using OpenTK.Mathematics;

namespace EngineAscii.Engine;

public class DeadlyWall
{
    public Vector2 Position;
    private char Symbol = 'X';

    public DeadlyWall(Vector2 position)
    {
        Position = position;
    }

    public void Draw()
    {
        int safeTop = Math.Clamp((int)Position.Y, 0, Console.BufferHeight - 1);
        int safeWidth = Math.Clamp((int)Position.X, 0, Console.BufferWidth - 1);
        Console.SetCursorPosition(safeWidth, safeTop);
        Console.Write(Symbol);
    }
}