# Ligo Ashen Desert missions: sources (cross-reference)

The 15 missions of the Ligo Ashen Desert quest PR, taken from the full mission cross-reference of the 1.16.5.0
client. For each mission: the client text and objectives, the sources found (TaRapedia, TR MMO DB, Ellatha,
Ten Ton Hammer, archived fan and official pages, patch notes) and a rebuild summary with the source of each
value. Values without a source are marked ESTIMATE. "This PR" rows (where present) show the data this PR adds.

Playtest status and the deviations from the original game: `docs/ashen-playtest.md`.

| Zone | Missions |
| --- | ---: |
| Ashen Desert | 15 |

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

### 1247 — Highway to Hell


- **Rebuild summary:**
  - level ESTIMATE from zone: the Ashen Desert zone level range is 40-42 — source: [Ellatha map: Ashen Desert](https://www.ellatha.com/tr/mapsview.asp?key=Ligo+Ashen+Desert) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Ashen Desert missions are level 30–41 (median 40, 10th–90th percentile) — derived from 14 missions in this file with a sourced level
  - reward: 180,000 XP; 8,200 credits; Vextronics Electric Torqueshell Rifle; Teleract Incendiary Injector Gun; Vextronics Cryogenic RPG Launcher; ChiTech Laser Chaingun — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Highway_to_Hell)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: zone Ashen Desert only
- **Client:** Travel north of Shadow's Edge Post and kill the Thrax invading from the Sheitan Highway. You will need to kill 10 Thrax Soldiers and 10 Thrax Ravagers in order to make a sufficient dent in the Bane military. Return to Captain Karter when you are done killing the enemy.
  - objectives (client): Kill 10 Thrax Ravagers; Kill 10 Thrax Soldiers
- **TaRapedia** [Highway to Hell](https://tabularasa.fandom.com/wiki/Highway_to_Hell): giver: Captain Sera Karter; at: Shadow's Edge Post; zone: Ashen Desert; requires: None; follow-up: None; XP: 180,000; credits: 8,200; items: Vextronics Electric Torqueshell Rifle; Teleract Incendiary Injector Gun; Vextronics Cryogenic RPG Launcher; ChiTech Laser Chaingun; reward from: Captain Sera Karter
  - overview: Travel north of Shadow's Edge Post and kill the Thrax invading from the Sheitan Highway. You will need to kill 10 Thrax Soldiers and 10 Thrax Ravagers in order to make a sufficient dent in the Bane military. Return to Captain Karter when you are done killing the enemy.
  - objectives: • Kill 10 Thrax Ravagers • Thrax Ravagers x/10 • Kill 10 Thrax Soldiers • Thrax Soldiers x/10
- **TaRapedia mission list** [Shadow's Edge Post mission list](https://tabularasa.fandom.com/wiki/Shadow%27s_Edge_Post_mission_list): zone Ashen Desert, area Shadow's Edge Post, given by Captain Sera Karter (Ashen Desert)

### 1248 — Air Superiority


- **Rebuild summary:**
  - level ESTIMATE from zone: the Ashen Desert zone level range is 40-42 — source: [Ellatha map: Ashen Desert](https://www.ellatha.com/tr/mapsview.asp?key=Ligo+Ashen+Desert) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Ashen Desert missions are level 30–41 (median 40, 10th–90th percentile) — derived from 14 missions in this file with a sourced level
  - reward: 180,000 XP; 8,200 credits; Vitalius Flame Thrower; Teleract Electric Rifle; Teleract Cryogenic Leech Gun; Vextronics Electric Chaingun — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Air_Superiority)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: zone Ashen Desert only
- **Client:** Destroy a Desert Predator that is patrolling the Sheitan Highway, north of Shadow's Edge Post. Report back to Lieutenant Colonel Ivan once you are completed.
  - objectives (client): Destroy 1 Desert Predator
- **TaRapedia** [Air Superiority](https://tabularasa.fandom.com/wiki/Air_Superiority): giver: Lt. Colonel Trent Ivan; at: Shadow's Edge Post; zone: Ashen Desert; requires: None; follow-up: None; XP: 180,000; credits: 8,200; items: Vitalius Flame Thrower; Teleract Electric Rifle; Teleract Cryogenic Leech Gun; Vextronics Electric Chaingun; reward from: Lt. Colonel Trent Ivan
  - overview: Destroy a Desert Predator that is patrolling the Sheitan Highway, north of Shadow's Edge Post. Report back to Lieutenant Colonel Ivan once you are completed.
  - objectives: • Destroy 1 Desert Predator • Desert Predators x/1
- **TaRapedia mission list** [Shadow's Edge Post mission list](https://tabularasa.fandom.com/wiki/Shadow%27s_Edge_Post_mission_list): zone Ashen Desert, area Shadow's Edge Post, given by Lt. Colonel Trent Ivan

### 1249 — Artillery Annihilation


- **Rebuild summary:**
  - level ESTIMATE from zone: the Ashen Desert zone level range is 40-42 — source: [Ellatha map: Ashen Desert](https://www.ellatha.com/tr/mapsview.asp?key=Ligo+Ashen+Desert) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Ashen Desert missions are level 30–41 (median 40, 10th–90th percentile) — derived from 14 missions in this file with a sourced level
  - reward: 90,000 XP; 6,150 credits — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Artillery_Annihilation)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: zone Ashen Desert only
- **Client:** Travel to the northern part of the Sheitan Highway and take out the 4 Bane Heavy Mortar that are firing at Shadow's Edge Post. Report back to Lieutenant Colonel Caldwell once you are finished.
  - objectives (client): Destroy Mortar 1; Destroy Mortar 2; Destroy Mortar 3; Destroy Mortar 4
- **TaRapedia** [Artillery Annihilation](https://tabularasa.fandom.com/wiki/Artillery_Annihilation): giver: Lt. Colonel Dania Caldwell; at: Shadow's Edge Post; zone: Ashen Desert; requires: None; follow-up: None; XP: 90,000; credits: 6,150; reward from: Lt. Colonel Dania Caldwell
  - overview: Travel to the northern part of the Sheitan Highway and take out the 4 Bane Heavy Mortar that are firing at Shadow's Edge Post. Report back to Lieutenant Colonel Caldwell once you are finished.
  - objectives: • Bane Heavy Mortar 1 • Bane Heavy Mortar 2 • Bane Heavy Mortar 3 • Bane Heavy Mortar 4
- **TaRapedia mission list** [Shadow's Edge Post mission list](https://tabularasa.fandom.com/wiki/Shadow%27s_Edge_Post_mission_list): zone Ashen Desert, area Shadow's Edge Post, given by Lt. Colonel Dania Caldwell
- **PlayTR EU** [eu.rgtr.com:80/en/news_article/patch_notes_and_known_issues_17th_janua …](https://web.archive.org/web/20080122184400/http://eu.rgtr.com:80/en/news_article/patch_notes_and_known_issues_17th_january_2008_test_server): “Typos have been fixed in the Howling Maw Targets of Opportunity. / Typos have been fixed in the mission Artillery Annihilation. / Command Jillian and other Stealth NPCs are now properly wearing Stealth Armor instead of Graviton Armor.”

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

### 1262 — Xanxless Job


- **Rebuild summary:**
  - level: 30 — source: [TR MMO DB](https://web.archive.org/web/20081216162411/http://tr.mmodb.com:80/quests/xanxless-job-644.php)
  - level ESTIMATE from zone: the Ashen Desert zone level range is 40-42 — source: [Ellatha map: Ashen Desert](https://www.ellatha.com/tr/mapsview.asp?key=Ligo+Ashen+Desert) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Ashen Desert missions are level 30–41 (median 40, 10th–90th percentile) — derived from 14 missions in this file with a sourced level
  - reward: 95,000 XP; 6,300 credits — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Xanxless_Job)
  - reward: 6300 (the page gives no unit; probably credits — ESTIMATE) — source: [TR MMO DB](https://web.archive.org/web/20081216162411/http://tr.mmodb.com:80/quests/xanxless-job-644.php)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: zone Ashen Desert only
- **Client:** Travel to the Boneyard and kill 6 Xanx. Report to Lieutenant Jan Blood at Boneyard Outpost when you are finished.
  - objectives (client): Kill 6 Xanx
- **TaRapedia** [Xanxless Job](https://tabularasa.fandom.com/wiki/Xanxless_Job): giver: Lieutenant Jan Blood; at: Boneyard Outpost; zone: Ashen Desert; requires: None; follow-up: None; XP: 95,000; credits: 6,300; reward from: Lieutenant Jan Blood
  - overview: Travel to the Boneyard and kill 6 Xanx. Report to Lieutenant Jan Blood at Boneyard Outpost when you are finished.
  - objectives: • Kill 6 Xanx • Xanx Killed x/6
- **TaRapedia mission list** [Boneyard Outpost mission list](https://tabularasa.fandom.com/wiki/Boneyard_Outpost_mission_list): zone Ashen Desert, area Boneyard Outpost, given by Lieutenant Jan Blood
- **TR MMO DB** [Xanxless Job](https://web.archive.org/web/20081216162411/http://tr.mmodb.com:80/quests/xanxless-job-644.php): level: 30; starts at npc: Lieutenant Jan Blood; starts in zone: Ashen Desert; objectives: Kill 6 Xanx, Return to Lieutenant Jan Blood; reward: 6300

- **Chain** (explicit prerequisite links): Fallen Soldiers chain (9 missions), step 1
  - Leads to: Death from Above (id 1352) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Death_from_Above)
  - Leads to: Turning Out the Lights (id 1354) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Turning_Out_the_Lights)
  - Leads to: The Strongest Link (id 1355) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/The_Strongest_Link_%28Ashen_Desert%29)

### 1263 — Fallen Soldiers


- **Rebuild summary:**
  - level ESTIMATE from zone: the Ashen Desert zone level range is 40-42 — source: [Ellatha map: Ashen Desert](https://www.ellatha.com/tr/mapsview.asp?key=Ligo+Ashen+Desert) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Ashen Desert missions are level 30–41 (median 40, 10th–90th percentile) — derived from 14 missions in this file with a sourced level
  - reward: 95,000 XP; 6,300 credits; ChiTech Laser Torqueshell Rifle; Vextronics Kinetic Staff; Vextronics Virulent Leech Gun; Teleract Incendiary Shotgun — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Fallen_Soldiers)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: NPC Captain Aiko Yamamoto: Ashen Desert, Boneyard Outpost — source: [TaRapedia NPC](https://tabularasa.fandom.com/wiki/Captain_Aiko_Yamamoto)
- **Client:** Find the bodies of Fallen Soldiers in the Boneyard and recover their dog tags. Return the dog tags to Captain Yamamoto once you have collected 6 Ashen AFS Dog Tags.
  - objectives (client): Recover Dog Tags from Fallen Soldiers
- **TaRapedia** [Fallen Soldiers](https://tabularasa.fandom.com/wiki/Fallen_Soldiers): giver: Captain Aiko Yamamoto; at: Boneyard Outpost; zone: Ashen Desert; requires: None; follow-up: Death from Above; XP: 95,000; credits: 6,300; items: ChiTech Laser Torqueshell Rifle; Vextronics Kinetic Staff; Vextronics Virulent Leech Gun; Teleract Incendiary Shotgun; reward from: Captain Aiko Yamamoto
  - overview: Find the bodies of Fallen Soldiers in the Boneyard and recover their dog tags. Return the dog tags to Captain Yamamoto once you have collected 6 Ashen AFS Dog Tags.
  - objectives: • Recover Dog Tags from Fallen Soldiers • x/6
  - walkthrough: [Idaho, Cassiopeia, March 28, 2008] • 483, -379 • 520, -308 • 507, -321 • 546, -354 • 519, -306
- **TaRapedia mission list** [Boneyard Outpost mission list](https://tabularasa.fandom.com/wiki/Boneyard_Outpost_mission_list): zone Ashen Desert, area Boneyard Outpost, given by Captain Aiko Yamamoto
- **NPCs (TaRapedia NPC pages):**
  - [Captain Aiko Yamamoto](https://tabularasa.fandom.com/wiki/Captain_Aiko_Yamamoto): Ashen Desert, Boneyard Outpost (named as giver/receiver)

- **Chain** (explicit prerequisite links): Fallen Soldiers chain (9 missions), step 1
  - Leads to: Death from Above (id 1352) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Death_from_Above), [TaRapedia](https://tabularasa.fandom.com/wiki/Fallen_Soldiers)
  - Leads to: Turning Out the Lights (id 1354) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Turning_Out_the_Lights)
  - Leads to: The Strongest Link (id 1355) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/The_Strongest_Link_%28Ashen_Desert%29)

### 1272 — Stalking the Stalkers


- **Rebuild summary:**
  - level ESTIMATE from zone: the Ashen Desert zone level range is 40-42 — source: [Ellatha map: Ashen Desert](https://www.ellatha.com/tr/mapsview.asp?key=Ligo+Ashen+Desert) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Ashen Desert missions are level 30–41 (median 40, 10th–90th percentile) — derived from 14 missions in this file with a sourced level
  - reward: 190,000 XP; 8,400 credits; Vextronics Pulse Disperser; Vextronics Cryogenic Injector Gun; Vextronics Incendiary Net Gun; Vextronics Electric Pistol — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Stalking_the_Stalkers)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: zone Ashen Desert only
- **Client:** Travel into the Boneyard and destroy a Desert Stalker. Report back to Lieutenant Infanger once you have completed this task.
  - objectives (client): Destroy 1 Desert Stalker
- **TaRapedia** [Stalking the Stalkers](https://tabularasa.fandom.com/wiki/Stalking_the_Stalkers): giver: Lieutenant Gabriel Infanger; at: Boneyard Outpost; zone: Ashen Desert; requires: None; follow-up: None; XP: 190,000; credits: 8,400; items: Vextronics Pulse Disperser; Vextronics Cryogenic Injector Gun; Vextronics Incendiary Net Gun; Vextronics Electric Pistol; reward from: Lieutenant Gabriel Infanger
  - overview: Travel into the Boneyard and destroy a Desert Stalker. Report back to Lieutenant Infanger once you have completed this task.
  - objectives: • Destroy 1 Desert Stalker • Desert Stalkers x/1
  - walkthrough: The stalker is just northwest of the boneyard at 595, -354.
- **TaRapedia mission list** [Boneyard Outpost mission list](https://tabularasa.fandom.com/wiki/Boneyard_Outpost_mission_list): zone Ashen Desert, area Boneyard Outpost, given by Lieutenant Gabriel Infanger

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

