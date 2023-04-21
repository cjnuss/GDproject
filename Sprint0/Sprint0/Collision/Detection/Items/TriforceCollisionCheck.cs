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
    public class TriforceCollisionCheck
    {
        public KeyBoardController KeyBoardController;
        public LinkTriforceCollision linkTriforceCollision;
        public Game1 game1;
        public Link link;

        public TriforceCollisionCheck(KeyBoardController KeyBoardController, LinkTriforceCollision linkTriforceCollision, Game1 game1, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            this.game1 = game1;
            this.linkTriforceCollision = new LinkTriforceCollision(this.game1, this.KeyBoardController, this.link);
        }

        public void CheckCollision()
        {
            Triforce triforce;
            foreach (ISprite item in game1.currentRoom.GetItems())
            {
                if (item.GetType() == typeof(Triforce))
                {
                    triforce = (Triforce)item;
                    if (triforce.location.X - KeyBoardController.linkSprite.location.X >= GameConstants.Zero && triforce.location.X - KeyBoardController.linkSprite.location.X <=
                        LinkConstants.Size * GameConstants.Sizing || KeyBoardController.linkSprite.location.X - triforce.location.X >= 0 && KeyBoardController.linkSprite.location.X - triforce.location.X <= ItemConstants.TriforceWidth * GameConstants.Sizing)
                    {
                        linkTriforceCollision.Update(triforce);
                    }
                }
            }
        }
    }
}
