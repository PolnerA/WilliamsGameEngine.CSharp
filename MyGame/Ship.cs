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
    class Ship : GameObject
    {
        private const float Speed = 0.3f;
        private const int FireDelay = 200;
        private int _fireTimer;
        private readonly Sprite _sprite = new Sprite();
        // Creates our ship.
        public Ship()
        {
            _sprite.Texture = Game.GetTexture("../../../Resources/ship.png");
            _sprite.Position = new Vector2f(100, 100);
        }
        // functions overridden from GameObject:
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

            if (Keyboard.IsKeyPressed(Keyboard.Key.W)) { y -= Speed * msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S)) { y += Speed * msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.A)) { x -= Speed * msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.D)) { x += Speed * msElapsed; }
            _sprite.Position = new Vector2f(x, y);

            if(_fireTimer >0) { _fireTimer -= msElapsed; }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && _fireTimer <= 0)
            {
                _fireTimer = FireDelay;
                FloatRect bounds = _sprite.GetGlobalBounds();
                float laserX = x+bounds.Width;
                float laserY = y+bounds.Height / 2.0f;
                float laser2Y = y+bounds.Height/3f;
                float laser3y = y+bounds.Height/1.5f;
                Laser laser = new Laser(new Vector2f(laserX, laserY));
                Laser laser2 = new Laser(new Vector2f(laserX,laser2Y));
                Laser laser3 = new Laser(new Vector2f(laserX, laser3y));
                Meteor meteor = new Meteor(new Vector2f(x+bounds.Width, y+bounds.Height/2.0f));
                Game.CurrentScene.AddGameObject(laser);
                Game.CurrentScene.AddGameObject(laser2);
                Game.CurrentScene.AddGameObject(laser3);
                Game.CurrentScene.AddGameObject(meteor);
            }
        }
    }
}
