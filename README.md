# World Cup API Linq
![alt text](https://media.giphy.com/media/kgsqn9gCVAQ3YM3C2f/giphy.gif)

This API allows to get informations about all world cups.

This project contains two data sources:
- worldCup.json : which contains a list of general informations from all World Cups, for example:
```json
[
  {
    "year": 2022,
    "champion": "Argentina",
    "second": "France",
    "third": "Croatia",
    "host": "Qatar",
    "nbTeams": 32,
    "nbMatches": 64,
    "nbGoals": 172
  },
  ...
]
```
- goldenBall.cs : which contains a list of golden ball top 3 from all World Cups, for example:
```json
[
  {
    "year": 2022,
    "winner": "Lionel Messi",
    "second": "Kylian Mbappé",
    "third": "Luka Modrić"
  },
  ...
]
```


## Controllers: World Cup
### GET /api/worldCup/getAll
Description: get all world cups

Example response:
```json
[
  {
    "year": 2022,
    "champion": "Argentina",
    "second": "France",
    "third": "Croatia",
    "host": "Qatar",
    "nbTeams": 32,
    "nbMatches": 64,
    "nbGoals": 172
  },
  {
    "year": 2018,
    "champion": "France",
    "second": "Croatia",
    "third": "Belgium",
    "host": "Russia",
    "nbTeams": 32,
    "nbMatches": 64,
    "nbGoals": 169
  },
  ...
]
```

### GET /api/worldCup/getAllSortedBy?sortedBy={property}:
Description: get all world cups sorted by a property.


### Example:
Request: ```GET /api/worldCup/getAllSortedBy?sortedBy=year```

Response:
```json
[
  {
    "year": 1930,
    "champion": "Uruguay",
    "second": "Argentina",
    "third": "United States",
    "host": "Uruguay",
    "nbTeams": 13,
    "nbMatches": 16,
    "nbGoals": 70
  },
  {
    "year": 1934,
    "champion": "Italy",
    "second": "Czechia",
    "third": "Germany",
    "host": "Italy",
    "nbTeams": 16,
    "nbMatches": 17,
    "nbGoals": 70
  },
  ...
]
```

### GET /api/worldCup/search?{property}={value}
Description: search world cup

### Example:
Request: ```GET /api/worldCup/search?champion=France```

Response:
```json
[
  {
    "year": 2018,
    "champion": "France",
    "second": "Croatia",
    "third": "Belgium",
    "host": "Russia",
    "nbTeams": 32,
    "nbMatches": 64,
    "nbGoals": 169
  },
  {
    "year": 1998,
    "champion": "France",
    "second": "Brazil",
    "third": "Croatia",
    "host": "France",
    "nbTeams": 32,
    "nbMatches": 64,
    "nbGoals": 171
  },
  ...
]
```

### GET /api/worldCup/greatherThan?{property}>{value}
Description: search world cups using a greater than (>) condition

Properties available:
- year
- nbTeams
- nbMatches
- nbGoals

### Example:
Request: ```GET /api/worldCup/greatherThan?nbGoals>150```

Response:
```json
[
  {
    "year": 2022,
    "champion": "Argentina",
    "second": "France",
    "third": "Croatia",
    "host": "Qatar",
    "nbTeams": 32,
    "nbMatches": 64,
    "nbGoals": 172
  },
  {
    "year": 2018,
    "champion": "France",
    "second": "Croatia",
    "third": "Belgium",
    "host": "Russia",
    "nbTeams": 32,
    "nbMatches": 64,
    "nbGoals": 169
  },
  ...
]
```

### GET /api/worldCup/smallerThan?{property}<{value}
Description: search world cups using a smaller than (<) condition

Properties available:
- year
- nbTeams
- nbMatches
- nbGoals

### Example:
Request: ```GET /api/worldCup/smallerThan?nbTeams<32```

Response:
```json
[
    {
    "year": 1994,
    "champion": "Brazil",
    "second": "Italy",
    "third": "Sweden",
    "host": "United States",
    "nbTeams": 24,
    "nbMatches": 52,
    "nbGoals": 141
  },
  {
    "year": 1990,
    "champion": "Germany",
    "second": "Argentina",
    "third": "Italy",
    "host": "Italy",
    "nbTeams": 24,
    "nbMatches": 52,
    "nbGoals": 115
  },
  ...
]
```

## Controllers: Golden Ball
### GET /api/goldenBall/getAll
Description: get all golden balls

Example response:
```json
[
  {
    "year": 1982,
    "winner": "Paolo Rossi",
    "second": "Falcão",
    "third": "Karl-Heinz Rummenigge"
  },
  {
    "year": 1986,
    "winner": "Diego Maradona",
    "second": "Harald Schumacher",
    "third": "Preben Elkjær"
  }
  ...
]
```

### GET /api/goldenBall/getAllSortedBy?sortedBy={property}:
Description: get all golden balls sorted by a property.


### Example:
Request: ```GET /api/goldenBall/getAllSortedBy?sortedBy=year```

Response:
```json
[
  {
    "year": 1982,
    "winner": "Paolo Rossi",
    "second": "Falcão",
    "third": "Karl-Heinz Rummenigge"
  },
  {
    "year": 1986,
    "winner": "Diego Maradona",
    "second": "Harald Schumacher",
    "third": "Preben Elkjær"
  },
  ...
]
```

### GET /api/goldenBall/search?{property}={value}
Description: search golden ball

### Example:
Request: ```GET /api/goldenBall/search?winner=Zidane```

Response:
```json
[
  {
    "year": 2006,
    "winner": "Zinedine Zidane",
    "second": "Fabio Cannavaro",
    "third": "Andrea Pirlo"
  }
]
```

### GET /api/goldenBall/greatherThan?{property}>{value}
Description: search golden balls using a greater than (>) condition

Properties available:
- year

### Example:
Request: ```GET /api/goldenBall/greatherThan?year>2000```

Response:
```json
[
  {
    "year": 2002,
    "winner": "Oliver Kahn",
    "second": "Ronaldo",
    "third": "Hong Myung-bo"
  },
  {
    "year": 2006,
    "winner": "Zinedine Zidane",
    "second": "Fabio Cannavaro",
    "third": "Andrea Pirlo"
  },
  ...
]
```

### GET /api/goldenBall/smallerThan?{property}<{value}
Description: search golden balls using a smaller than (<) condition

Properties available:
- year

### Example:
Request: ```GET /api/worldCup/smallerThan?year<1990```

Response:
```json
[
  {
    "year": 1982,
    "winner": "Paolo Rossi",
    "second": "Falcão",
    "third": "Karl-Heinz Rummenigge"
  },
  {
    "year": 1986,
    "winner": "Diego Maradona",
    "second": "Harald Schumacher",
    "third": "Preben Elkjær"
  }
]
```
