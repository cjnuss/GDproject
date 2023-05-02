using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Collision.Response.Enemies;
using Sprint0.Collision.Response.Walls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class LinkAquamentusCollisionCheck
    {
        public KeyBoardController KeyBoardController;
        public LinkAquamentusCollision linkAquamentusCollision;
        public EnemyWallCollision enemyRoomCollisionCheck;
        public Game1 game1;
        public Link link;
        public int roomType;

        public LinkAquamentusCollisionCheck(KeyBoardController KeyBoardController, Game1 game1, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            this.game1 = game1;
            linkAquamentusCollision = new LinkAquamentusCollision(this.KeyBoardController, this.link, this.game1);
        }

        public void CheckCollision()
        {
            Aquamentus aquamentus;
            if(link.invisibilityFrames == 0)
            {
                foreach (IEnemy enemy in game1.currentRoom.GetEnemies())
                {
                    if (enemy.GetType() == typeof(Aquamentus))
                    {
                        aquamentus = (Aquamentus)enemy;
                        if (aquamentus.GetLocation().X - KeyBoardController.linkSprite.location.X >= GameConstants.Zero && aquamentus.GetLocation().X - KeyBoardController.linkSprite.location.X <=
                        LinkConstants.Size * GameConstants.Sizing || KeyBoardController.linkSprite.location.X - aquamentus.GetLocation().X >= 0 && KeyBoardController.linkSprite.location.X - aquamentus.GetLocation().X <= aquamentus.GetSize().X)
                        {
                            linkAquamentusCollision.Update(aquamentus);
                        }

                        if (KeyBoardController.linkSprite.velocity == GameConstants.Zero)
                        {
                            KeyBoardController.linkSprite.velocity = LinkConstants.Velocity;
                            break;
                        }
                    }
                }
            } else
            {
                link.invisibilityFrames--;
            }
        }
    }
}
