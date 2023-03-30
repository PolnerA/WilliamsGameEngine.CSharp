using GameEngine;

namespace MyGame
{
    class MyGame
    {
        public int WindowWidth = 1080;
        public int WindowHeight = 720;

        private const string WindowTitle = "Adventure Land";

        private static void Main(string[] args)
        {
            // Initialize the game.
            Game.Initialize(WindowWidth, WindowHeight, WindowTitle);

            // Create our scene.
            GameScene scene = new GameScene();
            Game.SetScene(scene);

            // Run the game loop.
            Game.Run();
        }
    }
}