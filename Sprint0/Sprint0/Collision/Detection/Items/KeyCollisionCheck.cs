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
    public class KeyCollisionCheck
    {
        public KeyBoardController KeyBoardController;
        public LinkKeyCollision linkKeyCollision;
        public Game1 game1;
        public Link link;

        public KeyCollisionCheck(KeyBoardController KeyBoardController, LinkKeyCollision linkKeyCollision, Game1 game1, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            this.game1 = game1;
            this.linkKeyCollision = new LinkKeyCollision(this.game1, this.KeyBoardController, this.link);
        }

        public void CheckCollision()
        {
            Key key;
            foreach (ISprite item in game1.currentRoom.GetItems())
            {
                if (item.GetType() == typeof(Key))
                {
                    key = (Key)item;
                    if (key.location.X - KeyBoardController.linkSprite.location.X >= GameConstants.Zero && key.location.X - KeyBoardController.linkSprite.location.X <=
                        LinkConstants.Size * GameConstants.Sizing || KeyBoardController.linkSprite.location.X - key.location.X >= 0 && KeyBoardController.linkSprite.location.X - key.location.X <= ItemConstants.ArrowWidth * GameConstants.Sizing)
                    {
                        linkKeyCollision.Update(key);
                    }
                }
            }
        }
    }
}
