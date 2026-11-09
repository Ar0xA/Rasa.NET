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
  Ridge Fithik pool 540067, since fix job A a point pool on the open east slope of the Ridge (261, 308.6, -642.2): a full
  spawn puts its 2-4 Fithik on the point and the rings round it (within 6.6 m), a single one topped up comes on the point;
  on open ground, also after a respawn (tested). Turn in at
  Emmons: 90000 XP, 6150 credits, one of 123046, 123141, 123166, 123026. No marker on the other Ridge pool 540066: its
  Fithik stand in a navmesh pocket no player reaches (see Deviations).
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

Set 3, the Sheitan Highway (migration `20271110000200_Ashen_sheitan_highway`). New Desert Predator 790080, mortar copies
790081-790084, Thrax pools 790085-790088, Predator pools 790089-790090, next free id 790091. The highway has no waypoint:
walk north from Shadow's Edge Post along the road; the Bane camp is at (-160, 303, -300).

- [ ] 1247 Highway to Hell (Ligo Ashen Desert): Captain Sera Karter (790042, Shadow's Edge dropship pad) offers it, no
  requirement, level 41. Kill 10 Thrax Ravagers (counter "Thrax Ravagers"; the Ashen Thrax Grenadier 531009, L39, now
  named "Thrax Ravager") and 10 Thrax Soldiers (counter "Thrax Soldiers"; Thrax Soldier Mark VI 531008, L39). Ravager
  pools 790085 (-180, 306.57, -305) and 790086 (-140, 306.34, -305) in the camp, Soldier pools 790087 (-160, 304.19, -260)
  and 790088 (-120, 304.81, -225) at and north of its north end; a marker r20 on each. The camp's own pool 531034
  (Soldiers and others) counts too. Turn in at Karter: 180000 XP, 8200 credits, one of 49576, 45777, 47948, 45762
  (weapons). Look: the "Thrax Ravager" name over the grenadiers (also in the Bane Conscription Facility and Indra Caverns).
- [ ] 1248 Air Superiority (Ligo Ashen Desert): Lt. Colonel Trent Ivan (790001, Shadow's Edge east barracks) offers it, no
  requirement, level 42. Destroy 1 Desert Predator (new, 790080, L42, 4700 HP; counter "Desert Predators"): two walk beats
  on the road south of the camp, pool 790089 from (-170.6, 295.8, -515.6) to (-160, 299.52, -440) (home, the pool's point,
  at -173.3, 297.11, -478.7) and pool 790090 from (-160, 297.59, -425) to (-160, 301.35, -365) (home at -162, 299.39,
  -400), each a loop from home to both ends; a marker on each beat (r50 at -174.4, -482.2; r40 at -161.6, -392.2). Turn in at Ivan: 180000 XP, 8200 credits, one of 12065, 11953, 47772, 15111 (weapons). Look: the Predators walk
  their beats on the road (not through the ground), fight and go back to the beat; "get some help" (a group mission).
- [ ] 1249 Artillery Annihilation (Ligo Ashen Desert): Lt. Colonel Dania Caldwell (790002, Shadow's Edge west barracks)
  offers it, no requirement, level 41. Destroy Mortar 1-4 (any order): the Bane mortars on the pads by the camp, pool
  592191 (-210.9, 315.29, -409.7), 592192 (-195.6, 317.34, -337.7), 592193 (-180.6, 310.17, -282.7), 592194 (-140.3,
  310.43, -285.3) (L42, 17500 HP); a marker r10 on each, named "Bane Heavy Mortar 1" .. "4" on the map. Turn in at
  Caldwell: 90000 XP, 6150 credits, one of 24086, 20504, 36188, 19286 (armour). Look: each mortar ticks off its own
  objective; the map labels of the markers.

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

All ESTIMATE (set 3):
- Levels: 1247 and 1249 41, 1248 42 (the zone band, triage D5; no chain; 1248 is TaRapedia's 180000 XP group mission and
  its Predator is L42).
- Thrax Ravager = the World DB's unnamed Ashen Thrax Grenadier 531009 (triage D9: 1266 says the Ravagers carry grenade
  launchers); the name 9223 is on the row, so every 531009 (Ashen Desert, Bane Conscription Facility, Indra Caverns) is a
  Thrax Ravager. Thrax Soldier = 531008 "Thrax Soldier Mark VI". Any kill of either counts, wherever.
- The Thrax pools: four of three (two Ravager, two Soldier), radius 0, 120 s respawn; places by the client map's Bane camp
  statics (floodlights, barricades, pillboxes at x -200..-120, z -347..-258), chosen by a probe (2026-11-09): navmesh
  ground, 11 m or more from a wall, walked to from the Shadow's Edge Post waypoint, 19.7 m or more from the mortar pads
  (Ravager pool 790086 to Mortar 4). Counts per pool have no source.
- The Desert Predator: a copy of the World DB's Alpha Class Recon Predator - Incline 520022 (class 3902, L42, 4700 HP,
  armour 410, its attacks) with the client name 9327; stock look (set 21). "The two Predators patrolling" (the client's
  reminder): two pools of one, each on a beat (spawnpool_patrol, steps on the navmesh ground along the navmesh's path, 4-12
  m apart), on the road between Shadow's Edge Post and the camp; 120 s respawn. The pool's point (the Predator's home) is
  the beat's middle step and the beat a loop from there to both ends, every step at most 45 m from home: a fight is left
  at 60 m from home (BehaviorManager.MaxChaseDistance), so a fight anywhere on the beat has 15 m before the leash. One kill
  is the client's count.
- 1249: each mortar of the four highway pads is its own copy of the Ashen Bane Mortar 592011 (same class, level, hit
  points, armour, attack and launcher look; no name id, so the client still calls it "Bane Mortar"), so Mortar n is the kill
  of copy n. Mortar n = pool n, south to north along the road (592191-592193 west of it, 592194 east); the client gives no
  order.
- Rewards: as set 2. 1247's "Cryogenic RPG Launcher" read as the ice grenade launcher (the client has no ice rocket
  launcher); 1248's "Flame Thrower" as the fire propellant gun.

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

- 1247: "the Thrax are landing in waves" (the reminder) is flavour: no dropship waves, the pools respawn.
- 1247: the kills count by creature row (531009, 531008), so Thrax Ravagers and Thrax Soldier Mark VIs killed in the Bane
  Conscription Facility and Indra Caverns (the same rows) count too, not only those of the Sheitan Highway.
- 1248: the air strikes on the camp after the turn-in (the turn-in text) are flavour.
- 1249: the mortars shell what comes within their reach (BaneMortars), not Shadow's Edge Post far to the south (the log's
  "firing at Shadow's Edge Post" is flavour).

## Server data that differs from the sources (not changed)

- The Stonewall Ridge Fithik pool 540066 stands 14 m under the ground. Cosmetic, upstream design: the spawn puts its
  Fithik on the ground (SpawnPoolManager.Anchor, RandomPointAround). Its ground is an unreachable navmesh pocket (upstream
  navmesh defect).

## Server data changed by set 1 (upstream rows)

- Moved (upstream U1, D7): Mason Linier 510010 (from the Shadow's Edge weapon vendor, -163.4, 296.39, -709, to the HQ
  entrance), Harris 510008 (from 4 m off the Ashoka waypoint, under 2 m from the navmesh edge, to 405, 281.41, -459.5),
  Emmons 510009 (from the Stonewall Ridge region centre, 179.3, 316.37, -557.2, to the Command Tower), Daris Linier
  510007 (2.0 m from his upstream spot, 3.68 m from the White Oasis control point's point; now 4.17 m from it). Down puts them back.

## Server data changed by set 2 (upstream rows)

- Moved: Thrax Overseer Exing's pool 520007 from (-281, 340.4, -252), a navmesh island on the mesa top that no walk from
  any waypoint reaches (probe of 2026-11-09), 14 m to (-289, 332.98, -264) on the mesa's slope, walked to from the
  Stonewall Ridge and Shadow's Edge Post waypoints. Down puts it back.

## Server data changed by set 3 (upstream rows)

- 531009 "Thrax Grenadier - Ashen Desert" (no name id upstream) gets the client name 9223 "Thrax Ravager" (triage D9). Down
  takes it off while it is still 9223.
- The Sheitan Highway mortar pools 592191-592194 (Bane_mortars) hold the copies 790081-790084 for 592011 (BaneMortarTests
  allows it). Down gives them 592011 back while they still hold the copy.

## Server data changed by fix job A (20271110000300)

- Fithik pool 540067 (to-fix row 1): from (233.2, 316.4, -651.2) radius 15 to a point (radius 0) at (261, 308.3, -642.2),
  29 m east on the Ridge's open slope; 1274's marker from (234.8, 320.05, -651.2) onto it (261, 308.6, -642.2). Upstream's
  15 m (Detour's random points reach up to 10 m past it) took in ground under a rock shelf (about x 232-240, z -660 to
  -636): 15 % of the Fithik came down there, a client surface 3.5-7 m over them, and could not be shot from the shelf; not
  killed, they filled the pool. A full spawn comes on the point and its rings, a single top-up on the point. The point has
  open ground joined to the waypoints 17 m round it (the rings and a 10 m stroll), one navmesh floor in each spot. ESTIMATE: the place. Down puts upstream's pool and set 1's marker back while they are still the fix's.
