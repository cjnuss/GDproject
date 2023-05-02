using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprint0.Levels;
using Sprint0.UI;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Sprint0.Collision.Response.Walls;

namespace Sprint0
{
    public class GameManager
    {
        public Game1 game1;
        public Rectangle source = LevelsTextureStorage.level2;
        public Rectangle target = new Rectangle(0, 150, 800, 480);
        public Texture2D texture = LevelsTextureStorage.Instance.GetLevels();
        public int roomNum = 1;

        public Door checkDoor;

        private RoomLoad roomLoad;
        public List<Room> roomList = new List<Room>();

        private Transition transition;

        private int state;

        private KeyBoardController Kcontroller;
        private MouseController Mcontroller;

        private CollisionManager collisionManager;
        private DoorCollisions doorCollision;
        private Link linkSprite;

        private StaticText testingText;
        private HpHearts testingHearts;
        private MainHUD mainHUD;
        private PlayerMap playerMap;
        private Counts HUDnumbers;

        private WinningState winningState;
        private LosingState losingState;

        private SpriteBatch _spriteBatch;

        private StartScreen startScreen;
        private PauseScreen pauseScreen;

        private List<ISprite> dropedItems;


        public GameManager(Game1 game, SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
            game1 = game;
            state = 0;

            roomLoad = new RoomLoad();

            for (int i = 1; i <= 17; i++)
            {
                roomList.Add(roomLoad.load("Room" + i.ToString() + ".txt"));
            }

            linkSprite = new Link(game);
            Kcontroller = new KeyBoardController(game, _spriteBatch, linkSprite);
            Mcontroller = new MouseController(game, _spriteBatch);

            transition = new Transition(this, linkSprite);

            // hud setup
            testingText = new StaticText(game);
            testingHearts = new HpHearts(game);
            mainHUD = new MainHUD(game);
            playerMap = new PlayerMap(game, this);
            HUDnumbers = new Counts(game, game.linkItems);

            startScreen = new StartScreen(this);
            pauseScreen = new PauseScreen(this);

            winningState = new WinningState(game, _spriteBatch);
            losingState = new LosingState(game, _spriteBatch);

            dropedItems = new List<ISprite>();

            doorCollision = new DoorCollisions(Kcontroller, game1, linkSprite);
            collisionManager = new CollisionManager(Kcontroller, game1, linkSprite);
            collisionManager.Create();
        }

        public void Update()
        {
            // start screen
            if (state == 0)
            {
                startScreen.Update();
            }
            // playing
            else if (state == 1)
            {
                roomList[roomNum].Update();
                pauseScreen.Update(); // check for pause
            }
            // pause
            else if (state == 2)
            {
                pauseScreen.Update();
            }
            // inventory
            else if (state == 3)
            {

            }
            // transition
            else if (state == 4)
            {
                transition.MoveScreen();
                game1.currentRoom = roomList[roomNum];
                doorCollision.UpdateCollisionBlocks();
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            // start screen
            if (state == 0)
            {
                startScreen.Draw(spriteBatch, gameTime);
            }
            // playing
            else if (state == 1)
            {
                spriteBatch.Draw(texture, target, source, Color.White);
                game1.currentRoom = roomList[roomNum];
                Mcontroller.Update(gameTime);

                if (!game1.linkItems.triforce && game1.linkHealth.health > GameConstants.Zero)
                {
                    collisionManager.Check();
                    Kcontroller.Update(gameTime);
                }
                else if (game1.linkHealth.health == GameConstants.Zero)
                {
                    losingState.Update(Kcontroller);
                }
                else
                {
                    winningState.Update(game1, Kcontroller);
                }

                roomList[roomNum].Draw(spriteBatch);

                testingText.Draw(_spriteBatch);
                mainHUD.Draw(_spriteBatch);
                testingHearts.Update();
                testingHearts.Draw(_spriteBatch);
                playerMap.Draw(_spriteBatch);
                HUDnumbers.Update();
                HUDnumbers.Draw(_spriteBatch);

                collisionManager.Check();

                dropedItems = collisionManager.DropedItems();

                checkDoor = doorCollision.Check();

                foreach(ISprite item in dropedItems)
                {
                    if(item != null)
                        roomList[roomNum].AddItems(item);
                }

                if (checkDoor != null)
                {
                    state = 4;
                    transition.StartTransition(checkDoor, roomList[roomNum].GetRooms());
                }
            }
            // pause
            else if (state == 2)
            {
                pauseScreen.Draw(_spriteBatch, gameTime);
            }
            // inventory
            else if (state == 3)
            {

            }
            // transition
            else if (state == 4)
            {
                spriteBatch.Draw(texture, target, source, Color.White);
            }
        }

        public void SetState(int newState)
        {
            state = newState;
        }

        public void gameStart()
        {
            game1.currentRoom = roomList[roomNum];
            doorCollision.UpdateCollisionBlocks();
        }
    }
}
