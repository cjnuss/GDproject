using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class MouseController : IController
    {
        private Game1 game1;
        ISprite sprite;
        //get sprites and needed classes ready
        public Texture2D Texture { get; set; }
        private NonmovingAnimated animatedSprite;
        private NonmovingNonanimated nonanimatedSprite;
        private MovingnonAnimatedVert vertSprite;
        private MovingAnimatedHoriz horizSprite;
        private SpriteBatch _spriteBatch;
        private int gameState;
        public MouseController(Game1 game1, Texture2D atlas, SpriteBatch spriteBatch)
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
            if(Mouse.GetState().RightButton.Equals(ButtonState.Pressed))
            {
                game1.Exit();
            }
            else if (Mouse.GetState().X < 400 && Mouse.GetState().Y < 225 && Mouse.GetState().LeftButton.Equals(ButtonState.Pressed))
            {
                //upper left quad
                //should display a sprite with only one frame of animation and a fixed position
                gameState = 1;
            }
            else if (Mouse.GetState().X >= 400 && Mouse.GetState().Y < 225 && Mouse.GetState().LeftButton.Equals(ButtonState.Pressed))
            {
                //upper right quad
                //should display an animated sprite, but with a fixed position
                gameState = 2;
            }
            else if (Mouse.GetState().X < 400 && Mouse.GetState().Y >= 225 && Mouse.GetState().LeftButton.Equals(ButtonState.Pressed))
            {
                //lower left quad
                //should display a sprite with only one frame of animation, but moves the sprite up and down on screen
                gameState = 3;
            }
            else if (Mouse.GetState().X >= 400 && Mouse.GetState().Y >= 225 && Mouse.GetState().LeftButton.Equals(ButtonState.Pressed))
            {
                //lower right quad
                //should display an animated sprite, moving to the left and right on screen
                gameState = 4;
            }
            //now set the sprite using the game state
            if (gameState == 1)
            {
                sprite = nonanimatedSprite;
            }
            else if (gameState == 2)
            {
                sprite = animatedSprite;
            }
            else if (gameState == 3)
            {
                sprite = vertSprite;
            }
            else if (gameState == 4)
            {
                sprite = horizSprite;
            }
            sprite.Update();
            sprite.Draw(_spriteBatch, new Vector2(390, 210));
        }
    }

}
