﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class UsedBlockState : IBlockState
    {
        Game1 game;
        IAnimatedSprite sprite;
        

        public UsedBlockState(Game1 game)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.usedBlock);
            this.game = game;
        }
        public Rectangle GetRectangle(Vector2 location)
        {
            return sprite.GetRectangle(location);
        }
        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }

        public void Reaction()
        {
            // null 
        }
    }
}