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
    public class HealthHeartCollisionCheck
    {
        public KeyBoardController KeyBoardController;
        public LinkHealthHeartCollision linkHeartCollision;
        public Game1 game1;
        public Link link;

        public HealthHeartCollisionCheck(KeyBoardController KeyBoardController, LinkHealthHeartCollision linkHealthHeartCollision, Game1 game1, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            this.game1 = game1;
            linkHeartCollision = new LinkHealthHeartCollision(this.game1, this.KeyBoardController, this.link);
        }

        public void CheckCollision()
        {
            HealthHeart heart;
            foreach (ISprite item in game1.currentRoom.GetItems())
            {
                if (item.GetType() == typeof(HealthHeart))
                {
                    heart = (HealthHeart)item;
                    if (heart.location.X - KeyBoardController.linkSprite.location.X >= GameConstants.Zero && heart.location.X - KeyBoardController.linkSprite.location.X <=
                        LinkConstants.Size * GameConstants.Sizing || KeyBoardController.linkSprite.location.X - heart.location.X >= 0 && KeyBoardController.linkSprite.location.X - heart.location.X <= ItemConstants.HeartWidth * GameConstants.Sizing)
                    {
                        linkHeartCollision.Update(heart);
                    }
                }
            }
        }
    }
}
