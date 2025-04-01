namespace EngineAscii.Engine;

public class InputManager
{
    public ConsoleKey? CurrentKey { get; private set; }

    public void Update()
    {
        if (Console.KeyAvailable)
        {
            CurrentKey = Console.ReadKey(true).Key;
        }
        else
        {
            CurrentKey = null;
        }
    }

    public bool IsKeyDown(ConsoleKey key)
    {
        return CurrentKey == key;
    }
}