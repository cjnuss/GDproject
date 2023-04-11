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
    public class FairyCollisionCheck
    {
        public KeyBoardController KeyBoardController;
        public LinkFairyCollision linkFairyCollision;
        public Game1 game1;
        public Link link;

        public FairyCollisionCheck(KeyBoardController KeyBoardController, LinkFairyCollision linkFairyCollision, Game1 game1, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            this.game1 = game1;
            this.linkFairyCollision = new LinkFairyCollision(this.game1, this.KeyBoardController, this.link);
        }

        public void CheckCollision()
        {
            Fairy fairy;
            foreach (ISprite item in game1.currentRoom.GetItems())
            {
                if (item.GetType() == typeof(Fairy))
                {
                    fairy = (Fairy)item;
                    if ((fairy.location.X - KeyBoardController.linkSprite.location.X >= GameConstants.Zero && fairy.location.X - KeyBoardController.linkSprite.location.X <=
                        LinkConstants.Size * GameConstants.Sizing) || (KeyBoardController.linkSprite.location.X - fairy.location.X >= 0 && KeyBoardController.linkSprite.location.X - fairy.location.X <= ItemConstants.FairyWidth * GameConstants.Sizing))
                    {
                        linkFairyCollision.Update(fairy);
                    }
                }
            }
        }
    }
}
