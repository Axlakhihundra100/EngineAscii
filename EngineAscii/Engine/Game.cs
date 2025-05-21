using Engine.Engine;
using EngineAscii.Scenes;
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
        SceneManager.LoadScene(new GameScene("C:\\Users\\AxelEngan\\RiderProjects\\EngineAscii\\EngineAscii\\Scenes\\lvl1.txt"));
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