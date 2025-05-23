namespace Engine.Engine;

public static class SceneManager // scene switch + scene "loop" 
{
    private static IScene currentScene;

    public static void LoadScene(IScene newScene)
    {
        currentScene?.Unload(); // cleanup scen 
        currentScene = newScene;
        currentScene.Load(); // ny scene 
    }

    public static void Update(double deltaTime)
    {
        currentScene?.Update(deltaTime);
    }

    public static void Render()
    {
        currentScene?.Render();
    }
}