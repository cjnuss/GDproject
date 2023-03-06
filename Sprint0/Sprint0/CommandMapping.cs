﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public class MapCommands
    {
        public KeyBoardController KeyBoardController;
        public Dictionary<Keys, ICommand> controllerMapping;
        public Game1 game1;
        public Link link;

        // list of commands
        public ExitCommand exitCommand;
        public ResetCommand resetCommand;
        public LinkMoveLeftCommand linkMoveLeftCommand;
        public LinkMoveRightCommand linkMoveRightCommand;
        public LinkMoveUpCommand linkMoveUpCommand;
        public LinkMoveDownCommand linkMoveDownCommand;
        public LinkDamageCommand linkDamageCommand;
        public LinkAttackingCommand linkAttackingCommand;
        public LinkThrowGreenArrowCommand linkThrowGreenArrowCommand;

        public MapCommands(KeyBoardController KeyBoardController, Dictionary<Keys, ICommand> controllerMapping, Game1 game1, Link link)
        {
            this.KeyBoardController = KeyBoardController;
            this.controllerMapping = controllerMapping;
            this.game1 = game1;
            this.link = link;
        }

        public void createCommands()
        {
            exitCommand = new ExitCommand(game1);
            resetCommand = new ResetCommand(KeyBoardController, link, game1);
            linkMoveLeftCommand = new LinkMoveLeftCommand(KeyBoardController, link);
            linkMoveUpCommand = new LinkMoveUpCommand(KeyBoardController, link);
            linkMoveDownCommand = new LinkMoveDownCommand(KeyBoardController, link);
            linkMoveRightCommand = new LinkMoveRightCommand(KeyBoardController, link);
            linkDamageCommand = new LinkDamageCommand(KeyBoardController, link);
            linkAttackingCommand = new LinkAttackingCommand(KeyBoardController, link);
            linkThrowGreenArrowCommand = new LinkThrowGreenArrowCommand(KeyBoardController, link);
        }

        public Dictionary<Keys, ICommand> getControllerMapping(Dictionary<Keys, ICommand> controllerMapping)
        {
            controllerMapping.Add(Keys.Q, exitCommand);
            controllerMapping.Add(Keys.R, resetCommand);

            controllerMapping.Add(Keys.W, linkMoveUpCommand);
            controllerMapping.Add(Keys.S, linkMoveDownCommand);
            controllerMapping.Add(Keys.A, linkMoveLeftCommand);
            controllerMapping.Add(Keys.D, linkMoveRightCommand);
            controllerMapping.Add(Keys.Up, linkMoveUpCommand);
            controllerMapping.Add(Keys.Down, linkMoveDownCommand);
            controllerMapping.Add(Keys.Left, linkMoveLeftCommand);
            controllerMapping.Add(Keys.Right, linkMoveRightCommand);

            controllerMapping.Add(Keys.E, linkDamageCommand);
            controllerMapping.Add(Keys.Z, linkAttackingCommand);
            controllerMapping.Add(Keys.N, linkAttackingCommand);
            controllerMapping.Add(Keys.D1, linkThrowGreenArrowCommand);

            return controllerMapping;
        }
    }
}
