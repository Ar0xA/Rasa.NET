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
pools 790046-790051 (three Atta each; one each since fix G, 20271110001320), next free id 790052. The Mauna Barrens have
no waypoint: walk from Shadow's Edge Post (or White Oasis Post).

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
  pools of two 790085 (-213, 307.87, -302) and 790086 (-125, 314.27, -359) on the camp's west and south-east edge (fix E;
  set 3 had three each at (-180, -305) and (-140, -305), inside the camp), Soldier pools 790087 (-160, 304.19, -260)
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
  Highway Ravager pools 790085, 790086 (launchers; fix E: on the camp's edge, two each). Turn in at Latan: 95000 XP, 6300 credits, the Incendiary Injector
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
  Ravager pools 790085, 790086 (launchers; fix E: on the camp's edge, two each). Turn in at Ito: 95000 XP, 6300 credits, one of Cryogenic Blade 12101, Area
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
  Artillery Control 2) use the Radar Operations Console 5-6 m off the upper pad, on the side the lift opens to (fix E:
  tower 1 east, 2 east, 3 north-west, 4 west; walk off the pad on that side and straight to the console, not back over
  the pad); any order. The console is used only from its own floor (fix E: not from the floor under it). Towers 2-4:
  three Thrax Soldiers come on the top floor by the lift's exit and attack (fix E; set 9 had them at the tower's foot).
  Markers at the ground teleporters. Turn in at Emmons: 190000 XP, 8400 credits, one of Cryogenic Blade 12101, Electric
  Rifle 11953, Chaingun 48300, Pistol 14409. Look: each console's look (human monitor), name, on-state; the teleporters
  both ways; the console's use right after the ride up (to-fix row 12).
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
  Carapace (97487) off Sally (-439, 298.47, -298) (fix E, to-fix row 18: 40 m south of TaRapedia's (-439, -258), where
  she stood 20.6 m from Atta pool 790047 and joined the Atta fights; now 40 m and more from every other hostile pool). Turn
  in at Ida: 180000 XP, 8200 credits, one of Motor Assist legs 45986, Mech legs 35019, Bio legs 46069, Graviton legs
  13043. Retest: pull the Atta of 790049 / 790047; Sally should not come. Fix F (to-fix row 22): the camp's Workers call two
  more hostiles within 80 m (the Atta harvester warcry), so a pull at the camp is a group fight; farm the carapaces at
  1287's own pool of Ashen Atta Soldiers 790378 (three; one since fix G) (-355, 328.97, -210) on the slope east of the camp (marker 1/6), 80 m
  from the camp's pools. Sally (fix F, row 18) comes back 300 s after her death (was 50 s). Immunities (row 20): Sally takes
  nothing from Fire and Electrical (class 22627), nor do the Ashen Atta Soldiers (class 7081; the Workers take all): use
  another type (a Sonic rifle killed her, 2026-11-10).
- [ ] 1293 All the Latest Rage! (Ligo Ashen Desert): Ida offers it after 1287, level 42. 10 Shiny Granitour Carapace
  (97484) off the Granitours of Coheri Pools (-185, 520), (-215, 525) and the Pristine Granitour Carapace (97488) off Wendy
  (-180, 286.25, 570) (TaRapedia -190, 580). Walk from the White Oasis Post waypoint. Turn in: 200000 XP, 8600 credits, one
  of Sonic Torqueshell Rifle 45773, Virulent Disperser 12077, Electric Polarity Gun 15550, Laser Pistol 14492.
  Immunities (row 20): Wendy (class 25620) and the Granitours (10164) take nothing from Fire. Wendy comes back after 300 s
  (fix F).
- [ ] 1289 I Wouldn't Wear It, But... (Ligo Ashen Desert): Ida offers it (no requirement), level 41. 10 Lasher Leather
  Hides (97486) off the Lashers by the road west of Ashoka (330, -585), (280, -578) and the Pristine Lasher Hide (97489) off
  Molly (315, 283.02, -622) (fix E, to-fix row 17: set 10 had (299, 295.08, -658), reached only past the Fithik pool
  540067; now 47 m north-east of TaRapedia's notch (275, -659), the walk from the Ashoka Settlement waypoint 30 m and
  more from other hostile pools). Turn in: 180000 XP, 8200 credits, one of Cryogenic
  Injector Gun 48108, Laser Cannon 49108, Pulse Chaingun 15154, Pistol 14409. Immunities (row 20): Molly (class 10331)
  and the Lashers (7477) take nothing from Virulent and Laser. Molly comes back after 300 s (fix F).
- [ ] 1291 A New Fad (Ligo Ashen Desert): Ida offers it after 1289, level 42. 10 Beam Manta Leather Hides (97485) off the
  Beam Manta in the eastern Boneyard (770, -400; fix E: set 10's (764, -322) was walked to past the Nitroglazer pool
  790244), the Indra Pass (216, 486) and northeast Maji Field (-189, 635), and the Pristine Beam Manta Leather (97490) off
  Trudy (-250, 302.74, 632) (fix E: set 10's (-198, 299.48, 648) was 16 m from the Manta pool 790370; TaRapedia's hilltop
  -242, 771 is not joined to the navmesh). Walk to Coheri Pools and Maji Field from the White Oasis Post waypoint by the
  west ridge (-300, 620), not past the Fithik pools 540075 / 540077. Turn in: 190000 XP, 8400 credits, one of Electric Polarity Gun
  15550, Electric Net Gun 12131, Sonic Cannon 49172, Electric Chaingun 15111. Immunities (row 20): Trudy (class 10317) and
  the Beam Manta (6441) take nothing from Electrical: of the four reward weapons only the Sonic Cannon hurts them. Trudy
  comes back after 300 s (fix F).

Set 11, White Oasis Post (migration `20271110001100_Ashen_white_oasis`). New world rows 790400 Doctor Harold Meeks (-498,
282.39, 164) and 790401 Agent Hale (-516, 282.78, 176), both in the post. Lieutenant Dania Fontecilla (pool 510012) moved
7.9 m west to (-519, 283.71, 164), off the White Oasis control point's console (she stood on its spot). All four White Oasis
givers (Daris Linier, Fontecilla, Meeks, Hale) stand within 130 m of control point 17: they are gone while the Bane hold the
post, and come back when the AFS take it again. Every place is walked both ways on the client floor from the White Oasis
Post waypoint, 30 m or more outside every hostile pool's circle that is not the mission's own; corners in
AshenWhiteOasisTests.Places.

- [ ] 1295 Analyzing the Harvesters (Ligo Ashen Desert): Daris Linier offers it (no requirement), level 41. The Harvester
  Diagnostic Tool (97477) at the accept. Use the four Harvester Control Panels (your own monitors) at Maji Field's
  harvesters, any order: 1 (-305.7, 284.0, 198.1), 2 (-292, 290.71, 305), 3 (-375.5, 297.29, 394.1), 4 (-367, 298.49,
  514). Walk to 2 via (-305.7, 198.1); to 3 and 4 west round the field via (-439.1, 204.8), (-430, 300) (4 also (-425,
  470)). Turn in at Meeks: 100000 XP, 6450 credits, one of Flame Thrower 48752, Incendiary Net Gun 12125, Cryogenic Leech
  Gun 47772, Pulse Rifle 11957; Meeks takes the tool. Do not walk straight from panel 3 (or 2) to panel 4: the line passes
  through the Xanx pool 540076 (-363.9, 447.9; to-fix row 21, fix F: they notice a player within 33 m of its point and
  follow a pull up to 60 m from home, webbing from 40 m); go by (-425, 470).
- [ ] 1298 Murky Waters (Ligo Ashen Desert): Meeks offers it after 1295, level 41. Talk to Hale: choice 1 ("I can't do
  that", the repair) sets flag 258 and opens 3; choice 2 ("I agree", the poison) sets flag 257 and opens 2. Hale answers in
  that side's text and pays: 50000 XP, 4300 credits, one of Basic Med Pack x6 45063, EMP Bomb 111233, Frag Grenade x3
  45447, Cryogenic Grenade x3 111049. The choice is for good (set 12's 1299 needs 258, 1300 needs 257). Check: the client
  shows the choice dialogue and the right answer text for each flag.
- [ ] 1303 Prying Eyes (Ligo Ashen Desert): Daris Linier offers it (no requirement), level 41. Kill Overseer Ulovik
  (upstream boss 520006, level 44, 4900 HP) at (-235, 291.2, 335) between the first two harvesters; straight walk from the
  waypoint. Turn in at Daris: 95000 XP, 6300 credits, one of EMP Grenade x3, Res Trauma Kit, Concussion Grenade x3, Basic
  Med Pack x6. Risk: a level 44 boss against a level 41 player (as 1244's Exing); the nearest other pool (Fithik 540075) is
  46 m off.
- [ ] 1356 Gas Shortages (Ligo Ashen Desert): Fontecilla offers it (no requirement), level 41. Three Shaped Charges
  (111185) at the accept. On the Sheitan Embankment, three Raw Fuel Pumps (your own, class 21007, fix F; set 11 had 10190) at (-76, 282.67, 125),
  (-76, 282.75, 150), (-95, 282.8, 145), each with a Detonation Device 8.1 m off it: (-76, 133.1), (-67.9, 150), (-95,
  136.9). Use a device: it takes one charge and blows its pump. Walk east via (-260, 200), (-160, 200), (-100, 180). Turn in
  at Fontecilla: 95000 XP, 6300 credits, the same four stacks as 1303. Risk: the pumps stand inside the Embankment's Thrax
  garrison (pool 531032, radius 30, 2-3 Soldiers and Ravagers): a fight there is the mission; its dropship lands on the
  pads 6.1 m and more from the pump models and 5.6 m from the devices (the pads' models as the client places them).
  Retest (to-fix row 23, fix F): after the use the pump should show the explosion and then its wreck (set 11's class 10190
  kept its intact model).
- [ ] White Oasis Post control point 17 (real client): Daris Linier (set 1's place, -507.4, 162.4) stands 4.2 m from the
  point, about 2.3 m inside the console model's box (not moved). Click the console from the east side and look for
  Daris clipping into the model or taking the click.

Set 12, Murky Waters' two sides (migration `20271110001200_Ashen_murky_waters`). New world rows: two pools of set 10's
Lasher (790362, three each) on the ridge west of White Oasis Post, 790440 (-648, 336.06, 314) and 790441 (-655, 345.48,
360) (the client's 1300 log: "including the ridge west of White Oasis"). No NPC is new or moved. The side is for good: 1299
needs Murky Waters done with choice 1 (flag 258), 1300 and 1302 with choice 2 (flag 257); a player gets one side only.
Every place is walked both ways on the client floor, 30 m or more outside every hostile pool's circle that is not the
mission's own; corners in AshenMurkyWatersTests.Places.

- [ ] 1299 Water Purification (Ligo Ashen Desert): Meeks offers it after 1298 done by choice 1 (the repair), level 42. 12
  Granitour Water Glands (97479) off set 10's Coheri Pools Granitour (pools 790374 (-185, 520), 790375 (-215, 525)); Wendy
  drops none. Walk from the White Oasis Post waypoint round the west of Maji Field: (-439.1, 204.8), (-430, 300), (-425,
  470), the ridge (-300, 620), and to the first pool by (-250, 540) (the straight way passes Wendy and the Xanx / Tree Mite
  camps). Turn in at Meeks: 95000 XP, 6300 credits, one of EMP Grenade x3, Res Trauma Kit, Concussion Grenade x3, Basic Med
  Pack x6.
- [ ] 1300 Neurotoxins (Ligo Ashen Desert): Hale offers it after 1298 done by choice 2 (the poison), level 42. 12 Lasher
  Poison Glands (97480) off any of set 10's Lashers: the ridge pools west of the post (straight walk from the waypoint,
  about 350 m: the navmesh goes round to the north) or set 10's two pools west of Ashoka; Molly drops none. Turn in at Hale:
  100000 XP, 6450 credits, one of Mech V04 Legs 34374, Graviton V02 Vest 24086, Bio V04 Vest 46037, Stealth V04 Vest 40631.
  Look: the ridge Lashers stand on a slope (the player comes from below: check that the abilities reach them).
  Immunities (row 20, fix F): the Lashers (class 7477) take nothing from Virulent and Laser.
- [ ] 1302 Poisoning the Wellwater (Ligo Ashen Desert): Hale offers it after 1300 (flag 257), level 42. Four Water
  Filtration Systems (97495) at the accept. Use the four Harvester Control Panels (your own, on 1295's four places; 1295's
  own panels are gone after its turn-in): each takes one system. Same walks as 1295. Turn in at Hale: 45000 XP, 4000
  credits, one of the Resist Fire / Ice / Virulent / Electric [4] armour modules. Do not GM-reset 1295 (`.resetmission`)
  while 1302 is open: both missions' own panels would then stand at each place (two own panels per place).
- [ ] 1300 ridge pool 790440 (-648, 336.06, 314): watch point. A line-of-sight sample from the walk up (20, 25 and 30 m
  off, chest height) finds it hidden (the slope's surfaces 3-9 m in front of the player); 790441 is seen. Check in the
  real client that the Lashers there can be targeted from below, or from where a player stands.
- Set 10's walks (tests only, no place moved): with the whole walk now kept 30 m off other camps, the north-east Maji
  Field Beam Manta, Trudy, both Coheri Pools Granitour and Wendy go round the west of Maji Field first ((-439.1, 204.8),
  (-430, 300), (-425, 470), then the ridge (-300, 620)); the first Granitour pool by (-250, 540) both ways (off Trudy);
  the Indra Pass Beam Manta east by the south of Maji Field ((-260, 200), (-160, 200)) before set 10's Indra Pass corners
  (the straight way passed 5.3 m from Overseer Ulovik).

Set 13, Indra Pass (migration `20271110001300_Ashen_indra_pass`; places moved by fix G, `20271110001320_Ashen_fix_g`).
New NPCs: Surveyor Malya Odesha 790480 (115, 304.69, 450) and Researcher Endala Berish 790481 (112, 304.54, 458), 40 m
west of the valley's south entry, where set 10's way from the White Oasis Post waypoint comes in (copies of Raji Lasat's
Brann row, level 43). No hostile creature is new or moved by set 13. Next free id 790482. God of Storms and The Bonds of Blood are
exclusive: a player gets one side. Fix G (to-fix row 24): the real client could not climb set 13's way from the valley to
the Indra Pass waypoint (52-59 degree terrain; the client climbs 55 at most), and no way in to the waypoint's floor was
found outside hostile reach (N23), so the NPCs and the four resistors that stood there are in the valley now. Every walk
below is the client's floor, checked both ways with the client's slope limit, 30 m or more outside every hostile pool's
circle (AshenIndraPassTests.Walks): the NPCs from the valley's south entry, Veyon and the resistors from Odesha (up east
to the valley's south rim by (139, 450), (145, 456), (170, 479), then down).

- [ ] 1280 Missing Scientists (Ligo Ashen Desert): Odesha offers it, level 41. Search Researcher Veyon's body ("Corpse of
  Researcher Veyon", your own) in the valley at (178, 315.73, 536): it gives the Indra Lightning Resistor Codes (97476).
  A full bag leaves the codes on the body (free a slot and search again). Turn in at Odesha: 95000 XP, 6300 credits, one
  of Bio Vest 19286, Stealth Gloves 38952, Graviton Gloves 23698, Hazmat Helmet 20653; she takes the codes.
- [ ] 1281 God of Storms (Ligo Ashen Desert): Odesha offers it after 1280, level 42 (not while 1282 is held or done). Use
  the ten Indra Lightning Resistors (your own, any order): 1 (158, 541), 2 (60, 551), 3 (201, 525), 4 (174, 462), 5 (130,
  500), 6 (176, 496), 7 (66, 599), 8 (96, 462), 9 (124, 532), 10 (96, 554) (1, 2, 3, 7 moved by fix G); each turns on and
  completes its objective.
  Turn in at Odesha: 190000 XP, 8400 credits, one of four weapons. Look: the resistor model (class 10196) on the ground
  and its on state; the tenth resistor fails an open 1282.
- [ ] 1282 The Bonds of Blood (Ligo Ashen Desert): Endala offers it after 1280, level 42 (not while 1281 is held or done).
  Find Maiek's body (a Brann corpse, your own) in the Bane Conscription Base by the power generators at (344, 288.75, -72),
  walked from the Ashoka Settlement waypoint: off the pad to the west, north up the road, east of the hump at (394, -186)
  (fix G: the real client stopped there) by (402, -200), (402, -187), (396, -177), then (352, -137), (352, -84). The search opens "Talk to Endala Berish"; talk to her: 200000 XP, 8600
  credits, one of four weapons. Finding Maiek fails an open 1281.
- [ ] Fix G walks (real client): from the valley's south entry west down to Odesha and Endala by (126, 451); from Odesha
  to the resistors up east to the rim by (139, 450), (145, 456), (170, 479), then down by (171, 494); Maiek's new way east
  of the hump at (394, -186). The Indra Pass waypoint itself is not reached on foot (N23: no way in found).
- [ ] The Atta pools of the Mauna Barrens (790046-790051) and 1287's 790378 put down one creature each (fix G): 1242's ten
  Soldiers and ten Workers and 1243's samples come on respawns (120 s).


All ESTIMATE (set 13):
- Odesha and Endala 40 m west of the valley's south entry (fix G; 85 m or more from set 10's Indra Pass Beam Manta pool), not at TaRapedia's /loc (312, 324, 293) in the cave by the
  Indra Caverns, 190 m south-east: the Indra Pass waypoint's floor and the cave mouth have no way in a player can climb
  (N23, N26). Resistors 1, 2, 3, 7 in the valley (fix G), 32 m or more from the others. Both copy Raji Lasat's row and look (no female
  Brann NPC look on the World DB); level 43 (TaRapedia's Endala); Odesha has a server-only package (790480).
- Levels 41 (1280), 42 (1281, 1282). Rewards: TaRapedia's XP and credits; the items are the lowest Uncommon template of
  each named kind in the mission's band.
- Veyon's body (the client's Brann corpse 7928 with the client's name 67) and the ten resistors (the client's class 10196
  named 68) in the valley: places of no source; Maiek's body (7928, the client's own name) 36 m from the third generator
  and 64 m from Overseer Naxveik (TaRapedia "very near Naxveik"; kept 34 m and more outside every hostile pool's circle).
- The fork: each side's end (the tenth resistor, Maiek found) fails the other if it is held (the client logs); the offers
  are exclusive (TaRapedia, God of Storms). Markers r8.

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
- 1295: the panels do not check that the player holds the diagnostic tool.
- 1295: panel 2 is 33 m and panel 4 4 m off TaRapedia's 1302 spots (a hostile camp and the view).
- 1298: the client's empty choice 3 (10486) is not offered. The repair branch (1299) and the poison chain (1300, 1302) come
  in set 12; 1297 and 1301 are not built (triage D3).
- 1298: "Murky Waters Lead In" (TaRapedia, no client id) is not built: Meeks gives 1298 himself.
- White Oasis Post: Daris Linier, Fontecilla, Meeks and Hale are gone while the Bane hold control point 17 (the server's
  existing rule for service NPCs within 130 m of a point).

- 1299, 1300: no n/12 counter in the log (no client counter text); the glands drop anywhere on Ashen Desert, not only at
  Coheri Pools / on the ridge.
- 1302: the panels do not check the systems by kind (each use takes one; a mission item cannot be destroyed).
- 1297, 1301 (the repair side's follow-ups, client only) are not built (D3): the repair side ends at 1299.
- 1280-1282: Odesha and Endala stand by the Indra Pass valley's south entry, not in the cave by the Indra Caverns
  (TaRapedia): the Indra Pass waypoint's floor has no way in (N23, fix G), the cave pocket none we can check (N26).
- 1282: Maiek 64 m from Overseer Naxveik, not "very near" him (the 34 m keep-out of the base's hostile pools).
- 1281 / 1282: the exclusive offers and the fork are offer/accept rules and a scene signal; a GM-given pair still fails
  the other side at either end.
- 1281 / 1282: a failed side keeps its own objects (resistors or Maiek's body) for good: a failed mission cannot be
  abandoned (only an Active one); a use of them counts nothing. Only a GM's gift holds both sides.

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

## Server data changed by fix job E (20271110001010)

- 1277's scene (set 9, live): the four consoles 5-6 m off their upper pads on the lift's exit side, so the walk from the
  exit keeps 2.5 m off the pad's 2 m trigger (to-fix row 12); each console's use only within 3 m of its floor
  (SceneObjectAction.MaxUseHeight, an opt-in field no other scene sets; row 13); the ambushes on the top floors (row 14).
  The scene's row is swapped only where it holds set 9's exact JSON; Down puts it back. Evidence row 4 for 1277.
- The Sheitan Highway Ravager pools (set 3's rows, live): 790085 (-180, 306.57, -305) to (-213, 307.87, -302) and 790086
  (-140, 306.34, -305) to (-125, 314.27, -359), three Ravagers each to two (the encounter tuning, user 2026-11-10: a solo
  player died twice; the pools stood 24-27 m from the camp's upstream pool 531034, radius 30, and pulled with its Linker
  and Caretaker; now 53-55 m off it, ESTIMATE). The markers of 1247 (r20), 1266 and 1269 (r25) on them move with them.
  Guarded on the rows' exact stored values; Down puts set 3's places and counts back. Evidence rows 4 for 1247, 1266, 1269.
  Retest: 1266 / 1269 launchers and 1247's Ravagers solo at the new places; the camp's Linker and Caretaker should not join.
- Set 10's pools (live, migration 20271110001000; to-fix rows 17, 18): Sally 790361 (-439, 299.63, -258) to (-439, 298.47,
  -298), Molly 790366 (299, 295.08, -658) to (315, 283.02, -622), Trudy 790372 (-198, 299.48, 648) to (-250, 302.74, 632),
  the eastern Boneyard Beam Manta 790368 (764, 305.49, -322) to (770, 327.21, -400); the markers on them (1287 2, 1289 2,
  1291 2 and 1291 1's first) move with them. Each boss is now 38 m and more from every other hostile pool, and the last
  100 m of each walk to a set 10 pool from its waypoint keep 30 m and more from the hostile pools not of its order
  (AshenFixETests); set 10's places failed it (Sally 20.6 m, Trudy 15.8 m; the walks to Molly 22.3 m, to the Boneyard
  Manta 2.2 m). Wendy and the other pools stay. Guarded on the rows' exact stored values; Down puts set 10's back.
  Evidence rows 4 for 1287, 1289, 1291. ESTIMATE: the places (TaRapedia's spots for Sally and Molly are 40 and 47 m off).

## Server data changed by fix job F (20271110001310)

- Set 10's boss pools (live, migration 20271110001000; to-fix row 18): Sally 790361, Molly 790366, Trudy 790372, Wendy
  790377 respawn in 3000 tenths (300 s), not set 10's 500 (50 s, the value of every upstream boss pool); Sally came back
  about 50 s after her death by the camp a player farms. ESTIMATE: 300 s, the World DB's most common respawn. Guarded on
  the rows' exact stored values (and their boss); Down puts 500 back.
- New pool 790378 (to-fix row 22): three Ashen Atta Soldiers (set 2's 790043), radius 0, 120 s, at (-355, 328.97, -210) on
  the slope east of the Mauna Barrens camp, with a marker of 1287's objective 1 (indicator 6, r20). The camp's Ashen Atta
  Workers (790044, a copy of the Thunderhead harvester) have the Atta harvester warcry (477: the two nearest hostile
  creatures within 80 m that are not fighting join, once a minute a Worker), which reaches every camp pool, Sally and the
  Mutated pools: each pull there became a group fight. The new pool is 79.6 m from the nearest hostile pool, 106 m from the
  Worker pools, walked both ways from the Shadow's Edge Post waypoint (ESTIMATE: the place). Its Soldiers count for 1242
  and drop 1287's carapace. Down takes the pool and the marker out. Evidence rows 5 for 1287, 1289, 1291, row 4 for 1293.
- No change at White Oasis's panel 4 (to-fix row 21): the Xanx of upstream pool 540076 (radius 15) notice a player within
  33 m of its point (its radius and the 18 m aggro range); panel 4 is 66 m off. A Xanx pulled on the way follows the fight
  up to 60 m from its home and webs from 40 m, so it reaches the panel; the straight walk from panel 3 passes 7.8 m from the
  pool's point. Moving the panel out of that reach (115 m) would put it 50 m off its harvester: the walk by (-425, 470)
  keeps out of the Xanx's notice instead (playtest note above).
- 1356's pumps (set 11's scene, live; to-fix row 23): class 10190 (UsableInertDestBaneRawFuelPumpHouseV01) to 21007
  (V02), the same model bounds, augmentation 41, wreck mesh 26121 on state 2 and explosion 24019 (usabledata); 10190 alone
  loops an intact animation (usabledata.animation (10190, 110, NULL) = 53), and a blown 10190 kept its model in the real
  client although the server sends the destroy path 110 -> 185 -> 186 -> 2; 21007's wreck showed in 1053. ESTIMATE: the
  cause (not checked in the client). The scene row is swapped only where it holds set 11's exact JSON; Down puts it back.
  Evidence row 4 for 1356.
- Set 10's and set 12's creatures' damage immunities (to-fix row 20; no change): the classes' IMMUNE_* flags (World DB
  creature_class_flag, CreatureImmunities) make Sally 22627 take nothing from Fire and Electrical, Molly 10331 from
  Virulent and Laser, Trudy 10317 from Electrical, Wendy 25620 from Fire; the hide creatures alike: Lasher 7477 (set 10's
  pools and set 12's ridge pools 790440 / 790441) Virulent and Laser, Beam Manta 6441 Electrical, Granitour 10164 Fire,
  Ashen Atta Soldier 7081 (and set 2's Mutated Atta Soldier, same class) Fire and Electrical, Ashen Atta Worker 7078 none.
  A hit of such a type shows "absorbs all the damage". The classes are reconstructions (triage D8, MS10 10.4), and the rule
  is to switch to an immune-free class of the same kind: the client has none. Every Creature_Atta_Soldier_* class (7081,
  22627, 25612, 26024, 26025) has Fire and Electrical, both Lasher classes (7477, 10331) Virulent and Laser, both Beam Manta
  classes (6441, 10317) Electrical, every Granitour class (10164, 25610, 25620) Fire; the immune-free Atta classes are
  Harvesters and Queens, another kind. So the classes stay; bring a weapon of another type (a Sonic rifle killed Sally;
  of 1291's rewards only the Sonic Cannon hurts the Mantas and Trudy). Pinned in AshenFixFTests.

## Server data changed by fix job G (20271110001320)

- Set 13's places (live, migration 20271110001300; to-fix row 24): Odesha's pool 790480 (258, 315.49, 325) -> (115, 304.69,
  450), Endala's 790481 (266, 316.46, 337) -> (112, 304.54, 458); God of Storms' resistors 1 (200, 352) -> (158, 312.2,
  541), 2 (158, 362) -> (60, 301, 551), 3 (237, 348) -> (201, 317.56, 525), 7 (246, 309) -> (66, 300.72, 599) (1281's
  scene, its exact JSON) and their markers; 1282's Endala marker on her. Cause: the real client could not climb (99, 482) ->
  (86, 469) on set 13's way from the valley to the Indra Pass waypoint: the leg runs slant up terrain of 52-59 degrees; our
  check measured only the rise along it (0.3-0.7 m a metre) and took floors up to 60 degrees. tabula_rasa.exe reads
  Client.Developer.MaxAngleToClimb, default 55 (not set in client.cfg): the check now fails two climbing samples within a
  metre on a floor over 55 degrees (AshenFixBTests.MaxClimbAngle). No way in to the waypoint's floor was found with it (from
  the valley, from Ashoka; only one through the Bane Conscription Facility's pools). ESTIMATE: the new places. Evidence
  rows 4 for 1280, 1281, 1282.
- The Atta pools (coordinator, real client 2026-11-10 22:46: a level 50 player with the Sonic rifle cannot win three Ashen
  Atta, 8409 health each, about 13000 damage in 20 s from the three, ESTIMATE from the log): set 2's 790046-790051 (Ashen
  Atta Soldiers, Workers, Mutated Atta Soldiers) and fix F's 790378 put down 1, not 3 (ESTIMATE); respawn 120 s, places and
  creatures stay. Evidence rows 4 for 1242, 1243, row 6 for 1287.
- Every UPDATE is guarded on the row's exact stored values (markers within 0.001); Down puts them back.

## Server data changed by set 8 (upstream rows)

- None. Set 8 adds mission content only, on the rows of sets 3, 4, 6 and 7 and the Thrax rows 531008 / 531009.

## Server data changed by set 9 (upstream rows)

- None. Set 9 adds mission content only: its objects and creatures are scene actors on existing rows (the AFS Turret
  550001, the Thrax 531008 / 531009, set 4's Desert Stalker 790121, the client classes 7904 and 9478). The public turret
  pools 550001-550004 are not changed (hidden per player while the run's copies stand).

## Server data changed by set 10 (upstream rows)

- Ida Hayner's pool 510011 moved from (-167.1, 296.27, -709.0) to (-161, 296.57, -710): she stood at the x/z of the
  weapon vendor 500018 (upstream data). Down restores the exact stored value.

## Server data changed by set 11 (upstream rows)

- Lieutenant Dania Fontecilla's pool 510012 moved from (-511.1, 281.76, 164.4) to (-519, 283.71, 164): she stood on the
  White Oasis control point's own spot (control point 17, -511.08, 283.43, 164.35), inside the console a player uses
  (upstream data). Down restores the exact stored value.
