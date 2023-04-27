using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace Sprint0
{
    public class Door
    {
        public Vector2 location;
        public int width;
        public int height;
        public int type;

        public Door(Vector2 location, int type)
        {
            this.location = location;
            this.type = type;
            width = 10;
            height = 10;

            if (type == 0)
            {
                if (location.X < 75)
                {
                    width = 36;
                }
                else if (location.Y < 215)
                {
                    height = 31;
                }
                else if (location.X > 650)
                {
                    location.X = 699;
                }
                else if (location.Y > 500)
                {
                    location.Y = 541;
                }
            }
        }

        public int GetType()
        {
            return type;
        }
    }
}
