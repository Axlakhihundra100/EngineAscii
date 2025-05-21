using OpenTK.Mathematics;

namespace EngineAscii.Engine;


public static class LevelLoader
{
    public static (List<Wall> walls, List<DeadlyWall> deadlyWalls, Vector2 playerStart, Vector2? exitPosition) LoadLevel(string filePath)
    {
        var walls = new List<Wall>();
        var deadlyWalls = new List<DeadlyWall>();
        Vector2 playerStart = new Vector2(1, 1); // Def Postion
        Vector2? exitPosition = null;
        string[] lines = File.ReadAllLines(filePath);
        for (int y = 0; y < lines.Length; y++)
        {
            var line = lines[y];
            for (int x = 0; x < line.Length; x++)
            {
                char ch = line[x];
                Vector2 pos = new Vector2(x, y);
                switch (ch)
                {
                    case '#':
                        walls.Add(new Wall(new Vector2(x, y)));
                        break;
                    case '@':
                        playerStart = new Vector2(x, y);
                        break;
                    case 'X':
                        deadlyWalls.Add(new DeadlyWall(pos));
                        break;
                    case 'E':
                        exitPosition = pos;
                        break;
                    // byggbar
                }
            }
        }

        return (walls, deadlyWalls, playerStart, exitPosition);
    }
}