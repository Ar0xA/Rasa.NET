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
    /// and the Ashen Atta new and Thrax Overseer Exing's pool moved (Ashen_mauna_barrens).
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
            AshenEyesOnTheGroundV1.MissionId
        };

        /// <summary>
        /// Every visible objective has a marker (EveryVisibleObjectiveHasAMarker): set 1's five (each report's one at its
        /// receiver, Fithik Infestation's on the Stonewall Ridge Fithik pool); set 2's twelve (1242's four on the Atta Soldier and
        /// Worker pools, 1243's two on the Mutated Atta pools, 1244's on Exing, 1245's five on the beacon spots).
        /// </summary>
        internal const int Indicators = 5 + 12;

        private const string LeadIns = "20271110000000_Ashen_lead_ins";
        private const string MaunaBarrens = "20271110000100_Ashen_mauna_barrens";
        private const uint Map = 1734;

        private const uint Ames = 790000, Ivan = 790001, Caldwell = 790002, Yamamoto = 790003;
        private const uint MasonLinier = 510010, Harris = 510008, Emmons = 510009, DarisLinier = 510007;
        private const uint Kuang = 790040, Kwon = 790041, Karter = 790042;
        private const uint AttaSoldier = 790043, AttaWorker = 790044, MutatedSoldier = 790045, Exing = 520007;

        /// <summary>The migration directly before <paramref name="migration"/> (IMigrationsAssembly, ordinal order), as CrucibleMissionTests.Previous.</summary>
        internal static string Previous(DbContext world, string migration) => Rasa.Test.Missions.Crucible.CrucibleMissionTests.Previous(world, migration);

        [TestMethod]
        public void TheMissionsAreEnabledOperationalAndGivenByTheirNpcs()
        {
            var expected = new (uint Mission, uint? Giver, uint? Receiver, uint Level)[]
            {
                (1250, Ames, MasonLinier, 40), (1273, Harris, Emmons, 40), (1274, Emmons, Emmons, 40), (1283, Ivan, Yamamoto, 40),
                (1284, Caldwell, DarisLinier, 40), (1242, Kuang, Kuang, 40), (1243, Kuang, Kwon, 40), (1244, Kuang, Kuang, 41),
                (1245, Karter, Karter, 41)
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
                (Kuang, 9291, 790040, 3846, 40), (Kwon, 9298, 790041, 3848, 40), (Karter, 9281, 790042, 3848, 48)
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
                (Karter, -112, -748), (Exing, -289, -264)
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
                })
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
                    evidence.Where(entry => entry.MissionId == mission).OrderBy(entry => entry.EvidenceId)
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
                (1245, 90000, 6150, new[] { (33987U, 1U), (23698U, 1U), (21100U, 1U), (46013U, 1U) })
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
        /// keyed by the client's names 155-159 "Atta Beacon Point 1" .. "5" (missionobjectiveindicatorlanguage).
        /// </summary>
        [TestMethod]
        public void IndicatorsAreOnAshenDesertAndAboveUnnamedButTheBeaconPoints()
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
        /// Point n" (missionobjectiveindicatorlanguage 154 + n); null for the others.
        /// </summary>
        internal static uint? NamedMarker(uint mission, uint objective) =>
            mission == 1245 && objective is >= 1 and <= 5 ? 154 + objective : null;

        /// <summary>Every visible Ashen objective has a marker; no Ashen objective is hidden (the scenes of 1243 and 1245 hold items and spots only).</summary>
        [TestMethod]
        public void EveryVisibleObjectiveHasAMarker()
        {
            using var harness = WildernessRuntimeTestHarness.Create();
            var world = harness.World;
            var revision = AshenMissionDataV1.Revision;
            var marked = world.MissionIndicatorEntries.AsNoTracking().Where(entry => entry.ContentRevision == revision)
                .Select(entry => new { entry.MissionId, entry.ObjectiveId }).ToList()
                .Select(entry => (entry.MissionId, entry.ObjectiveId)).ToHashSet();
            CollectionAssert.AreEquivalent(new uint[] { 1243, 1245 }, Scenes(harness).Select(scene => scene.MissionId).ToArray(), "the scenes");
            var objectives = world.MissionObjectiveDefinitionEntries.AsNoTracking().Where(entry => entry.ContentRevision == revision)
                .Select(entry => new { entry.MissionId, entry.ObjectiveId }).ToList();
            Assert.HasCount(5 + 2 + 1 + 1 + 5, objectives, "the objectives are read");
            var missing = objectives.Select(entry => (entry.MissionId, entry.ObjectiveId)).Where(key => !marked.Contains(key)).OrderBy(key => key).ToArray();
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
                (1274, 1, 234.8, -651.2, 30), // Fithik pool 540067 (540066's Fithik are in an unreachable pocket)
                (1283, 1, 686, -495, 8),                            // Yamamoto
                (1284, 1, -507.4, 162.4, 8),                        // Daris Linier
                (1242, 1, -493, -240, 20), (1242, 1, -429, -240, 20), // the Ashen Atta Soldier pools 790046, 790047
                (1242, 2, -461, -216, 20), (1242, 2, -461, -264, 20), // the Ashen Atta Worker pools 790048, 790049
                (1243, 1, -533, -256, 20), (1243, 1, -405, -272, 20), // the Mutated Atta Soldier pools 790050, 790051
                (1244, 1, -289, -264, 15),                          // Exing, moved
                (1245, 1, -431, -203, 8), (1245, 2, -554, -230, 8), (1245, 3, -596, -83, 8), (1245, 4, -476, -17, 8), (1245, 5, -338, -80, 8)
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
                (790050, MutatedSoldier, 1, 1243), (790051, MutatedSoldier, 1, 1243), (Exing, Exing, 1, 1244)
            })
            {
                var row = harness.World.SpawnPoolEntries.AsNoTracking().Single(entry => entry.Id == pool);
                Assert.AreEqual(creature, row.Creature1Id, $"pool {pool}");
                Assert.IsTrue(rows.Any(marker => marker.MissionId == mission && marker.ObjectiveId == objective &&
                    Vector2.Distance(new((float)marker.PosX, (float)marker.PosZ), new((float)row.PosX, (float)row.PosZ)) < 0.1f), $"pool {pool} under a {mission}.{objective} marker");
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
        /// A scene use object takes the use argument the client sends (QUEST-RULES): usabledata lookup[class][0], or 1 where it
        /// is None (Usable.__init__), written out here. 7847 UsableItemAccHumGpsBeacon sends 3 (as CrucibleMissionTests pins it);
        /// 1245's five spots carry the client's name 71 "Atta Sensor Beacon" (usablenameoverride LIGO_ASHEN_ATTA_BEACON).
        /// </summary>
        [TestMethod]
        public void EveryUsableSceneObjectTakesTheClientsUseArgument()
        {
            var clientUseArguments = new Dictionary<uint, uint> { [7847] = 3 };
            var clientUseNames = new Dictionary<uint, uint> { [7847] = 71 };
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
            Assert.AreEqual(5, used, "1245's five beacon spots");
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
