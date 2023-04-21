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
    public class ArrowCollisionCheck
    {
        private KeyBoardController KeyBoardController;
        private LinkArrowCollision linkArrowCollision;
        private Game1 game1;
        private Link link;

        public ArrowCollisionCheck(KeyBoardController KeyBoardController, LinkArrowCollision linkArrowCollision, Game1 game1, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            this.game1 = game1;
            this.linkArrowCollision = new LinkArrowCollision(this.game1, this.KeyBoardController, this.link);
        }

        public void CheckCollision()
        {
            Arrow arrow;
            foreach (ISprite item in game1.currentRoom.GetItems())
            {
                if (item.GetType() == typeof(Arrow))
                {
                    arrow = (Arrow)item;
                    if (arrow.location.X - KeyBoardController.linkSprite.location.X >= GameConstants.Zero && arrow.location.X - KeyBoardController.linkSprite.location.X <=
                        LinkConstants.Size * GameConstants.Sizing || KeyBoardController.linkSprite.location.X - arrow.location.X >= 0 && KeyBoardController.linkSprite.location.X - arrow.location.X <= ItemConstants.ArrowWidth * GameConstants.Sizing)
                    {
                        linkArrowCollision.Update(arrow);
                    }
                }
            }
        }
    }
}
