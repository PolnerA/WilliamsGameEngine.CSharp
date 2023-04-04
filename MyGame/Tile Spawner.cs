﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using GameEngine;
using SFML.Graphics;
using SFML.System;

namespace MyGame
{
    class Tile_Spawner :GameObject
    {
        private const int SpawnDelay = 1000;
        private int _timer;
        public void SpawnThreetiles(Vector2f pos, Vector2f previouspos)
        {
            float x = pos.X;
            float y = pos.Y;
            float previousx = previouspos.X;
            float previousy = previouspos.Y;
            if (previousx+32==x) 
            {
                if (previousy+16==y)//south direction
                {//spawn south,east,west
                    Tile south = new Tile(new Vector2f(x+32,y+16));
                    Tile east = new Tile(new Vector2f(x+32, y-16));
                    Tile west = new Tile(new Vector2f(x-32, y-16));
                }
                else //east direction
                { //spawn south,north,west
                    Tile south = new Tile(new Vector2f(x+32, y+16));
                    Tile north = new Tile(new Vector2f(x-32, y+16));
                    Tile west = new Tile(new Vector2f(x-32, y-16));
                }
            }
            if (previousx-32==x) 
            {
                if (previousy+16==y)//north direction
                {//spawn south,east,west
                    Tile south = new Tile(new Vector2f(x+32, y+16));
                    Tile east = new Tile(new Vector2f(x+32, y-16));
                    Tile west = new Tile(new Vector2f(x-32, y-16));
                }
                else//west direction
                {//spawn south,east,north
                    Tile south = new Tile(new Vector2f(x+32, y+16));
                    Tile east = new Tile(new Vector2f(x+32, y-16));
                    Tile north = new Tile(new Vector2f(x-32, y+16));
                }
            }
        }
        public void SpawnThreetilesNorth(Vector2f pos)
        {
            Tile south = new Tile(new Vector2f(pos.X+32, pos.Y+16));
            Tile east = new Tile(new Vector2f(pos.X+32, pos.Y-16));
            Tile west = new Tile(new Vector2f(pos.X-32, pos.Y+16));
            Game.CurrentScene.AddGameObject(1,south);
            Game.CurrentScene.AddGameObject(1,east);
            Game.CurrentScene.AddGameObject(1,west);
            
        }
        public void SpawnThreetilesWest(Vector2f pos)
        {
            Tile south = new Tile(new Vector2f(pos.X+32, pos.Y+16));
            Tile east = new Tile(new Vector2f(pos.X+32, pos.Y-16));
            Tile north = new Tile(new Vector2f(pos.X-32, pos.Y-16));
            Game.CurrentScene.AddGameObject(1,south);
            Game.CurrentScene.AddGameObject(1,east);
            Game.CurrentScene.AddGameObject(1,north);
            

        }
        public void SpawnThreetilesSouth(Vector2f pos)
        {
            Tile north = new Tile(new Vector2f(pos.X-32, pos.Y-16));
            Tile east = new Tile(new Vector2f(pos.X+32, pos.Y-16));
            Tile west = new Tile(new Vector2f(pos.X-32, pos.Y+16));
            Game.CurrentScene.AddGameObject(1,north);
            Game.CurrentScene.AddGameObject(1,east);
            Game.CurrentScene.AddGameObject(1,west);
            
        }
        public void SpawnThreetilesEast(Vector2f pos)
        {
            Tile south = new Tile(new Vector2f(pos.X+32, pos.Y+16));
            Tile north = new Tile(new Vector2f(pos.X-32, pos.Y-16));
            Tile west = new Tile(new Vector2f(pos.X-32, pos.Y+16));
            Game.CurrentScene.AddGameObject(1,south);
            Game.CurrentScene.AddGameObject(1,north);
            Game.CurrentScene.AddGameObject(1,west);
            

        }
        public override void Update(Time elapsed)
        {
            
        }
    }
}
