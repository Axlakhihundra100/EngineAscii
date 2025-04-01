using EngineAscii.Engine;
using System;
using Engine.Engine;
using OpenTK.Mathematics;
namespace EngineAscii.Scenes;

public class GameScene : IScene
{
    private Player player;
    private InputManager input;

    public void Load()
    {
        input = new InputManager(); 
        player = new Player(new Vector2(10,10), '@');
    }   
    public void Unload() {}

    public void Update(double deltaTime)
    {
        input.Update();
        player.Update((float)deltaTime, input);
    }

    public void Render()
    {
        player.Draw();
    }
}