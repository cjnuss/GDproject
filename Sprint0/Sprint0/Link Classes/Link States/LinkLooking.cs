using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0;
using System.Runtime.CompilerServices;

namespace Sprint0
{
    public class LinkLooking : ILinkSprite
    {
        public int direction;
        private Texture2D texture;

        private static Rectangle LinkLookingDown = LinkTextureStorage.LinkLookingDown;
        private static Rectangle LinkLookingLeft = LinkTextureStorage.LinkLookingLeft;
        private static Rectangle LinkLookingRight = LinkTextureStorage.LinkLookingRight;
        private static Rectangle LinkLookingUp = LinkTextureStorage.LinkLookingUp;

        private static List<Rectangle> frames = new List<Rectangle>
        {
            LinkLookingDown,
            LinkLookingLeft,
            LinkLookingRight,
            LinkLookingUp
        };

        private static Texture2D _texture = LinkTextureStorage.Instance.GetLinkTextures();

        public LinkLooking()
        {
            direction = GameConstants.Down;
        }

        // nothing to do here
        public void Update() { }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            texture = _texture;
            Rectangle source = frames[direction];
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, source.Width*GameConstants.Sizing, 
                source.Height*GameConstants.Sizing);
            spriteBatch.Draw(texture, dest, source, Color.White);
        }
    }
}
