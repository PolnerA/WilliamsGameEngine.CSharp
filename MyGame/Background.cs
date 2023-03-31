using System;
using GameEngine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Background : GameObject
    {
        private const float Speed = 0.3f;
        private readonly Sprite _sprite = new Sprite();
        private readonly Sprite _sprite2 = new Sprite();
        private readonly Sprite tilemiddle = new Sprite();
        private readonly Sprite tilesouth = new Sprite();
        private readonly Sprite tilewest = new Sprite();
        private readonly Sprite tileeast = new Sprite();
        private readonly Sprite tilenorth = new Sprite();
        public Background()
        {
            _sprite.Texture = Game.GetTexture("../../../Resources/background.png");
            _sprite2.Texture = Game.GetTexture("../../../Resources/background.png");
            tilemiddle.Texture = Game.GetTexture("../../../Resources/64X32tile.png");
            tilesouth.Texture = Game.GetTexture("../../../Resources/64X32tile.png");
            tilewest.Texture = Game.GetTexture("../../../Resources/64X32tile.png");
            tilenorth.Texture = Game.GetTexture("../../../Resources/64X32tile.png");
            tileeast.Texture = Game.GetTexture("../../../Resources/64X32tile.png");
            tilesouth.Position= new Vector2f(132, 536);
            tilemiddle.Position = new Vector2f(100, 520);
            tilewest.Position = new Vector2f(132, 504);
            tilenorth.Position = new Vector2f(68,504);
            tileeast.Position = new Vector2f(68, 536);
            _sprite2.Position = new Vector2f(1080, 0);
            _sprite.Position = new Vector2f(0, 0);
        }
        public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
            Game.RenderWindow.Draw(_sprite2);
            Game.RenderWindow.Draw(tilemiddle);
            Game.RenderWindow.Draw(tilesouth);
            Game.RenderWindow.Draw(tileeast);
            Game.RenderWindow.Draw(tilewest);
            Game.RenderWindow.Draw(tilenorth);
        }
        public override void Update(Time elapsed)
        {
            Vector2f pos = _sprite.Position;
            Vector2f pos2 =_sprite2.Position;
            Vector2f posmiddle = tilemiddle.Position;
            Vector2f possouth = tilesouth.Position;
            Vector2f poswest = tilewest.Position;
            Vector2f posnorth = tilenorth.Position;
            Vector2f poseast = tileeast.Position
            float x2 = pos2.X;
            float y2 = pos2.Y;
            float x = pos.X;
            float y = pos.Y;
            float x3 = pos3.X;
            float y3 = pos3.Y;
            float x4 = pos4.X;
            float y4 = pos4.Y;
            int msElapsed = elapsed.AsMilliseconds();
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                x4 = x3 + 32;
                y4 = y3+16;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.D)) 
            { 
                x -= Speed * msElapsed;
                x2 -= Speed * msElapsed;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.A)) 
            { 
                x += Speed * msElapsed;
                x2 += Speed * msElapsed;
            }
            if (x < -1080)
            {
                x+=2160;
            }
            if (x2 <-1080)
            {
                x2+=2160;
            }
            if (1080<x)
            {
                x -= 2160;
            }
            if (1080<x2)
            {
                x2-= 2160;
            }
            _sprite2.Position = new Vector2f(x2,y2);
            _sprite.Position = new Vector2f(x, y);
            tilemiddle.Position = new Vector2f(x3, y3);
            tilesouth.Position = new Vector2f(x4,y4);
        }
    }
}
