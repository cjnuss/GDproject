﻿using Microsoft.Xna.Framework.Input;
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

namespace Sprint0
{
    public class KeyBoardController : IController
    {
        private Game1 game1;
        public Link linkSprite;

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

            controllerMapping = new Dictionary<Keys, ICommand>();
            mappingCommands = new MapCommands(this, controllerMapping, game1, linkSprite);
            mappingCommands.CreateCommands();
            controllerMapping = mappingCommands.GetControllerMapping(controllerMapping);

            blockCollisionCheck = new BlockCollisionCheck(this, new LinkBlockCollision(this, linkSprite), game1, linkSprite);

            dir = 0; linkState = 0;
            _spriteBatch = spriteBatch;
        }
        public void Update(GameTime gameTime)
        {
            linkState = 0; // reset link state

            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            Array.Sort(pressedKeys);
            Array.Reverse(pressedKeys);

            if (pressedKeys.Length != 0 && controllerMapping.ContainsKey(pressedKeys[0]))
                controllerMapping[pressedKeys[0]].Execute(gameTime);

            // collision checks
            blockCollisionCheck.CheckCollision();
            // more to follow..
            
            linkSprite.Update(linkState, dir, location);
            linkSprite.Draw(_spriteBatch);
        }

    }
}
