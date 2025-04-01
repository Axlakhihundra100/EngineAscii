using Engine.Engine;
using OpenTK.Windowing.Common;

namespace EngineAscii.Engine;
using System;
using System.Threading;
using OpenTK.Windowing.Desktop;

public class Game : GameWindow
{
    private IScene currentScene;
    public Game() : base(GameWindowSettings.Default, NativeWindowSettings.Default) {}

    protected override void OnLoad()
    {
        base.OnLoad();
        Console.CursorVisible = false;
        SceneManager.LoadScene(new Scenes.GameScene());
    }

    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        base.OnUpdateFrame(args);
        SceneManager.Update(args.Time);
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        base.OnRenderFrame(args);
        Console.Clear();
        SceneManager.Render();
        Thread.Sleep(50); 
    }
}