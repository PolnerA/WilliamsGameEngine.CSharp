﻿using GameEngine;
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
        private const double V=0.3;
        float Speed = (float)V;
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
        }
    }
}
