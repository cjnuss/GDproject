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
            direction = 0; // initialized as looking down
            // DEBUG: LOCATION?? magic numbers
        }

        // nothing to do here
        public void Update()
        {
            // DEBUG: might just be within keyboard controller
            // update lookingState based on key press
            // velocity must be 0 to update this
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            texture = _texture;
            Rectangle source = frames[direction];
            Rectangle dest = new Rectangle((int)location.X, (int)location.Y, source.Width*3, source.Height*3); // DEBUG *3?
            spriteBatch.Draw(texture, dest, source, Color.White);
        }
    }
}
