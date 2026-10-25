using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rasa.Test.Missions.Pools
{
    using Rasa.Services.Preloader.Missions.Plateau;
    using Rasa.Services.Preloader.Missions.Pools;
    using Rasa.Structures;
    using Rasa.Structures.World;
    using Rasa.Test.Missions.Wilderness;

    /// <summary>
    /// The Valverde Pools missions (PoolsMissionDataV1, revision pools_1_16_5): the Snake Pit's Building Materials (1314)
    /// and Medicinal Measures (1066), with Supply Chief Riggins and Dr. Hester (Pools_snake_pit); Riggins's Death Patrol (1315),
    /// More Clips and Tags (1321) and The Thirsty Hermit (1328), and Snake's move to his sourced place (Pools_death_patrol);
    /// Looking For Logos? (1308), Mapping The Pools (1025) and Bane Investigation (932), with Spymaster Timlin, Specialist
    /// Allen and Lieutenant Feldman (Pools_snake_pit_contacts).
    /// Amee Corman's Retreads to
    /// Retreads (1751) is on the Plateau's revision (PlateauMissionTests): it follows Weapons Trafficking.
    /// </summary>
    [TestClass]
    [DoNotParallelize]
    public class PoolsMissionTests
    {
        /// <summary>The Pools missions the World migrations enable, for the tests that pin the enabled set.</summary>
        internal static readonly uint[] MissionIds =
        {
            PoolsBuildingMaterialsV1.MissionId, PoolsMedicinalMeasuresV1.MissionId, PoolsDeathPatrolV1.MissionId,
            PoolsMoreClipsAndTagsV1.MissionId, PoolsThirstyHermitV1.MissionId, PoolsLookingForLogosV1.MissionId,
            PoolsMappingThePoolsV1.MissionId, PoolsBaneInvestigationV1.MissionId
        };

        /// <summary>
        /// Medicinal Measures' one, on the Mawflower field; The Thirsty Hermit's three (Hester, the cabinet, the Hermit);
        /// Looking For Logos?'s three (Suresh, the Refinery's door, Suresh); Mapping The Pools' eight (Timlin, the pack, the
        /// five beacons, Timlin); Bane Investigation's three (the terminal twice, Feldman). Building Materials, Death Patrol
        /// and More Clips and Tags have none (their creatures and bodies are all over the Pools).
        /// </summary>
        internal const int Indicators = 18;

        private const string Before = "20270401000000_Plateau_retreads_to_retreads";
        private const string SnakePit = "20270402000000_Pools_snake_pit";
        private const string DeathPatrol = "20270403000000_Pools_death_patrol";
        private const string Contacts = "20270404000000_Pools_snake_pit_contacts";

        [TestMethod]
        public void TheMissionsAreEnabledOperationalAndGivenByTheirNpcs()
        {
            var expected = new (uint Mission, uint? Giver, uint? Receiver, uint Level)[]
            {
                (PoolsBuildingMaterialsV1.MissionId, PoolsSnakePitNpcsV1.Riggins, PoolsSnakePitNpcsV1.Riggins, 33),
                (PoolsMedicinalMeasuresV1.MissionId, PoolsSnakePitNpcsV1.Hester, PoolsSnakePitNpcsV1.Hester, 35),
                (PoolsDeathPatrolV1.MissionId, PoolsSnakePitNpcsV1.Riggins, PoolsSnakePitNpcsV1.Riggins, 33),
                (PoolsMoreClipsAndTagsV1.MissionId, PoolsSnakePitNpcsV1.Riggins, PoolsSnakePitNpcsV1.Riggins, 33),
                (PoolsThirstyHermitV1.MissionId, PoolsSnakePitNpcsV1.Riggins, PlateauBaileyNpcsV1.Hermit, 33),
                (PoolsLookingForLogosV1.MissionId, PoolsSnakePitContactsV1.Timlin, 510202, 33),
                (PoolsMappingThePoolsV1.MissionId, PoolsSnakePitContactsV1.Allen, PoolsSnakePitContactsV1.Allen, 35),
                (PoolsBaneInvestigationV1.MissionId, PoolsSnakePitContactsV1.Feldman, PoolsSnakePitContactsV1.Feldman, 35)
            };
            using var harness = WildernessRuntimeTestHarness.Create();
            var enabled = harness.World.MissionContentDefinitionEntries.AsNoTracking()
                .Where(entry => entry.Enabled && entry.ContentRevision == PoolsMissionDataV1.Revision).ToArray();
            CollectionAssert.AreEquivalent(MissionIds, enabled.Select(entry => entry.MissionId).ToArray());
            foreach (var (mission, giver, receiver, level) in expected)
            {
                var entry = enabled.Single(row => row.MissionId == mission);
                Assert.AreEqual<uint?>(giver, entry.GiverId, $"{mission} giver");
                Assert.AreEqual<uint?>(receiver, entry.ReceiverId, $"{mission} receiver");
                Assert.AreEqual<uint?>(level, entry.Level, $"{mission} level");
                Assert.AreEqual<uint?>(PoolsMissionDataV1.CategoryId, entry.CategoryId);
            }
            // Riggins, Hester, Timlin and Feldman stand at the Snake Pit, Allen in the field, on Valverde Pools, with their
            // names, level and packages.
            foreach (var (npc, name, package) in new (uint, uint, uint)[]
            {
                (650200, 9385, 650200), (650201, 8865, 1129), (650202, 4385, 343), (650203, 4387, 650203), (650204, 4376, 650204)
            })
            {
                Assert.AreEqual(1304U, harness.World.SpawnPoolEntries.AsNoTracking().Single(row => row.Id == npc).MapContextId, $"{npc} map");
                var creature = harness.World.CreatureEntries.AsNoTracking().Single(row => row.Id == npc);
                Assert.AreEqual((name, 40U), (creature.NameId, creature.Level), $"{npc} name and level");
                Assert.AreEqual(package, harness.World.NpcPackageEntries.AsNoTracking().Single(row => row.Id == npc).PackageId, $"{npc} package");
            }

            Assert.IsFalse(harness.Manager.LoadMissions().BlocksReadiness);
            foreach (var id in MissionIds)
                Assert.IsTrue(harness.Manager.LoadedMissions[id].IsOperational,
                    $"{id}: {harness.Manager.LoadedMissions[id].OperationalDiagnostic}");
        }

        /// <summary>
        /// The client's own texts: the ids are written out here from the client tables (missionconversation,
        /// missionobjective), not taken from the data classes, so a wrong id in those fails.
        /// </summary>
        [TestMethod]
        public void TitlesAndObjectivesUseTheClientsTexts()
        {
            var expected = new (uint Mission, uint Title, (uint Objective, uint Name, uint Body, uint? Counter)[] Objectives)[]
            {
                (1314, 10666, new (uint, uint, uint, uint?)[] { (1, 10671, 10672, null), (2, 10673, 10674, null), (3, 10675, 10676, null) }),
                (1066, 6005, new (uint, uint, uint, uint?)[] { (1, 6019, 7644, null), (2, 6019, 7644, null) }),
                (1315, 10677, new (uint, uint, uint, uint?)[] { (1, 10717, 10718, null), (2, 10719, 10720, null), (4, 10717, 10718, null),
                    (5, 10719, 10720, null) }),
                (1321, 10721, new (uint, uint, uint, uint?)[] { (1, 10726, 10727, null), (2, 10728, 10729, null), (4, 10726, 10727, null),
                    (5, 10728, 10729, null) }),
                (1328, 10848, new (uint, uint, uint, uint?)[] { (1, 10853, 10854, null), (2, 10856, 10857, null), (3, 10858, 10859, null) }),
                (1308, 10610, new (uint, uint, uint, uint?)[] { (1, 10627, 10628, null), (2, 10630, 10631, null), (3, 10633, 10634, null) }),
                (1025, 5675, new (uint, uint, uint, uint?)[]
                {
                    (1, 5688, 7569, null), (2, 5690, 7570, null), (3, 5691, 7572, null), (4, 5692, 7573, null), (5, 5693, 7574, null),
                    (6, 5694, 7575, null), (7, 5695, 7576, null), (8, 5698, 7577, 5699), (9, 5700, 7578, null)
                }),
                (932, 5003, new (uint, uint, uint, uint?)[] { (1, 5020, 7974, null), (2, 5034, 7975, null), (3, 5036, 7976, null) })
            };
            using var harness = WildernessRuntimeTestHarness.Create();
            foreach (var (mission, title, objectives) in expected)
            {
                Assert.AreEqual(title, harness.World.MissionContentDefinitionEntries.AsNoTracking()
                    .Single(entry => entry.MissionId == mission && entry.ContentRevision == PoolsMissionDataV1.Revision)
                    .ClientNameTextId, $"{mission} title");
                var actual = harness.World.MissionObjectiveDefinitionEntries.AsNoTracking()
                    .Where(entry => entry.MissionId == mission && entry.ContentRevision == PoolsMissionDataV1.Revision).ToArray();
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
        }

        /// <summary>
        /// Building Materials, Medicinal Measures, Death Patrol, Looking For Logos?, Mapping The Pools and Bane Investigation
        /// have no requirement (TaRapedia). More Clips and Tags follows
        /// Death Patrol and repeats at once (PlanetTR); The Thirsty Hermit follows both Death Patrol and Medicinal Measures.
        /// </summary>
        [TestMethod]
        public void EachMissionRequiresTheMissionsBeforeIt()
        {
            using var harness = WildernessRuntimeTestHarness.Create();
            var prerequisites = harness.World.MissionPrerequisiteEntries.AsNoTracking()
                .Where(entry => entry.ContentRevision == PoolsMissionDataV1.Revision).ToArray();
            Assert.HasCount(3, prerequisites);
            Assert.IsTrue(prerequisites.All(entry => entry.Kind == MissionPrerequisiteKind.MissionCompleted));
            foreach (var mission in new uint[] { 1314, 1066, 1315, 1308, 1025, 932 })
                Assert.IsFalse(prerequisites.Any(entry => entry.MissionId == mission), $"{mission}");
            CollectionAssert.AreEquivalent(new uint?[] { 1315 },
                prerequisites.Where(entry => entry.MissionId == 1321).Select(entry => entry.RequiredMissionId).ToArray());
            CollectionAssert.AreEquivalent(new uint?[] { 1315, 1066 },
                prerequisites.Where(entry => entry.MissionId == 1328).Select(entry => entry.RequiredMissionId).ToArray());

            var repeats = harness.World.Set<MissionRepeatPolicyEntry>().AsNoTracking()
                .Where(entry => entry.ContentRevision == PoolsMissionDataV1.Revision).ToArray();
            Assert.AreEqual((1321U, Rasa.Missions.Runtime.MissionRepeatKind.Immediate), (repeats.Single().MissionId, repeats.Single().Kind));
        }

        /// <summary>The missions' sources and how far each is trusted: the client 1.0, TaRapedia 0.5, the reconstruction 0.3.</summary>
        [TestMethod]
        public void TheSourcesAreTrustedAsFarAsTheyGo()
        {
            using var harness = WildernessRuntimeTestHarness.Create();
            var evidence = harness.World.MissionEvidenceEntries.AsNoTracking()
                .Where(entry => entry.ContentRevision == PoolsMissionDataV1.Revision).ToArray();
            foreach (var (mission, confidences) in new (uint, (MissionEvidenceSourceKind, double)[])[]
            {
                (1314, new[] { (MissionEvidenceSourceKind.Client, 1.0), (MissionEvidenceSourceKind.Documentation, 0.5),
                    (MissionEvidenceSourceKind.Reconstruction, 0.3) }),
                (1066, new[] { (MissionEvidenceSourceKind.Client, 1.0), (MissionEvidenceSourceKind.Documentation, 0.5),
                    (MissionEvidenceSourceKind.Reconstruction, 0.3) }),
                (1315, new[] { (MissionEvidenceSourceKind.Client, 1.0), (MissionEvidenceSourceKind.Documentation, 0.5),
                    (MissionEvidenceSourceKind.Reconstruction, 0.3) }),
                (1321, new[] { (MissionEvidenceSourceKind.Client, 1.0), (MissionEvidenceSourceKind.Documentation, 0.4),
                    (MissionEvidenceSourceKind.Reconstruction, 0.3) }),
                (1328, new[] { (MissionEvidenceSourceKind.Client, 1.0), (MissionEvidenceSourceKind.Documentation, 0.5),
                    (MissionEvidenceSourceKind.Reconstruction, 0.3) }),
                (1308, new[] { (MissionEvidenceSourceKind.Client, 1.0), (MissionEvidenceSourceKind.Documentation, 0.5),
                    (MissionEvidenceSourceKind.Reconstruction, 0.3) }),
                (1025, new[] { (MissionEvidenceSourceKind.Client, 1.0), (MissionEvidenceSourceKind.Documentation, 0.5),
                    (MissionEvidenceSourceKind.Reconstruction, 0.3) }),
                (932, new[] { (MissionEvidenceSourceKind.Client, 1.0), (MissionEvidenceSourceKind.Documentation, 0.5),
                    (MissionEvidenceSourceKind.Reconstruction, 0.3) })
            })
                CollectionAssert.AreEqual(confidences, evidence.Where(entry => entry.MissionId == mission)
                    .OrderBy(entry => entry.EvidenceId).Select(entry => (entry.SourceKind, entry.Confidence)).ToArray(),
                    $"{mission} evidence");
        }

        [TestMethod]
        public void IndicatorsCarryNoOtherMissionsClientName()
        {
            using var harness = WildernessRuntimeTestHarness.Create();
            var indicators = harness.World.MissionIndicatorEntries.AsNoTracking()
                .Where(entry => entry.ContentRevision == PoolsMissionDataV1.Revision).ToArray();
            Assert.HasCount(Indicators, indicators);
            foreach (var row in indicators)
                Assert.IsTrue(row.IndicatorId > MissionIndicator.UnnamedFrom,
                    $"mission {row.MissionId} objective {row.ObjectiveId} indicator {row.IndicatorId}");
        }

        /// <summary>
        /// Pools_snake_pit_contacts takes out its three missions and Timlin, Allen and Feldman; Death Patrol's missions stay.
        /// </summary>
        [TestMethod]
        public void TheSnakePitContactsRollBackWithTheirMigration()
        {
            using var harness = WildernessRuntimeTestHarness.Create();
            var world = harness.World;
            bool Has(uint mission) => world.MissionContentDefinitionEntries.AsNoTracking()
                .Any(entry => entry.MissionId == mission && entry.ContentRevision == PoolsMissionDataV1.Revision);
            int Rows(string table) => world.Database.SqlQueryRaw<int>(
                $"SELECT COUNT(*) AS Value FROM {table} WHERE id IN ({PoolsSnakePitContactsV1.Timlin}, {PoolsSnakePitContactsV1.Allen}, " +
                $"{PoolsSnakePitContactsV1.Feldman})").AsEnumerable().Single();
            int Scenes() => world.Database.SqlQueryRaw<int>(
                "SELECT COUNT(*) AS Value FROM mission_scene_binding WHERE mission_id IN (1308, 1025, 932)").AsEnumerable().Single();

            Assert.IsTrue(Has(1308) && Has(1025) && Has(932));
            Assert.AreEqual((3, 3, 3, 18), (Rows("creature"), Rows("spawnpool"), Rows("npc_package"), Rows("creature_appearance")));
            Assert.AreEqual(3, Scenes(), "one scene each; 1308's holds only its fact objective");

            world.GetService<IMigrator>().Migrate(DeathPatrol);
            Assert.IsFalse(Has(1308) || Has(1025) || Has(932));
            Assert.AreEqual((0, 0, 0, 0), (Rows("creature"), Rows("spawnpool"), Rows("npc_package"), Rows("creature_appearance")));
            Assert.AreEqual(0, Scenes());
            Assert.IsFalse(world.MissionEvidenceEntries.Any(entry => new uint[] { 1308, 1025, 932 }.Contains(entry.MissionId)));
            Assert.IsTrue(Has(1315) && Has(1321) && Has(1328));

            world.GetService<IMigrator>().Migrate(Contacts);
            Assert.IsTrue(Has(1308) && Has(1025) && Has(932));
        }

        /// <summary>
        /// Pools_death_patrol takes out its three missions and puts Snake back at his Plateau-PR place; the Snake Pit's two
        /// missions stay.
        /// </summary>
        [TestMethod]
        public void DeathPatrolRollsBackWithItsMigrationAndSnakeGoesBack()
        {
            using var harness = WildernessRuntimeTestHarness.Create();
            var world = harness.World;
            bool Has(uint mission) => world.MissionContentDefinitionEntries.AsNoTracking()
                .Any(entry => entry.MissionId == mission && entry.ContentRevision == PoolsMissionDataV1.Revision);
            (double, double, double) Snake()
            {
                var row = world.SpawnPoolEntries.AsNoTracking().Single(entry => entry.Id == PlateauSnakePitV1.Snake);
                return (System.Math.Round(row.PosX, 2), System.Math.Round(row.PosY, 2), System.Math.Round(row.PosZ, 2));
            }

            Assert.IsTrue(Has(1315) && Has(1321) && Has(1328));
            Assert.AreEqual(PoolsWashingtonPlaceV1.At, Snake());

            world.GetService<IMigrator>().Migrate(SnakePit);
            Assert.IsFalse(Has(1315) || Has(1321) || Has(1328));
            Assert.IsFalse(world.Set<MissionRepeatPolicyEntry>().AsNoTracking().Any(entry => entry.ContentRevision == PoolsMissionDataV1.Revision));
            Assert.AreEqual(PlateauSnakePitV1.SnakeAt, Snake());
            Assert.IsTrue(Has(1314) && Has(1066));

            world.GetService<IMigrator>().Migrate(DeathPatrol);
            Assert.IsTrue(Has(1315) && Has(1321) && Has(1328));
            Assert.AreEqual(PoolsWashingtonPlaceV1.At, Snake());
        }

        /// <summary>Pools_snake_pit takes out its missions and Riggins and Hester; Retreads to Retreads stays.</summary>
        [TestMethod]
        public void TheSnakePitRollsBackWithItsMigration()
        {
            using var harness = WildernessRuntimeTestHarness.Create();
            var world = harness.World;
            bool Has(uint mission) => world.MissionContentDefinitionEntries.AsNoTracking()
                .Any(entry => entry.MissionId == mission && entry.ContentRevision == PoolsMissionDataV1.Revision);
            int Rows(string table) => world.Database.SqlQueryRaw<int>(
                $"SELECT COUNT(*) AS Value FROM {table} WHERE id IN ({PoolsSnakePitNpcsV1.Riggins}, {PoolsSnakePitNpcsV1.Hester})").AsEnumerable().Single();

            Assert.IsTrue(Has(PoolsBuildingMaterialsV1.MissionId) && Has(PoolsMedicinalMeasuresV1.MissionId));
            Assert.AreEqual((2, 2, 2, 12), (Rows("creature"), Rows("spawnpool"), Rows("npc_package"), Rows("creature_appearance")));

            world.GetService<IMigrator>().Migrate(Before);
            Assert.IsFalse(world.MissionContentDefinitionEntries.Any(entry => entry.ContentRevision == PoolsMissionDataV1.Revision));
            Assert.IsFalse(world.MissionRewardItemEntries.Any(entry => entry.ContentRevision == PoolsMissionDataV1.Revision));
            Assert.IsFalse(world.MissionEvidenceEntries.Any(entry => entry.ContentRevision == PoolsMissionDataV1.Revision));
            Assert.IsFalse(world.MissionScenarioEntries.Any(entry => entry.ContentRevision == PoolsMissionDataV1.Revision));
            Assert.AreEqual((0, 0, 0, 0), (Rows("creature"), Rows("spawnpool"), Rows("npc_package"), Rows("creature_appearance")));
            Assert.IsTrue(world.MissionContentDefinitionEntries.Any(entry => entry.MissionId == PlateauRetreadsToRetreadsV1.MissionId &&
                entry.ContentRevision == PlateauMissionDataV1.Revision));

            world.GetService<IMigrator>().Migrate(SnakePit);
            Assert.IsTrue(Has(PoolsBuildingMaterialsV1.MissionId) && Has(PoolsMedicinalMeasuresV1.MissionId));
        }
    }
}
