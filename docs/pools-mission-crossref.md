# Valverde Pools missions: sources (cross-reference)

The 12 missions of the Valverde Pools quest PR, taken from the full mission cross-reference of the 1.16.5.0
client. For each mission: the client text and objectives, the sources found (TaRapedia, TR MMO DB, Ellatha,
Ten Ton Hammer, archived fan and official pages, patch notes) and a rebuild summary with the source of each
value. Values without a source are marked ESTIMATE. "This PR" rows (where present) show the data this PR adds.

Playtest status and the deviations from the original game: `docs/pools-playtest.md`.

| Zone | Missions |
| --- | ---: |
| Plateau | 1 |
| Pools | 11 |

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

### 932 — Bane Investigation


- **Rebuild summary:**
  - level: 35 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`); 35 — source: [TR MMO DB](https://web.archive.org/web/20080829154110/http://tr.mmodb.com/quests/bane-investigation-267.php)
  - level ESTIMATE from zone: the Pools zone level range is 34-38 — source: [Ellatha map: Pools](https://www.ellatha.com/tr/Pools_Maps_Logos.asp) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 35, 10th–90th percentile) — derived from 34 missions in this file with a sourced level
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
  - Leads to: Sabotage the Tower (id 937) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Bane_Investigation), [TaRapedia](https://tabularasa.fandom.com/wiki/Sabotage_the_Tower)
- **TR MMO DB quest series:** "Bane Investigation", row 1 of 3 ([list](https://web.archive.org/web/20120731170309/http://tr.mmodb.com/quests/seriesname-bane_investigation/)). The row order is an ESTIMATE of the play order. The list does not say which mission unlocks which.

### 937 — Sabotage the Tower


- **Rebuild summary:**
  - level: 35 — source: [TR MMO DB](https://web.archive.org/web/20081010181037/http://tr.mmodb.com/quests/sabotage-the-tower-269.php)
  - level ESTIMATE from zone: the Pools zone level range is 34-38 — source: [Ellatha map: Pools](https://www.ellatha.com/tr/Pools_Maps_Logos.asp) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 35, 10th–90th percentile) — derived from 34 missions in this file with a sourced level
  - reward: 60,000 XP; 5,250 credits; Prodigy Conical Repair Tool lvl 35; Vextronics Electric Pistol lvl 35; Teleract Virulent Disperser lvl 32; Eclipse EMP Torqueshell Rifle lvl 32 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Sabotage_the_Tower)
  - reward: 5250 (the page gives no unit; probably credits — ESTIMATE) — source: [TR MMO DB](https://web.archive.org/web/20081010181037/http://tr.mmodb.com/quests/sabotage-the-tower-269.php)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: NPC Lieutenant Feldman: Pools, The Snakepit, /loc -934, 920, 381 — source: [TaRapedia NPC](https://tabularasa.fandom.com/wiki/Lieutenant_Feldman)
- **Client:** Destroy the Bane personnel and their equipment protecting the Eloh Obelisk.
  - objectives (client): Destroy the Bane Equipment; Eliminate the Linkers guarding the Eloh Relic site.
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
  - Requires: Bane Investigation (id 932) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Bane_Investigation), [TaRapedia](https://tabularasa.fandom.com/wiki/Sabotage_the_Tower)
  - Leads to: Bane Jamming (id 938) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Bane_Jamming), [TaRapedia](https://tabularasa.fandom.com/wiki/Sabotage_the_Tower)
  - Leads to: Elimination (id 941) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Elimination), [TaRapedia](https://tabularasa.fandom.com/wiki/Sabotage_the_Tower)
- **TR MMO DB quest series:** "Bane Investigation", row 3 of 3 ([list](https://web.archive.org/web/20120731170309/http://tr.mmodb.com/quests/seriesname-bane_investigation/)). The row order is an ESTIMATE of the play order. The list does not say which mission unlocks which.

### 938 — Bane Jamming


- **Rebuild summary:**
  - level: 35 — source: [TR MMO DB](https://web.archive.org/web/20081010182144/http://tr.mmodb.com/quests/bane-jamming-268.php)
  - level ESTIMATE from zone: the Pools zone level range is 34-38 — source: [Ellatha map: Pools](https://www.ellatha.com/tr/Pools_Maps_Logos.asp) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 35, 10th–90th percentile) — derived from 34 missions in this file with a sourced level
  - reward: 120,000 XP; 7,000 credits; lvl 35; lvl 34; lvl 33; lvl 34 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Bane_Jamming)
  - reward: 950 (the page gives no unit; probably credits — ESTIMATE) — source: [TR MMO DB](https://web.archive.org/web/20081010182144/http://tr.mmodb.com/quests/bane-jamming-268.php)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: NPC Lieutenant Feldman: Pools, The Snakepit, /loc -934, 920, 381 — source: [TaRapedia NPC](https://tabularasa.fandom.com/wiki/Lieutenant_Feldman)
- **Client:** Prevent the Bane from tapping into the Eloh tower by destroying any attached equipment and by burying Jammers surrounding the tower.
  - objectives (client): Destroy the Bane Equipment attached to the Eloh Obelisk; Place Jammer: Alpha; Place Jammer: Beta; Place Jammer: Gamma; Place Jammer: Delta; Place Jammer: Epsilon; Place Jammer: Zeta
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
  - Requires: Sabotage the Tower (id 937) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Bane_Jamming), [TaRapedia](https://tabularasa.fandom.com/wiki/Sabotage_the_Tower)
- **TR MMO DB quest series:** "Bane Investigation", row 2 of 3 ([list](https://web.archive.org/web/20120731170309/http://tr.mmodb.com/quests/seriesname-bane_investigation/)). The row order is an ESTIMATE of the play order. The list does not say which mission unlocks which.

### 941 — Elimination


- **Rebuild summary:**
  - level: 35 — source: [TR MMO DB](https://web.archive.org/web/20080907092013/http://tr.mmodb.com/quests/elimination-265.php)
  - level ESTIMATE from zone: the Pools zone level range is 34-38 — source: [Ellatha map: Pools](https://www.ellatha.com/tr/Pools_Maps_Logos.asp) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 35, 10th–90th percentile) — derived from 34 missions in this file with a sourced level
  - reward: 60,000 XP; 5,250 credits; AccuMax Chaingun lvl 33; AccuMax Incendiary Net Gun lvl 36; Vitalius Exothermic Polarity Gun lvl 33; Eclipse Shotgun lvl 32 — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Elimination)
  - reward: 1760 (the page gives no unit; probably credits — ESTIMATE) — source: [TR MMO DB](https://web.archive.org/web/20080907092013/http://tr.mmodb.com/quests/elimination-265.php)
  - drops / mission items: not found (not critical, or not a collect mission)
  - location: NPC Colonel 'Snake' Washington: Pools, The Snakepit, /loc -981, 915, 413 — source: [TaRapedia NPC](https://tabularasa.fandom.com/wiki/Colonel_%27Snake%27_Washington)
- **Client:** Eliminate the Bane Officer name Prysiam located in the vacinity of the Eloh Obelisk in Western Valverde Pools.
  - objectives (client): Eliminate Overseer Prysiam
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
  - Requires: Sabotage the Tower (id 937) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/Elimination), [TaRapedia](https://tabularasa.fandom.com/wiki/Sabotage_the_Tower)

### 1025 — Mapping The Pools


- **Rebuild summary:**
  - level: 35 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`); 35 — source: [TR MMO DB quest list](https://web.archive.org/web/20120731172517/http://tr.mmodb.com/quests/startingzone-pools/)
  - level ESTIMATE from zone: the Pools zone level range is 34-38 — source: [Ellatha map: Pools](https://www.ellatha.com/tr/Pools_Maps_Logos.asp) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 35, 10th–90th percentile) — derived from 34 missions in this file with a sourced level
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
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 35, 10th–90th percentile) — derived from 34 missions in this file with a sourced level
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
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 35, 10th–90th percentile) — derived from 34 missions in this file with a sourced level
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
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 35, 10th–90th percentile) — derived from 34 missions in this file with a sourced level
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
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 35, 10th–90th percentile) — derived from 34 missions in this file with a sourced level
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
  - Leads to: The Supply Master (id 1322) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/The_Supply_Master)
  - Leads to: The Hermit (id 1327) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/The_Thirsty_Hermit)
  - Leads to: The Thirsty Hermit (id 1328) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/The_Thirsty_Hermit), this PR's World data (`mission_content_definition` / `mission_reward_*`)
- **TR MMO DB quest series:** "Death Patrol", row 2 of 3 ([list](https://web.archive.org/web/20120731161916/http://tr.mmodb.com/quests/seriesname-death_patrol/)). The row order is an ESTIMATE of the play order. The list does not say which mission unlocks which.

### 1321 — More Clips and Tags


- **Rebuild summary:**
  - level: 33 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`)
  - level ESTIMATE from zone: the Pools zone level range is 34-38 — source: [Ellatha map: Pools](https://www.ellatha.com/tr/Pools_Maps_Logos.asp) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 35, 10th–90th percentile) — derived from 34 missions in this file with a sourced level
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

### 1328 — The Thirsty Hermit


- **Rebuild summary:**
  - level: 33 — source: this PR's World data (`mission_content_definition` / `mission_reward_*`); 33 — source: [TR MMO DB quest list](https://web.archive.org/web/20120731172517/http://tr.mmodb.com/quests/startingzone-pools/)
  - level ESTIMATE from zone: the Pools zone level range is 34-38 — source: [Ellatha map: Pools](https://www.ellatha.com/tr/Pools_Maps_Logos.asp) (a zone range, not this mission's own level)
  - level ESTIMATE from zone: most Pools missions are level 33–35 (median 35, 10th–90th percentile) — derived from 34 missions in this file with a sourced level
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
  - Leads to: A Cult Divided (id 560) — source: [TaRapedia](https://tabularasa.fandom.com/wiki/A_Cult_Divided), [TaRapedia](https://tabularasa.fandom.com/wiki/The_Thirsty_Hermit)
- **TR MMO DB quest series:** "Death Patrol", row 3 of 3 ([list](https://web.archive.org/web/20120731161916/http://tr.mmodb.com/quests/seriesname-death_patrol/)). The row order is an ESTIMATE of the play order. The list does not say which mission unlocks which.

