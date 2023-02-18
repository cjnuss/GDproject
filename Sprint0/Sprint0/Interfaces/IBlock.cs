using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public interface IBlock
    {
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
