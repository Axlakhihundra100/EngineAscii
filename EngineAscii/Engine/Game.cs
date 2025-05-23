using Engine.Engine;
using EngineAscii.Scenes;
using OpenTK.Windowing.Common;

namespace EngineAscii.Engine;
using System;
using System.Threading;
using OpenTK.Windowing.Desktop;

public class Game // loop
{
    private IScene currentScene; // aktiv scen 
    public void run()
    {
        Console.CursorVisible = false;
        // laddar lvl1
        SceneManager.LoadScene(new GameScene("C:\\Users\\AxelEngan\\RiderProjects\\EngineAscii\\EngineAscii\\Scenes\\lvl1.txt"));
        var stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();
        double previousTime = stopwatch.Elapsed.TotalSeconds;

        while (true) // själva loopen 
        {
            double currentTime = stopwatch.Elapsed.TotalSeconds;
            double deltaTime = currentTime - previousTime;
            previousTime = currentTime;
            
            // updatar scene + render
            SceneManager.Update(deltaTime);
            Console.Clear();
            //Console.SetCursorPosition(0, 0); - Fixar screen flickering MEN då måste jag fixa logik för att ta bort old player ;0 
            SceneManager.Render();
            Thread.Sleep(50); 
        }
    }
}