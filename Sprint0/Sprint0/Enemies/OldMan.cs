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
    public class OldMan : IEnemy
    {
        private int width;
        private int height;

        public Vector2 GetSize()
        {
            return new Vector2(width, height);
        }

        public void SetLocation(Vector2 location)
        {
            this.location = location;
        }

        public Vector2 location;
        public Vector2 GetLocation()
        {
            return location;
        }
        private Texture2D texture;

        public OldMan(Vector2 coords)
        {
            location = coords;
            width = 20;
            height = 20;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            texture = EnemyTextureStorage.Instance.GetNPC();
            Rectangle source = EnemyTextureStorage.OldManSource;
            Rectangle destinaton = new Rectangle((int)location.X, (int)location.Y, source.Width * EnemyConstants.Sizing, source.Height * EnemyConstants.Sizing);
            spriteBatch.Draw(texture, destinaton, source, Color.White);
        }
    }
}
