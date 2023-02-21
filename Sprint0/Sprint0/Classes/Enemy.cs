using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class Enemy : IEnemy
    {
        private Game1 game1;

        public ISprite1 sprite;
        private int currentCount = 0;
        private int totalCount = 10;

        private int currentSprite = 0;

        private Skeleton skeleton;
        private Gel gel;
        private Bat bat;
        private Aquamentus aquamentus;
        private Goriya goriya;
        private OldMan oldman;

        private ISprite1[] sprites;

        public Enemy(Game1 game1)
        {
            this.game1 = game1;

            skeleton = new Skeleton();
            gel = new Gel();
            bat = new Bat();
            aquamentus = new Aquamentus();
            goriya = new Goriya();
            oldman = new OldMan();

            sprites = new ISprite1[]
            {
                skeleton,
                gel,
                bat,
                aquamentus,
                goriya,
                oldman
            };
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprites[currentSprite].Draw(spriteBatch);
        }

        public void Update(int enemyState)
        {
            if (currentCount >= totalCount)
            {
                currentCount = 0;
                if (enemyState == 1)
                {
                    if (currentSprite == 0)
                    {
                        currentSprite = 5;
                    }
                    else
                    {
                        currentSprite--;
                    }
                    ResetSprite();
                }
                else if (enemyState == 2)
                {
                    if (currentSprite == 5)
                    {
                        currentSprite = 0;
                    }
                    else
                    {
                        currentSprite++;
                    }
                    ResetSprite();
                }
            }
            else
            {
                currentCount++;
            }
            if (enemyState == 0)
            {
                currentSprite = 0;
                ResetSprite();
            }
            sprites[currentSprite].Update();
        }

        private void ResetSprite()
        {
            switch (currentSprite)
            {
                case 0:
                    sprites[0] = new Skeleton();
                    break;
                case 1:
                    sprites[1] = new Gel();
                    break;
                case 2:
                    sprites[2] = new Bat();
                    break;
                case 3:
                    sprites[3] = new Aquamentus();
                    break;
                case 4:
                    sprites[4] = new Goriya();
                    break;
                case 5:
                    sprites[5] = new OldMan();
                    break;
            }
        }
    }
}
