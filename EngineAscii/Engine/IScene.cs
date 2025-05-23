namespace Engine.Engine;

public interface IScene // interface för scener
{
    void Load(); //laddar scen
    void Unload(); //laddar av scen
    void Update(double deltaTime); // spel logiken 
    void Render(); // drawing, ritar i consolen
}