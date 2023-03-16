using GameEngine;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    class MeteorSpawner : GameObject
    {
        //num of milliseconds pre meteor spawn
        private const int SpawnDelay = 1000;

        private int _timer;

        public void Update(TimeOnly elapsed)
        { 
            //determine time passed and adjusts the timer
            int msElapsed = elapsed.AsMilliseconds();
            _timer -= msElapsed;
            // if the timer elapses it spawns a meteor
            if (_timer <= 0) 
            {
                _timer = SpawnDelay;
                Vector2u size = Game.RenderWindow.Size;
                // spawn the meteor on the right side
                // meteor isnt more than 100 pixels
                float meteorX = size.X + 100;
                // spawn the meteor somewhere along the window height at random
                float meteorY = Game.Random.Next() % size.Y;
                //create meteor and add it to scene
                Meteor meteor = new Meteor(new Vector2f(meteorX, meteorY));
                Game.CurrentScene.AddGameObject(meteor);
            }
        }
    }
}
