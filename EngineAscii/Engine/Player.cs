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

    public void Update(float deltaTime, InputManager input)
    {
        if (input.IsKeyDown(ConsoleKey.W)) Position.Y--;
        if (input.IsKeyDown(ConsoleKey.S)) Position.Y++;
        if (input.IsKeyDown(ConsoleKey.A)) Position.X--;
        if (input.IsKeyDown(ConsoleKey.D)) Position.X++;
    }

    public void Draw()
    {
        int safeTop = Math.Clamp((int)Position.Y, 0, Console.BufferHeight - 1);
        int safeWidth = Math.Clamp((int)Position.X, 0, Console.BufferWidth - 1);
        string left;
//        Console.WriteLine($"Cursor Position: left={safeWidth}, top={safeTop}, Max BufferHeight={Console.BufferHeight}");
        Console.SetCursorPosition(safeWidth, safeTop);
        Console.Write(Symbol);
    }
}