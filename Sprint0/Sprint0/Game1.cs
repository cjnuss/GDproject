using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Levels;
using Sprint0.UI;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Sprint0
{
    public class Game1 : Game
    {
        // DEBUG
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public BackgroundAudio backgroundAudio;
        public SoundEffects soundEffects;
        public SoundManager soundManager;

        public LinkItems linkItems;
        public LinkHP linkHealth;

        GameManager gameManager;

        public IRoom currentRoom;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            linkItems = new LinkItems();
            linkHealth = new LinkHP(this);
        }

        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //480 x 800 - added 150 to height
            _graphics.PreferredBackBufferHeight = GameConstants.BufferHeight;
            _graphics.PreferredBackBufferWidth = GameConstants.BufferWidth;
            _graphics.ApplyChanges();

            // sprite setup
            Texture2D level = Content.Load<Texture2D>("level1");
            LevelsTextureStorage.Instance.Load(Content);
            EnemyTextureStorage.Instance.Load(Content);
            LinkTextureStorage.Instance.Load(Content);
            ItemsTextureStorage.Instance.Load(Content);
            UITextureStorage.Instance.Load(Content);
            InventoryTextureStorage.Instance.Load(Content);

            // audio setup
            backgroundAudio = new BackgroundAudio();
            backgroundAudio.LoadSound(this);
            soundEffects = new SoundEffects();
            soundManager = new SoundManager(this);
            soundManager.LoadAllSounds();

            gameManager = new GameManager(this, _spriteBatch);
        }

        protected override void Update(GameTime gameTime)
        {
            gameManager.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            gameManager.Draw(_spriteBatch, gameTime);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}