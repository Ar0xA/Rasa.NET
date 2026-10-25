using System.Collections.Generic;
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
    /// Allen and Lieutenant Feldman (Pools_snake_pit_contacts); Sabotage the Tower (937), Bane Jamming (938) and
    /// Elimination (941), with the western fort's Eloh obelisk and a Pools Linker (Pools_bane_chain); the Retread chain, A
    /// Cult Divided (560), Testing the Pools (561), One Man's Trash (562), Retread Planning (563) and Retread Planning Part II
    /// (1330), with McKormic, Venma, Buckley and Rickert at the Retread Camp (Pools_retread_chain); the supply chain, The
    /// Supply Master (1322), Eastern Listening Post (1323), Smash and Grab (1324) and Spoils of War (1326), with Nakrinx's
    /// patrol and Lieutenant Chester's package (Pools_supply_chain); the spy chain, Spy Networking (1331), Poison Control
    /// (1368) and Taking the Poison (1590), with Corporal Sheen's package and her stand-in (Pools_spy_chain); the Lamna
    /// Armory's Bane Battle Plans (896), Operation Overlord (898) and Blow Them All Up (903), with its givers, key bosses
    /// and Overlord (Pools_lamna_armory); the Retread Caves' Stick Your Neck Out (1329) and Mox Clearing chain, Mox
    /// Clearing (1132), Mox Shouldn't Smoke (1135), A Mox On Both Our Houses (1133), Deadly Moxins, er-Toxins (1134),
    /// Miasma Mutations (1131), Miasma Testing (1136), Total Slaughter (1138) and The Mad Bomber (856), with the caves'
    /// Retreads, mission creatures and pools (Pools_retread_caves). Amee Corman's Retreads to Retreads (1751) is on the
    /// Plateau's revision (PlateauMissionTests): it follows Weapons Trafficking.
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
            PoolsMappingThePoolsV1.MissionId, PoolsBaneInvestigationV1.MissionId, PoolsSabotageTheTowerV1.MissionId,
            PoolsBaneJammingV1.MissionId, PoolsEliminationV1.MissionId, PoolsCultDividedV1.MissionId,
            PoolsTestingThePoolsV1.MissionId, PoolsOneMansTrashV1.MissionId, PoolsRetreadPlanningV1.MissionId,
            PoolsRetreadPlanningPartTwoV1.MissionId, PoolsSupplyMasterV1.MissionId, PoolsEasternListeningPostV1.MissionId,
            PoolsSmashAndGrabV1.MissionId, PoolsSpoilsOfWarV1.MissionId, PoolsSpyNetworkingV1.MissionId,
            PoolsPoisonControlV1.MissionId, PoolsTakingThePoisonV1.MissionId, PoolsBaneBattlePlansV1.MissionId,
            PoolsOperationOverlordV1.MissionId, PoolsBlowThemAllUpV1.MissionId, PoolsStickYourNeckOutV1.MissionId,
            PoolsMoxClearingV1.MissionId, PoolsMoxShouldntSmokeV1.MissionId, PoolsMoxOnBothOurHousesV1.MissionId,
            PoolsDeadlyMoxinsV1.MissionId, PoolsMiasmaMutationsV1.MissionId, PoolsMiasmaTestingV1.MissionId,
            PoolsTotalSlaughterV1.MissionId, PoolsMadBomberV1.MissionId
        };

        /// <summary>
        /// Medicinal Measures' one, on the Mawflower field; The Thirsty Hermit's three (Hester, the cabinet, the Hermit);
        /// Looking For Logos?'s three (Suresh, the Refinery's door, Suresh); Mapping The Pools' eight (Timlin, the pack, the
        /// five beacons, Timlin); Bane Investigation's three (the terminal twice, Feldman); Sabotage the Tower's two (the fort,
        /// the obelisk); Bane Jamming's seven (the obelisk, the six jammers); Elimination's one (Prysiam); A Cult Divided's
        /// one (McKormic); Testing the Pools' three (the sample spots); One Man's Trash's two (the crates); Retread Planning's
        /// four (the camp three times, the Hermit); Part II's one (Amee); The Supply Master's two (the beat's start, Riggins);
        /// Eastern Listening Post's one (the crate); Smash and Grab's six (the three stores, the three servers); Spoils of
        /// War's one (Snake); Spy Networking's one (the console); Poison Control's and Taking the Poison's three each (the
        /// canister consoles). The Lamna Armory's three and the Retread Caves' nine have none (instance). Building Materials, Death Patrol and More Clips and
        /// Tags have none (their creatures and bodies are all over the Pools).
        /// </summary>
        internal const int Indicators = 56;

        private const string Before = "20270401000000_Plateau_retreads_to_retreads";
        private const string SnakePit = "20270402000000_Pools_snake_pit";
        private const string DeathPatrol = "20270403000000_Pools_death_patrol";
        private const string Contacts = "20270404000000_Pools_snake_pit_contacts";
        private const string BaneChain = "20270405000000_Pools_bane_chain";
        private const string RetreadChain = "20270406000000_Pools_retread_chain";
        private const string SupplyChain = "20270407000000_Pools_supply_chain";
        private const string SpyChain = "20270408000000_Pools_spy_chain";
        private const string LamnaArmory = "20270409000000_Pools_lamna_armory";
        private const string RetreadCaves = "20270410000000_Pools_retread_caves";

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
                (PoolsBaneInvestigationV1.MissionId, PoolsSnakePitContactsV1.Feldman, PoolsSnakePitContactsV1.Feldman, 35),
                (PoolsSabotageTheTowerV1.MissionId, PoolsSnakePitContactsV1.Feldman, PoolsSnakePitContactsV1.Feldman, 35),
                (PoolsBaneJammingV1.MissionId, PoolsSnakePitContactsV1.Feldman, PoolsSnakePitContactsV1.Feldman, 35),
                (PoolsEliminationV1.MissionId, PlateauSnakePitV1.Snake, PlateauSnakePitV1.Snake, 35),
                (PoolsCultDividedV1.MissionId, PlateauBaileyNpcsV1.Hermit, PoolsRetreadCampNpcsV1.McKormic, 33),
                (PoolsTestingThePoolsV1.MissionId, PoolsRetreadCampNpcsV1.Venma, PoolsRetreadCampNpcsV1.Venma, 33),
                (PoolsOneMansTrashV1.MissionId, PoolsRetreadCampNpcsV1.Buckley, PoolsRetreadCampNpcsV1.Buckley, 33),
                (PoolsRetreadPlanningV1.MissionId, null, PlateauBaileyNpcsV1.Hermit, 33),
                (PoolsRetreadPlanningPartTwoV1.MissionId, PlateauBaileyNpcsV1.Hermit, 510195, 33),
                (PoolsSupplyMasterV1.MissionId, PoolsSnakePitNpcsV1.Riggins, PoolsSnakePitNpcsV1.Riggins, 33),
                (PoolsEasternListeningPostV1.MissionId, PlateauSnakePitV1.Snake, 510198, 35),
                (PoolsSmashAndGrabV1.MissionId, 510198, 510198, 35),
                (PoolsSpoilsOfWarV1.MissionId, 510198, PlateauSnakePitV1.Snake, 35),
                (PoolsSpyNetworkingV1.MissionId, 510195, null, 32),
                (PoolsPoisonControlV1.MissionId, 510195, 510195, 32),
                (PoolsTakingThePoisonV1.MissionId, 510197, 510197, 33),
                (PoolsBaneBattlePlansV1.MissionId, PoolsLamnaArmoryNpcsV1.Arimoro, PoolsLamnaArmoryNpcsV1.Arimoro, 35),
                (PoolsOperationOverlordV1.MissionId, PoolsLamnaArmoryNpcsV1.Bromfield, PoolsLamnaArmoryNpcsV1.Bromfield, 35),
                (PoolsBlowThemAllUpV1.MissionId, PoolsLamnaArmoryNpcsV1.Herring, PoolsLamnaArmoryNpcsV1.Herring, 35),
                (PoolsStickYourNeckOutV1.MissionId, 510195, PoolsRetreadCavesNpcsV1.Kaethi, 33),
                (PoolsMoxClearingV1.MissionId, PoolsRetreadCavesNpcsV1.Ellen, PoolsRetreadCavesNpcsV1.Ellen, 35),
                (PoolsMoxShouldntSmokeV1.MissionId, PoolsRetreadCavesNpcsV1.Ellen, PoolsRetreadCavesNpcsV1.Ellen, 35),
                (PoolsMoxOnBothOurHousesV1.MissionId, PoolsRetreadCavesNpcsV1.Donius, PoolsRetreadCavesNpcsV1.Ellen, 35),
                (PoolsDeadlyMoxinsV1.MissionId, PoolsRetreadCavesNpcsV1.Donius, 510195, 35),
                (PoolsMiasmaMutationsV1.MissionId, PoolsRetreadCavesNpcsV1.Donius, PoolsRetreadCavesNpcsV1.Donius, 35),
                (PoolsMiasmaTestingV1.MissionId, PoolsRetreadCavesNpcsV1.Donius, PoolsRetreadCavesNpcsV1.Miles, 35),
                (PoolsTotalSlaughterV1.MissionId, PoolsRetreadCavesNpcsV1.Miles, PoolsRetreadCavesNpcsV1.Ellen, 35),
                (PoolsMadBomberV1.MissionId, PoolsRetreadCavesNpcsV1.Ellen, PoolsRetreadCavesNpcsV1.Ellen, 35)
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
            // Riggins, Hester, Timlin and Feldman stand at the Snake Pit, Allen in the field, McKormic, Venma, Buckley and
            // Rickert at the Retread Camp, on Valverde Pools, with their names, level and packages.
            foreach (var (npc, name, package) in new (uint, uint, uint)[]
            {
                (650200, 9385, 650200), (650201, 8865, 1129), (650202, 4385, 343), (650203, 4387, 650203), (650204, 4376, 650204),
                (650206, 4367, 326), (650207, 4368, 327), (650208, 4369, 328), (650209, 4374, 333)
            })
            {
                Assert.AreEqual(1304U, harness.World.SpawnPoolEntries.AsNoTracking().Single(row => row.Id == npc).MapContextId, $"{npc} map");
                var creature = harness.World.CreatureEntries.AsNoTracking().Single(row => row.Id == npc);
                Assert.AreEqual((name, 40U), (creature.NameId, creature.Level), $"{npc} name and level");
                Assert.AreEqual(package, harness.World.NpcPackageEntries.AsNoTracking().Single(row => row.Id == npc).PackageId, $"{npc} package");
            }
            // Nakrinx (level 33, neutral, no attack, package 1522) and his bodyguards (Thrax Soldier, level 30) on one
            // pool of the Pools, on a beat of 28 steps; Chester has a package.
            var nakrinx = harness.World.CreatureEntries.AsNoTracking().Single(row => row.Id == 650210);
            Assert.AreEqual((9403U, 33U, 3U, 0U, 11320U), (nakrinx.NameId, nakrinx.Level, nakrinx.Faction, nakrinx.Action1, nakrinx.ClassId), "Nakrinx");
            Assert.AreEqual(1522U, harness.World.NpcPackageEntries.AsNoTracking().Single(row => row.Id == 650210).PackageId);
            var bodyguard = harness.World.CreatureEntries.AsNoTracking().Single(row => row.Id == 650211);
            Assert.AreEqual((237U, 30U, 20757U), (bodyguard.NameId, bodyguard.Level, bodyguard.ClassId), "a bodyguard");
            Assert.IsFalse(harness.World.NpcPackageEntries.AsNoTracking().Any(row => row.Id == 650211), "the bodyguards do not talk");
            var pool = harness.World.SpawnPoolEntries.AsNoTracking().Single(row => row.Id == 650210);
            Assert.AreEqual((1304U, 650210U, (byte)1, 650211U, (byte)4), (pool.MapContextId, pool.Creature1Id, pool.Creature1MaxCount,
                pool.Creature2Id, pool.Creature2MaxCount), "Nakrinx's pool");
            Assert.AreEqual(28, harness.World.Database.SqlQueryRaw<int>(
                "SELECT COUNT(*) AS Value FROM spawnpool_patrol WHERE pool_id = 650210").AsEnumerable().Single(), "the beat");
            Assert.AreEqual(510198U, harness.World.NpcPackageEntries.AsNoTracking().Single(row => row.Id == 510198).PackageId, "Chester");
            // Sheen has her own package; her stand-in (a copy of her, no spawn pool) carries her client package 1524.
            Assert.AreEqual(510197U, harness.World.NpcPackageEntries.AsNoTracking().Single(row => row.Id == 510197).PackageId, "Sheen");
            var standIn = harness.World.CreatureEntries.AsNoTracking().Single(row => row.Id == 650212);
            var sheen = harness.World.CreatureEntries.AsNoTracking().Single(row => row.Id == 510197);
            Assert.AreEqual((sheen.NameId, sheen.ClassId, sheen.Level), (standIn.NameId, standIn.ClassId, standIn.Level), "Sheen's stand-in");
            Assert.AreEqual(1524U, harness.World.NpcPackageEntries.AsNoTracking().Single(row => row.Id == 650212).PackageId);
            Assert.IsFalse(harness.World.SpawnPoolEntries.AsNoTracking().Any(row => row.Id == 650212), "only her mission's scene sets her down");
            // The Lamna Armory: the givers and the key bosses in pools on its map; Vanduahl and his Kael in no pool.
            foreach (var (id, name) in new[]
                {
                    (PoolsLamnaArmoryNpcsV1.Arimoro, PoolsLamnaArmoryNpcsV1.ArimoroName), (PoolsLamnaArmoryNpcsV1.Bromfield, PoolsLamnaArmoryNpcsV1.BromfieldName),
                    (PoolsLamnaArmoryNpcsV1.Herring, PoolsLamnaArmoryNpcsV1.HerringName), (PoolsLamnaArmoryNpcsV1.Gaite, PoolsLamnaArmoryNpcsV1.GaiteName),
                    (PoolsLamnaArmoryNpcsV1.Kwel, PoolsLamnaArmoryNpcsV1.KwelName), (PoolsLamnaArmoryNpcsV1.Fearce, PoolsLamnaArmoryNpcsV1.FearceName),
                })
            {
                Assert.AreEqual(name, harness.World.CreatureEntries.AsNoTracking().Single(row => row.Id == id).NameId, $"{id}");
                Assert.AreEqual(PoolsLamnaArmoryNpcsV1.MapContextId,
                    harness.World.SpawnPoolEntries.AsNoTracking().Single(row => row.Id == id).MapContextId, $"{id} in the Armory");
            }
            foreach (var id in new[] { PoolsLamnaArmoryNpcsV1.Vanduahl, PoolsLamnaArmoryNpcsV1.Kael })
                Assert.IsFalse(harness.World.SpawnPoolEntries.AsNoTracking().Any(row => row.Id == id), $"{id}: only the switch sets him down");
            // The Retread Caves: the four Retreads (level 36, friendly) with their names and packages in pools on the caves'
            // map; the Mox and mutated miasma pools there; the mission creatures in no pool.
            foreach (var (npc, name, package) in new (uint, uint, uint)[]
            {
                (650221, 7083, 650221), (650222, 4377, 336), (650223, 7078, 849), (650224, 7080, 851)
            })
            {
                Assert.AreEqual(1694U, harness.World.SpawnPoolEntries.AsNoTracking().Single(row => row.Id == npc).MapContextId, $"{npc} map");
                var creature = harness.World.CreatureEntries.AsNoTracking().Single(row => row.Id == npc);
                Assert.AreEqual((name, 36U, 1U), (creature.NameId, creature.Level, creature.Faction), $"{npc} name, level and faction");
                Assert.AreEqual(package, harness.World.NpcPackageEntries.AsNoTracking().Single(row => row.Id == npc).PackageId, $"{npc} package");
            }
            foreach (var (pools, creature) in new[] { (Enumerable.Range(650230, 5), 650230U), (Enumerable.Range(650235, 4), 650226U) })
                foreach (var id in pools)
                {
                    var row = harness.World.SpawnPoolEntries.AsNoTracking().Single(entry => entry.Id == id);
                    Assert.AreEqual((1694U, creature, (byte)3, (byte)3), (row.MapContextId, row.Creature1Id, row.Creature1MinCount,
                        row.Creature1MaxCount), $"pool {id}");
                }
            foreach (var (id, name, level, faction) in new (uint, uint, uint, uint)[]
            {
                (650225, 9028, 36, 0), (650226, 9037, 33, 0), (650227, 9038, 33, 1), (650228, 7913, 34, 0), (650229, 7085, 36, 0),
                (650230, 8797, 33, 0)
            })
            {
                var creature = harness.World.CreatureEntries.AsNoTracking().Single(row => row.Id == id);
                Assert.AreEqual((name, level, faction), (creature.NameId, creature.Level, creature.Faction), $"{id}");
            }
            foreach (var id in new uint[] { 650225, 650226, 650227, 650228, 650229 })
                Assert.IsFalse(harness.World.SpawnPoolEntries.AsNoTracking().Any(row => row.Id == id), $"{id}: only its scene sets it down");

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
                (932, 5003, new (uint, uint, uint, uint?)[] { (1, 5020, 7974, null), (2, 5034, 7975, null), (3, 5036, 7976, null) }),
                (937, 5046, new (uint, uint, uint, uint?)[] { (1, 5050, 7606, 5059), (2, 5051, 7607, 5060) }),
                (938, 5066, new (uint, uint, uint, uint?)[]
                {
                    (1, 5093, 7978, 5097), (2, 5096, 7979, null), (8, 5263, 7980, null), (9, 5264, 7981, null), (10, 5265, 7982, null),
                    (11, 5266, 7983, null), (12, 5267, 7984, null)
                }),
                (941, 5115, new (uint, uint, uint, uint?)[] { (1, 5130, 7580, 5131) }),
                (560, 1623, new (uint, uint, uint, uint?)[] { (2, 9341, 9342, null) }),
                (561, 1634, new (uint, uint, uint, uint?)[] { (1, 1642, 8054, null), (3, 1643, 8055, null), (4, 1644, 8056, null),
                    (5, 1645, 8057, null) }),
                (562, 1638, new (uint, uint, uint, uint?)[] { (1, 1651, 7613, null), (2, 1652, 7614, null) }),
                (563, 1653, new (uint, uint, uint, uint?)[]
                {
                    (3, 1666, 7994, null), (4, 1668, 7995, null), (5, 1670, 7996, null), (6, 1672, 7997, null), (7, 1674, 7998, null),
                    (10, 1678, 8001, null), (11, 1680, 8002, null), (12, 1682, 8003, null), (13, 1684, 8004, null), (14, 1686, 8005, null),
                    (15, 10869, 10870, 10871), (16, 10872, 10873, 10874), (17, 10875, 10876, 10877),
                    (19, 10884, 10885, null), (20, 10887, 10888, null), (21, 10890, 10891, null), (22, 10893, 10894, null),
                    (23, 10896, 10897, null), (24, 10881, 10882, null),
                    // 25 and 26: the server's own hidden gate, on 24's texts.
                    (25, 10881, 10882, null), (26, 10881, 10882, null)
                }),
                (1330, 10899, new (uint, uint, uint, uint?)[] { (1, 10904, 10905, null) }),
                // 1322's 3: the server's own kill count, on 1's texts, its count "Thrax Body Guards Killed" (1964).
                (1322, 10768, new (uint, uint, uint, uint?)[] { (1, 10773, 10774, null), (2, 10776, 10777, null), (3, 10773, 10774, 1964) }),
                (1323, 10778, new (uint, uint, uint, uint?)[] { (1, 10783, 10784, null) }),
                (1324, 10785, new (uint, uint, uint, uint?)[]
                {
                    (1, 10812, 10813, null), (2, 10814, 10815, null), (3, 10816, 10817, null), (4, 10818, 10819, 10820),
                    (5, 10821, 10822, 10823), (6, 10824, 10825, 10826)
                }),
                (1326, 10832, new (uint, uint, uint, uint?)[] { (1, 10837, 10838, null) }),
                (1331, 10907, new (uint, uint, uint, uint?)[] { (25, 11615, 11616, 11617) }),
                (1368, 11283, new (uint, uint, uint, uint?)[] { (1, 15000, 15001, null), (3, 15014, 15015, null), (5, 15026, 15027, null) }),
                (1590, 15038, new (uint, uint, uint, uint?)[] { (1, 15043, 15044, null), (3, 15055, 15056, null), (5, 15067, 15068, null) }),
                (896, 4716, new (uint, uint, uint, uint?)[]
                {
                    (2, 4720, 7339, null), (3, 5961, 7340, null), (4, 5962, 7341, null), (5, 5963, 7342, null), (6, 5963, 7342, null)
                }),
                (898, 4743, new (uint, uint, uint, uint?)[]
                {
                    (2, 6049, 7334, null), (3, 6050, 7335, null), (4, 6051, 7336, null), (5, 6052, 7337, null),
                    (6, 6052, 7337, null), (7, 6052, 7337, null), (8, 6052, 7337, null), (9, 6052, 7337, null)
                }),
                (903, 4782, new (uint, uint, uint, uint?)[] { (1, 4786, 7344, 4787) }),
                (1329, 10861, new (uint, uint, uint, uint?)[] { (1, 10866, 10867, null) }),
                (1132, 8013, new (uint, uint, uint, uint?)[] { (2, 8018, 8019, 8020) }),
                (1135, 8043, new (uint, uint, uint, uint?)[] { (1, 8051, 8052, null), (2, 8048, 8049, null) }),
                (1133, 8023, new (uint, uint, uint, uint?)[] { (1, 8028, 8029, null), (2, 8030, 8031, 8032) }),
                // 1134's 3: the server's own count of the last Mox, on 2's texts.
                (1134, 8033, new (uint, uint, uint, uint?)[] { (1, 8038, 8039, 8040), (2, 8041, 8042, null), (3, 8041, 8042, null) }),
                (1131, 8006, new (uint, uint, uint, uint?)[] { (1, 8011, 8012, null) }),
                (1136, 8064, new (uint, uint, uint, uint?)[]
                {
                    (1, 8100, 8101, null), (2, 8102, 8103, null), (3, 8104, 8105, null), (4, 8106, 8107, null), (5, 8108, 8109, null),
                    (6, 8110, 8111, null), (7, 8112, 8113, null), (8, 8114, 8115, null), (9, 8117, 8118, null), (10, 8121, 8122, null),
                    (11, 8124, 8125, null)
                }),
                // 1138's 3-5: the server's own wave counts, on 2's texts.
                (1138, 8127, new (uint, uint, uint, uint?)[]
                {
                    (1, 8185, 8186, null), (2, 8187, 8188, null), (3, 8187, 8188, null), (4, 8187, 8188, null), (5, 8187, 8188, null)
                }),
                (856, 4441, new (uint, uint, uint, uint?)[] { (1, 4445, 7359, null) })
            };
            // 937's objective 1 shows its second count too: counter 1 "Bane Equipment Locker Destroyed".
            var secondCounters = new Dictionary<(uint, uint), uint> { [(937, 1)] = 5058 };
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
                    Assert.AreEqual(secondCounters.TryGetValue((mission, objective), out var second) ? second : null,
                        row.ClientCounter1TextId, $"{mission}.{objective} counter1");
                    Assert.IsNull(row.ClientCounter2TextId, $"{mission}.{objective} counter2");
                }
            }
        }

        /// <summary>
        /// Building Materials, Medicinal Measures, Death Patrol, Looking For Logos?, Mapping The Pools and Bane Investigation
        /// have no requirement (TaRapedia). More Clips and Tags follows
        /// Death Patrol and repeats at once (PlanetTR); The Thirsty Hermit follows both Death Patrol and Medicinal Measures;
        /// Sabotage the Tower follows Bane Investigation, and Bane Jamming and Elimination follow it; A Cult Divided follows The
        /// Thirsty Hermit, Testing the Pools and One Man's Trash follow it, Retread Planning follows One Man's Trash, and Part
        /// II follows Retread Planning; The Supply Master follows Death Patrol, and Eastern Listening Post, Smash and Grab and
        /// Spoils of War each the one before; Spy Networking follows Part II, and Poison Control and Taking the Poison follow
        /// it; Stick Your Neck Out follows Retread Planning, and the Retread Caves' chain runs Mox Clearing (no requirement),
        /// Mox Shouldn't Smoke, A Mox On Both Our Houses, Deadly Moxins, Miasma Mutations, Miasma Testing, Total Slaughter,
        /// The Mad Bomber, each the one before (TaRapedia).
        /// </summary>
        [TestMethod]
        public void EachMissionRequiresTheMissionsBeforeIt()
        {
            using var harness = WildernessRuntimeTestHarness.Create();
            var prerequisites = harness.World.MissionPrerequisiteEntries.AsNoTracking()
                .Where(entry => entry.ContentRevision == PoolsMissionDataV1.Revision).ToArray();
            Assert.HasCount(26, prerequisites);
            Assert.IsTrue(prerequisites.All(entry => entry.Kind == MissionPrerequisiteKind.MissionCompleted));
            foreach (var mission in new uint[] { 1314, 1066, 1315, 1308, 1025, 932, 896, 898, 903, 1132 })
                Assert.IsFalse(prerequisites.Any(entry => entry.MissionId == mission), $"{mission}");
            CollectionAssert.AreEquivalent(new uint?[] { 1315 },
                prerequisites.Where(entry => entry.MissionId == 1321).Select(entry => entry.RequiredMissionId).ToArray());
            CollectionAssert.AreEquivalent(new uint?[] { 1315, 1066 },
                prerequisites.Where(entry => entry.MissionId == 1328).Select(entry => entry.RequiredMissionId).ToArray());
            foreach (var (mission, required) in new (uint, uint)[]
            {
                (937, 932), (938, 937), (941, 937), (560, 1328), (561, 560), (562, 560), (563, 562), (1330, 563),
                (1322, 1315), (1323, 1322), (1324, 1323), (1326, 1324), (1331, 1330), (1368, 1331), (1590, 1331),
                (1329, 563), (1135, 1132), (1133, 1135), (1134, 1133), (1131, 1134), (1136, 1131), (1138, 1136), (856, 1138)
            })
                CollectionAssert.AreEquivalent(new uint?[] { required },
                    prerequisites.Where(entry => entry.MissionId == mission).Select(entry => entry.RequiredMissionId).ToArray(), $"{mission}");

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
                    (MissionEvidenceSourceKind.Reconstruction, 0.3) }),
                (937, new[] { (MissionEvidenceSourceKind.Client, 1.0), (MissionEvidenceSourceKind.Documentation, 0.5),
                    (MissionEvidenceSourceKind.Reconstruction, 0.3) }),
                (938, new[] { (MissionEvidenceSourceKind.Client, 1.0), (MissionEvidenceSourceKind.Documentation, 0.5),
                    (MissionEvidenceSourceKind.Reconstruction, 0.3) }),
                (941, new[] { (MissionEvidenceSourceKind.Client, 1.0), (MissionEvidenceSourceKind.Documentation, 0.5),
                    (MissionEvidenceSourceKind.Reconstruction, 0.3) }),
                (560, new[] { (MissionEvidenceSourceKind.Client, 1.0), (MissionEvidenceSourceKind.Documentation, 0.5),
                    (MissionEvidenceSourceKind.Reconstruction, 0.3) }),
                (561, new[] { (MissionEvidenceSourceKind.Client, 1.0), (MissionEvidenceSourceKind.Documentation, 0.5),
                    (MissionEvidenceSourceKind.Reconstruction, 0.3) }),
                (562, new[] { (MissionEvidenceSourceKind.Client, 1.0), (MissionEvidenceSourceKind.Documentation, 0.5),
                    (MissionEvidenceSourceKind.Reconstruction, 0.3) }),
                (563, new[] { (MissionEvidenceSourceKind.Client, 1.0), (MissionEvidenceSourceKind.Documentation, 0.5),
                    (MissionEvidenceSourceKind.Reconstruction, 0.3) }),
                (1330, new[] { (MissionEvidenceSourceKind.Client, 1.0), (MissionEvidenceSourceKind.Documentation, 0.5),
                    (MissionEvidenceSourceKind.Reconstruction, 0.3) }),
                (1322, new[] { (MissionEvidenceSourceKind.Client, 1.0), (MissionEvidenceSourceKind.Documentation, 0.5),
                    (MissionEvidenceSourceKind.Reconstruction, 0.3) }),
                (1323, new[] { (MissionEvidenceSourceKind.Client, 1.0), (MissionEvidenceSourceKind.Documentation, 0.5),
                    (MissionEvidenceSourceKind.Reconstruction, 0.3) }),
                (1324, new[] { (MissionEvidenceSourceKind.Client, 1.0), (MissionEvidenceSourceKind.Documentation, 0.5),
                    (MissionEvidenceSourceKind.Reconstruction, 0.3) }),
                (1326, new[] { (MissionEvidenceSourceKind.Client, 1.0), (MissionEvidenceSourceKind.Documentation, 0.5),
                    (MissionEvidenceSourceKind.Reconstruction, 0.3) }),
                (1331, new[] { (MissionEvidenceSourceKind.Client, 1.0), (MissionEvidenceSourceKind.Documentation, 0.5),
                    (MissionEvidenceSourceKind.Reconstruction, 0.3) }),
                (1368, new[] { (MissionEvidenceSourceKind.Client, 1.0), (MissionEvidenceSourceKind.Documentation, 0.5),
                    (MissionEvidenceSourceKind.Reconstruction, 0.3) }),
                (1590, new[] { (MissionEvidenceSourceKind.Client, 1.0), (MissionEvidenceSourceKind.Documentation, 0.5),
                    (MissionEvidenceSourceKind.Reconstruction, 0.3) }),
                (896, new[] { (MissionEvidenceSourceKind.Client, 1.0), (MissionEvidenceSourceKind.Documentation, 0.5),
                    (MissionEvidenceSourceKind.Reconstruction, 0.3) }),
                (898, new[] { (MissionEvidenceSourceKind.Client, 1.0), (MissionEvidenceSourceKind.Documentation, 0.5),
                    (MissionEvidenceSourceKind.Reconstruction, 0.3) }),
                (903, new[] { (MissionEvidenceSourceKind.Client, 1.0), (MissionEvidenceSourceKind.Documentation, 0.5),
                    (MissionEvidenceSourceKind.Reconstruction, 0.3) })
            }.Concat(new uint[] { 1329, 1132, 1135, 1133, 1134, 1131, 1136, 1138, 856 }.Select(mission => (mission, new[]
            {
                (MissionEvidenceSourceKind.Client, 1.0), (MissionEvidenceSourceKind.Documentation, 0.5), (MissionEvidenceSourceKind.Reconstruction, 0.3)
            }))))
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
        /// Pools_retread_caves takes out its nine missions, the four Retreads, the mission creatures, the Mox and mutated
        /// miasma pools and the Mad Bomber's pistol; the caves' older pools, Amee and Retread Planning stay.
        /// </summary>
        [TestMethod]
        public void TheRetreadCavesRollBackWithTheirMigration()
        {
            using var harness = WildernessRuntimeTestHarness.Create();
            var world = harness.World;
            var missions = new uint[] { 1329, 1132, 1135, 1133, 1134, 1131, 1136, 1138, 856 };
            bool Has(uint mission) => world.MissionContentDefinitionEntries.AsNoTracking()
                .Any(entry => entry.MissionId == mission && entry.ContentRevision == PoolsMissionDataV1.Revision);
            int Count(string sql) => world.Database.SqlQueryRaw<int>(sql).AsEnumerable().Single();
            (int, int, int, int, int, int) All() => (
                Count("SELECT COUNT(*) AS Value FROM creature WHERE id BETWEEN 650221 AND 650230"),
                Count("SELECT COUNT(*) AS Value FROM spawnpool WHERE id BETWEEN 650221 AND 650238"),
                Count("SELECT COUNT(*) AS Value FROM npc_package WHERE id BETWEEN 650221 AND 650230"),
                Count("SELECT COUNT(*) AS Value FROM creature_stat WHERE id BETWEEN 650221 AND 650230"),
                Count("SELECT COUNT(*) AS Value FROM creature_action WHERE id = 650040"),
                Count("SELECT COUNT(*) AS Value FROM mission_scene_binding WHERE mission_id IN (1329, 1132, 1135, 1133, 1134, 1131, 1136, 1138, 856)"));
            int Stays() => Count("SELECT COUNT(*) AS Value FROM spawnpool WHERE map_context_id = 1694 AND id NOT BETWEEN 650221 AND 650238");

            Assert.IsTrue(missions.All(Has));
            Assert.AreEqual((10, 13, 4, 5, 1, 7), All(), "1329 and 1132 have no scene; the docile miasma has no stat row");
            var stays = Stays();

            world.GetService<IMigrator>().Migrate(LamnaArmory);
            Assert.IsFalse(missions.Any(Has));
            Assert.AreEqual((0, 0, 0, 0, 0, 0), All());
            Assert.AreEqual(0, Count("SELECT COUNT(*) AS Value FROM creature_appearance WHERE id BETWEEN 650221 AND 650230"));
            Assert.IsFalse(world.MissionEvidenceEntries.Any(entry => missions.Contains(entry.MissionId)));
            Assert.AreEqual(stays, Stays(), "the caves' older pools stay");
            Assert.IsTrue(Has(PoolsRetreadPlanningV1.MissionId) && Has(PoolsBlowThemAllUpV1.MissionId));
            Assert.AreEqual(1, Count($"SELECT COUNT(*) AS Value FROM creature WHERE id = {PoolsRetreadCampNpcsV1.Amee}"));

            world.GetService<IMigrator>().Migrate(RetreadCaves);
            Assert.IsTrue(missions.All(Has));
            Assert.AreEqual((10, 13, 4, 5, 1, 7), All());
        }

        /// <summary>
        /// Pools_lamna_armory takes out its three missions, its givers, bosses and their pools, Fearce's attacks; the Armory's
        /// medics and Thrax pool and the spy chain stay.
        /// </summary>
        [TestMethod]
        public void TheLamnaArmoryRollsBackWithItsMigration()
        {
            using var harness = WildernessRuntimeTestHarness.Create();
            var world = harness.World;
            var missions = new uint[] { 896, 898, 903 };
            bool Has(uint mission) => world.MissionContentDefinitionEntries.AsNoTracking()
                .Any(entry => entry.MissionId == mission && entry.ContentRevision == PoolsMissionDataV1.Revision);
            int Count(string sql) => world.Database.SqlQueryRaw<int>(sql).AsEnumerable().Single();
            (int, int, int, int, int) All() => (
                Count("SELECT COUNT(*) AS Value FROM creature WHERE id BETWEEN 650213 AND 650220"),
                Count("SELECT COUNT(*) AS Value FROM spawnpool WHERE id BETWEEN 650213 AND 650220"),
                Count("SELECT COUNT(*) AS Value FROM npc_package WHERE id BETWEEN 650213 AND 650220"),
                Count("SELECT COUNT(*) AS Value FROM creature_action WHERE id IN (650038, 650039)"),
                Count("SELECT COUNT(*) AS Value FROM mission_scene_binding WHERE mission_id IN (896, 898, 903)"));
            int Stays() => Count("SELECT COUNT(*) AS Value FROM spawnpool WHERE map_context_id = 1465 AND id NOT BETWEEN 650213 AND 650220");

            Assert.IsTrue(missions.All(Has));
            Assert.AreEqual((8, 6, 3, 2, 3), All());
            var stays = Stays();

            world.GetService<IMigrator>().Migrate(SpyChain);
            Assert.IsFalse(missions.Any(Has));
            Assert.AreEqual((0, 0, 0, 0, 0), All());
            Assert.AreEqual(0, Count("SELECT COUNT(*) AS Value FROM creature_appearance WHERE id BETWEEN 650213 AND 650220"));
            Assert.AreEqual(0, Count("SELECT COUNT(*) AS Value FROM creature_stat WHERE id BETWEEN 650213 AND 650220"));
            Assert.IsFalse(world.MissionEvidenceEntries.Any(entry => missions.Contains(entry.MissionId)));
            Assert.AreEqual(stays, Stays(), "the medics and the Thrax pool stay");
            Assert.IsTrue(Has(PoolsSpyNetworkingV1.MissionId));

            world.GetService<IMigrator>().Migrate(LamnaArmory);
            Assert.IsTrue(missions.All(Has));
            Assert.AreEqual((8, 6, 3, 2, 3), All());
        }

        /// <summary>
        /// Pools_spy_chain takes out its three missions, Sheen's package and her stand-in; Sheen, Amee and Part II stay.
        /// </summary>
        [TestMethod]
        public void TheSpyChainRollsBackWithItsMigration()
        {
            using var harness = WildernessRuntimeTestHarness.Create();
            var world = harness.World;
            var missions = new uint[] { 1331, 1368, 1590 };
            bool Has(uint mission) => world.MissionContentDefinitionEntries.AsNoTracking()
                .Any(entry => entry.MissionId == mission && entry.ContentRevision == PoolsMissionDataV1.Revision);
            int Count(string sql) => world.Database.SqlQueryRaw<int>(sql).AsEnumerable().Single();
            (int, int, int, int) All() => (
                Count("SELECT COUNT(*) AS Value FROM creature WHERE id = 650212"),
                Count("SELECT COUNT(*) AS Value FROM creature_appearance WHERE id = 650212"),
                Count("SELECT COUNT(*) AS Value FROM npc_package WHERE id IN (650212, 510197)"),
                Count("SELECT COUNT(*) AS Value FROM mission_scene_binding WHERE mission_id IN (1331, 1368, 1590)"));

            Assert.IsTrue(missions.All(Has));
            Assert.AreEqual((1, Count("SELECT COUNT(*) AS Value FROM creature_appearance WHERE id = 510197"), 2, 3), All());

            world.GetService<IMigrator>().Migrate(SupplyChain);
            Assert.IsFalse(missions.Any(Has));
            Assert.AreEqual((0, 0, 0, 0), All());
            Assert.IsFalse(world.MissionEvidenceEntries.Any(entry => missions.Contains(entry.MissionId)));
            Assert.IsTrue(Has(PoolsRetreadPlanningPartTwoV1.MissionId) && Has(PoolsSpoilsOfWarV1.MissionId));
            Assert.AreEqual(1, Count("SELECT COUNT(*) AS Value FROM creature WHERE id = 510197"), "Sheen stays");

            world.GetService<IMigrator>().Migrate(SpyChain);
            Assert.IsTrue(missions.All(Has));
            Assert.AreEqual(2, All().Item3);
        }

        /// <summary>
        /// Pools_supply_chain takes out its four missions, Nakrinx, his bodyguards, their pool and beat, and Chester's package;
        /// Chester, Riggins and Death Patrol stay.
        /// </summary>
        [TestMethod]
        public void TheSupplyChainRollsBackWithItsMigration()
        {
            using var harness = WildernessRuntimeTestHarness.Create();
            var world = harness.World;
            var missions = new uint[] { 1322, 1323, 1324, 1326 };
            bool Has(uint mission) => world.MissionContentDefinitionEntries.AsNoTracking()
                .Any(entry => entry.MissionId == mission && entry.ContentRevision == PoolsMissionDataV1.Revision);
            int Count(string sql) => world.Database.SqlQueryRaw<int>(sql).AsEnumerable().Single();
            (int, int, int, int, int, int) All() => (
                Count("SELECT COUNT(*) AS Value FROM creature WHERE id IN (650210, 650211)"),
                Count("SELECT COUNT(*) AS Value FROM creature_stat WHERE id IN (650210, 650211)"),
                Count("SELECT COUNT(*) AS Value FROM npc_package WHERE id IN (650210, 650211, 510198)"),
                Count("SELECT COUNT(*) AS Value FROM spawnpool WHERE id = 650210"),
                Count("SELECT COUNT(*) AS Value FROM spawnpool_patrol WHERE pool_id = 650210"),
                Count("SELECT COUNT(*) AS Value FROM mission_scene_binding WHERE mission_id IN (1322, 1323, 1324, 1326)"));

            Assert.IsTrue(missions.All(Has));
            Assert.AreEqual((2, 2, 2, 1, 28, 2), All(), "1322 and 1326 have no scene");

            world.GetService<IMigrator>().Migrate(RetreadChain);
            Assert.IsFalse(missions.Any(Has));
            Assert.AreEqual((0, 0, 0, 0, 0, 0), All());
            Assert.IsFalse(world.MissionEvidenceEntries.Any(entry => missions.Contains(entry.MissionId)));
            Assert.IsTrue(Has(PoolsDeathPatrolV1.MissionId) && Has(PoolsRetreadPlanningPartTwoV1.MissionId));
            Assert.AreEqual(1, Count("SELECT COUNT(*) AS Value FROM creature WHERE id = 510198"), "Chester stays");
            Assert.AreEqual(1, Count($"SELECT COUNT(*) AS Value FROM creature WHERE id = {PoolsSnakePitNpcsV1.Riggins}"));

            world.GetService<IMigrator>().Migrate(SupplyChain);
            Assert.IsTrue(missions.All(Has));
            Assert.AreEqual((2, 2, 2, 1, 28, 2), All());
        }

        /// <summary>
        /// Pools_retread_chain takes out its five missions and the four Retreads; Amee, the Hermit and The Thirsty Hermit stay.
        /// </summary>
        [TestMethod]
        public void TheRetreadChainRollsBackWithItsMigration()
        {
            using var harness = WildernessRuntimeTestHarness.Create();
            var world = harness.World;
            var missions = new uint[] { 560, 561, 562, 563, 1330 };
            bool Has(uint mission) => world.MissionContentDefinitionEntries.AsNoTracking()
                .Any(entry => entry.MissionId == mission && entry.ContentRevision == PoolsMissionDataV1.Revision);
            int Count(string sql) => world.Database.SqlQueryRaw<int>(sql).AsEnumerable().Single();
            int Rows(string table) => Count($"SELECT COUNT(*) AS Value FROM {table} WHERE id BETWEEN " +
                $"{PoolsRetreadCampNpcsV1.McKormic} AND {PoolsRetreadCampNpcsV1.Rickert}");
            (int, int, int, int, int) All() => (Rows("creature"), Rows("spawnpool"), Rows("npc_package"), Rows("creature_appearance"),
                Count("SELECT COUNT(*) AS Value FROM mission_scene_binding WHERE mission_id IN (560, 561, 562, 563, 1330)"));

            Assert.IsTrue(missions.All(Has));
            Assert.AreEqual((4, 4, 4, 24, 4), All(), "1330 has no scene");

            world.GetService<IMigrator>().Migrate(BaneChain);
            Assert.IsFalse(missions.Any(Has));
            Assert.AreEqual((0, 0, 0, 0, 0), All());
            Assert.IsFalse(world.MissionEvidenceEntries.Any(entry => missions.Contains(entry.MissionId)));
            Assert.IsFalse(world.Set<MissionChannelPolicyEntry>().AsNoTracking().Any(entry => entry.MissionId == 563 &&
                entry.ContentRevision == PoolsMissionDataV1.Revision), "563's radio offer goes");
            Assert.IsTrue(Has(PoolsThirstyHermitV1.MissionId) && Has(937));
            Assert.AreEqual(1, Count($"SELECT COUNT(*) AS Value FROM creature WHERE id = {PoolsRetreadCampNpcsV1.Amee}"));
            Assert.AreEqual(1, Count($"SELECT COUNT(*) AS Value FROM creature WHERE id = {PlateauBaileyNpcsV1.Hermit}"));

            world.GetService<IMigrator>().Migrate(RetreadChain);
            Assert.IsTrue(missions.All(Has));
            Assert.AreEqual((4, 4, 4, 24, 4), All());
        }

        /// <summary>
        /// Pools_bane_chain takes out its three missions, the obelisk and the Linker; Bane Investigation and Feldman stay.
        /// </summary>
        [TestMethod]
        public void TheBaneChainRollsBackWithItsMigration()
        {
            using var harness = WildernessRuntimeTestHarness.Create();
            var world = harness.World;
            bool Has(uint mission) => world.MissionContentDefinitionEntries.AsNoTracking()
                .Any(entry => entry.MissionId == mission && entry.ContentRevision == PoolsMissionDataV1.Revision);
            int Count(string sql) => world.Database.SqlQueryRaw<int>(sql).AsEnumerable().Single();
            (int, int, int, int, int) Rows() => (
                Count($"SELECT COUNT(*) AS Value FROM world_destructible WHERE id = {PoolsObeliskV1.Id}"),
                Count($"SELECT COUNT(*) AS Value FROM creature WHERE id = {PoolsLinkerV1.Linker}"),
                Count($"SELECT COUNT(*) AS Value FROM creature_stat WHERE id = {PoolsLinkerV1.Linker}"),
                Count($"SELECT COUNT(*) AS Value FROM creature_action WHERE id BETWEEN {PoolsLinkerV1.FirstAction} AND {PoolsLinkerV1.LastAction}"),
                Count("SELECT COUNT(*) AS Value FROM mission_scene_binding WHERE mission_id IN (937, 938, 941)"));

            Assert.IsTrue(Has(937) && Has(938) && Has(941));
            Assert.AreEqual((1, 1, 1, 4, 2), Rows(), "941 has no scene");

            world.GetService<IMigrator>().Migrate(Contacts);
            Assert.IsFalse(Has(937) || Has(938) || Has(941));
            Assert.AreEqual((0, 0, 0, 0, 0), Rows());
            Assert.IsFalse(world.MissionEvidenceEntries.Any(entry => new uint[] { 937, 938, 941 }.Contains(entry.MissionId)));
            Assert.IsTrue(Has(932));
            Assert.AreEqual(1, Count($"SELECT COUNT(*) AS Value FROM creature WHERE id = {PoolsSnakePitContactsV1.Feldman}"));

            world.GetService<IMigrator>().Migrate(BaneChain);
            Assert.IsTrue(Has(937) && Has(938) && Has(941));
            Assert.AreEqual((1, 1, 1, 4, 2), Rows());
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
