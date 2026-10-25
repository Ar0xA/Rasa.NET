# Valverde Pools missions: playtest list, assumptions and deviations

Missions that are implemented (data, migrations and tests pass) but not yet played through in the
game client. `docs/pools-mission-crossref.md` gives the sources of each mission. A checked box
(`- [x]`) means the playtest is done and the mission works.

Format: `- [ ] <mission id> <name> (<zone>): <what to look at>`.

## Valverde Pools

- [ ] 1751 Retreads to Retreads (Valverde Pools -> Valverde Marshes): Amee Corman (Retread Camp, -145, 862, 521) offers it after 904 Weapons Trafficking. Talk to Retread Vincent in Retread City, Valverde Marshes (server spawn -276.8, 217.5, -761). No marker (the goal is on another map). Turn in at Vincent: 30000 XP, 3500 credits, 2 Class VII EMP Bombs, 2 Class VII Power Chargers, 4 Class VII Concussion Grenades, 4 Class VII Fragmentation Grenades (all given, no choice). Abandon and take it again.
- [ ] 1314 Building Materials (Valverde Pools): Supply Chief Riggins (new, Snake Pit, -964.6, 915.9, 403.5; officer uniform) offers it, no requirement. Thrax Carapaces (8) only from Thrax Soldier Mark IV, Hunter Thigh Bones (5) only from Hunter Trackers, Howler Sinew (15) only from Fiend Pup Howlers, each 50% a kill, picked up from the corpse. Are the parts visible on the corpse before pickup? Hunter Trackers stand in only 3 pools: are 5 bones a slow grind? Turn in at Riggins: 55000 XP, 5100 credits, one of Bio vest 46036, Graviton vest 25357, Mech legs 34354, Stealth vest 40611; he takes the parts.
- [ ] 1066 Medicinal Measures (Valverde Pools): Dr. Hester (new, Snake Pit, -961, 919.4, 469; officer uniform) offers it, no requirement. Ten personal Mawflowers (five models, two each) appear on accept in the field round (264, 680.6, -529); the marker is on the field. Each use takes 10 s and gives one nectar; a used plant closes. Do the plant models show (their classes end in DELETE)? Do they stand on the ground? Turn in at Hester: 27500 XP, 3400 credits, 2 Class VII EMP Bombs, 2 Class VII Armor Chargers, 4 Class VII EMP Grenades, 4 Class VII Concussion Grenades; the nectar goes. Abandon: the nectar and plants go; taken again, ten new plants.
- [ ] 1315 Death Patrol (Valverde Pools): Supply Chief Riggins offers it, no requirement. On accept 22 personal corpses (class 7654 "Slaughtered Ranger's Corpse") lie at TaRapedia's places over the west of the Pools (see `PoolsDeathPatrolV1.Bodies`). Each use takes 10 s, gives 1 Empty Ammo Clip and closes the corpse. While you have fewer than 8 Dog Tags, a corpse also gives a tag by chance (random bodies, each run its own); the 8th tag comes no later than the 16th corpse. Any 16 of the 22 corpses finish the mission; after the 16th the others give nothing. No marker. Does the corpse model show and stand on the ground (Kling and Brown are 200 m above TaRapedia's heights)? Does the client show the corpse as usable, and as searched after use (states 81 -> 82 and use argument 3 are not confirmed for class 7654)? Turn in at Riggins: 55000 XP, 5000 credits, one of Photonic Blade 47668, Area Healing Disc 120030, Sonic Pistol 14444, Pulse Staff 15216; he takes the tags and clips. Abandon: tags, clips and corpses go; taken again, 22 new corpses.
- [ ] 1321 More Clips and Tags (Valverde Pools): Riggins offers it after 1315, and again at once after each turn-in. 24 corpses (1315's 22 plus Corporal Schulte -667, 777, 39 and Sergeant Steinfeldt -427, 886, 657), same rules: 1 clip each, tags by chance until 8, any 16 corpses. Turn in at Riggins: 27500 XP and 3400 credits (both ESTIMATE), no item.
- [ ] 1328 The Thirsty Hermit (Valverde Pools): Riggins offers it after 1315 and 1066. Talk to Dr. Hester (objective 2) first. Then open "Dr. Hester's Medicine Cabinet", a personal crate (class 11078) next to her (-963, 919.4, 466): it gives the "Medicine" and closes (objective 3). Then talk to the Hermit on Fractured Butte (-430, 920.56, 115, objective 1): he takes the medicine. Markers on Hester, the cabinet and the Hermit. Turn in at the Hermit: 27500 XP, 3400 credits, 2 Class VII Advanced Med Packs, 2 Class VII Adrenaline Boosters, 4 Class VII Concussion Grenades, 4 Class VII Fragmentation Grenades. Does the crate show open after use (state 81 -> 82)?
- [ ] Colonel 'Snake' Washington moved (Valverde Pools): from (-968, 919.2, 363) to TaRapedia's /loc (-981, 915.6, 413). Does he stand on the ground at the Snake Pit? 1068 South Of The Border still ends at him.
- [ ] 1308 Looking For Logos? (Valverde Pools, instance): Spymaster Timlin (new, Snake Pit, -969.6, 915.8, 413; officer uniform, male) offers it, no requirement. Talk to Scientist Suresh at the South Listening Post (244, 664.6, -588; objective 1). Then take the "Far" Logos in Turpis Refinery (door on the Pools 148, 673, -607; shrine 40, 111.8, -224; same chunnel gap question as 1051), objective 3; a Far you already have counts once Suresh has talked. Then show it to Suresh (objective 2). Markers: Suresh, the Refinery door, Suresh. Turn in at Suresh: 60000 XP, 4950 credits, one of Bio Gloves 46011, Graviton Helmet 25079, Mech Gloves 34076, Stealth Gloves 40203.
- [ ] 1025 Mapping The Pools (Valverde Pools): Specialist Allen (new, in the field, -784.7, 936, 571.9; officer uniform) offers it, no requirement. Talk to Timlin (objective 1). Use the personal "GPS Beacons" pack (class 22987) by his cases (-965.3, 915.9, 428.1): it gives 5 GPS Beacons (item 743) and closes. Plant them at the five personal spots (class 7847, any order, markers on each): #1 -568.8, 900.4, 511.2; #2 -264.5, 866.7, 473.8; #3 -27.9, 818, 234.9; #4 -505.1, 777.9, -10.3; #5 -668.4, 858.6, 257.1. Does the spot show, and does it show the planted beacon after use (state 119 -> 121, model 21980)? Does the client let you use the spot (it may check the beacon's class)? Is #4 on the ground (2.4 m above TaRapedia's height)? "Beacons Placed" counts to 5. Then Timlin: choose "Praise Specialist Allen" or "Take Credit" (same result). Turn in at Allen: 25000 XP, 3300 credits, 2 Class VI EMP Bombs, 2 Class VI Adrenaline Boosters, 4 Class VI Incendiary Grenades, 4 Class VI EMP Grenades. Abandon: the beacons, pack and spots go.
- [ ] 932 Bane Investigation (Valverde Pools): Lieutenant Feldman (new, Snake Pit, -933.3, 920.8, 384.5; officer uniform) offers it, no requirement. A personal Bane terminal (class 10519 UsableNPCBaneKeyboard) stands at the fort's console (-790, 783.6, -11.3). Does its model show, and can you talk to it? One talk shows the map text and completes objectives 1 and 2. Objective 3 "Return to Lt. Feldman" then shows as a guide. Turn in at Feldman: 60000 XP, 5250 credits, one of Weapon Crit Hit Bonus [4] 123161, Armor Absorption [4] 122951, Tool Threat Reduction [4] 123141, Weapon Armor Piercing [4] 123146.

## Assumptions and choices (not from a source)

Rules carried over from the Plateau batch (`docs/plateau-playtest.md`):
- Client data first, then TaRapedia, TR MMO DB, IGN TR Vault, Ellatha, archived pages. Each value without a
  source is ESTIMATE in the mission's evidence rows.
- Named consumable rewards: the lowest template of each client class, all given (no choice).
- Rewards with no named item: the nearest Uncommon template of each kind at the mission's level.
- Manufacturer item names (Phoenix, Astra, Teleract, Prodigy) are not in the client tables: the Uncommon V04
  template of that kind and level band ("tier 4" on TaRapedia read as V04).
- New NPCs with no source for their look wear the look of the NPCs round them (ESTIMATE look).
- Drop rates with no source: 50% a kill (as PlateauCrystalBluePersuasionV1's crystals).

Per mission:
- 1751 Retreads to Retreads: revision `plateau_1_16_5` and category "Battlefield (Plateau)", not the Pools
  ones. It requires 904 Weapons Trafficking (Plateau revision), and upstream allows a required chain on one
  revision only (`MissionContentValidator`, "cross-revision-reference"). 904 has the same deviation.
  Reward items: Class VII EMP Bomb 111232 (the lower of two templates), Power Charger 118907, Concussion
  Grenade 111018, Fragmentation Grenade 45446.

- New NPCs at the Snake Pit (`PoolsSnakePitNpcsV1`): Supply Chief Riggins (650200) at IGN TR Vault's place
  (-964.6, 915.7, 403.5), Dr. Hester (650201) at TaRapedia's (-961, 919, 469); heights from the navmesh. Level
  40, AFS, male (TaRapedia). Look: the officer uniform that all Snake Pit NPCs wear on the server (no source
  describes them). Riggins's package is a server-only id 650200 (the client has none for him); Hester's is
  the client's 1129.
- 1314 Building Materials: "Thrax soldiers" read as the Thrax Soldier Mark IV only (not the Technician
  Sergeant or Commander of the same pools); "Bane Hunters" (client) / "Thrax Hunters" (TaRapedia briefing)
  as the Hunter Tracker; "Howlers" as the Fiend Pup Howler. 50% a kill. No marker (the creatures are all
  over the Pools). Rewards: Bio vest 46036, Graviton vest 25357, Mech legs 34354, Stealth vest 40611.
- 1066 Medicinal Measures: TaRapedia's first field (54.1, 665.7, 458.5) has no navmesh within 30 m (with
  z = -458.5 it is a flat area 2 m higher, maybe water). All ten plants stand in the second field round
  (267.4, 680.2, -530.0). Ten plants for ten nectar (no source gives a count). Plant classes 22518-22522
  (`UsableItemDispMawflowerV01DELETE`..`V05DELETE`): the client map places none, as 855's Saccharo
  Plant. A hidden tally counts the plants (no client counter text). The nectar goes with the mission at
  the turn-in. Rewards: Class VII EMP Bomb 111232, Armor Charger 118898, EMP Grenade 111028, Concussion
  Grenade 111018.
- 1315 Death Patrol (user's choices, 2026-10-25): 22 personal corpses at TaRapedia's places (heights from
  the navmesh; for Kling and Brown TaRapedia gives heights 200 m below the ground, 663 where the navmesh is
  at 863, so 200 m is added). Corpse class 7654
  `UsableItemDispGuardPromCorpse` ("Slaughtered Ranger's Corpse"): no AFS corpse class gives items. Each corpse
  gives 1 clip. A tag by chance while the player has fewer than 8: chance = tags still needed / clips still
  needed, so all 8 come by the 16th corpse (scene script `pools.fallen-soldiers`). Any 16 of 22 finish. Objective
  3 "Dropping the loot" (no text in any source) is left out: Riggins takes the items at the turn-in. Reward
  items: the Uncommon template of each named kind and level band (manufacturer names not in the client).
  No marker (corpses over the whole west of the Pools).
- Engine change for 1315/1321: a scene counter (`CompleteOnDistinctScenarioEvents`) can now complete at K of
  its N events (before: only all N). Needed for "any 16 of 22".
- 1321 More Clips and Tags: requires 1315 and repeats at once (PlanetTR, Dec 2007). TaRapedia's "34000"
  credits read as a typo for 3400 (ESTIMATE). 27500 XP: no source (ESTIMATE, as 1066). Corpses: 1315's 22 plus
  TaRapedia's Schulte and Steinfeldt.
- 1328 The Thirsty Hermit: 1328 built, not its client twin 1327 (user's choice). Requires 1315 and 1066
  (TaRapedia). Order 2, 3, 1 (the offer text and Hester's line). The cabinet: the client places no usable
  cabinet, so a personal AFS item crate (class 11078) next to Hester (user's choice). Reward items: the lowest
  template of each client class, all given.
- Colonel 'Snake' Washington: moved to TaRapedia's /loc (-981, 915, 413) at height 915.6 on the navmesh (user's
  choice). IGN TR Vault's place (-979.2, 927.5, 402.6) is on a small navmesh island 12 m up (a roof).

- 1308 Looking For Logos?: objective 4 "Objective Tracker" (no text) is left out. Objective 3's marker is on the Refinery door on the Pools; inside the instance it points at the same coordinates of the instance map (the server's marker has no map).
- 1025 Mapping The Pools: Timlin's answers to the two choices (client flags 122 and 123) are not shown: the choice completes objective 9 at once. "Take Credit" gives no bonus (user decision; no source gives the amount). Objective 11 and item 744 GPS Data are not used. Pack, beacon spots and their classes are ESTIMATEs (the client map places none).
- 932 Bane Investigation: no keycard and no Cipher; a plain talk at the terminal (user decision). The terminal class 10519 is an ESTIMATE (the client's "Bane CammLink Terminal" class is not known). Objective 3 has no client line, so it is not required: the turn-in at Feldman ends the mission.
- Spymaster Timlin, Specialist Allen, Lieutenant Feldman: new NPCs (the server did not have them), in the Snake Pit's officer uniform (ESTIMATE). Timlin is male (client 1025 texts) and level 40, not TaRapedia's female level 50.

## Server data that differs from the sources (not changed)

- Amee Corman: server spawn (-144.7, 861.6, 520.5). TaRapedia (-150, 861, 539) and IGN TR Vault
  (-153.7, 861.7, 539.8) put her about 19 m away. Not moved (not part of a mission change).
- Retread Vincent: server spawn (-276.8, 217.5, -761). TaRapedia /loc (-268, 216, -812), about 50 m away. Not moved.
