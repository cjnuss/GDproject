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
    public class BlockCollisionCheck
    {
        public KeyBoardController KeyBoardController;
        public LinkBlockCollision linkBlockCollision;
        public Game1 game1;
        public Link link;

        public BlockCollisionCheck(KeyBoardController KeyBoardController, LinkBlockCollision linkBlockCollision, Game1 game1, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            this.game1 = game1;
            this.linkBlockCollision = new LinkBlockCollision(this.KeyBoardController, this.link);
        }

        public void CheckCollision()
        {
            foreach (CollisionBlock block in game1.currentRoom.GetBlocks())
            {
                if ((block.location.X - KeyBoardController.linkSprite.location.X >= GameConstants.Zero && block.location.X - KeyBoardController.linkSprite.location.X <= 
                    LinkConstants.Size * GameConstants.Sizing) || (KeyBoardController.linkSprite.location.X - block.location.X >= 0 && KeyBoardController.linkSprite.location.X - block.location.X <= block.width))
                {
                    linkBlockCollision.Update(block);
                }

                if (KeyBoardController.linkSprite.velocity == GameConstants.Zero)
                {
                    KeyBoardController.linkSprite.velocity = LinkConstants.Velocity;
                    break;
                }
            }
        }
    }
}
