using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rasa.ClientData;
using Rasa.Data;
using Rasa.Game;
using Rasa.Navigation;
using Rasa.Services.Preloader.Missions.Ashen;
using Rasa.Structures;
using Rasa.Test.Missions.Marshes;
using Rasa.Test.Missions.Wilderness;

namespace Rasa.Test.Missions.Ashen
{
    using F = MarshesClientFloorTests;
    using X = AshenFixBV1;

    /// <summary>
    /// Ashen fix job B (to-fix row 5): Chemical Oversight's (1244) Thrax Overseer Exing, pool 520007, stands on the flat at the
    /// mesa's south foot, and 1244's marker on him.
    ///
    /// Why these tests: in the real client no walk reached him at set 2's spot on the mesa's slope: every navmesh route ended on
    /// a flank the client does not climb. A spot that only the navmesh reaches, a walk with a step over 0.9 m or something in
    /// the way at chest height, a marker off him, or a Down that does not put set 2's pool and marker back would block 1244 again.
    ///
    /// The map: Ligo Ashen Desert (1734), loaded as AshenLeadInsTests loads it. The client floor checks read the client's files
    /// (as MarshesClientFloorTests).
    /// </summary>
    [TestClass]
    [DoNotParallelize]
    public class AshenFixBTests
    {
        private const string FixB = "20271110000610_Ashen_fix_b";

        /// <summary>The most the client's floor rises from one metre to the next on a walk (real client and probe, 2026-11-09).</summary>
        internal const float MaxClientStep = 0.9f;

        /// <summary>The height over the floor that must be clear from one metre to the next.</summary>
        internal const float Chest = 1.2f;

        /// <summary>The heights over the floor at knee and head that must be clear as well (fix B review): an obstacle 0.9-1.2 m high passes under the chest line.</summary>
        internal const float Knee = 0.5f, Head = 1.8f;

        /// <summary>The walk is sampled every half metre along its corners as one line.</summary>
        internal const float Spacing = 0.5f;

        /// <summary>The places the real client reached on its own feet near the mesa (1242's Atta pool 790051, 1247's camp pools 790087, 790085).</summary>
        internal static readonly (string Name, Vector3 At)[] RealClientPlaces =
        {
            ("the Mauna Barrens basin (pool 790051)", new Vector3(-405f, 300.97f, -272f)),
            ("the Sheitan Highway camp (pool 790087)", new Vector3(-160f, 304.19f, -260f)),
            ("the Sheitan Highway camp (pool 790085)", new Vector3(-180f, 306.57f, -305f))
        };

        /// <summary>The pools of later migrations (set 7's): they go down and up with the Down to fix B's predecessor.</summary>
        private static readonly uint[] LaterPools = AshenScavengerNpcsV1.NitroglazerPools.Concat(AshenScavengerNpcsV1.MachinaPools).Select(pool => pool.Pool).ToArray();

        private static Vector3 V((double X, double Y, double Z) at) => new((float)at.X, (float)at.Y, (float)at.Z);

        /// <summary>
        /// The pool as the server loads it: Exing's row (creature, count, radius 0, respawn as set 2 left it) at the new place;
        /// 1244's one marker (r15) on it at the navmesh ground; Exing comes down within 3 m of it, on the ground.
        /// </summary>
        [TestMethod]
        public void ExingStandsAtTheMesasFootWithTheMarkerOnHim()
        {
            using var harness = WildernessRuntimeTestHarness.Create();
            var row = harness.World.SpawnPoolEntries.AsNoTracking().Single(entry => entry.Id == X.Pool);
            Assert.AreEqual((X.Exing, 0.0), (row.Creature1Id, row.Radius), "Exing's point pool");
            Assert.IsLessThan(0.01, Vector3.Distance(V(X.PoolNow), V((row.PosX, row.PosY, row.PosZ))), $"at {X.PoolNow}");
            var markers = harness.World.MissionIndicatorEntries.AsNoTracking()
                .Where(entry => entry.MissionId == X.MissionId && entry.ContentRevision == AshenMissionDataV1.Revision).ToList();
            Assert.HasCount(1, markers, "1244's one marker");
            Assert.AreEqual((X.Marker.Objective, X.Marker.Indicator, AshenChemicalOversightV1.MarkerRadius), (markers[0].ObjectiveId, markers[0].IndicatorId, markers[0].Radius));
            Assert.IsLessThan(0.01, Vector3.Distance(V(X.MarkerNow), V((markers[0].PosX, markers[0].PosY, markers[0].PosZ))), "the marker on the point");

            var desert = AshenLeadInsTests.EnterAshen(harness, AshenLeadInsTests.ShadowsEdgeWaypoint);
            Assert.AreEqual(X.MarkerNow.Y, desert.NavMesh.GroundHeight(V(X.PoolNow)) ?? float.NaN, 0.05, "the marker at the navmesh ground");
            Plateau.PlateauCampResistanceTests.Spawn(desert, X.Pool);
            var exing = MarshesPaludosTests.Alive(desert).Single(candidate => candidate.DbId == X.Exing && candidate.SpawnPool?.DbId == X.Pool);
            Assert.IsLessThan(3f, Vector2.Distance(new((float)X.PoolNow.X, (float)X.PoolNow.Z), new(exing.Position.X, exing.Position.Z)), "Exing at the point");
            MarshesPaludosTests.AssertOnGround(desert, exing.Position, "Exing");
        }

        /// <summary>
        /// The play's case, on the client's floor: the navmesh's walks to Exing from the Shadow's Edge Post waypoint and from the
        /// places the real client reached near the mesa (the Barrens basin, the highway camp) keep a client floor all the way,
        /// one metre at a time, never more than 0.9 m up, with nothing of the placed meshes in the way at chest height; the
        /// Stonewall Ridge waypoint's navmesh walk is complete (the real client walked it to the mesa's foot, 2026-11-09). Set 2's
        /// spot on the mesa is not reached on the client floor from the basin or the camp (why it moved).
        /// </summary>
        [TestMethod]
        public void ExingIsWalkedToOnTheClientsFloor()
        {
            var dataDir = F.ClientData();
            using var harness = WildernessRuntimeTestHarness.Create();
            var desert = AshenLeadInsTests.EnterAshen(harness, AshenLeadInsTests.ShadowsEdgeWaypoint);
            var nav = desert.NavMesh;
            using var meshes = new MeshLibrary(dataDir, F.MeshCsv());
            var geometry = MapGeometry.Load(Path.Combine(dataDir, "maps", harness.World.MapInfoEntries.AsNoTracking()
                .Single(map => map.Id == AshenMissionDataV1.MapContextId).MapName), meshes, 1);
            var exing = nav.Nearest(V(X.PoolNow)).Value;
            foreach (var (name, from) in RealClientPlaces.Prepend(("the Shadow's Edge Post waypoint", AshenLeadInsTests.ShadowsEdgeWaypoint)))
            {
                var failure = ClientFloorWalk(nav, geometry, from, exing);
                Assert.IsNull(failure, $"Exing from {name}: {failure}");
            }
            var back = ClientFloorWalk(nav, geometry, exing, AshenLeadInsTests.ShadowsEdgeWaypoint);
            Assert.IsNull(back, $"from Exing back to the Shadow's Edge Post waypoint: {back}");
            Assert.IsTrue(nav.FindPath(nav.Nearest(AshenLeadInsTests.StonewallWaypoint).Value, exing, out var complete) != null && complete,
                "Exing walked to from the Stonewall Ridge waypoint on the navmesh");

            var before = nav.Nearest(V(X.PoolBefore)).Value;
            foreach (var (name, from) in RealClientPlaces.Take(2))
            {
                var failure = ClientFloorWalk(nav, geometry, from, before);
                Assert.IsTrue(failure?.StartsWith("no client floor within", StringComparison.Ordinal) == true,
                    $"set 2's spot from {name}: the client floor does not climb the flank ({failure})");
            }
        }

        /// <summary>
        /// The ground round the point (fix A's ClearRadius, where Exing strolls and fights): every navmesh floor on a 1 m grid
        /// is one floor, joined to the Shadow's Edge Post waypoint's ground, within 1 m of a client floor (up to 1.5 m over it)
        /// with no client surface over it.
        /// </summary>
        [TestMethod]
        public void TheGroundRoundExingIsOpenAndJoined()
        {
            var dataDir = F.ClientData();
            using var harness = WildernessRuntimeTestHarness.Create();
            var desert = AshenLeadInsTests.EnterAshen(harness, AshenLeadInsTests.ShadowsEdgeWaypoint);
            var nav = desert.NavMesh;
            var region = nav.RegionArea(nav.Nearest(AshenLeadInsTests.ShadowsEdgeWaypoint).Value);
            var centre = V(X.PoolNow);
            var columns = new List<List<Vector3>>();
            var reach = (int)Math.Ceiling(X.ClearRadius);
            for (var dz = -reach; dz <= reach; dz++)
                for (var dx = -reach; dx <= reach; dx++)
                {
                    if (dx * dx + dz * dz > X.ClearRadius * X.ClearRadius)
                        continue;
                    var heights = new SortedSet<float>();
                    for (var h = -8; h <= 12; h++)
                    {
                        var probe = new Vector3(centre.X + dx, centre.Y + h, centre.Z + dz);
                        if (nav.Nearest(probe) is { } nearest && MathF.Abs(nearest.X - probe.X) < 0.3f && MathF.Abs(nearest.Z - probe.Z) < 0.3f &&
                            nav.GroundHeight(probe) is { } y)
                            heights.Add(MathF.Round(y, 1));
                    }
                    if (heights.Count == 0)
                        continue;
                    var column = new List<Vector3>();
                    foreach (var y in heights)
                        if (column.Count == 0 || y - column[^1].Y >= 2)
                            column.Add(new Vector3(centre.X + dx, y, centre.Z + dz));
                    columns.Add(column);
                }
            Assert.IsGreaterThan(500, columns.Count, "the floors round the point are read");
            Assert.IsEmpty(columns.Where(column => column.Count != 1).Take(5).ToList(), "one floor in each spot");
            var ground = columns.SelectMany(column => column).ToList();
            Assert.IsEmpty(ground.Where(at => nav.RegionArea(at) != region).Take(5).ToList(), "joined to the waypoints");

            using var meshes = new MeshLibrary(dataDir, F.MeshCsv());
            var geometry = MapGeometry.Load(Path.Combine(dataDir, "maps", harness.World.MapInfoEntries.AsNoTracking()
                .Single(map => map.Id == AshenMissionDataV1.MapContextId).MapName), meshes, 1);
            var near = F.Near(geometry, ground, 0.5f);
            var failures = new List<string>();
            for (var i = 0; i < ground.Count; i++)
            {
                var at = ground[i];
                if (F.FloorAt(near[i], at, at.Y - 2, at.Y + 1.5f) is not { } y || y - at.Y > 1 || at.Y - y > 1.5f)
                    failures.Add(FormattableString.Invariant($"no client floor at ({at.X:0.0}, {at.Y:0.00}, {at.Z:0.0})"));
                if (near[i].Any(t => F.Hit(at + new Vector3(0, 1, 0), Vector3.UnitY, t.A, t.B, t.C) is { } up && up < 40))
                    failures.Add(FormattableString.Invariant($"a client surface over ({at.X:0.0}, {at.Y:0.00}, {at.Z:0.0})"));
            }
            Assert.IsEmpty(failures, $"{failures.Count}: " + string.Join("; ", failures.Take(10)));
        }

        /// <summary>
        /// Ashen_fix_b rolls back: Down puts set 2's pool spot and marker back and takes out its evidence row; no other Ashen pool
        /// moves; Up again, the fix is back.
        /// </summary>
        [TestMethod]
        public void FixBRollsBackWithItsMigration()
        {
            using var harness = WildernessRuntimeTestHarness.Create();
            var world = harness.World;
            (double X, double Y, double Z) Pool()
            {
                var row = world.SpawnPoolEntries.AsNoTracking().Single(entry => entry.Id == X.Pool);
                return (row.PosX, row.PosY, row.PosZ);
            }
            (double X, double Y, double Z) Marker()
            {
                var row = world.MissionIndicatorEntries.AsNoTracking().Single(entry => entry.MissionId == X.MissionId &&
                    entry.ContentRevision == AshenMissionDataV1.Revision && entry.ObjectiveId == X.Marker.Objective && entry.IndicatorId == X.Marker.Indicator);
                return (row.PosX, row.PosY, row.PosZ);
            }
            bool Evidence() => world.MissionEvidenceEntries.AsNoTracking().Any(entry => entry.MissionId == X.MissionId &&
                entry.ContentRevision == AshenMissionDataV1.Revision && entry.EvidenceId == X.Evidence);
            void Is((double X, double Y, double Z) expected, (double X, double Y, double Z) actual, string what) =>
                Assert.IsLessThan(0.01, Vector3.Distance(V(expected), V(actual)), $"{what}: {expected}, is {actual}");
            string Others() => string.Join("; ", world.SpawnPoolEntries.AsNoTracking()
                .Where(entry => entry.MapContextId == AshenMissionDataV1.MapContextId && entry.Id != X.Pool && !LaterPools.Contains(entry.Id)).OrderBy(entry => entry.Id)
                .Select(entry => new { entry.Id, entry.PosX, entry.PosY, entry.PosZ, entry.Radius }).AsEnumerable().Select(entry => entry.ToString()));
            void Fixed()
            {
                Is(X.PoolNow, Pool(), "the pool");
                Is(X.MarkerNow, Marker(), "the marker");
                Assert.IsTrue(Evidence(), "fix B's evidence");
            }
            var others = Others();

            Fixed();
            world.GetService<IMigrator>().Migrate(AshenMissionTests.Previous(world, FixB));
            world.ChangeTracker.Clear();
            Assert.AreEqual(AshenMaunaBarrensNpcsV1.ExingAt, Pool(), "set 2's spot, as set 2 wrote it");
            Assert.AreEqual(AshenMaunaBarrensNpcsV1.ExingAt, Marker(), "set 2's marker, as set 2 wrote it");
            Assert.IsFalse(Evidence(), "no fix B evidence");
            Assert.IsTrue(world.MissionContentDefinitionEntries.Any(entry => entry.MissionId == X.MissionId && entry.ContentRevision == AshenMissionDataV1.Revision && entry.Enabled),
                "1244 stays (set 2)");
            Assert.AreEqual(others, Others(), "no other Ashen pool moves");

            world.GetService<IMigrator>().Migrate();
            world.ChangeTracker.Clear();
            Fixed();
            Assert.AreEqual(others, Others(), "no other Ashen pool moves");
        }

        /// <summary>
        /// The navmesh's walk from <paramref name="from"/> to <paramref name="to"/> on the client's floor: one metre at a time
        /// along its corners, the floor at each never more than MaxClientStep over the one before (down to 2.5 m under it), and
        /// nothing of the placed meshes in the way at Chest height from one to the next (the terrain heightmap is a surface to
        /// stand on, not a solid: TerrainHeightmap.AppendTriangles; its steps are the floor's). Null when it gets there, else why not.
        /// </summary>
        internal static string ClientFloorWalk(NavMeshQuery nav, MapGeometry geometry, Vector3 from, Vector3 to)
        {
            var start = nav.Nearest(from) ?? from;
            var path = nav.FindPath(start, to, out var complete);
            if (path == null || !complete)
                return "no complete navmesh walk";
            return ClientFloorLine(geometry, path.Prepend(start).ToList(), to);
        }

        /// <summary>
        /// The walk along <paramref name="corners"/> (in order; the first one's height is the start's floor) on the client's floor,
        /// with ClientFloorWalk's checks: for a route the navmesh does not join (Ashen fix C: Ashoka's corridor, upstream N18).
        /// Where <paramref name="meshFloorOnly"/> holds, only the placed meshes are floor, not the heightmap (a Brann corridor
        /// the terrain runs through, AshenFormalComplaintsTests.InAshokaCorridor). With <paramref name="halfWidth"/> the knee, chest
        /// and head lines are checked that far to each side as well (a player's body, not a line: doorways and corners).
        /// </summary>
        internal static string ClientFloorLine(MapGeometry geometry, IReadOnlyList<Vector3> corners, Vector3 to, Func<Vector3, bool> meshFloorOnly = null, float halfWidth = 0)
        {
            // Points every Spacing along the corners as one line (a short leg between corners is sampled too), and the last corner.
            var points = new List<Vector3> { corners[0] };
            var carried = 0f;
            for (var k = 1; k < corners.Count; k++)
            {
                var length = Vector2.Distance(new(corners[k - 1].X, corners[k - 1].Z), new(corners[k].X, corners[k].Z));
                var along = Spacing - carried;
                for (; along <= length; along += Spacing)
                    points.Add(Vector3.Lerp(corners[k - 1], corners[k], along / length));
                carried = length - (along - Spacing);
            }
            if (Vector2.Distance(new(points[^1].X, points[^1].Z), new(corners[^1].X, corners[^1].Z)) > 0.01f)
                points.Add(corners[^1]);
            var near = F.Near(geometry, points, 2);
            bool OnTerrain((Vector3 A, Vector3 B, Vector3 C) t) =>
                new[] { t.A, t.B, t.C }.All(v => geometry.Terrain.Height(v.X, v.Z) is { } h && MathF.Abs(h - v.Y) < 0.01f);
            List<(Vector3 A, Vector3 B, Vector3 C)> Floor(int i) => meshFloorOnly?.Invoke(points[i]) == true ? near[i].Where(t => !OnTerrain(t)).ToList() : near[i];
            var y = F.FloorAt(Floor(0), points[0], points[0].Y - 2, points[0].Y + 1) ?? points[0].Y;
            var floors = new List<Vector3>();
            for (var i = 0; i < points.Count; i++)
            {
                if (F.FloorAt(Floor(i), points[i] with { Y = y }, y - 2.5f, y + MaxClientStep) is not { } floor)
                    return FormattableString.Invariant($"no client floor within {MaxClientStep} m up at ({points[i].X:0.0}, {points[i].Z:0.0}) from {y:0.00} (navmesh {points[i].Y:0.00})");
                var here = points[i] with { Y = floor };
                // The rise over the last metre of the walk (the samples back to 1 m behind), not only from the sample before.
                for (var back = floors.Count - 1; back >= 0; back--)
                {
                    var run = Vector2.Distance(new(floors[back].X, floors[back].Z), new(here.X, here.Z));
                    if (run > 1.001f)
                        break;
                    if (here.Y - floors[back].Y > MaxClientStep)
                        return FormattableString.Invariant($"no client floor within {MaxClientStep} m up at ({here.X:0.0}, {here.Z:0.0}): {here.Y - floors[back].Y:0.00} m up over {run:0.00} m");
                }
                if (floors.Count > 0)
                {
                    var before = floors[^1];
                    var solids = near[i - 1].Concat(near[i]).Where(t => !OnTerrain(t)).ToList();
                    var across = Vector3.Normalize(new Vector3(before.Z - here.Z, 0, here.X - before.X)) * halfWidth;
                    var sides = halfWidth > 0 ? new[] { Vector3.Zero, across, -across } : new[] { Vector3.Zero };
                    foreach (var (height, name) in new[] { (Knee, "knee"), (Chest, "chest"), (Head, "head") })
                        foreach (var side in sides)
                            if (!F.Clear(solids, before + side + new Vector3(0, height, 0), here + side + new Vector3(0, height, 0)))
                                return FormattableString.Invariant($"something in the way at {name} height from ({before.X:0.0}, {before.Y:0.00}, {before.Z:0.0}) to ({here.X:0.0}, {here.Y:0.00}, {here.Z:0.0}){(side == Vector3.Zero ? "" : " beside the line")}");
                }
                y = floor;
                floors.Add(here);
            }
            return MathF.Abs(y - to.Y) > 1.5f ? FormattableString.Invariant($"ends on the floor at {y:0.00}, {to.Y:0.00} wanted") : null;
        }
    }
}
