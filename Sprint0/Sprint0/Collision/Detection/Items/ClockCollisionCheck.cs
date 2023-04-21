using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Collision.Response.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.Collision.Detection.Items
{
    public class ClockCollisionCheck
    {
        public KeyBoardController KeyBoardController;
        public LinkClockCollision linkClockCollision;
        public Game1 game1;
        public Link link;

        public ClockCollisionCheck(KeyBoardController KeyBoardController, LinkClockCollision linkClockCollision, Game1 game1, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.link = link;
            this.game1 = game1;
            this.linkClockCollision = new LinkClockCollision(this.game1, this.KeyBoardController, this.link);
        }

        public void CheckCollision()
        {
            Clock clock;
            foreach (ISprite item in game1.currentRoom.GetItems())
            {
                if (item.GetType() == typeof(Clock))
                {
                    clock = (Clock)item;
                    if (clock.location.X - KeyBoardController.linkSprite.location.X >= GameConstants.Zero && clock.location.X - KeyBoardController.linkSprite.location.X <=
                        LinkConstants.Size * GameConstants.Sizing || KeyBoardController.linkSprite.location.X - clock.location.X >= 0 && KeyBoardController.linkSprite.location.X - clock.location.X <= ItemConstants.ClockWidth * GameConstants.Sizing)
                    {
                        linkClockCollision.Update(clock);
                    }
                }
            }
        }
    }
}
