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
    public class SkeletonGreenArrowCollisionCheck
    {
        private KeyBoardController KeyBoardController;
        private SkeletonGreenArrowCollision skeletonGreenArrowCollision;
        private Game1 game;
        private Skeleton skeleton;

        public SkeletonGreenArrowCollisionCheck(KeyBoardController KeyBoardController, SkeletonGreenArrowCollision skeletonGreenArrowCollision, Game1 game)
        {
            this.KeyBoardController = KeyBoardController;
            this.game = game;
            this.skeletonGreenArrowCollision = new SkeletonGreenArrowCollision(this.game, this.KeyBoardController);
        }

        public ISprite CheckCollision()
        {
            foreach (IEnemy enemy in game.currentRoom.GetEnemies())
            {
                if (enemy.GetType() == typeof(Skeleton))
                {
                    skeleton = (Skeleton)enemy;
                    if (skeleton.location.X - KeyBoardController.linkSprite.attack.greenArrow.currentX >= GameConstants.Zero && skeleton.location.X - KeyBoardController.linkSprite.attack.greenArrow.currentX <=
                        ItemConstants.ArrowWidth * GameConstants.Sizing || KeyBoardController.linkSprite.attack.greenArrow.currentX - skeleton.location.X >= 0 && KeyBoardController.linkSprite.attack.greenArrow.currentX - skeleton.location.X <= ItemConstants.ArrowWidth * GameConstants.Sizing)
                    {
                        return skeletonGreenArrowCollision.Update(skeleton);
                    }
                }
            }

            return null;
        }
    }
}
