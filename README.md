Battleships
========
[![.NET CI](https://github.com/Arkko002/Battleships-Task/actions/workflows/dotnet.yml/badge.svg)](https://github.com/Arkko002/Battleships-Task/actions/workflows/dotnet.yml)
[![Vue Client CI](https://github.com/Arkko002/Battleships-Task/actions/workflows/node.js.yml/badge.svg)](https://github.com/Arkko002/Battleships-Task/actions/workflows/node.js.yml)


## Table of Contents
1. [Table of Contents](#table-of-contents)
2. [Description](#description)
    * [Battleships](#battleships)
    * [API](#API)
    * [Vue Client](#vue-client)
3. [Getting started](#getting-started)
   * [Installation](#installation)
   * [Running](#running)
4. [Tests](#tests)
5. [Documentation](#documentation)

## Description

### Battleships 
Main component of the game that contains all of game related logic and behaviour.

#### IBattleshipsGame
Externally facing interface responsible for controlling flow of the game. Keeps track of current game progress, who's turn it is,
and exposes methods that allow to move the game forward or restart it.

#### IShips
Defines the common shared properties between the ships, like their coordinates, size, orientation.
The current coordinate offset system was meant to be expanded into 2D offsets that would allow for
creating custom, non-regular ship sizes and shapes, but I decided to use a simple orientation system
to somewhat reduce complexity of placing ships on boards.

IShips does not enforce any constraints on properties of the ships, which allows for easily extending
the standard set with new ideas.

Implementation of new custom ships can be done through extending IShip, IGameRules, and IShipFactory interface.

#### IGameRules and IWinningRules
Both game rules and victory rules are customizable and expose appropriate interfaces for that.
IWinningRules is used by IBattleshipsGames to determine the winner of current game. IWinningRules
doesn't provide a priority mechanism itself, but they are being stored in a sequential list, so the
first rule will always be evaluated first and have a precedence over the rest.

The two IWinningRules implementations that are provided implement the standard, default rules of battleships.

#### IPlayer and IPlayerStrategy
IPlayer interface represents all the data associated with a player, like his board, tracking board
and behaviour that is defined by IPlayerStrategy. IPlayer uses IPlayerStrategy to make decisions about
new moves, passes outputs to IBattleshipsGames and processes inputs it gets passed back.

Currently there is only one provided player strategy that relies on pseudo-randomness,
and servers as an example of interface implementation.

#### IBoard, IPlayersBoard and ITrackingBoard
IBoard defines shared properties of all boards, in this case just dimensions.

IPlayerBoard is used by IPlayer to store information about positions of his own ships in a 2D
array with object references pointing to appropriate IShip instances.

ITrackingBoard is used by IPlayer to track his shots against the opponents, and contains a 2D array
of enum fields that describe hits, misses and destroyed ships.

There is no code constraints against players playing on irregular boards, and that is intentional.
By extending IGameRules and IBoard it is possible to create a game where each player's board is shaped differently.

### API
A simple REST API created in ASP.NET Core that allows the Vue client to communicate with back end logic.
It registers IBattleshipsGame in it's DI container, and then retrieves it in BattleshipsController.

Default JSON serializer provided by ASP.NET Core Web API 2 doesn't support serializing 2D interface arrays
into JSON, so usage of NewtonsoftJson is required.

### Vue Client
Simple, one page client that displays current game status and allows to control it.
Communicates with API through Axios calls.

## Getting Started

### Installation
To download and build run
```
git clone https://github.com/Arkko002/Battleships-Task ;
cd Battleships-Task ;
dotnet build Battleships-Task.sln
```

### Running
API executables will be located in bin/ and can be run with
```
dotnet API.dll
```

Vue client is stored in API/ClientApp and can be run with
```
npm run serve
```

## Tests
Tests have been written in xUnit framework and can be found in "Tests" folder.

Tests can be run locally with
```
dotnet test
```

Tests are also run automatically in .NET CI Action, and their result can be seen in the badge included at the top of the readme.

## Documentation

Documentation is automatically generated from docstrings with Doxygen on each push to master and it can be found in the "Docs" folder.
They can also be viewed through Github Pages deployment at https://arkko002.github.io/Battleships-Task/

A sample Action on how to achieve that is provided in docs generation Action.
