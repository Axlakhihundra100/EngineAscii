using OpenTK.Mathematics;

namespace EngineAscii.Engine;

public class DeadlyWall
{
    public Vector2 Position; //positionen i consolen
    private char Symbol = 'X'; // väggen = X 

    public DeadlyWall(Vector2 position)
    {
        Position = position;
    }

    public void Draw() // ritar i consolen
    {
        // math.clamp för att kringå consol storleks problem 
        int safeTop = Math.Clamp((int)Position.Y, 0, Console.BufferHeight - 1);
        int safeWidth = Math.Clamp((int)Position.X, 0, Console.BufferWidth - 1);
        Console.SetCursorPosition(safeWidth, safeTop);
        Console.Write(Symbol);
    }
}