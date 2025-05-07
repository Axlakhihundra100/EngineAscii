using Engine.Engine;
using OpenTK.Windowing.Common;

namespace EngineAscii.Engine;
using System;
using System.Threading;
using OpenTK.Windowing.Desktop;

public class Game
{
    private IScene currentScene;
    public void run()
    {
        Console.CursorVisible = false;
        SceneManager.LoadScene(new Scenes.GameScene());
        var stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        double previousTime = stopwatch.Elapsed.TotalSeconds;

        while (true)
        {
            double currentTime = stopwatch.Elapsed.TotalSeconds;
            double deltaTime = currentTime - previousTime;
            previousTime = currentTime;
            SceneManager.Update(deltaTime);
            Console.Clear();
            SceneManager.Render();
            Thread.Sleep(50); 
        }
    }
}