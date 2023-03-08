using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class CollisionBlock : IBlock
    {
        public Vector2 location;
        public int width;
        public int height;

        public CollisionBlock(Vector2 location, int width, int height)
        {
            this.location = location;
            this.width = width; 
            this.height = height;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
        }

        public void KeyBlockUpdate(bool check, ref int oldBlockState, ref int blockState)
        {
        }

        public void Update(int blockState)
        {
        }
    }
}
