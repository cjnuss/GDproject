using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Collision.Response.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Collision.Detection.Items
{
    public class CompassCollisionCheck
    {
        public KeyBoardController KeyBoardController;
        public LinkCompassCollision linkCompassCollision;
        public Game1 game1;
        public Link link;

        public CompassCollisionCheck(KeyBoardController KeyBoardController, LinkCompassCollision linkCompassCollision, Game1 game1, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            this.game1 = game1;
            this.linkCompassCollision = new LinkCompassCollision(this.game1, this.KeyBoardController, this.link);
        }

        public void CheckCollision()
        {
            Compass compass;
            foreach (ISprite item in game1.currentRoom.GetItems())
            {
                if (item.GetType() == typeof(Compass))
                {
                    compass = (Compass)item;
                    if (compass.location.X - KeyBoardController.linkSprite.location.X >= GameConstants.Zero && compass.location.X - KeyBoardController.linkSprite.location.X <=
                        LinkConstants.Size * GameConstants.Sizing || KeyBoardController.linkSprite.location.X - compass.location.X >= 0 && KeyBoardController.linkSprite.location.X - compass.location.X <= ItemConstants.CompassWidth * GameConstants.Sizing)
                    {
                        linkCompassCollision.Update(compass);
                    }
                }
            }
        }
    }
}
