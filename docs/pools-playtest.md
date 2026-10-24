# Valverde Pools missions: playtest list, assumptions and deviations

Missions that are implemented (data, migrations and tests pass) but not yet played through in the
game client. `docs/pools-mission-crossref.md` gives the sources of each mission. A checked box
(`- [x]`) means the playtest is done and the mission works.

Format: `- [ ] <mission id> <name> (<zone>): <what to look at>`.

## Valverde Pools

- [ ] 1751 Retreads to Retreads (Valverde Pools -> Valverde Marshes): Amee Corman (Retread Camp, -145, 862, 521) offers it after 904 Weapons Trafficking. Talk to Retread Vincent in Retread City, Valverde Marshes (server spawn -276.8, 217.5, -761). No marker (the goal is on another map). Turn in at Vincent: 30000 XP, 3500 credits, 2 Class VII EMP Bombs, 2 Class VII Power Chargers, 4 Class VII Concussion Grenades, 4 Class VII Fragmentation Grenades (all given, no choice). Abandon and take it again.
- [ ] 1314 Building Materials (Valverde Pools): Supply Chief Riggins (new, Snake Pit, -964.6, 915.9, 403.5; officer uniform) offers it, no requirement. Thrax Carapaces (8) only from Thrax Soldier Mark IV, Hunter Thigh Bones (5) only from Hunter Trackers, Howler Sinew (15) only from Fiend Pup Howlers, each 50% a kill, picked up from the corpse. Are the parts visible on the corpse before pickup? Hunter Trackers stand in only 3 pools: are 5 bones a slow grind? Turn in at Riggins: 55000 XP, 5100 credits, one of Bio vest 46036, Graviton vest 25357, Mech legs 34354, Stealth vest 40611; he takes the parts.
- [ ] 1066 Medicinal Measures (Valverde Pools): Dr. Hester (new, Snake Pit, -961, 919.4, 469; officer uniform) offers it, no requirement. Ten personal Mawflowers (five models, two each) appear on accept in the field round (264, 680.6, -529); the marker is on the field. Each use takes 10 s and gives one nectar; a used plant closes. Do the plant models show (their classes end in DELETE)? Do they stand on the ground? Turn in at Hester: 27500 XP, 3400 credits, 2 Class VII EMP Bombs, 2 Class VII Armor Chargers, 4 Class VII EMP Grenades, 4 Class VII Concussion Grenades; the nectar goes. Abandon: the nectar and plants go; taken again, ten new plants.

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

## Server data that differs from the sources (not changed)

- Amee Corman: server spawn (-144.7, 861.6, 520.5). TaRapedia (-150, 861, 539) and IGN TR Vault
  (-153.7, 861.7, 539.8) put her about 19 m away. Not moved (not part of a mission change).
- Retread Vincent: server spawn (-276.8, 217.5, -761). TaRapedia /loc (-268, 216, -812), about 50 m away. Not moved.
