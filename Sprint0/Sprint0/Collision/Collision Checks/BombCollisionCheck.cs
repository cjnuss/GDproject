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
    public class BombCollisionCheck
    {
        public KeyBoardController KeyBoardController;
        public LinkBombCollision linkBombCollision;
        public Game1 game1;
        public Link link;

        public BombCollisionCheck(KeyBoardController KeyBoardController, LinkBombCollision linkBombCollision, Game1 game1, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            this.game1 = game1;
            this.linkBombCollision = new LinkBombCollision(this.game1, this.KeyBoardController, this.link);
        }

        public void CheckCollision()
        {
            BombItem bomb;
            foreach (ISprite item in game1.currentRoom.GetItems())
            {
                if (item.GetType() == typeof(BombItem))
                {
                    bomb = (BombItem)item;
                    if ((bomb.location.X - KeyBoardController.linkSprite.location.X >= GameConstants.Zero && bomb.location.X - KeyBoardController.linkSprite.location.X <=
                        LinkConstants.Size * GameConstants.Sizing) || (KeyBoardController.linkSprite.location.X - bomb.location.X >= 0 && KeyBoardController.linkSprite.location.X - bomb.location.X <= ItemConstants.ArrowWidth * GameConstants.Sizing))
                    {
                        linkBombCollision.Update(bomb);
                    }
                }
            }
        }
    }
}
