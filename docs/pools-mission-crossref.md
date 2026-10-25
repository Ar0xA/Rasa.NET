# Valverde Pools missions: sources (cross-reference)

The 21 missions of the Valverde Pools quest PR, taken from the full mission cross-reference of the 1.16.5.0
client. For each mission: the client text and objectives, the sources found (TaRapedia, TR MMO DB, Ellatha,
Ten Ton Hammer, archived fan and official pages, patch notes) and a rebuild summary with the source of each
value. Values without a source are marked ESTIMATE. "This PR" rows (where present) show the data this PR adds.

Playtest status and the deviations from the original game: `docs/pools-playtest.md`.

| Zone | Missions |
| --- | ---: |
| Plateau | 1 |
| Pools | 20 |

## Plateau

### 1751 — Retreads to Retreads


- **Rebuild summary:**
  - level: 33 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`); 33 — source: [TR MMO DB quest list](https://web.archive.org/web/20120731172517/http://tr.mmodb.com/quests/startingzone-pools/)
  - level ESTIMATE from zone: the Plateau zone level range is 30-34 — source: [Ellatha map: Plateau](https://www.ellatha.com/tr/Plateau_Maps_Logos.asp) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Plateau missions are level 29–33 (median 30, 10th–90th percentile) — derived from 70 missions in this file with a sourced level
  - reward: 30000 XP; 3500 credits; Class VII EMP Bomb, Class VII Power Charger, Class VII Concussion Grenade, Class VII Fragmentation Grenade — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - reward: 30,000 XP; 3500 credits; CIsss VII EMP Bomb (2); Class VII Power Charger (2); Class VII Concussion Grenade (4); Class VII Fragmentation Grenade (4) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Retreads_to_Retreads)
  - reward: 3500 (the page gives no unit; probably credits — ESTIMATE) — source: [TR MMO DB quest series list](https://web.archive.org/web/20120731165344/http://tr.mmodb.com/quests/seriesname-weapons_trafficking/)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: NPC Retread Vincent: /loc -268, 216, -812 — source: [TaRapedia NPC](https://tabularasa.fandom.com/wiki/Retread_Vincent)
- **Client:** Travel to Valverde Marshes to speak with Retread Vincent located in the Retread City about the Eloh.
  - objectives (client): Speak to Retread Vincent — Travel to Valverde Marshes to speak with Retread Vincent located at Retread City
- **This PR:** revision `plateau_1_16_5`, level 33, solo, category 10000056 (Battlefield (Plateau)), giver Amee Corman → Retread Vincent
  - reward: 30000 XP; 3500 credits; items: Class VII EMP Bomb ×2, Class VII Power Charger ×2, Class VII Concussion Grenade ×4, Class VII Fragmentation Grenade ×4
  - prerequisites: Requires completed mission 904
- **TaRapedia** [Retreads to Retreads](https://tabularasa.fandom.com/wiki/Retreads_to_Retreads): giver: Amee Corman; at: Retread Camp; zone: Pools; requires: Weapons Trafficking; follow-up: It Lies in Ruins; XP: 30,000; credits: 3500; items: CIsss VII EMP Bomb (2); Class VII Power Charger (2); Class VII Concussion Grenade (4); Class VII Fragmentation Grenade (4); reward from: Retread Vincent
  - overview: Amee Corman cannot provide you with the detailed information that she promised, so she's sending you to Retread City in the Marshes to speak to the one who can.
  - objectives: • Speak to Retread Vincent
- **TaRapedia mission list** [Retread Camp mission list](https://tabularasa.fandom.com/wiki/Retread_Camp_mission_list): zone Pools, area Retread Camp, given by Amee Corman
- **TaRapedia mission list** [Retread City mission list](https://tabularasa.fandom.com/wiki/Retread_City_mission_list): zone Marshes, area Retread City, given by Retread Vincent
- **TR MMO DB quest series** [Weapons Trafficking](https://web.archive.org/web/20120731165344/http://tr.mmodb.com/quests/seriesname-weapons_trafficking/): Retreads to Retreads (level 33, reward 3500) → Weapons Trafficking (level 33, reward 5400) (series order as listed on the page; reward unit not stated)
- **NPCs (TaRapedia NPC pages):**
  - [Retread Vincent](https://tabularasa.fandom.com/wiki/Retread_Vincent): /loc -268, 216, -812 (NPC page lists this mission)
  - [Amee Corman](https://tabularasa.fandom.com/wiki/Amee_Corman): Pools, Retread Camp (named as giver/receiver)

- **Chain** (explicit prerequisite links): Giant Killer chain (11 missions), step 7
  - Requires: Weapons Trafficking (id 904) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Retreads_to_Retreads), [TaRapedia](https://tabularasa.fandom.com/wiki/Weapons_Trafficking), this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - Leads to: It Lies in Ruins (id 1673) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/It_Lies_in_Ruins), [TaRapedia](https://tabularasa.fandom.com/wiki/Retreads_to_Retreads)
- **TR MMO DB quest series:** "Weapons Trafficking", row 1 of 2 ([list](https://web.archive.org/web/20120731165344/http://tr.mmodb.com/quests/seriesname-weapons_trafficking/)). The row order is an ESTIMATE of the play order. The list does not say which mission unlocks which.

## Pools

### 560 — A Cult Divided


- **Rebuild summary:**
  - level: 33 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`); 33 — source: [TR MMO DB](https://web.archive.org/web/20120731171607/http://tr.mmodb.com/quests/a-cult-divided-276.php)
  - level ESTIMATE from zone: the Pools zone level range is 34-38 — source: [Ellatha map: Pools](https://www.ellatha.com/tr/Pools_Maps_Logos.asp) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 33, 10th–90th percentile) — derived from 39 missions in this file with a sourced level
  - reward: 27500 XP; 3400 credits; Class VII Advanced Med Pack, Class VII Armor Charger, Class VII Cryogenic Grenade, Class VII Incendiary Grenade — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - reward: 27,500 XP; 3,400 credits; Class VII Advanced Med Pack (2); Claee VII Armor Charger (2); Class VII Cryogenic Grenade (4); Class VII Incendiary Grenade (4) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/A_Cult_Divided)
  - reward: 3400 (the page gives no unit; probably credits — ESTIMATE) — source: [TR MMO DB](https://web.archive.org/web/20120731171607/http://tr.mmodb.com/quests/a-cult-divided-276.php)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: NPC Hermit: /loc -430, 921, 115 — source: [TaRapedia NPC](https://tabularasa.fandom.com/wiki/Hermit)
- **Client:** Use the Hermit's Token to introduce yourself to the Retread splinter group.
  - objectives (client): Find the Retread Camp — Search for the current location of the Retreads on Valverde Pools; Item Tracker
- **This PR:** revision `pools_1_16_5`, level 33, solo, category 10000061 (Battlefield (Pools)), giver Hermit → John McKormic
  - reward: 27500 XP; 3400 credits; items: Class VII Advanced Med Pack ×2, Class VII Armor Charger ×2, Class VII Cryogenic Grenade ×4, Class VII Incendiary Grenade ×4
  - prerequisites: Requires completed mission 1328
- **TaRapedia** [A Cult Divided](https://tabularasa.fandom.com/wiki/A_Cult_Divided): giver: Hermit; at: The Hermit; zone: Pools; requires: The Thirsty Hermit; follow-up: One Man's Trash; Testing the Pools; XP: 27,500; credits: 3,400; items: Class VII Advanced Med Pack (2); Claee VII Armor Charger (2); Class VII Cryogenic Grenade (4); Class VII Incendiary Grenade (4); reward from: John McKormic
  - overview: Objectives: • Find the Retread Camp
  - objectives: • Find the Retread Camp
- **TR MMO DB** [A Cult Divided](https://web.archive.org/web/20120731171607/http://tr.mmodb.com/quests/a-cult-divided-276.php): level: 33; starts at npc: Hermit; starts in zone: Pools; reward: 3400; series: Death Patrol
  - related mob John McKormic (not in the archived bestiary pages)
- **TR MMO DB quest series** [Death Patrol](https://web.archive.org/web/20120731161916/http://tr.mmodb.com/quests/seriesname-death_patrol/): A Cult Divided (level 33, reward 3400) → Death Patrol (level 33, reward 5000) → The Thirsty Hermit (level 33, reward 3400) (series order as listed on the page; reward unit not stated)
- **NPCs (TaRapedia NPC pages):**
  - [Hermit](https://tabularasa.fandom.com/wiki/Hermit): /loc -430, 921, 115 (named as giver/receiver)

- **Chain** (explicit prerequisite links): Death Patrol chain (18 missions), step 3
  - Requires: The Hermit (id 1327) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/The_Thirsty_Hermit)
  - Requires: The Thirsty Hermit (id 1328) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/A_Cult_Divided), [TaRapedia](https://tabularasa.fandom.com/wiki/The_Thirsty_Hermit), this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - Leads to: Testing the Pools (id 561) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/A_Cult_Divided), [TaRapedia](https://tabularasa.fandom.com/wiki/Testing_the_Pools), this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - Leads to: One Man's Trash (id 562) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/A_Cult_Divided), [TaRapedia](https://tabularasa.fandom.com/wiki/One_Man%27s_Trash), this PR's World data (`mission_content_definition` / `mission_reward_*`)
- **TR MMO DB quest series:** "Death Patrol", row 1 of 3 ([list](https://web.archive.org/web/20120731161916/http://tr.mmodb.com/quests/seriesname-death_patrol/)). The row order is an ESTIMATE of the play order. The list does not say which mission unlocks which.

### 561 — Testing the Pools


- Internal/test identity in the client.
- **Client:** Collect tainted water samples from key points in the cascading pools to find the source of the pollution. Then return to the Retread Jaysen Venma.
  - objectives (client): Collect Northern Water Sample; Collect East Sample; Collect West Sample; Collect Water Samples
- **This PR:** revision `pools_1_16_5`, level 33, solo, category 10000061 (Battlefield (Pools)), giver Jayson Venma
  - reward: 60000 XP; 5250 credits; choose 1 of: Bio Armor Helmet, Hazmat Armor Vest, Motor Assist Armor Vest, Reflective Armor Vest
  - prerequisites: Requires completed mission 560
- **TaRapedia** [Testing the Pools](https://tabularasa.fandom.com/wiki/Testing_the_Pools) [stub, bug noted]: giver: Jayson Venma; at: Retread Camp; zone: Retread Camp; requires: A Cult Divided; XP: 60,000; credits: 5,250; items: lvl 35; lvl 34; lvl 33; lvl 34; reward from: Jayson Venma
  - overview: Collect tainted water samples from key points in the cascading pools to find the source of the pollution. Then return to the Retread Jaysen Venma.
  - objectives: • Collect Water Samples • Eastern Water Sample 0 / 1 • Western Water Sample 0 / 1 • Northern Water Sample 0 / 1
  - walkthrough: The only tricky part of this mission is that when you find the correct pool, you will get a notice that you filled an objective, but the walkie talkie indicator stays lit. Just ignore it and move on to the next waypoint.
- **TaRapedia mission list** [Retread Camp mission list](https://tabularasa.fandom.com/wiki/Retread_Camp_mission_list): zone Pools, area Retread Camp, given by Jayson Venma

- **Chain** (explicit prerequisite links): Death Patrol chain (18 missions), step 4
  - Requires: A Cult Divided (id 560) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/A_Cult_Divided), [TaRapedia](https://tabularasa.fandom.com/wiki/Testing_the_Pools), this PR's World data (`mission_content_definition` / `mission_reward_*`)

### 562 — One Man's Trash


- **Rebuild summary:**
  - level: 33 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`); 33 — source: [TR MMO DB quest list](https://web.archive.org/web/20120731172517/http://tr.mmodb.com/quests/startingzone-pools/)
  - level ESTIMATE from zone: the Pools zone level range is 34-38 — source: [Ellatha map: Pools](https://www.ellatha.com/tr/Pools_Maps_Logos.asp) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 33, 10th–90th percentile) — derived from 39 missions in this file with a sourced level
  - reward: 55000 XP; 5100 credits; choose 1 of: Hazmat Armor Helmet, Mech Armor Vest, Motor Assist Armor Helmet, Reflective Armor Helmet — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - reward: 55,000 XP; 5,100 credits; lvl 34; lvl 35; lvl 33; lvl 34 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/One_Man%27s_Trash)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: Collect Ration Packs from container in The Snake Pit: -953, 919, 458 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/One_Man%27s_Trash)
- **Client:** Steal an ammunition crate from the Thrax ammo depot near the Thrax Barracks and a Ration Pack from the Snake Pit for delivery to the Retreads.
  - objectives (client): Collect Thrax Ammo Crates; Collect Ration Packs
- **This PR:** revision `pools_1_16_5`, level 33, solo, category 10000061 (Battlefield (Pools)), giver Austin Buckley
  - reward: 55000 XP; 5100 credits; choose 1 of: Hazmat Armor Helmet, Mech Armor Vest, Motor Assist Armor Helmet, Reflective Armor Helmet
  - prerequisites: Requires completed mission 560
- **TaRapedia** [One Man's Trash](https://tabularasa.fandom.com/wiki/One_Man%27s_Trash) [stub]: giver: Austin Buckley; at: Retread Camp; zone: Retread Camp; requires: A Cult Divided; follow-up: Retread Planning; XP: 55,000; credits: 5,100; items: lvl 34; lvl 35; lvl 33; lvl 34; reward from: Austin Buckley
  - overview: Steal an ammunition crate from the Thrax ammo depot near the Thrax Barracks and a Ration Pack from the Snake Pit for delivery to the Retreads.
  - objectives: • Collect Thrax Ammo Crates • Collect Ration Packs
  - walkthrough: Collect Ration Packs from container in The Snake Pit: -953, 919, 458
- **TaRapedia mission list** [Retread Camp mission list](https://tabularasa.fandom.com/wiki/Retread_Camp_mission_list): zone Pools, area Retread Camp, given by Austin Buckley
- **TR MMO DB NPC** [Austin Buckley](https://web.archive.org/web/20080907091731/http://tr.mmodb.com/bestiary/austin-buckley-703.php): Quest NPC, location Retread Camp, zone Pools (starts this quest)
- **PlanetTR** [planettr.com:80/forums/archive/index.php/t-1365.html](https://web.archive.org/web/20071209022816/http://planettr.com:80/forums/archive/index.php/t-1365.html): “o Mission: One Man’s Trash / o Issue: The ammo objective in One Man's Trash doesn't complete when the ammo is retrieved, preventing mission completion. / o Mission: Smash and Grab”
- **RGTR official site** [www.rgtr.com/news/patch_notes/patch_notes_and_known_issues_1_4.html](https://web.archive.org/web/20081117172815/http://www.rgtr.com/news/patch_notes/patch_notes_and_known_issues_1_4.html): “Mission: One Man’s Trash / Issue: The ammo objective in One Man's Trash doesn't complete when the ammo is retrieved, preventing mission completion. / Mission: Smash and Grab”
- **WarCry TR** [tr.warcry.com:80/forums/read/191.50079](https://web.archive.org/web/20071013203606/http://tr.warcry.com:80/forums/read/191.50079): “Issue: Players cannot turn in the mission. / Foreas Valverde Pools / Mission: One Man's Trash / Issue: Containers holding mission items do not respawn, causing mission to be uncompletable / Mission: Smash and Grab”
- **Where (locations / coordinates):**
  - Collect Ration Packs from container in The Snake Pit: -953, 919, 458 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/One_Man%27s_Trash)

- **Chain** (explicit prerequisite links): Death Patrol chain (18 missions), step 4
  - Requires: A Cult Divided (id 560) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/A_Cult_Divided), [TaRapedia](https://tabularasa.fandom.com/wiki/One_Man%27s_Trash), this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - Leads to: Retread Planning (id 563) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/One_Man%27s_Trash), [TaRapedia](https://tabularasa.fandom.com/wiki/Retread_Planning), this PR's World data (`mission_content_definition` / `mission_reward_*`)

### 563 — Retread Planning


- **Rebuild summary:**
  - level: 33 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`); 33 — source: [TR MMO DB quest list](https://web.archive.org/web/20120731172517/http://tr.mmodb.com/quests/startingzone-pools/)
  - level ESTIMATE from zone: the Pools zone level range is 34-38 — source: [Ellatha map: Pools](https://www.ellatha.com/tr/Pools_Maps_Logos.asp) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 33, 10th–90th percentile) — derived from 39 missions in this file with a sourced level
  - reward: 27500 XP; 3300 credits; Class VII EMP Bomb, Class VII Adrenaline Booster, Class VII Cryogenic Grenade, Class VII Incendiary Grenade — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - reward: 27,500 XP; 3,300 credits; Class VII EMP Bomb (2); Class VII Adrenaline Booster (2); Class VII Cryogenic Grenade (4); Class VII Incendiary Grenade (4) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Retread_Planning)
  - reward: 0 (the page gives no unit; probably credits — ESTIMATE) — source: [TR MMO DB quest series list](https://web.archive.org/web/20120731164744/http://tr.mmodb.com/quests/seriesname-retread_planning/)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: NPC Hermit: /loc -430, 921, 115 — source: [TaRapedia NPC](https://tabularasa.fandom.com/wiki/Hermit)
- **Client:** The Hermit wishes for you to discover the Retread plans. He wants to know the "Who, What, and Where".
  - objectives (client): Who?; Who?; Who?; Who?; Who?; What?; What?; What?; What?; What? … (+9 more)
- **This PR:** revision `pools_1_16_5`, level 33, solo, category 10000061 (Battlefield (Pools))
  - reward: 27500 XP; 3300 credits; items: Class VII EMP Bomb ×2, Class VII Adrenaline Booster ×2, Class VII Cryogenic Grenade ×4, Class VII Incendiary Grenade ×4
  - prerequisites: Requires completed mission 562
- **TaRapedia** [Retread Planning](https://tabularasa.fandom.com/wiki/Retread_Planning) [stub]: giver: Headquarters; at: Radio; zone: Retread Camp; requires: One Man's Trash; follow-up: Retread Planning Part II; Stick Your Neck Out; XP: 27,500; credits: 3,300; items: Class VII EMP Bomb (2); Class VII Adrenaline Booster (2); Class VII Cryogenic Grenade (4); Class VII Incendiary Grenade (4); reward from: Hermit
  - overview: Objectives: • Who? • What? • Where? • Return to the Hermit
  - objectives: • Who? • What? • Where? • Return to the Hermit
  - walkthrough: Talk to each surrounding person and between them they will reveal the mission details. This mission seems to activate Amee Corman's Stick Your Neck Out mission.
- **TR MMO DB quest series** [Retread Planning](https://web.archive.org/web/20120731164744/http://tr.mmodb.com/quests/seriesname-retread_planning/): Retread Planning (level 33, reward 0) → Retread Planning Part II (level 33, reward 3500) (series order as listed on the page; reward unit not stated)
- **PlanetTR** [planettr.com:80/forums/archive/index.php/t-1365.html](https://web.archive.org/web/20071209022816/http://planettr.com:80/forums/archive/index.php/t-1365.html): “* Fixed Mission Objective Text for "Create the Queen Lure". / * Fixed grammar from John McKormic in "Retread Planning". / * Fixed truncated greeting for Handyman Hank on Thunderhead.”
- **NPCs (TaRapedia NPC pages):**
  - [Hermit](https://tabularasa.fandom.com/wiki/Hermit): /loc -430, 921, 115 (named as giver/receiver)

- **Chain** (explicit prerequisite links): Death Patrol chain (18 missions), step 5
  - Requires: One Man's Trash (id 562) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/One_Man%27s_Trash), [TaRapedia](https://tabularasa.fandom.com/wiki/Retread_Planning), this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - Leads to: Stick Your Neck Out (id 1329) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Retread_Planning), [TaRapedia](https://tabularasa.fandom.com/wiki/Stick_Your_Neck_Out)
  - Leads to: Retread Planning Part II (id 1330) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Retread_Planning), [TaRapedia](https://tabularasa.fandom.com/wiki/Retread_Planning_Part_II), this PR's World data (`mission_content_definition` / `mission_reward_*`)
- **TR MMO DB quest series:** "Retread Planning", row 1 of 2 ([list](https://web.archive.org/web/20120731164744/http://tr.mmodb.com/quests/seriesname-retread_planning/)). The row order is an ESTIMATE of the play order. The list does not say which mission unlocks which.

### 932 — Bane Investigation


- **Rebuild summary:**
  - level: 35 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`); 35 — source: [TR MMO DB](https://web.archive.org/web/20080829154110/http://tr.mmodb.com/quests/bane-investigation-267.php)
  - level ESTIMATE from zone: the Pools zone level range is 34-38 — source: [Ellatha map: Pools](https://www.ellatha.com/tr/Pools_Maps_Logos.asp) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 33, 10th–90th percentile) — derived from 39 missions in this file with a sourced level
  - reward: 60000 XP; 5250 credits; choose 1 of: Weapon Module: Crit Hit Bonus [4], Armor Module: Armor Absorption [4], Tool Module: Threat Reduction [4], Weapon Module: Armor Piercing [4] — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - reward: 60,000 XP; 5,250 credits; Modification: Crit Hit Increase; Modification: Armor Absorption; Modification: Threat Reduction; Modification: Armor Piercing — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Bane_Investigation)
  - reward: 5250 (the page gives no unit; probably credits — ESTIMATE) — source: [TR MMO DB](https://web.archive.org/web/20080829154110/http://tr.mmodb.com/quests/bane-investigation-267.php)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: NPC Lieutenant Feldman: Pools, The Snakepit, /loc -934, 920, 381 — source: [TaRapedia NPC](https://tabularasa.fandom.com/wiki/Lieutenant_Feldman)
- **Client:** Investigate the Bane activity in the western part of Valverde Pools by gaining access to the terminal located outside the fortifications.
  - objectives (client): Gain access to the Bane terminal; Search for information for the reason the Bane have invested western Valverde …; Return to Lt. Feldman
- **This PR:** revision `pools_1_16_5`, level 35, solo, category 10000061 (Battlefield (Pools)), giver Lieutenant Feldman
  - reward: 60000 XP; 5250 credits; choose 1 of: Weapon Module: Crit Hit Bonus [4], Armor Module: Armor Absorption [4], Tool Module: Threat Reduction [4], Weapon Module: Armor Piercing [4]
- **TaRapedia** [Bane Investigation](https://tabularasa.fandom.com/wiki/Bane_Investigation): giver: Lieutenant Feldman; at: The Snakepit; zone: Pools; follow-up: Sabotage the Tower; XP: 60,000; credits: 5,250; items: Modification: Crit Hit Increase; Modification: Armor Absorption; Modification: Threat Reduction; Modification: Armor Piercing; reward from: Lieutenant Feldman
  - overview: Investigate the Bane activity in the western part of Valverde Pools by gaining access to the terminal located outside the fortifications.
  - objectives: • Gain access to the Bane terminal • Search for information for the reason the Bane have invested western Valverde Pools
  - walkthrough: Walkthrough
- **TaRapedia mission list** [The Snakepit mission list](https://tabularasa.fandom.com/wiki/The_Snakepit_mission_list): zone Pools, area The Snakepit, given by Lieutenant Feldman
- **TR MMO DB** [Bane Investigation](https://web.archive.org/web/20080829154110/http://tr.mmodb.com/quests/bane-investigation-267.php): level: 35; starts at npc: Lieutenant Feldman; starts in zone: Pools; objectives: Gain access to the Bane Terminal, Return to Lieutenant Feldman; reward: 5250; series: Bane Investigation
- **TR MMO DB quest series** [Bane Investigation](https://web.archive.org/web/20120731170309/http://tr.mmodb.com/quests/seriesname-bane_investigation/): Bane Investigation (level 35, reward 5250) → Bane Jamming (level 35, reward 950) → Sabotage the Tower (level 35, reward 5250) (series order as listed on the page; reward unit not stated)
- **NPCs (TaRapedia NPC pages):**
  - [Lieutenant Feldman](https://tabularasa.fandom.com/wiki/Lieutenant_Feldman): Pools, The Snakepit, /loc -934, 920, 381 (named as giver/receiver)

- **Chain** (explicit prerequisite links): Bane Investigation chain (4 missions), step 1
  - Leads to: Sabotage the Tower (id 937) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Bane_Investigation), [TaRapedia](https://tabularasa.fandom.com/wiki/Sabotage_the_Tower), this PR's World data (`mission_content_definition` / `mission_reward_*`)
- **TR MMO DB quest series:** "Bane Investigation", row 1 of 3 ([list](https://web.archive.org/web/20120731170309/http://tr.mmodb.com/quests/seriesname-bane_investigation/)). The row order is an ESTIMATE of the play order. The list does not say which mission unlocks which.

### 937 — Sabotage the Tower


- **Rebuild summary:**
  - level: 35 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`); 35 — source: [TR MMO DB](https://web.archive.org/web/20081010181037/http://tr.mmodb.com/quests/sabotage-the-tower-269.php)
  - level ESTIMATE from zone: the Pools zone level range is 34-38 — source: [Ellatha map: Pools](https://www.ellatha.com/tr/Pools_Maps_Logos.asp) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 33, 10th–90th percentile) — derived from 39 missions in this file with a sourced level
  - reward: 60000 XP; 5250 credits; choose 1 of: Direct Repair Tool, Electric Pistol, Virulent Disperser, EMP Torqueshell Rifle — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - reward: 60,000 XP; 5,250 credits; Prodigy Conical Repair Tool lvl 35; Vextronics Electric Pistol lvl 35; Teleract Virulent Disperser lvl 32; Eclipse EMP Torqueshell Rifle lvl 32 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Sabotage_the_Tower)
  - reward: 5250 (the page gives no unit; probably credits — ESTIMATE) — source: [TR MMO DB](https://web.archive.org/web/20081010181037/http://tr.mmodb.com/quests/sabotage-the-tower-269.php)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: NPC Lieutenant Feldman: Pools, The Snakepit, /loc -934, 920, 381 — source: [TaRapedia NPC](https://tabularasa.fandom.com/wiki/Lieutenant_Feldman)
- **Client:** Destroy the Bane personnel and their equipment protecting the Eloh Obelisk.
  - objectives (client): Destroy the Bane Equipment; Eliminate the Linkers guarding the Eloh Relic site.
- **This PR:** revision `pools_1_16_5`, level 35, solo, category 10000061 (Battlefield (Pools)), giver Lieutenant Feldman
  - reward: 60000 XP; 5250 credits; choose 1 of: Direct Repair Tool, Electric Pistol, Virulent Disperser, EMP Torqueshell Rifle
  - prerequisites: Requires completed mission 932
- **TaRapedia** [Sabotage the Tower](https://tabularasa.fandom.com/wiki/Sabotage_the_Tower): giver: Lieutenant Feldman; at: The Snakepit; zone: Pools; requires: Bane Investigation; follow-up: Bane Jamming; Elimination; XP: 60,000; credits: 5,250; items: Prodigy Conical Repair Tool lvl 35; Vextronics Electric Pistol lvl 35; Teleract Virulent Disperser lvl 32; Eclipse EMP Torqueshell Rifle lvl 32; reward from: Lieutenant Feldman
  - overview: Destroy the Bane personnel and their equipment protecting the Eloh Obelisk.
  - objectives: • Destroy the Bane Equipment • Vital Bane Equipment Destroyed 0 / 6 • Bane Equipment Locker Destroyed 0 / 10 • Eliminate the Linkers guarding the Eloh Relic site. • Linkers eliminated 0 / 4
  - walkthrough: Walkthrough
- **TaRapedia mission list** [The Snakepit mission list](https://tabularasa.fandom.com/wiki/The_Snakepit_mission_list): zone Pools, area The Snakepit, given by Lieutenant Feldman
- **TR MMO DB** [Sabotage the Tower](https://web.archive.org/web/20081010181037/http://tr.mmodb.com/quests/sabotage-the-tower-269.php): level: 35; starts at npc: Lieutenant Feldman; starts in zone: Pools; objectives: Destroy the Bane Equipment, Eliminate the LInkers guarding the Eloh Relic Site; reward: 5250; series: Bane Investigation
- **TR MMO DB quest series** [Bane Investigation](https://web.archive.org/web/20120731170309/http://tr.mmodb.com/quests/seriesname-bane_investigation/): Bane Investigation (level 35, reward 5250) → Bane Jamming (level 35, reward 950) → Sabotage the Tower (level 35, reward 5250) (series order as listed on the page; reward unit not stated)
- **IGN TR Vault** [tabularasavault.ign.com/View.php?view=Npc.List&category_show_all=1&per …](https://web.archive.org/web/20120712175931/http://tabularasavault.ign.com/View.php?view=Npc.List&category_show_all=1&persist_search=1b97890fb44f287ca7117545aec03cc8&sort_field=Author&sort_dir=asc): “Starts quest "Building Materials" / Lietenant Feldman / Cyberus / 12-29-2007 / Sabotage the Tower / Amee Corman / Cyberus / 12-29-2007 / New Orders from the General”
- **NPCs (TaRapedia NPC pages):**
  - [Lieutenant Feldman](https://tabularasa.fandom.com/wiki/Lieutenant_Feldman): Pools, The Snakepit, /loc -934, 920, 381 (named as giver/receiver)

- **Chain** (explicit prerequisite links): Bane Investigation chain (4 missions), step 2
  - Requires: Bane Investigation (id 932) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Bane_Investigation), [TaRapedia](https://tabularasa.fandom.com/wiki/Sabotage_the_Tower), this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - Leads to: Bane Jamming (id 938) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Bane_Jamming), [TaRapedia](https://tabularasa.fandom.com/wiki/Sabotage_the_Tower), this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - Leads to: Elimination (id 941) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Elimination), [TaRapedia](https://tabularasa.fandom.com/wiki/Sabotage_the_Tower), this PR's World data (`mission_content_definition` / `mission_reward_*`)
- **TR MMO DB quest series:** "Bane Investigation", row 3 of 3 ([list](https://web.archive.org/web/20120731170309/http://tr.mmodb.com/quests/seriesname-bane_investigation/)). The row order is an ESTIMATE of the play order. The list does not say which mission unlocks which.

### 938 — Bane Jamming


- **Rebuild summary:**
  - level: 35 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`); 35 — source: [TR MMO DB](https://web.archive.org/web/20081010182144/http://tr.mmodb.com/quests/bane-jamming-268.php)
  - level ESTIMATE from zone: the Pools zone level range is 34-38 — source: [Ellatha map: Pools](https://www.ellatha.com/tr/Pools_Maps_Logos.asp) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 33, 10th–90th percentile) — derived from 39 missions in this file with a sourced level
  - reward: 120000 XP; 7000 credits; choose 1 of: Graviton Armor Gloves, Hazmat Armor Legs, Motor Assist Armor Legs, Reflective Armor Legs — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - reward: 120,000 XP; 7,000 credits; lvl 35; lvl 34; lvl 33; lvl 34 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Bane_Jamming)
  - reward: 950 (the page gives no unit; probably credits — ESTIMATE) — source: [TR MMO DB](https://web.archive.org/web/20081010182144/http://tr.mmodb.com/quests/bane-jamming-268.php)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: NPC Lieutenant Feldman: Pools, The Snakepit, /loc -934, 920, 381 — source: [TaRapedia NPC](https://tabularasa.fandom.com/wiki/Lieutenant_Feldman)
- **Client:** Prevent the Bane from tapping into the Eloh tower by destroying any attached equipment and by burying Jammers surrounding the tower.
  - objectives (client): Destroy the Bane Equipment attached to the Eloh Obelisk; Place Jammer: Alpha; Place Jammer: Beta; Place Jammer: Gamma; Place Jammer: Delta; Place Jammer: Epsilon; Place Jammer: Zeta
- **This PR:** revision `pools_1_16_5`, level 35, solo, category 10000061 (Battlefield (Pools)), giver Lieutenant Feldman
  - reward: 120000 XP; 7000 credits; choose 1 of: Graviton Armor Gloves, Hazmat Armor Legs, Motor Assist Armor Legs, Reflective Armor Legs
  - prerequisites: Requires completed mission 937
- **TaRapedia** [Bane Jamming](https://tabularasa.fandom.com/wiki/Bane_Jamming): giver: Lieutenant Feldman; at: The Snakepit; zone: Pools; requires: Sabotage the Tower; XP: 120,000; credits: 7,000; items: lvl 35; lvl 34; lvl 33; lvl 34; reward from: Lieutenant Feldman
  - overview: Prevent the Bane from tapping into the Eloh tower by destroying any attached equipment and by burying Jammers surrounding the tower.
  - objectives: • Destroy the Bane Equipment attached to the Eloh Obelisk • Place Jammer: Alpha • Place Jammer: Beta • Place Jammer: Gamma • Place Jammer: Delta • Place Jammer: Epsilon • Place Jammer: Zeta
  - walkthrough: Approaching from the area outside the base where you plant three of the beacons, you can jump onto the wall of the base to reach the other three without fighting through hordes of enemies. You can also take out Overseer Prysiam for Elimination this way.
- **TaRapedia mission list** [The Snakepit mission list](https://tabularasa.fandom.com/wiki/The_Snakepit_mission_list): zone Pools, area The Snakepit, given by Lieutenant Feldman
- **TR MMO DB** [Bane Jamming](https://web.archive.org/web/20081010182144/http://tr.mmodb.com/quests/bane-jamming-268.php): level: 35; starts at npc: Lieutenant Feldman; starts in zone: Pools; objectives: Destroy the Bane Equipment attached to the Eloh Obelisk, Plane Jammers: Alpha, Beta, Gamma, Delta, Epsilon, and Zeta, Return to Lieutenant Feldman; reward: 950; series: Bane Investigation
- **TR MMO DB quest series** [Bane Investigation](https://web.archive.org/web/20120731170309/http://tr.mmodb.com/quests/seriesname-bane_investigation/): Bane Investigation (level 35, reward 5250) → Bane Jamming (level 35, reward 950) → Sabotage the Tower (level 35, reward 5250) (series order as listed on the page; reward unit not stated)
- **NPCs (TaRapedia NPC pages):**
  - [Lieutenant Feldman](https://tabularasa.fandom.com/wiki/Lieutenant_Feldman): Pools, The Snakepit, /loc -934, 920, 381 (named as giver/receiver)

- **Chain** (explicit prerequisite links): Bane Investigation chain (4 missions), step 3
  - Requires: Sabotage the Tower (id 937) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Bane_Jamming), [TaRapedia](https://tabularasa.fandom.com/wiki/Sabotage_the_Tower), this PR's World data (`mission_content_definition` / `mission_reward_*`)
- **TR MMO DB quest series:** "Bane Investigation", row 2 of 3 ([list](https://web.archive.org/web/20120731170309/http://tr.mmodb.com/quests/seriesname-bane_investigation/)). The row order is an ESTIMATE of the play order. The list does not say which mission unlocks which.

### 941 — Elimination


- **Rebuild summary:**
  - level: 35 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`); 35 — source: [TR MMO DB](https://web.archive.org/web/20080907092013/http://tr.mmodb.com/quests/elimination-265.php)
  - level ESTIMATE from zone: the Pools zone level range is 34-38 — source: [Ellatha map: Pools](https://www.ellatha.com/tr/Pools_Maps_Logos.asp) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 33, 10th–90th percentile) — derived from 39 missions in this file with a sourced level
  - reward: 60000 XP; 5250 credits; choose 1 of: Chaingun, Incendiary Net Gun, Exothermic Polarity Gun, Shotgun — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - reward: 60,000 XP; 5,250 credits; AccuMax Chaingun lvl 33; AccuMax Incendiary Net Gun lvl 36; Vitalius Exothermic Polarity Gun lvl 33; Eclipse Shotgun lvl 32 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Elimination)
  - reward: 1760 (the page gives no unit; probably credits — ESTIMATE) — source: [TR MMO DB](https://web.archive.org/web/20080907092013/http://tr.mmodb.com/quests/elimination-265.php)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: NPC Colonel 'Snake' Washington: Pools, The Snakepit, /loc -981, 915, 413 — source: [TaRapedia NPC](https://tabularasa.fandom.com/wiki/Colonel_%27Snake%27_Washington)
- **Client:** Eliminate the Bane Officer name Prysiam located in the vacinity of the Eloh Obelisk in Western Valverde Pools.
  - objectives (client): Eliminate Overseer Prysiam
- **This PR:** revision `pools_1_16_5`, level 35, solo, category 10000061 (Battlefield (Pools)), giver Colonel 'Snake' Washington
  - reward: 60000 XP; 5250 credits; choose 1 of: Chaingun, Incendiary Net Gun, Exothermic Polarity Gun, Shotgun
  - prerequisites: Requires completed mission 937
- **TaRapedia** [Elimination](https://tabularasa.fandom.com/wiki/Elimination): giver: Colonel 'Snake' Washington; at: The Snakepit; zone: Pools; requires: Sabotage the Tower; XP: 60,000; credits: 5,250; items: AccuMax Chaingun lvl 33; AccuMax Incendiary Net Gun lvl 36; Vitalius Exothermic Polarity Gun lvl 33; Eclipse Shotgun lvl 32; reward from: Colonel 'Snake' Washington
  - overview: Eliminate the Bane Officer named Prysiam located in the vacinity of the Eloh Obelisk in Western Valverde Pools.
  - objectives: • Eliminate Overseer Prysiam
  - walkthrough: If you jump onto the wall of the base from outside near where you place three beacons for Bane Jamming, you can take out Overseer Prysiam without having to fight through the entire base.
- **TaRapedia mission list** [The Snakepit mission list](https://tabularasa.fandom.com/wiki/The_Snakepit_mission_list): zone Pools, area The Snakepit, given by Colonel 'Snake' Washington
- **TR MMO DB** [Elimination](https://web.archive.org/web/20080907092013/http://tr.mmodb.com/quests/elimination-265.php): level: 35; starts at npc: Colonel 'Snake' Washington; starts in zone: Pools; objectives: Eliminate Overseer Prysiam, Return to Colonel Washington; reward: 1760
  - related mob Overseer Prysiam (not in the archived bestiary pages)
- **Stratics TR forum** [boards.stratics.com:80/php-bin/tr/showflat.php?Cat=&Number=11987&page= …](https://web.archive.org/web/20071221003621/http://boards.stratics.com:80/php-bin/tr/showflat.php?Cat=&Number=11987&page=0&view=collapsed&sb=5&o=&fpart=1): “missions Traitor in the Midst, Wrench in the Gears, Process of / Elimination, and Proof of Assurance. / Valverede Divide: Sanctus Grotto: Mission rewards have been added to the new”
- **NPCs (TaRapedia NPC pages):**
  - [Colonel 'Snake' Washington](https://tabularasa.fandom.com/wiki/Colonel_%27Snake%27_Washington): Pools, The Snakepit, /loc -981, 915, 413 (named as giver/receiver)

- **Chain** (explicit prerequisite links): Bane Investigation chain (4 missions), step 3
  - Requires: Sabotage the Tower (id 937) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Elimination), [TaRapedia](https://tabularasa.fandom.com/wiki/Sabotage_the_Tower), this PR's World data (`mission_content_definition` / `mission_reward_*`)

### 1025 — Mapping The Pools


- **Rebuild summary:**
  - level: 35 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`); 35 — source: [TR MMO DB quest list](https://web.archive.org/web/20120731172517/http://tr.mmodb.com/quests/startingzone-pools/)
  - level ESTIMATE from zone: the Pools zone level range is 34-38 — source: [Ellatha map: Pools](https://www.ellatha.com/tr/Pools_Maps_Logos.asp) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 33, 10th–90th percentile) — derived from 39 missions in this file with a sourced level
  - reward: 25000 XP; 3300 credits; Class VI EMP Bomb, Class VI Adrenaline Booster, Class VI Incendiary Grenade, Class VI EMP Grenade — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - reward: 25,000 XP; 3,300 credits; Class VI EMP Bomb (2); Class VI Adrenaline Booster (2); Class VI Incendiary Grenade (4); Class VI EMP Grenade (4) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Mapping_The_Pools)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: Walkthrough: The beacons are in a crate at -965.3, 915.7, 428.1. — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Mapping_The_Pools)
  - location: *GPS Beacon #1: -568.8, 900.0, 511.2 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Mapping_The_Pools)
- **Client:** Specialist Allen wants you to collect a pack of GPS Beacons from Spymaster Timlin in the Snake Pit to be planted around Valverde Pools. Report your findings to Spymaster Timlin, then return to Specialist Allen once you are complete.
  - objectives (client): Speak with Spymaster Timlin to collect a pack of GPS Beacons.; Pick up a pack of GPS Beacons — Pick up a pack of GPS Beacons located next to Spymaster Timlin.; Plant GPS Beacon #1; Plant GPS Beacon #2; Plant GPS Beacon #3; Plant GPS Beacon #4; Plant GPS Beacon #5; Beacon Tracker; Report to Spymaster Timlin that the job is complete.; Beacon Tracker
- **This PR:** revision `pools_1_16_5`, level 35, solo, category 10000061 (Battlefield (Pools)), giver Specialist Allen
  - reward: 25000 XP; 3300 credits; items: Class VI EMP Bomb ×2, Class VI Adrenaline Booster ×2, Class VI Incendiary Grenade ×4, Class VI EMP Grenade ×4
- **TaRapedia** [Mapping The Pools](https://tabularasa.fandom.com/wiki/Mapping_The_Pools): giver: Specialist Allen; at: Pools; zone: Pools; XP: 25,000; credits: 3,300; items: Class VI EMP Bomb (2); Class VI Adrenaline Booster (2); Class VI Incendiary Grenade (4); Class VI EMP Grenade (4); reward from: Specialist Allen
  - overview: Specialist Allen wants you to collect a pack of GPS Beacons from Spymaster Timlin in the Snakepit to be planted around Valverde Pools. Return to Spymaster Timlin when the job is complete.
  - objectives: • Speak with Spymaster Timlin to collect a pack of GPS Beacons. • Pick up a pack of GPS Beacons. • Plant GPS Beacon #1 • Plant GPS Beacon #2 • Plant GPS Beacon #3 • Plant GPS Beacon #4 • Plant GPS Beacon #5 • Report to Spymaster Timlin that the job is complete.
  - walkthrough: Walkthrough: The beacons are in a crate at -965.3, 915.7, 428.1. • GPS Beacon #1: -568.8, 900.0, 511.2 • GPS Beacon #2: -264.5, 866.7, 473.8 • GPS Beacon #3: -27.9, 818.0, 234.9 • GPS Beacon #4: -505.1, 775.5, -10.3 • GPS Beacon #5: -668.4, 858.2, 257.1 You will be given a moral choice upon returning to Spymaster Timlin: whether to continue the charade and give all credit to the lazy Specialist Allen, or to truthfully acknowledge that you were the one who did all the work.
- **TaRapedia mission list** [The Snakepit mission list](https://tabularasa.fandom.com/wiki/The_Snakepit_mission_list): zone Pools, area The Snakepit, given by Specialist Allen
- **Where (locations / coordinates):**
  - Walkthrough: The beacons are in a crate at -965.3, 915.7, 428.1. — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Mapping_The_Pools)
  - *GPS Beacon #1: -568.8, 900.0, 511.2 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Mapping_The_Pools)
  - *GPS Beacon #2: -264.5, 866.7, 473.8 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Mapping_The_Pools)
  - *GPS Beacon #3: -27.9, 818.0, 234.9 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Mapping_The_Pools)
- **NPCs (TaRapedia NPC pages):**
  - [Specialist Allen](https://tabularasa.fandom.com/wiki/Specialist_Allen): no location on page (named as giver/receiver)
  - [Spymaster Timlin](https://tabularasa.fandom.com/wiki/Spymaster_Timlin): Pools, The Snakepit, /loc -970, 915, 414 (named in client text)

### 1066 — Medicinal Measures


- **Rebuild summary:**
  - level: 35 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`); 35 — source: [TR MMO DB quest list](https://web.archive.org/web/20120731172517/http://tr.mmodb.com/quests/startingzone-pools/)
  - level ESTIMATE from zone: the Pools zone level range is 34-38 — source: [Ellatha map: Pools](https://www.ellatha.com/tr/Pools_Maps_Logos.asp) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 33, 10th–90th percentile) — derived from 39 missions in this file with a sourced level
  - reward: 27500 XP; 3400 credits; Class VII EMP Bomb, Class VII Armor Charger, Class VII EMP Grenade, Class VII Concussion Grenade — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - reward: 27,500 XP; 3,400 credits; Class VII EMP Bomb (2); Class VII Armor Charger (2); Class VII EMP Grenade (4); Class VII Concussion Grenade (4) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Medicinal_Measures)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: NPC Dr. Hester: Pools, The Snakepit, /loc -961, 919, 469 — source: [TaRapedia NPC](https://tabularasa.fandom.com/wiki/Dr._Hester)
  - location: There is a field of the flowers around 54.1, 665.7, 458.5 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Medicinal_Measures)
  - location: Another field at: 267.4, 680.2, -530.0 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Medicinal_Measures)
- **Client:** Dr. Hester located in the Snake Pit would like you to collect nectar from the native Mawflower plant that can be found throughout all of Valverde Pools.
  - objectives (client): Collect Mawflower Nectar — Collect Mawflower Nectar from the Malflower plants in Valverde Pools.
- **This PR:** revision `pools_1_16_5`, level 35, solo, category 10000061 (Battlefield (Pools)), giver Dr. Hester
  - reward: 27500 XP; 3400 credits; items: Class VII EMP Bomb ×2, Class VII Armor Charger ×2, Class VII EMP Grenade ×4, Class VII Concussion Grenade ×4
- **TaRapedia** [Medicinal Measures](https://tabularasa.fandom.com/wiki/Medicinal_Measures): giver: Dr. Hester; at: The Snakepit; zone: Pools; XP: 27,500; credits: 3,400; items: Class VII EMP Bomb (2); Class VII Armor Charger (2); Class VII EMP Grenade (4); Class VII Concussion Grenade (4); reward from: Dr. Hester
  - overview: Dr. Hester located in the Snakepit would like you to collect nectar from the native Mawflower plant that can be found throughout all of Valverde Pools.
  - objectives: • Collect 10 Mawflower Nectar. • Collect Mawflower Nectar from the Malf lower plants in Valverde Pools.
  - walkthrough: There is a field of the flowers around 54.1, 665.7, 458.5 Another field at: 267.4, 680.2, -530.0
- **TaRapedia mission list** [The Snakepit mission list](https://tabularasa.fandom.com/wiki/The_Snakepit_mission_list): zone Pools, area The Snakepit, given by Dr. Hester
- **Where (locations / coordinates):**
  - There is a field of the flowers around 54.1, 665.7, 458.5 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Medicinal_Measures)
  - Another field at: 267.4, 680.2, -530.0 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Medicinal_Measures)
- **NPCs (TaRapedia NPC pages):**
  - [Dr. Hester](https://tabularasa.fandom.com/wiki/Dr._Hester): Pools, The Snakepit, /loc -961, 919, 469 (named as giver/receiver)

- **Chain** (explicit prerequisite links): Death Patrol chain (18 missions), step 1
  - Leads to: The Hermit (id 1327) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/The_Thirsty_Hermit)
  - Leads to: The Thirsty Hermit (id 1328) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/The_Thirsty_Hermit), this PR's World data (`mission_content_definition` / `mission_reward_*`)

### 1308 — Looking For Logos?


- **Instance mentioned:** Turpis Refinery — the name appears in the client mission text or the TaRapedia page; not shown to happen there (ESTIMATE)
- **Rebuild summary:**
  - level: 33 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`); 33 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Looking_for_Logos%3F); 35 — source: [TR MMO DB quest list](https://web.archive.org/web/20120731172517/http://tr.mmodb.com/quests/startingzone-pools/)
  - level ESTIMATE from zone: the Pools zone level range is 34-38 — source: [Ellatha map: Pools](https://www.ellatha.com/tr/Pools_Maps_Logos.asp) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 33, 10th–90th percentile) — derived from 39 missions in this file with a sourced level
  - reward: 60000 XP; 4950 credits; choose 1 of: Bio Armor Gloves, Graviton Armor Helmet, Mech Armor Gloves, Stealth Armor Gloves — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - reward: 60,000 XP; 4,950 credits; lvl 30; lvl 30; lvl 30; lvl 30 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Looking_for_Logos%3F)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: NPC Spymaster Timlin: Pools, The Snakepit, /loc -970, 915, 414 — source: [TaRapedia NPC](https://tabularasa.fandom.com/wiki/Spymaster_Timlin)
- **Client:** Search for the "Far" Logos.
  - objectives (client): Speak with Suresh — Speak with Scientist Suresh located at the South Listening Post in Valverdy Pools; Show Scientist Suresh the Far Logos — Show Scientis Suresh your Tablit containing the "Far" Logos.; Find the "Far" Logos and return to Scientist Suresh — Find the "Far" Logos and place it in your Tabula.; Objective Tracker
- **This PR:** revision `pools_1_16_5`, level 33, solo, category 10000061 (Battlefield (Pools)), giver Spymaster Timlin → Scientist Suresh
  - reward: 60000 XP; 4950 credits; choose 1 of: Bio Armor Gloves, Graviton Armor Helmet, Mech Armor Gloves, Stealth Armor Gloves
- **TaRapedia** [Looking for Logos?](https://tabularasa.fandom.com/wiki/Looking_for_Logos%3F): giver: Spymaster Timlin; at: The Snakepit; zone: Pools; level: 33; XP: 60,000; credits: 4,950; items: lvl 30; lvl 30; lvl 30; lvl 30; reward from: Scientist Suresh
  - overview: •; Search for the "Far" Logos.
  - objectives: • Speak with Suresh • Speak with Scientist Suresh located at the South Listening Post in Valverde Pools • Show Scientist Suresh the Far Logos • Only when you have Far Logos acquired before speaking to Suresh • Show Scientist Suresh your Tablit containing the "Far" Logos. • Find the "Far" Logos and return to Scientist Suresh • Find the "Far" Logos and place it in your Tabula.
  - walkthrough: You will easily find this logos in a cave at the back of the instance map. While not obvious looking at the map, when you reach a point in the complex that appears to extend off the map opposite the entrance, you are there. There are defenders in Eloh cave.
- **TaRapedia mission list** [The Snakepit mission list](https://tabularasa.fandom.com/wiki/The_Snakepit_mission_list): zone Pools, area The Snakepit, given by Spymaster Timlin
- **TaRapedia mission list** [Turpis Refinery mission list](https://tabularasa.fandom.com/wiki/Turpis_Refinery_mission_list): zone Pools, given by Scientist Suresh
- **NPCs (TaRapedia NPC pages):**
  - [Spymaster Timlin](https://tabularasa.fandom.com/wiki/Spymaster_Timlin): Pools, The Snakepit, /loc -970, 915, 414 (named as giver/receiver)

### 1314 — Building Materials


- **Rebuild summary:**
  - level: 33 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`); 33 — source: [TR MMO DB](https://web.archive.org/web/20080907092421/http://tr.mmodb.com/quests/building-materials-273.php)
  - level ESTIMATE from zone: the Pools zone level range is 34-38 — source: [Ellatha map: Pools](https://www.ellatha.com/tr/Pools_Maps_Logos.asp) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 33, 10th–90th percentile) — derived from 39 missions in this file with a sourced level
  - reward: 55000 XP; 5100 credits; choose 1 of: Bio Armor Vest, Graviton Armor Vest, Mech Armor Legs, Stealth Armor Vest — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - reward: 55,000 XP; 5,100 credits; lvl 35; lvl 35; lvl 35; lvl 35 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Building_Materials)
  - reward: 5100 (the page gives no unit; probably credits — ESTIMATE) — source: [TR MMO DB](https://web.archive.org/web/20080907092421/http://tr.mmodb.com/quests/building-materials-273.php)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: NPC Supply Chief Riggins: Pools, The Snakepit, /loc -967, 915, 400 — source: [TaRapedia NPC](https://tabularasa.fandom.com/wiki/Supply_Chief_Riggins)
  - location: Name Supply Chief Riggins / Category NPCs / Coordinates - 964.6, 915.7, 403.5 / Description Starts quest "Building Materials" / Continent / Related / Valverde — source: [IGN TR Vault](https://web.archive.org/web/20120717145656/http://tabularasavault.ign.com/View.php?view=NPC.Detail&id=16)
- **Client:** Supply Chief Riggins from The Snake Pit wants you to "harvest" materials from Bane Forces in Valverde Pools.
  - objectives (client): Collect Thrax Carapaces — Collect Thrax Carapaces from the dead bodies of Thrax soldiers from Valverde Pools; Collect Hunter Thigh Bones — Collect Hunter Thigh Bones from the dead bodies of Bane Hunters from Valverde Pools; Collect Howler Sinew — Collect Howler Sinew from the dead bodies of the Howlers from Valverde Pools
- **This PR:** revision `pools_1_16_5`, level 33, solo, category 10000061 (Battlefield (Pools)), giver Supply Chief Riggins
  - reward: 55000 XP; 5100 credits; choose 1 of: Bio Armor Vest, Graviton Armor Vest, Mech Armor Legs, Stealth Armor Vest
- **TaRapedia** [Building Materials](https://tabularasa.fandom.com/wiki/Building_Materials): giver: Supply Chief Riggins; at: The Snakepit; zone: Pools; XP: 55,000; credits: 5,100; items: lvl 35; lvl 35; lvl 35; lvl 35; reward from: Supply Chief Riggins
  - overview: Supply Master Riggins from The Snakepit wants you to "harvest" materials from Bane Forces in Valverde Pools.
  - objectives: • Collect Thrax Carapaces • Collect Thrax Carapaces from the dead bodies of Thrax soldiers from Valverde Pools • Thrax Carapaces 0 / 8 • Collect Hunter Thigh Bones • Collect Hunter Thigh Bones from the dead bodies of Bane Hunters from Valverde Pools • Hunter Thigh Bone 0 / 5 • Collect Howler Sinew • Colled Howler Sinew from the dead bodies of the Howlers from Valverde Pools • Howler Sinew 0 / 15
  - walkthrough: Walkthrough
- **TaRapedia mission list** [The Snakepit mission list](https://tabularasa.fandom.com/wiki/The_Snakepit_mission_list): zone Pools, area The Snakepit, given by Supply Chief Riggins
- **TR MMO DB** [Building Materials](https://web.archive.org/web/20080907092421/http://tr.mmodb.com/quests/building-materials-273.php): level: 33; starts at npc: Supply Chief Riggins; starts in zone: Pools; objectives: Collect Thrax Carapaces, Collect Hunter Thigh Bones, Collect Howler Sinews, Return to Supply Chief Riggins; reward: 5100
- **IGN TR Vault** [tabularasavault.ign.com/View.php?view=NPC.Detail&id=16](https://web.archive.org/web/20120717145656/http://tabularasavault.ign.com/View.php?view=NPC.Detail&id=16): “Name Supply Chief Riggins / Category NPCs / Coordinates - 964.6, 915.7, 403.5 / Description Starts quest "Building Materials" / Continent / Related / Valverde”
- **IGN TR Vault** [tabularasavault.ign.com/View.php?view=Npc.List&category_show_all=1&per …](https://web.archive.org/web/20120712175931/http://tabularasavault.ign.com/View.php?view=Npc.List&category_show_all=1&persist_search=1b97890fb44f287ca7117545aec03cc8&sort_field=Author&sort_dir=asc): “Continues "Lurking in the Shadows" / Supply Chief Riggins / Cyberus / 12-27-2007 / Starts quest "Building Materials" / Lietenant Feldman / Cyberus / 12-29-2007 / Sabotage the Tower”
- **Where (locations / coordinates):**
  - Name Supply Chief Riggins / Category NPCs / Coordinates - 964.6, 915.7, 403.5 / Description Starts quest "Building Materials" / Continent / Related / Valverde — source: [IGN TR Vault](https://web.archive.org/web/20120717145656/http://tabularasavault.ign.com/View.php?view=NPC.Detail&id=16)
- **NPCs (TaRapedia NPC pages):**
  - [Supply Chief Riggins](https://tabularasa.fandom.com/wiki/Supply_Chief_Riggins): Pools, The Snakepit, /loc -967, 915, 400 (named as giver/receiver)

### 1315 — Death Patrol


- **Instance mentioned:** Retread Caves — the name appears in the client mission text or the TaRapedia page; not shown to happen there (ESTIMATE)
- **Rebuild summary:**
  - level: 33 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`); 33 — source: [TR MMO DB](https://web.archive.org/web/20081202022721/http://tr.mmodb.com/quests/death-patrol-274.php)
  - level ESTIMATE from zone: the Pools zone level range is 34-38 — source: [Ellatha map: Pools](https://www.ellatha.com/tr/Pools_Maps_Logos.asp) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 33, 10th–90th percentile) — derived from 39 missions in this file with a sourced level
  - reward: 55000 XP; 5000 credits; choose 1 of: Photonic Blade, Area Healing Disc, Sonic Pistol, Pulse Staff — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - reward: 55,000 XP; 5,000 credits; Vextronics Photonic Blade lvl 31; Astra Radial Healing Disc lvl 35; AccuMax Sonic Pistol lvl 35; Pulsar Pulse Staff lvl 35 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Death_Patrol)
  - reward: 5000 (the page gives no unit; probably credits — ESTIMATE) — source: [TR MMO DB](https://web.archive.org/web/20081202022721/http://tr.mmodb.com/quests/death-patrol-274.php)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: NPC Supply Chief Riggins: Pools, The Snakepit, /loc -967, 915, 400 — source: [TaRapedia NPC](https://tabularasa.fandom.com/wiki/Supply_Chief_Riggins)
  - location: *Corporal Hayden: -602.8, 918.3, 599.1 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Death_Patrol)
  - location: *Private Kroh: -515.1, 874.0, 512.0 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Death_Patrol)
- **Client:** Supply Chief Riggins from The Snake Pit wants you to collect empty ammunition clips and dog tags from dead AFS soldiers found throughout Valverde Pools
  - objectives (client): Collect Dog Tags — Collect Dog Tags from fallen AFS Soldiers; Collect Empty Ammunition Clips — Collect Empty Ammunition Clips from fallen AFS Soldiers; Dropping the loot
- **This PR:** revision `pools_1_16_5`, level 33, solo, category 10000061 (Battlefield (Pools)), giver Supply Chief Riggins
  - reward: 55000 XP; 5000 credits; choose 1 of: Photonic Blade, Area Healing Disc, Sonic Pistol, Pulse Staff
- **TaRapedia** [Death Patrol](https://tabularasa.fandom.com/wiki/Death_Patrol): giver: Supply Chief Riggins; at: The Snakepit; zone: Pools; follow-up: The Thirsty Hermit The Supply Master; XP: 55,000; credits: 5,000; items: Vextronics Photonic Blade lvl 31; Astra Radial Healing Disc lvl 35; AccuMax Sonic Pistol lvl 35; Pulsar Pulse Staff lvl 35; reward from: Supply Chief Riggins
  - overview: Supply Chief Riggins from The Snakepit wants you to collect empty ammunition clips and dog tags from dead AFS soldiers fround throughout Valverde Pools.
  - objectives: • Collect Dog Tags • Collect 8 Dog Tags from fallen AFS soldiers • Collect Empty Ammunition Clips • Collect 16 Empty Ammunition Clips from fallen AFS soldiers
  - walkthrough: • Corporal Hayden: -602.8, 918.3, 599.1 • Private Kroh: -515.1, 874.0, 512.0 • Sergeant Tracey: -386, 862, 483 • Lieutenant Kling: -270.5, 663.2, 467.0 • Sergeant Evers: -293, 862, 454 • Lieutenant Kahoe: -545, 873, 412 • Private Spongberg: -442.9, 889.1, 386.5 on a large rock • Sergeant Pinella: 52.0, 858.0, 383.0 overlooking Nothing (logos) west of Retread Outpost • Sergeant Sweeney: -469.6, 890.7, 376.4 just west of Private Spongberg • Private Brown: -677.8, 662.9, 354.3 by a chopped-down tree • Private Taylor: -288, 856, 340 • Corporal Sheckard: -102, 851, 334 • Lieutenant Alton: -82, …
- **TaRapedia mission list** [The Snakepit mission list](https://tabularasa.fandom.com/wiki/The_Snakepit_mission_list): zone Pools, area The Snakepit, given by Supply Chief Riggins
- **TR MMO DB** [Death Patrol](https://web.archive.org/web/20081202022721/http://tr.mmodb.com/quests/death-patrol-274.php): level: 33; starts at npc: Supply Chief Riggins; starts in zone: Pools; objectives: Collect Dog Tags from Fallen AFS Soldiers (0/8), Collect Empty Ammunition Clips from Fallen AFS Soldiers (0/16), Return to Supply Chief Riggins; reward: 5000; series: Death Patrol
- **TR MMO DB quest series** [Death Patrol](https://web.archive.org/web/20120731161916/http://tr.mmodb.com/quests/seriesname-death_patrol/): A Cult Divided (level 33, reward 3400) → Death Patrol (level 33, reward 5000) → The Thirsty Hermit (level 33, reward 3400) (series order as listed on the page; reward unit not stated)
- **Where (locations / coordinates):**
  - *Corporal Hayden: -602.8, 918.3, 599.1 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Death_Patrol)
  - *Private Kroh: -515.1, 874.0, 512.0 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Death_Patrol)
  - *Sergeant Tracey: -386, 862, 483 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Death_Patrol)
  - *Lieutenant Kling: -270.5, 663.2, 467.0 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Death_Patrol)
- **NPCs (TaRapedia NPC pages):**
  - [Supply Chief Riggins](https://tabularasa.fandom.com/wiki/Supply_Chief_Riggins): Pools, The Snakepit, /loc -967, 915, 400 (named as giver/receiver)

- **Chain** (explicit prerequisite links): Death Patrol chain (18 missions), step 1
  - Leads to: More Clips and Tags (id 1321) — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - Leads to: The Supply Master (id 1322) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/The_Supply_Master), this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - Leads to: The Hermit (id 1327) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/The_Thirsty_Hermit)
  - Leads to: The Thirsty Hermit (id 1328) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/The_Thirsty_Hermit), this PR's World data (`mission_content_definition` / `mission_reward_*`)
- **TR MMO DB quest series:** "Death Patrol", row 2 of 3 ([list](https://web.archive.org/web/20120731161916/http://tr.mmodb.com/quests/seriesname-death_patrol/)). The row order is an ESTIMATE of the play order. The list does not say which mission unlocks which.

### 1321 — More Clips and Tags


- **Rebuild summary:**
  - level: 33 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - level ESTIMATE from zone: the Pools zone level range is 34-38 — source: [Ellatha map: Pools](https://www.ellatha.com/tr/Pools_Maps_Logos.asp) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 33, 10th–90th percentile) — derived from 39 missions in this file with a sourced level
  - reward: 27500 XP; 3400 credits — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - reward: 34000 credits — source: [TaRapedia](https://tabularasa.fandom.com/wiki/More_Clips_and_Tags)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: NPC Supply Chief Riggins: Pools, The Snakepit, /loc -967, 915, 400 — source: [TaRapedia NPC](https://tabularasa.fandom.com/wiki/Supply_Chief_Riggins)
  - location: : Lieutentant Moran -600,777,-7 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/More_Clips_and_Tags)
  - location: : Private Lundgren -503,777,-11 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/More_Clips_and_Tags)
- **Client:** Supply Chief Riggins from The Snake Pit wants you to collect more empty ammunition clips and dog tags from dead AFS soldiers found throughout Valverde Pools
  - objectives (client): Collect Dog Tags — Collect Dog Tags from fallen AFS Soldiers; Collect Empty Ammunition Clips — Collect Empty Ammunition Clips from fallen AFS Soldiers
- **This PR:** revision `pools_1_16_5`, level 33, solo, category 10000061 (Battlefield (Pools)), giver Supply Chief Riggins
  - reward: 27500 XP; 3400 credits
  - prerequisites: Requires completed mission 1315
- **TaRapedia** [More Clips and Tags](https://tabularasa.fandom.com/wiki/More_Clips_and_Tags) [stub]: giver: Supply Chief Riggins; at: The Snakepit; zone: Pools; credits: 34000; reward from: Supply Chief Riggins
  - overview: Supply Chief Riggins from the Snake Pit wants you to collect more empty ammunition clips and dog tags from Dead AFS soldiers found throughout Valverde Pools.
  - objectives: • Collect Dog Tags • 0/8 Tags • Collect Empty Clips • 0/16 Clips
  - walkthrough: • Lieutentant Moran -600,777,-7 • Private Lundgren -503,777,-11 • Corporal Schulte -667,777,39 • Lieutenant Hardy -560,631,214 • Captain Overall -560,843,250 • Private Kroh -515,674,513 • Sergeant Sweeny -470,890,377 • Sergeant Steinfeldt -427,885,657 • Private Fraser -446,906,291 • Lieutenant Kahoe -548,673,411 • Corporal Hofman -402,909,250 • Private Taylor -288,657,342
- **Where (locations / coordinates):**
  - : Lieutentant Moran -600,777,-7 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/More_Clips_and_Tags)
  - : Private Lundgren -503,777,-11 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/More_Clips_and_Tags)
  - : Corporal Schulte -667,777,39 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/More_Clips_and_Tags)
  - : Lieutenant Hardy -560,631,214 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/More_Clips_and_Tags)
- **NPCs (TaRapedia NPC pages):**
  - [Supply Chief Riggins](https://tabularasa.fandom.com/wiki/Supply_Chief_Riggins): Pools, The Snakepit, /loc -967, 915, 400 (named as giver/receiver)

- **Chain** (explicit prerequisite links): Death Patrol chain (18 missions), step 2
  - Requires: Death Patrol (id 1315) — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)

### 1322 — The Supply Master


- **Rebuild summary:**
  - level: 33 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`); 33 — source: [TR MMO DB quest list](https://web.archive.org/web/20120731172517/http://tr.mmodb.com/quests/startingzone-pools/)
  - level ESTIMATE from zone: the Pools zone level range is 34-38 — source: [Ellatha map: Pools](https://www.ellatha.com/tr/Pools_Maps_Logos.asp) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 33, 10th–90th percentile) — derived from 39 missions in this file with a sourced level
  - reward: 60000 XP; 5250 credits; choose 1 of: Weapon Module: Steal Adrenaline [4], Weapon Module: Steal Armor [4], Weapon Module: Steal Health [4], Weapon Module: Steal Power [4] — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - reward: 60,000 XP; 5,250 credits; Modification: Steal Adrenaline; Modification: Steal Armor; Modification: Steal Health; Modification: Steal Power — source: [TaRapedia](https://tabularasa.fandom.com/wiki/The_Supply_Master)
  - reward: 5250 (the page gives no unit; probably credits — ESTIMATE) — source: [TR MMO DB quest series list](https://web.archive.org/web/20120731161417/http://tr.mmodb.com/quests/seriesname-the_supply_master/)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: NPC Supply Chief Riggins: Pools, The Snakepit, /loc -967, 915, 400 — source: [TaRapedia NPC](https://tabularasa.fandom.com/wiki/Supply_Chief_Riggins)
- **Client:** Supply Chief Riggins wants you to "interrogate" the Bane Supply Master named Nakrinx. He can be found traveling between the Thrax Barracks and Lamna Armory.
  - objectives (client): Interrogate Nakrinx — Find and Interrogate the Bane Supply Master Nakrinx. You'll have to kill his bodyguards to get him to talk.; Return to Supply Chief Riggins — Return to Supply Chief Riggins a The Snake Pit
- **This PR:** revision `pools_1_16_5`, level 33, solo, category 10000061 (Battlefield (Pools)), giver Supply Chief Riggins
  - reward: 60000 XP; 5250 credits; choose 1 of: Weapon Module: Steal Adrenaline [4], Weapon Module: Steal Armor [4], Weapon Module: Steal Health [4], Weapon Module: Steal Power [4]
  - prerequisites: Requires completed mission 1315
- **TaRapedia** [The Supply Master](https://tabularasa.fandom.com/wiki/The_Supply_Master): giver: Supply Chief Riggins; at: The Snakepit; zone: Pools; requires: Death Patrol; follow-up: Eastern Listening Post; XP: 60,000; credits: 5,250; items: Modification: Steal Adrenaline; Modification: Steal Armor; Modification: Steal Health; Modification: Steal Power; reward from: Supply Chief Riggins
  - overview: Supply Chief Riggins wants you to "interrogate" the Bane Supply Master named Nakrinx. He can be found traveling between the Thrax Barracks and Lamna Armory.
  - objectives: • Interrogate Nakrinx • Find and Interrogate the Bane supply master Nakrinx. You'll have to kill his bodyguards to get him to talk.
  - walkthrough: Nakrinx can be found in and around the Thrax Barracks. Kill the four Thrax that patrol with him and be careful not to kill him. After they die, a mission indicator pops above his head, and you can interrogate him.
- **TaRapedia mission list** [The Snakepit mission list](https://tabularasa.fandom.com/wiki/The_Snakepit_mission_list): zone Pools, area The Snakepit, given by Supply Chief Riggins
- **TR MMO DB quest series** [The Supply Master](https://web.archive.org/web/20120731161417/http://tr.mmodb.com/quests/seriesname-the_supply_master/): Eastern Listening Post (level 35, reward 3600) → The Supply Master (level 33, reward 5250) (series order as listed on the page; reward unit not stated)
- **NPCs (TaRapedia NPC pages):**
  - [Supply Chief Riggins](https://tabularasa.fandom.com/wiki/Supply_Chief_Riggins): Pools, The Snakepit, /loc -967, 915, 400 (named as giver/receiver)
  - [Spymaster Timlin](https://tabularasa.fandom.com/wiki/Spymaster_Timlin): Pools, The Snakepit, /loc -970, 915, 414 (named in client text)

- **Chain** (explicit prerequisite links): Death Patrol chain (18 missions), step 2
  - Requires: Death Patrol (id 1315) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/The_Supply_Master), this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - Leads to: Eastern Listening Post (id 1323) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Eastern_Listening_Post), [TaRapedia](https://tabularasa.fandom.com/wiki/The_Supply_Master), this PR's World data (`mission_content_definition` / `mission_reward_*`)
- **TR MMO DB quest series:** "The Supply Master", row 2 of 2 ([list](https://web.archive.org/web/20120731161417/http://tr.mmodb.com/quests/seriesname-the_supply_master/)). The row order is an ESTIMATE of the play order. The list does not say which mission unlocks which.

### 1323 — Eastern Listening Post


- **Rebuild summary:**
  - level: 35 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`); 33 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Eastern_Listening_Post); 35 — source: [TR MMO DB quest list](https://web.archive.org/web/20120731172517/http://tr.mmodb.com/quests/startingzone-pools/)
  - level ESTIMATE from zone: the Pools zone level range is 34-38 — source: [Ellatha map: Pools](https://www.ellatha.com/tr/Pools_Maps_Logos.asp) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 33, 10th–90th percentile) — derived from 39 missions in this file with a sourced level
  - reward: 32500 XP; 3600 credits; Class VII EMP Bomb, Class VII Armor Charger, Class VII Incendiary Grenade, Class VII EMP Grenade — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - reward: 32,500 XP; 3,600 credits; Class VII EMP Bomb (2); Class VII Armor Charger (2); Class VII Incendiary Grenade (4); Class VII EMP Grenade (4) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Eastern_Listening_Post)
  - reward: 3600 (the page gives no unit; probably credits — ESTIMATE) — source: [TR MMO DB quest series list](https://web.archive.org/web/20120731161417/http://tr.mmodb.com/quests/seriesname-the_supply_master/)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: NPC Colonel 'Snake' Washington: Pools, The Snakepit, /loc -981, 915, 413 — source: [TaRapedia NPC](https://tabularasa.fandom.com/wiki/Colonel_%27Snake%27_Washington)
- **Client:** Colonel Snake Washington wants you to recover the lost supply package for the East Listening Post and deliver it to Lieutenant Chester.
  - objectives (client): Collect ELP Supply Package — Follow the beacon to the missing supply package for the Eastern Listening Post
- **This PR:** revision `pools_1_16_5`, level 35, solo, category 10000061 (Battlefield (Pools)), giver Colonel 'Snake' Washington → Lieutenant Chester
  - reward: 32500 XP; 3600 credits; items: Class VII EMP Bomb ×2, Class VII Armor Charger ×2, Class VII Incendiary Grenade ×4, Class VII EMP Grenade ×4
  - prerequisites: Requires completed mission 1322
- **TaRapedia** [Eastern Listening Post](https://tabularasa.fandom.com/wiki/Eastern_Listening_Post): giver: Colonel 'Snake' Washington; at: The Snakepit; zone: Pools; level: 33; requires: The Supply Master; follow-up: Smash and Grab; XP: 32,500; credits: 3,600; items: Class VII EMP Bomb (2); Class VII Armor Charger (2); Class VII Incendiary Grenade (4); Class VII EMP Grenade (4); reward from: Lieutenant Chester
  - overview: • Colonel Snake Washington wants you to recover the lost supply package for the East Listening Post and deliver it to Lieutenant Chester.
  - objectives: • Collect ELP Supply Package
  - walkthrough: The supply crate beacon is at x(240.4), y(-141.2) The closest teleports are the South Listening Post and the Control Point Bane Guard Station. The large supply crate is actually in a large crater. NOTE: One or more striders may spawn when you approach the crate.
- **TaRapedia mission list** [The Snakepit mission list](https://tabularasa.fandom.com/wiki/The_Snakepit_mission_list): zone Pools, area The Snakepit, given by Colonel 'Snake' Washington
- **TR MMO DB quest series** [The Supply Master](https://web.archive.org/web/20120731161417/http://tr.mmodb.com/quests/seriesname-the_supply_master/): Eastern Listening Post (level 35, reward 3600) → The Supply Master (level 33, reward 5250) (series order as listed on the page; reward unit not stated)
- **TR MMO DB NPC** [Lieutenant Chester](https://web.archive.org/web/20081205004007/http://tr.mmodb.com/bestiary/lieutenant-chester-708.php): Quest NPC, location East Listening Post, zone Pools (related to this quest)
- **NPCs (TaRapedia NPC pages):**
  - [Colonel 'Snake' Washington](https://tabularasa.fandom.com/wiki/Colonel_%27Snake%27_Washington): Pools, The Snakepit, /loc -981, 915, 413 (named as giver/receiver)
  - [Lieutenant Chester](https://tabularasa.fandom.com/wiki/Lieutenant_Chester): Pools, East Listening Post, /loc 1017.1, 656.5, 330.9 (named as giver/receiver)
  - [Spymaster Timlin](https://tabularasa.fandom.com/wiki/Spymaster_Timlin): Pools, The Snakepit, /loc -970, 915, 414 (named in client text)

- **Chain** (explicit prerequisite links): Death Patrol chain (18 missions), step 3
  - Requires: The Supply Master (id 1322) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Eastern_Listening_Post), [TaRapedia](https://tabularasa.fandom.com/wiki/The_Supply_Master), this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - Leads to: Smash and Grab (id 1324) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Eastern_Listening_Post), [TaRapedia](https://tabularasa.fandom.com/wiki/Smash_and_Grab), this PR's World data (`mission_content_definition` / `mission_reward_*`)
- **TR MMO DB quest series:** "The Supply Master", row 1 of 2 ([list](https://web.archive.org/web/20120731161417/http://tr.mmodb.com/quests/seriesname-the_supply_master/)). The row order is an ESTIMATE of the play order. The list does not say which mission unlocks which.

### 1324 — Smash and Grab


- **Rebuild summary:**
  - level: 35 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`); 35 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Smash_and_Grab); 35 — source: [TR MMO DB quest list](https://web.archive.org/web/20120731172517/http://tr.mmodb.com/quests/startingzone-pools/)
  - level ESTIMATE from zone: the Pools zone level range is 34-38 — source: [Ellatha map: Pools](https://www.ellatha.com/tr/Pools_Maps_Logos.asp) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 33, 10th–90th percentile) — derived from 39 missions in this file with a sourced level
  - reward: 130000 XP; 7200 credits; choose 1 of: Laser Chaingun, Cryogenic Net Gun, Electric Polarity Gun, Laser Rifle — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - reward: 130,000 XP; 7,200 credits; Shinobi Laser Chaingun lvl 33; Vitalius Cryogenic Net Gun lvl 36; Vitalius Electric Polarity Gun lvl 33; Eclipse Laser Rifle lvl 36 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Smash_and_Grab)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: NPC Lieutenant Chester: Pools, East Listening Post, /loc 1017.1, 656.5, 330.9 — source: [TaRapedia NPC](https://tabularasa.fandom.com/wiki/Lieutenant_Chester)
- **Client:** Lt. Chester located at the East Listening Post in Valverde Pools wants you to steal several supplies and destroy the Bane data servers from the Thrax Barracks.
  - objectives (client): Collect Thrax Ammo — Collect Thrax Ammunition from the Bane Barracks; Collect Plasma Capacitors — Collect Plasma Capacitors from the Bane Barracks; Collect Nutrient Paste from the Bane Barracks; Destroy Thrax Ammo Data Server — Destroy the Bane Data Sever located near the Thrax Ammunition dump.; Destroy Plasma Capacitor Data Server — Destroy the Bane Data Sever located near the Plasma Capacitor storage location.; Destroy Nutrient Paste Data Server — Destroy the Bane Data Sever located near the Nutrient Paste storage area; Additional Ammo — This is for One Man's Trash if active.
- **This PR:** revision `pools_1_16_5`, level 35, solo, category 10000061 (Battlefield (Pools)), giver Lieutenant Chester
  - reward: 130000 XP; 7200 credits; choose 1 of: Laser Chaingun, Cryogenic Net Gun, Electric Polarity Gun, Laser Rifle
  - prerequisites: Requires completed mission 1323
- **TaRapedia** [Smash and Grab](https://tabularasa.fandom.com/wiki/Smash_and_Grab): giver: Lieutenant Chester; at: East Listening Post; zone: Pools; level: 35; requires: Eastern Listening Post; follow-up: Spoils of War; XP: 130,000; credits: 7,200; items: Shinobi Laser Chaingun lvl 33; Vitalius Cryogenic Net Gun lvl 36; Vitalius Electric Polarity Gun lvl 33; Eclipse Laser Rifle lvl 36; reward from: Lieutenant Chester
  - overview: • Lt. Chester located at the East Listening Post in Valverde Pools wants you to steal several supplies and destroy the Bane data servers from the Thrax Barracks.
  - objectives: • Collect Thrax Ammo • Collect Plasma Capacitors • Collect Nutrient Paste from the Bane Barracks • Destroy Thrax Ammo Data Server • Destroy Plasma Capacitor Data Server • Destroy Nutrient Paste Data Server
  - walkthrough: The items needed are in the two main buildings. There are bosses in each of the buildings. In addition, the Supplymaster and his guards spawn in one of these buildings, so the number of enemies can immediately rise. This is particularly the case in the building housing the computers. The object is to move quickly into the main central room and on to an upper level. This way you can control the number of foes you face. Remaining in the hall will subject you to crossfire from respawning Bane troops.
- **TaRapedia mission list** [East Listening Post mission list](https://tabularasa.fandom.com/wiki/East_Listening_Post_mission_list): zone Pools, area East Listening Post, given by Lieutenant Chester
- **TR MMO DB NPC** [Lieutenant Chester](https://web.archive.org/web/20081205004007/http://tr.mmodb.com/bestiary/lieutenant-chester-708.php): Quest NPC, location East Listening Post, zone Pools (starts this quest)
- **PlanetTR** [planettr.com:80/forums/archive/index.php/t-1365.html](https://web.archive.org/web/20071209022816/http://planettr.com:80/forums/archive/index.php/t-1365.html): “o Issue: The ammo objective in One Man's Trash doesn't complete when the ammo is retrieved, preventing mission completion. / o Mission: Smash and Grab / o Issue: After collecting the three ammo crates required for Smash and Grab, the ammo crates objective doesn't complete, preventing completion of the mission.”
- **RGTR official site** [rgtr.com:80/news/patch_notes/patch_notes_and_known_issues_109.html](https://web.archive.org/web/20071011062613/http://rgtr.com:80/news/patch_notes/patch_notes_and_known_issues_109.html): “Issue: Containers holding mission items do not respawn, causing mission to be uncompletable / Mission: Smash and Grab / Issue: Containers holding mission items do not respawn, causing mission to be uncompletable”
- **RGTR official site** [www.rgtr.com/news/patch_notes/patch_notes_and_known_issues_1_4.html](https://web.archive.org/web/20081117172815/http://www.rgtr.com/news/patch_notes/patch_notes_and_known_issues_1_4.html): “Issue: The ammo objective in One Man's Trash doesn't complete when the ammo is retrieved, preventing mission completion. / Mission: Smash and Grab / Issue: After collecting the three ammo crates required for Smash and Grab, the ammo crates objective doesn't complete, preventing completion of the mission.”
- **NPCs (TaRapedia NPC pages):**
  - [Lieutenant Chester](https://tabularasa.fandom.com/wiki/Lieutenant_Chester): Pools, East Listening Post, /loc 1017.1, 656.5, 330.9 (named as giver/receiver)
  - [Spymaster Timlin](https://tabularasa.fandom.com/wiki/Spymaster_Timlin): Pools, The Snakepit, /loc -970, 915, 414 (named in client text)

- **Chain** (explicit prerequisite links): Death Patrol chain (18 missions), step 4
  - Requires: Eastern Listening Post (id 1323) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Eastern_Listening_Post), [TaRapedia](https://tabularasa.fandom.com/wiki/Smash_and_Grab), this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - Leads to: Spoils of War (id 1326) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Smash_and_Grab), [TaRapedia](https://tabularasa.fandom.com/wiki/Spoils_of_War), this PR's World data (`mission_content_definition` / `mission_reward_*`)

### 1326 — Spoils of War


- **Rebuild summary:**
  - level: 35 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - level ESTIMATE from zone: the Pools zone level range is 34-38 — source: [Ellatha map: Pools](https://www.ellatha.com/tr/Pools_Maps_Logos.asp) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 33, 10th–90th percentile) — derived from 39 missions in this file with a sourced level
  - reward: 32500 XP; 3600 credits; Class VII Advanced Med Pack, Class VII Power Charger, Class VII Cryogenic Grenade, Class VII Incendiary Grenade — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - reward: 32,500 XP; 3,600 credits; Class VII Advanced Med Pack (2); Class VII Power Charger (2); Class VII Cryogenic Grenade (4); Class VII Incendiary Grenade (4) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Spoils_of_War)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: NPC Lieutenant Chester: Pools, East Listening Post, /loc 1017.1, 656.5, 330.9 — source: [TaRapedia NPC](https://tabularasa.fandom.com/wiki/Lieutenant_Chester)
- **Client:** Report to Colonel Snake Washington at the Snake Pit in Valverde Pools
  - objectives (client): Report to Snake — Report to Colonel Snake Washington in Valverde Pools
- **This PR:** revision `pools_1_16_5`, level 35, solo, category 10000061 (Battlefield (Pools)), giver Lieutenant Chester → Colonel 'Snake' Washington
  - reward: 32500 XP; 3600 credits; items: Class VII Advanced Med Pack ×2, Class VII Power Charger ×2, Class VII Cryogenic Grenade ×4, Class VII Incendiary Grenade ×4
  - prerequisites: Requires completed mission 1324
- **TaRapedia** [Spoils of War](https://tabularasa.fandom.com/wiki/Spoils_of_War): giver: Lieutenant Chester; at: East Listening Post; zone: Pools; requires: Smash and Grab; follow-up: none; XP: 32,500; credits: 3,600; items: Class VII Advanced Med Pack (2); Class VII Power Charger (2); Class VII Cryogenic Grenade (4); Class VII Incendiary Grenade (4); reward from: Colonel 'Snake' Washington
  - overview: • Report to Colonel 'Snake' Washington.
  - objectives: • Report to Snake
  - walkthrough: This is the end of this mission story arc.
- **NPCs (TaRapedia NPC pages):**
  - [Lieutenant Chester](https://tabularasa.fandom.com/wiki/Lieutenant_Chester): Pools, East Listening Post, /loc 1017.1, 656.5, 330.9 (named as giver/receiver)
  - [Colonel 'Snake' Washington](https://tabularasa.fandom.com/wiki/Colonel_%27Snake%27_Washington): Pools, The Snakepit, /loc -981, 915, 413 (named as giver/receiver)

- **Chain** (explicit prerequisite links): Death Patrol chain (18 missions), step 9
  - Requires: Smash and Grab (id 1324) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Smash_and_Grab), [TaRapedia](https://tabularasa.fandom.com/wiki/Spoils_of_War), this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - Requires: Taking the Poison (id 1590) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Taking_the_Poison)

### 1328 — The Thirsty Hermit


- **Rebuild summary:**
  - level: 33 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`); 33 — source: [TR MMO DB quest list](https://web.archive.org/web/20120731172517/http://tr.mmodb.com/quests/startingzone-pools/)
  - level ESTIMATE from zone: the Pools zone level range is 34-38 — source: [Ellatha map: Pools](https://www.ellatha.com/tr/Pools_Maps_Logos.asp) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 33, 10th–90th percentile) — derived from 39 missions in this file with a sourced level
  - reward: 27500 XP; 3400 credits; Class VII Advanced Med Pack, Class VII Adrenaline Booster, Class VII Concussion Grenade, Class VII Fragmentation Grenade — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - reward: 27,500 XP; 3,400 credits; Class VII Advanced Med Pack (2); Class VII Adrenaline Booster (2); Class VII Concussion Grenade (4); Class VII Fragmentation Grenade (4) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/The_Thirsty_Hermit)
  - reward: 3400 (the page gives no unit; probably credits — ESTIMATE) — source: [TR MMO DB quest series list](https://web.archive.org/web/20120731161916/http://tr.mmodb.com/quests/seriesname-death_patrol/)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: NPC Supply Chief Riggins: Pools, The Snakepit, /loc -967, 915, 400 — source: [TaRapedia NPC](https://tabularasa.fandom.com/wiki/Supply_Chief_Riggins)
- **Client:** Supply Chief Riggins wants you to speak with Dr. Hester to introduce you to the Hermit in Valverde Pools.
  - objectives (client): Speak with the Hermit — Speak with the Hermit in Valverde Pools; Speak with Dr. Hester — Speak with Dr. Hester in the Snake Pit; Collect "Medicine" — Collect Dr Hester's "Medicine" for delivery to the Hermit in Valverde Pools
- **This PR:** revision `pools_1_16_5`, level 33, solo, category 10000061 (Battlefield (Pools)), giver Supply Chief Riggins → Hermit
  - reward: 27500 XP; 3400 credits; items: Class VII Advanced Med Pack ×2, Class VII Adrenaline Booster ×2, Class VII Concussion Grenade ×4, Class VII Fragmentation Grenade ×4
  - prerequisites: Requires completed mission 1315; Requires completed mission 1066
- **TaRapedia** [The Thirsty Hermit](https://tabularasa.fandom.com/wiki/The_Thirsty_Hermit): giver: Supply Chief Riggins; at: The Snakepit; zone: Pools; requires: Death Patrol; Medicinal Measures; follow-up: A Cult Divided; XP: 27,500; credits: 3,400; items: Class VII Advanced Med Pack (2); Class VII Adrenaline Booster (2); Class VII Concussion Grenade (4); Class VII Fragmentation Grenade (4); reward from: Hermit
  - overview: Supply Chief Riggins wants you to speak with Dr. Hester to introduce you to the Hermit in Valverde Pools.
  - objectives: • Speak with Dr. Hester • Speak with the Hermit
- **TaRapedia mission list** [The Snakepit mission list](https://tabularasa.fandom.com/wiki/The_Snakepit_mission_list): zone Pools, area The Snakepit, given by Supply Chief Riggins
- **TR MMO DB quest series** [Death Patrol](https://web.archive.org/web/20120731161916/http://tr.mmodb.com/quests/seriesname-death_patrol/): A Cult Divided (level 33, reward 3400) → Death Patrol (level 33, reward 5000) → The Thirsty Hermit (level 33, reward 3400) (series order as listed on the page; reward unit not stated)
- **NPCs (TaRapedia NPC pages):**
  - [Supply Chief Riggins](https://tabularasa.fandom.com/wiki/Supply_Chief_Riggins): Pools, The Snakepit, /loc -967, 915, 400 (named as giver/receiver)
  - [Hermit](https://tabularasa.fandom.com/wiki/Hermit): /loc -430, 921, 115 (named as giver/receiver)
  - [Dr. Hester](https://tabularasa.fandom.com/wiki/Dr._Hester): Pools, The Snakepit, /loc -961, 919, 469 (named in client text)

- **Chain** (explicit prerequisite links): Death Patrol chain (18 missions), step 2
  - Requires: Medicinal Measures (id 1066) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/The_Thirsty_Hermit), this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - Requires: Death Patrol (id 1315) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/The_Thirsty_Hermit), this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - Leads to: A Cult Divided (id 560) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/A_Cult_Divided), [TaRapedia](https://tabularasa.fandom.com/wiki/The_Thirsty_Hermit), this PR's World data (`mission_content_definition` / `mission_reward_*`)
- **TR MMO DB quest series:** "Death Patrol", row 3 of 3 ([list](https://web.archive.org/web/20120731161916/http://tr.mmodb.com/quests/seriesname-death_patrol/)). The row order is an ESTIMATE of the play order. The list does not say which mission unlocks which.

### 1330 — Retread Planning Part II


- **Rebuild summary:**
  - level: 33 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`); 33 — source: [TR MMO DB quest list](https://web.archive.org/web/20120731172517/http://tr.mmodb.com/quests/startingzone-pools/)
  - level ESTIMATE from zone: the Pools zone level range is 34-38 — source: [Ellatha map: Pools](https://www.ellatha.com/tr/Pools_Maps_Logos.asp) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 33, 10th–90th percentile) — derived from 39 missions in this file with a sourced level
  - reward: 30000 XP; 3500 credits; Class VII Advanced Med Pack, Class VII Armor Charger, Class VII Fragmentation Grenade, Class VII Cryogenic Grenade — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - reward: 30,000 XP; 3,500 credits; Class VII Advanced Med Pack (2); Class VII Armor Charger (2); Class VII Fragmentation Grenade (4); Class VII Cryogenic Grenade (4) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Retread_Planning_Part_II)
  - reward: 3500 (the page gives no unit; probably credits — ESTIMATE) — source: [TR MMO DB quest series list](https://web.archive.org/web/20120731164744/http://tr.mmodb.com/quests/seriesname-retread_planning/)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: NPC Hermit: /loc -430, 921, 115 — source: [TaRapedia NPC](https://tabularasa.fandom.com/wiki/Hermit)
- **Client:** Convince Amee Corman to let you help her with the attack on the Bane Barracks
  - objectives (client): Speak to Amee Corman — Speak to Amee Corman at the Retread Camp
- **This PR:** revision `pools_1_16_5`, level 33, solo, category 10000061 (Battlefield (Pools)), giver Hermit → Amee Corman
  - reward: 30000 XP; 3500 credits; items: Class VII Advanced Med Pack ×2, Class VII Armor Charger ×2, Class VII Fragmentation Grenade ×4, Class VII Cryogenic Grenade ×4
  - prerequisites: Requires completed mission 563
- **TaRapedia** [Retread Planning Part II](https://tabularasa.fandom.com/wiki/Retread_Planning_Part_II) [stub]: giver: Hermit; at: The Hermit; zone: Retread Camp; requires: Retread Planning; follow-up: Spy Networking; XP: 30,000; credits: 3,500; items: Class VII Advanced Med Pack (2); Class VII Armor Charger (2); Class VII Fragmentation Grenade (4); Class VII Cryogenic Grenade (4); reward from: Amee Corman
  - overview: Objectives: • Speak to Amee Gorman
  - objectives: • Speak to Amee Gorman
- **TR MMO DB quest series** [Retread Planning](https://web.archive.org/web/20120731164744/http://tr.mmodb.com/quests/seriesname-retread_planning/): Retread Planning (level 33, reward 0) → Retread Planning Part II (level 33, reward 3500) (series order as listed on the page; reward unit not stated)
- **TR MMO DB NPC** [Amee Corman](https://web.archive.org/web/20081010234322/http://tr.mmodb.com/bestiary/amee-corman-702.php): Quest NPC, location Retread Camp, zone Pools (related to this quest)
- **NPCs (TaRapedia NPC pages):**
  - [Hermit](https://tabularasa.fandom.com/wiki/Hermit): /loc -430, 921, 115 (named as giver/receiver)
  - [Amee Corman](https://tabularasa.fandom.com/wiki/Amee_Corman): Pools, Retread Camp (named as giver/receiver)

- **Chain** (explicit prerequisite links): Death Patrol chain (18 missions), step 6
  - Requires: Retread Planning (id 563) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Retread_Planning), [TaRapedia](https://tabularasa.fandom.com/wiki/Retread_Planning_Part_II), this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - Leads to: Spy Networking (id 1331) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Retread_Planning_Part_II), [TaRapedia](https://tabularasa.fandom.com/wiki/Spy_Networking)
- **TR MMO DB quest series:** "Retread Planning", row 2 of 2 ([list](https://web.archive.org/web/20120731164744/http://tr.mmodb.com/quests/seriesname-retread_planning/)). The row order is an ESTIMATE of the play order. The list does not say which mission unlocks which.

