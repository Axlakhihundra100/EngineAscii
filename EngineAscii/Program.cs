using EngineAscii.Engine;

namespace EngineAscii;

public class Program
{
    static void Main()
    {
        using (Game game = new Game())
        {
            game.Run();
        }
    }
}