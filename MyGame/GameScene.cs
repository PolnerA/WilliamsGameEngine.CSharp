﻿using GameEngine;
using SFML.System;
using SFML.Audio;
namespace MyGame
{
    class GameScene : Scene
    {
        private int _lives = 3;
        private int _score;
        private Sound _boom = new Sound();
        public GameScene()
        {


            Ship ship = new Ship();
            AddGameObject(ship);
            MeteorSpawner meteorSpawner = new MeteorSpawner();
            AddGameObject(meteorSpawner);
            Score score = new Score(new Vector2f(10.0f, 10.0f));
            AddGameObject(score);
            _boom.SoundBuffer = Game.GetSoundBuffer("Resources/boom.wav");
        }
        // Get the current score
        public int GetScore()
        {
            return _score;
        }
        //play the sound
        public void PlayExplosion()
        {
            _boom.Play();
        }
        // Increase the score
        public void IncreaseScore()
        {
            ++_score;
        }
        // Get the number of lives
        public int GetLives()
        {
            return _lives;
        }
        // Decrease the number of lives
        public void DecreaseLives()
        {
            --_lives;
            if (_lives == 0)
            {
                GameOverScene gameOverScene = new GameOverScene(_score);
                Game.SetScene(gameOverScene);
            }
        }
    }
}
