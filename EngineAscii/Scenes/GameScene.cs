using EngineAscii.Engine;
using System;
using System.Collections.Generic;
using Engine.Engine;
using OpenTK.Mathematics;
namespace EngineAscii.Scenes;

public class GameScene : IScene
{
    private List<Wall> walls;
    private Player player;
    private InputManager input;

    public void Load()
    {
        input = new InputManager(); 
        player = new Player(new Vector2(10,10), '@');
        walls = new List<Wall>();
        for (int x = 5; x < 15; x++)
        {
            walls.Add(new Wall(new Vector2(x, 5)));
        }
    }   
    public void Unload() {}

    public void Update(double deltaTime)
    {
        input.Update();
        player.Update((float)deltaTime, input);
    }

    public void Render()
    {
        foreach (var wall in walls)
        {
            wall.Draw();
        }
        player.Draw();
    }
}