# Ligo Ashen Desert missions: playtest list, assumptions and deviations

Missions that are implemented (data, migrations and tests pass) but not yet played through in the
game client. A checked box (`- [x]`) means the playtest is done and the mission works.

Format: `- [ ] <mission id> <name> (<zone>): <what to look at>`.

## Ligo Ashen Desert

Set 1, the lead-ins (migration `20271110000000_Ashen_lead_ins`). Map 1734 (`adv_arieki_ligo_ashendesert`), log
category 10000016 "Battlefield (Ashen Desert)". New NPCs 790000-790003, next free id 790004.

- [ ] 1250 The Dustiest Place on Earth (Ligo Ashen Desert): Sergeant Bernard Ames (new, 790000, Ashen Lookout camp by the
  communication tent, 345, 311.14, -818) offers it, no requirement, level 40. Talk to Colonel Mason Linier (moved to the
  Shadow's Edge HQ entrance, -132, 284.05, -875). A marker at Linier. Turn in at Linier: 42500 XP, 4000 credits, one of
  2x 45065, 3x 111029, 1x 47600, 3x 111019. Check the mission log shows it under "Battlefield (Ashen Desert)".
- [ ] 1273 Report to Stonewall Ridge (Ligo Ashen Desert): Captain Flynn Harris (moved to 405, 281.41, -459.5, 8 m from the
  Ashoka waypoint) offers it, no requirement, level 40. Talk to Captain Marcus Emmons (moved to the Stonewall Command
  Tower, -62, 350.48, -414). A marker at Emmons. Turn in at Emmons: 45000 XP, 4100 credits, one of 3x 111039, 2x 45065,
  3x 111029, 1x 47600.
- [ ] 1274 Fithik Infestation (Ligo Ashen Desert): Emmons offers it, no requirement, level 40. Kill 10 Fithik ("Kill
  Fithik" n/10; any creature with the Fithik species flag counts, anywhere). One marker (radius 30) on the Stonewall
  Ridge Fithik pool 540067 (234.8, 320.05, -651.2). Turn in at Emmons: 90000 XP, 6150 credits, one of 123046, 123141,
  123166, 123026. The pool row is 4 m under the ground; the spawn puts the Fithik on it (tested). No marker on the other
  Ridge pool 540066: its Fithik stand in a navmesh pocket no player reaches (see Deviations).
- [ ] 1283 Good Day to Die (Ligo Ashen Desert): Lt. Colonel Trent Ivan (new, 790001, Shadow's Edge east barracks, -97,
  297.05, -792) offers it, no requirement, level 40. Talk to Captain Akio Yamamoto (new, 790003, Boneyard Outpost eastern
  tent, 686, 289.93, -495). A marker at Yamamoto. Turn in at Yamamoto: 45000 XP, 4100 credits, one of 3x 111019, 6x
  45063, 3x 45447, 1x 111233.
- [ ] 1284 You Can't Drink Ash (Ligo Ashen Desert): Lt. Colonel Dania Caldwell (new, 790002, Shadow's Edge west barracks,
  -158, 297.05, -792) offers it, no requirement, level 40. Talk to Captain Daris Linier (moved 2.0 m from his upstream
  spot, 4.17 m from the White Oasis control point's point, -507.4, 282.73, 162.4). A marker at Daris. Turn in at Daris: 47500 XP, 4200 credits, one of 3x
  111029, 1x 47600, 3x 111019, 6x 45063. Look: Daris is a control point 17 service NPC; he must stand while the point is
  AFS-held.

## Assumptions and choices (not from a source)

All ESTIMATE (set 1):
- Levels: all five missions level 40 (the Ashen Desert zone band 40-42, Ellatha map; the TR MMO DB's level 30 is not
  used). Ames, Ivan and Caldwell level 40 (no source). Yamamoto level 49 (TaRapedia NPC page, a source, but it is far over
  the zone band).
- Looks: Ames is a copy of Harris 510008, Ivan of Mason Linier 510010, Caldwell of Ida Hayner 510011 (female AFS class
  3848), Yamamoto of Emmons 510009. The new NPCs have 4500 HP and armour 300, and stand still. Ames, Ivan and Caldwell
  have server-only packages (their ids); the client gives them no objective conversation. All the NPC pools (new and
  moved) face rotation 0.
- All positions except Yamamoto (TaRapedia loc): chosen by a probe (2026-11-09): on the navmesh and on a client floor, at
  least 2 m from a wall, nothing over the head, seen from 16 of 16 places 2 m round it and from the end of the walk from
  its area's waypoint, 7 m or more from every waypoint and local teleporter, 22 m or more outside every hostile pool's
  circle. Ivan and Caldwell in the east and west barracks (TaRapedia names only Shadow's Edge Post). Emmons by the
  Command Tower (TaRapedia 1277 "Start with this tower here").
- Rewards: the client has no reward blocks for these missions; the items are TaRapedia's, the stack sizes are ESTIMATE.
  1274 "Modification" read as the grade [4] modules (as in the Crucible).
- 1274: any Fithik counts, also off the Ridge (CreatureFlagKilled, flag 72). The markers are at the navmesh ground over
  the two automatic Ridge pools (540068 is scripted, no marker).

## Deviations (client/server limits)

- 1274: one marker, not two. The Ridge's other automatic Fithik pool 540066 puts its Fithik in an isolated navmesh pocket
  (lowest of three layers at 72.99, -581.11: y 325.3, 330.6, 336.5; about 15-25 m) with no path to any waypoint. The pool
  row is not changed (upstream navmesh defect).
- 1250: Colonel Mason Linier stands at the entrance of the Shadow's Edge HQ, not in the rooms under the post: the rooms
  are within 20 m (2D) of the Fithik pools 540083 and 540084 on the ridge above.

## Server data that differs from the sources (not changed)

- The Stonewall Ridge Fithik pools 540066 and 540067 stand 14 m and 4 m under the ground. Cosmetic, upstream design: the
  spawn puts their Fithik on the ground (SpawnPoolManager.Anchor, RandomPointAround); no effect. 540066's ground is an
  unreachable navmesh pocket (upstream navmesh defect).

## Server data changed by set 1 (upstream rows)

- Moved (upstream U1, D7): Mason Linier 510010 (from the Shadow's Edge weapon vendor, -163.4, 296.39, -709, to the HQ
  entrance), Harris 510008 (from 4 m off the Ashoka waypoint, under 2 m from the navmesh edge, to 405, 281.41, -459.5),
  Emmons 510009 (from the Stonewall Ridge region centre, 179.3, 316.37, -557.2, to the Command Tower), Daris Linier
  510007 (2.0 m from his upstream spot, 3.68 m from the White Oasis control point's point; now 4.17 m from it). Down puts them back.
