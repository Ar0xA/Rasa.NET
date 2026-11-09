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
    /// (Ashen_boneyard); set 5, the Bane Conscription Base, Yamamoto's Death from Above (1352), Infanger's Turning Out the
    /// Lights (1354) and Blood's The Strongest Link (1355), with the trench mortars each their own row, the Linker pools new and
    /// Overseer Naxveik's pool moved (Ashen_conscription_base); set 6, Formal Complaints and its AFS side, Scavenger Vakiel
    /// Latan's Formal Complaints (1254, the choice of flag 250 or 251) and A Bribe for Your Thoughts (1259), Shinichiro Ito's The
    /// Human Perspective (1258), Yamamoto's Court Martial Arts (1261) and Megumi Yamamoto's Dearly Departed (1285), with
    /// Latan, Ito and Megumi new (Ashen_formal_complaints); set 7, Latan's side (flag 250), her Robotic Salvage Recovery (1264),
    /// Weapon Salvage Recovery (1266) and Heavy Salvage Recovery (1265), with the Nitroglazer and the Hominis Machina Mk XI new
    /// in the Boneyard (Ashen_scavenger); set 8, the AFS side (flag 251), Shinichiro Ito's Robotic Salvage Acquisitions (1267),
    /// Weapon Salvage Acquisitions (1269) and Heavy Salvage Acquisitions (1268), on the creatures of sets 3, 4 and 7
    /// (Ashen_logistician).
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
            AshenXanxlessJobV1.MissionId, AshenFallenSoldiersV1.MissionId, AshenStalkingTheStalkersV1.MissionId,
            AshenDeathFromAboveV1.MissionId, AshenTurningOutTheLightsV1.MissionId, AshenStrongestLinkV1.MissionId,
            AshenFormalComplaintsV1.MissionId, AshenHumanPerspectiveV1.MissionId, AshenBribeForYourThoughtsV1.MissionId,
            AshenCourtMartialArtsV1.MissionId, AshenDearlyDepartedV1.MissionId,
            AshenRoboticSalvageV1.MissionId, AshenWeaponSalvageV1.MissionId, AshenHeavySalvageV1.MissionId,
            AshenRoboticAcquisitionsV1.MissionId, AshenWeaponAcquisitionsV1.MissionId, AshenHeavyAcquisitionsV1.MissionId
        };

        /// <summary>
        /// Every visible objective has a marker (EveryVisibleObjectiveHasAMarker): set 1's five (each report's one at its
        /// receiver, Fithik Infestation's on the Stonewall Ridge Fithik pool); set 2's twelve (1242's four on the Atta Soldier and
        /// Worker pools, 1243's two on the Mutated Atta pools, 1244's on Exing, 1245's five on the beacon spots); set 3's ten
        /// (1247's four on the Thrax Ravager and Soldier pools, 1248's two on the Desert Predators' beats, 1249's four on the
        /// mortars); set 4's six (1262's three on the Xanx pools, 1263's one over the six fallen, 1272's two on the Desert Stalker
        /// pools); set 5's twenty (1352's four on the trench mortars, six on the launchers' Detonation Devices and one over the
        /// trench, 1354's three on the generators, 1355's five on the Linker pools and one on Naxveik); set 6's nine (1254's three
        /// at Latan, 1258's and 1259's at Yamamoto, 1261's at Mason Linier, 1285's three on the Boneyard's Thrax pools); set 7's
        /// thirteen (1264's four on the Nitroglazer and Hominis Machina pools, 1266's three on the Boneyard's Thrax pools and two
        /// on the highway's Ravager pools, 1265's two on the Desert Stalker pools and two on the Desert Predators' beats); set 8's
        /// twelve (Ito's 1267, 1269 and 1268 on the places of Latan's 1264, 1266 and 1265 but the Thrax pool 531041, which the
        /// client-floor walk does not reach: AshenWeaponAcquisitionsV1.UnwalkedPool).
        /// </summary>
        internal const int Indicators = 5 + 12 + 10 + 6 + 20 + 9 + 13 + 12;

        private const string LeadIns = "20271110000000_Ashen_lead_ins";
        private const string MaunaBarrens = "20271110000100_Ashen_mauna_barrens";
        private const string SheitanHighway = "20271110000200_Ashen_sheitan_highway";
        private const string Boneyard = "20271110000400_Ashen_boneyard";
        private const string ConscriptionBase = "20271110000500_Ashen_conscription_base";
        private const string FormalComplaints = "20271110000600_Ashen_formal_complaints";
        private const string Scavenger = "20271110000700_Ashen_scavenger";
        private const string Logistician = "20271110000800_Ashen_logistician";
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
        private static readonly uint[] TrenchCopies = { 790160, 790161, 790162, 790163 };
        private static readonly uint[] TrenchPools = { 592199, 592202, 592203, 592204 };
        private static readonly uint[] LinkerPools = { 790164, 790165, 790166, 790167, 790168 };
        private const uint Linker = 531014, Naxveik = 520005;
        private const uint Latan = 790200, Ito = 790201, Megumi = 790202;
        private const uint Nitroglazer = 790240, Machina = 790241;
        private static readonly uint[] NitroPools = { 790243, 790244 };
        private static readonly uint[] MachinaPools = { 790245, 790246 };

        /// <summary>The migration directly before <paramref name="migration"/> (IMigrationsAssembly, ordinal order), as CrucibleMissionTests.Previous.</summary>
        internal static string Previous(DbContext world, string migration) => Rasa.Test.Missions.Crucible.CrucibleMissionTests.Previous(world, migration);

        /// <summary>
        /// The Ashen Desert pools that the migrations sorting after <paramref name="migration"/> add or change: <paramref
        /// name="world"/>'s rows (all migrations) against a database migrated only to <paramref name="migration"/>. A rollback
        /// test that goes down past them and up again only to its own migration leaves these out of its "no other pool changes".
        /// </summary>
        internal static uint[] PoolsOfLaterMigrations(DbContext world, string migration)
        {
            static Dictionary<uint, string> Rows(DbContext context) => context.Set<SpawnPoolEntry>().AsNoTracking()
                .Where(entry => entry.MapContextId == AshenMissionDataV1.MapContextId).AsEnumerable()
                .ToDictionary(entry => entry.Id, entry => new { entry.PosX, entry.PosY, entry.PosZ, entry.Radius, entry.Creature1Id, entry.RespawnTime }.ToString());
            var all = Rows(world);
            Dictionary<uint, string> before;
            using (var fresh = WildernessRuntimeTestHarness.Create(targetWorldMigration: migration))
                before = Rows(fresh.World);
            return all.Where(row => !before.TryGetValue(row.Key, out var was) || was != row.Value).Select(row => row.Key)
                .Concat(before.Keys.Where(id => !all.ContainsKey(id))).OrderBy(id => id).ToArray();
        }

        [TestMethod]
        public void TheMissionsAreEnabledOperationalAndGivenByTheirNpcs()
        {
            var expected = new (uint Mission, uint? Giver, uint? Receiver, uint Level)[]
            {
                (1250, Ames, MasonLinier, 40), (1273, Harris, Emmons, 40), (1274, Emmons, Emmons, 40), (1283, Ivan, Yamamoto, 40),
                (1284, Caldwell, DarisLinier, 40), (1242, Kuang, Kuang, 40), (1243, Kuang, Kwon, 40), (1244, Kuang, Kuang, 41),
                (1245, Karter, Karter, 41), (1247, Karter, Karter, 41), (1248, Ivan, Ivan, 42), (1249, Caldwell, Caldwell, 41),
                (1262, Blood, Blood, 40), (1263, Yamamoto, Yamamoto, 40), (1272, Infanger, Infanger, 41),
                (1352, Yamamoto, Yamamoto, 41), (1354, Infanger, Infanger, 41), (1355, Blood, Blood, 42),
                (1254, Latan, Latan, 40), (1258, Ito, Latan, 41), (1259, Latan, Yamamoto, 41), (1261, Yamamoto, MasonLinier, 41),
                (1285, Megumi, Yamamoto, 42),
                (1264, Latan, Latan, 40), (1266, Latan, Latan, 41), (1265, Latan, Latan, 42),
                (1267, Ito, Ito, 42), (1269, Ito, Ito, 42), (1268, Ito, Ito, 42)
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
                // 1355 shareable: TaRapedia updates 2007-08-21 lists "Mission is not shareable" as a known issue.
                Assert.AreEqual(mission == 1355, entry.Shareable, $"{mission} shareable");
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
                (Infanger, 9304, 790120, 3846, 40),
                // Set 6: Latan's package 1449 (objectiveconversation 1254,1-3), Ito's and Megumi's server-only; Latan Brann (class
                // 7776, Raji Lasat's), Ito AFS, Megumi the female AFS class.
                (Latan, 9277, 1449, 7776, 40), (Ito, 9272, 790201, 3846, 43), (Megumi, 9295, 790202, 3848, 42)
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
                (Karter, -112, -748), (Exing, -260, -310), (Infanger, 676, -505), (Blood, 682.4, -516.4), (Naxveik, 296, -30),
                (Latan, 576, -321), (Ito, 560, -320), (Megumi, -166, -895)
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
            Assert.AreEqual(1, world.NpcPackageEntries.AsNoTracking().Count(row => row.PackageId == 1449), "only Latan has 1449");
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
                (1272, 10224, new (uint, uint, uint, uint?)[] { (1, 10229, 10230, 10231) }),
                (1352, 11060, new (uint, uint, uint, uint?)[]
                {
                    (1, 11065, 11066, null), (2, 11067, 11068, null), (3, 11069, 11070, null), (4, 11071, 11072, null),
                    (5, 11073, 11074, null), (6, 11075, 11076, null), (7, 11077, 11078, null), (8, 11079, 11080, null),
                    (9, 11081, 11082, null), (10, 11083, 11084, null), (11, 11085, 11086, 11087)
                }),
                (1354, 11133, new (uint, uint, uint, uint?)[] { (1, 11333, 11334, null), (2, 11335, 11336, null), (3, 11337, 11338, null) }),
                (1355, 11144, new (uint, uint, uint, uint?)[] { (1, 11424, 11425, 11426), (2, 11427, 11428, 11429) }),
                // 1254's 4 is server-only and hidden: it carries 1's texts (the client has no objective 4).
                (1254, 10049, new (uint, uint, uint, uint?)[] { (1, 10054, 10055, null), (2, 10060, 10061, null), (3, 10063, 10064, null), (4, 10054, 10055, null) }),
                (1258, 10092, new (uint, uint, uint, uint?)[] { (1, 10097, 10098, null) }),
                (1259, 10100, new (uint, uint, uint, uint?)[] { (1, 10110, 10111, null) }),
                (1261, 10113, new (uint, uint, uint, uint?)[] { (1, 10118, 10119, null) }),
                (1285, 10370, new (uint, uint, uint, uint?)[] { (1, 10375, 10376, null) }),
                (1264, 10143, new (uint, uint, uint, uint?)[] { (1, 10173, 10174, null), (2, 10175, 10176, null) }),
                (1265, 10148, new (uint, uint, uint, uint?)[] { (1, 10177, 10178, null), (2, 10179, 10180, null) }),
                (1266, 10153, new (uint, uint, uint, uint?)[] { (1, 10181, 10182, null), (2, 10183, 10184, null) }),
                (1267, 10158, new (uint, uint, uint, uint?)[] { (1, 10185, 10186, null), (2, 10187, 10188, null) }),
                (1268, 10163, new (uint, uint, uint, uint?)[] { (1, 10189, 10190, null), (2, 10191, 10192, null) }),
                (1269, 10168, new (uint, uint, uint, uint?)[] { (1, 10193, 10194, null), (2, 10195, 10196, null) })
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
            // with the client's variant 1. Set 6: 1254,1 Latan's choice (1449, variant 1, a trigger for each of its two
            // choices), 1254,2 1449 variant 250, 1254,3 1449 variant 251; 1258,1 and 1259,1 Yamamoto (1414) and 1261,1 Mason
            // Linier (1389), variant 251: the client's variant is the player flag of Formal Complaints' choice.
            var talks = harness.World.Set<MissionTriggerEntry>().AsNoTracking()
                .Where(entry => entry.ContentRevision == AshenMissionDataV1.Revision && entry.Kind == MissionTriggerKind.Conversation)
                .AsEnumerable().Select(entry => (entry.MissionId, entry.ObjectiveId, entry.NpcPackageId, entry.PlayerFlagId))
                .OrderBy(entry => entry.MissionId).ThenBy(entry => entry.ObjectiveId).ToArray();
            CollectionAssert.AreEqual(new (uint, uint, uint?, uint?)[]
            {
                (1250, 1, 1389, 1), (1254, 1, 1449, 1), (1254, 1, 1449, 1), (1254, 2, 1449, 250), (1254, 3, 1449, 251),
                (1258, 1, 1414, 251), (1259, 1, 1414, 251), (1261, 1, 1389, 251),
                (1273, 1, 1411, 1), (1283, 1, 1414, 1), (1284, 1, 1476, 1)
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

            // Set 5: 1352 Mortar n the copy in trench pool n, once; 11 no trigger (it aggregates 1-4); Launcher n (5-10)
            // scene result n (counter 1). 1354 Generator n scene result n. 1355 the Linker - Ashen Desert (531014) fifteen and
            // Overseer Naxveik (520005) once, each on counter 0.
            var conscription = harness.World.Set<MissionTriggerEntry>().AsNoTracking()
                .Where(entry => entry.ContentRevision == AshenMissionDataV1.Revision && (entry.MissionId == 1352 || entry.MissionId == 1354 ||
                                entry.MissionId == 1355) && entry.Kind == MissionTriggerKind.ProgressEvent).AsEnumerable()
                .Select(entry => (entry.MissionId, entry.ObjectiveId, entry.EventKind, entry.SubjectId, entry.CounterId, entry.TargetValue))
                .OrderBy(entry => entry.MissionId).ThenBy(entry => entry.ObjectiveId).ThenBy(entry => entry.SubjectId).ToArray();
            CollectionAssert.AreEqual(new (uint, uint, byte?, uint?, uint?, uint?)[]
            {
                (1352, 1, killed, 790160, null, null), (1352, 2, killed, 790161, null, null), (1352, 3, killed, 790162, null, null),
                (1352, 4, killed, 790163, null, null),
                (1352, 5, scene, 1, 1, null), (1352, 6, scene, 2, 1, null), (1352, 7, scene, 3, 1, null), (1352, 8, scene, 4, 1, null),
                (1352, 9, scene, 5, 1, null), (1352, 10, scene, 6, 1, null),
                (1354, 1, scene, 1, 1, null), (1354, 2, scene, 2, 1, null), (1354, 3, scene, 3, 1, null),
                (1355, 1, killed, Linker, 0, 15), (1355, 2, killed, Naxveik, 0, 1)
            }, conscription);
            // 1352's 11 "Mortars Destroyed": the count of Mortar 1-4 done, on counter 0 to 4 (distinct mortars, not kills).
            var aggregate = Scenes(harness).Single(entry => entry.MissionId == 1352).Scene.ObjectiveAggregations.Single();
            Assert.AreEqual((11U, "1,2,3,4", 4U, (uint?)0U),
                (aggregate.Key, string.Join(",", aggregate.Value.ChildObjectiveIds), aggregate.Value.TargetCount, aggregate.Value.CounterId), "1352's 11 aggregates 1-4");
            // The explosives: 1352 six High Grade Plastic Explosives (client item class 25490), 1354 three Electromagnetic Charged
            // Explosives (26441), each given at the accept (TaRapedia's known issue of 2007-08-21 not copied).
            foreach (var (mission, template, count) in new (uint, uint, uint)[] { (1352, 97491, 6), (1354, 111184, 3) })
            {
                var bombs = Scenes(harness).Single(entry => entry.MissionId == mission).Scene;
                var binding = bombs.Items.Single();
                Assert.AreEqual((template, count, Rasa.Missions.Scenes.MissionItemScope.AssignmentIssued), (binding.ItemTemplateId, binding.MaximumQuantity, binding.Scope), $"{mission} explosives");
                var issued = (Rasa.Missions.Scenes.IssueMissionItemIntent)bombs.AcceptanceItems.Single();
                Assert.AreEqual((template, count), (issued.ItemTemplateId, issued.Quantity), $"{mission}: all of them at the accept");
            }

            // Set 6: Formal Complaints' choice 1 sets player flag 250 to 1 and 251 to 0, choice 2 251 to 1 and 250 to 0 (the
            // client's variants of 1254,2 and 1254,3); 2 and 3 answer; the hidden 4 aggregates 2 or 3, count 1.
            var flags = harness.World.Set<MissionActionEntry>().AsNoTracking()
                .Where(entry => entry.ContentRevision == AshenMissionDataV1.Revision && entry.Kind == MissionActionKind.SetPlayerFlag).AsEnumerable()
                .Select(entry => (entry.MissionId, entry.ObjectiveId, entry.TransitionId, entry.PlayerFlagId, entry.PlayerFlagValue))
                .OrderBy(entry => entry.TransitionId).ThenBy(entry => entry.PlayerFlagId).ToArray();
            CollectionAssert.AreEqual(new (uint, uint, uint, uint?, uint?)[]
            {
                (1254, 1, 1, 250, 1), (1254, 1, 1, 251, 0), (1254, 1, 2, 250, 0), (1254, 1, 2, 251, 1)
            }, flags);
            var complaints = Scenes(harness).Single(entry => entry.MissionId == 1254).Scene;
            CollectionAssert.AreEqual(new uint[] { 4 }, complaints.HiddenObjectiveIds.ToArray(), "1254's 4 is hidden");
            var outcome = complaints.ObjectiveAggregations.Single();
            Assert.AreEqual((4U, "2,3", 1U), (outcome.Key, string.Join(",", outcome.Value.ChildObjectiveIds), outcome.Value.TargetCount), "1254's 4 aggregates 2 or 3");
            var choice = complaints.Dialogue.Single();
            Assert.AreEqual((1U, 1449U, 1U, Rasa.Missions.Definitions.MissionDialogueKind.Choice, "1:1,2:2"),
                (choice.ObjectiveId, choice.NpcPackageId, choice.PlayerFlagId, choice.Kind, string.Join(",", choice.Choices.OrderBy(pair => pair.Key).Select(pair => $"{pair.Key}:{pair.Value}"))),
                "Latan's choice: the client's choice 1 and 2 on 1's transitions 1 and 2");
            // 1259 and 1261: Latan's Package (client item class 25439, template 97462), one, at the accept, taken at the talk.
            foreach (var mission in new uint[] { 1259, 1261 })
            {
                var parcel = Scenes(harness).Single(entry => entry.MissionId == mission).Scene;
                var binding = parcel.Items.Single();
                Assert.AreEqual((97462U, 1U, Rasa.Missions.Scenes.MissionItemScope.AssignmentIssued), (binding.ItemTemplateId, binding.MaximumQuantity, binding.Scope), $"{mission} package");
                var issued = (Rasa.Missions.Scenes.IssueMissionItemIntent)parcel.AcceptanceItems.Single();
                Assert.AreEqual((97462U, 1U), (issued.ItemTemplateId, issued.Quantity), $"{mission}: the package at the accept");
            }
            // 1285 picks up Yamamoto's Wedding Ring (client item class 25480, template 97481): a personal 15% drop (ESTIMATE) off the
            // Thrax Soldier (531008) and Thrax Ravager (531009) on Ashen Desert, one, taken at the turn-in.
            var ring = harness.World.Set<MissionTriggerEntry>().AsNoTracking()
                .Single(entry => entry.ContentRevision == AshenMissionDataV1.Revision && entry.MissionId == 1285 && entry.Kind == MissionTriggerKind.ProgressEvent);
            Assert.AreEqual(((byte?)MissionProgressEventKind.ItemAcquired, (uint?)25480, (uint?)1), (ring.EventKind, ring.SubjectId, ring.TargetValue));
            var ringDrop = Scenes(harness).Single(entry => entry.MissionId == 1285).Scene.Items.Single();
            Assert.AreEqual((97481U, 15, 1U, 1U, Map), (ringDrop.ItemTemplateId, ringDrop.Drop.ChancePercent, ringDrop.TurnInQuantity, ringDrop.MaximumQuantity, ringDrop.Drop.MapContextId));
            CollectionAssert.AreEqual(new[] { ThraxSoldier, Ravager }, ringDrop.Drop.CreatureIds.ToArray());

            // Set 7: each objective picks up its client item class (no counter text in the client), each a personal drop of one
            // creature row on Ashen Desert: 1264 Intact Nitroglazer Salvage (25444, template 97465) off the Nitroglazer 790240 and
            // Intact Machina Salvage (25445, 97466) off the Hominis Machina 790241, 15 each at 75%; 1266 Thrax Rifle Salvage
            // (25448, 97469) off the Thrax Soldier 531008 and Thrax Grenade Launcher Salvage (25449, 97470) off the Ravager
            // 531009, 15 each at 75%; 1265 Intact Stalker Salvage (25446, 97467) off the Desert Stalker 790121 and Intact
            // Predator Salvage (25447, 97468) off the Desert Predator 790080, one each at 100% (all ESTIMATE rates). All kept at
            // an abandon, taken at the turn-in. Set 8: Ito's 1267, 1269 and 1268 the same as Latan's 1264, 1266 and 1265 (the
            // client gives the twins the same item classes; TaRapedia: one side only), each binding the mission's own.
            var salvage = harness.World.Set<MissionTriggerEntry>().AsNoTracking()
                .Where(entry => entry.ContentRevision == AshenMissionDataV1.Revision && entry.MissionId >= 1264 && entry.MissionId <= 1269 &&
                                entry.Kind == MissionTriggerKind.ProgressEvent).AsEnumerable()
                .Select(entry => (entry.MissionId, entry.ObjectiveId, entry.EventKind, entry.SubjectId, entry.TargetValue))
                .OrderBy(entry => entry.MissionId).ThenBy(entry => entry.ObjectiveId).ToArray();
            var acquired = (byte?)MissionProgressEventKind.ItemAcquired;
            CollectionAssert.AreEqual(new (uint, uint, byte?, uint?, uint?)[]
            {
                (1264, 1, acquired, 25444, 15), (1264, 2, acquired, 25445, 15),
                (1265, 1, acquired, 25446, 1), (1265, 2, acquired, 25447, 1),
                (1266, 1, acquired, 25448, 15), (1266, 2, acquired, 25449, 15),
                (1267, 1, acquired, 25444, 15), (1267, 2, acquired, 25445, 15),
                (1268, 1, acquired, 25446, 1), (1268, 2, acquired, 25447, 1),
                (1269, 1, acquired, 25448, 15), (1269, 2, acquired, 25449, 15)
            }, salvage);
            foreach (var (mission, drops) in new (uint, (uint Template, uint Objective, uint Creature, int Chance, uint Count)[])[]
            {
                (1264, new[] { (97465U, 1U, Nitroglazer, 75, 15U), (97466U, 2U, Machina, 75, 15U) }),
                (1265, new[] { (97467U, 1U, Stalker, 100, 1U), (97468U, 2U, Predator, 100, 1U) }),
                (1266, new[] { (97469U, 1U, ThraxSoldier, 75, 15U), (97470U, 2U, Ravager, 75, 15U) }),
                (1267, new[] { (97465U, 1U, Nitroglazer, 75, 15U), (97466U, 2U, Machina, 75, 15U) }),
                (1268, new[] { (97467U, 1U, Stalker, 100, 1U), (97468U, 2U, Predator, 100, 1U) }),
                (1269, new[] { (97469U, 1U, ThraxSoldier, 75, 15U), (97470U, 2U, Ravager, 75, 15U) })
            })
            {
                var items = Scenes(harness).Single(entry => entry.MissionId == mission).Scene.Items.OrderBy(item => item.ItemTemplateId).ToArray();
                CollectionAssert.AreEqual(drops.Select(drop => (drop.Template, drop.Objective, drop.Creature, drop.Chance, drop.Count, drop.Count, drop.Count, 1U, Map,
                        Rasa.Missions.Scenes.MissionItemScope.CharacterOwned, Rasa.Missions.Definitions.MissionItemCleanupDisposition.Retain)).ToArray(),
                    items.Select(item => (item.ItemTemplateId, item.Drop.ObjectiveId, item.Drop.CreatureIds.Single(), item.Drop.ChancePercent, item.MaximumQuantity,
                        item.TurnInQuantity, item.MaximumQuantity, item.Drop.Quantity, item.Drop.MapContextId, item.Scope, item.Abandonment)).ToArray(), $"{mission} drops");
            }
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
            // Set 5's three need both Fallen Soldiers and Xanxless Job (TaRapedia).
            var prerequisites = harness.World.MissionPrerequisiteEntries.AsNoTracking().Where(entry => entry.ContentRevision == AshenMissionDataV1.Revision)
                .AsEnumerable().Select(entry => (entry.MissionId, entry.Kind, entry.RequiredMissionId, entry.RequiredMissionState))
                .OrderBy(entry => entry.MissionId).ThenBy(entry => entry.RequiredMissionId).ToArray();
            var done = (byte)MissionState.Completed;
            CollectionAssert.AreEqual(new (uint, MissionPrerequisiteKind, uint?, byte?)[]
            {
                (1244, MissionPrerequisiteKind.MissionCompleted, 1242, done),
                (1245, MissionPrerequisiteKind.MissionCompleted, 1243, done),
                // Set 6 (TaRapedia): 1258 after Formal Complaints with its choice 2 (player flag 251 at 1), then the chain.
                (1258, MissionPrerequisiteKind.PlayerFlagValue, null, null), (1258, MissionPrerequisiteKind.MissionCompleted, 1254, done),
                (1259, MissionPrerequisiteKind.MissionCompleted, 1258, done), (1261, MissionPrerequisiteKind.MissionCompleted, 1259, done),
                // Set 7 (TaRapedia; triage D1): 1264 after Formal Complaints done with its choice 1 (flag 250 at 1), then the chain.
                (1264, MissionPrerequisiteKind.PlayerFlagValue, null, null), (1264, MissionPrerequisiteKind.MissionCompleted, 1254, done),
                (1265, MissionPrerequisiteKind.MissionCompleted, 1266, done), (1266, MissionPrerequisiteKind.MissionCompleted, 1264, done),
                // Set 8 (TaRapedia "Dearly Departed"; triage D1): 1267 after Dearly Departed and Formal Complaints done with its
                // choice 2 (flag 251 at 1), then the chain 1269, 1268.
                (1267, MissionPrerequisiteKind.PlayerFlagValue, null, null), (1267, MissionPrerequisiteKind.MissionCompleted, 1254, done),
                (1267, MissionPrerequisiteKind.MissionCompleted, 1285, done),
                (1268, MissionPrerequisiteKind.MissionCompleted, 1269, done), (1269, MissionPrerequisiteKind.MissionCompleted, 1267, done),
                (1285, MissionPrerequisiteKind.MissionCompleted, 1261, done),
                (1352, MissionPrerequisiteKind.MissionCompleted, 1262, done), (1352, MissionPrerequisiteKind.MissionCompleted, 1263, done),
                (1354, MissionPrerequisiteKind.MissionCompleted, 1262, done), (1354, MissionPrerequisiteKind.MissionCompleted, 1263, done),
                (1355, MissionPrerequisiteKind.MissionCompleted, 1262, done), (1355, MissionPrerequisiteKind.MissionCompleted, 1263, done)
            }, prerequisites);
            var flags = harness.World.MissionPrerequisiteEntries.AsNoTracking()
                .Where(entry => entry.ContentRevision == AshenMissionDataV1.Revision && entry.Kind == MissionPrerequisiteKind.PlayerFlagValue)
                .AsEnumerable().Select(entry => (entry.MissionId, entry.PlayerFlagId, entry.PlayerFlagValue)).OrderBy(entry => entry.MissionId).ToArray();
            CollectionAssert.AreEqual(new (uint, uint?, uint?)[] { (1258, 251, 1), (1264, 250, 1), (1267, 251, 1) }, flags,
                "1258: flag 251 at 1; 1264: flag 250 at 1; 1267: flag 251 at 1");
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
                    evidence.Where(entry => entry.MissionId == mission && !(mission == AshenFixAV1.MissionId && entry.EvidenceId == AshenFixAV1.Evidence)
                        && !(mission == AshenFixBV1.MissionId && entry.EvidenceId == AshenFixBV1.Evidence))
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
                (1272, 190000, 8400, new[] { (15335U, 1U), (48108U, 1U), (12125U, 1U), (14534U, 1U) }),
                (1352, 200000, 8600, new[] { (12099U, 1U), (15442U, 1U), (14980U, 1U), (48108U, 1U) }),
                (1354, 100000, 6450, new[] { (19802U, 1U), (39081U, 1U), (20951U, 1U), (31394U, 1U) }),
                (1355, 200000, 8600, new[] { (33342U, 1U), (24086U, 1U), (19544U, 1U), (36638U, 1U) }),
                // Set 6: TaRapedia's stacks for 1254 and 1261, 1254's for 1258 and 1259 (TaRapedia names none: zone median,
                // ESTIMATE), the lowest Uncommon armour of TaRapedia's four kinds at level 42 for 1285.
                (1254, 45000, 4100, new[] { (111029U, 3U), (47600U, 1U), (111019U, 3U), (45063U, 6U) }),
                (1258, 45000, 4100, new[] { (111029U, 3U), (47600U, 1U), (111019U, 3U), (45063U, 6U) }),
                (1259, 45000, 4100, new[] { (111029U, 3U), (47600U, 1U), (111019U, 3U), (45063U, 6U) }),
                (1261, 45000, 4100, new[] { (45447U, 3U), (111233U, 1U), (111049U, 3U), (45064U, 3U) }),
                (1285, 190000, 8400, new[] { (38823U, 1U), (23828U, 1U), (20802U, 1U), (29093U, 1U) }),
                // Set 7: TaRapedia's XP and credits; 1264 the lowest Uncommon of TaRapedia's four armour kinds (icon 2; Motor Assist
                // has no Uncommon below V04) at level 40; 1266 TaRapedia's one item (the fire injection gun); 1265 TaRapedia names
                // none: 1254's stacks (zone median, ESTIMATE).
                (1264, 95000, 6300, new[] { (23698U, 1U), (29093U, 1U), (20802U, 1U), (36039U, 1U) }),
                (1266, 95000, 6300, new[] { (45777U, 1U) }),
                (1265, 200000, 6300, new[] { (111029U, 3U), (47600U, 1U), (111019U, 3U), (45063U, 6U) }),
                // Set 8: TaRapedia's credits (1267, 1269; 1268 none: as 1265); XP as Latan's twins (TaRapedia "?", ESTIMATE); 1267
                // the grade [4] armour modules of TaRapedia's four resistances; 1269 the lowest Uncommon of TaRapedia's four kinds
                // at level 42 (Cryogenic Blade, Area Healing Disc, Sonic Pistol, Pulse Staff); 1268 1254's stacks.
                (1267, 95000, 6300, new[] { (123016U, 1U), (123026U, 1U), (123031U, 1U), (123071U, 1U) }),
                (1269, 95000, 6300, new[] { (12101U, 1U), (119882U, 1U), (14452U, 1U), (15220U, 1U) }),
                (1268, 200000, 6300, new[] { (111029U, 3U), (47600U, 1U), (111019U, 3U), (45063U, 6U) })
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

        /// <summary>Every visible Ashen objective has a marker; the hidden objectives are 1263's server-only tally (2) and 1254's server-only outcome (4): the scenes of 1243 and 1245 hold items and spots only.</summary>
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
            CollectionAssert.AreEquivalent(new uint[] { 1243, 1245, 1263, 1352, 1354, 1254, 1259, 1261, 1285, 1264, 1265, 1266, 1267, 1268, 1269 }, scenes.Select(scene => scene.MissionId).ToArray(), "the scenes");
            var hidden = scenes.SelectMany(scene => (scene.Scene.HiddenObjectiveIds ?? new()).Select(objective => (scene.MissionId, objective))).ToHashSet();
            CollectionAssert.AreEquivalent(new[] { (1263U, 2U), (1254U, 4U) }, hidden.ToArray(), "1263's tally and 1254's outcome, hidden");
            var objectives = world.MissionObjectiveDefinitionEntries.AsNoTracking().Where(entry => entry.ContentRevision == revision)
                .Select(entry => new { entry.MissionId, entry.ObjectiveId }).ToList();
            Assert.HasCount(5 + 2 + 1 + 1 + 5 + 2 + 1 + 4 + 1 + 2 + 1 + 11 + 3 + 2 + 4 + 1 + 1 + 1 + 1 + 2 + 2 + 2 + 2 + 2 + 2, objectives, "the objectives are read");
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
                (1244, 1, -260, -310, 15),                          // Exing, moved (set 2, fix B)
                (1245, 1, -431, -203, 8), (1245, 2, -554, -230, 8), (1245, 3, -596, -83, 8), (1245, 4, -476, -17, 8), (1245, 5, -338, -80, 8),
                (1247, 1, -180, -305, 20), (1247, 1, -140, -305, 20), // the Thrax Ravager pools 790085, 790086
                (1247, 3, -160, -260, 20), (1247, 3, -120, -225, 20), // the Thrax Soldier pools 790087, 790088
                (1248, 1, -174.4, -482.2, 50), (1248, 1, -161.6, -392.2, 40), // the Desert Predators' south and north beats
                (1249, 1, -210.888, -409.662, 10), (1249, 2, -195.561, -337.739, 10), // the mortar pools 592191, 592192
                (1249, 3, -180.58, -282.694, 10), (1249, 4, -140.3, -285.3, 10),       // and 592193, 592194
                (1262, 1, 560, -250, 20), (1262, 1, 600, -230, 20), (1262, 1, 640, -250, 20), // the Xanx pools 790122-790124
                (1263, 1, 512.5, -335.5, 55),                       // over the six fallen
                (1272, 1, 580, -345, 15), (1272, 1, 585, -370, 15), // the Desert Stalker pools 790125, 790126
                (1352, 1, 440.34, -200.983, 10), (1352, 2, 490.114, -194.194, 10), // the trench mortar pools 592199, 592202
                (1352, 3, 524.666, -170.568, 10), (1352, 4, 550.574, -130.494, 10), // and 592203, 592204
                (1352, 5, 376, 117, 10), (1352, 6, 412, 117, 10), (1352, 7, 428, 117, 10), // the launchers' Detonation Devices
                (1352, 8, 376, 155, 10), (1352, 9, 416, 155, 10), (1352, 10, 424, 155, 10),
                (1352, 11, 501.4, -174.1, 75),                      // over the trench, round the four mortars
                (1354, 1, 318, -14, 8), (1354, 2, 326, -34, 8), (1354, 3, 314, -52, 8), // the power generators
                (1355, 1, 385, 82, 15), (1355, 1, 420, 95, 15), (1355, 1, 466, 132, 15), (1355, 1, 430, 160, 15), (1355, 1, 358, 160, 15), // the Linker pools
                (1355, 2, 296, -30, 15),                            // Overseer Naxveik, moved
                (1254, 1, 576, -321, 8), (1254, 2, 576, -321, 8), (1254, 3, 576, -321, 8), // Latan
                (1258, 1, 686, -495, 8), (1259, 1, 686, -495, 8),   // Yamamoto
                (1261, 1, -132, -875, 8),                           // Mason Linier
                (1285, 1, 566, -136, 25), (1285, 1, 487, -261.3, 25), (1285, 1, 487, -219, 25), // the Boneyard's Thrax pools 531038, 531039, 531041 (moved by set 6)
                (1264, 1, 700, -250, 20), (1264, 1, 690, -310, 20), // the Nitroglazer pools 790243, 790244
                (1264, 2, 440, -320, 20), (1264, 2, 440, -360, 20), // the Hominis Machina pools 790245, 790246
                (1266, 1, 566, -136, 25), (1266, 1, 487, -261.3, 25), (1266, 1, 487, -219, 25), // rifles: the Boneyard's Thrax pools
                (1266, 2, -180, -305, 25), (1266, 2, -140, -305, 25), // launchers: the highway's Ravager pools 790085, 790086
                (1265, 1, 580, -345, 15), (1265, 1, 585, -370, 15), // the Desert Stalker pools 790125, 790126
                (1265, 2, -174.4, -482.2, 50), (1265, 2, -161.6, -392.2, 40), // the Desert Predators' beats (as 1248's)
                // Set 8: Ito's twins on the same places as Latan's.
                (1267, 1, 700, -250, 20), (1267, 1, 690, -310, 20), // the Nitroglazer pools 790243, 790244
                (1267, 2, 440, -320, 20), (1267, 2, 440, -360, 20), // the Hominis Machina pools 790245, 790246
                (1269, 1, 566, -136, 25), (1269, 1, 487, -261.3, 25), // rifles: the Boneyard's Thrax pools 531038, 531039 (not 531041)
                (1269, 2, -180, -305, 25), (1269, 2, -140, -305, 25), // launchers: the highway's Ravager pools 790085, 790086
                (1268, 1, 580, -345, 15), (1268, 1, 585, -370, 15), // the Desert Stalker pools 790125, 790126
                (1268, 2, -174.4, -482.2, 50), (1268, 2, -161.6, -392.2, 40) // the Desert Predators' beats (as 1248's)
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
                (790122, Xanx, 1, 1262), (790123, Xanx, 1, 1262), (790124, Xanx, 1, 1262), (790125, Stalker, 1, 1272), (790126, Stalker, 1, 1272),
                (592199, 790160, 1, 1352), (592202, 790161, 2, 1352), (592203, 790162, 3, 1352), (592204, 790163, 4, 1352),
                (790164, Linker, 1, 1355), (790165, Linker, 1, 1355), (790166, Linker, 1, 1355), (790167, Linker, 1, 1355), (790168, Linker, 1, 1355),
                (Naxveik, Naxveik, 2, 1355),
                (531038, ThraxSoldier, 1, 1285), (531039, ThraxSoldier, 1, 1285), (531041, ThraxSoldier, 1, 1285),
                (790243, Nitroglazer, 1, 1264), (790244, Nitroglazer, 1, 1264), (790245, Machina, 2, 1264), (790246, Machina, 2, 1264),
                (531038, ThraxSoldier, 1, 1266), (531039, ThraxSoldier, 1, 1266), (531041, ThraxSoldier, 1, 1266),
                (790085, Ravager, 2, 1266), (790086, Ravager, 2, 1266), (790125, Stalker, 1, 1265), (790126, Stalker, 1, 1265),
                (790243, Nitroglazer, 1, 1267), (790244, Nitroglazer, 1, 1267), (790245, Machina, 2, 1267), (790246, Machina, 2, 1267),
                (531038, ThraxSoldier, 1, 1269), (531039, ThraxSoldier, 1, 1269),
                (790085, Ravager, 2, 1269), (790086, Ravager, 2, 1269), (790125, Stalker, 1, 1268), (790126, Stalker, 1, 1268)
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
            // And inside each Predator salvage marker of 1265 and 1268 (objective 2), its own.
            foreach (var (mission, objective) in new (uint, uint)[] { (1248, 1), (1265, 2), (1268, 2) })
            {
                var predatorMarkers = rows.Where(row => row.MissionId == mission && row.ObjectiveId == objective).OrderBy(row => row.IndicatorId).ToList();
                Assert.HasCount(2, predatorMarkers, $"{mission}: a marker on each beat");
                foreach (var ((pool, steps), marker) in beats.OrderBy(beat => beat.Key).Zip(predatorMarkers))
                {
                    Assert.AreEqual(Predator, harness.World.SpawnPoolEntries.AsNoTracking().Single(entry => entry.Id == pool).Creature1Id, $"pool {pool}");
                    foreach (var step in steps)
                        Assert.IsLessThanOrEqualTo(marker.Radius, Vector2.Distance(new((float)marker.PosX, (float)marker.PosZ), new((float)step.PosX, (float)step.PosZ)),
                            $"{mission}: pool {pool} step {step.Step} inside its marker");
                }
            }

            // The six fallen (1263's scene) inside its one marker.
            var field = rows.Single(row => row.MissionId == 1263);
            foreach (var actor in Scenes(harness).Single(scene => scene.MissionId == 1263).Scene.Actors.Values)
                Assert.IsLessThanOrEqualTo(field.Radius, Vector2.Distance(new((float)field.PosX, (float)field.PosZ), new(actor.Position.X, actor.Position.Z)),
                    $"{actor.Role} inside the 1263 marker");

            // Set 5: the four trench mortars inside 1352's 11 marker; each launcher's device and each generator under its
            // objective's marker, the generator's device inside it too.
            var trench = rows.Single(row => row.MissionId == 1352 && row.ObjectiveId == 11);
            foreach (var pool in TrenchPools)
            {
                var row = harness.World.SpawnPoolEntries.AsNoTracking().Single(entry => entry.Id == pool);
                Assert.IsLessThanOrEqualTo(trench.Radius - 5, Vector2.Distance(new((float)trench.PosX, (float)trench.PosZ), new((float)row.PosX, (float)row.PosZ)),
                    $"trench mortar pool {pool} inside 1352's 11 marker");
            }
            for (var number = 1; number <= 6; number++)
            {
                var device = AshenDeathFromAboveV1.DevicesAt[number - 1];
                var marker = rows.Single(row => row.MissionId == 1352 && row.ObjectiveId == 4 + number);
                Assert.IsLessThan(0.1f, Vector2.Distance(new((float)marker.PosX, (float)marker.PosZ), new(device.X, device.Z)), $"launcher {number}'s device under its marker");
            }
            for (var number = 1; number <= 3; number++)
            {
                var marker = rows.Single(row => row.MissionId == 1354 && row.ObjectiveId == number);
                foreach (var at in new[] { AshenTurningOutTheLightsV1.GeneratorsAt[number - 1], AshenTurningOutTheLightsV1.DevicesAt[number - 1] })
                    Assert.IsLessThanOrEqualTo(marker.Radius, Vector2.Distance(new((float)marker.PosX, (float)marker.PosZ), new(at.X, at.Z)), $"generator {number} and its device inside its marker");
            }
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
            }

            AllUp();
            Assert.AreEqual(AshenFixBV1.PoolNow, ExingAt(), "Exing at fix B's place (the last migration)");
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
            Assert.AreEqual(AshenMaunaBarrensNpcsV1.ExingAt, ExingAt(), "Exing at his set 2 place (fix B not run again)");
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
        /// Set 5's creatures: the trench mortar pools 592199, 592202-592204 each hold their own copy of the Ashen Bane Mortar
        /// 592011 (all of its row, its stats and look but the id, no name id); the Linker pools hold the World DB's Linker - Ashen
        /// Desert 531014 (name 414 "Linker Master", L40, unchanged), three each, radius 0, 120 s respawn, automatic, linked to no
        /// control point and 130 m or more from Control Point 16; Overseer Naxveik's row is upstream's (name 9353, L44), his pool
        /// moved, one of him, automatic.
        /// </summary>
        [TestMethod]
        public void TheConscriptionBaseCreaturesCopyTheirWorldRows()
        {
            using var harness = WildernessRuntimeTestHarness.Create();
            var world = harness.World;
            var creatures = world.CreatureEntries.AsNoTracking().ToDictionary(row => row.Id);
            var stats = world.CreatureStatEntries.AsNoTracking().ToDictionary(row => row.Id);
            var mortar = creatures[Mortar];
            var look = world.CreatureAppearanceEntries.AsNoTracking().Where(row => row.Id == Mortar).ToList()
                .Select(row => (row.SlotId, row.ClassId, row.Color)).ToList();
            for (var index = 0; index < TrenchCopies.Length; index++)
            {
                var copy = creatures[TrenchCopies[index]];
                Assert.AreEqual((mortar.ClassId, mortar.Faction, mortar.Level, mortar.MaxHitPoints, mortar.NameId, mortar.Action1, mortar.RunSpeed, mortar.WalkSpeed),
                    (copy.ClassId, copy.Faction, copy.Level, copy.MaxHitPoints, copy.NameId, copy.Action1, copy.RunSpeed, copy.WalkSpeed), $"{copy.Id} copies {Mortar}");
                Assert.AreEqual((7482U, 0U, 42U), (copy.ClassId, copy.NameId, copy.Level));
                Assert.AreEqual((stats[Mortar].Health, stats[Mortar].Armor), (stats[copy.Id].Health, stats[copy.Id].Armor), $"{copy.Id} stats");
                CollectionAssert.AreEqual(look, world.CreatureAppearanceEntries.AsNoTracking().Where(row => row.Id == copy.Id).ToList()
                    .Select(row => (row.SlotId, row.ClassId, row.Color)).ToList(), $"{copy.Id} look");
                var pool = world.SpawnPoolEntries.AsNoTracking().Single(row => row.Id == TrenchPools[index]);
                Assert.AreEqual((Map, copy.Id, (byte)1, (byte)1, (byte)0), (pool.MapContextId, pool.Creature1Id, pool.Creature1MinCount, pool.Creature1MaxCount, pool.Mode),
                    $"trench mortar pool {pool.Id}");
            }

            Assert.AreEqual((414U, 9751U, 40U, 0U), (creatures[Linker].NameId, creatures[Linker].ClassId, creatures[Linker].Level, creatures[Linker].Faction),
                "the Linker row, as upstream");
            var links = world.ControlPointLinkEntries.AsNoTracking().Select(row => row.ObjectId).ToList();
            var garrison = world.ControlPointEntries.AsNoTracking().Single(row => row.Id == 16);
            foreach (var pool in LinkerPools)
            {
                var row = world.SpawnPoolEntries.AsNoTracking().Single(entry => entry.Id == pool);
                Assert.AreEqual((Map, Linker, (byte)3, (byte)3, 0U, 0.0, 1200U, (byte)0), (row.MapContextId, row.Creature1Id, row.Creature1MinCount,
                    row.Creature1MaxCount, row.Creature2Id, row.Radius, row.RespawnTime, row.Mode), $"pool {pool}");
                Assert.IsGreaterThanOrEqualTo(130.0, System.Math.Sqrt(System.Math.Pow(row.PosX - garrison.PosX, 2) + System.Math.Pow(row.PosZ - garrison.PosZ, 2)),
                    $"pool {pool} 130 m or more from the Conscription Garrison");
                Assert.IsFalse(links.Contains(pool), $"pool {pool} linked to no control point");
            }

            Assert.AreEqual((9353U, 44U, 0U), (creatures[Naxveik].NameId, creatures[Naxveik].Level, creatures[Naxveik].Faction), "Overseer Naxveik's row, as upstream");
            var naxveik = world.SpawnPoolEntries.AsNoTracking().Single(row => row.Id == Naxveik);
            Assert.AreEqual((Map, Naxveik, (byte)1, (byte)1, (byte)0), (naxveik.MapContextId, naxveik.Creature1Id, naxveik.Creature1MinCount, naxveik.Creature1MaxCount, naxveik.Mode));
            Assert.IsGreaterThanOrEqualTo(130.0, System.Math.Sqrt(System.Math.Pow(naxveik.PosX - garrison.PosX, 2) + System.Math.Pow(naxveik.PosZ - garrison.PosZ, 2)),
                "Naxveik 130 m or more from the Conscription Garrison");
            Assert.IsFalse(links.Contains(Naxveik) || TrenchPools.Any(links.Contains), "Naxveik and the trench mortars linked to no control point");
        }

        /// <summary>
        /// Ashen_conscription_base takes out its three missions, the four trench mortar copies and the five Linker pools, gives
        /// the trench pools 592011 back and puts Naxveik back where upstream had him (its float values); the Linker and Naxveik
        /// rows stay; sets 1-4 stay. Up again, all of it is back. The counts take only set 5's own ids and missions.
        /// </summary>
        [TestMethod]
        public void ConscriptionBaseRollsBackWithItsMigration()
        {
            var missions = new[] { AshenDeathFromAboveV1.MissionId, AshenTurningOutTheLightsV1.MissionId, AshenStrongestLinkV1.MissionId };
            using var harness = WildernessRuntimeTestHarness.Create();
            var world = harness.World;
            bool Has(uint mission) => world.MissionContentDefinitionEntries.AsNoTracking()
                .Any(entry => entry.MissionId == mission && entry.ContentRevision == AshenMissionDataV1.Revision);
            int Count(string sql) => world.Database.SqlQueryRaw<int>(sql).AsEnumerable().Single();
            var creatures = string.Join(", ", TrenchCopies);
            var pools = string.Join(", ", LinkerPools);
            var ids = string.Join(", ", missions);
            var trench = string.Join(", ", TrenchPools);
            (int, int, int, int, int, int, int, int) All() => (
                Count($"SELECT COUNT(*) AS Value FROM creature WHERE id IN ({creatures})"),
                Count($"SELECT COUNT(*) AS Value FROM creature_stat WHERE id IN ({creatures})"),
                Count($"SELECT COUNT(*) AS Value FROM creature_appearance WHERE id IN ({creatures})"),
                Count($"SELECT COUNT(*) AS Value FROM spawnpool WHERE id IN ({pools})"),
                Count($"SELECT COUNT(*) AS Value FROM mission_indicator WHERE content_revision = 'ashen_1_16_5' AND mission_id IN ({ids})"),
                Count($"SELECT COUNT(*) AS Value FROM mission_scene_binding WHERE content_revision = 'ashen_1_16_5' AND mission_id IN ({ids})"),
                Count($"SELECT COUNT(*) AS Value FROM spawnpool WHERE id IN ({trench}) AND creature_1_Id = {Mortar}"),
                Count($"SELECT COUNT(*) AS Value FROM creature WHERE id IN ({Linker}, {Naxveik})"));
            (double X, double Y, double Z) NaxveikAt()
            {
                var row = world.SpawnPoolEntries.AsNoTracking().Single(entry => entry.Id == Naxveik);
                return (row.PosX, row.PosY, row.PosZ);
            }
            void AllUp()
            {
                Assert.IsTrue(missions.All(Has));
                Assert.AreEqual((4, 4, 4, 5, 20, 2, 0, 2), All());
                Assert.AreEqual(AshenConscriptionBaseNpcsV1.NaxveikAt, NaxveikAt(), "Naxveik at his set 5 place");
            }

            AllUp();
            world.GetService<IMigrator>().Migrate(Previous(world, ConscriptionBase));
            world.ChangeTracker.Clear();
            Assert.IsFalse(missions.Any(Has));
            Assert.AreEqual((0, 0, 0, 0, 0, 0, 4, 2), All());
            Assert.AreEqual((305.4142150878906, 282.60791015625, 84.41419982910156), NaxveikAt(), "Naxveik back at upstream's place, to the float");
            Assert.IsFalse(world.MissionEvidenceEntries.Any(entry => entry.ContentRevision == AshenMissionDataV1.Revision && missions.Contains(entry.MissionId)));
            Assert.IsFalse(world.MissionRewardItemEntries.Any(entry => entry.ContentRevision == AshenMissionDataV1.Revision && missions.Contains(entry.MissionId)));
            Assert.IsFalse(world.MissionObjectiveDefinitionEntries.Any(entry => entry.ContentRevision == AshenMissionDataV1.Revision && missions.Contains(entry.MissionId)));
            Assert.IsFalse(world.MissionPrerequisiteEntries.Any(entry => entry.ContentRevision == AshenMissionDataV1.Revision && missions.Contains(entry.MissionId)));
            Assert.IsTrue(MissionIds.Take(15).All(Has), "sets 1-4 stay");

            world.GetService<IMigrator>().Migrate(ConscriptionBase);
            world.ChangeTracker.Clear();
            AllUp();
        }

        /// <summary>
        /// Ashen_formal_complaints takes out its five missions and Latan, Ito and Megumi (creature, look, stats, package, pool)
        /// and puts the Boneyard's three Thrax pools back to upstream's rows (point and radius, to the float); the upstream rows
        /// it uses (Mason Linier, Raji Lasat, Ida Hayner) and sets 1-5 stay, and no other Ashen pool changes. Up again, all of
        /// it is back. The counts take only set 6's own ids and missions.
        /// </summary>
        [TestMethod]
        public void FormalComplaintsRollsBackWithItsMigration()
        {
            var missions = new[]
            {
                AshenFormalComplaintsV1.MissionId, AshenHumanPerspectiveV1.MissionId, AshenBribeForYourThoughtsV1.MissionId,
                AshenCourtMartialArtsV1.MissionId, AshenDearlyDepartedV1.MissionId
            };
            using var harness = WildernessRuntimeTestHarness.Create();
            var world = harness.World;
            bool Has(uint mission) => world.MissionContentDefinitionEntries.AsNoTracking()
                .Any(entry => entry.MissionId == mission && entry.ContentRevision == AshenMissionDataV1.Revision);
            int Count(string sql) => world.Database.SqlQueryRaw<int>(sql).AsEnumerable().Single();
            var npcs = string.Join(", ", new[] { Latan, Ito, Megumi });
            var ids = string.Join(", ", missions);
            (int, int, int, int, int, int, int, int) All() => (
                Count($"SELECT COUNT(*) AS Value FROM creature WHERE id IN ({npcs})"),
                Count($"SELECT COUNT(*) AS Value FROM creature_stat WHERE id IN ({npcs})"),
                Count($"SELECT COUNT(*) AS Value FROM npc_package WHERE id IN ({npcs})"),
                Count($"SELECT COUNT(*) AS Value FROM spawnpool WHERE id IN ({npcs})"),
                Count($"SELECT COUNT(*) AS Value FROM mission_indicator WHERE content_revision = 'ashen_1_16_5' AND mission_id IN ({ids})"),
                Count($"SELECT COUNT(*) AS Value FROM mission_scene_binding WHERE content_revision = 'ashen_1_16_5' AND mission_id IN ({ids})"),
                Count($"SELECT COUNT(*) AS Value FROM creature WHERE id IN ({MasonLinier}, 510014, 510011)"),
                Count("SELECT COUNT(*) AS Value FROM spawnpool WHERE id IN (531038, 531039, 531041) AND creature_1_Id = 531008"));
            ((double, double, double) At, double Radius)[] Thrax() => AshenDearlyDepartedV1.Pools
                .Select(pool => world.SpawnPoolEntries.AsNoTracking().Single(entry => entry.Id == pool.Pool))
                .Select(row => ((row.PosX, row.PosY, row.PosZ), row.Radius)).ToArray();
            var thraxIds = AshenDearlyDepartedV1.Pools.Select(pool => pool.Pool).ToArray();
            var later = PoolsOfLaterMigrations(world, FormalComplaints);
            string Others() => string.Join("; ", world.SpawnPoolEntries.AsNoTracking()
                .Where(entry => entry.MapContextId == AshenMissionDataV1.MapContextId && !thraxIds.Contains(entry.Id) && entry.Id != Latan && entry.Id != Ito && entry.Id != Megumi
                    && !later.Contains(entry.Id)) // the later migrations' pools (fix B's Exing, set 7's robots) go down and up too
                .OrderBy(entry => entry.Id).Select(entry => new { entry.Id, entry.PosX, entry.PosY, entry.PosZ, entry.Radius }).AsEnumerable().Select(entry => entry.ToString()));
            var others = Others();
            void AllUp()
            {
                Assert.IsTrue(missions.All(Has));
                Assert.AreEqual((3, 3, 3, 3, 9, 4, 3, 3), All());
                CollectionAssert.AreEqual(AshenDearlyDepartedV1.Pools.Select(pool => (pool.At, 0.0)).ToArray(), Thrax()
                    .Select(pool => ((System.Math.Round(pool.At.Item1, 2), System.Math.Round(pool.At.Item2, 2), System.Math.Round(pool.At.Item3, 2)), pool.Radius)).ToArray(), "the Thrax pools on their points");
                Assert.IsTrue(Count($"SELECT COUNT(*) AS Value FROM creature_appearance WHERE id IN ({npcs})") >= 3, "the three looks");
            }

            AllUp();
            world.GetService<IMigrator>().Migrate(Previous(world, FormalComplaints));
            world.ChangeTracker.Clear();
            Assert.IsFalse(missions.Any(Has));
            Assert.AreEqual((0, 0, 0, 0, 0, 0, 3, 3), All());
            CollectionAssert.AreEqual(new ((double, double, double), double)[]
            {
                ((544.2000122070312, 283.20001220703125, -120), 14.4), ((499, 285.5, -269.29998779296875), 10.7), ((502, 277.5, -198.1999969482422), 12.6)
            }, Thrax(), "upstream's Thrax pools, to the float");
            Assert.AreEqual(others, Others(), "no other Ashen pool changes");
            Assert.AreEqual(0, Count($"SELECT COUNT(*) AS Value FROM creature_appearance WHERE id IN ({npcs})"), "no look left");
            Assert.IsFalse(world.MissionEvidenceEntries.Any(entry => entry.ContentRevision == AshenMissionDataV1.Revision && missions.Contains(entry.MissionId)));
            Assert.IsFalse(world.MissionRewardItemEntries.Any(entry => entry.ContentRevision == AshenMissionDataV1.Revision && missions.Contains(entry.MissionId)));
            Assert.IsFalse(world.MissionObjectiveDefinitionEntries.Any(entry => entry.ContentRevision == AshenMissionDataV1.Revision && missions.Contains(entry.MissionId)));
            Assert.IsFalse(world.MissionPrerequisiteEntries.Any(entry => entry.ContentRevision == AshenMissionDataV1.Revision && missions.Contains(entry.MissionId)));
            Assert.IsFalse(world.Set<MissionActionEntry>().Any(entry => entry.ContentRevision == AshenMissionDataV1.Revision && missions.Contains(entry.MissionId)));
            Assert.IsTrue(MissionIds.Take(18).All(Has), "sets 1-5 stay");

            world.GetService<IMigrator>().Migrate(FormalComplaints);
            world.ChangeTracker.Clear();
            AllUp();
            Assert.AreEqual(others, Others(), "no other Ashen pool changes");
        }

        /// <summary>
        /// Set 7's creatures: the Nitroglazer 790240 (class 7234, the client's name 434) and the Hominis Machina Mk XI 790241 (class
        /// 3868, 7716), hostile, level 40, 8409 hit points and armour 285 (ESTIMATE: the Ashen level-40 rows'); their attacks
        /// their own rows (the World DB rows' actions and reaches at the Ashen Thrax damage), the Machina's revive upstream's
        /// 62059 and its look the Torcastra Machina 660012's; two pools of three of each (radius 0, 120 s respawn, automatic) on
        /// Ashen Desert, the only pools that hold them.
        /// </summary>
        [TestMethod]
        public void TheBoneyardRobotsHaveTheirOwnRows()
        {
            using var harness = WildernessRuntimeTestHarness.Create();
            var world = harness.World;
            var creatures = world.CreatureEntries.AsNoTracking().ToDictionary(row => row.Id);
            var stats = world.CreatureStatEntries.AsNoTracking().ToDictionary(row => row.Id);
            var actions = world.Set<CreatureActionEntry>().AsNoTracking().ToDictionary(row => row.Id);
            foreach (var (robot, cls, name, attacks, pools) in new (uint, uint, uint, uint[], uint[])[]
            {
                (Nitroglazer, 7234, 434, new uint[] { 790240, 790242 }, NitroPools),
                (Machina, 3868, 7716, new uint[] { 790241, 62059 }, MachinaPools)
            })
            {
                var row = creatures[robot];
                Assert.AreEqual((cls, name, 40U, 0U, 8409U, 9U, 5U), (row.ClassId, row.NameId, row.Level, row.Faction, row.MaxHitPoints, row.RunSpeed, row.WalkSpeed), $"{robot}");
                Assert.AreEqual((attacks[0], attacks[1], 0U), (row.Action1, row.Action2, row.Action3), $"{robot} attacks");
                Assert.AreEqual((8409, 285), (stats[robot].Health, stats[robot].Armor), $"{robot} stats");
                Assert.IsTrue(CreatureManager.Instance.LoadedCreatures.TryGetValue(robot, out var loaded) && loaded.TargetCategory == TargetCategory.Hostile, $"{robot} hostile");
                CollectionAssert.AreEquivalent(pools, world.SpawnPoolEntries.AsNoTracking().Where(pool => pool.Creature1Id == robot).Select(pool => pool.Id).ToArray(), $"{robot}'s pools");
                foreach (var pool in pools)
                {
                    var entry = world.SpawnPoolEntries.AsNoTracking().Single(candidate => candidate.Id == pool);
                    Assert.AreEqual((Map, (byte)3, (byte)3, 0U, 0.0, 1200U, (byte)0), (entry.MapContextId, entry.Creature1MinCount, entry.Creature1MaxCount,
                        entry.Creature2Id, entry.Radius, entry.RespawnTime, entry.Mode), $"pool {pool}");
                }
            }
            // The attacks: action, argument, reach, cooldown, damage, kind (the World DB rows' 710001 / 710002 / 660002 but the damage).
            foreach (var (id, action, arg, min, max, cooldown, low, high) in new (uint, uint, uint, double, double, uint, uint, uint)[]
            {
                (790240, 1, 232, 1, 30, 1500, 247, 370), (790242, 289, 1, 5, 40, 12000, 356, 555), (790241, 1, 97, 1, 20, 800, 247, 370)
            })
            {
                var row = actions[id];
                Assert.AreEqual((action, arg, min, max, cooldown, 0U, low, high, 1U), (row.ActionId, row.ActionArgId, row.RangeMin, row.RangeMax, row.Cooldown,
                    row.Windup, row.MinDamage, row.MaxDamage, row.DamageType), $"action {id}");
            }
            Assert.AreEqual(429U, actions[62059].ActionId, "upstream's machina_revive, unchanged");
            CollectionAssert.AreEquivalent(
                world.CreatureAppearanceEntries.AsNoTracking().Where(row => row.Id == 660012).ToList().Select(row => (row.SlotId, row.ClassId, row.Color)).ToArray(),
                world.CreatureAppearanceEntries.AsNoTracking().Where(row => row.Id == Machina).ToList().Select(row => (row.SlotId, row.ClassId, row.Color)).ToArray(),
                "the Machina's look is 660012's");
        }

        /// <summary>
        /// Ashen_scavenger takes out its three missions, the two robots (creature, stats, look, attacks) and their four pools; the
        /// upstream rows it uses (Latan's set 6 row, the Thrax, the Stalker and Predator of sets 3 and 4, the revive action and
        /// 660012's look) stay, no Ashen pool changes, sets 1-6 stay. Up again, all of it is back. The counts take only set 7's own
        /// ids and missions.
        /// </summary>
        [TestMethod]
        public void ScavengerRollsBackWithItsMigration()
        {
            var missions = new[] { AshenRoboticSalvageV1.MissionId, AshenWeaponSalvageV1.MissionId, AshenHeavySalvageV1.MissionId };
            using var harness = WildernessRuntimeTestHarness.Create();
            var world = harness.World;
            bool Has(uint mission) => world.MissionContentDefinitionEntries.AsNoTracking()
                .Any(entry => entry.MissionId == mission && entry.ContentRevision == AshenMissionDataV1.Revision);
            int Count(string sql) => world.Database.SqlQueryRaw<int>(sql).AsEnumerable().Single();
            var robots = $"{Nitroglazer}, {Machina}";
            var pools = string.Join(", ", NitroPools.Concat(MachinaPools));
            var ids = string.Join(", ", missions);
            (int, int, int, int, int, int, int, int, int) All() => (
                Count($"SELECT COUNT(*) AS Value FROM creature WHERE id IN ({robots})"),
                Count($"SELECT COUNT(*) AS Value FROM creature_stat WHERE id IN ({robots})"),
                Count($"SELECT COUNT(*) AS Value FROM creature_appearance WHERE id IN ({robots})"),
                Count("SELECT COUNT(*) AS Value FROM creature_action WHERE id IN (790240, 790241, 790242)"),
                Count($"SELECT COUNT(*) AS Value FROM spawnpool WHERE id IN ({pools})"),
                Count($"SELECT COUNT(*) AS Value FROM mission_indicator WHERE content_revision = 'ashen_1_16_5' AND mission_id IN ({ids})"),
                Count($"SELECT COUNT(*) AS Value FROM mission_scene_binding WHERE content_revision = 'ashen_1_16_5' AND mission_id IN ({ids})"),
                Count($"SELECT COUNT(*) AS Value FROM creature WHERE id IN ({Latan}, {ThraxSoldier}, {Ravager}, {Stalker}, {Predator}, 660012)"),
                Count("SELECT COUNT(*) AS Value FROM creature_action WHERE id = 62059"));
            var look = Count("SELECT COUNT(*) AS Value FROM creature_appearance WHERE id = 660012");
            Assert.IsGreaterThan(0, look);
            var later = PoolsOfLaterMigrations(world, Scavenger);
            string Others() => string.Join("; ", world.SpawnPoolEntries.AsNoTracking()
                .Where(entry => entry.MapContextId == AshenMissionDataV1.MapContextId && !NitroPools.Contains(entry.Id) && !MachinaPools.Contains(entry.Id) && !later.Contains(entry.Id))
                .OrderBy(entry => entry.Id).Select(entry => new { entry.Id, entry.PosX, entry.PosY, entry.PosZ, entry.Radius, entry.Creature1Id }).AsEnumerable().Select(entry => entry.ToString()));
            var others = Others();
            void AllUp()
            {
                Assert.IsTrue(missions.All(Has));
                Assert.AreEqual((2, 2, look, 3, 4, 13, 3, 6, 1), All());
            }

            AllUp();
            world.GetService<IMigrator>().Migrate(Previous(world, Scavenger));
            world.ChangeTracker.Clear();
            Assert.IsFalse(missions.Any(Has));
            Assert.AreEqual((0, 0, 0, 0, 0, 0, 0, 6, 1), All());
            Assert.AreEqual(others, Others(), "no other Ashen pool changes");
            Assert.IsFalse(world.MissionEvidenceEntries.Any(entry => entry.ContentRevision == AshenMissionDataV1.Revision && missions.Contains(entry.MissionId)));
            Assert.IsFalse(world.MissionRewardItemEntries.Any(entry => entry.ContentRevision == AshenMissionDataV1.Revision && missions.Contains(entry.MissionId)));
            Assert.IsFalse(world.MissionObjectiveDefinitionEntries.Any(entry => entry.ContentRevision == AshenMissionDataV1.Revision && missions.Contains(entry.MissionId)));
            Assert.IsFalse(world.MissionPrerequisiteEntries.Any(entry => entry.ContentRevision == AshenMissionDataV1.Revision && missions.Contains(entry.MissionId)));
            Assert.IsFalse(world.Set<MissionTriggerEntry>().Any(entry => entry.ContentRevision == AshenMissionDataV1.Revision && missions.Contains(entry.MissionId)));
            Assert.IsTrue(MissionIds.Take(23).All(Has), "sets 1-6 stay");

            world.GetService<IMigrator>().Migrate(Scavenger);
            world.ChangeTracker.Clear();
            AllUp();
            Assert.AreEqual(others, Others(), "no other Ashen pool changes");
        }

        /// <summary>
        /// Ashen_logistician takes out Ito's three missions and nothing else: their definitions, objectives, triggers,
        /// prerequisites, rewards, markers, scenes and evidence go; Latan's twins (set 7, the same item classes), Ito's row, the
        /// creatures and every Ashen pool stay as they were; sets 1-7 stay. Up again, all of it is back. The counts take only set
        /// 8's missions.
        /// </summary>
        [TestMethod]
        public void LogisticianRollsBackWithItsMigration()
        {
            var missions = new[] { AshenRoboticAcquisitionsV1.MissionId, AshenWeaponAcquisitionsV1.MissionId, AshenHeavyAcquisitionsV1.MissionId };
            using var harness = WildernessRuntimeTestHarness.Create();
            var world = harness.World;
            bool Has(uint mission) => world.MissionContentDefinitionEntries.AsNoTracking()
                .Any(entry => entry.MissionId == mission && entry.ContentRevision == AshenMissionDataV1.Revision);
            int Count(string sql) => world.Database.SqlQueryRaw<int>(sql).AsEnumerable().Single();
            const string ids = "1267, 1268, 1269";
            (int, int, int, int, int, int, int, int) All() => (
                Count($"SELECT COUNT(*) AS Value FROM mission_objective_definition WHERE content_revision = 'ashen_1_16_5' AND mission_id IN ({ids})"),
                Count($"SELECT COUNT(*) AS Value FROM mission_trigger WHERE content_revision = 'ashen_1_16_5' AND mission_id IN ({ids})"),
                Count($"SELECT COUNT(*) AS Value FROM mission_prerequisite WHERE content_revision = 'ashen_1_16_5' AND mission_id IN ({ids})"),
                Count($"SELECT COUNT(*) AS Value FROM mission_reward_item WHERE content_revision = 'ashen_1_16_5' AND mission_id IN ({ids})"),
                Count($"SELECT COUNT(*) AS Value FROM mission_indicator WHERE content_revision = 'ashen_1_16_5' AND mission_id IN ({ids})"),
                Count($"SELECT COUNT(*) AS Value FROM mission_scene_binding WHERE content_revision = 'ashen_1_16_5' AND mission_id IN ({ids})"),
                Count($"SELECT COUNT(*) AS Value FROM mission_evidence WHERE content_revision = 'ashen_1_16_5' AND mission_id IN ({ids})"),
                Count($"SELECT COUNT(*) AS Value FROM creature WHERE id IN ({Ito}, {Nitroglazer}, {Machina}, {ThraxSoldier}, {Ravager}, {Stalker}, {Predator})"));
            string Twins() => string.Join("; ", world.MissionIndicatorEntries.AsNoTracking()
                .Where(entry => entry.ContentRevision == AshenMissionDataV1.Revision && entry.MissionId >= 1264 && entry.MissionId <= 1266)
                .OrderBy(entry => entry.MissionId).ThenBy(entry => entry.ObjectiveId).ThenBy(entry => entry.IndicatorId)
                .Select(entry => new { entry.MissionId, entry.ObjectiveId, entry.IndicatorId, entry.PosX, entry.PosZ }).AsEnumerable().Select(entry => entry.ToString()))
                + "|" + string.Join("; ", Scenes(harness).Where(entry => entry.MissionId >= 1264 && entry.MissionId <= 1266).OrderBy(entry => entry.MissionId)
                    .SelectMany(entry => entry.Scene.Items.Select(item => $"{entry.MissionId}:{item.ItemTemplateId}:{item.Drop.ChancePercent}")));
            var later = PoolsOfLaterMigrations(world, Logistician);
            string Others() => string.Join("; ", world.SpawnPoolEntries.AsNoTracking()
                .Where(entry => entry.MapContextId == AshenMissionDataV1.MapContextId && !later.Contains(entry.Id))
                .OrderBy(entry => entry.Id).Select(entry => new { entry.Id, entry.PosX, entry.PosY, entry.PosZ, entry.Radius, entry.Creature1Id }).AsEnumerable().Select(entry => entry.ToString()));
            var others = Others();
            var twins = Twins();
            Assert.Contains("1264:97465:75", twins, "Latan's twins read");
            void AllUp()
            {
                Assert.IsTrue(missions.All(Has));
                Assert.AreEqual((6, 6, 5, 4 + 4 + 4, 12, 3, 9, 7), All());
            }

            AllUp();
            world.GetService<IMigrator>().Migrate(Previous(world, Logistician));
            world.ChangeTracker.Clear();
            Assert.IsFalse(missions.Any(Has));
            Assert.AreEqual((0, 0, 0, 0, 0, 0, 0, 7), All());
            Assert.AreEqual(others, Others(), "no Ashen pool changes");
            Assert.AreEqual(twins, Twins(), "Latan's twins unchanged");
            Assert.IsTrue(MissionIds.Take(26).All(Has), "sets 1-7 stay");

            world.GetService<IMigrator>().Migrate(Logistician);
            world.ChangeTracker.Clear();
            AllUp();
            Assert.AreEqual(others, Others(), "no Ashen pool changes");
            Assert.AreEqual(twins, Twins(), "Latan's twins unchanged");
        }

        /// <summary>
        /// A scene use object takes the use argument the client sends (QUEST-RULES): usabledata lookup[class][0], or 1 where it
        /// is None (Usable.__init__), written out here. 7847 UsableItemAccHumGpsBeacon sends 3 (as CrucibleMissionTests pins it);
        /// 1245's five spots carry the client's name 71 "Atta Sensor Beacon" (usablenameoverride LIGO_ASHEN_ATTA_BEACON). The
        /// human corpses UsableTreasureDispHumCorpseMale V01-V04 (24995, 7865, 24989, 24990) have None: they send 1; 1263's six
        /// fallen carry 63 "Fallen Soldier" (LIGO_ASHEN_FALLENSOLDIER). The bomb acceptor UsableItemAccHumBombV01 (7334) sends 1
        /// (usabledata lookup[7334][0]); 1352's and 1354's Detonation Devices keep the client's own name.
        /// </summary>
        [TestMethod]
        public void EveryUsableSceneObjectTakesTheClientsUseArgument()
        {
            var clientUseArguments = new Dictionary<uint, uint> { [7847] = 3, [24995] = 1, [7865] = 1, [24989] = 1, [24990] = 1, [7334] = 1 };
            var clientUseNames = new Dictionary<uint, uint> { [7847] = 71, [24995] = 63, [7865] = 63, [24989] = 63, [24990] = 63, [7334] = 0 };
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
            Assert.AreEqual(5 + 6 + 6 + 3, used, "1245's five beacon spots, 1263's six fallen, 1352's six and 1354's three Detonation Devices");
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
