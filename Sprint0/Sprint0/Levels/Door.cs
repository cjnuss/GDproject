using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class Door
    {
        public Vector2 location;
        public int width = 10;
        public int height = 10;
        public int type;

        public Door(Vector2 location, int type)
        {
            this.location = location;
            this.type = type;
        }

        public int GetType()
        {
            return type;
        }
    }
}
