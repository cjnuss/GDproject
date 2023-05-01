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
        private IEnemy enemy;

        private LinkObsticleCollisionCheck linkObsticleCollisionCheck;
        private TriforceCollisionCheck triforceCollisionCheck;
        private ArrowCollisionCheck arrowCollisionCheck;
        private BombCollisionCheck bombCollisionCheck;
        private RupeeCollisionCheck rupeeCollisionCheck;
        private LinkEnemyCollisionCheck enemyCollisionCheck;
        private HeartCollisionCheck heartCollisionCheck;
        private KeyCollisionCheck keyCollisionCheck;
        private MapCollisionCheck mapCollisionCheck;
        private BowCollisionCheck bowCollisionCheck;
        private ClockCollisionCheck clockCollisionCheck;
        private CompassCollisionCheck compassCollisionCheck;
        private FairyCollisionCheck fairyCollisionCheck;
        private EnemyObsticleCollisionCheck enemyObsticleCollisionCheck;

        private BatSwordCollisionCheck batSwordCollisionCheck;
        private BatGreenArrowCollisionCheck batGreenArrowCollisionCheck;
        private BatBombCollisionCheck batBombCollisionCheck;
        private BatFireCollisionCheck batFireCollisionCheck;
        private BatBlueArrowCollisionCheck batBlueArrowCollisionCheck;
        private BatSwordBeamCollisionCheck batSwordBeamCollisionCheck;

        private SkeletonGreenArrowCollisionCheck skeletonGreenArrowCollisionCheck;
        private SkeletonBlueArrowCollisionCheck skeletonBlueArrowCollisionCheck;
        private SkeletonFireCollisionCheck skeletonFireCollisionCheck;
        private SkeletonBombCollisionCheck skeletonBombCollisionCheck;
        private SkeletonSwordCollisionCheck skeletonSwordCollisionCheck;
        private SkeletonSwordBeamCollisionCheck skeletonSwordBeamCollisionCheck;

        private GoriyaGreenArrowCollisionCheck goriyaGreenArrowCollisionCheck;
        private GoriyaSwordCollisionCheck goriyaSwordCollisionCheck;
        private GoriyaBlueArrowCollisionCheck goriyaBlueArrowCollisionCheck;
        private GoriyaFireCollisionCheck goriyaFireCollisionCheck;
        private GoriyaBombCollisionCheck goriyaBombCollisionCheck;
        private GoriyaSwordBeamCollisionCheck goriyaSwordBeamCollisionCheck;

        private GelSwordCollisionCheck gelSwordCollisionCheck;
        private GelGreenArrowCollisionCheck gelGreenArrowCollisionCheck;
        private GelBombCollisionCheck gelBombCollisionCheck;
        private GelFireCollisionCheck gelFireCollisionCheck;
        private GelBlueArrowCollisionCheck gelBlueArrowCollisionCheck;
        private GelSwordBeamCollisionCheck gelSwordBeamCollisionCheck;

        private AquamentusSwordCollisionCheck aquamentusSwordCollisionCheck;
        private AquamentusGreenArrowCollisionCheck aquamentusGreenArrowCollisionCheck;
        private AquamentusBombCollisionCheck aquamentusBombCollisionCheck;
        private AquamentusFireCollisionCheck aquamentusFireCollisionCheck;
        private AquamentusBlueArrowCollisionCheck aquamentusBlueArrowCollisionCheck;
        private AquamentusSwordBeamCollisionCheck aquamentusSwordBeamCollisionCheck;

        private List<ISprite> dropedItems = new List<ISprite>();

        public CollisionManager(KeyBoardController keyBoardController, Game1 game1, Link linkSprite)
        {
            KeyBoardController = keyBoardController;
            this.game1 = game1;
            this.linkSprite = linkSprite;
        }

        public void Create()
        {
            linkObsticleCollisionCheck = new LinkObsticleCollisionCheck(this.KeyBoardController, this.game1, this.linkSprite);
            triforceCollisionCheck = new TriforceCollisionCheck(this.KeyBoardController, new LinkTriforceCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);
            arrowCollisionCheck = new ArrowCollisionCheck(this.KeyBoardController, new LinkArrowCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);
            bombCollisionCheck = new BombCollisionCheck(this.KeyBoardController, new LinkBombCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);
            rupeeCollisionCheck = new RupeeCollisionCheck(this.KeyBoardController, new LinkRupeeCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);
            enemyCollisionCheck = new LinkEnemyCollisionCheck(this.KeyBoardController, this.game1, this.linkSprite);
            heartCollisionCheck = new HeartCollisionCheck(this.KeyBoardController, new LinkHeartCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);
            keyCollisionCheck = new KeyCollisionCheck(this.KeyBoardController, new LinkKeyCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);
            mapCollisionCheck = new MapCollisionCheck(this.KeyBoardController, new LinkMapCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);
            bowCollisionCheck = new BowCollisionCheck(this.KeyBoardController, new LinkBowCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);
            clockCollisionCheck = new ClockCollisionCheck(this.KeyBoardController, new LinkClockCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);
            compassCollisionCheck = new CompassCollisionCheck(this.KeyBoardController, new LinkCompassCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);
            fairyCollisionCheck = new FairyCollisionCheck(this.KeyBoardController, new LinkFairyCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);

            batSwordCollisionCheck = new BatSwordCollisionCheck(this.KeyBoardController, new BatSwordCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);
            batGreenArrowCollisionCheck = new BatGreenArrowCollisionCheck(this.KeyBoardController, new BatGreenArrowCollision(this.game1, this.KeyBoardController), this.game1);
            batBombCollisionCheck = new BatBombCollisionCheck(this.KeyBoardController, new BatBombCollision(this.game1, this.KeyBoardController), this.game1);
            batFireCollisionCheck = new BatFireCollisionCheck(this.KeyBoardController, new BatFireCollision(this.game1, this.KeyBoardController), this.game1);
            batBlueArrowCollisionCheck = new BatBlueArrowCollisionCheck(this.KeyBoardController, new BatBlueArrowCollision(this.game1, this.KeyBoardController), this.game1);
            batSwordBeamCollisionCheck = new BatSwordBeamCollisionCheck(this.KeyBoardController, new BatSwordBeamCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);

            skeletonGreenArrowCollisionCheck = new SkeletonGreenArrowCollisionCheck(this.KeyBoardController, new SkeletonGreenArrowCollision(this.game1, this.KeyBoardController), this.game1);
            skeletonBlueArrowCollisionCheck = new SkeletonBlueArrowCollisionCheck(this.KeyBoardController, new SkeletonBlueArrowCollision(this.game1, this.KeyBoardController), this.game1);
            skeletonFireCollisionCheck = new SkeletonFireCollisionCheck(this.KeyBoardController, new SkeletonFireCollision(this.game1, this.KeyBoardController), this.game1);
            skeletonBombCollisionCheck = new SkeletonBombCollisionCheck(this.KeyBoardController, new SkeletonBombCollision(this.game1, this.KeyBoardController), this.game1);
            skeletonSwordCollisionCheck = new SkeletonSwordCollisionCheck(this.KeyBoardController, new SkeletonSwordCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);
            skeletonSwordBeamCollisionCheck = new SkeletonSwordBeamCollisionCheck(this.KeyBoardController, new SkeletonSwordBeamCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);

            goriyaGreenArrowCollisionCheck = new GoriyaGreenArrowCollisionCheck(this.KeyBoardController, new GoriyaGreenArrowCollision(this.game1, this.KeyBoardController), this.game1);
            goriyaSwordCollisionCheck = new GoriyaSwordCollisionCheck(this.KeyBoardController, new GoriyaSwordCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);
            goriyaBlueArrowCollisionCheck = new GoriyaBlueArrowCollisionCheck(this.KeyBoardController, new GoriyaBlueArrowCollision(this.game1, this.KeyBoardController), this.game1);
            goriyaFireCollisionCheck = new GoriyaFireCollisionCheck(this.KeyBoardController, new GoriyaFireCollision(this.game1, this.KeyBoardController), this.game1);
            goriyaBombCollisionCheck = new GoriyaBombCollisionCheck(this.KeyBoardController, new GoriyaBombCollision(this.game1, this.KeyBoardController), this.game1);
            goriyaSwordBeamCollisionCheck = new GoriyaSwordBeamCollisionCheck(this.KeyBoardController, new GoriyaSwordBeamCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);

            gelGreenArrowCollisionCheck = new GelGreenArrowCollisionCheck(this.KeyBoardController, new GelGreenArrowCollision(this.game1, this.KeyBoardController), this.game1);
            gelBlueArrowCollisionCheck = new GelBlueArrowCollisionCheck(this.KeyBoardController, new GelBlueArrowCollision(this.game1, this.KeyBoardController), this.game1);
            gelFireCollisionCheck = new GelFireCollisionCheck(this.KeyBoardController, new GelFireCollision(this.game1, this.KeyBoardController), this.game1);
            gelBombCollisionCheck = new GelBombCollisionCheck(this.KeyBoardController, new GelBombCollision(this.game1, this.KeyBoardController), this.game1);
            gelSwordCollisionCheck = new GelSwordCollisionCheck(this.KeyBoardController, new GelSwordCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);
            gelSwordBeamCollisionCheck = new GelSwordBeamCollisionCheck(this.KeyBoardController, new GelSwordBeamCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);

            aquamentusGreenArrowCollisionCheck = new AquamentusGreenArrowCollisionCheck(this.KeyBoardController, new AquamentusGreenArrowCollision(this.game1, this.KeyBoardController), this.game1);
            aquamentusBlueArrowCollisionCheck = new AquamentusBlueArrowCollisionCheck(this.KeyBoardController, new AquamentusBlueArrowCollision(this.game1, this.KeyBoardController), this.game1);
            aquamentusFireCollisionCheck = new AquamentusFireCollisionCheck(this.KeyBoardController, new AquamentusFireCollision(this.game1, this.KeyBoardController), this.game1);
            aquamentusBombCollisionCheck = new AquamentusBombCollisionCheck(this.KeyBoardController, new AquamentusBombCollision(this.game1, this.KeyBoardController), this.game1);
            aquamentusSwordCollisionCheck = new AquamentusSwordCollisionCheck(this.KeyBoardController, new AquamentusSwordCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);
            aquamentusSwordBeamCollisionCheck = new AquamentusSwordBeamCollisionCheck(this.KeyBoardController, new AquamentusSwordBeamCollision(this.game1, this.KeyBoardController, this.linkSprite), this.game1, this.linkSprite);

            enemyObsticleCollisionCheck = new EnemyObsticleCollisionCheck(KeyBoardController, game1, enemy);
        }

        public void Check()
        {
            #region Top Level Game Collisions
            linkObsticleCollisionCheck.CheckCollision();
            enemyCollisionCheck.CheckCollision();
            enemyObsticleCollisionCheck.CheckCollision();
            #endregion

            #region Link Item Collisions
            triforceCollisionCheck.CheckCollision();
            arrowCollisionCheck.CheckCollision();
            bombCollisionCheck.CheckCollision();
            rupeeCollisionCheck.CheckCollision();
            heartCollisionCheck.CheckCollision();
            keyCollisionCheck.CheckCollision();
            mapCollisionCheck.CheckCollision();
            bowCollisionCheck.CheckCollision();
            clockCollisionCheck.CheckCollision();
            compassCollisionCheck.CheckCollision();
            fairyCollisionCheck.CheckCollision();
            #endregion

            #region Enemy & Link Attack Collisions
            batSwordCollisionCheck.CheckCollision();
            batGreenArrowCollisionCheck.CheckCollision();
            batBombCollisionCheck.CheckCollision();
            batFireCollisionCheck.CheckCollision();
            batBlueArrowCollisionCheck.CheckCollision();
            batSwordBeamCollisionCheck.CheckCollision();

            dropedItems.Add(skeletonGreenArrowCollisionCheck.CheckCollision());
            dropedItems.Add(skeletonBlueArrowCollisionCheck.CheckCollision());
            dropedItems.Add(skeletonFireCollisionCheck.CheckCollision());
            dropedItems.Add(skeletonBombCollisionCheck.CheckCollision());
            dropedItems.Add(skeletonSwordCollisionCheck.CheckCollision());
            dropedItems.Add(skeletonSwordBeamCollisionCheck.CheckCollision());

            goriyaGreenArrowCollisionCheck.CheckCollision();
            goriyaSwordCollisionCheck.CheckCollision();
            goriyaBlueArrowCollisionCheck.CheckCollision();
            goriyaFireCollisionCheck.CheckCollision();
            goriyaBombCollisionCheck.CheckCollision();
            goriyaSwordBeamCollisionCheck.CheckCollision();

            gelGreenArrowCollisionCheck.CheckCollision();
            gelBlueArrowCollisionCheck.CheckCollision();
            gelFireCollisionCheck.CheckCollision();
            gelBombCollisionCheck.CheckCollision();
            gelSwordCollisionCheck.CheckCollision();
            gelSwordBeamCollisionCheck.CheckCollision();

            dropedItems.Add(aquamentusGreenArrowCollisionCheck.CheckCollision());
            dropedItems.Add(aquamentusBlueArrowCollisionCheck.CheckCollision());
            dropedItems.Add(aquamentusFireCollisionCheck.CheckCollision());
            dropedItems.Add(aquamentusBombCollisionCheck.CheckCollision());
            dropedItems.Add(aquamentusSwordCollisionCheck.CheckCollision());
            dropedItems.Add(aquamentusSwordBeamCollisionCheck.CheckCollision());
            #endregion

        }

        public List<ISprite> DropedItems()
        {
            return dropedItems;
        }
    }
}
