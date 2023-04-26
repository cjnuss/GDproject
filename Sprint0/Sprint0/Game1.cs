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
        //private SpriteFont font;

        public BackgroundAudio backgroundAudio;
        public SoundEffects soundEffects;
        public SoundManager soundManager;

        private KeyBoardController Kcontroller;
        private MouseController Mcontroller;

        private CollisionManager collisionManager;
        private Link linkSprite;

        private StaticText testingText;
        private HpHearts testingHearts;
        private MainHUD mainHUD;
        private PlayerMap playerMap;
        public LinkItems linkItems;
        public LinkHP linkHealth;
        private Counts HUDnumbers;

        private WinningState WinningState;
        private LosingState LosingState;

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
            EnemyTextureStorage.Instance.Load(Content);
            LinkTextureStorage.Instance.Load(Content);
            ItemsTextureStorage.Instance.Load(Content);
            UITextureStorage.Instance.Load(Content);

            // audio setup
            backgroundAudio = new BackgroundAudio();
            backgroundAudio.LoadSound(this);
            soundEffects = new SoundEffects();
            soundManager = new SoundManager(this);
            soundManager.LoadAllSounds();

            // controller setup
            linkSprite = new Link(this);
            Kcontroller = new KeyBoardController(this, _spriteBatch, linkSprite);
            Mcontroller = new MouseController(this, level, _spriteBatch);

            // collision setup
            collisionManager = new CollisionManager(Kcontroller, this, linkSprite);
            collisionManager.Create();

            // hud setup
            testingText = new StaticText(this);
            testingHearts = new HpHearts(this);
            mainHUD = new MainHUD(this);
            playerMap = new PlayerMap(this);
            
            HUDnumbers = new Counts(this, linkItems);

            WinningState = new WinningState(this, _spriteBatch);
            LosingState = new LosingState(this, _spriteBatch);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            Mcontroller.Update(gameTime);
            if (!linkItems.triforce && linkHealth.health > GameConstants.Zero)
            {
                collisionManager.Check();
                Kcontroller.Update(gameTime);
            }
            else if (linkHealth.health == GameConstants.Zero)
            {
                LosingState.Update(Kcontroller);
            }
            else
            {
                WinningState.Update(this, Kcontroller);
            }

            testingText.Draw(_spriteBatch);
            mainHUD.Draw(_spriteBatch);
            testingHearts.Update();
            testingHearts.Draw(_spriteBatch);
            playerMap.Draw(_spriteBatch);

            HUDnumbers.Update();
            HUDnumbers.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}