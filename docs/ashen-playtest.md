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

Set 2, the Mauna Barrens (migration `20271110000100_Ashen_mauna_barrens`). New NPCs 790040-790042, Atta 790043-790045, Atta
pools 790046-790051, next free id 790052. The Mauna Barrens have no waypoint: walk from Shadow's Edge Post (or White Oasis
Post).

- [ ] 1242 Angry Angry Atta (Ligo Ashen Desert): Lieutenant Simon Kuang (new, 790040, Shadow's Edge west gate under the
  "Mauna Barrens" holosign, -205, 297.54, -736) offers it, no requirement, level 40. Kill 10 Ashen Atta Soldiers (counter
  "Atta Soldiers") and 10 Ashen Atta Workers ("Atta Workers") in the Mauna Barrens' south basin: Soldier pools 790046
  (-493, 295.61, -240) and 790047 (-429, 300.18, -240), Worker pools 790048 (-461, 298.32, -216) and 790049 (-461, 297.3,
  -264); a marker r20 on each. Turn in at Kuang: 90000 XP, 6150 credits, one of 49616, 48712, 48300, 15025 (weapons).
  Look: the Atta names and levels (Ashen Atta Soldier L40, Ashen Atta Worker L40), and that they count for Targets of
  Opportunity 1580's "50 Atta".
- [ ] 1243 Harmful Mutations (Ligo Ashen Desert): Kuang offers it, no requirement, level 40. Recover 4 Mutated Atta Blood
  Samples (item 97458; a 50% personal drop) from the Mutated Atta Soldiers (L41) of pools 790050 (-533, 302.79, -256) and
  790051 (-405, 300.97, -272); a marker r20 on each. Turn in at Doctor Jung Kwon (new, 790041, by the Shadow's Edge
  hospital, -89, 296.78, -822): 90000 XP, 6150 credits, one of 34116, 40502, 36787, 31088; she takes the samples.
- [ ] 1244 Chemical Oversight (Ligo Ashen Desert): Kuang offers it after 1242, level 41. Kill Thrax Overseer Exing (L44;
  pool 520007 moved 14 m off its navmesh island to -289, 332.98, -264, on the mesa slope west of the Sheitan Highway).
  A marker r15 on him. Walk from the Stonewall Ridge waypoint. Turn in at Kuang: 90000 XP, 6150 credits, one of 28634,
  38952, 18770, 35740. "Bring some friends" (a group boss).
- [ ] 1245 Eyes on the Ground (Ligo Ashen Desert): Captain Sera Karter (new, 790042, by the Shadow's Edge dropship pad,
  -112, 296.19, -748) offers it after 1243, level 41, and gives 5 Atta Sensor Beacons (97460). Plant one at each of five
  personal spots (class 7847, named "Atta Sensor Beacon") in the Barrens, any order: 1 (-431, 304.07, -203), 2 (-554,
  304.23, -230), 3 (-596, 303.04, -83), 4 (-476, 328.91, -17), 5 (-338, 293.53, -80); a marker r8 on each, named "Atta
  Beacon Point 1" .. "5" on the map. Turn in at Karter: 90000 XP, 6150 credits, one of 33987, 23698, 21100, 46013. Look:
  the spot's name and the planted beacon model; the map labels of the markers.

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

All ESTIMATE (set 2):
- Levels: 1242 and 1243 40, 1244 and 1245 41 (the zone band by chain position, triage D5). Kuang and Kwon level 40 (no
  source), Karter 48 (TaRapedia's page of the Avernus Outpost Karter, "the same contact").
- Looks: Kuang a copy of Mason Linier 510010, Kwon and Karter of Ida Hayner 510011 (female AFS class 3848; Kwon is female
  in the client's 1243 offer, Karter on TaRapedia). Server-only packages (their ids): the client gives these missions no
  objective conversation. 4500 HP, armour 300, standing still, rotation 0.
- Places of Kuang, Kwon, Karter: TaRapedia names only Shadow's Edge Post; spots by the client statics (the west gate's
  "Mauna Barrens" holosign, the hospital, the dropship transport pad), chosen by a probe (2026-11-09) with the set 1
  criteria (navmesh and client floor, 2.5 m from a wall, nothing over the head, seen from 16 of 16 places round it and from
  the end of the walk from the Shadow's Edge Post waypoint, 8 m from every waypoint and teleporter, 22 m outside every
  hostile pool's circle).
- The Atta: copies of World DB rows at the zone band: Ashen Atta Soldier = 531015 (Atta Soldier, Ashen/Avernus, L40),
  Ashen Atta Worker = 531099 (Atta Harvester, Thunderhead, L40; "Worker" read as the harvester class), Mutated Atta Soldier
  = 531098 (Atta Soldier, Thunderhead, L41), each with the client name (9318, 9319, 9320) and the copied hit points,
  armour and attacks; stock look (no tint: set 21). Six pools of three (two of each kind), radius 0, 120 s respawn, in the
  open south basin of the Barrens (the Barrens region's big flat part), 40 m apart, walked to from Shadow's Edge Post and
  White Oasis Post. Counts per pool and pool places have no source.
- 1243: the sample drop rate 50% (no source); Kwon takes the four at the turn-in; an abandon keeps them.
- 1245: five beacons given at the accept; the spot is the GPS beacon acceptor 7847 (as Crucible 1214, Pools 1025) with the
  client's usable name 71 "Atta Sensor Beacon"; the five spots (no source) one in each fifth of a 110 m circle round the
  Barrens region's centre, on flat open ground, 24 m outside every hostile pool's circle.
- Rewards: TaRapedia's item names matched to the lowest Uncommon template of the kind and icon number in the band of the
  mission's level, the nearest icon number where the band has none (as the Crucible).

## Deviations (client/server limits)

- 1274: one marker, not two. The Ridge's other automatic Fithik pool 540066 puts its Fithik in an isolated navmesh pocket
  (lowest of three layers at 72.99, -581.11: y 325.3, 330.6, 336.5; about 15-25 m) with no path to any waypoint. The pool
  row is not changed (upstream navmesh defect).
- 1250: Colonel Mason Linier stands at the entrance of the Shadow's Edge HQ, not in the rooms under the post: the rooms
  are within 20 m (2D) of the Fithik pools 540083 and 540084 on the ridge above.

- 1245: the air strikes in the offer ("Despite your efforts ...") and any Atta reaction to a beacon are flavour; a planted
  beacon only completes its objective (no mission air strike, as Crucible 1214).
- 1244: Exing stays near the World DB spot that Ellatha, TaRapedia's boss page and 1580 give; the client log's "Sheitan
  Outpost, at the north end of the Sheitan Highway" is not followed (triage D10). He does not walk "among the Atta" (the
  1244 offer): a boss pool of his own, 14 m from the upstream spot.
- 1242: the Atta "call for assistance" (TaRapedia 2007-12-11) is not built (no such server behaviour).

## Server data that differs from the sources (not changed)

- The Stonewall Ridge Fithik pools 540066 and 540067 stand 14 m and 4 m under the ground. Cosmetic, upstream design: the
  spawn puts their Fithik on the ground (SpawnPoolManager.Anchor, RandomPointAround); no effect. 540066's ground is an
  unreachable navmesh pocket (upstream navmesh defect).

## Server data changed by set 1 (upstream rows)

- Moved (upstream U1, D7): Mason Linier 510010 (from the Shadow's Edge weapon vendor, -163.4, 296.39, -709, to the HQ
  entrance), Harris 510008 (from 4 m off the Ashoka waypoint, under 2 m from the navmesh edge, to 405, 281.41, -459.5),
  Emmons 510009 (from the Stonewall Ridge region centre, 179.3, 316.37, -557.2, to the Command Tower), Daris Linier
  510007 (2.0 m from his upstream spot, 3.68 m from the White Oasis control point's point; now 4.17 m from it). Down puts them back.

## Server data changed by set 2 (upstream rows)

- Moved: Thrax Overseer Exing's pool 520007 from (-281, 340.4, -252), a navmesh island on the mesa top that no walk from
  any waypoint reaches (probe of 2026-11-09), 14 m to (-289, 332.98, -264) on the mesa's slope, walked to from the
  Stonewall Ridge and Shadow's Edge Post waypoints. Down puts it back.
