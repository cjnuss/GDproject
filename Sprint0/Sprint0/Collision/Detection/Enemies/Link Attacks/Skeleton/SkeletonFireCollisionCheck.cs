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
    public class SkeletonFireCollisionCheck
    {
        private KeyBoardController KeyBoardController;
        private SkeletonFireCollision skeletonFireCollision;
        private Game1 game;
        private Skeleton skeleton;

        public SkeletonFireCollisionCheck(KeyBoardController KeyBoardController, SkeletonFireCollision skeletonFireCollision, Game1 game)
        {
            this.KeyBoardController = KeyBoardController;
            this.game = game;
            this.skeletonFireCollision = new SkeletonFireCollision(this.game, this.KeyBoardController);
        }

        public void CheckCollision()
        {
            foreach (IEnemy enemy in game.currentRoom.GetEnemies())
            {
                if (enemy.GetType() == typeof(Skeleton))
                {
                    skeleton = (Skeleton)enemy;
                    if (skeleton.location.X - KeyBoardController.linkSprite.attack.fire.currentX >= GameConstants.Zero && skeleton.location.X - KeyBoardController.linkSprite.attack.fire.currentX <=
                        ItemConstants.ArrowWidth * GameConstants.Sizing || KeyBoardController.linkSprite.attack.fire.currentX - skeleton.location.X >= 0 && KeyBoardController.linkSprite.attack.fire.currentX - skeleton.location.X <= ItemConstants.ArrowWidth * GameConstants.Sizing)
                    {
                        skeletonFireCollision.Update(skeleton);
                    }
                }
            }
        }
    }
}
