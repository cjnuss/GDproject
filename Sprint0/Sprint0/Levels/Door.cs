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
            
            if (location.X < 75)
            {
                width = 10;
            }
            else if (location.Y < 215)
            {
                
            }
            else if (location.X > 715)
            {
                
            }
            else if (location.Y > 550)
            {
                
            }
        }

        public int GetType()
        {
            return type;
        }
    }
}
