using System.Collections.Generic;
using System.Linq;
using static Rasa.Services.Preloader.Missions.Plateau.PlateauCreatureSqlV1;

namespace Rasa.Services.Preloader.Missions.Pools
{
    /// <summary>
    /// Nakrinx, the Bane Supply Master, and his four bodyguards on their rounds south of the Thrax Barracks, Valverde Pools
    /// (map 1304), for The Supply Master (1322); and a package for Lieutenant Chester (510198), who gives Smash and Grab
    /// (1324) and Spoils of War (1326). The server had neither Nakrinx nor a package for Chester.
    ///
    /// Sourced: client name 9403 "Nakrinx" (creaturenamelanguage); his package 1522 (objectiveconversation 1322,1, "I tell
    /// you everything you need to know human. No shoot Nakrinx."). Client log of 1322: "He can be found traveling between
    /// the Thrax Barracks and Lamna Armory"; offer: "he only has a small contingent of guards"; objective body "You'll
    /// have to kill his bodyguards to get him to talk." TaRapedia The Supply Master walkthrough: "Nakrinx can be found in
    /// and around the Thrax Barracks. Kill the four Thrax that patrol with him and be careful not to kill him. After they
    /// die, a mission indicator pops above his head, and you can interrogate him."
    ///
    /// Reconstructed (ESTIMATE; the user's choice of 2026-10-25: a public patrol on an estimated route with 4 guards,
    /// talkable once his guards are dead):
    ///  - One public spawn pool, a patrol group (PatrolGroups): Nakrinx leads, his four bodyguards follow. The beat is the
    ///    navmesh route from the Barracks' east gate south towards Lamna Armory, about 430 m (<see cref="Beat"/>), walked
    ///    there and back with a pause at each end; respawn 300 s.
    ///  - Nakrinx: a Thrax class a player can talk to (11320 NPC_Bane_Thrax_Technician, as "Thrax Technician - Divide"
    ///    530003: the Thrax Commander's class 10504 has no NPC augmentation, so no talk), level 33, the Thrax Commander's
    ///    hit points and armour ("Thrax Commander - Pools" 531093), NEUTRAL (faction 3: he seeks no one and no one seeks him, but a player may shoot him), no attack: a bystander
    ///    (engine: PatrolGroups.IsBystander), in no fight, his guards' or by a shot, and he stands on his beat while they
    ///    fight. His talk is the mission's, open per player once
    ///    that player has killed four of the bodyguards (PoolsSupplyMasterV1).
    ///  - The bodyguards: their own creature (so only they count), a copy of "Thrax Soldier - Pools" (531089: class 20757,
    ///    name 237, level 30, 2652 hit points, armour 140, its two attacks).
    ///  - Chester: a server-only package (his id), as Riggins's: the client has no talk on him.
    ///
    /// Ids: creatures 650210 and 650211, pool 650210, free before. Plain SQL, valid on SQLite and MySQL; down takes out only
    /// these rows.
    /// </summary>
    public static class PoolsSupplyNpcsV1
    {
        public const uint MapContextId = PoolsMissionDataV1.MapContextId;
        public const uint Nakrinx = 650210, NakrinxName = 9403, NakrinxPackage = 1522;
        public const uint NakrinxClass = 11320, NakrinxLevel = 33, NakrinxHitPoints = 8024, NakrinxArmor = 310;
        public const uint Neutral = 3;
        public const uint Bodyguard = 650211, BodyguardClass = 20757, BodyguardName = 237, BodyguardLevel = 30;
        public const uint BodyguardHitPoints = 2652, BodyguardArmor = 140, BodyguardKick = 53137, BodyguardWeapon = 53138;
        public const uint Bodyguards = 4;
        public const uint Pool = 650210, RespawnSeconds = 300, EndPauseMs = 10000;
        public const uint Chester = 510198, ChesterPackage = 510198;

        /// <summary>
        /// The way out, the corners of the navmesh's path from the Barracks' east gate south (a navmesh probe of
        /// 2026-10-25, corners closer than 3 m to the next left out). The way back is the same corners in turn.
        /// </summary>
        public static readonly (double X, double Y, double Z)[] Out =
        {
            (545.6, 680.0, 464.0), (559.6, 677.2, 464.8), (563.2, 674.0, 462.8), (564.8, 672.6, 461.2), (568.8, 667.4, 450.0),
            (574.4, 672.6, 428.8), (584.0, 669.0, 389.6), (598.4, 676.2, 351.6), (594.8, 678.4, 338.0), (580.8, 676.8, 224.0),
            (579.2, 676.8, 213.6), (574.8, 676.0, 202.0), (570.0, 674.4, 192.0), (574.8, 673.8, 164.4), (538.4, 672.6, 70.4),
        };

        /// <summary>The beat: out to the far end, then back over the same corners to the step before the first.</summary>
        public static (double X, double Y, double Z, uint PauseMs)[] Beat =>
            Out.Select((at, index) => (at.X, at.Y, at.Z, index == 0 || index == Out.Length - 1 ? EndPauseMs : 0U))
                .Concat(Out.Skip(1).Take(Out.Length - 2).Reverse().Select(at => (at.X, at.Y, at.Z, 0U))).ToArray();

        public static IEnumerable<string> Up()
        {
            yield return "INSERT INTO creature (id, comment, class_id, faction, level, max_hp, name_id, run_speed, walk_speed, " +
                         "action1, action2, action3, action4, action5, action6, action7, action8) " +
                         $"VALUES ({Nakrinx}, 'Nakrinx - Pools, Bane Supply Master', {NakrinxClass}, {Neutral}, {NakrinxLevel}, " +
                         $"{NakrinxHitPoints}, {NakrinxName}, 9, 5, 0, 0, 0, 0, 0, 0, 0, 0);";
            yield return Stat(Nakrinx, NakrinxHitPoints, NakrinxArmor);
            yield return $"INSERT INTO npc_package (id, package_id, comment) VALUES ({Nakrinx}, {NakrinxPackage}, 'Nakrinx - Pools');";
            yield return Creature(Bodyguard, "Nakrinx Bodyguard - Pools", BodyguardClass, BodyguardLevel, BodyguardHitPoints, BodyguardName,
                BodyguardKick, BodyguardWeapon);
            yield return Stat(Bodyguard, BodyguardHitPoints, BodyguardArmor);

            var start = Out[0];
            yield return "INSERT INTO spawnpool (id, mode, anim_type, respown_time, pos_x, pos_y, pos_z, rotation, map_context_id, " +
                "creature_1_Id, creature_1_min_count, creature_1_max_count, creature_2_Id, creature_2_min_count, creature_2_max_count, " +
                "creature_3_Id, creature_3_min_count, creature_3_max_count, creature_4_Id, creature_4_min_count, creature_4_max_count, " +
                "creature_5_Id, creature_5_min_count, creature_5_max_count, creature_6_Id, creature_6_min_count, creature_6_max_count, radius) " +
                $"VALUES ({Pool}, 0, 0, {RespawnSeconds}, {F(start.X)}, {F(start.Y)}, {F(start.Z)}, 0, {MapContextId}, " +
                $"{Nakrinx}, 1, 1, {Bodyguard}, {Bodyguards}, {Bodyguards}, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);";
            var beat = Beat;
            for (var step = 0; step < beat.Length; step++)
                yield return "INSERT INTO spawnpool_patrol (pool_id, step, pos_x, pos_y, pos_z, facing, pause_ms) " +
                    $"VALUES ({Pool}, {step}, {F(beat[step].X)}, {F(beat[step].Y)}, {F(beat[step].Z)}, NULL, {beat[step].PauseMs});";

            yield return $"INSERT INTO npc_package (id, package_id, comment) VALUES ({Chester}, {ChesterPackage}, 'Lieutenant Chester - East Listening Post');";
        }

        public static IEnumerable<string> Down()
        {
            yield return $"DELETE FROM npc_package WHERE id = {Chester};";
            yield return $"DELETE FROM spawnpool_patrol WHERE pool_id = {Pool};";
            yield return $"DELETE FROM spawnpool WHERE id = {Pool};";
            foreach (var id in new[] { Bodyguard, Nakrinx })
            {
                yield return $"DELETE FROM npc_package WHERE id = {id};";
                yield return $"DELETE FROM creature_stat WHERE id = {id};";
                yield return $"DELETE FROM creature WHERE id = {id};";
            }
        }
    }
}
