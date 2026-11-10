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
  pool 520007 moved off its navmesh island: set 2 to -289, 332.98, -264 on the mesa slope, fix B to -260, 308.9, -310 on
  the flat at the mesa's south foot, west of the Sheitan Highway). A marker r15 on him. Walk from the Shadow's Edge Post
  waypoint, or on from the Mauna Barrens basin or the highway camp. Turn in at Kuang: 90000 XP, 6150 credits, one of 28634,
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

Set 4, the Boneyard (migration `20271110000400_Ashen_boneyard`). New Lieutenant Gabriel Infanger 790120, Desert Stalker
790121, Xanx pools 790122-790124, Stalker pools 790125-790126, next free id 790127. Boneyard Outpost and the Boneyard have
no waypoint: walk north-east from the Ashoka Settlement waypoint (up out of Ashoka) to the outpost (682, 290, -516) and the
Boneyard (579, 283, -291).

- [ ] 1262 Xanxless Job (Ligo Ashen Desert): Lieutenant Jan Blood (upstream 510013, Boneyard Outpost, 682.4, 289.56,
  -516.4, where upstream has him) offers it, no requirement, level 40. Kill 6 Xanx (counter "Xanx Killed"; the World DB's
  Xanx - Ashen Desert 540020, "Xanx Burrower", L39): pools 790122 (560, 283.41, -250), 790123 (600, 282.49, -230), 790124
  (640, 282.85, -250) of three in the Boneyard; a marker r20 on each. Turn in at Blood: 95000 XP, 6300 credits, one of
  46029, 34374, 23569, 31241 (armour). Look: the Xanx come down and back on the Boneyard floor (not under it).
- [ ] 1263 Fallen Soldiers (Ligo Ashen Desert): Captain Akio Yamamoto (790003, Boneyard Outpost eastern tent) offers it, no
  requirement, level 40. Six personal "Fallen Soldier" bodies in the Boneyard, one Ashen AFS Dog Tag (97464) each, any
  order: (483, 286.56, -379), (520, 283.38, -308), (507, 282.89, -321), (544, 285.58, -352), (519, 283.51, -306), (500,
  286.56, -345); one marker r55 over them (512.5, -335.5); the objective shows n/6. Turn in at Yamamoto (he takes the six):
  95000 XP, 6300 credits, one of 49616, 49536, 15301, 14861 (weapons). Look: the bodies' model and name, the tag counter.
- [ ] 1272 Stalking the Stalkers (Ligo Ashen Desert): Lieutenant Gabriel Infanger (new, 790120, Boneyard Outpost, 676,
  289.65, -505) offers it, no requirement, level 41. Destroy 1 Desert Stalker (new, 790121, "Class XI Desert Stalker", L40,
  4500 HP; counter "Desert Stalkers"): pools of one 790125 (580, 282.85, -345) and 790126 (585, 283.58, -370) by
  TaRapedia's spot (595, -354); a marker r15 on each. Turn in at Infanger: 190000 XP, 8400 credits, one of 15335, 48108,
  12125, 14534 (weapons). Look: the Stalker on the Boneyard floor, not on Ashoka's lower level under it; "Class XI Desert
  Stalker" over it.

Set 5, the Bane Conscription Base (migration `20271110000500_Ashen_conscription_base`). New trench mortar copies
790160-790163, Linker pools 790164-790168, next free id 790169; Overseer Naxveik's pool 520005 moved. The three need 1262
and 1263 done. The base and the trench have no waypoint a player holds (the Conscription Garrison is Bane's control point
16): walk north from the Ashoka Settlement waypoint through the Boneyard.

- [ ] 1352 Death from Above (Ligo Ashen Desert): Captain Akio Yamamoto (790003, Boneyard Outpost) offers it, level 41, and
  gives 6 High Grade Plastic Explosives (97491) at the accept (a bag with no room refuses the accept). Destroy Mortar 1-4: the trench pools 592199 (440.3, 288.13,
  -201.0), 592202 (490.1, 281.22, -194.2), 592203 (524.7, 283.71, -170.6), 592204 (550.6, 287.55, -130.5), west to east,
  each its own mortar copy, a marker r10 on each; objective 11 "Mortars Destroyed" n/4 (the count of Mortar 1-4 done:
  a mortar killed again does not count again), a marker r75 over the trench.
  Destroy Launcher 1-6: six personal Missile Launchers (21873) in the walled yard north of the Garrison, two rows of three
  at x 376, 400, 428 and z 128 / 144; use the Detonation Device 11 m off each launcher's point, south of the south row
  and north of the north row (devices at (376, 117), (412, 117), (428, 117), (376, 155), (416, 155), (424, 155); each
  takes one explosive); a marker r10 on each device. Turn in at Yamamoto: 200000 XP, 8600 credits, one of 12099, 15442, 14980, 48108 (weapons).
  Look: the launcher model, its facing (the model is 22 m long; facing 0 is not verified, the ground is flat for it
  either way along its row and each device stands outside it either way) and its blown state; the mortar counter.
- [ ] 1354 Turning Out the Lights (Ligo Ashen Desert): Lieutenant Gabriel Infanger (790120, Boneyard Outpost) offers it,
  level 41, and gives 3 Electromagnetic Charged Explosives (111184) at the accept. Destroy Power Generator 1-3: three
  personal small Bane generators (20594, named "Power Generator") on the plateau west of the Garrison, (318, 296.2, -14),
  (326, 296.7, -34), (314, 296.3, -52); use the Detonation Device 6 m west of each; a marker r8 on each generator. Turn in
  at Infanger: 100000 XP, 6450 credits, one of 19802, 39081, 20951, 31394 (armour). Look: the generators' look and name,
  the blown state; Naxveik (L44) stands among them.
- [ ] 1355 The Strongest Link (Ligo Ashen Desert): Lieutenant Jan Blood (510013, Boneyard Outpost) offers it, level 42,
  shareable (TaRapedia updates 2007-08-21 list "Mission is not shareable" as a known issue).
  Kill 15 Linkers (the World DB's Linker - Ashen Desert 531014, "Linker Master", L40; counter "Linkers Killed"): pools of
  three 790164 (385, 304.31, 82), 790165 (420, 299.37, 95), 790166 (466, 304.06, 132), 790167 (430, 304.13, 160), 790168
  (358, 304.16, 160) round the walled base, a marker r15 on each. Kill Overseer Naxveik (520005, L44) at (296, 296.49,
  -30), a marker r15. Turn in at Blood: 200000 XP, 8600 credits, one of 33342, 24086, 19544, 36638 (armour). Look: the
  Linkers can be hit and killed (to-fix row 2 was an Atta hit problem; Linker class 9751 not yet tried in the client).

Set 6, Formal Complaints and the AFS side (migration `20271110000600_Ashen_formal_complaints`). New: Scavenger Vakiel
Latan 790200 (576, 248.65, -321) and Shinichiro Ito 790201 (560, 248.65, -320) on Ashoka's lower level (the hospital's
floor), Megumi Yamamoto 790202 (-166, 296.98, -895, Shadow's Edge Post, south enclosure); next free id 790203. The Boneyard
Thrax pools 531038, 531039, 531041 made point pools on open ground. Walk to Latan and Ito from the Ashoka Settlement
hospital, the Ashoka Upper teleporter (613) or down the market's ramp (the server navmesh does not join the ramp top to
the waypoint's terrace: N18; the client floor does).

- [ ] 1254 Formal Complaints (Ligo Ashen Desert): Latan offers it, level 40. Objective 1: talk to Latan and choose:
  choice 1 (side with Latan) sets player flag 250 to 1 and 251 to 0 and opens 2 "talk to Latan" (her variant 250);
  choice 2 (hear Yamamoto first) sets 251 to 1 and 250 to 0 and opens 3 (variant 251). Hidden objective 4 is done by 2 or 3.
  Turn in at Latan: 45000 XP, 4100 credits, one of 111029 x3, 47600, 111019 x3, 45063 x6. Flag 250 leads to 1264-1266
  (set 7), 251 to 1258. Look: the choice window and both answer texts.
- [ ] 1258 The Human Perspective (Ligo Ashen Desert): Ito offers it after 1254 with flag 251 at 1, level 41. Talk to
  Captain Akio Yamamoto (790003, Boneyard Outpost; variant 251). Turn in at Latan: 45000 XP, 4100 credits, the 1254 stacks.
- [ ] 1259 A Bribe for Your Thoughts (Ligo Ashen Desert): Latan offers it after 1258, level 41; Latan's Package (97462) at
  the accept (a full bag refuses the accept). Give it to Yamamoto (variant 251); turn in at Yamamoto: 45000 XP, 4100
  credits, the 1254 stacks.
- [ ] 1261 Court Martial Arts (Ligo Ashen Desert): Yamamoto offers it after 1259, level 41; the package again at the
  accept. Give it to Colonel Mason Linier (510010, Shadow's Edge HQ entrance; variant 251); turn in at Linier: 45000 XP,
  4100 credits, one of 45447 x3, 111233, 111049 x3, 45064 x3.
- [ ] 1285 Dearly Departed (Ligo Ashen Desert): Megumi offers it after 1261, level 42. Yamamoto's Wedding Ring (97481): a
  personal 15 % drop off a Thrax Soldier (531008) or Thrax Ravager (531009) anywhere on Ashen Desert while 1 is open, one
  at most; markers r25 on the Boneyard Thrax pools 531038 (566, 285.1, -136), 531039 (487, 286.45, -261.3), 531041 (487,
  271.9, -219). Turn in at Yamamoto (he takes the ring): 190000 XP, 8400 credits, one of 38823, 23828, 20802, 29093
  (armour). Look: the ring drops and is picked up; the Thrax stand on the ground at the moved points.

Set 7, Latan's side of Formal Complaints (migration `20271110000700_Ashen_scavenger`). New: the Nitroglazer 790240 and
the Hominis Machina Mk XI 790241 (both level 40) in the Boneyard, pools of three 790243 (700, 282.2, -250) and 790244
(690, 281.05, -310) (Nitroglazers, east), 790245 (440, 287.89, -320) and 790246 (440, 285.32, -360) (Hominis Machina,
west); next free id 790247. Only for a character who chose Latan's side (choice 1) and finished Formal Complaints.

- [ ] 1264 Robotic Salvage Recovery (Ligo Ashen Desert): Latan offers it after 1254 done with flag 250 at 1, level 40.
  Recover 15 Intact Nitroglazer Salvage (97465) and 15 Intact Machina Salvage (97466): personal 75 % drops, one a kill,
  off the Nitroglazers and the Hominis Machina; markers r20 on the four pools. Turn in at Latan (she takes the 30): 95000
  XP, 6300 credits, one of 23698, 29113 (fix D; set 7 had 29093), 20802, 36039 (armour). Look: the robots' look, name and level (Nitroglazer 434,
  "Hominis Machina Mk XI" 7716), their attacks (the Nitroglazer's mortar), the Machina's revive (upstream action 62059,
  not tried); a player of choice 2, or one who took choice 1 and abandoned 1254, is not offered it.
- [ ] 1266 Weapon Salvage Recovery (Ligo Ashen Desert): Latan offers it after 1264, level 41. Recover 15 Thrax Rifle
  Salvage (97469) off Thrax Soldiers (531008) and 15 Thrax Grenade Launcher Salvage (97470) off Thrax Ravagers (531009):
  personal 75 % drops anywhere on Ashen Desert; markers r25 on the Boneyard Thrax pools (rifles) and on the Sheitan
  Highway Ravager pools 790085, 790086 (launchers). Turn in at Latan: 95000 XP, 6300 credits, the Incendiary Injector
  Gun 45777.
- [ ] 1265 Heavy Salvage Recovery (Ligo Ashen Desert): Latan offers it after 1266, level 42. Recover 1 Intact Stalker
  Salvage (97467) off a Desert Stalker (790121, Boneyard pools 790125, 790126) and 1 Intact Predator Salvage (97468) off
  a Desert Predator (790080, the Sheitan Highway beats): every kill drops it while it is needed; markers as 1272's and
  1248's. Turn in at Latan: 200000 XP, 6300 credits, one of the 1254 stacks.

Set 8, the AFS side of Formal Complaints (migration `20271110000800_Ashen_logistician`). No new world rows: the three
use set 7's robots and pools, the Thrax rows 531008 / 531009, set 3's Desert Predator and set 4's Desert Stalker. Only for
a character who chose Yamamoto (choice 2), finished Formal Complaints and the chain up to Dearly Departed (1285). Ito
stands on Ashoka's lower level: walk to him from the Ashoka Settlement waypoint through the Brann corridor under the
dome (fix C: mouth at (404, -472), down to the market, the east and cross corridors), or from the Ashoka hospital or the
Ashoka Upper teleporter (613). The straight line to the market ramp is walled off.

- [ ] 1267 Robotic Salvage Acquisitions (Ligo Ashen Desert): Ito offers it after 1285 and 1254 done with flag 251 at 1,
  level 42. Recover 15 Intact Nitroglazer Salvage (97465) and 15 Intact Machina Salvage (97466): personal 75 % drops off
  set 7's Nitroglazers and Hominis Machina; markers r20 on the four pools. Turn in at Ito (he takes the 30): 95000 XP,
  6300 credits, one of the Armor Modules Resist Electric / Fire / Ice / Virulent [4] (123016, 123026, 123031, 123071).
  Look: a player of choice 1, or one who took choice 2 and abandoned 1254, is not offered it; Latan offers nothing.
- [ ] 1269 Weapon Salvage Acquisitions (Ligo Ashen Desert): Ito offers it after 1267, level 42. 15 Thrax Rifle Salvage
  (97469) off Thrax Soldiers and 15 Thrax Grenade Launcher Salvage (97470) off Thrax Ravagers, personal 75 % drops
  anywhere on Ashen Desert; markers r25 on the Boneyard Thrax pools 531038, 531039, 531041 (rifles) and the highway
  Ravager pools 790085, 790086 (launchers). Turn in at Ito: 95000 XP, 6300 credits, one of Cryogenic Blade 12101, Area
  Healing Disc 119882, Sonic Pistol 14452, Pulse Staff 15220.
- [ ] 1268 Heavy Salvage Acquisitions (Ligo Ashen Desert): Ito offers it after 1269, level 42. 1 Intact Stalker Salvage
  (97467) off a Desert Stalker (Boneyard pools 790125, 790126) and 1 Intact Predator Salvage (97468) off a Desert Predator
  (the Sheitan Highway beats), every kill while needed; markers as 1265's. Turn in at Ito: 200000 XP, 6300 credits, one
  of the 1254 stacks. The chain ends (TaRapedia: title "Desert Logistician", the Targets of Opportunity's, not built).

Set 9, Stonewall Ridge (migration `20271110000900_Ashen_stonewall_ridge`). No new world rows: the salvage crate, the
consoles, the ambushers, the turret copies and the waves are scene actors on existing rows (Bane crate 7904, human monitor
9478, Thrax Soldier 531008, Thrax Ravager 531009, Desert Stalker 790121, AFS Turret 550001). Emmons stands by the
Stonewall Command tower (-62, 350.5, -414), 13 m from its ground teleporter 539. Walks east of the waypoint go round the
knee-high rise at (21.6, -437.0) (e.g. by (18.5, -429.6) and (32.8, -438.1)).

- [ ] 1275 Cycled Frequencies (Ligo Ashen Desert): Emmons offers it (no requirement), level 40. Search the Bane Dropship
  Salvage crate (537, 283.9, -267) by the Boneyard wreck at (537, 282, -279) (walk from the Ashoka Settlement waypoint):
  the Bane Radar Frequency Codes (97475). Turn in at Emmons: 95000 XP, 6300 credits, one of Sonic Rifle 14658,
  Endothermic Polarity Gun 48712, Sonic RPG Launcher 49172, Pulse Shotgun 15025. Look: the crate's look and name
  ("Bane Dropship Salvage"), the open animation, the use with a full bag (codes stay in the crate).
- [ ] 1277 On The Same Frequency (Ligo Ashen Desert): Emmons offers it after 1275, level 41. On each tower's second floor
  (ground teleporter -> upper: 539 -> 823 Command, 538 -> 824 Operations, 537 -> 825 Artillery Control 1, 540 -> 826
  Artillery Control 2) use the Radar Operations Console 4 m off the upper pad; any order. Towers 2-4: three
  Thrax Soldiers come at the tower's foot and attack. Markers at the ground teleporters. Turn in at Emmons: 190000 XP,
  8400 credits, one of Cryogenic Blade 12101, Electric Rifle 11953, Chaingun 48300, Pistol 14409. Look: each console's
  look (human monitor), name, on-state; the teleporters both ways. Risk: the ambushers spawn at the tower's foot and may
  be unable to reach a player on the second floor (about 13.4 m up, teleporter only, no stairs): they may stand below
  until the player comes down (ESTIMATE).
- [ ] 1278 King of the Hill (Ligo Ashen Desert): Emmons offers it after 1277, level 42. Four AFS Turrets of the player's
  own stand at the four batteries (the public ones hidden for the player). 1: reach the batteries (area r60 round (100.5,
  -528.4)) within 3:00 (countdown), else it fails. Then four waves: 0 s three Thrax Soldiers between batteries 2 and 3, 45 s two
  Desert Stalkers and a Ravager by battery 1, 90 s two Soldiers and two Ravagers below battery 3, 135 s two Stalkers
  and two Soldiers below battery 4; they attack the turrets. At 180 s 2 completes; the fourth turret lost (before or after the top: each loss counts) fails the mission. Turn in
  at Emmons: 190000 XP, 8400 credits, one of Bio Helmet 19673, Hazmat Gloves 20504, Reflective Gloves 37985, Motor Assist
  Boots 45843. Look: the copies over the public turrets (no doubled turret for the player; others see the public ones);
  do the waves reach and hurt the turrets on their platforms (navmesh islands); do the turrets shoot the waves; the client
  crash at a turret kill (C23: kill_swap_delay is live on the server, not on this branch); a lost turret's public one comes
  back for the player at once.

Set 10, Ida Hayner's orders (migration `20271110001000_Ashen_designer_hides`). New world rows 790360-790377: four bosses
(Sally, Molly, Trudy, Wendy, level 44, 4900 HP, one each, 50 s respawn) and three hide creatures (Lasher 790362, Beam
Manta 790367, Granitour 790373, 3 per pool, 120 s respawn) in 11 pools. Ida Hayner (pool 510011) moved 6 m off the weapon
vendor 500018, at whose x/z she stood (-161, 296.57, -710). Hides and carapaces are personal drops while objective 1 is
open (75 %, 10 at most); the pristine piece is a 100 % drop off the boss; Ida takes all at the turn-in, an abandon keeps
them. All places walked both ways on the client floor; corners in AshenDesignerHidesTests.Places.

- [ ] 1287 Designer Jewelry Gone Wrong (Ligo Ashen Desert): Ida offers it (no requirement), level 41. 10 Shiny Atta
  Carapace (97483) off set 2's Ashen Atta Soldiers / Workers (Mauna Barrens pools 790046-790049) and the Pristine Atta
  Carapace (97487) off Sally (-439, 299.63, -258) (TaRapedia's place). Turn in at Ida: 180000 XP, 8200 credits, one of
  Motor Assist legs 45986, Mech legs 35019, Bio legs 46069, Graviton legs 13043. Risk: Sally (L44) stands 20.6 m from
  Atta pool 790047 and 22.8 m from 790049 (aggro about 18 m): she may join level-40 fights there in 1242.
- [ ] 1293 All the Latest Rage! (Ligo Ashen Desert): Ida offers it after 1287, level 42. 10 Shiny Granitour Carapace
  (97484) off the Granitours of Coheri Pools (-185, 520), (-215, 525) and the Pristine Granitour Carapace (97488) off Wendy
  (-180, 286.25, 570) (TaRapedia -190, 580). Walk from the White Oasis Post waypoint. Turn in: 200000 XP, 8600 credits, one
  of Sonic Torqueshell Rifle 45773, Virulent Disperser 12077, Electric Polarity Gun 15550, Laser Pistol 14492.
- [ ] 1289 I Wouldn't Wear It, But... (Ligo Ashen Desert): Ida offers it (no requirement), level 41. 10 Lasher Leather
  Hides (97486) off the Lashers by the road west of Ashoka (330, -585), (280, -578) and the Pristine Lasher Hide (97489) off
  Molly (299, 295.08, -658), 24 m east of TaRapedia's notch (275, -659). Turn in: 180000 XP, 8200 credits, one of Cryogenic
  Injector Gun 48108, Laser Cannon 49108, Pulse Chaingun 15154, Pistol 14409.
- [ ] 1291 A New Fad (Ligo Ashen Desert): Ida offers it after 1289, level 42. 10 Beam Manta Leather Hides (97485) off the
  Beam Manta in the eastern Boneyard (764, -322), the Indra Pass (216, 486) and northeast Maji Field (-189, 635), and the
  Pristine Beam Manta Leather (97490) off Trudy (-198, 299.48, 648), at the north end of the ridge floor (TaRapedia's
  hilltop -242, 771 is not joined to the navmesh). Turn in: 190000 XP, 8400 credits, one of Electric Polarity Gun
  15550, Electric Net Gun 12131, Sonic Cannon 49172, Electric Chaingun 15111. Look: Trudy 16 m from the NE Manta pool (she
  may pull its three).

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

All ESTIMATE (set 4):
- Levels: 1262 and 1263 40, 1272 41 (the zone band, triage D5; 1272 is TaRapedia's 190000 XP mission). Infanger level 40
  (no source).
- Infanger: a copy of Mason Linier 510010 (male AFS class 3846), server-only package (his id: the client gives 1272 no
  objective conversation), 4500 HP, armour 300, standing still, rotation 0. TaRapedia names only Boneyard Outpost; the
  spot (west of Yamamoto's tent, 13 m from Blood) chosen by a probe (2026-11-09) with the set 1 criteria; one client floor
  in its column (Yamamoto's tent and the outpost's towers have floors over the ground round them).
- Blood stays where upstream has him (the outpost region's centre, on the client floor, 6 m from a wall, one floor):
  the set 1 checks pass there, so no move. He keeps upstream's row (level 10, no package): he gives and takes 1262 by id.
- The Xanx: the World DB's only Ashen Xanx row 540020 (L39, "Xanx Burrower"); any kill of it counts, also in Maji Field
  and Indra Pass. Three pools of three, radius 0, 120 s respawn, in the open middle and north of the Boneyard (no source
  for the places or counts; the World DB has no Xanx there), 40 m apart, 25 m and more from a wall. Not burrowing (triage
  M10).
- The Desert Stalker: a copy of the World DB's Stalker Overlord - Plains 520073 (class 3781, L40, 4500 HP, armour 400, its
  attacks, also its egg drop) with the client name 9321; stock look (set 21). Two pools of one, radius 0, 120 s respawn,
  17.5 m and 18.9 m from TaRapedia's spot (595, -354): that spot's column has a second floor under it (Ashoka's lower level,
  y 248.7), so the pools stand where the client has one floor. One kill is the client's count.
- 1263: the six bodies are the client's human soldier corpses (UsableTreasureDispHumCorpseMale V01-V04, 24995, 7865,
  24989, 24990) with the client's usable name 63 "Fallen Soldier", personal (as Crucible 1143): TaRapedia's five spots
  (the fourth 2.8 m north-west of (546, -354): from 5 of the 16 places 2 m round that spot a player could not see it) and a
  sixth (500, -345) among them (the log's six tags). A hidden server-only objective 2 counts the six uses (as Marshes 4695)
  and completes 1. An abandon takes the tags and the bodies.
- Rewards: as set 2. 1263's "Kinetic Staff" read as the physical staff; 1272's "Pulse Disperser" as the EMP propellant gun
  ("Disperser" is the propellant gun, as Pools' Virulent Disperser), "Incendiary Net Gun" the fire net gun of 41-45 (the
  36-40 band does not hold level 41).

All ESTIMATE (set 5):
- Levels: 1352 and 1354 41, 1355 42 (the zone band, triage D5).
- 1352: the four trench mortars are copies of the Ashen Bane Mortar 592011 (as 1249's), Mortar n = pool n west to east.
  The six launchers (the client's UsableInertDestBaneMissileLauncherV01, no static of it on the map) stand in the walled
  yard north of the Garrison ("the west side of the Conscription Base"), facing 0, each over flat navmesh ground facing
  either way along its row; the Detonation Device (7334, as Marshes' Cleaning House) 11 m off the row takes one explosive
  and blows the launcher. Six explosives, one per launcher. Objective 11 is the count of Mortar 1-4 done (an
  aggregation, as Wilderness' Survey Says).
- 1354: the generators are the client's small Bane generator 20594 with the usable name 245 "Power Generator": the Bane
  outpost generator 3857 is 17 by 27 m, three of it do not fit on the compound's plateau. Three explosives. 106-125 m
  from control point 16 (objects, not creature pools).
- 1355: the Linkers are the World DB row 531014, no copy: Linkers killed anywhere count too (the Sheitan Highway pool
  531034, the Bane Conscription Facility pools 531064, 531072, 531075, 531078, 531083, Indra Caverns 531086, 531089,
  531092).
  Five pools of three, 120 s respawn, 147 m and more from control point 16, not linked to it.
- Naxveik: moved from the World DB spot (305.4, 282.6, 84.4; Ellatha's map value, 14 m under the compound) to the
  compound's plateau (296, 296.49, -30), 136 m from control point 16: TaRapedia's /loc (300, 20) and (311, 26) have a
  second navmesh floor under the plateau's edge.
- Rewards: as set 2. "Incendiary Blade" the fire blade, "Pulse Cannon" the EMP rocket launcher, "Photonic Shotgun" the
  laser shotgun, "Cryogenic Injector" the ice injection gun.

All ESTIMATE (set 6):
- 1254: giver and receiver Latan (the client's voice; TaRapedia's infobox says Botha, triage D1). The flags stay at an
  abandon; taken again, the choice is asked again and the last one stands (as Crucible Calendar Girl).
- Levels: 1254 40, 1258, 1259, 1261 41, 1285 42 (the zone band, D5).
- Rewards: 1258 and 1259 have no item on TaRapedia: the 1254 stacks (the zone's other 45000 XP talks).
- Places: Ito 4 m from his TaRapedia /loc (556, 248, -320); Latan 16 m east of him (no source). Megumi's TaRapedia /loc
  (-195, 269, -898) is in the barracks rooms under the post, a navmesh island; the post has no tent: she stands on the
  post's floor in its south enclosure, 29 m from the loc.
- Looks: Latan a copy of Raji Lasat 510014 (Brann), Ito of Mason Linier, Megumi of Ida Hayner.
- 1259, 1261: the package is given at each accept, taken at the talk, gone at an abandon.
- 1285: the ring a 15 % drop (triage); kept at an abandon (as 1243's samples). The three Boneyard Thrax pools moved to
  open ground 14-27 m from their points and made point pools (see "Server data changed by set 6").

All ESTIMATE (set 7):
- 1264: offered after Formal Complaints done and flag 250 at 1 (both, triage D1; TaRapedia's requirement is "??"). The
  flag alone is not enough: the flags stay at an abandon of 1254.
- Levels: 1264 40, 1266 41, 1265 42 (the zone band, D5).
- The Nitroglazer and the Hominis Machina: new rows at level 40 with the Ashen level-40 hit points and armour (8409, 285);
  the World DB has neither in the band (Nitroglazers L20-28, Machina L8-14). Their attacks are the World DB rows' (the
  EWC Nitroglazer's weapon and mortar, the Torcastra Machina's weapon and revive) at the Ashen Thrax damage (247-370, the
  mortar 356-555). The Machina's look is the Torcastra Machina's. Rank Mk XI (TaRapedia "Mark XI").
- Places: two pools of three of each in the Boneyard (TaRapedia "throughout The Boneyard"; no spot named).
- Drop rates: 75 % for the 15-count salvage (the Crucible's 50-75 %), 100 % for the one-off heavy salvage. Salvage is kept
  at an abandon and taken at the turn-in.
- 1266: the launcher markers on the highway's Ravager pools (three Ravagers each); the Boneyard pools hold at most one.
- Rewards: 1264 TaRapedia's four kinds at icon 2 (Motor Assist Legs: no Uncommon below V04, so V04 29093); 1266
  TaRapedia's one item; 1265 TaRapedia names none: the 1254 stacks.

All ESTIMATE (set 8):
- 1267: offered after Dearly Departed (TaRapedia "Dearly Departed ??"), Formal Complaints done and flag 251 at 1 (triage
  D1; the chain before it already needs both: the three keep it shut on any other path).
- Levels: 42 for all three (after Dearly Departed, level 42; the zone's chain top, D5).
- XP: TaRapedia gives "?" (1267, 1269) or nothing (1268): as Latan's twins (95000, 95000, 200000). Credits 6300
  (TaRapedia for 1267 and 1269; 1268 as 1265).
- Drop rates, counts, abandon and turn-in as set 7's twins (75 %, 15; 100 %, 1).
- Rewards: 1267 "Modification: ... Resistance" read as the grade [4] armour modules (as 1274); 1269 the lowest Uncommon of
  each named kind at level 42 ("Radial" = the area healing disc, as the Pools' Death Patrol; the manufacturer names are
  not in the client tables); 1268 none named: the 1254 stacks.
- 1269: the walk to the Boneyard Thrax pool 531041 (set 6's point in a dip at (487, 271.9, -219)) climbs 0.99 m over a
  metre in and 1.01-1.05 m out. The real client walked it both ways (tester 2026-11-09 23:41-23:54), so the client-floor
  check allows 1.1 m a metre (it was 0.9 m) and 1269 marks 531041 too. The pool stays where set 6 put it.

All ESTIMATE (set 9):
- Levels 40, 41, 42 (the zone band, D5). The three not shareable.
- Rewards: the lowest Uncommon of TaRapedia's four kinds at each level; 1278's armour with TaRapedia's version numbers
  (V03, V02, V05, V09).
- 1275: one crate, the wreck nearest the Boneyard's middle of the five (the triage); its spot 12 m off the wreck's middle,
  seen from all 32 places round it.
- 1277: tower 1 = Command (Emmons': "Start with this tower here"), 2 Operations, 3 and 4 the artillery control towers; any
  order. The consoles 4 m off the upper pad (the second floors are about 11 m across; spots seen from all 16 places round them), facing not checked. The ambushes
  (the client's helper 5 "Ambushes", not written): three Thrax Soldiers at towers 2-4, none at Emmons' tower 1.
- 1278: the turrets are personal copies of the AFS Turret 550001 at the public pools' places and facings; they stand from
  the accept. The hold 180 s (the triage; TaRapedia's 3:00 is 1's countdown). Waves at 0 / 45 / 90 / 135 s, 3 / 3 / 4 / 4
  members, from the four sides (TaRapedia: "a few stalkers and some Bane"). 1's area r60 over the four platforms.

All ESTIMATE (set 10):
- Levels 41 / 42 / 41 / 42 (D5); bosses level 44, 4900 HP, armour 420 (the Ashen boss rows 520002-520007'); hide creatures copy
  the World DB rows 770008 (Lasher), 540040 (Beam Manta), 540031 (Granitour); bosses take the client classes 22627
  (Sally), 10331 (Molly), 10317 (Trudy), 25620 (Wendy) and names 9359-9362.
- Drop rates 75 % / 100 % (no source; as sets 7 and 8).
- Places: the hide pools where the client log names the area, on open floor 60 m from other hostiles and 85 m from NPCs;
  Molly 24 m east of TaRapedia's notch (stacked floor there, a Fithik pool 22 m off); Trudy at the north end of the
  reachable ridge (TaRapedia's hilltop not joined to the navmesh); the Indra Pass Manta on the floor joined to the White Oasis side
  (the Indra Pass waypoint's floor is joined to nothing); Ida 6 m off the vendor 500018.
- Rewards: the lowest Uncommon of TaRapedia's kinds at each level (1287 legs with TaRapedia's version numbers).

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

- 1262: the Xanx "digging tunnels and ambushing" (the offer) do not burrow (MawLurk is keyed by class; triage M10).
- 1262: the kills count by creature row 540020, so Xanx killed in Maji Field and Indra Pass (the same row) count too.
- 1272: "Cowards started dropping Stalkers on us" is flavour: no dropship, the pools respawn.

- 1354: the explosion of a generator does no damage to a player near it (the offer's warning; not built, triage set 5).
- 1352, 1354: the launchers and generators cannot be shot: only the Detonation Device blows them. The client lets a player
  aim at them (their classes' target flag is 1), but they are not interactable and the server drops a hit on a disabled
  object (PracticeTargetManager.TryGetTarget).
- 1355: "Hundreds of them": fifteen Linkers in five pools round the base, not a perimeter of hundreds. Linkers killed in
  the Bane Conscription Facility, Indra Caverns and on the Sheitan Highway count too (same row 531014).

- 1254: a player can change sides by abandoning 1254 before the turn-in and choosing again (the flags are set at the
  choice, the follow-ups open only at the turn-in).
- 1254: the client reminder texts 10066 / 10067 are not sent (no server reminder).
- 1285: the ring drops off any Ashen Thrax Soldier or Ravager (a drop is bound to creature rows and the map), not only
  those of the Boneyard: also those of the Sheitan Highway and the Conscription Facility.
- 1285: Megumi does not stand in the "eastern tent" (TaRapedia): see the assumptions.

- 1265: the Predator salvage comes off the Desert Predators of the Sheitan Highway (the client's log and TaRapedia), not
  "near Maji Field" (the client's offer text): no Predator stands there.
- 1264, 1266: the client gives the objectives no counter text: the log shows no n/15 count (the bag shows the stack).
- 1266: rifles and launchers drop off any Ashen Thrax Soldier or Ravager on Ashen Desert (the drop is bound to the rows and
  the map), as 1285's ring.
- 1255-1257 (the client's further flag-250 missions) are not built (triage D2): Latan's side ends with 1265.
- 1268: the title "Desert Logistician" is not given (it is the Targets of Opportunity's objective 17, not built upstream).
- 1267, 1269: no n/15 counter in the log (no counter text in the client). 1269's salvage drops off any Ashen Thrax
  Soldier / Ravager on Ashen Desert.

- 1278: no fail when the player leaves Stonewall Ridge (the client's body of 2): the server has no area-leave event
  (triage M2, D17; NOTES-missing-mechanics "Fail on leaving an area").
- 1278: the client's "Towers Lost" counter (10295) is not shown: a counter rule can only complete its objective
  (MissionRuntime.Evaluate), so the losses are counted on a hidden server-only objective 7 whose completion (the fourth)
  fails 2.
- 1278: the client's wave helpers 3-6 ("Wave 1", "Spawn 2".."4") and 1277's 5 ("Ambushes") are not written.
- 1278: a lost turret's public copy is shown again to the player at once (the hide is held by the turret copy).

- 1287, 1289, 1291, 1293: the drops are bound to the creature rows and the map, so a hide drops off any of the set's
  hide creatures on Ashen Desert (1287: off any set 2 Atta Soldier / Worker), not only in the named area.
- 1287, 1289, 1291, 1293: no n/10 counter in the log (no counter text in the client).
- 1291: Trudy not on TaRapedia's hilltop (-242, 771): it is not reachable on the navmesh.

## Server data that differs from the sources (not changed)

- Lieutenant Jan Blood 510013 is level 10 with 1000 HP (upstream), in a level 40-42 zone. Not changed: he is friendly and
  stands in the outpost, no hostile pool reaches him.

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

## Server data changed by fix job B (20271110000610)

- Thrax Overseer Exing's pool 520007 (to-fix row 5): from set 2's spot (-289, 332.98, -264) on the mesa's slope to (-260,
  308.9, -310) on the flat at the mesa's south foot, 54 m on; 1244's marker with him (-260, 309.26, -310). No real-client
  walk reached set 2's spot: every navmesh route ends on a mesa flank the client floor does not climb (more than 0.9 m a
  metre; upstream N19). The new spot is walked on the client floor (0.9 m steps at most, nothing in the way at chest
  height) from the Shadow's Edge Post waypoint, the Mauna Barrens basin and the Sheitan Highway camp; still west of the
  highway and south of the Barrens (D10). ESTIMATE: the place. Down puts set 2's pool and marker back while they are
  still the fix's.

## Server data changed by set 4 (upstream rows)

- None. Set 4 uses Blood 510013 and the Xanx row 540020 as upstream has them.

## Server data changed by set 5 (upstream rows)

- The trench mortar pools 592199, 592202-592204 (Bane_mortars) hold the copies 790160-790163 for 592011 (BaneMortarTests
  allows it). Down gives them 592011 back while they still hold the copy.
- Moved: Overseer Naxveik's pool 520005 from (305.41, 282.61, 84.41) to (296, 296.49, -30) in the generators' compound.
  Down puts it back (the exact stored values) while it still stands at the new place.

## Server data changed by set 6 (upstream rows)

- The Boneyard Thrax pools 531038 (544.2, 283.2, -120, radius 14.4), 531039 (499, 285.5, -269.3, radius 10.7) and 531041
  (502, 277.5, -198.2, radius 12.6) become point pools (radius 0) at (566, 285.1, -136), (487, 286.45, -261.3) and (487,
  271.9, -219), 14-27 m away (probe of 2026-11-09). Upstream's radius draws (Detour's random point round the circle) put
  Thrax up to 47 m from the point, onto rock tops (531038 has two navmesh floors 2.7-6 m apart) and 2-5 m off the rows'
  heights (the rows stand 1.7-2.75 m under the ground). Round each new point every navmesh floor within 17 m is one floor,
  joined to the Ashoka Settlement waypoint, on a client floor under open sky. Count, creatures and respawn as upstream.
  ESTIMATE: the places. Down puts upstream's rows back (the exact stored values) while they are still set 6's.

## Server data changed by set 7 (upstream rows)

- None. Set 7 adds its own rows only; it uses the Thrax rows 531008 / 531009, set 3's Desert Predator and set 4's Desert
  Stalker as they are, and upstream's machina_revive action 62059 and the Torcastra Machina's look 660012 by reference.

## Server data changed by fix job D (20271110000710)

- 1264's reward item 2 (Motor Assist Armor Legs): set 7's 29093 (level 38-42) to 29113 (V04 Uncommon 43-47; TaRapedia
  "Dynamo Motor Assist Armor Legs 2, green, 43"), guarded on set 7's exact row; an evidence row 4 for 1264. Down puts
  29093 back. A delta on set 7 (live): set 7's data class stays.
- Teleporter 208 (Hospital: Shadow's Edge Post, upstream row): y 269.3 to 296.5, x, z and rotation unchanged. Upstream's
  height is 27 m under the hospital's floor (client floors 296.20 / 296.50 / 300.95 / 302.27 / 307.30 at its x/z, navmesh
  296.68): a hospital return fell under the map and the fall guard put the player back at the death spot. Guarded on the
  row's exact stored values; Down puts 269.3 back. AshenHospitalTests checks every Ashen hospital and waypoint (195-198,
  207-209, 317-319, 322) on the client floor and the navmesh, and the walk 208 to and from the Shadow's Edge waypoint.
  Retest: die in Ashen Desert, take the hospital return (or Respawn at Shadow's Edge Post Hospital): the player stands in
  the hospital.

## Server data changed by set 8 (upstream rows)

- None. Set 8 adds mission content only, on the rows of sets 3, 4, 6 and 7 and the Thrax rows 531008 / 531009.

## Server data changed by set 9 (upstream rows)

- None. Set 9 adds mission content only: its objects and creatures are scene actors on existing rows (the AFS Turret
  550001, the Thrax 531008 / 531009, set 4's Desert Stalker 790121, the client classes 7904 and 9478). The public turret
  pools 550001-550004 are not changed (hidden per player while the run's copies stand).

## Server data changed by set 10 (upstream rows)

- Ida Hayner's pool 510011 moved from (-167.1, 296.27, -709.0) to (-161, 296.57, -710): she stood at the x/z of the
  weapon vendor 500018 (upstream data). Down restores the exact stored value.
