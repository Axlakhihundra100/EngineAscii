using EngineAscii.Engine;
using System;
using System.Collections.Generic;
using Engine.Engine;
using OpenTK.Mathematics;
namespace EngineAscii.Scenes;

public class GameScene : IScene // genomför alla scen grejir 
{
    private List<Wall> walls;
    private List<DeadlyWall> deadlyWalls;
    private Vector2? exitPosition;
    private Player player;
    private InputManager input;
    private string levelFile;
    private int levelNumber;



    public GameScene(string levelFile, int levelNumber = 1)
    {
        this.levelFile = levelFile;
        this.levelNumber = levelNumber;
    }

    public void Load() // laddar från lvl.txt
    {
        input = new InputManager();
        var (loadedWalls, loadedDeadlyWalls, playerStart, exitPos) = LevelLoader.LoadLevel(levelFile);
        walls = loadedWalls;
        deadlyWalls = loadedDeadlyWalls;
        exitPosition = exitPos;
        player = new Player(playerStart, '@');
        //player = new Player(new Vector2(10,10), '@');
        //walls = new List<Wall>();   
        //for (int x = 5; x < 15; x++)
        //{
        //  walls.Add(new Wall(new Vector2(x, 5)));
        //}
    }   
    public void Unload() {}

    public void Update(double deltaTime)
    {
        input.Update();
        player.Update((float)deltaTime, input, walls);
        // dev shortcut :0
        if (input.IsKeyDown(ConsoleKey.N))
        {
            int nextLevel = levelNumber + 1;
            string nextFile = $"C:\\Users\\AxelEngan\\RiderProjects\\EngineAscii\\EngineAscii\\Scenes/lvl{nextLevel}.txt";
            if (File.Exists(nextFile))
            {
                SceneManager.LoadScene(new GameScene(nextFile, nextLevel));
            }
        }
        // checkar för död 
        if (deadlyWalls.Any(x => x.Position == player.Position))
        {
            Console.Clear();
            Console.WriteLine("You Died");
            Thread.Sleep(1000);
            SceneManager.LoadScene(new GameScene(levelFile, levelNumber));
        }
        // checkar för klar lvl 
        if (exitPosition.HasValue && player.Position == exitPosition.Value)
        {
            Console.Clear();
            Console.WriteLine("Level Complete");
            Thread.Sleep(1000);
            int nextLevel = levelNumber + 1;
            string nextFile = $"C:\\Users\\AxelEngan\\RiderProjects\\EngineAscii\\EngineAscii\\Scenes/lvl{nextLevel}.txt"; // FUNKAR NU 

            if (File.Exists(nextFile))
            {
                SceneManager.LoadScene(new GameScene(nextFile, nextLevel));

            }
            else
            {
                Console.WriteLine("Game Complete");
                Thread.Sleep(3000);
                Environment.Exit(0);
            }
            
        }
        
    }

    public void Render()
    {
        foreach (var wall in walls)
        {
            wall.Draw();
        }

        foreach (var xwall in deadlyWalls)
            xwall.Draw();
        if (exitPosition.HasValue)
        {
            var pos = exitPosition.Value;
            Console.SetCursorPosition((int)pos.X, (int)pos.Y);
            Console.WriteLine('E');
        }
        player.Draw();
    }
}