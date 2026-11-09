# Ligo Ashen Desert missions: sources (cross-reference)

The 23 missions of the Ligo Ashen Desert quest PR, taken from the full mission cross-reference of the 1.16.5.0
client. For each mission: the client text and objectives, the sources found (TaRapedia, TR MMO DB, Ellatha,
Ten Ton Hammer, archived fan and official pages, patch notes) and a rebuild summary with the source of each
value. Values without a source are marked ESTIMATE. "This PR" rows (where present) show the data this PR adds.

Playtest status and the deviations from the original game: `docs/ashen-playtest.md`.

| Zone | Missions |
| --- | ---: |
| Ashen Desert | 23 |

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

### 1254 — Formal Complaints


- **Rebuild summary:**
  - level ESTIMATE from zone: the Ashen Desert zone level range is 40-42 — source: [Ellatha map: Ashen Desert](https://www.ellatha.com/tr/mapsview.asp?key=Ligo+Ashen+Desert) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Ashen Desert missions are level 30–41 (median 40, 10th–90th percentile) — derived from 14 missions in this file with a sourced level
  - reward: 45,000 XP; 4,100 credits; Class VIII EMP Grenade x3; Class VIII Res Trauma Kit; Class VIII Concussion Grenade x3; Class VIII Basic Med Pack x6 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Formal_Complaints)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: zone Ashen Desert only
- **Client:** Speak with Vakiel Latan of the Labbna Syndicate about the tense relationship between Captain Yamamoto and the Labbna Syndicate. You must choose between helping Vakiel Latan, or speaking with Captain Yamamoto to find out his side. Once you make your choice you can not change your mind.
  - objectives (client): Discuss the situation with Vakiel Latan; Speak with Vakiel Latan; Speak with Vakiel Latan
- **TaRapedia** [Formal Complaints](https://tabularasa.fandom.com/wiki/Formal_Complaints) [stub]: giver: Captain Amandla Botha; at: Ashoka Settlement; zone: Ashen Desert; requires: None; follow-up: The Human Perspective (If Option 2); XP: 45,000; credits: 4,100; items: Class VIII EMP Grenade x3; Class VIII Res Trauma Kit; Class VIII Concussion Grenade x3; Class VIII Basic Med Pack x6; reward from: Captain Amandla Botha
  - overview: Speak with Vakiel Latan of the Labbna Syndicate about the tense relationship between Captain Yamamoto and the Labbna Syndicate. You must choose between helping Vakiel Latan, or speaking with Captain Yamamoto to find out his side. Once you make your choice you can not change your mind.
  - objectives: • Discuss the situation with Vakiel Latan • Option 1: Side with Vakiel Latan and speak directly to Colonel Linier • Option 2: Choose to speak with Captain Yamamoto to hear his side of the story
- **TaRapedia mission list** [Ashoka Settlement mission list](https://tabularasa.fandom.com/wiki/Ashoka_Settlement_mission_list): zone Ashen Desert, area Ashoka Settlement, given by Scavenger Vakiel Latan

### 1258 — The Human Perspective


- **Rebuild summary:**
  - level: <=41 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/The_Human_Perspective)
  - level ESTIMATE from zone: the Ashen Desert zone level range is 40-42 — source: [Ellatha map: Ashen Desert](https://www.ellatha.com/tr/mapsview.asp?key=Ligo+Ashen+Desert) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Ashen Desert missions are level 30–41 (median 40, 10th–90th percentile) — derived from 14 missions in this file with a sourced level
  - reward: 45,000 XP; 4,100 credits; Class VIII Cryogenic Grenade x3; Class VIII Basic Med Pack x3; Class VIII Incendiary Grenade x3; Class VIII Advanced Med Pack x2 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/The_Human_Perspective)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: NPC Shinichiro Ito: Plains, Ashoka Settlement, /loc 556, 248, -320 — source: [TaRapedia NPC](https://tabularasa.fandom.com/wiki/Shinichiro_Ito)
- **Client:** Travel to the Boneyard Outpost and speak with Captain Yamamoto. Once you have spoke with Captain Yamamoto, return to Ashoka Settlement and see what Vakiel Latan has to say.
  - objectives (client): Speak with Captain Yamamoto
- **TaRapedia** [The Human Perspective](https://tabularasa.fandom.com/wiki/The_Human_Perspective): giver: Shinichiro Ito; at: Ashoka Settlement; zone: Ashen Desert; level: <=41; requires: Formal Complaints (If Option 2); follow-up: A Bribe for Your Thoughts; XP: 45,000; credits: 4,100; items: Class VIII Cryogenic Grenade x3; Class VIII Basic Med Pack x3; Class VIII Incendiary Grenade x3; Class VIII Advanced Med Pack x2; reward from: Scavenger Vakiel Latan
  - overview: Travel to the Boneyard Outpost and speak with Captain Yamamoto. Once you have spoke with Captain Yamamoto, return to Ashoka Settlement and see what Vakiel Latan has to say.
  - objectives: • Speak with Captain Yamamoto
- **TaRapedia mission list** [Ashoka Settlement mission list](https://tabularasa.fandom.com/wiki/Ashoka_Settlement_mission_list): zone Ashen Desert, area Ashoka Settlement, given by Shinichiro Ito
- **NPCs (TaRapedia NPC pages):**
  - [Shinichiro Ito](https://tabularasa.fandom.com/wiki/Shinichiro_Ito): Plains, Ashoka Settlement, /loc 556, 248, -320 (named as giver/receiver)

- **Chain** (explicit prerequisite links): The Human Perspective chain (7 missions), step 1
  - Leads to: A Bribe for Your Thoughts (id 1259) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/A_Bribe_for_Your_Thoughts), [TaRapedia](https://tabularasa.fandom.com/wiki/The_Human_Perspective)
- **Requires (name not matched to a mission):** Formal Complaints (If Option 2) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/The_Human_Perspective)

### 1259 — A Bribe for Your Thoughts


- **Rebuild summary:**
  - level ESTIMATE from zone: the Ashen Desert zone level range is 40-42 — source: [Ellatha map: Ashen Desert](https://www.ellatha.com/tr/mapsview.asp?key=Ligo+Ashen+Desert) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Ashen Desert missions are level 30–41 (median 40, 10th–90th percentile) — derived from 14 missions in this file with a sourced level
  - reward: 45,000 XP; 4,100 credits; Class VIII EMP Grenade x3; Class VIII Res Trauma Kit; Class VIII Concussion Grenade x3; Class VIII Basic Med Pack x6 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/A_Bribe_for_Your_Thoughts)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: NPC Captain Aiko Yamamoto: Ashen Desert, Boneyard Outpost — source: [TaRapedia NPC](https://tabularasa.fandom.com/wiki/Captain_Aiko_Yamamoto)
- **Client:** Deliver Latan's Package to Captain Yamamoto so that he can see the contents. Captain Yamamoto is in Boneyard Outpost in eastern Ashen Desert.
  - objectives (client): Delivery Latan's Package to Captain Yamamoto
- **TaRapedia** [A Bribe for Your Thoughts](https://tabularasa.fandom.com/wiki/A_Bribe_for_Your_Thoughts): giver: Scavenger Vakiel Latan; at: Ashoka Settlement; zone: Ashen Desert; requires: The Human Perspective; follow-up: Court Martial Arts; XP: 45,000; credits: 4,100; items: Class VIII EMP Grenade x3; Class VIII Res Trauma Kit; Class VIII Concussion Grenade x3; Class VIII Basic Med Pack x6; reward from: Captain Aiko Yamamoto
  - overview: Travel to the Boneyard Outpost and deliver Vakiel Latan's package to Captain Yamamoto.
  - objectives: • Deliver Latan's Package to Captain Yamamoto
- **TaRapedia mission list** [Ashoka Settlement mission list](https://tabularasa.fandom.com/wiki/Ashoka_Settlement_mission_list): zone Ashen Desert, area Ashoka Settlement, given by Scavenger Vakiel Latan
- **NPCs (TaRapedia NPC pages):**
  - [Captain Aiko Yamamoto](https://tabularasa.fandom.com/wiki/Captain_Aiko_Yamamoto): Ashen Desert, Boneyard Outpost (named as giver/receiver)

- **Chain** (explicit prerequisite links): The Human Perspective chain (7 missions), step 2
  - Requires: The Human Perspective (id 1258) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/A_Bribe_for_Your_Thoughts), [TaRapedia](https://tabularasa.fandom.com/wiki/The_Human_Perspective)
  - Leads to: Court Martial Arts (id 1261) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/A_Bribe_for_Your_Thoughts), [TaRapedia](https://tabularasa.fandom.com/wiki/Court_Martial_Arts)

### 1261 — Court Martial Arts


- **Rebuild summary:**
  - level ESTIMATE from zone: the Ashen Desert zone level range is 40-42 — source: [Ellatha map: Ashen Desert](https://www.ellatha.com/tr/mapsview.asp?key=Ligo+Ashen+Desert) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Ashen Desert missions are level 30–41 (median 40, 10th–90th percentile) — derived from 14 missions in this file with a sourced level
  - reward: 45,000 XP; 4,100 credits; Class VIII Fragmentation Grenade x3; Class VIII EMP Bomb; Class VIII Cryogenic Grenade x3; Class VIII Standard Med Pack x3 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Court_Martial_Arts)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: NPC Captain Aiko Yamamoto: Ashen Desert, Boneyard Outpost — source: [TaRapedia NPC](https://tabularasa.fandom.com/wiki/Captain_Aiko_Yamamoto)
- **Client:** Deliver Latan's Package to Colonel Linier at Shadow's Edge Post. Shadow's Edge Post can be found in the southern part of the Ashen Desert.
  - objectives (client): Deliver Latan's Package to Colonel Linier
- **TaRapedia** [Court Martial Arts](https://tabularasa.fandom.com/wiki/Court_Martial_Arts): giver: Captain Aiko Yamamoto; at: Boneyard Outpost; zone: Ashen Desert; requires: A Bribe for Your Thoughts; follow-up: None; XP: 45,000; credits: 4,100; items: Class VIII Fragmentation Grenade x3; Class VIII EMP Bomb; Class VIII Cryogenic Grenade x3; Class VIII Standard Med Pack x3; reward from: Colonel Mason Linier
  - overview: Deliver Latan's Package to Colonel Linier at Shadow's Edge Post. Shadow's Edge Post can be found in the southern part of the Ashen Desert.
  - objectives: • Deliver Latan's Package to Colonel Linier
- **TaRapedia mission list** [Boneyard Outpost mission list](https://tabularasa.fandom.com/wiki/Boneyard_Outpost_mission_list): zone Ashen Desert, area Boneyard Outpost, given by Captain Aiko Yamamoto
- **NPCs (TaRapedia NPC pages):**
  - [Captain Aiko Yamamoto](https://tabularasa.fandom.com/wiki/Captain_Aiko_Yamamoto): Ashen Desert, Boneyard Outpost (named as giver/receiver)

- **Chain** (explicit prerequisite links): The Human Perspective chain (7 missions), step 3
  - Requires: A Bribe for Your Thoughts (id 1259) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/A_Bribe_for_Your_Thoughts), [TaRapedia](https://tabularasa.fandom.com/wiki/Court_Martial_Arts)
  - Leads to: Dearly Departed (id 1285) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Dearly_Departed)

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

### 1285 — Dearly Departed


- **Rebuild summary:**
  - level ESTIMATE from zone: the Ashen Desert zone level range is 40-42 — source: [Ellatha map: Ashen Desert](https://www.ellatha.com/tr/mapsview.asp?key=Ligo+Ashen+Desert) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Ashen Desert missions are level 30–41 (median 40, 10th–90th percentile) — derived from 14 missions in this file with a sourced level
  - reward: 190,000 XP; 8,400 credits — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Dearly_Departed)
  - drops / mission items: Yamamoto's Wedding Ring: Overview: Yamamoto's Wedding Ring was lost during a battle with the Bane. Captain Aiko Yamamoto kept it as a memento of his wife, who was slain at their hands. It … — source: [TaRapedia item](https://tabularasa.fandom.com/wiki/Yamamoto%27s_Wedding_Ring)
  - drops / mission items: Yamamoto's Wedding Ring can be found on one of the many Thrax in the region — source: client text
  - drops / mission items: The wedding ring is a random drop off Thrax in the area — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Dearly_Departed)
  - location: NPC Megumi Yamamoto: Ashen Desert, Shadow's Edge Post — source: [TaRapedia NPC](https://tabularasa.fandom.com/wiki/Megumi_Yamamoto)
- **Client:** Recover Captain Yamamoto's lost wedding ring, which was misplaced while he was fighting Thrax in the Boneyard. Yamamoto's Wedding Ring can be found on one of the many Thrax in the region. Return the ring to Captain Yamamoto once you have found it.
  - objectives (client): Recovery Yamamoto's Ring
- **TaRapedia** [Dearly Departed](https://tabularasa.fandom.com/wiki/Dearly_Departed): giver: Megumi Yamamoto; at: Shadow's Edge Post; zone: Ashen Desert; requires: Court Martial Arts; follow-up: None; XP: 190,000; credits: 8,400; reward from: Megumi Yamamoto
  - overview: Recover Captain Yamamoto's lost wedding ring, which was misplaced while he was fighting Thrax in the Boneyard. Yamamoto's Wedding Ring can be found on one of the many Thrax in the region. Return the ring to Captain Yamamoto once you have found it.
  - objectives: • Recover Yamamoto's Ring • x/1
  - walkthrough: The wedding ring is a random drop off Thrax in the area.
- **TaRapedia mission list** [Shadow's Edge Post mission list](https://tabularasa.fandom.com/wiki/Shadow%27s_Edge_Post_mission_list): zone Ashen Desert, area Shadow's Edge Post, given by Megumi Yamamoto
- **NPCs (TaRapedia NPC pages):**
  - [Megumi Yamamoto](https://tabularasa.fandom.com/wiki/Megumi_Yamamoto): Ashen Desert, Shadow's Edge Post (named as giver/receiver)
- **Mission items (TaRapedia item pages):**
  - [Yamamoto's Wedding Ring](https://tabularasa.fandom.com/wiki/Yamamoto%27s_Wedding_Ring): Overview: Yamamoto's Wedding Ring was lost during a battle with the Bane. Captain Aiko Yamamoto kept it as a memento of his wife, who was slain at their hands. It fueled his rage in combat. His daughter, Megumi Yamamoto, asks you to find his missing ring and return it to him. == …
- **Drops / item sources:**
  - Yamamoto's Wedding Ring can be found on one of the many Thrax in the region — source: client text
  - The wedding ring is a random drop off Thrax in the area — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Dearly_Departed)

- **Chain** (explicit prerequisite links): The Human Perspective chain (7 missions), step 4
  - Requires: Court Martial Arts (id 1261) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Dearly_Departed)
  - Leads to: Robotic Salvage Acquisitions (id 1267) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Robotic_Salvage_Acquisitions)

### 1352 — Death from Above


- **Rebuild summary:**
  - level ESTIMATE from zone: the Ashen Desert zone level range is 40-42 — source: [Ellatha map: Ashen Desert](https://www.ellatha.com/tr/mapsview.asp?key=Ligo+Ashen+Desert) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Ashen Desert missions are level 30–41 (median 40, 10th–90th percentile) — derived from 14 missions in this file with a sourced level
  - reward: 200,000 XP; 8,600 credits; Vextronics Incendiary Blade; Vextronics Pulse Cannon; Vextronics Photonic Shotgun; Vitalius Cryogenic Injector Gun — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Death_from_Above)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: NPC Captain Aiko Yamamoto: Ashen Desert, Boneyard Outpost — source: [TaRapedia NPC](https://tabularasa.fandom.com/wiki/Captain_Aiko_Yamamoto)
- **Client:** Destroy the 4 Bane Mortars along the trench separating the Boneyard from the Bane Conscription Base. Then head north and destroy the 6 Long Range Missile Launchers using the High Grade Plastic Explosives given to you by Captain Yamamoto. Report back to Captain Yamamoto once all targets have been …
  - objectives (client): Destroy Mortar 1; Destroy Mortar 2; Destroy Mortar 3; Destroy Mortar 4; Destroy Launcher 1; Destroy Launcher 2; Destroy Launcher 3; Destroy Launcher 4; Destroy Launcher 5; Destroy Launcher 6 … (+1 more)
- **TaRapedia** [Death from Above](https://tabularasa.fandom.com/wiki/Death_from_Above): giver: Captain Aiko Yamamoto; at: Boneyard Outpost; zone: Ashen Desert; requires: Fallen Soldiers; Xanxless Job; follow-up: None; XP: 200,000; credits: 8,600; items: Vextronics Incendiary Blade; Vextronics Pulse Cannon; Vextronics Photonic Shotgun; Vitalius Cryogenic Injector Gun; reward from: Captain Aiko Yamamoto
  - overview: Destroy the 4 Bane Mortars along the trench separating the Boneyard from the Bane Conscription Base. Then head north and destroy the 6 Long Range Missile Launchers using the High Grade Plastic Explosives given to you by Captain Yamamoto. Report back to Captain Yamamoto once all targets have been …
  - objectives: • Destroy Mortar 1 • Destroy Mortar 2 • Destroy Mortar 3 • Destroy Mortar 4 • Destroy Launcher 1 • Destroy Launcher 2 • Destroy Launcher 3 • Destroy Launcher 4 • Destroy Launcher 5 • Destroy Launcher 6
- **TaRapedia mission list** [Boneyard Outpost mission list](https://tabularasa.fandom.com/wiki/Boneyard_Outpost_mission_list): zone Ashen Desert, area Boneyard Outpost, given by Captain Aiko Yamamoto
- **IGN TR boards** [vnboards.ign.com/tabula_rasa_general_board/b22750/106660985/p1/](https://web.archive.org/web/20081013130601/http://vnboards.ign.com/tabula_rasa_general_board/b22750/106660985/p1/): “s Commando Guide, Logos, LvL 50 Crafting Recipes Locations, Main Page, Media, Medic, Paradise Lost, Planets, Player Compiled Cloning Tips, Predator: "Death from Above", Quick Guide, Ranger, Recruit, Roleplay Guides, Rules, Sanctus Grotto, Sandbox, Sapper, Sarah Begins, Skills, Sniper, Soldier, Specialist, Spy, Stalker: "Battlefield Giants", Submissions Page, System Requirements, Tabula Rasa Art Director Creature Concepts, Technical Guides, The …”
- **IGN TR Vault** [tabularasavault.ign.com/wiki/index.php/Predator:_%22Death_from_Above%2 …](https://web.archive.org/web/20080820092639/http://tabularasavault.ign.com/wiki/index.php/Predator:_%22Death_from_Above%22): “Predator: "Death from Above" -- Tabula Rasa Vault / History: Predator: "Death from Above" / Predator: "Death from Above" / Predators are the mechanical airborne weapons of the Bane army. Whether launched from orbit or from secured ground locations, the Predator is a swing-role (in-flight multi-mission ready) offensive platform that is capable of inflicting aggressive and devastating ground attacks. Equipped with forward-mounted searchlights and …”
- **RGTR official site** [www.rgtr.com:80/about_the_game/know_your_enemy/know_your_enemy_1.html](https://web.archive.org/web/20080831023519/http://www.rgtr.com:80/about_the_game/know_your_enemy/know_your_enemy_1.html): “ers are rarely deployed in urban or icy environments. Though slow and easily targeted, Stalkers can withstand massive amounts of damage. / Predator: "Death from Above" / Predators are the mechanical airborne weapons of the Bane army. Whether launched from orbit or from secured ground locations, the Predator is a swing-role (in-flight multi-mission ready) offensive platform that is capable of inflicting aggressive and devastating ground attacks. …”
- **NPCs (TaRapedia NPC pages):**
  - [Captain Aiko Yamamoto](https://tabularasa.fandom.com/wiki/Captain_Aiko_Yamamoto): Ashen Desert, Boneyard Outpost (named as giver/receiver)

- **Chain** (explicit prerequisite links): Fallen Soldiers chain (9 missions), step 2
  - Requires: Xanxless Job (id 1262) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Death_from_Above)
  - Requires: Fallen Soldiers (id 1263) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Death_from_Above), [TaRapedia](https://tabularasa.fandom.com/wiki/Fallen_Soldiers)

### 1354 — Turning Out the Lights


- **Instance mentioned:** Bane Conscription Facility — the name appears in the client mission text or the TaRapedia page; not shown to happen there (ESTIMATE)
- **Rebuild summary:**
  - level ESTIMATE from zone: the Ashen Desert zone level range is 40-42 — source: [Ellatha map: Ashen Desert](https://www.ellatha.com/tr/mapsview.asp?key=Ligo+Ashen+Desert) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Ashen Desert missions are level 30–41 (median 40, 10th–90th percentile) — derived from 14 missions in this file with a sourced level
  - reward: 100,000 XP; 6,450 credits — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Turning_Out_the_Lights)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: zone Ashen Desert only
- **Client:** Lieutenant Infanger wants you to infiltrate the Bane Conscription Base and destroy the three power generators being used to collect electrical energy from Indra Pass and power the base. Once these generators have been destroyed, report back to Lieutenant Infanger.
  - objectives (client): Destroy Power Generator 1; Destroy Power Generator 2; Destroy Power Generator 3
- **TaRapedia** [Turning Out the Lights](https://tabularasa.fandom.com/wiki/Turning_Out_the_Lights): giver: Lieutenant Gabriel Infanger; at: Boneyard Outpost; zone: Ashen Desert; requires: Fallen Soldiers; Xanxless Job; follow-up: None; XP: 100,000; credits: 6,450; reward from: Lieutenant Gabriel Infanger
  - overview: Lieutenant Infanger wants you to infiltrate the Bane Conscription Base and destroy the three power generators being used to collect electrical energy from Indra Pass and power the base. Once these generators have been destroyed, report back to Lieutenant Infanger.
  - objectives: • Destroy Power Generator 1 • Destroy Power Generator 2 • Destroy Power Generator 3
- **TaRapedia mission list** [Boneyard Outpost mission list](https://tabularasa.fandom.com/wiki/Boneyard_Outpost_mission_list): zone Ashen Desert, area Boneyard Outpost, given by Lieutenant Gabriel Infanger

- **Chain** (explicit prerequisite links): Fallen Soldiers chain (9 missions), step 2
  - Requires: Xanxless Job (id 1262) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Turning_Out_the_Lights)
  - Requires: Fallen Soldiers (id 1263) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Turning_Out_the_Lights)

### 1355 — The Strongest Link

- **Note:** the Ten Ton Hammer lines (Sgt. Wolfe, level 30, Linker Commander Casso) and "Requires: Look Before You Sabotage" below are the Mires mission of the same name (1307), not this one. This mission: Lieutenant Jan Blood; requires Fallen Soldiers and Xanxless Job; 15 Linkers (TaRapedia, PlayTR patch notes 2007-12-11).


- **Rebuild summary:**
  - level: guide mentions “ers, too, for that matter). The boss and the caretakers are level 30 while the other linkers are level 29. A” (context only; may be a creature or item level) — source: [Ten Ton Hammer](https://www.tentonhammer.com/guides/tabula-rasa-energy-center-guide)
  - level ESTIMATE from zone: the Ashen Desert zone level range is 40-42 — source: [Ellatha map: Ashen Desert](https://www.ellatha.com/tr/mapsview.asp?key=Ligo+Ashen+Desert) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Ashen Desert missions are level 30–41 (median 40, 10th–90th percentile) — derived from 14 missions in this file with a sourced level
  - reward: 200,000 XP; 8,600 credits — source: [TaRapedia](https://tabularasa.fandom.com/wiki/The_Strongest_Link_%28Ashen_Desert%29)
  - reward: “Wolfe gives you the choice of a Prodigy Graviton Armor Helmet (blue), Pulsar Bio Armor Gloves (blue), Pulsar Mech Armor Legs (purple), and a Vextronics Incendiary Net Gun (blue).” — source: [Ten Ton Hammer](https://www.tentonhammer.com/guides/tabula-rasa-energy-center-guide)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: Naxveik (Thrax): /loc 304,83, zone Ashen Desert — source: [Ellatha boss NPC](https://www.ellatha.com/tr/bossnpcview.asp?key=Naxveik&id=58)
- **Client:** Travel to the Bane Conscription Base, at the north end of the Boneyard, and kill 15 Linkers, along with Overseer Naxveik, who is protecting the power generators. Once you have successfully thinned their numbers, return to Lieutenant Jan Blood and report your success.
  - objectives (client): Kill 15 Linkers; Kill Overseer Naxviek
- **TaRapedia** [The Strongest Link (Ashen Desert)](https://tabularasa.fandom.com/wiki/The_Strongest_Link_%28Ashen_Desert%29) (base-title title match): giver: Lieutenant Jan Blood; at: Boneyard Outpost; zone: Ashen Desert; requires: Fallen Soldiers; Xanxless Job; follow-up: None; XP: 200,000; credits: 8,600; reward from: Lieutenant Jan Blood
  - overview: Travel to the Bane Conscription Base, at the north end of the Boneyard, and kill 15 Linkers, along with Overseer Naxveik who is protecting the power generators. Once you have successfully thinned their numbers, return to Lieutenant Blood and report your success.
  - objectives: • Kill 15 Linkers • Kill Overseer Naxviek
  - walkthrough: Overseer Naxviek is located at /loc 311, 26.
- **TaRapedia mission list** [Boneyard Outpost mission list](https://tabularasa.fandom.com/wiki/Boneyard_Outpost_mission_list): zone Ashen Desert, area Boneyard Outpost, given by Lieutenant Jan Blood
- **Ten Ton Hammer** [tabula-rasa-energy-center-guide](https://www.tentonhammer.com/guides/tabula-rasa-energy-center-guide): “The Strongest Link where you are to defeat Linker Commander Casso and his minions. If you slowly enter the room, youll notice that the boss doesn't spawn until you are fully in the room with the door locked behind you. Be sure to read the comments from the boss as you clear the room. Ive found that EMP weapons work well against linkers (and howlers, too, for that matter). …”
- **Ten Ton Hammer** [tabula-rasa-energy-center-guide](https://www.tentonhammer.com/guides/tabula-rasa-energy-center-guide): “The Strongest Link to Sgt. Wolfe gives you the choice of a Prodigy Graviton Armor Helmet (blue), Pulsar Bio Armor Gloves (blue), Pulsar Mech Armor Legs (purple), and a Vextronics Incendiary Net Gun (blue). See the medic to heal up and sell any stuff you dont want before heading out. Note that the area you cleared before entering this instance will likely have respawned by …”
- **IGN TR boards** [vnboards.ign.com/tabula_rasa_general_board/b22750/106585290/r106594805 …](https://web.archive.org/web/20080518034441/http://vnboards.ign.com/tabula_rasa_general_board/b22750/106585290/r106594805/): “* All pipes inside Turpis Refinery should now be destroyable. / * Pets should no longer keep "The Strongest Link" from completing. / * Pets should now attack the Linker boss properly inside Energy Weapons Center.”
- **IGN TR boards** [vnboards.ign.com/tabula_rasa_general_board/b22750/107144855/p1/](https://web.archive.org/web/20081012141434/http://vnboards.ign.com/tabula_rasa_general_board/b22750/107144855/p1/): “Weapons Center with mission “The Strongest Link”. This previously would complete with the optional mission “Incursion Invasion,” sometimes breaking the ToO mission.”
- **IGN TR boards** [vnboards.ign.com:80/tabula_rasa_general_board/b22750/106459602/p1/?](https://web.archive.org/web/20080302101520/http://vnboards.ign.com:80/tabula_rasa_general_board/b22750/106459602/p1/?): “o Any mission that requires the player to loot an item from a corpse will not drop the mission loot needed when killed by a pet. / o Mission: The Strongest Link (Energy Weapons Center:Mires): Pets do not attack Linker Commander Casso or other Linkers in room / o If a player has the "Function" logos in their Tabula already then they cannot complete the objective "Retrieve the Eloh Artifact" (which is to obtain Function from the obelisk) and …”
- **PlayTR EU** [eu.rgtr.com:80/en/news_article/patch_notes_and_known_issues_11th_decem …](https://web.archive.org/web/20071218075407/http://eu.rgtr.com:80/en/news_article/patch_notes_and_known_issues_11th_december_2007): “ges”: Fixed a bug that prevented players from completing the mission if they got disconnected between setting a bomb and receiving credit / * Mission “The Strongest Link”: Linkers around the Bane Conscription Control Point now properly give player kill credit. / * Mission “The Strongest Link”: The kill requirement of Linkers has been increased from 10 to 15.”
- **PlayTR EU** [eu.rgtr.com:80/en/news_article/patch_notes_and_known_issues_26th_febru …](https://web.archive.org/web/20080303001652/http://eu.rgtr.com:80/en/news_article/patch_notes_and_known_issues_26th_february_2008): “Any mission that requires the player to loot an item from a corpse will not drop the mission loot needed when killed by a pet. / Mission: The Strongest Link (Energy Weapons Center:Mires): Pets do not attack Linker Commander Casso or other Linkers in room / If a player has the “Function” logos in their Tabula already then they cannot complete the objective “Retrieve the Eloh Artifact” (which is to obtain Function from the obelisk) and cannot …”
- **PlayTR EU** [eu.rgtr.com:80/en/news_article/patchnotes_and_known_issues_monday_28th …](https://web.archive.org/web/20080501145429/http://eu.rgtr.com:80/en/news_article/patchnotes_and_known_issues_monday_28th_april_2008): “Mires “Targets of Opportunity” – “Complete All Operations” now completes for Energy Weapons Center with mission “The Strongest Link” instead of optional mission “Incursion Invasion,” which was incorrectly used originally, sometimes breaking the ToO mission.”
- **Where (locations / coordinates):**
  - Naxveik (Thrax): /loc 304,83, zone Ashen Desert — source: [Ellatha boss NPC](https://www.ellatha.com/tr/bossnpcview.asp?key=Naxveik&id=58)
- **Ellatha boss NPC** [Naxveik](https://www.ellatha.com/tr/bossnpcview.asp?key=Naxveik&id=58): Thrax; /loc 304,83; zone Ashen Desert; needed for: Ashen Desert Targets of Opportunity (boss named in client text)

- **Chain** (explicit prerequisite links): Fallen Soldiers chain (9 missions), step 4
  - Requires: Xanxless Job (id 1262) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/The_Strongest_Link_%28Ashen_Desert%29)
  - Requires: Fallen Soldiers (id 1263) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/The_Strongest_Link_%28Ashen_Desert%29)
  - Requires: Look Before You Sabotage (id 1296) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Look_Before_You_Sabotage)

