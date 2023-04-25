using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Collision.Response.Blocks;
using Sprint0.Collision.Response.Items;
using Sprint0.Collision.Response.Walls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class LinkObsticleCollisionCheck
    {
        public KeyBoardController KeyBoardController;
        public LinkBlockCollision linkBlockCollision;
        private LinkWallCollision linkWallCollision;
        public Game1 game1;
        public Link link;
        public int roomType;

        public LinkObsticleCollisionCheck(KeyBoardController KeyBoardController, Game1 game1, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            this.game1 = game1;
            linkBlockCollision = new LinkBlockCollision(this.KeyBoardController, this.link);
            linkWallCollision = new LinkWallCollision(this.KeyBoardController, this.link);
            linkWallCollision.roomType = GameConstants.Zero;
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
            
            linkWallCollision.Update();
        }
    }
}
