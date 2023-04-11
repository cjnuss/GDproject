using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Levels;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        //private SpriteFont font;

        public BackgroundAudio backgroundAudio;
        public SoundEffects soundEffects;

        private KeyBoardController Kcontroller;
        private MouseController Mcontroller;

        private CollisionManager collisionManager;
        private Link linkSprite;

        public IRoom currentRoom;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
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
            // sprite factory
            //BlockSpriteFactory.Instance.LoadBlockTextures(Content);

            // load in objects
            Texture2D level = Content.Load<Texture2D>("level1");
            EnemyTextureStorage.Instance.Load(Content);
            LinkTextureStorage.Instance.Load(Content);
            ItemsTextureStorage.Instance.Load(Content);
            UITextureStorage.Instance.Load(Content);

            // music / sounds
            backgroundAudio = new BackgroundAudio();
            backgroundAudio.LoadSound(this);
            soundEffects = new SoundEffects();

            // controller setup
            linkSprite = new Link(this);
            Kcontroller = new KeyBoardController(this, _spriteBatch, linkSprite);
            Mcontroller = new MouseController(this, level, _spriteBatch);

            // collision setup
            collisionManager = new CollisionManager(Kcontroller, this, linkSprite);
            collisionManager.Create();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            // Texture2D level = Content.Load<Texture2D>("level1");
            // _spriteBatch.Draw(level, new Rectangle(0, 0, 1200, 600), Color.LightSlateGray); 

            Mcontroller.Update(gameTime);
            collisionManager.Check();
            Kcontroller.Update(gameTime);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}