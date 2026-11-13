using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Rasa.Structures.World;

namespace Rasa.Services.Preloader.Missions.Ashen
{
    /// <summary>
    /// Ashen fix job P (real client 2026-11-13), a delta on 20271110002110 (fix O, live): 1535's first objective (the graveyard's
    /// four pools dead at once; a squad's copy refills a cleared pool only after 45 min) was too much for one player. Fix O's two
    /// pools took upstream 531049's and 531060's counts (ESTIMATE): 790700's nine Atta stand beside 531049's nine on its island, and
    /// the Harvesters' warcries chain. Fix O's pools are ours to size: one player's (a deviation, user review).
    ///  - 790700: Atta Soldier 531015 2-3 -> 1, Atta Harvester 531016 3-4 -> 1-2, Atta Grub 531017 0-2 -> none.
    ///  - 790701: Atta Harvester 531016 2-4 -> 1-2.
    /// Places and radii kept (fix O's). Each UPDATE guarded on fix O's exact counts; Down puts them back.
    /// </summary>
    public static class AshenFixPV1
    {
        public const uint Run = AshenPetrovichsRunV1.MissionId;
        public const uint WestPool = AshenFixOV1.WestPool, EastPool = AshenFixOV1.EastPool;

        /// <summary>A pool's three creature slots: id, least, most.</summary>
        public static readonly (uint Id, uint Min, uint Max)[] WestBefore = { (531015, 2, 3), (531016, 3, 4), (531017, 0, 2) },
            WestNow = { (531015, 1, 1), (531016, 1, 2), (531017, 0, 0) },
            EastBefore = { (531016, 2, 4), (0, 0, 0), (0, 0, 0) },
            EastNow = { (531016, 1, 2), (0, 0, 0), (0, 0, 0) };

        public const uint Evidence = 6;
        public const string Source = "repository:AshenFixPV1";
        public const string RunNote =
            "Fix job P (real client 2026-11-13): fix O's pools sized for one player (a deviation, user review): 790700 one Atta " +
            "Soldier and one or two Harvesters (was 2-3, 3-4 and 0-2 Grubs), 790701 one or two Harvesters (was 2-4). ESTIMATE.";

        public static IEnumerable<string> UpSql()
        {
            yield return CountsSql(WestPool, WestNow, WestBefore);
            yield return CountsSql(EastPool, EastNow, EastBefore);
        }

        public static IEnumerable<string> DownSql()
        {
            yield return CountsSql(EastPool, EastBefore, EastNow);
            yield return CountsSql(WestPool, WestBefore, WestNow);
        }

        public static void Up(MigrationBuilder migration)
        {
            foreach (var sql in UpSql())
                migration.Sql(sql);
            AshenMissionDataV1.Existing(migration, Run).Evidence(Evidence, MissionEvidenceSourceKind.Reconstruction, Source, RunNote, 0.3);
        }

        public static void Down(MigrationBuilder migration)
        {
            migration.Sql($"DELETE FROM mission_evidence WHERE mission_id = {Run} AND content_revision = '{AshenMissionDataV1.Revision}' " +
                          $"AND evidence_id = {Evidence} AND source_uri = '{Source}';");
            foreach (var sql in DownSql())
                migration.Sql(sql);
        }

        private static string CountsSql(uint pool, (uint Id, uint Min, uint Max)[] to, (uint Id, uint Min, uint Max)[] from) =>
            $"UPDATE spawnpool SET creature_1_min_count = {to[0].Min}, creature_1_max_count = {to[0].Max}, " +
            $"creature_2_min_count = {to[1].Min}, creature_2_max_count = {to[1].Max}, " +
            $"creature_3_min_count = {to[2].Min}, creature_3_max_count = {to[2].Max} " +
            $"WHERE id = {pool} AND map_context_id = {AshenFixOV1.Outpost} " +
            $"AND creature_1_Id = {from[0].Id} AND creature_1_min_count = {from[0].Min} AND creature_1_max_count = {from[0].Max} " +
            $"AND creature_2_Id = {from[1].Id} AND creature_2_min_count = {from[1].Min} AND creature_2_max_count = {from[1].Max} " +
            $"AND creature_3_Id = {from[2].Id} AND creature_3_min_count = {from[2].Min} AND creature_3_max_count = {from[2].Max};";
    }
}
