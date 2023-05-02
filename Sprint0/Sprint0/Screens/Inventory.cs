using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Sprint0.Levels;

namespace Sprint0
{
    public class Inventory : IGameScreen
    {
        private GameManager gameManager;
        private Game1 game;
        private bool paused = false;
        private bool canPress = true;
        private bool canMove = true;

        TimeSpan delayTime = TimeSpan.FromSeconds(1);
        TimeSpan delayTime2 = TimeSpan.FromSeconds(1);

        Texture2D texture;

        Rectangle target1 = new Rectangle(0, 150, 800, 205);
        Rectangle target2 = new Rectangle(0, 355, 800, 275);

        Rectangle map = InventoryTextureStorage.map;
        Rectangle inv = InventoryTextureStorage.inv;

        Rectangle mapItem = InventoryTextureStorage.mapItem;
        Rectangle compass = InventoryTextureStorage.compass;

        Rectangle bow = InventoryTextureStorage.bow;
        Rectangle arrow = InventoryTextureStorage.arrow;
        Rectangle bomb = InventoryTextureStorage.bomb;
        Rectangle boomerang = InventoryTextureStorage.boomerang;

        Rectangle hover1 = InventoryTextureStorage.hover1;
        Rectangle hover2 = InventoryTextureStorage.hover2;

        List<Rectangle> topRow = new List<Rectangle>();
        List<Rectangle> bottomRow = new List<Rectangle>();

        List<Rectangle> target = new List<Rectangle>();

        Rectangle higlight = new Rectangle(212, 225, 25, 50);

        private int currentFrame = 0;
        private int hover = 0;

        List<InventoryMap> invMaps = new List<InventoryMap>();

        List<Rectangle> locations = InventoryTextureStorage.Instance.Locations();

        public Inventory(GameManager gameManager, Game1 game)
        {
            this.gameManager = gameManager;
            this.game = game;

            texture = InventoryTextureStorage.Instance.Inventory();

            topRow.Add(new Rectangle(403, 225, 50, 50));
            topRow.Add(new Rectangle(478, 225, 50, 50));
            topRow.Add(new Rectangle(553, 225, 50, 50));
            topRow.Add(new Rectangle(628, 225, 50, 50));

            bottomRow.Add(new Rectangle(403, 275, 50, 50));
            bottomRow.Add(new Rectangle(478, 275, 50, 50));
            bottomRow.Add(new Rectangle(553, 275, 50, 50));
            bottomRow.Add(new Rectangle(628, 275, 50, 50));

            target = topRow;

            int i = 0;
            foreach (Room room in gameManager.roomList)
            {
                invMaps.Add(new InventoryMap(room, this.gameManager, i));
                i++;
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(texture, target1, inv, Color.White);
            spriteBatch.Draw(texture, target2, map, Color.White);

            if (currentFrame < 10)
            {
                spriteBatch.Draw(texture, target[hover], hover1, Color.White);
            } else
            {
                spriteBatch.Draw(texture, target[hover], hover2, Color.White);
            }

            if(game.linkItems.bow)
            {
                spriteBatch.Draw(texture, new Rectangle(575, 225, 25, 50), bomb, Color.White);
            }

            if (game.linkItems.arrow)
            {
                spriteBatch.Draw(texture, new Rectangle(550, 225, 25, 50), bomb, Color.White);
            }

            if (game.linkItems.bombs > 0)
            {
                spriteBatch.Draw(texture, new Rectangle(487, 225, 25, 50), bomb, Color.White);
            }

            if (game.linkItems.map)
            {
                spriteBatch.Draw(texture, new Rectangle(150, 430, 25, 50), mapItem, Color.White);
            }
            if (game.linkItems.compass)
            {
                spriteBatch.Draw(texture, new Rectangle(137, 555, 47, 50), compass, Color.White);
            }
            switch (hover)
            {
                case 0:
                    if (target == topRow)
                    {
                    }
                    break;
                case 1:
                    if ((target == topRow) && (game.linkItems.bombs > 0))
                    {
                        spriteBatch.Draw(texture, higlight, bomb, Color.White);
                    }
                    break;
                case 2:
                    if ((target == topRow) && game.linkItems.bow)
                    {
                        spriteBatch.Draw(texture, higlight, bow, Color.White);
                    }
                    break;
            }
            int i = 0;
            foreach (Room room in gameManager.roomList)
            {
                invMaps[i].Draw(spriteBatch);
                i++;
            }
            spriteBatch.Draw(texture, locations[gameManager.roomNum], InventoryTextureStorage.dot, Color.White);
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == 20)
            {
                currentFrame = 0;
            }

            KeyboardState currentKeyboardState = Keyboard.GetState();

            if (canMove && currentKeyboardState.IsKeyDown(Keys.A))
            {
                canMove = false;
                delayTime2 = TimeSpan.FromSeconds(1);
                if (hover != 0)
                {
                    hover--;
                }
            }

            if (canMove && currentKeyboardState.IsKeyDown(Keys.D))
            {
                canMove = false;
                delayTime2 = TimeSpan.FromSeconds(1);
                if (hover != 3)
                {
                    hover++;
                }
            }

            if (canMove && currentKeyboardState.IsKeyDown(Keys.W))
            {
                canMove = false;
                delayTime2 = TimeSpan.FromSeconds(1);
                if (target != topRow)
                {
                    target = topRow;
                }
            }

            if (canMove && currentKeyboardState.IsKeyDown(Keys.S))
            {
                canMove = false;
                delayTime2 = TimeSpan.FromSeconds(1);
                if (target != bottomRow)
                {
                    target = bottomRow;
                }
            }

            if (canPress && (currentKeyboardState.IsKeyDown(Keys.I)))
            {
                if (!paused)
                {
                    paused = true;
                    gameManager.SetState(3);
                } else
                {
                    paused = false;
                    gameManager.SetState(1);
                }
                canPress = false;
                delayTime = TimeSpan.FromSeconds(2);
            }
            else if (currentKeyboardState.IsKeyDown(Keys.Q))
            {
                gameManager.game1.Exit();
            }

            if (!canMove)
            {
                delayTime2 -= TimeSpan.FromMilliseconds(40);

                if (delayTime2 <= TimeSpan.Zero)
                {
                    canMove = true;
                }
            }

            if (!canPress)
            {
                delayTime -= TimeSpan.FromMilliseconds(30);

                if (delayTime <= TimeSpan.Zero)
                {
                    canPress = true;
                }
            }

            int i = 0;
            foreach (Room room in gameManager.roomList)
            {
                invMaps[i].Update();
                i++;
            }
        }
    }
}
