﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Levels;
using System.Collections.Generic;

namespace Sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        //private SpriteFont font;
        private bool key;

        private KeyBoardController Kcontroller;
        private MouseController Mcontroller;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            //default state is 
            key = true;
    }

    protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // sprite factory
            //BlockSpriteFactory.Instance.LoadBlockTextures(Content);

            // load in objects
            Texture2D level = Content.Load<Texture2D>("level1");
            EnemyTextureStorage.Instance.Load(Content);
            LinkTextureStorage.Instance.Load(Content);

            // controller setup
            Kcontroller = new KeyBoardController(this, _spriteBatch);
            Mcontroller = new MouseController(this, level, _spriteBatch);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightSlateGray);

            _spriteBatch.Begin();

            // Texture2D level = Content.Load<Texture2D>("level1");
            // _spriteBatch.Draw(level, new Rectangle(0, 0, 1200, 600), Color.LightSlateGray); 

            // unless Q is pressed, keep updating
            //!Keyboard.GetState().IsKeyDown(Keys.Q)


            Mcontroller.Update();
            Kcontroller.Update();



            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}