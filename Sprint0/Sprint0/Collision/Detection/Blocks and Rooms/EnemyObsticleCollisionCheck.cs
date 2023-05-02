using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Collision.Response.Blocks;
using Sprint0.Collision.Response.Enemies;
using Sprint0.Collision.Response.Items;
using Sprint0.Collision.Response.Walls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class EnemyObsticleCollisionCheck
    {
        public KeyBoardController KeyBoardController;
        public EnemyBlockCollision enemyBlockCollision;
        public EnemyWallCollision enemyWallCollision;
        public Game1 game1;
        public IEnemy enemy;
        public int roomType;

        public EnemyObsticleCollisionCheck(KeyBoardController KeyBoardController, Game1 game1, IEnemy enemy)
        {
            this.KeyBoardController = KeyBoardController;
            this.enemy = enemy;
            this.game1 = game1;
            
            
        }

        public void CheckCollision()
        {
            foreach (IEnemy enemy in game1.currentRoom.GetEnemies())
            {
                enemyWallCollision = new EnemyWallCollision(KeyBoardController, enemy);
                if(!enemyWallCollision.Update())
                {
                    foreach (CollisionBlock block in game1.currentRoom.GetBlocks())
                    {
                        enemyBlockCollision = new EnemyBlockCollision(KeyBoardController, enemy);

                        if ((block.location.X - enemy.GetLocation().X >= GameConstants.Zero && block.location.X - enemy.GetLocation().X <=
                            enemy.GetSize().X * GameConstants.Sizing) || (enemy.GetLocation().X - block.location.X >= 0 && enemy.GetLocation().X - block.location.X <= block.width))
                        {
                            enemyBlockCollision.Update(block);
                        }
                    }
                }
            }
        }
    }
}
