using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Collision.Response.Enemies;
using Sprint0.Link_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class SkeletonBombCollisionCheck
    {
        private KeyBoardController KeyBoardController;
        private SkeletonBombCollision skeletonBombCollision;
        private Game1 game;
        private Skeleton skeleton;

        public SkeletonBombCollisionCheck(KeyBoardController KeyBoardController, SkeletonBombCollision skeletonBombCollision, Game1 game)
        {
            this.KeyBoardController = KeyBoardController;
            this.game = game;
            this.skeletonBombCollision = new SkeletonBombCollision(this.game, this.KeyBoardController);
        }

        public ISprite CheckCollision()
        {
            foreach (IEnemy enemy in game.currentRoom.GetEnemies())
            {
                if (enemy.GetType() == typeof(Skeleton))
                {
                    skeleton = (Skeleton)enemy;
                    if (skeleton.location.X - (int)KeyBoardController.linkSprite.attack.bomb.location1.X >= GameConstants.Zero && skeleton.location.X - (int)KeyBoardController.linkSprite.attack.bomb.location1.X <=
                        ItemConstants.BombWidth * GameConstants.Sizing || (int)KeyBoardController.linkSprite.attack.bomb.location1.X - skeleton.location.X >= 0 && (int)KeyBoardController.linkSprite.attack.bomb.location1.X - skeleton.location.X <= ItemConstants.BombWidth * GameConstants.Sizing)
                    {
                        return skeletonBombCollision.Update(skeleton);
                    }
                }
            }

            return null;
        }
    }
}
