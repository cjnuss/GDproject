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
    public class HeartCollisionCheck
    {
        public KeyBoardController KeyBoardController;
        public LinkHeartCollision linkHeartCollision;
        public Game1 game1;
        public Link link;

        public HeartCollisionCheck(KeyBoardController KeyBoardController, LinkHeartCollision linkHeartCollision, Game1 game1, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            this.game1 = game1;
            this.linkHeartCollision = new LinkHeartCollision(this.game1, this.KeyBoardController, this.link);
        }

        public void CheckCollision()
        {
            Heart heart;
            foreach (ISprite item in game1.currentRoom.GetItems())
            {
                if (item.GetType() == typeof(Heart))
                {
                    heart = (Heart)item;
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
