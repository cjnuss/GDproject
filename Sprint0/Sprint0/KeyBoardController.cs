using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    public class KeyBoardController : IController
    {
        //implement
        private Game1 game1;
        ISprite sprite;
        public Texture2D Texture { get; set; }
        private NonmovingAnimated animatedSprite;
        private NonmovingNonanimated nonanimatedSprite;
        private MovingnonAnimatedVert vertSprite;
        private MovingAnimatedHoriz horizSprite;
        private SpriteBatch _spriteBatch;
        private int gameState;

        public KeyBoardController(Game1 game1, Texture2D atlas, SpriteBatch spriteBatch)
        {
            this.game1 = game1;
            animatedSprite = new NonmovingAnimated(atlas);
            nonanimatedSprite = new NonmovingNonanimated(atlas);
            vertSprite = new MovingnonAnimatedVert(atlas);
            horizSprite = new MovingAnimatedHoriz(atlas);
            _spriteBatch = spriteBatch;
            gameState = 1;
        }
        public void Update()
        {
            //set game state so that once a key is pressed it will hold a state
            if (Keyboard.GetState().IsKeyDown(Keys.D0) || Keyboard.GetState().IsKeyDown(Keys.NumPad0))
            {
                //exit
                game1.Exit();
            }else if(Keyboard.GetState().IsKeyDown(Keys.D1) || Keyboard.GetState().IsKeyDown(Keys.NumPad1))
            {
                //Have a key (1) that has the program display a sprite with only one frame of animation and a fixed position.
                gameState = 1;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D2) || Keyboard.GetState().IsKeyDown(Keys.NumPad2))
            {
                //that has the program display an animated sprite, but with a fixed position.
                gameState = 2;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D3) || Keyboard.GetState().IsKeyDown(Keys.NumPad3))
            {
                // a sprite with only one frame of animation, but moves the sprite up and down on screen.
                gameState = 3;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.D4) || Keyboard.GetState().IsKeyDown(Keys.NumPad4))
            {
                // a sprite with only one frame of animation, but moves the sprite up and down on screen.
                gameState = 4;
            }

            //now set the sprite using the game state
            if(gameState == 1)
            {
                sprite = nonanimatedSprite;
            }else if(gameState == 2)
            {
                sprite = animatedSprite;
            }else if(gameState == 3)
            {
                sprite = vertSprite;
            }else if (gameState == 4)
            {
                sprite = horizSprite;
            }

            sprite.Update();
            sprite.Draw(_spriteBatch, new Vector2(390, 210));
        }

    }
}
