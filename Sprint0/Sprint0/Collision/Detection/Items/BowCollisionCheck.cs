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
    public class BowCollisionCheck
    {
        public KeyBoardController KeyBoardController;
        public LinkBowCollision linkBowCollision;
        public Game1 game1;
        public Link link;

        public BowCollisionCheck(KeyBoardController KeyBoardController, LinkBowCollision linkArrowCollision, Game1 game1, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            this.game1 = game1;
            linkBowCollision = new LinkBowCollision(this.game1, this.KeyBoardController, this.link);
        }

        public void CheckCollision()
        {
            Bow bow;
            foreach (ISprite item in game1.currentRoom.GetItems())
            {
                if (item.GetType() == typeof(Bow))
                {
                    bow = (Bow)item;
                    if (bow.location.X - KeyBoardController.linkSprite.location.X >= GameConstants.Zero && bow.location.X - KeyBoardController.linkSprite.location.X <=
                        LinkConstants.Size * GameConstants.Sizing || KeyBoardController.linkSprite.location.X - bow.location.X >= 0 && KeyBoardController.linkSprite.location.X - bow.location.X <= ItemConstants.BowWidth * GameConstants.Sizing)
                    {
                        linkBowCollision.Update(bow);
                    }
                }
            }
        }
    }
}
