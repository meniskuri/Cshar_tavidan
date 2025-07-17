using Raylib_cs;

class Program
{
    static void Main()
    {
        Raylib.InitWindow(800, 600, "Hero Game");
        Raylib.SetTargetFPS(60);

        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.BLACK);
            Raylib.DrawText("🧙‍♂️ Hello Hero!", 300, 280, 20, Color.GREEN);
            Raylib.EndDrawing();
        }

        Raylib.CloseWindow();
    }
}
