﻿using Microsoft.Xna.Framework;
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
    public class SkeletonSwordCollision
    {
        public Game1 game;
        private Link link;
        private KeyBoardController KeyBoardController;
        private Rectangle linkRectangle;
        private Rectangle skeletonRectangle;

        public SkeletonSwordCollision(Game1 game, KeyBoardController KeyBoardController, Link link)
        {
            this.game = game;
            this.KeyBoardController = KeyBoardController;
            this.link = link;
        }

        public void Update(Skeleton skeleton)
        {
            linkRectangle = new Rectangle((int)link.location.X, (int)link.location.Y + LinkConstants.YChange, LinkConstants.Size * LinkConstants.Size, LinkConstants.CollisionSize * GameConstants.Sizing);
            skeletonRectangle = new Rectangle((int)skeleton.location.X, (int)skeleton.location.Y, EnemyConstants.SkeletonSize * GameConstants.Sizing, EnemyConstants.SkeletonSize * GameConstants.Sizing);

            if (skeletonRectangle.Intersects(linkRectangle) && KeyBoardController.linkState == LinkConstants.WoodenSword)
            {
                if (skeleton.hits < EnemyConstants.SkeletonHP)
                {
                    if (!skeleton.hit)
                        skeleton.Hit(KeyBoardController.dir);

                    if (!game.soundEffects.IsPlaying("EnemyHit"))
                        game.soundEffects.PlaySound("EnemyHit");
                }
                else
                {
                    skeleton.Dispose();
                    game.soundEffects.PlaySound("EnemyDie");
                }
            }
        }
    }
}
