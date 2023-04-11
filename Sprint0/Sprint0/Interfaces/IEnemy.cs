using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public interface IEnemy
    {
        void Draw(SpriteBatch spriteBatch);
        void SetLocation(Vector2 location);
        Vector2 GetLocation();
        Vector2 GetSize();
        void Update();
    }
}
