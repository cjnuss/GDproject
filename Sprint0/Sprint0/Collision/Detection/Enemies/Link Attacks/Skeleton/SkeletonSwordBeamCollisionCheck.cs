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
    public class SkeletonSwordBeamCollisionCheck
    {
        private KeyBoardController KeyBoardController;
        private SkeletonSwordBeamCollision skeletonSwordBeamCollision;
        private Game1 game;
        private Link link;
        private Skeleton skeleton;

        public SkeletonSwordBeamCollisionCheck(KeyBoardController KeyBoardController, SkeletonSwordBeamCollision skeletonSwordBeamCollision, Game1 game, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.game = game;
            this.link = link;
            this.skeletonSwordBeamCollision = skeletonSwordBeamCollision;
        }

        public ISprite CheckCollision()
        {
            foreach (IEnemy enemy in game.currentRoom.GetEnemies())
            {
                if (enemy.GetType() == typeof(Skeleton))
                {
                    skeleton = (Skeleton)enemy;
                    if (skeleton.location.X - KeyBoardController.linkSprite.attack.swordBeam.currentX >= GameConstants.Zero && skeleton.location.X - KeyBoardController.linkSprite.attack.swordBeam.currentX <=
                        LinkConstants.SwordBeamWidth * GameConstants.Sizing || KeyBoardController.linkSprite.attack.swordBeam.currentX - skeleton.location.X >= 0 && KeyBoardController.linkSprite.attack.swordBeam.currentX - skeleton.location.X <= LinkConstants.SwordBeamWidth * GameConstants.Sizing)
                    {
                        return skeletonSwordBeamCollision.Update(skeleton);
                    }
                }
            }

            return null;
        }
    }
}
