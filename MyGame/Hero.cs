using GameEngine;
using GameEngine;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class Hero: GameObject
    {
        private const float speed = 0.3f;
        private const int attackdelay = 300;
        private const int jumpdelay = 1000;
        private int _attacktimer;
        private int jumpduration = 0;
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
            if (0<jumpduration)
            {
                y-=2f;
                jumpduration-=1;
            }
            int msElapsed = elapsed.AsMilliseconds();
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                MyGame.WindowWidth += 1;
                MyGame.WindowHeight +=1;
            }
            if (y<320&&jumpduration==0)//if in the air and not jumping up 
            {
                float yincrease = 0.98f;
                y+= yincrease;//gravity -9.8m/s/s ->  100 pixels = 1 meter ms = 0.001 seconds | speed is pixels per millisecond gravity| speed down 980 pixels per second per second -> -0.98 pixels per millisecond per second
                if (elapsed.AsSeconds()%1 ==0)
                {
                    yincrease+=0.98f;
                }
            }
            if (_jumptimer >0) { _jumptimer -= msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && _jumptimer <=0)
            {
                y-=2f;
                jumpduration=50;
                jumpduration -=1;
                _jumptimer = 1000;
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
