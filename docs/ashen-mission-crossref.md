# Ligo Ashen Desert missions: sources (cross-reference)

The 9 missions of the Ligo Ashen Desert quest PR, taken from the full mission cross-reference of the 1.16.5.0
client. For each mission: the client text and objectives, the sources found (TaRapedia, TR MMO DB, Ellatha,
Ten Ton Hammer, archived fan and official pages, patch notes) and a rebuild summary with the source of each
value. Values without a source are marked ESTIMATE. "This PR" rows (where present) show the data this PR adds.

Playtest status and the deviations from the original game: `docs/ashen-playtest.md`.

| Zone | Missions |
| --- | ---: |
| Ashen Desert | 9 |

## Ashen Desert

### 1242 — Angry Angry Atta


- **Rebuild summary:**
  - level: 40 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - level ESTIMATE from zone: the Ashen Desert zone level range is 40-42 — source: [Ellatha map: Ashen Desert](https://www.ellatha.com/tr/mapsview.asp?key=Ligo+Ashen+Desert) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Ashen Desert missions are level 30–41 (median 40, 10th–90th percentile) — derived from 14 missions in this file with a sourced level
  - reward: 90000 XP; 6150 credits; choose 1 of: Laser Torqueshell Rifle, Endothermic Polarity Gun, Chaingun, Pulse Shotgun — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - reward: 90,000 XP; 6,150 credits; Eclipse Laser Torqueshell Rifle; Vextronics Endothermic Polarity Gun; Vextronics Chaingun; Vextronics Pulse Shotgun — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Angry_Angry_Atta)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: zone Ashen Desert only
- **Client:** Travel to the Mauna Barrens and kill 10 Ashen Atta Soldiers and 10 Ashen Atta Workers. Return to Lieutenant Simon Kuang once you are done.
  - objectives (client): Kill 10 Ashen Atta Soldiers; Kill 10 Atta Workers
- **This PR:** revision `ashen_1_16_5`, level 40, solo, category 10000016 (Battlefield (Ashen Desert)), giver Lieutenant Simon Kuang
  - reward: 90000 XP; 6150 credits; choose 1 of: Laser Torqueshell Rifle, Endothermic Polarity Gun, Chaingun, Pulse Shotgun
- **TaRapedia** [Angry Angry Atta](https://tabularasa.fandom.com/wiki/Angry_Angry_Atta): giver: Lieutenant Simon Kuang; at: Shadow's Edge Post; zone: Ashen Desert; requires: None; follow-up: None; XP: 90,000; credits: 6,150; items: Eclipse Laser Torqueshell Rifle; Vextronics Endothermic Polarity Gun; Vextronics Chaingun; Vextronics Pulse Shotgun; reward from: Lieutenant Simon Kuang
  - overview: Travel to the Mauna Barrens and kill 10 Ashen Atta Soldiers and 10 Ashen Atta Workers. Return to Lieutenant Simon Kuang once you are done.
  - objectives: • Kill 10 Ashen Atta Soldiers • Atta Soldiers x/10 • Kill 10 Atta Workers • Atta Workers x/10
- **TaRapedia mission list** [Shadow's Edge Post mission list](https://tabularasa.fandom.com/wiki/Shadow%27s_Edge_Post_mission_list): zone Ashen Desert, area Shadow's Edge Post, given by Lieutenant Simon Kuang

- **Chain** (explicit prerequisite links): Angry Angry Atta chain (2 missions), step 1
  - Leads to: Chemical Oversight (id 1244) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Chemical_Oversight), this PR's World data (`mission_content_definition` / `mission_reward_*`)

### 1243 — Harmful Mutations


- **Rebuild summary:**
  - level: 40 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - level ESTIMATE from zone: the Ashen Desert zone level range is 40-42 — source: [Ellatha map: Ashen Desert](https://www.ellatha.com/tr/mapsview.asp?key=Ligo+Ashen+Desert) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Ashen Desert missions are level 30–41 (median 40, 10th–90th percentile) — derived from 14 missions in this file with a sourced level
  - reward: 90000 XP; 6150 credits; choose 1 of: Mech Armor Gloves, Stealth Armor Legs, Reflective Armor Legs, Motor Assist Armor Gloves — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - reward: 90,000 XP; 6,150 credits — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Harmful_Mutations)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: zone Ashen Desert only
- **Client:** Travel to the Mauna Barrens and retrieve 4 Mutated Atta Blood Samples from the Mutated Atta Soldiers. Return the blood samples to Doctor Kwon as soon as you have collected enough.
  - objectives (client): Recover 4 Mutant Atta Blood Samples
- **This PR:** revision `ashen_1_16_5`, level 40, solo, category 10000016 (Battlefield (Ashen Desert)), giver Lieutenant Simon Kuang → Doctor Jung Kwon
  - reward: 90000 XP; 6150 credits; choose 1 of: Mech Armor Gloves, Stealth Armor Legs, Reflective Armor Legs, Motor Assist Armor Gloves
- **TaRapedia** [Harmful Mutations](https://tabularasa.fandom.com/wiki/Harmful_Mutations): giver: Lieutenant Simon Kuang; at: Shadow's Edge Post; zone: Ashen Desert; requires: None; follow-up: None; XP: 90,000; credits: 6,150; reward from: Doctor Jung Kwon
  - overview: Travel to the Mauna Barrens and retrieve 4 Mutated Atta Blood Samples from the Mutated Atta Soldiers. Return the blood samples to Doctor Kwon as soon as you have collected enough.
  - objectives: • Recover 4 Mutant Atta Blood Samples • x/4
- **TaRapedia mission list** [Shadow's Edge Post mission list](https://tabularasa.fandom.com/wiki/Shadow%27s_Edge_Post_mission_list): zone Ashen Desert, area Shadow's Edge Post, given by Lieutenant Simon Kuang

- **Chain** (explicit prerequisite links): Harmful Mutations chain (2 missions), step 1
  - Leads to: Eyes on the Ground (id 1245) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Eyes_on_the_Ground), this PR's World data (`mission_content_definition` / `mission_reward_*`)

### 1244 — Chemical Oversight


- **Rebuild summary:**
  - level: 41 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - level ESTIMATE from zone: the Ashen Desert zone level range is 40-42 — source: [Ellatha map: Ashen Desert](https://www.ellatha.com/tr/mapsview.asp?key=Ligo+Ashen+Desert) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Ashen Desert missions are level 30–41 (median 40, 10th–90th percentile) — derived from 14 missions in this file with a sourced level
  - reward: 90000 XP; 6150 credits; choose 1 of: Motor Assist Armor Boots, Stealth Armor Gloves, Bio Armor Boots, Reflective Armor Gloves — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - reward: 90,000 XP; 6,150 credits — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Chemical_Oversight)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: Exing: /loc -281, -252, zone Ashen Desert — source: [Ellatha boss NPC](https://www.ellatha.com/tr/bossnpcview.asp?key=Exing)
  - location: Exing: /loc -281, -252, zone Ashen Desert — source: [Ellatha boss NPC](https://www.ellatha.com/tr/bossnpcview.asp?key=Exing&id=59)
- **Client:** Infiltrate the Sheitan Outpost, at the north end of the Sheitan Highway. Kill Handler Overseer Exing, then report your success to Lieutenant Kuang.
  - objectives (client): Kill Thrax Overseer Exing
- **This PR:** revision `ashen_1_16_5`, level 41, solo, category 10000016 (Battlefield (Ashen Desert)), giver Lieutenant Simon Kuang
  - reward: 90000 XP; 6150 credits; choose 1 of: Motor Assist Armor Boots, Stealth Armor Gloves, Bio Armor Boots, Reflective Armor Gloves
  - prerequisites: Requires completed mission 1242
- **TaRapedia** [Chemical Oversight](https://tabularasa.fandom.com/wiki/Chemical_Oversight): giver: Lieutenant Simon Kuang; at: Shadow's Edge Post; zone: Ashen Desert; requires: Angry Angry Atta; XP: 90,000; credits: 6,150; reward from: Lieutenant Simon Kuang
  - overview: •; Infiltrate the Sheitan Outpost, at the north end of the Sheitan Highway. Kill Handler Overseer Exing, then report your success to Lieutenant Kuang.
  - objectives: • Kill Thrax Overseer Exing
  - walkthrough: Overseer Exing Spawns west of the Sheitan Highway and south of Mauna Barrens (-252.9, -241.6).
- **TaRapedia mission list** [Shadow's Edge Post mission list](https://tabularasa.fandom.com/wiki/Shadow%27s_Edge_Post_mission_list): zone Ashen Desert, area Shadow's Edge Post, given by Lieutenant Simon Kuang
- **Where (locations / coordinates):**
  - Exing: /loc -281, -252, zone Ashen Desert — source: [Ellatha boss NPC](https://www.ellatha.com/tr/bossnpcview.asp?key=Exing)
  - Exing: /loc -281, -252, zone Ashen Desert — source: [Ellatha boss NPC](https://www.ellatha.com/tr/bossnpcview.asp?key=Exing&id=59)
  - Overseer Exing Spawns west of the Sheitan Highway and south of Mauna Barrens (-252.9, -241.6). — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Chemical_Oversight)
- **Ellatha boss NPC** [Exing](https://www.ellatha.com/tr/bossnpcview.asp?key=Exing): /loc -281, -252; zone Ashen Desert; needed for: Ashen Desert Targets of Opportunity (boss named in client text)
- **Ellatha boss NPC** [Exing](https://www.ellatha.com/tr/bossnpcview.asp?key=Exing&id=59): /loc -281, -252; zone Ashen Desert; needed for: Ashen Desert Targets of Opportunity (boss named in client text)

- **Chain** (explicit prerequisite links): Angry Angry Atta chain (2 missions), step 2
  - Requires: Angry Angry Atta (id 1242) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Chemical_Oversight), this PR's World data (`mission_content_definition` / `mission_reward_*`)

### 1245 — Eyes on the Ground


- **Rebuild summary:**
  - level: 41 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - level ESTIMATE from zone: the Ashen Desert zone level range is 40-42 — source: [Ellatha map: Ashen Desert](https://www.ellatha.com/tr/mapsview.asp?key=Ligo+Ashen+Desert) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Ashen Desert missions are level 30–41 (median 40, 10th–90th percentile) — derived from 14 missions in this file with a sourced level
  - reward: 90000 XP; 6150 credits; choose 1 of: Mech Armor Boots, Graviton Armor Gloves, Hazmat Armor Boots, Bio Armor Gloves — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - reward: 90,000 XP; 6,150 credits — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Eyes_on_the_Ground)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: zone Ashen Desert only
- **Client:** Travel to the Mauna Barrens and plant the 5 Mauna Sensor Beacons in the places indicated on your map. Report back to Captain Sera Karter once you have completed this task.
  - objectives (client): Sensor Beacon 1; Sensor Beacon 2; Sensor Beacon 3; Sensor Beacon 4; Sensor Beacon 5
- **This PR:** revision `ashen_1_16_5`, level 41, solo, category 10000016 (Battlefield (Ashen Desert)), giver Captain Sera Karter
  - reward: 90000 XP; 6150 credits; choose 1 of: Mech Armor Boots, Graviton Armor Gloves, Hazmat Armor Boots, Bio Armor Gloves
  - prerequisites: Requires completed mission 1243
- **TaRapedia** [Eyes on the Ground](https://tabularasa.fandom.com/wiki/Eyes_on_the_Ground): giver: Captain Sera Karter; at: Shadow's Edge Post; zone: Ashen Desert; requires: Harmful Mutations; follow-up: None; XP: 90,000; credits: 6,150; reward from: Captain Sera Karter
  - overview: Travel to the Mauna Barrens and plant the 5 Mauna Sensor Beacons in the places indicated on your map. Report back to Captain Sera Karter once you have completed this task.
  - objectives: • Sensor Beacon 1 • Sensor Beacon 2 • Sensor Beacon 3 • Sensor Beacon 4 • Sensor Beacon 5
- **TaRapedia mission list** [Shadow's Edge Post mission list](https://tabularasa.fandom.com/wiki/Shadow%27s_Edge_Post_mission_list): zone Ashen Desert, area Shadow's Edge Post, given by Captain Sera Karter (Ashen Desert)

- **Chain** (explicit prerequisite links): Harmful Mutations chain (2 missions), step 2
  - Requires: Harmful Mutations (id 1243) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Eyes_on_the_Ground), this PR's World data (`mission_content_definition` / `mission_reward_*`)

### 1250 — The Dustiest Place on Earth


- **Rebuild summary:**
  - level: 40 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`); 30 — source: [TR MMO DB](https://web.archive.org/web/20081216162356/http://tr.mmodb.com:80/quests/the-dustiest-place-on-earth-641.php)
  - level ESTIMATE from zone: the Ashen Desert zone level range is 40-42 — source: [Ellatha map: Ashen Desert](https://www.ellatha.com/tr/mapsview.asp?key=Ligo+Ashen+Desert) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Ashen Desert missions are level 30–41 (median 40, 10th–90th percentile) — derived from 14 missions in this file with a sourced level
  - reward: 42500 XP; 4000 credits; choose 1 of: Class VIII Advanced Med Pack, Class VIII EMP Grenade, Class VIII Res Trauma Kit, Class VIII Concussion Grenade — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - reward: 42,500 XP; 4,000 credits; Class VIII Advanced Med Pack x2; Class VIII EMP Grenade x3; Class VIII Res Trauma Kit; Class VIII Concussion Grenade x3 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/The_Dustiest_Place_on_Earth)
  - reward: 4000 (the page gives no unit; probably credits — ESTIMATE) — source: [TR MMO DB](https://web.archive.org/web/20081216162356/http://tr.mmodb.com:80/quests/the-dustiest-place-on-earth-641.php)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: zone Ashen Desert only
- **Client:** Report to Colonel Mason Linier in Shadow's Edge Post, which is west of the entrance into Ashen Desert.
  - objectives (client): Report to Colonel Linier
- **This PR:** revision `ashen_1_16_5`, level 40, solo, category 10000016 (Battlefield (Ashen Desert)), giver Sergeant Bernard Ames → Colonel Mason Linier
  - reward: 42500 XP; 4000 credits; choose 1 of: Class VIII Advanced Med Pack ×2, Class VIII EMP Grenade ×3, Class VIII Res Trauma Kit, Class VIII Concussion Grenade ×3
- **TaRapedia** [The Dustiest Place on Earth](https://tabularasa.fandom.com/wiki/The_Dustiest_Place_on_Earth): giver: Sergeant Bernard Ames; at: Ashen Lookout; zone: Ashen Desert; requires: None; follow-up: None; XP: 42,500; credits: 4,000; items: Class VIII Advanced Med Pack x2; Class VIII EMP Grenade x3; Class VIII Res Trauma Kit; Class VIII Concussion Grenade x3; reward from: Colonel Mason Linier
  - overview: Report to Colonel Mason Linier in Shadow's Edge Post, which is west of the entrance into Ashen Desert.
  - objectives: • Report to Colonel Linier
- **TaRapedia mission list** [Ashen Lookout mission list](https://tabularasa.fandom.com/wiki/Ashen_Lookout_mission_list): zone Ashen Desert, area Ashen Lookout, given by Sergeant Bernard Ames
- **TR MMO DB** [The Dustiest Place on Earth](https://web.archive.org/web/20081216162356/http://tr.mmodb.com:80/quests/the-dustiest-place-on-earth-641.php): level: 30; starts at npc: Sergeant Bernard Ames; starts in zone: Ashen Desert; objectives: Report to Colonel Linier; reward: 4000
  - related mob Colonel Linier (not in the archived bestiary pages)
- **TR MMO DB NPC** [Colonel Linier](https://web.archive.org/web/20081216161858/http://tr.mmodb.com:80/bestiary/colonel-linier-1021.php): Quest NPC, zone Ashen Desert (related to this quest)
- **TR MMO DB NPC** [Sergeant Bernard Ames](https://web.archive.org/web/20081216161933/http://tr.mmodb.com:80/bestiary/sergeant-bernard-ames-1020.php): Quest NPC, location Ashen Lookout, zone Ashen Desert (starts this quest)
- **NPCs (TaRapedia NPC pages):**
  - [Sergeant Bernard Ames](https://tabularasa.fandom.com/wiki/Sergeant_Bernard_Ames): no location on page (named as giver/receiver)

### 1273 — Report to Stonewall Ridge


- **Rebuild summary:**
  - level: 40 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`); 30 — source: [TR MMO DB](https://web.archive.org/web/20081216162338/http://tr.mmodb.com:80/quests/report-to-stonewall-ridge-643.php)
  - level ESTIMATE from zone: the Ashen Desert zone level range is 40-42 — source: [Ellatha map: Ashen Desert](https://www.ellatha.com/tr/mapsview.asp?key=Ligo+Ashen+Desert) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Ashen Desert missions are level 30–41 (median 40, 10th–90th percentile) — derived from 14 missions in this file with a sourced level
  - reward: 45000 XP; 4100 credits; choose 1 of: Class VIII Incendiary Grenade, Class VIII Advanced Med Pack, Class VIII EMP Grenade, Class VIII Res Trauma Kit — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - reward: 45,000 XP; 4,100 credits; Class VIII Incendiary Grenade x3; Class VIII Advanced Med Pack x2; Class VIII EMP Grenade x3; Class VIII Res Trauma Kit — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Report_to_Stonewall_Ridge)
  - reward: 4100 (the page gives no unit; probably credits — ESTIMATE) — source: [TR MMO DB](https://web.archive.org/web/20081216162338/http://tr.mmodb.com:80/quests/report-to-stonewall-ridge-643.php)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: zone Ashen Desert only
- **Client:** Report to Captain Marcus Emmons on Stonewall Ridge.
  - objectives (client): Report to Captain Emmons
- **This PR:** revision `ashen_1_16_5`, level 40, solo, category 10000016 (Battlefield (Ashen Desert)), giver Captain Flynn Harris → Captain Marcus Emmons
  - reward: 45000 XP; 4100 credits; choose 1 of: Class VIII Incendiary Grenade ×3, Class VIII Advanced Med Pack ×2, Class VIII EMP Grenade ×3, Class VIII Res Trauma Kit
- **TaRapedia** [Report to Stonewall Ridge](https://tabularasa.fandom.com/wiki/Report_to_Stonewall_Ridge): giver: Captain Flynn Harris; at: Ashoka Settlement; zone: Ashen Desert; requires: None; follow-up: None; XP: 45,000; credits: 4,100; items: Class VIII Incendiary Grenade x3; Class VIII Advanced Med Pack x2; Class VIII EMP Grenade x3; Class VIII Res Trauma Kit; reward from: Captain Marcus Emmons
  - overview: Report to Captain Marcus Emmons on Stonewall Ridge.
  - objectives: • Report to Captain Emmons
- **TaRapedia mission list** [Ashoka Settlement mission list](https://tabularasa.fandom.com/wiki/Ashoka_Settlement_mission_list): zone Ashen Desert, area Ashoka Settlement, given by Captain Flynn Harris
- **TR MMO DB** [Report to Stonewall Ridge](https://web.archive.org/web/20081216162338/http://tr.mmodb.com:80/quests/report-to-stonewall-ridge-643.php): level: 30; starts at npc: Captain Flynn Harris; starts in zone: Ashen Desert; objectives: Report to Captain Marcus Emmons at Stonewall Ridge; reward: 4100
  - related mob Captain Marcus Emmons (not in the archived bestiary pages)
- **TR MMO DB NPC** [Captain Flynn Harris](https://web.archive.org/web/20081216161848/http://tr.mmodb.com:80/bestiary/captain-flynn-harris-1023.php): Quest NPC, location Ashoka Settlement, zone Ashen Desert (starts this quest)
- **TR MMO DB NPC** [Captain Marcus Emmons](https://web.archive.org/web/20081216161853/http://tr.mmodb.com:80/bestiary/captain-marcus-emmons-1024.php): Quest NPC, location Stonewall Ridge, zone Ashen Desert (related to this quest)

### 1274 — Fithik Infestation


- **Rebuild summary:**
  - level: 40 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - level ESTIMATE from zone: the Ashen Desert zone level range is 40-42 — source: [Ellatha map: Ashen Desert](https://www.ellatha.com/tr/mapsview.asp?key=Ligo+Ashen+Desert) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Ashen Desert missions are level 30–41 (median 40, 10th–90th percentile) — derived from 14 missions in this file with a sourced level
  - reward: 90000 XP; 6150 credits; choose 1 of: Armor Module: Resist Physical [4], Tool Module: Threat Reduction [4], Weapon Module: Debuff Electric Resist [4], Armor Module: Resist Fire [4] — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - reward: 90,000 XP; 6,150 credits; Modification: Physical Resistance; Modification: Threat Reduction; Modification: Debuff to Electric Resist; Modification: Fire Resistance — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Fithik_Infestation)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: zone Ashen Desert only
- **Client:** Captain Emmons of Stonewall Ridge wants you to kill 10 Fithik. Report back to him once you are finished.
  - objectives (client): Kill 10 Fithik
- **This PR:** revision `ashen_1_16_5`, level 40, solo, category 10000016 (Battlefield (Ashen Desert)), giver Captain Marcus Emmons
  - reward: 90000 XP; 6150 credits; choose 1 of: Armor Module: Resist Physical [4], Tool Module: Threat Reduction [4], Weapon Module: Debuff Electric Resist [4], Armor Module: Resist Fire [4]
- **TaRapedia** [Fithik Infestation](https://tabularasa.fandom.com/wiki/Fithik_Infestation): giver: Captain Marcus Emmons; at: Stonewall Ridge; zone: Ashen Desert; requires: None; follow-up: None; XP: 90,000; credits: 6,150; items: Modification: Physical Resistance; Modification: Threat Reduction; Modification: Debuff to Electric Resist; Modification: Fire Resistance; reward from: Captain Marcus Emmons
  - overview: Captain Emmons of Stonewall Ridge wants you to kill 10 Fithik. Report back to him once you are finished.
  - objectives: • Kill 10 Fithik • Kill Fithik x/10
- **TaRapedia mission list** [Stonewall Ridge mission list](https://tabularasa.fandom.com/wiki/Stonewall_Ridge_mission_list): zone Ashen Desert, area Stonewall Ridge, given by Captain Marcus Emmons

### 1283 — Good Day to Die


- **Rebuild summary:**
  - level: 40 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - level ESTIMATE from zone: the Ashen Desert zone level range is 40-42 — source: [Ellatha map: Ashen Desert](https://www.ellatha.com/tr/mapsview.asp?key=Ligo+Ashen+Desert) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Ashen Desert missions are level 30–41 (median 40, 10th–90th percentile) — derived from 14 missions in this file with a sourced level
  - reward: 45000 XP; 4100 credits; choose 1 of: Class VIII Concussion Grenade, Class VIII Basic Med Pack, Class VIII Fragmentation Grenade, Class VIII EMP Bomb — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - reward: 45,000 XP; 4,100 credits; Class VIII Concussion Grenade x3; Class VIII Basic Med Pack x6; Class VIII Fragmentation Grenade x3; Class VIII EMP Bomb — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Good_Day_to_Die)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: NPC Captain Aiko Yamamoto: Ashen Desert, Boneyard Outpost — source: [TaRapedia NPC](https://tabularasa.fandom.com/wiki/Captain_Aiko_Yamamoto)
- **Client:** Travel out to the Boneyard in the eastern Ashen Desert and report to Captain Yamamoto.
  - objectives (client): Report to Captain Yamamoto
- **This PR:** revision `ashen_1_16_5`, level 40, solo, category 10000016 (Battlefield (Ashen Desert)), giver Lt. Colonel Trent Ivan → Captain Akio Yamamoto
  - reward: 45000 XP; 4100 credits; choose 1 of: Class VIII Concussion Grenade ×3, Class VIII Basic Med Pack ×6, Class VIII Fragmentation Grenade ×3, Class VIII EMP Bomb
- **TaRapedia** [Good Day to Die](https://tabularasa.fandom.com/wiki/Good_Day_to_Die) [stub]: giver: Lt. Colonel Trent Ivan; at: Shadow's Edge Post; zone: Ashen Desert; requires: None; follow-up: None; XP: 45,000; credits: 4,100; items: Class VIII Concussion Grenade x3; Class VIII Basic Med Pack x6; Class VIII Fragmentation Grenade x3; Class VIII EMP Bomb; reward from: Captain Aiko Yamamoto
  - overview: Travel out to the Boneyard in the eastern Ashen Desert and report to Captain Yamamoto.
  - objectives: • Report to Captain Yamamoto
- **TaRapedia mission list** [Shadow's Edge Post mission list](https://tabularasa.fandom.com/wiki/Shadow%27s_Edge_Post_mission_list): zone Ashen Desert, area Shadow's Edge Post, given by Lt. Colonel Trent Ivan
- **NPCs (TaRapedia NPC pages):**
  - [Captain Aiko Yamamoto](https://tabularasa.fandom.com/wiki/Captain_Aiko_Yamamoto): Ashen Desert, Boneyard Outpost (named as giver/receiver)

### 1284 — You Can't Drink Ash


- **Rebuild summary:**
  - level: 40 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - level ESTIMATE from zone: the Ashen Desert zone level range is 40-42 — source: [Ellatha map: Ashen Desert](https://www.ellatha.com/tr/mapsview.asp?key=Ligo+Ashen+Desert) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Ashen Desert missions are level 30–41 (median 40, 10th–90th percentile) — derived from 14 missions in this file with a sourced level
  - reward: 47500 XP; 4200 credits; choose 1 of: Class VIII EMP Grenade, Class VIII Res Trauma Kit, Class VIII Concussion Grenade, Class VIII Basic Med Pack — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - reward: 47,500 XP; 4,200 credits; Class VIII EMP Grenade x3; Class VIII Res Trauma Kit; Class VIII Concussion Grenade x3; Class VIII Basic Med Pack x6 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/You_Can%27t_Drink_Ash)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: zone Ashen Desert only
- **Client:** Travel to White Oasis Outpost up in Maji Field, in the north end of Ashen Desert. Report to Captain Daris Linier for further orders.
  - objectives (client): Report to Captain Linier
- **This PR:** revision `ashen_1_16_5`, level 40, solo, category 10000016 (Battlefield (Ashen Desert)), giver Lt. Colonel Dania Caldwell → Captain Daris Linier
  - reward: 47500 XP; 4200 credits; choose 1 of: Class VIII EMP Grenade ×3, Class VIII Res Trauma Kit, Class VIII Concussion Grenade ×3, Class VIII Basic Med Pack ×6
- **TaRapedia** [You Can't Drink Ash](https://tabularasa.fandom.com/wiki/You_Can%27t_Drink_Ash): giver: Lt. Colonel Dania Caldwell; at: Shadow's Edge Post; zone: Ashen Desert; requires: None; follow-up: None; XP: 47,500; credits: 4,200; items: Class VIII EMP Grenade x3; Class VIII Res Trauma Kit; Class VIII Concussion Grenade x3; Class VIII Basic Med Pack x6; reward from: Captain Daris Linier
  - overview: Travel to White Oasis Outpost up in Maji Field, in the north end of Ashen Desert. Report to Captain Daris Linier for futher orders.
  - objectives: • Report to Captain Linier
- **TaRapedia mission list** [Shadow's Edge Post mission list](https://tabularasa.fandom.com/wiki/Shadow%27s_Edge_Post_mission_list): zone Ashen Desert, area Shadow's Edge Post, given by Lt. Colonel Dania Caldwell

