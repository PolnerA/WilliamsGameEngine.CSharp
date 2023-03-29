using GameEngine;
using GameEngine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Hero: GameObject
    {
        private const float speed = 0.3f;
        private const int attackdelay = 300;
        private const int jumpdelay = 300;
        private int _attacktimer;
        private int _jumptimer;
        private readonly Sprite _sprite = new Sprite();
        public Hero()
        {
            _sprite.Texture = Game.GetTexture("../../../Resources/Hero.png");
            _sprite.Position = new Vector2f(540,320);
        }
        public override void Draw()
        {
            Game.RenderWindow.Draw(_sprite);
        }
        public override void Update(Time elapsed)
        {

            Vector2f pos = _sprite.Position;
            float x = pos.X;
            float y = pos.Y;

            int msElapsed = elapsed.AsMilliseconds();
            if (Keyboard.IsKeyPressed(Keyboard.Key.A)) { x -= speed * msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.D)) { x += speed * msElapsed; }
            if (y<320)
            {
                y+=0.98f;
            }
            if (-_jumptimer >0) { _jumptimer -= msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && _jumptimer <=0 && y ==320)
            {
                y-=0.98f;
            }
            _sprite.Position = new Vector2f(x, y);

            /*
            if (-_attacktimer >0) { _attacktimer -= msElapsed; }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && _attacktimer <= 0)
            {
                _attacktimer = attackdelay;
                FloatRect bounds = _sprite.GetGlobalBounds();
                float laserX = x+bounds.Width/2.0f;
                float laserY = y+bounds.Height / 2.0f;
                float laser2Y = y+bounds.Height;
                float laser3y = y;
                Laser laser = new Laser(new Vector2f(laserX, laserY));
                Laser laser2 = new Laser(new Vector2f(laserX, laser2Y));
                Laser laser3 = new Laser(new Vector2f(laserX, laser3y));
                Game.CurrentScene.AddGameObject(laser);
                Game.CurrentScene.AddGameObject(laser2);
                Game.CurrentScene.AddGameObject(laser3);
            }
            */
        }
    }
}
