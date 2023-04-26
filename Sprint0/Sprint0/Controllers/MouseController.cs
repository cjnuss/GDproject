using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Vector2 = System.Numerics.Vector2;

namespace Sprint0.Levels
{
    public class MouseController : IController
    {
        private Game1 game1;
        private SpriteBatch _spriteBatch;

        public MouseController(Game1 game1, SpriteBatch spriteBatch)
        {
            this.game1 = game1;
            _spriteBatch = spriteBatch;
        }

        public void Update(GameTime gameTime)
        {
        }
    }

}
