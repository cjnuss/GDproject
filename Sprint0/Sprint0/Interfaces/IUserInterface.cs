﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public interface IUserInterface
    {
        public void Draw(SpriteBatch spriteBatch);
        public void Update();

    }
}
