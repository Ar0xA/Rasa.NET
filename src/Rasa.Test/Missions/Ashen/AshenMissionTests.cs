using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rasa.Test.Missions.Ashen
{
    using Rasa.Data;
    using Rasa.Managers;
    using Rasa.Services.Preloader.Missions.Ashen;
    using Rasa.Services.Preloader.Missions.Crucible;
    using Rasa.Structures;
    using Rasa.Structures.World;
    using Rasa.Test.Missions.Wilderness;

    /// <summary>
    /// The Ligo Ashen Desert missions (AshenMissionDataV1, revision ashen_1_16_5): set 1, the lead-ins, Sergeant Bernard Ames'
    /// The Dustiest Place on Earth (1250), Captain Flynn Harris' Report to Stonewall Ridge (1273), Captain Marcus Emmons'
    /// Fithik Infestation (1274), Lt. Colonel Trent Ivan's Good Day to Die (1283) and Lt. Colonel Dania Caldwell's You Can't
    /// Drink Ash (1284), with Ames, Ivan, Caldwell and Captain Akio Yamamoto new and the upstream rows set 1 uses moved
    /// (Ashen_lead_ins); set 2, the Mauna Barrens, Lieutenant Simon Kuang's Angry Angry Atta (1242), Harmful Mutations (1243)
    /// and Chemical Oversight (1244) and Captain Sera Karter's Eyes on the Ground (1245), with Kuang, Doctor Jung Kwon, Karter
    /// and the Ashen Atta new and Thrax Overseer Exing's pool moved (Ashen_mauna_barrens); set 3, the Sheitan Highway, Karter's
    /// Highway to Hell (1247), Lt. Colonel Trent Ivan's Air Superiority (1248) and Lt. Colonel Dania Caldwell's Artillery
    /// Annihilation (1249), with the Thrax Ravager name on the Ashen Thrax Grenadier, the highway's Thrax pools, the Desert
    /// Predator on two beats and the highway's four mortars each its own row (Ashen_sheitan_highway); set 4, the Boneyard,
    /// Lieutenant Jan Blood's Xanxless Job (1262), Captain Akio Yamamoto's Fallen Soldiers (1263) and Lieutenant Gabriel
    /// Infanger's Stalking the Stalkers (1272), with Infanger, the Boneyard's Xanx pools and the Desert Stalker new
    /// (Ashen_boneyard).
    ///
    /// Why these tests: the client's text ids and packages are written out here from the client tables, not taken from the
    /// data classes, so a wrong id fails; the NPC rows, rewards, prerequisites and markers are pinned; the migration rolls back
    /// to the one directly before it.
    ///
    /// [TestCategory]: none, as PlateauCampResistanceTests.
    /// </summary>
    [TestClass]
    [DoNotParallelize]
    public class AshenMissionTests
    {
        /// <summary>The Ashen Desert missions the World migrations enable on the Ashen revision, for the tests that pin the enabled set.</summary>
        internal static readonly uint[] MissionIds =
        {
            AshenDustiestPlaceV1.MissionId, AshenReportToStonewallV1.MissionId, AshenFithikInfestationV1.MissionId,
            AshenGoodDayToDieV1.MissionId, AshenCantDrinkAshV1.MissionId,
            AshenAngryAngryAttaV1.MissionId, AshenHarmfulMutationsV1.MissionId, AshenChemicalOversightV1.MissionId,
            AshenEyesOnTheGroundV1.MissionId,
            AshenHighwayToHellV1.MissionId, AshenAirSuperiorityV1.MissionId, AshenArtilleryAnnihilationV1.MissionId,
            AshenXanxlessJobV1.MissionId, AshenFallenSoldiersV1.MissionId, AshenStalkingTheStalkersV1.MissionId
        };

        /// <summary>
        /// Every visible objective has a marker (EveryVisibleObjectiveHasAMarker): set 1's five (each report's one at its
        /// receiver, Fithik Infestation's on the Stonewall Ridge Fithik pool); set 2's twelve (1242's four on the Atta Soldier and
        /// Worker pools, 1243's two on the Mutated Atta pools, 1244's on Exing, 1245's five on the beacon spots); set 3's ten
        /// (1247's four on the Thrax Ravager and Soldier pools, 1248's two on the Desert Predators' beats, 1249's four on the
        /// mortars); set 4's six (1262's three on the Xanx pools, 1263's one over the six fallen, 1272's two on the Desert Stalker
        /// pools).
        /// </summary>
        internal const int Indicators = 5 + 12 + 10 + 6;

        private const string LeadIns = "20271110000000_Ashen_lead_ins";
        private const string MaunaBarrens = "20271110000100_Ashen_mauna_barrens";
        private const string SheitanHighway = "20271110000200_Ashen_sheitan_highway";
        private const string Boneyard = "20271110000400_Ashen_boneyard";
        private const uint Map = 1734;

        private const uint Ames = 790000, Ivan = 790001, Caldwell = 790002, Yamamoto = 790003;
        private const uint MasonLinier = 510010, Harris = 510008, Emmons = 510009, DarisLinier = 510007;
        private const uint Kuang = 790040, Kwon = 790041, Karter = 790042;
        private const uint AttaSoldier = 790043, AttaWorker = 790044, MutatedSoldier = 790045, Exing = 520007;
        private const uint Ravager = 531009, ThraxSoldier = 531008, Predator = 790080, Mortar = 592011;
        private static readonly uint[] MortarCopies = { 790081, 790082, 790083, 790084 };
        private static readonly uint[] MortarPools = { 592191, 592192, 592193, 592194 };
        private const uint Blood = 510013, Infanger = 790120, Xanx = 540020, Stalker = 790121;
        private static readonly uint[] XanxPools = { 790122, 790123, 790124 };
        private static readonly uint[] StalkerPools = { 790125, 790126 };

        /// <summary>The migration directly before <paramref name="migration"/> (IMigrationsAssembly, ordinal order), as CrucibleMissionTests.Previous.</summary>
        internal static string Previous(DbContext world, string migration) => Rasa.Test.Missions.Crucible.CrucibleMissionTests.Previous(world, migration);

        [TestMethod]
        public void TheMissionsAreEnabledOperationalAndGivenByTheirNpcs()
        {
            var expected = new (uint Mission, uint? Giver, uint? Receiver, uint Level)[]
            {
                (1250, Ames, MasonLinier, 40), (1273, Harris, Emmons, 40), (1274, Emmons, Emmons, 40), (1283, Ivan, Yamamoto, 40),
                (1284, Caldwell, DarisLinier, 40), (1242, Kuang, Kuang, 40), (1243, Kuang, Kwon, 40), (1244, Kuang, Kuang, 41),
                (1245, Karter, Karter, 41), (1247, Karter, Karter, 41), (1248, Ivan, Ivan, 42), (1249, Caldwell, Caldwell, 41),
                (1262, Blood, Blood, 40), (1263, Yamamoto, Yamamoto, 40), (1272, Infanger, Infanger, 41)
            };
            using var harness = WildernessRuntimeTestHarness.Create();
            var enabled = harness.World.MissionContentDefinitionEntries.AsNoTracking()
                .Where(entry => entry.Enabled && entry.ContentRevision == AshenMissionDataV1.Revision).ToArray();
            CollectionAssert.AreEquivalent(MissionIds, enabled.Select(entry => entry.MissionId).ToArray());
            foreach (var (mission, giver, receiver, level) in expected)
            {
                var entry = enabled.Single(row => row.MissionId == mission);
                Assert.AreEqual<uint?>(giver, entry.GiverId, $"{mission} giver");
                Assert.AreEqual<uint?>(receiver, entry.ReceiverId, $"{mission} receiver");
                Assert.AreEqual<uint?>(level, entry.Level, $"{mission} level");
                Assert.AreEqual<uint?>(10000016U, entry.CategoryId, "Battlefield (Ashen Desert), missioncategorylanguage 10000016");
            }
            Assert.IsFalse(harness.Manager.LoadMissions().BlocksReadiness);
            foreach (var id in MissionIds)
                Assert.IsTrue(harness.Manager.LoadedMissions[id].IsOperational,
                    $"{id}: {harness.Manager.LoadedMissions[id].OperationalDiagnostic}");
        }

        /// <summary>
        /// The new NPCs: the client's names (creaturenamelanguage 9279, 9261, 9262, 9303) and packages (objectiveconversation
        /// 1283,1 1414; Ames', Ivan's and Caldwell's server-only), friendly, standing still, with their own hit points, on Ashen
        /// Desert; the upstream rows set 1 uses at their new places with their packages (1389, 1412, 1411, 1476).
        /// </summary>
        [TestMethod]
        public void TheNpcsHaveTheClientsNamesAndPackages()
        {
            using var harness = WildernessRuntimeTestHarness.Create();
            var world = harness.World;
            foreach (var (npc, name, package, cls, level) in new (uint, uint, uint, uint, uint)[]
            {
                (Ames, 9279, 790000, 3846, 40), (Ivan, 9261, 790001, 3846, 40), (Caldwell, 9262, 790002, 3848, 40), (Yamamoto, 9303, 1414, 3846, 49),
                (Kuang, 9291, 790040, 3846, 40), (Kwon, 9298, 790041, 3848, 40), (Karter, 9281, 790042, 3848, 48),
                (Infanger, 9304, 790120, 3846, 40)
            })
            {
                var creature = world.CreatureEntries.AsNoTracking().Single(row => row.Id == npc);
                Assert.AreEqual((name, level, 1U, cls, 0U, 0U), (creature.NameId, creature.Level, creature.Faction, creature.ClassId,
                    creature.RunSpeed, creature.WalkSpeed), $"{npc}");
                Assert.AreEqual(package, world.NpcPackageEntries.AsNoTracking().Single(row => row.Id == npc).PackageId, $"{npc} package");
                var stat = world.CreatureStatEntries.AsNoTracking().Single(row => row.Id == npc);
                Assert.AreEqual((4500, 300), (stat.Health, stat.Armor), $"{npc} stats");
                Assert.IsTrue(world.CreatureAppearanceEntries.AsNoTracking().Any(row => row.Id == npc), $"{npc} has a look");
                var pool = world.SpawnPoolEntries.AsNoTracking().Single(row => row.Id == npc);
                Assert.AreEqual((Map, npc, (byte)1, (byte)1), (pool.MapContextId, pool.Creature1Id, pool.Creature1MinCount, pool.Creature1MaxCount), $"{npc} pool");
            }

            // The places (TaRapedia's for Yamamoto; the probe's by the client statics for the others).
            foreach (var (pool, x, z) in new (uint, double, double)[]
            {
                (Ames, 345, -818), (Ivan, -97, -792), (Caldwell, -158, -792), (Yamamoto, 686, -495), (MasonLinier, -132, -875),
                (Harris, 405, -459.5), (Emmons, -62, -414), (DarisLinier, -507.4, 162.4), (Kuang, -205, -736), (Kwon, -89, -822),
                (Karter, -112, -748), (Exing, -289, -264), (Infanger, 676, -505), (Blood, 682.4, -516.4)
            })
            {
                var row = world.SpawnPoolEntries.AsNoTracking().Single(entry => entry.Id == pool);
                Assert.IsLessThan(0.01, System.Math.Abs(row.PosX - x) + System.Math.Abs(row.PosZ - z), $"pool {pool} at ({x}, {z})");
                Assert.AreEqual(Map, row.MapContextId, $"pool {pool} on Ashen Desert");
            }
            var packages = world.NpcPackageEntries.AsNoTracking().Where(row => row.Id == MasonLinier || row.Id == Harris || row.Id == Emmons ||
                row.Id == DarisLinier).AsEnumerable().ToDictionary(row => row.Id, row => row.PackageId);
            Assert.AreEqual((1389U, 1412U, 1411U, 1476U), (packages[MasonLinier], packages[Harris], packages[Emmons], packages[DarisLinier]));
            Assert.AreEqual(1, world.NpcPackageEntries.AsNoTracking().Count(row => row.PackageId == 1414), "only Yamamoto has 1414");
            // Set 4: Blood gives and takes 1262 by his id; the client gives him no talk in it, and he keeps upstream's row (no package).
            var blood = world.CreatureEntries.AsNoTracking().Single(row => row.Id == Blood);
            Assert.AreEqual((9305U, 1U), (blood.NameId, blood.Faction), "Lieutenant Jan Blood, friendly");
            Assert.IsFalse(world.NpcPackageEntries.AsNoTracking().Any(row => row.Id == Blood), "Blood: no package, as upstream");
        }

        /// <summary>
        /// The client's own texts: the ids are written out here from the client tables (missionconversation,
        /// missionobjective, objectiveconversation), not taken from the data classes, so a wrong id in those fails.
        /// </summary>
        [TestMethod]
        public void TitlesAndObjectivesUseTheClientsTexts()
        {
            var expected = new (uint Mission, uint Title, (uint Objective, uint Name, uint Body, uint? Counter)[] Objectives)[]
            {
                (1250, 10000, new (uint, uint, uint, uint?)[] { (1, 10005, 10006, null) }),
                (1273, 10232, new (uint, uint, uint, uint?)[] { (1, 10237, 10238, null) }),
                (1274, 10240, new (uint, uint, uint, uint?)[] { (1, 10245, 10246, 10247) }),
                (1283, 10354, new (uint, uint, uint, uint?)[] { (1, 10359, 10360, null) }),
                (1284, 10362, new (uint, uint, uint, uint?)[] { (1, 10367, 10368, null) }),
                (1242, 9914, new (uint, uint, uint, uint?)[] { (1, 9919, 9920, 9921), (2, 9922, 9923, 9924) }),
                (1243, 9925, new (uint, uint, uint, uint?)[] { (1, 9930, 9931, null) }),
                (1244, 9932, new (uint, uint, uint, uint?)[] { (1, 9937, 9938, null) }),
                (1245, 9939, new (uint, uint, uint, uint?)[]
                {
                    (1, 9944, 9945, null), (2, 9946, 9947, null), (3, 9948, 9949, null), (4, 9950, 9951, null), (5, 9952, 9953, null)
                }),
                (1247, 9962, new (uint, uint, uint, uint?)[] { (1, 9967, 9968, 9969), (3, 9973, 9974, 9975) }),
                (1248, 9976, new (uint, uint, uint, uint?)[] { (1, 9981, 9982, 9983) }),
                (1249, 9984, new (uint, uint, uint, uint?)[] { (1, 9989, 9990, null), (2, 9991, 9992, null), (3, 9993, 9994, null), (4, 9995, 9996, null) }),
                (1262, 10121, new (uint, uint, uint, uint?)[] { (1, 10126, 10127, 10128) }),
                // 1263's 2 is server-only and hidden: it carries 1's texts (the client has no objective 2).
                (1263, 10136, new (uint, uint, uint, uint?)[] { (1, 10141, 10142, null), (2, 10141, 10142, null) }),
                (1272, 10224, new (uint, uint, uint, uint?)[] { (1, 10229, 10230, 10231) })
            };
            using var harness = WildernessRuntimeTestHarness.Create();
            foreach (var (mission, title, objectives) in expected)
            {
                Assert.AreEqual(title, harness.World.MissionContentDefinitionEntries.AsNoTracking()
                    .Single(entry => entry.MissionId == mission && entry.ContentRevision == AshenMissionDataV1.Revision)
                    .ClientNameTextId, $"{mission} title");
                var actual = harness.World.MissionObjectiveDefinitionEntries.AsNoTracking()
                    .Where(entry => entry.MissionId == mission && entry.ContentRevision == AshenMissionDataV1.Revision).ToArray();
                CollectionAssert.AreEquivalent(objectives.Select(row => row.Objective).ToArray(),
                    actual.Select(row => row.ObjectiveId).ToArray(), $"{mission} objectives");
                foreach (var (objective, name, body, counter) in objectives)
                {
                    var row = actual.Single(entry => entry.ObjectiveId == objective);
                    Assert.AreEqual(name, row.ClientNameTextId, $"{mission}.{objective} name");
                    Assert.AreEqual(body, row.ClientBodyTextId, $"{mission}.{objective} body");
                    Assert.AreEqual(counter, row.ClientCounter0TextId, $"{mission}.{objective} counter0");
                    Assert.IsNull(row.ClientCounter1TextId, $"{mission}.{objective} counter1");
                    Assert.IsNull(row.ClientCounter2TextId, $"{mission}.{objective} counter2");
                }
            }

            // The talks at the client's packages (objectiveconversation 1250,1 1389; 1273,1 1411; 1283,1 1414; 1284,1 1476), each
            // with the client's variant 1.
            var talks = harness.World.Set<MissionTriggerEntry>().AsNoTracking()
                .Where(entry => entry.ContentRevision == AshenMissionDataV1.Revision && entry.Kind == MissionTriggerKind.Conversation)
                .AsEnumerable().Select(entry => (entry.MissionId, entry.ObjectiveId, entry.NpcPackageId, entry.PlayerFlagId))
                .OrderBy(entry => entry.MissionId).ThenBy(entry => entry.ObjectiveId).ToArray();
            CollectionAssert.AreEqual(new (uint, uint, uint?, uint?)[]
            {
                (1250, 1, 1389, 1), (1273, 1, 1411, 1), (1283, 1, 1414, 1), (1284, 1, 1476, 1)
            }, talks);

            // Fithik Infestation counts the Fithik species (CreatureFlag 72), counter 0, to 10.
            var kill = harness.World.Set<MissionTriggerEntry>().AsNoTracking()
                .Single(entry => entry.ContentRevision == AshenMissionDataV1.Revision && entry.MissionId == 1274 && entry.Kind == MissionTriggerKind.ProgressEvent);
            Assert.AreEqual(((byte?)MissionProgressEventKind.CreatureFlagKilled, (uint?)72, (uint?)0, (uint?)10),
                (kill.EventKind, kill.SubjectId, kill.CounterId, kill.TargetValue));
            Assert.AreEqual(72, (int)CreatureFlag.SpeciesFithik, "the client's Fithik species flag");

            // Set 2's kills: 1242 the new Ashen Atta Soldier and Worker, ten each on counter 0; 1244 Exing, once.
            var kills = harness.World.Set<MissionTriggerEntry>().AsNoTracking()
                .Where(entry => entry.ContentRevision == AshenMissionDataV1.Revision && (entry.MissionId == 1242 || entry.MissionId == 1244) &&
                                entry.Kind == MissionTriggerKind.ProgressEvent).AsEnumerable()
                .Select(entry => (entry.MissionId, entry.ObjectiveId, entry.EventKind, entry.SubjectId, entry.CounterId, entry.TargetValue))
                .OrderBy(entry => entry.MissionId).ThenBy(entry => entry.ObjectiveId).ToArray();
            var killed = (byte?)MissionProgressEventKind.CreatureKilled;
            CollectionAssert.AreEqual(new (uint, uint, byte?, uint?, uint?, uint?)[]
            {
                (1242, 1, killed, AttaSoldier, 0, 10), (1242, 2, killed, AttaWorker, 0, 10), (1244, 1, killed, Exing, null, null)
            }, kills);
            // 1243 picks up four Mutated Atta Blood Samples (client item class 25409); 1245's five beacons are scene results 1-5.
            var samples = harness.World.Set<MissionTriggerEntry>().AsNoTracking()
                .Single(entry => entry.ContentRevision == AshenMissionDataV1.Revision && entry.MissionId == 1243 && entry.Kind == MissionTriggerKind.ProgressEvent);
            Assert.AreEqual(((byte?)MissionProgressEventKind.ItemAcquired, (uint?)25409, (uint?)4), (samples.EventKind, samples.SubjectId, samples.TargetValue));
            // The sample: a personal drop of the Mutated Atta Soldier 790045 at 50% (ESTIMATE: no source gives a rate), four turned in.
            var drop = Scenes(harness).Single(scene => scene.MissionId == 1243).Scene.Items.Single();
            Assert.AreEqual((97458U, 50, 4U), (drop.ItemTemplateId, drop.Drop.ChancePercent, drop.TurnInQuantity));
            CollectionAssert.AreEqual(new[] { MutatedSoldier }, drop.Drop.CreatureIds.ToArray());
            var beacons = harness.World.Set<MissionTriggerEntry>().AsNoTracking()
                .Where(entry => entry.ContentRevision == AshenMissionDataV1.Revision && entry.MissionId == 1245 && entry.Kind == MissionTriggerKind.ProgressEvent)
                .AsEnumerable().OrderBy(entry => entry.ObjectiveId).Select(entry => (entry.ObjectiveId, entry.EventKind, entry.SubjectId, entry.CounterId)).ToArray();
            CollectionAssert.AreEqual(Enumerable.Range(1, 5).Select(n => ((uint)n, (byte?)MissionProgressEventKind.ScenarioEvent, (uint?)n, (uint?)1)).ToArray(), beacons);

            // Set 3's kills: 1247 the Thrax Ravager (531009) on 1 and the Thrax Soldier Mark VI (531008) on 3, ten each on counter 0;
            // 1248 the Desert Predator once on counter 0; 1249 Mortar n the copy in mortar pool n, once.
            var highway = harness.World.Set<MissionTriggerEntry>().AsNoTracking()
                .Where(entry => entry.ContentRevision == AshenMissionDataV1.Revision && (entry.MissionId == 1247 || entry.MissionId == 1248 ||
                                entry.MissionId == 1249) && entry.Kind == MissionTriggerKind.ProgressEvent).AsEnumerable()
                .Select(entry => (entry.MissionId, entry.ObjectiveId, entry.EventKind, entry.SubjectId, entry.CounterId, entry.TargetValue))
                .OrderBy(entry => entry.MissionId).ThenBy(entry => entry.ObjectiveId).ToArray();
            CollectionAssert.AreEqual(new (uint, uint, byte?, uint?, uint?, uint?)[]
            {
                (1247, 1, killed, Ravager, 0, 10), (1247, 3, killed, ThraxSoldier, 0, 10), (1248, 1, killed, Predator, 0, 1),
                (1249, 1, killed, 790081, null, null), (1249, 2, killed, 790082, null, null), (1249, 3, killed, 790083, null, null),
                (1249, 4, killed, 790084, null, null)
            }, highway);

            // Set 4's kills: 1262 the Xanx - Ashen Desert (540020, "Xanx Burrower") six on counter 0; 1272 the Desert Stalker once
            // on counter 0. 1263's hidden 2 counts the six fallen's uses (scene results 1-6, counter 1, to 6); 1 completes on it.
            var boneyard = harness.World.Set<MissionTriggerEntry>().AsNoTracking()
                .Where(entry => entry.ContentRevision == AshenMissionDataV1.Revision && (entry.MissionId == 1262 || entry.MissionId == 1263 ||
                                entry.MissionId == 1272) && entry.Kind == MissionTriggerKind.ProgressEvent).AsEnumerable()
                .Select(entry => (entry.MissionId, entry.ObjectiveId, entry.EventKind, entry.SubjectId, entry.CounterId, entry.TargetValue))
                .OrderBy(entry => entry.MissionId).ThenBy(entry => entry.ObjectiveId).ThenBy(entry => entry.SubjectId).ToArray();
            var scene = (byte?)MissionProgressEventKind.ScenarioEvent;
            CollectionAssert.AreEqual(new (uint, uint, byte?, uint?, uint?, uint?)[]
            {
                (1262, 1, killed, Xanx, 0, 6),
                (1263, 2, scene, 1, 1, 6), (1263, 2, scene, 2, 1, 6), (1263, 2, scene, 3, 1, 6), (1263, 2, scene, 4, 1, 6),
                (1263, 2, scene, 5, 1, 6), (1263, 2, scene, 6, 1, 6),
                (1272, 1, killed, Stalker, 0, 1)
            }, boneyard);
            var tags = Scenes(harness).Single(entry => entry.MissionId == 1263).Scene;
            CollectionAssert.AreEqual(new uint[] { 2 }, tags.HiddenObjectiveIds.ToArray(), "1263's 2 is hidden");
            var tag = tags.Items.Single();
            Assert.AreEqual((97464U, 6U, 1U), (tag.ItemTemplateId, tag.MaximumQuantity, tag.CounterObjectiveId), "Ashen AFS Dog Tag (client item class 25443), n/6 on 1");
        }

        /// <summary>
        /// Set 2's Atta: the client's names (creaturenamelanguage 9318 Ashen Atta Soldier, 9319 Ashen Atta Worker, 9320 Mutated
        /// Atta Soldier), hostile, the classes, levels, hit points and attacks of the World DB rows they copy (531015, 531099,
        /// 531098), the Atta species flag (82, so Targets of Opportunity 1580's "Desert Exterminator" counts them), in six pools of
        /// three (radius 0) on Ashen Desert; Exing's pool at its new place.
        /// </summary>
        [TestMethod]
        public void TheAttaCopyTheirWorldRowsWithTheClientsNames()
        {
            using var harness = WildernessRuntimeTestHarness.Create();
            var world = harness.World;
            foreach (var (atta, name, copy, cls, level) in new (uint, uint, uint, uint, uint)[]
            {
                (AttaSoldier, 9318, 531015, 7081, 40), (AttaWorker, 9319, 531099, 7078, 40), (MutatedSoldier, 9320, 531098, 7081, 41)
            })
            {
                var row = world.CreatureEntries.AsNoTracking().Single(entry => entry.Id == atta);
                var source = world.CreatureEntries.AsNoTracking().Single(entry => entry.Id == copy);
                Assert.AreEqual((name, cls, level, 0U), (row.NameId, row.ClassId, row.Level, row.Faction), $"{atta}");
                Assert.AreEqual((source.ClassId, source.Level, source.MaxHitPoints, source.Action1, source.Action2, source.Action3, source.RunSpeed),
                    (row.ClassId, row.Level, row.MaxHitPoints, row.Action1, row.Action2, row.Action3, row.RunSpeed), $"{atta} copies {copy}");
                Assert.IsTrue(CreatureManager.Instance.LoadedCreatures.TryGetValue(atta, out var loaded), $"{atta} loaded");
                Assert.AreEqual(TargetCategory.Hostile, loaded.TargetCategory, $"{atta} hostile");
                Assert.IsTrue(world.CreatureClassFlagEntries.AsNoTracking().Any(flag => flag.ClassId == cls && flag.FlagId == 82),
                    $"class {cls} has the Atta flag 82");
                var pools = world.SpawnPoolEntries.AsNoTracking().Where(pool => pool.Creature1Id == atta).ToList();
                Assert.HasCount(2, pools, $"{atta}'s two pools");
                foreach (var pool in pools)
                    Assert.AreEqual((Map, (byte)3, (byte)3, 0.0, 1200U), (pool.MapContextId, pool.Creature1MinCount, pool.Creature1MaxCount,
                        pool.Radius, pool.RespawnTime), $"pool {pool.Id}");
            }
            Assert.AreEqual(82, (int)Rasa.Services.Preloader.TargetsOfOpportunitySeed.Flag.Atta, "the ToO's Atta flag");
        }

        /// <summary>
        /// The lead-ins, Fithik Infestation, Angry Angry Atta and Harmful Mutations need no mission (TaRapedia: no requirement);
        /// Chemical Oversight needs Angry Angry Atta done, Eyes on the Ground Harmful Mutations (TaRapedia); none repeats.
        /// </summary>
        [TestMethod]
        public void OnlyTheFollowUpsRequireAMission()
        {
            using var harness = WildernessRuntimeTestHarness.Create();
            // Set 3's three need none (TaRapedia: no requirement; triage chain 13); set 4's three neither (TaRapedia).
            var prerequisites = harness.World.MissionPrerequisiteEntries.AsNoTracking().Where(entry => entry.ContentRevision == AshenMissionDataV1.Revision)
                .AsEnumerable().Select(entry => (entry.MissionId, entry.Kind, entry.RequiredMissionId, entry.RequiredMissionState))
                .OrderBy(entry => entry.MissionId).ToArray();
            CollectionAssert.AreEqual(new (uint, MissionPrerequisiteKind, uint?, byte?)[]
            {
                (1244, MissionPrerequisiteKind.MissionCompleted, 1242, (byte)MissionState.Completed),
                (1245, MissionPrerequisiteKind.MissionCompleted, 1243, (byte)MissionState.Completed)
            }, prerequisites);
            Assert.IsFalse(harness.World.Set<MissionRepeatPolicyEntry>().AsNoTracking()
                .Any(entry => entry.ContentRevision == AshenMissionDataV1.Revision));
        }

        /// <summary>The missions' sources and how far each is trusted: the client 1.0, TaRapedia 0.5, the reconstruction 0.3.</summary>
        [TestMethod]
        public void TheSourcesAreTrustedAsFarAsTheyGo()
        {
            using var harness = WildernessRuntimeTestHarness.Create();
            var evidence = harness.World.MissionEvidenceEntries.AsNoTracking()
                .Where(entry => entry.ContentRevision == AshenMissionDataV1.Revision).ToArray();
            foreach (var mission in MissionIds)
                CollectionAssert.AreEqual(new[]
                    {
                        (MissionEvidenceSourceKind.Client, 1.0), (MissionEvidenceSourceKind.Documentation, 0.5),
                        (MissionEvidenceSourceKind.Reconstruction, 0.3)
                    },
                    evidence.Where(entry => entry.MissionId == mission && !(mission == AshenFixAV1.MissionId && entry.EvidenceId == AshenFixAV1.Evidence))
                        .OrderBy(entry => entry.EvidenceId)
                        .Select(entry => (entry.SourceKind, entry.Confidence)).ToArray(), $"{mission} evidence");
        }

        /// <summary>The rewards: XP and credits of TaRapedia, the four items (or stacks) to choose one of (written out here).</summary>
        [TestMethod]
        public void TheRewardsAreTaRapediasWithOneItemToChoose()
        {
            using var harness = WildernessRuntimeTestHarness.Create();
            foreach (var (mission, experience, credits, items) in new (uint, uint, uint, (uint, uint)[])[]
            {
                (1250, 42500, 4000, new[] { (45065U, 2U), (111029U, 3U), (47600U, 1U), (111019U, 3U) }),
                (1273, 45000, 4100, new[] { (111039U, 3U), (45065U, 2U), (111029U, 3U), (47600U, 1U) }),
                (1274, 90000, 6150, new[] { (123046U, 1U), (123141U, 1U), (123166U, 1U), (123026U, 1U) }),
                (1283, 45000, 4100, new[] { (111019U, 3U), (45063U, 6U), (45447U, 3U), (111233U, 1U) }),
                (1284, 47500, 4200, new[] { (111029U, 3U), (47600U, 1U), (111019U, 3U), (45063U, 6U) }),
                (1242, 90000, 6150, new[] { (49616U, 1U), (48712U, 1U), (48300U, 1U), (15025U, 1U) }),
                (1243, 90000, 6150, new[] { (34116U, 1U), (40502U, 1U), (36787U, 1U), (31088U, 1U) }),
                (1244, 90000, 6150, new[] { (28634U, 1U), (38952U, 1U), (18770U, 1U), (35740U, 1U) }),
                (1245, 90000, 6150, new[] { (33987U, 1U), (23698U, 1U), (21100U, 1U), (46013U, 1U) }),
                (1247, 180000, 8200, new[] { (49576U, 1U), (45777U, 1U), (47948U, 1U), (45762U, 1U) }),
                (1248, 180000, 8200, new[] { (12065U, 1U), (11953U, 1U), (47772U, 1U), (15111U, 1U) }),
                (1249, 90000, 6150, new[] { (24086U, 1U), (20504U, 1U), (36188U, 1U), (19286U, 1U) }),
                (1262, 95000, 6300, new[] { (46029U, 1U), (34374U, 1U), (23569U, 1U), (31241U, 1U) }),
                (1263, 95000, 6300, new[] { (49616U, 1U), (49536U, 1U), (15301U, 1U), (14861U, 1U) }),
                (1272, 190000, 8400, new[] { (15335U, 1U), (48108U, 1U), (12125U, 1U), (14534U, 1U) })
            })
            {
                var reward = harness.World.Set<MissionRewardDefinitionEntry>().AsNoTracking()
                    .Single(entry => entry.MissionId == mission && entry.ContentRevision == AshenMissionDataV1.Revision);
                Assert.AreEqual((experience, credits, (byte)1), (reward.Experience, reward.Credits, reward.SelectionCount), $"{mission}");
                CollectionAssert.AreEqual(items, harness.World.MissionRewardItemEntries.AsNoTracking()
                    .Where(entry => entry.MissionId == mission && entry.ContentRevision == AshenMissionDataV1.Revision)
                    .OrderBy(entry => entry.ItemId).AsEnumerable().Select(entry => (entry.ItemTemplateId, entry.Quantity)).ToArray(), $"{mission} items");
            }
        }

        /// <summary>
        /// The indicators: all on Ashen Desert (MissionMarkerProjection), keyed above UnnamedFrom, but Eyes on the Ground's five,
        /// keyed by the client's names 155-159 "Atta Beacon Point 1" .. "5", and Artillery Annihilation's four, 160-163 "Bane
        /// Heavy Mortar 1" .. "4" (missionobjectiveindicatorlanguage).
        /// </summary>
        [TestMethod]
        public void IndicatorsAreOnAshenDesertAndAboveUnnamedButTheClientsNamedOnes()
        {
            using var harness = WildernessRuntimeTestHarness.Create();
            var indicators = harness.World.MissionIndicatorEntries.AsNoTracking()
                .Where(entry => entry.ContentRevision == AshenMissionDataV1.Revision).ToArray();
            Assert.HasCount(Indicators, indicators);
            var catalog = new MissionContentCatalog(harness, new Dictionary<uint, Mission>(), null);
            catalog.Load();
            foreach (var row in indicators)
            {
                Assert.AreEqual(Map, MissionMarkerProjection.ResolveMap(catalog, row.MissionId, row.ObjectiveId,
                    new MissionIndicator { IndicatorId = row.IndicatorId }), $"mission {row.MissionId} objective {row.ObjectiveId}: on Ashen Desert");
                if (NamedMarker(row.MissionId, row.ObjectiveId) is { } name)
                    Assert.AreEqual(name, row.IndicatorId, $"mission {row.MissionId} objective {row.ObjectiveId}: the client's name");
                else
                    Assert.IsTrue(row.IndicatorId > MissionIndicator.UnnamedFrom, $"mission {row.MissionId} objective {row.ObjectiveId} indicator {row.IndicatorId}");
            }
        }

        /// <summary>
        /// The client's name of an Ashen marker, where the client has one: Eyes on the Ground's beacon <c>n</c>, "Atta Beacon
        /// Point n" (missionobjectiveindicatorlanguage 154 + n); Artillery Annihilation's mortar <c>n</c>, "Bane Heavy Mortar n"
        /// (159 + n); null for the others.
        /// </summary>
        internal static uint? NamedMarker(uint mission, uint objective) => (mission, objective) switch
        {
            (1245, >= 1 and <= 5) => 154 + objective,
            (1249, >= 1 and <= 4) => 159 + objective,
            _ => null
        };

        /// <summary>Every visible Ashen objective has a marker; the one hidden objective is 1263's server-only tally (2): the scenes of 1243 and 1245 hold items and spots only.</summary>
        [TestMethod]
        public void EveryVisibleObjectiveHasAMarker()
        {
            using var harness = WildernessRuntimeTestHarness.Create();
            var world = harness.World;
            var revision = AshenMissionDataV1.Revision;
            var marked = world.MissionIndicatorEntries.AsNoTracking().Where(entry => entry.ContentRevision == revision)
                .Select(entry => new { entry.MissionId, entry.ObjectiveId }).ToList()
                .Select(entry => (entry.MissionId, entry.ObjectiveId)).ToHashSet();
            var scenes = Scenes(harness);
            CollectionAssert.AreEquivalent(new uint[] { 1243, 1245, 1263 }, scenes.Select(scene => scene.MissionId).ToArray(), "the scenes");
            var hidden = scenes.SelectMany(scene => (scene.Scene.HiddenObjectiveIds ?? new()).Select(objective => (scene.MissionId, objective))).ToHashSet();
            CollectionAssert.AreEquivalent(new[] { (1263U, 2U) }, hidden.ToArray(), "1263's tally, hidden");
            var objectives = world.MissionObjectiveDefinitionEntries.AsNoTracking().Where(entry => entry.ContentRevision == revision)
                .Select(entry => new { entry.MissionId, entry.ObjectiveId }).ToList();
            Assert.HasCount(5 + 2 + 1 + 1 + 5 + 2 + 1 + 4 + 1 + 2 + 1, objectives, "the objectives are read");
            var missing = objectives.Select(entry => (entry.MissionId, entry.ObjectiveId)).Where(key => !marked.Contains(key) && !hidden.Contains(key))
                .OrderBy(key => key).ToArray();
            Assert.IsFalse(hidden.Any(marked.Contains), "no marker on a hidden objective");
            Assert.IsEmpty(missing, string.Join(", ", missing));
        }

        /// <summary>The markers stand at their objective's target: an NPC, or a Fithik pool on Stonewall Ridge.</summary>
        [TestMethod]
        public void TheMarkersStandAtTheirObjectivesTargets()
        {
            using var harness = WildernessRuntimeTestHarness.Create();
            var rows = harness.World.MissionIndicatorEntries.AsNoTracking()
                .Where(entry => entry.ContentRevision == AshenMissionDataV1.Revision).ToList();
            var expected = new List<(uint Mission, uint Objective, double X, double Z, double Radius)>
            {
                (1250, 1, -132, -875, 8),                           // Mason Linier
                (1273, 1, -62, -414, 8),                            // Emmons
                (1274, 1, AshenFixAV1.MarkerNow.X, AshenFixAV1.MarkerNow.Z, 30), // Fithik pool 540067, a point since fix job A (540066's Fithik are in an unreachable pocket)
                (1283, 1, 686, -495, 8),                            // Yamamoto
                (1284, 1, -507.4, 162.4, 8),                        // Daris Linier
                (1242, 1, -493, -240, 20), (1242, 1, -429, -240, 20), // the Ashen Atta Soldier pools 790046, 790047
                (1242, 2, -461, -216, 20), (1242, 2, -461, -264, 20), // the Ashen Atta Worker pools 790048, 790049
                (1243, 1, -533, -256, 20), (1243, 1, -405, -272, 20), // the Mutated Atta Soldier pools 790050, 790051
                (1244, 1, -289, -264, 15),                          // Exing, moved
                (1245, 1, -431, -203, 8), (1245, 2, -554, -230, 8), (1245, 3, -596, -83, 8), (1245, 4, -476, -17, 8), (1245, 5, -338, -80, 8),
                (1247, 1, -180, -305, 20), (1247, 1, -140, -305, 20), // the Thrax Ravager pools 790085, 790086
                (1247, 3, -160, -260, 20), (1247, 3, -120, -225, 20), // the Thrax Soldier pools 790087, 790088
                (1248, 1, -174.4, -482.2, 50), (1248, 1, -161.6, -392.2, 40), // the Desert Predators' south and north beats
                (1249, 1, -210.888, -409.662, 10), (1249, 2, -195.561, -337.739, 10), // the mortar pools 592191, 592192
                (1249, 3, -180.58, -282.694, 10), (1249, 4, -140.3, -285.3, 10),       // and 592193, 592194
                (1262, 1, 560, -250, 20), (1262, 1, 600, -230, 20), (1262, 1, 640, -250, 20), // the Xanx pools 790122-790124
                (1263, 1, 512.5, -335.5, 55),                       // over the six fallen
                (1272, 1, 580, -345, 15), (1272, 1, 585, -370, 15)  // the Desert Stalker pools 790125, 790126
            };
            Assert.HasCount(Indicators, expected);
            foreach (var (mission, objective, x, z, radius) in expected)
                Assert.IsTrue(rows.Any(row => row.MissionId == mission && row.ObjectiveId == objective &&
                        Vector2.Distance(new((float)row.PosX, (float)row.PosZ), new((float)x, (float)z)) < 0.1f && row.Radius == radius),
                    $"{mission} objective {objective}'s marker at ({x}, {z}) radius {radius}");
            Assert.HasCount(Indicators, rows);

            // Each Fithik pool's centre inside its marker.
            var pools = harness.World.SpawnPoolEntries.AsNoTracking().Where(row => row.Id == 540067).ToList();
            Assert.HasCount(1, pools);
            foreach (var pool in pools)
                Assert.IsTrue(rows.Any(row => row.MissionId == 1274 && Vector2.Distance(new((float)row.PosX, (float)row.PosZ),
                    new((float)pool.PosX, (float)pool.PosZ)) < 5), $"pool {pool.Id} by a marker");
            var pocket = harness.World.SpawnPoolEntries.AsNoTracking().Single(row => row.Id == AshenFithikInfestationV1.PocketPool);
            Assert.IsFalse(rows.Any(row => row.MissionId == 1274 && Vector2.Distance(new((float)row.PosX, (float)row.PosZ),
                new((float)pocket.PosX, (float)pocket.PosZ)) < 30), "no marker on 540066's unreachable pocket");

            // Set 2: each Atta pool's centre is its marker's centre, on the objective of its kind; Exing's pool under his.
            foreach (var (pool, creature, objective, mission) in new (uint, uint, uint, uint)[]
            {
                (790046, AttaSoldier, 1, 1242), (790047, AttaSoldier, 1, 1242), (790048, AttaWorker, 2, 1242), (790049, AttaWorker, 2, 1242),
                (790050, MutatedSoldier, 1, 1243), (790051, MutatedSoldier, 1, 1243), (Exing, Exing, 1, 1244),
                (790085, Ravager, 1, 1247), (790086, Ravager, 1, 1247), (790087, ThraxSoldier, 3, 1247), (790088, ThraxSoldier, 3, 1247),
                (592191, 790081, 1, 1249), (592192, 790082, 2, 1249), (592193, 790083, 3, 1249), (592194, 790084, 4, 1249),
                (790122, Xanx, 1, 1262), (790123, Xanx, 1, 1262), (790124, Xanx, 1, 1262), (790125, Stalker, 1, 1272), (790126, Stalker, 1, 1272)
            })
            {
                var row = harness.World.SpawnPoolEntries.AsNoTracking().Single(entry => entry.Id == pool);
                Assert.AreEqual(creature, row.Creature1Id, $"pool {pool}");
                Assert.IsTrue(rows.Any(marker => marker.MissionId == mission && marker.ObjectiveId == objective &&
                    Vector2.Distance(new((float)marker.PosX, (float)marker.PosZ), new((float)row.PosX, (float)row.PosZ)) < 0.1f), $"pool {pool} under a {mission}.{objective} marker");
            }

            // The Desert Predators: every step of each beat (spawnpool_patrol) inside one 1248 marker, its own.
            var beats = harness.World.Set<SpawnPoolPatrolEntry>().AsNoTracking().Where(row => row.PoolId == 790089 || row.PoolId == 790090)
                .AsEnumerable().GroupBy(row => row.PoolId).ToDictionary(group => group.Key, group => group.ToList());
            Assert.HasCount(2, beats, "two beats");
            var predatorMarkers = rows.Where(row => row.MissionId == 1248).OrderBy(row => row.IndicatorId).ToList();
            foreach (var ((pool, steps), marker) in beats.OrderBy(beat => beat.Key).Zip(predatorMarkers))
            {
                Assert.AreEqual(Predator, harness.World.SpawnPoolEntries.AsNoTracking().Single(entry => entry.Id == pool).Creature1Id, $"pool {pool}");
                foreach (var step in steps)
                    Assert.IsLessThanOrEqualTo(marker.Radius, Vector2.Distance(new((float)marker.PosX, (float)marker.PosZ), new((float)step.PosX, (float)step.PosZ)),
                        $"pool {pool} step {step.Step} inside its marker");
            }

            // The six fallen (1263's scene) inside its one marker.
            var field = rows.Single(row => row.MissionId == 1263);
            foreach (var actor in Scenes(harness).Single(scene => scene.MissionId == 1263).Scene.Actors.Values)
                Assert.IsLessThanOrEqualTo(field.Radius, Vector2.Distance(new((float)field.PosX, (float)field.PosZ), new(actor.Position.X, actor.Position.Z)),
                    $"{actor.Role} inside the 1263 marker");
        }

        /// <summary>
        /// Set 4's creatures: the Desert Stalker 790121 has the client's name 9321 "Class XI Desert Stalker" and the class, level,
        /// hit points, armour and attacks of the World DB's Stalker 520073, hostile, in two pools of one (radius 0); the Xanx pools
        /// hold the World DB's Xanx - Ashen Desert 540020 (name 471 "Xanx Burrower", L39, unchanged), three each, radius 0. All on
        /// Ashen Desert, 120 s respawn, automatic. Infanger's pool is his own.
        /// </summary>
        [TestMethod]
        public void TheBoneyardCreaturesCopyTheirWorldRows()
        {
            using var harness = WildernessRuntimeTestHarness.Create();
            var world = harness.World;
            var creatures = world.CreatureEntries.AsNoTracking().ToDictionary(row => row.Id);
            var stats = world.CreatureStatEntries.AsNoTracking().ToDictionary(row => row.Id);
            var stalker = creatures[Stalker];
            var source = creatures[520073];
            Assert.AreEqual((9321U, 3781U, 40U, 0U), (stalker.NameId, stalker.ClassId, stalker.Level, stalker.Faction), "the Desert Stalker");
            Assert.AreEqual((source.MaxHitPoints, source.Action1, source.Action2, source.Action3, source.Action4, source.RunSpeed, source.WalkSpeed),
                (stalker.MaxHitPoints, stalker.Action1, stalker.Action2, stalker.Action3, stalker.Action4, stalker.RunSpeed, stalker.WalkSpeed), "copies 520073");
            Assert.AreEqual((4500, 400), (stats[Stalker].Health, stats[Stalker].Armor));
            Assert.IsTrue(CreatureManager.Instance.LoadedCreatures.TryGetValue(Stalker, out var loaded) && loaded.TargetCategory == TargetCategory.Hostile, "hostile");
            Assert.AreEqual((471U, 7510U, 39U), (creatures[Xanx].NameId, creatures[Xanx].ClassId, creatures[Xanx].Level), "the Xanx row, as upstream");

            foreach (var (pools, creature, count) in new[] { (XanxPools, Xanx, (byte)3), (StalkerPools, Stalker, (byte)1) })
                foreach (var pool in pools)
                {
                    var row = world.SpawnPoolEntries.AsNoTracking().Single(entry => entry.Id == pool);
                    Assert.AreEqual((Map, creature, count, count, 0U, 0.0, 1200U, (byte)0), (row.MapContextId, row.Creature1Id, row.Creature1MinCount,
                        row.Creature1MaxCount, row.Creature2Id, row.Radius, row.RespawnTime, row.Mode), $"pool {pool}");
                }
            CollectionAssert.AreEquivalent(StalkerPools, world.SpawnPoolEntries.AsNoTracking().Where(pool => pool.Creature1Id == Stalker).Select(pool => pool.Id).ToArray(),
                "the Desert Stalker's two pools");
        }

        /// <summary>
        /// Set 3's creatures: the Ashen Thrax Grenadier 531009 has the client's name 9223 "Thrax Ravager" (the triage's D9); the
        /// Thrax Soldier Mark VI 531008 keeps 355. The Desert Predator 790080 has the client's name 9327 and the class, level,
        /// hit points, armour and attacks of 520022, hostile, in two pools of one (radius 0) on Ashen Desert, each with a beat
        /// walked there and back. The highway's mortar pools 592191-592194 each hold their own copy of the Ashen Bane Mortar
        /// 592011 (all of its row, its stats and look but the id, no name id); the other Ashen mortars keep 592011. The Thrax
        /// pools: two of Ravagers and two of Soldiers, three each, radius 0.
        /// </summary>
        [TestMethod]
        public void TheHighwayCreaturesCopyTheirWorldRows()
        {
            using var harness = WildernessRuntimeTestHarness.Create();
            var world = harness.World;
            var creatures = world.CreatureEntries.AsNoTracking().ToDictionary(row => row.Id);
            var stats = world.CreatureStatEntries.AsNoTracking().ToDictionary(row => row.Id);
            Assert.AreEqual((9223U, 9354U, 39U), (creatures[Ravager].NameId, creatures[Ravager].ClassId, creatures[Ravager].Level), "the Ravager");
            Assert.AreEqual((355U, 20757U), (creatures[ThraxSoldier].NameId, creatures[ThraxSoldier].ClassId), "the Thrax Soldier");

            var predator = creatures[Predator];
            var source = creatures[520022];
            Assert.AreEqual((9327U, 3902U, 42U, 0U), (predator.NameId, predator.ClassId, predator.Level, predator.Faction), "the Desert Predator");
            Assert.AreEqual((source.MaxHitPoints, source.Action1, source.Action2, source.Action3, source.Action4, source.RunSpeed, source.WalkSpeed),
                (predator.MaxHitPoints, predator.Action1, predator.Action2, predator.Action3, predator.Action4, predator.RunSpeed, predator.WalkSpeed), "copies 520022");
            Assert.AreEqual((4700, 410), (stats[Predator].Health, stats[Predator].Armor));
            Assert.IsTrue(CreatureManager.Instance.LoadedCreatures.TryGetValue(Predator, out var loaded) && loaded.TargetCategory == TargetCategory.Hostile, "hostile");
            var predatorPools = world.SpawnPoolEntries.AsNoTracking().Where(pool => pool.Creature1Id == Predator).OrderBy(pool => pool.Id).ToList();
            CollectionAssert.AreEqual(new uint[] { 790089, 790090 }, predatorPools.Select(pool => pool.Id).ToArray());
            var patrols = world.Set<SpawnPoolPatrolEntry>().AsNoTracking().ToList();
            foreach (var pool in predatorPools)
            {
                Assert.AreEqual((Map, (byte)1, (byte)1, 0.0, 1200U, (byte)0), (pool.MapContextId, pool.Creature1MinCount, pool.Creature1MaxCount,
                    pool.Radius, pool.RespawnTime, pool.Mode), $"pool {pool.Id}");
                var steps = patrols.Where(row => row.PoolId == pool.Id).OrderBy(row => row.Step).ToList();
                var (_, home, way) = AshenSheitanHighwayNpcsV1.PredatorPools.Single(entry => entry.Pool == pool.Id);
                Assert.HasCount(2 * way.Length - 2, steps, $"pool {pool.Id}: every step both ways");
                Assert.IsLessThan(0.01, System.Math.Abs(way[home].X - pool.PosX) + System.Math.Abs(way[home].Z - pool.PosZ), $"pool {pool.Id}: its point is the beat's home step");
                Assert.IsTrue(home > 0 && home < way.Length - 1, $"pool {pool.Id}: home inside the beat, not at an end");
                Assert.IsLessThan(0.01, System.Math.Abs(steps[0].PosX - pool.PosX) + System.Math.Abs(steps[0].PosZ - pool.PosZ), $"pool {pool.Id} starts its beat at home");
                // Each end once, each step between twice (out and back); each step leads to a neighbour on the way.
                int Index(SpawnPoolPatrolEntry step) => System.Array.FindIndex(way, at => System.Math.Abs(at.X - step.PosX) + System.Math.Abs(at.Z - step.PosZ) < 0.01);
                var order = steps.Select(Index).ToList();
                Assert.IsFalse(order.Contains(-1), $"pool {pool.Id}: every step on the way");
                for (var i = 0; i < way.Length; i++)
                    Assert.AreEqual(i == 0 || i == way.Length - 1 ? 1 : 2, order.Count(index => index == i), $"pool {pool.Id} way step {i}");
                for (var i = 0; i < order.Count; i++)
                    Assert.AreEqual(1, System.Math.Abs(order[i] - order[(i + 1) % order.Count]), $"pool {pool.Id} step {i} to a neighbour");
                // The leash: every step within MaxChaseDistance less 15 m of home (BehaviorManager.ChasedTooFar).
                foreach (var step in steps)
                    Assert.IsLessThanOrEqualTo(BehaviorManager.MaxChaseDistance - 15f,
                        Vector2.Distance(new((float)pool.PosX, (float)pool.PosZ), new((float)step.PosX, (float)step.PosZ)), $"pool {pool.Id} step {step.Step} near home");
            }

            var mortar = creatures[Mortar];
            var mortarStat = stats[Mortar];
            var look = world.CreatureAppearanceEntries.AsNoTracking().Where(row => row.Id == Mortar).ToList()
                .Select(row => (row.SlotId, row.ClassId, row.Color)).ToList();
            Assert.HasCount(1, look, "the launcher in slot 13");
            for (var index = 0; index < MortarCopies.Length; index++)
            {
                var copy = creatures[MortarCopies[index]];
                Assert.AreEqual((mortar.ClassId, mortar.Faction, mortar.Level, mortar.MaxHitPoints, mortar.NameId, mortar.Action1, mortar.RunSpeed, mortar.WalkSpeed),
                    (copy.ClassId, copy.Faction, copy.Level, copy.MaxHitPoints, copy.NameId, copy.Action1, copy.RunSpeed, copy.WalkSpeed), $"{copy.Id} copies {Mortar}");
                Assert.AreEqual((7482U, 0U, 42U), (copy.ClassId, copy.NameId, copy.Level));
                Assert.AreEqual((mortarStat.Health, mortarStat.Armor), (stats[copy.Id].Health, stats[copy.Id].Armor), $"{copy.Id} stats");
                CollectionAssert.AreEqual(look, world.CreatureAppearanceEntries.AsNoTracking().Where(row => row.Id == copy.Id).ToList()
                    .Select(row => (row.SlotId, row.ClassId, row.Color)).ToList(), $"{copy.Id} look");
                var pool = world.SpawnPoolEntries.AsNoTracking().Single(row => row.Id == MortarPools[index]);
                Assert.AreEqual((Map, copy.Id, (byte)1, (byte)1), (pool.MapContextId, pool.Creature1Id, pool.Creature1MinCount, pool.Creature1MaxCount), $"mortar pool {pool.Id}");
            }
            Assert.IsGreaterThan(5, world.SpawnPoolEntries.AsNoTracking().Count(pool => pool.MapContextId == Map && pool.Creature1Id == Mortar), "the other Ashen mortars keep 592011");

            foreach (var (pool, creature) in new (uint, uint)[] { (790085, Ravager), (790086, Ravager), (790087, ThraxSoldier), (790088, ThraxSoldier) })
            {
                var row = world.SpawnPoolEntries.AsNoTracking().Single(entry => entry.Id == pool);
                Assert.AreEqual((Map, creature, (byte)3, (byte)3, 0U, 0.0, 1200U), (row.MapContextId, row.Creature1Id, row.Creature1MinCount,
                    row.Creature1MaxCount, row.Creature2Id, row.Radius, row.RespawnTime), $"pool {pool}");
            }
        }

        /// <summary>
        /// Ashen_lead_ins takes out its five missions and four NPCs and puts the moved upstream rows back where upstream had them
        /// (MissionNpcSpawnpoolPreloader with StandingHeights' corrections, not Down's own constants); the Crucible missions
        /// stay. Up again, all of it is back. The counts take only set 1's own ids and missions, so later sets do not change them.
        /// </summary>
        [TestMethod]
        public void LeadInsRollBackWithTheirMigration()
        {
            // Set 1's own missions and markers (one at each talk's receiver, one per Fithik pool), from the data classes.
            var leadInMissions = new[]
            {
                AshenDustiestPlaceV1.MissionId, AshenReportToStonewallV1.MissionId, AshenFithikInfestationV1.MissionId,
                AshenGoodDayToDieV1.MissionId, AshenCantDrinkAshV1.MissionId
            };
            var leadInIndicators = leadInMissions.Length - 1 + AshenFithikInfestationV1.Pools.Length;
            using var harness = WildernessRuntimeTestHarness.Create();
            var world = harness.World;
            bool Has(uint mission) => world.MissionContentDefinitionEntries.AsNoTracking()
                .Any(entry => entry.MissionId == mission && entry.ContentRevision == AshenMissionDataV1.Revision);
            int Count(string sql) => world.Database.SqlQueryRaw<int>(sql).AsEnumerable().Single();
            var ids = string.Join(", ", AshenLeadInNpcsV1.New.Select(npc => npc.Id));
            var missions = string.Join(", ", leadInMissions);
            (int, int, int, int, int, int) All() => (
                Count($"SELECT COUNT(*) AS Value FROM creature WHERE id IN ({ids})"),
                Count($"SELECT COUNT(*) AS Value FROM spawnpool WHERE id IN ({ids})"),
                Count($"SELECT COUNT(*) AS Value FROM npc_package WHERE id IN ({ids})"),
                Count($"SELECT COUNT(*) AS Value FROM creature_stat WHERE id IN ({ids})"),
                Count($"SELECT COUNT(*) AS Value FROM creature_appearance WHERE id IN ({ids})"),
                Count($"SELECT COUNT(*) AS Value FROM mission_indicator WHERE content_revision = 'ashen_1_16_5' AND mission_id IN ({missions})"));
            (double X, double Y, double Z) At(uint pool)
            {
                var row = world.SpawnPoolEntries.AsNoTracking().Single(entry => entry.Id == pool);
                return (row.PosX, row.PosY, row.PosZ);
            }
            var npcs = AshenLeadInNpcsV1.New.Length;
            // The copied rows: one appearance row per slot of the NPC each copies.
            var appearances = AshenLeadInNpcsV1.New.Sum(npc =>
                world.Database.SqlQueryRaw<int>($"SELECT COUNT(*) AS Value FROM creature_appearance WHERE id = {npc.Copy}").AsEnumerable().Single());
            Assert.IsGreaterThan(0, appearances);
            void AllUp()
            {
                Assert.IsTrue(leadInMissions.All(Has));
                Assert.AreEqual((npcs, npcs, npcs, npcs, appearances, leadInIndicators), All());
                foreach (var (pool, _, now) in AshenLeadInNpcsV1.Moves)
                    Assert.AreEqual(now, At(pool), $"pool {pool} at its set 1 place");
            }

            AllUp();
            world.GetService<IMigrator>().Migrate(Previous(world, LeadIns));
            world.ChangeTracker.Clear();
            Assert.IsFalse(leadInMissions.Any(Has));
            Assert.AreEqual((0, 0, 0, 0, 0, 0), All());
            Assert.IsFalse(world.MissionEvidenceEntries.Any(entry => entry.ContentRevision == AshenMissionDataV1.Revision && leadInMissions.Contains(entry.MissionId)));
            Assert.IsFalse(world.MissionRewardItemEntries.Any(entry => entry.ContentRevision == AshenMissionDataV1.Revision && leadInMissions.Contains(entry.MissionId)));
            Assert.IsFalse(world.MissionObjectiveDefinitionEntries.Any(entry => entry.ContentRevision == AshenMissionDataV1.Revision && leadInMissions.Contains(entry.MissionId)));
            foreach (var (pool, _, _) in AshenLeadInNpcsV1.Moves)
            {
                var upstream = Upstream(pool);
                var at = At(pool);
                Assert.IsLessThan(0.01, System.Math.Abs(at.X - upstream.X) + System.Math.Abs(at.Y - upstream.Y) + System.Math.Abs(at.Z - upstream.Z),
                    $"pool {pool} back at its upstream place {upstream}, is {at}");
            }
            Assert.IsTrue(world.MissionContentDefinitionEntries.Any(entry => entry.MissionId == CrucibleLastMenStandingV1.MissionId &&
                entry.ContentRevision == CrucibleMissionDataV1.Revision), "the Crucible missions stay");

            world.GetService<IMigrator>().Migrate(LeadIns);
            world.ChangeTracker.Clear();
            AllUp();
        }

        /// <summary>
        /// Ashen_mauna_barrens takes out its four missions, three NPCs, three Atta and six Atta pools, and puts Exing's pool back
        /// where upstream had it; set 1 stays. Up again, all of it is back. The counts take only set 2's own ids and missions.
        /// </summary>
        [TestMethod]
        public void MaunaBarrensRollsBackWithItsMigration()
        {
            var missions = new[]
            {
                AshenAngryAngryAttaV1.MissionId, AshenHarmfulMutationsV1.MissionId, AshenChemicalOversightV1.MissionId, AshenEyesOnTheGroundV1.MissionId
            };
            using var harness = WildernessRuntimeTestHarness.Create();
            var world = harness.World;
            bool Has(uint mission) => world.MissionContentDefinitionEntries.AsNoTracking()
                .Any(entry => entry.MissionId == mission && entry.ContentRevision == AshenMissionDataV1.Revision);
            int Count(string sql) => world.Database.SqlQueryRaw<int>(sql).AsEnumerable().Single();
            var npcs = string.Join(", ", AshenMaunaBarrensNpcsV1.New.Select(npc => npc.Id));
            var creatures = string.Join(", ", AshenMaunaBarrensNpcsV1.New.Select(npc => npc.Id).Concat(AshenMaunaBarrensNpcsV1.Atta.Select(atta => atta.Id)));
            var pools = string.Join(", ", AshenMaunaBarrensNpcsV1.New.Select(npc => npc.Id).Concat(AshenMaunaBarrensNpcsV1.AttaPools.Select(pool => pool.Pool)));
            var ids = string.Join(", ", missions);
            (int, int, int, int, int, int, int) All() => (
                Count($"SELECT COUNT(*) AS Value FROM creature WHERE id IN ({creatures})"),
                Count($"SELECT COUNT(*) AS Value FROM creature_stat WHERE id IN ({creatures})"),
                Count($"SELECT COUNT(*) AS Value FROM spawnpool WHERE id IN ({pools})"),
                Count($"SELECT COUNT(*) AS Value FROM npc_package WHERE id IN ({npcs})"),
                Count($"SELECT COUNT(*) AS Value FROM creature_appearance WHERE id IN ({creatures})"),
                Count($"SELECT COUNT(*) AS Value FROM mission_indicator WHERE content_revision = 'ashen_1_16_5' AND mission_id IN ({ids})"),
                Count($"SELECT COUNT(*) AS Value FROM mission_scene_binding WHERE content_revision = 'ashen_1_16_5' AND mission_id IN ({ids})"));
            (double X, double Y, double Z) ExingAt()
            {
                var row = world.SpawnPoolEntries.AsNoTracking().Single(entry => entry.Id == Exing);
                return (row.PosX, row.PosY, row.PosZ);
            }
            var appearances = AshenMaunaBarrensNpcsV1.New.Sum(npc =>
                world.Database.SqlQueryRaw<int>($"SELECT COUNT(*) AS Value FROM creature_appearance WHERE id = {npc.Copy}").AsEnumerable().Single());
            Assert.IsGreaterThan(0, appearances);
            void AllUp()
            {
                Assert.IsTrue(missions.All(Has));
                Assert.AreEqual((6, 6, 9, 3, appearances, 12, 2), All());
                Assert.AreEqual(AshenMaunaBarrensNpcsV1.ExingAt, ExingAt(), "Exing at his set 2 place");
            }

            AllUp();
            world.GetService<IMigrator>().Migrate(Previous(world, MaunaBarrens));
            world.ChangeTracker.Clear();
            Assert.IsFalse(missions.Any(Has));
            Assert.AreEqual((0, 0, 0, 0, 0, 0, 0), All());
            Assert.IsFalse(world.MissionEvidenceEntries.Any(entry => entry.ContentRevision == AshenMissionDataV1.Revision && missions.Contains(entry.MissionId)));
            Assert.IsFalse(world.MissionRewardItemEntries.Any(entry => entry.ContentRevision == AshenMissionDataV1.Revision && missions.Contains(entry.MissionId)));
            Assert.IsFalse(world.MissionObjectiveDefinitionEntries.Any(entry => entry.ContentRevision == AshenMissionDataV1.Revision && missions.Contains(entry.MissionId)));
            Assert.IsFalse(world.MissionPrerequisiteEntries.Any(entry => entry.ContentRevision == AshenMissionDataV1.Revision && missions.Contains(entry.MissionId)));
            var back = ExingAt();
            Assert.IsLessThan(0.01, System.Math.Abs(back.X + 281) + System.Math.Abs(back.Y - 340.4) + System.Math.Abs(back.Z + 252),
                $"Exing back at upstream's (-281, 340.4, -252), is {back}");
            Assert.IsTrue(MissionIds.Take(5).All(Has), "set 1 stays");

            world.GetService<IMigrator>().Migrate(MaunaBarrens);
            world.ChangeTracker.Clear();
            AllUp();
        }

        /// <summary>
        /// Ashen_sheitan_highway takes out its three missions, the Desert Predator and the four mortar copies, the six pools and
        /// the beats, gives the mortar pools 592011 back and takes the Ravager name off 531009; sets 1 and 2 stay. Up again, all
        /// of it is back. The counts take only set 3's own ids and missions.
        /// </summary>
        [TestMethod]
        public void SheitanHighwayRollsBackWithItsMigration()
        {
            var missions = new[] { AshenHighwayToHellV1.MissionId, AshenAirSuperiorityV1.MissionId, AshenArtilleryAnnihilationV1.MissionId };
            using var harness = WildernessRuntimeTestHarness.Create();
            var world = harness.World;
            bool Has(uint mission) => world.MissionContentDefinitionEntries.AsNoTracking()
                .Any(entry => entry.MissionId == mission && entry.ContentRevision == AshenMissionDataV1.Revision);
            int Count(string sql) => world.Database.SqlQueryRaw<int>(sql).AsEnumerable().Single();
            var creatures = string.Join(", ", MortarCopies.Append(Predator));
            var pools = string.Join(", ", AshenSheitanHighwayNpcsV1.ThraxPools.Select(pool => pool.Pool).Concat(AshenSheitanHighwayNpcsV1.PredatorPools.Select(pool => pool.Pool)));
            var ids = string.Join(", ", missions);
            var mortarPools = string.Join(", ", MortarPools);
            (int, int, int, int, int, int, int, int) All() => (
                Count($"SELECT COUNT(*) AS Value FROM creature WHERE id IN ({creatures})"),
                Count($"SELECT COUNT(*) AS Value FROM creature_stat WHERE id IN ({creatures})"),
                Count($"SELECT COUNT(*) AS Value FROM creature_appearance WHERE id IN ({creatures})"),
                Count($"SELECT COUNT(*) AS Value FROM spawnpool WHERE id IN ({pools})"),
                Count($"SELECT COUNT(*) AS Value FROM spawnpool_patrol WHERE pool_id IN ({pools})"),
                Count($"SELECT COUNT(*) AS Value FROM mission_indicator WHERE content_revision = 'ashen_1_16_5' AND mission_id IN ({ids})"),
                Count($"SELECT COUNT(*) AS Value FROM spawnpool WHERE id IN ({mortarPools}) AND creature_1_Id = {Mortar}"),
                Count($"SELECT COUNT(*) AS Value FROM creature WHERE id = {Ravager} AND name_id = 9223"));
            var beatSteps = AshenSheitanHighwayNpcsV1.PredatorPools.Sum(pool => 2 * pool.Way.Length - 2);
            void AllUp()
            {
                Assert.IsTrue(missions.All(Has));
                Assert.AreEqual((5, 5, 4, 6, beatSteps, 10, 0, 1), All());
            }

            AllUp();
            world.GetService<IMigrator>().Migrate(Previous(world, SheitanHighway));
            world.ChangeTracker.Clear();
            Assert.IsFalse(missions.Any(Has));
            Assert.AreEqual((0, 0, 0, 0, 0, 0, 4, 0), All());
            Assert.AreEqual(0U, world.CreatureEntries.AsNoTracking().Single(row => row.Id == Ravager).NameId, "531009 nameless again, as upstream");
            Assert.IsFalse(world.MissionEvidenceEntries.Any(entry => entry.ContentRevision == AshenMissionDataV1.Revision && missions.Contains(entry.MissionId)));
            Assert.IsFalse(world.MissionRewardItemEntries.Any(entry => entry.ContentRevision == AshenMissionDataV1.Revision && missions.Contains(entry.MissionId)));
            Assert.IsFalse(world.MissionObjectiveDefinitionEntries.Any(entry => entry.ContentRevision == AshenMissionDataV1.Revision && missions.Contains(entry.MissionId)));
            Assert.IsTrue(MissionIds.Take(9).All(Has), "sets 1 and 2 stay");

            world.GetService<IMigrator>().Migrate(SheitanHighway);
            world.ChangeTracker.Clear();
            AllUp();
        }

        /// <summary>
        /// Ashen_boneyard takes out its three missions, Infanger, the Desert Stalker and the five pools; Blood and the Xanx row stay
        /// as upstream has them; sets 1-3 stay. Up again, all of it is back. The counts take only set 4's own ids and missions.
        /// </summary>
        [TestMethod]
        public void BoneyardRollsBackWithItsMigration()
        {
            var missions = new[] { AshenXanxlessJobV1.MissionId, AshenFallenSoldiersV1.MissionId, AshenStalkingTheStalkersV1.MissionId };
            using var harness = WildernessRuntimeTestHarness.Create();
            var world = harness.World;
            bool Has(uint mission) => world.MissionContentDefinitionEntries.AsNoTracking()
                .Any(entry => entry.MissionId == mission && entry.ContentRevision == AshenMissionDataV1.Revision);
            int Count(string sql) => world.Database.SqlQueryRaw<int>(sql).AsEnumerable().Single();
            var creatures = $"{Infanger}, {Stalker}";
            var pools = string.Join(", ", XanxPools.Concat(StalkerPools).Append(Infanger));
            var ids = string.Join(", ", missions);
            (int, int, int, int, int, int, int) All() => (
                Count($"SELECT COUNT(*) AS Value FROM creature WHERE id IN ({creatures})"),
                Count($"SELECT COUNT(*) AS Value FROM creature_stat WHERE id IN ({creatures})"),
                Count($"SELECT COUNT(*) AS Value FROM npc_package WHERE id IN ({creatures})"),
                Count($"SELECT COUNT(*) AS Value FROM spawnpool WHERE id IN ({pools})"),
                Count($"SELECT COUNT(*) AS Value FROM mission_indicator WHERE content_revision = 'ashen_1_16_5' AND mission_id IN ({ids})"),
                Count($"SELECT COUNT(*) AS Value FROM mission_scene_binding WHERE content_revision = 'ashen_1_16_5' AND mission_id IN ({ids})"),
                Count($"SELECT COUNT(*) AS Value FROM creature WHERE id IN ({Blood}, {Xanx})"));
            var appearances = Count($"SELECT COUNT(*) AS Value FROM creature_appearance WHERE id = {MasonLinier}");
            Assert.IsGreaterThan(0, appearances);
            void AllUp()
            {
                Assert.IsTrue(missions.All(Has));
                Assert.AreEqual((2, 2, 1, 6, 6, 1, 2), All());
                Assert.AreEqual(appearances, Count($"SELECT COUNT(*) AS Value FROM creature_appearance WHERE id = {Infanger}"), "Infanger's look");
            }

            AllUp();
            world.GetService<IMigrator>().Migrate(Previous(world, Boneyard));
            world.ChangeTracker.Clear();
            Assert.IsFalse(missions.Any(Has));
            Assert.AreEqual((0, 0, 0, 0, 0, 0, 2), All());
            Assert.AreEqual(0, Count($"SELECT COUNT(*) AS Value FROM creature_appearance WHERE id = {Infanger}"));
            Assert.IsFalse(world.MissionEvidenceEntries.Any(entry => entry.ContentRevision == AshenMissionDataV1.Revision && missions.Contains(entry.MissionId)));
            Assert.IsFalse(world.MissionRewardItemEntries.Any(entry => entry.ContentRevision == AshenMissionDataV1.Revision && missions.Contains(entry.MissionId)));
            Assert.IsFalse(world.MissionObjectiveDefinitionEntries.Any(entry => entry.ContentRevision == AshenMissionDataV1.Revision && missions.Contains(entry.MissionId)));
            Assert.IsTrue(MissionIds.Take(12).All(Has), "sets 1-3 stay");

            world.GetService<IMigrator>().Migrate(Boneyard);
            world.ChangeTracker.Clear();
            AllUp();
        }

        /// <summary>
        /// A scene use object takes the use argument the client sends (QUEST-RULES): usabledata lookup[class][0], or 1 where it
        /// is None (Usable.__init__), written out here. 7847 UsableItemAccHumGpsBeacon sends 3 (as CrucibleMissionTests pins it);
        /// 1245's five spots carry the client's name 71 "Atta Sensor Beacon" (usablenameoverride LIGO_ASHEN_ATTA_BEACON). The
        /// human corpses UsableTreasureDispHumCorpseMale V01-V04 (24995, 7865, 24989, 24990) have None: they send 1; 1263's six
        /// fallen carry 63 "Fallen Soldier" (LIGO_ASHEN_FALLENSOLDIER).
        /// </summary>
        [TestMethod]
        public void EveryUsableSceneObjectTakesTheClientsUseArgument()
        {
            var clientUseArguments = new Dictionary<uint, uint> { [7847] = 3, [24995] = 1, [7865] = 1, [24989] = 1, [24990] = 1 };
            var clientUseNames = new Dictionary<uint, uint> { [7847] = 71, [24995] = 63, [7865] = 63, [24989] = 63, [24990] = 63 };
            using var harness = WildernessRuntimeTestHarness.Create();
            var used = 0;
            foreach (var scene in Scenes(harness))
                foreach (var actor in scene.Scene.Actors.Values.Where(actor => actor.UseAction != null))
                {
                    used++;
                    Assert.IsTrue(clientUseArguments.TryGetValue(actor.TemplateId, out var argument),
                        $"{scene.MissionId} {actor.Role}: class {actor.TemplateId} has no pinned client use argument");
                    Assert.AreEqual(argument, actor.UseAction.ActionArgId, $"{scene.MissionId} {actor.Role}: the client's argument");
                    Assert.AreEqual(clientUseNames[actor.TemplateId], actor.NameOverrideId, $"{scene.MissionId} {actor.Role}: the client's name");
                }
            Assert.AreEqual(5 + 6, used, "1245's five beacon spots and 1263's six fallen");
        }

        /// <summary>Where upstream puts a pool: its MissionNpcSpawnpoolPreloader row, with StandingHeights' correction.</summary>
        private static (double X, double Y, double Z) Upstream(uint pool)
        {
            var row = new Rasa.Services.Preloader.MissionNpcSpawnpoolPreloader().Rows().Single(values => System.Convert.ToUInt32(values[0]) == pool);
            (double X, double Y, double Z) at = (System.Convert.ToDouble(row[4]), System.Convert.ToDouble(row[5]), System.Convert.ToDouble(row[6]));
            foreach (var (id, x, y, z) in Rasa.Services.Preloader.StandingHeights.Corrected())
                if (id == pool)
                    at = (x ?? at.X, y, z ?? at.Z);
            return at;
        }

        internal static List<(uint MissionId, Rasa.Missions.Content.MissionSceneDefinition Scene)> Scenes(WildernessRuntimeTestHarness harness) =>
            harness.World.Set<MissionSceneBindingEntry>().AsNoTracking().Where(entry => entry.ContentRevision == AshenMissionDataV1.Revision)
                .ToList().Select(entry => (entry.MissionId, System.Text.Json.JsonSerializer.Deserialize<Rasa.Missions.Content.MissionSceneDefinition>(
                    entry.Bindings, Rasa.Missions.Content.MissionContentCodec.Options))).ToList();
    }
}
