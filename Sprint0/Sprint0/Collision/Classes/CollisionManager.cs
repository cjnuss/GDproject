using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Collision.Detection.Items;
using Sprint0.Collision.Detection.Enemies;
using Sprint0.Collision.Response.Enemies;
using Sprint0.Collision.Response.Items;
using Sprint0.Collision.Response.Blocks;

namespace Sprint0
{
    public class CollisionManager
    {
        private KeyBoardController KeyBoardController;
        private Game1 game1;
        private Link linkSprite;
        private BlockCollisionCheck blockCollisionCheck;
        private TriforceCollisionCheck triforceCollisionCheck;
        private ArrowCollisionCheck arrowCollisionCheck;
        private BombCollisionCheck bombCollisionCheck;
        private RupeeCollisionCheck rupeeCollisionCheck;
        private RoomCollisionCheck roomCollisionCheck;
        private EnemyCollisionCheck enemyCollisionCheck;
        private HeartCollisionCheck heartCollisionCheck;
        private KeyCollisionCheck keyCollisionCheck;
        private MapCollisionCheck mapCollisionCheck;
        private BowCollisionCheck bowCollisionCheck;
        private ClockCollisionCheck clockCollisionCheck;
        private CompassCollisionCheck compassCollisionCheck;
        private FairyCollisionCheck fairyCollisionCheck;

        private BatSwordCollisionCheck batSwordCollisionCheck;
        private BatGreenArrowCollisionCheck batGreenArrowCollisionCheck;

        public CollisionManager(KeyBoardController keyBoardController, Game1 game1, Link linkSprite)
        {
            KeyBoardController = keyBoardController;
            this.game1 = game1;
            this.linkSprite = linkSprite;
        }

        public void Create()
        {
            blockCollisionCheck = new BlockCollisionCheck(this.KeyBoardController, this.game1, this.linkSprite);
            triforceCollisionCheck = new TriforceCollisionCheck(this.KeyBoardController, new LinkTriforceCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);
            arrowCollisionCheck = new ArrowCollisionCheck(this.KeyBoardController, new LinkArrowCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);
            bombCollisionCheck = new BombCollisionCheck(this.KeyBoardController, new LinkBombCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);
            rupeeCollisionCheck = new RupeeCollisionCheck(this.KeyBoardController, new LinkRupeeCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);
            roomCollisionCheck = new RoomCollisionCheck(this.KeyBoardController, this.linkSprite);
            enemyCollisionCheck = new EnemyCollisionCheck(this.KeyBoardController, this.game1, this.linkSprite);
            heartCollisionCheck = new HeartCollisionCheck(this.KeyBoardController, new LinkHeartCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);
            keyCollisionCheck = new KeyCollisionCheck(this.KeyBoardController, new LinkKeyCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);
            mapCollisionCheck = new MapCollisionCheck(this.KeyBoardController, new LinkMapCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);
            bowCollisionCheck = new BowCollisionCheck(this.KeyBoardController, new LinkBowCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);
            clockCollisionCheck = new ClockCollisionCheck(this.KeyBoardController, new LinkClockCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);
            compassCollisionCheck = new CompassCollisionCheck(this.KeyBoardController, new LinkCompassCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);
            fairyCollisionCheck = new FairyCollisionCheck(this.KeyBoardController, new LinkFairyCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);
            roomCollisionCheck.roomType = GameConstants.Zero;

            batSwordCollisionCheck = new BatSwordCollisionCheck(this.KeyBoardController, new BatSwordCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);
            batGreenArrowCollisionCheck = new BatGreenArrowCollisionCheck(this.KeyBoardController, new BatGreenArrowCollision(this.game1, this.KeyBoardController), this.game1);
        }

        public void Check()
        {
            blockCollisionCheck.CheckCollision();
            triforceCollisionCheck.CheckCollision();
            arrowCollisionCheck.CheckCollision();
            bombCollisionCheck.CheckCollision();
            rupeeCollisionCheck.CheckCollision();
            triforceCollisionCheck.CheckCollision();
            roomCollisionCheck.CheckCollision();
            enemyCollisionCheck.CheckCollision();
            heartCollisionCheck.CheckCollision();
            keyCollisionCheck.CheckCollision();
            mapCollisionCheck.CheckCollision();
            bowCollisionCheck.CheckCollision();
            clockCollisionCheck.CheckCollision();
            compassCollisionCheck.CheckCollision();
            fairyCollisionCheck.CheckCollision();

            batSwordCollisionCheck.CheckCollision();
            batGreenArrowCollisionCheck.CheckCollision();
        }
    }
}
