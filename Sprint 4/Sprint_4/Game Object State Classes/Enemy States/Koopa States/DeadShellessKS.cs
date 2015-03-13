﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint4
{
    class DeadShellessKS : IEnemyState
    {
        Game1 game;
        IAnimatedSprite sprite;
        
        public DeadShellessKS(Game1 game)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.deadShellessKoopa);
            this.game = game;
        }
        public Rectangle GetRectangle(Vector2 location)
        {
            return sprite.GetRectangle(location);
        }

        public void TakeDamage(Enemy enemy)
        {
            // null
        }
        public void GoLeft(Enemy enemy)
        {
            //null
        }
        public void GoRight(Enemy enemy)
        {
            //null
        }

        public void Update(GameTime gameTime)
        {
            //null
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }
    }
}