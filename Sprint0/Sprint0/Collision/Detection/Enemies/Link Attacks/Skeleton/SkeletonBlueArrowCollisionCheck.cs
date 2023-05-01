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
    public class SkeletonBlueArrowCollisionCheck
    {
        private KeyBoardController KeyBoardController;
        private SkeletonBlueArrowCollision skeletonBlueArrowCollision;
        private Game1 game;
        private Skeleton skeleton;

        public SkeletonBlueArrowCollisionCheck(KeyBoardController KeyBoardController, SkeletonBlueArrowCollision skeletonBlueArrowCollision, Game1 game)
        {
            this.KeyBoardController = KeyBoardController;
            this.game = game;
            this.skeletonBlueArrowCollision = new SkeletonBlueArrowCollision(this.game, this.KeyBoardController);
        }

        public ISprite CheckCollision()
        {
            foreach (IEnemy enemy in game.currentRoom.GetEnemies())
            {
                if (enemy.GetType() == typeof(Skeleton))
                {
                    skeleton = (Skeleton)enemy;
                    if (skeleton.location.X - KeyBoardController.linkSprite.attack.blueArrow.currentX >= GameConstants.Zero && skeleton.location.X - KeyBoardController.linkSprite.attack.blueArrow.currentX <=
                        ItemConstants.ArrowWidth * GameConstants.Sizing || KeyBoardController.linkSprite.attack.blueArrow.currentX - skeleton.location.X >= 0 && KeyBoardController.linkSprite.attack.blueArrow.currentX - skeleton.location.X <= ItemConstants.ArrowWidth * GameConstants.Sizing)
                    {
                        return skeletonBlueArrowCollision.Update(skeleton);
                    }
                }
            }

            return null;
        }
    }
}
