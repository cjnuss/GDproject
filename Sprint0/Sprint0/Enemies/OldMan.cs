using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0;

namespace Sprint0
{
    public class OldMan : ISprite1
    {
        private Texture2D texture;
        public Vector2 location;

        public OldMan(Vector2 coords)
        {
            location = coords;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            texture = EnemyTextureStorage.Instance.GetNPC();
            Rectangle source = EnemyTextureStorage.OldManSource;
            Rectangle destinaton = new Rectangle((int)location.X, (int)location.Y, source.Width * 2, source.Height * 2);
            spriteBatch.Draw(texture, destinaton, source, Color.White);
        }
    }
}
