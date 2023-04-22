using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Link_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class SkeletonSwordCollisionCheck
    {
        private KeyBoardController KeyBoardController;
        private SkeletonSwordCollision skeletonSwordCollision;
        private Game1 game;
        private Link link;
        private Skeleton skeleton;

        public SkeletonSwordCollisionCheck(KeyBoardController KeyBoardController, SkeletonSwordCollision skeletonSwordCollision, Game1 game, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.game = game;
            this.link = link;
            this.skeletonSwordCollision = new SkeletonSwordCollision(this.game, this.KeyBoardController, this.link);
        }

        public void CheckCollision()
        {
            foreach (IEnemy enemy in game.currentRoom.GetEnemies())
            {
                if (enemy.GetType() == typeof(Skeleton))
                {
                    skeleton = (Skeleton)enemy;
                    if (skeleton.location.X - KeyBoardController.linkSprite.location.X >= GameConstants.Zero && skeleton.location.X - KeyBoardController.linkSprite.location.X <=
                        LinkConstants.Size * GameConstants.Sizing || KeyBoardController.linkSprite.location.X - skeleton.location.X >= 0 && KeyBoardController.linkSprite.location.X - skeleton.location.X <= LinkConstants.Size * GameConstants.Sizing)
                    {
                        skeletonSwordCollision.Update(skeleton);
                    }
                }
            }
        }
    }
}
