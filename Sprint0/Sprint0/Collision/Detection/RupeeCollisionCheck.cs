using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class RupeeCollisionCheck
    {
        public KeyBoardController KeyBoardController;
        public LinkRupeeCollision linkRupeeCollision;
        public Game1 game1;
        public Link link;

        public RupeeCollisionCheck(KeyBoardController KeyBoardController, LinkRupeeCollision linkRupeeCollision, Game1 game1, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            this.game1 = game1;
            this.linkRupeeCollision = new LinkRupeeCollision(this.game1, this.KeyBoardController, this.link);
        }

        public void CheckCollision()
        {
            Rupee rupee;
            foreach (ISprite item in game1.currentRoom.GetItems())
            {
                if (item.GetType() == typeof(Rupee))
                {
                    rupee = (Rupee)item;
                    if ((rupee.location.X - KeyBoardController.linkSprite.location.X >= GameConstants.Zero && rupee.location.X - KeyBoardController.linkSprite.location.X <=
                        LinkConstants.Size * GameConstants.Sizing) || (KeyBoardController.linkSprite.location.X - rupee.location.X >= 0 && KeyBoardController.linkSprite.location.X - rupee.location.X <= ItemConstants.ArrowWidth * GameConstants.Sizing))
                    {
                        linkRupeeCollision.Update(rupee);
                    }
                }
            }
        }
    }
}
