using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;
using System.ComponentModel.Design;
using Sprint0.Link_Classes;
using static System.Reflection.Metadata.BlobBuilder;
using Sprint0.UI;
using Microsoft.Xna.Framework.Content;

namespace Sprint0
{
    public class KeyBoardController : IController
    {
        private Game1 game1;
        public Link linkSprite;
        //test
        private StaticText testingText;
        private HpHearts testingHearts;
        private MainHUD mainHUD;
        private PlayerMap playerMap;
        private Counts HUDnumbers;

        public Texture2D Texture { get; set; }
        public SpriteBatch _spriteBatch;

        public int dir, linkState;
        public Vector2 location;

        public MapCommands mappingCommands;
        public Dictionary<Keys, ICommand> controllerMapping;

        public BlockCollisionCheck blockCollisionCheck;

        public KeyBoardController(Game1 game1, SpriteBatch spriteBatch)
        {
            this.game1 = game1;

            linkSprite = new Link(game1);
            //temp
            testingText = new StaticText(game1);
            testingHearts = new HpHearts(game1);
            mainHUD = new MainHUD(game1);
            playerMap = new PlayerMap(game1);
            HUDnumbers = new Counts(game1); 

            controllerMapping = new Dictionary<Keys, ICommand>();
            mappingCommands = new MapCommands(this, controllerMapping, game1, linkSprite);
            mappingCommands.CreateCommands();
            controllerMapping = mappingCommands.GetControllerMapping(controllerMapping);

            blockCollisionCheck = new BlockCollisionCheck(this, new LinkBlockCollision(this, linkSprite), game1, linkSprite);

            dir = GameConstants.Down; linkState = LinkConstants.Default;
            _spriteBatch = spriteBatch;
        }
        public void Update(GameTime gameTime)
        {
            linkState = LinkConstants.Default; // reset link state

            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            Array.Sort(pressedKeys);
            Array.Reverse(pressedKeys);

            if (pressedKeys.Length != GameConstants.Zero && controllerMapping.ContainsKey(pressedKeys[GameConstants.Zero]))
                controllerMapping[pressedKeys[GameConstants.Zero]].Execute(gameTime);

            // collision checks
            blockCollisionCheck.CheckCollision();
            // more to follow..
            
            linkSprite.Update(linkState, dir, location);
            linkSprite.Draw(_spriteBatch);
            //temp

            testingText.Draw(_spriteBatch);
            mainHUD.Draw(_spriteBatch);
            testingHearts.Draw(_spriteBatch);
            playerMap.Draw(_spriteBatch);
            HUDnumbers.Draw(_spriteBatch);
        }

    }
}
