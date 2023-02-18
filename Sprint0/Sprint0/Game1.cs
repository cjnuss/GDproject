using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Sprint0
{
    // finally working comment
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        //private SpriteFont font;
        private bool key;

        private KeyBoardController Kcontroller;
        //private MouseController Mcontroller;
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
            Texture2D atlas = Content.Load<Texture2D>("mysprite");
            Texture2D blocks = Content.Load<Texture2D>("blockSet");
            Texture2D items = Content.Load<Texture2D>("items&weaponsSet");

            // keyboard controller
            Kcontroller = new KeyBoardController(this, atlas, blocks, items, _spriteBatch);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightSlateGray);

            _spriteBatch.Begin();

            // unless Q is pressed, keep updating
            if(!Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                key = true;
            }
            else if(Mouse.GetState().LeftButton.Equals(ButtonState.Pressed) || Mouse.GetState().RightButton.Equals(ButtonState.Pressed))
            {
                key = false;
            }
            if (key)
            {
                Kcontroller.Update();
            }
            //NEED THIS FOR LATER HOME SCREEN
            //else if (!key)
            //{
            //    Mcontroller.Update();
            //}

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}