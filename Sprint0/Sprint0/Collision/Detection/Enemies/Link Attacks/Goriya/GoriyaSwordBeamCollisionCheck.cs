﻿using Microsoft.Xna.Framework;
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
    public class GoriyaSwordBeamCollisionCheck
    {
        private KeyBoardController KeyBoardController;
        private GoriyaSwordBeamCollision goriyaSwordBeamCollision;
        private Game1 game;
        private Link link;
        private Goriya goriya;

        public GoriyaSwordBeamCollisionCheck(KeyBoardController KeyBoardController, GoriyaSwordBeamCollision goriyaSwordBeamCollision, Game1 game, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.game = game;
            this.link = link;
            this.goriyaSwordBeamCollision = new GoriyaSwordBeamCollision(this.game, this.KeyBoardController, this.link);
        }

        public void CheckCollision()
        {
            foreach (IEnemy enemy in game.currentRoom.GetEnemies())
            {
                if (enemy.GetType() == typeof(Goriya))
                {
                    goriya = (Goriya)enemy;
                    if (goriya.location.X - KeyBoardController.linkSprite.attack.swordBeam.currentX >= GameConstants.Zero && goriya.location.X - KeyBoardController.linkSprite.attack.swordBeam.currentX <=
                        LinkConstants.SwordBeamWidth * GameConstants.Sizing || KeyBoardController.linkSprite.attack.swordBeam.currentX - goriya.location.X >= 0 && KeyBoardController.linkSprite.attack.swordBeam.currentX - goriya.location.X <= LinkConstants.SwordBeamWidth * GameConstants.Sizing)
                    {
                        goriyaSwordBeamCollision.Update(goriya);
                    }
                }
            }
        }
    }
}