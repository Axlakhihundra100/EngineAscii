namespace EngineAscii.Engine;

public class InputManager // hanterar keyboard input 
{
    public ConsoleKey? CurrentKey { get; private set; }

    public void Update()
    {
        // kollar per frame ifall vilken som helst knapp trycks 
        if (Console.KeyAvailable)
        {
            CurrentKey = Console.ReadKey(true).Key;
        }
        else
        {
            CurrentKey = null;
        }
    }

    public bool IsKeyDown(ConsoleKey key) // kollar specifika knappar
    {
        return CurrentKey == key;
    }
}