using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public interface ILink
    {
        void Draw(SpriteBatch spriteBatch);
        void Update(int linkState, int dir, Vector2 location);

        //int UpdateSprite(int linkState);
        //void UpdateDirection(int dir);
    }
}
