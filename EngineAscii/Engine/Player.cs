namespace EngineAscii.Engine;
using System;
using OpenTK.Mathematics;

public class Player
{
    public Vector2 Position;
    private char Symbol;

    public Player(Vector2 startposition, char symbol)
    {
        Position = startposition;
        Symbol = symbol;
    }

    public void Update(float deltaTime, InputManager input, List<Wall> walls)
    {
        // uppdaterar position baserat på input
        Vector2 newPosition = Position;

        if (input.IsKeyDown(ConsoleKey.W)) newPosition.Y--; 
        if (input.IsKeyDown(ConsoleKey.S)) newPosition.Y++;
        if (input.IsKeyDown(ConsoleKey.A)) newPosition.X--;
        if (input.IsKeyDown(ConsoleKey.D)) newPosition.X++;

        // löser vägg problemen :0 (halvt) :X
        bool collides = walls.Any(wall => wall.Position == newPosition);
        if (!collides)
        {
            Position = newPosition;
        }
    }


    public void Draw()
    {
        // ritar spelaren på rätt plats 
        int safeTop = Math.Clamp((int)Position.Y, 0, Console.BufferHeight - 1);
        int safeWidth = Math.Clamp((int)Position.X, 0, Console.BufferWidth - 1);
        string left;
//        Console.WriteLine($"Cursor: left={safeWidth}, top={safeTop}, Max Height={Console.BufferHeight}");
        Console.SetCursorPosition(safeWidth, safeTop);
        Console.Write(Symbol);
    }
}