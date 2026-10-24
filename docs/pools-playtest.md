# Valverde Pools missions: playtest list, assumptions and deviations

Missions that are implemented (data, migrations and tests pass) but not yet played through in the
game client. `docs/pools-mission-crossref.md` gives the sources of each mission. A checked box
(`- [x]`) means the playtest is done and the mission works.

Format: `- [ ] <mission id> <name> (<zone>): <what to look at>`.

## Valverde Pools

- [ ] 1751 Retreads to Retreads (Valverde Pools -> Valverde Marshes): Amee Corman (Retread Camp, -145, 862, 521) offers it after 904 Weapons Trafficking. Talk to Retread Vincent in Retread City, Valverde Marshes (server spawn -276.8, 217.5, -761). No marker (the goal is on another map). Turn in at Vincent: 30000 XP, 3500 credits, 2 Class VII EMP Bombs, 2 Class VII Power Chargers, 4 Class VII Concussion Grenades, 4 Class VII Fragmentation Grenades (all given, no choice). Abandon and take it again.

## Assumptions and choices (not from a source)

Rules carried over from the Plateau batch (`docs/plateau-playtest.md`):
- Client data first, then TaRapedia, TR MMO DB, IGN TR Vault, Ellatha, archived pages. Each value without a
  source is ESTIMATE in the mission's evidence rows.
- Named consumable rewards: the lowest template of each client class, all given (no choice).
- Rewards with no named item: the nearest Uncommon template of each kind at the mission's level.

Per mission:
- 1751 Retreads to Retreads: revision `plateau_1_16_5` and category "Battlefield (Plateau)", not the Pools
  ones. It requires 904 Weapons Trafficking (Plateau revision), and upstream allows a required chain on one
  revision only (`MissionContentValidator`, "cross-revision-reference"). 904 has the same deviation.
  Reward items: Class VII EMP Bomb 111232 (the lower of two templates), Power Charger 118907, Concussion
  Grenade 111018, Fragmentation Grenade 45446.

## Server data that differs from the sources (not changed)

- Amee Corman: server spawn (-144.7, 861.6, 520.5). TaRapedia (-150, 861, 539) and IGN TR Vault
  (-153.7, 861.7, 539.8) put her about 19 m away. Not moved (not part of a mission change).
- Retread Vincent: server spawn (-276.8, 217.5, -761). TaRapedia /loc (-268, 216, -812), about 50 m away. Not moved.
