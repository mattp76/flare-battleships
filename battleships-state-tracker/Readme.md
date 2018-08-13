# FlareHR Battleships

##Synopsis
The task is to implement a Battleship state-tracker for a single player that must support the following logic: 

# Create a board 
Add a battleship to the board.

Take an “attack” at a given position, and report back whether the attack resulted in a hit or a miss.

Return whether the player has lost the game yet (i.e. all battleships are sunk). 
 

##Prerequisites

Visual Studio 2017  
I built the application using Visual Studio 2017. 
.Net Version 4.6.1
There are one or two NUGET packages to help my along, such as AutoFac and Log4Net (which I didnt end up using). 


##Tests  
```
cd battleships-state-tracker.Tests
dotnet test
```
PLEASE NOTE. I have only setup the structure for the test projects. No tests have been added. I choose to use the likes of Autofac (IOC) for potential Mocking / Unit Testing.


##Contributors

Matthew Parker
mattp_76@hotmail.com
