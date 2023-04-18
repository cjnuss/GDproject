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
    public class MapCollisionCheck
    {
        public KeyBoardController KeyBoardController;
        public LinkMapCollision linkMapCollision;
        public Game1 game1;
        public Link link;

        public MapCollisionCheck(KeyBoardController KeyBoardController, LinkMapCollision linkMapCollision, Game1 game1, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            this.game1 = game1;
            this.linkMapCollision = new LinkMapCollision(this.game1, this.KeyBoardController, this.link);
        }

        public void CheckCollision()
        {
            Map map;
            foreach (ISprite item in game1.currentRoom.GetItems())
            {
                if (item.GetType() == typeof(Map))
                {
                    map = (Map)item;
                    if (map.location.X - KeyBoardController.linkSprite.location.X >= GameConstants.Zero && map.location.X - KeyBoardController.linkSprite.location.X <=
                        LinkConstants.Size * GameConstants.Sizing || KeyBoardController.linkSprite.location.X - map.location.X >= 0 && KeyBoardController.linkSprite.location.X - map.location.X <= ItemConstants.MapWidth * GameConstants.Sizing)
                    {
                        linkMapCollision.Update(map);
                    }
                }
            }
        }
    }
}
