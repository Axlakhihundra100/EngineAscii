Usage: 
Install any IDE (c#) Preferably JetBrainsRider v(2024.1.1)
Clone project. (Latest Major .NET) 
Terminal:
  cd EngineAscii
  dotnet build
  dotnet run
  Game should run (the terminal may have to be enlarged to fit the level) 

Code: 
Program.cs, Starts the game 
Game.cs, Runs the game loop
SceneManager.cs, Switches/Updates scenes 
IScene.cs, Defines the interface all scenes must use
GameScene.cs, THE "GameScene", WORK IN PROGRESS ((doesnt work)(as intended) :(, handles logic and rendering 
LevelLoader.cs, .txt to objects
Player.cs, player logic, handles player input
Wall.cs, Wall... 
DeadlyWall.cs, DeadlyWall...
Entity.cs, Unused for now (ignore) 
InputManager.cs, Captures keyboard input and abstracts 


