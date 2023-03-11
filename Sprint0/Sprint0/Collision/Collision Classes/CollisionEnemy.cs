using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    internal class CollisionEnemy : IEnemy
    {
        public Vector2 location;
        public int width;
        public int height;

        public CollisionEnemy(Vector2 location, int width, int height)
        {
            this.location = location;
            this.width = width;
            this.height = height;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        }

        public void Update(int blockState)
        {
        }
    }
}
