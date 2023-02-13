﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

//testing pt.732421
// testing pt. 160000301205
namespace Sprint0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont font;
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

            // TODO: use this.Content to load your game content
            font = Content.Load<SpriteFont>("Desc");
            Texture2D atlas = Content.Load<Texture2D>("mysprite");

            //set up controllers
            Kcontroller = new KeyBoardController(this, atlas, _spriteBatch);
            Mcontroller = new MouseController(this, atlas, _spriteBatch);

        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.DrawString(font, "Credits:\nProgram Made By: Chris Rockich\nSprites from: http://www.mariouniverse.com/sprites/", new Vector2(150, 300), Color.White);

            //logic to see if key is pressed
            if(Keyboard.GetState().IsKeyDown(Keys.D0) || Keyboard.GetState().IsKeyDown(Keys.NumPad0) ||
               Keyboard.GetState().IsKeyDown(Keys.D1) || Keyboard.GetState().IsKeyDown(Keys.NumPad1) ||
               Keyboard.GetState().IsKeyDown(Keys.D2) || Keyboard.GetState().IsKeyDown(Keys.NumPad2) ||
               Keyboard.GetState().IsKeyDown(Keys.D3) || Keyboard.GetState().IsKeyDown(Keys.NumPad3) ||
               Keyboard.GetState().IsKeyDown(Keys.D4) || Keyboard.GetState().IsKeyDown(Keys.NumPad4))
            {
                key = true;
            }else if(Mouse.GetState().LeftButton.Equals(ButtonState.Pressed) || Mouse.GetState().RightButton.Equals(ButtonState.Pressed))
            {
                key = false;
            }
            if (key)
            {
                Kcontroller.Update();
            }else if (!key)
            {
                Mcontroller.Update();
            }

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}