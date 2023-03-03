using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0;
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

        private SpriteBatch _spriteBatch;
        private int levelState;
        public MouseController(Game1 game1, Texture2D atlas, SpriteBatch spriteBatch)
        {
            this.game1 = game1;

            _spriteBatch = spriteBatch;
            levelState = 0;

        }
        public void Update()
        {

            if(Mouse.GetState().RightButton.Equals(ButtonState.Pressed))
            {
                //next level
                if (levelState < 17) levelState++;
            }
            else if (Mouse.GetState().LeftButton.Equals(ButtonState.Pressed))
            {
                //prev level
                if(levelState > 0) levelState--;

            }


            sprite.Update();
            sprite.Draw(_spriteBatch, new Vector2(390, 210));
        }
    }

}
