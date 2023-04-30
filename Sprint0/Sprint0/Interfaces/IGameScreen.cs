using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public interface IGameScreen
    {
        void Draw(SpriteBatch spriteBatch, GameTime gameTime);
        void Update();
    }
}
