﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class RightMovingBigMS : IMarioState
    {
        Game1 game;
        IAnimatedSprite sprite;

        public RightMovingBigMS(Game1 game)
        {
            ISpriteFactory factory = new SpriteFactory();
            sprite = factory.build(SpriteFactory.sprites.rightMovingMarioBig);
            this.game = game;
        }
        public Rectangle getRectangle(Vector2 location)
        {
            return sprite.GetRectangle(location);
        }

        public void TakeDamage()
        {
            game.level.mario.state = new RightMovingSmallMS(game);
        }
        public void Up()
        {
            game.level.mario.state = new RightJumpingBigMS(game);
        }
        public void Down()
        {
            game.level.mario.state = new RightCrouchingBigMS(game);
        }
        public void GoLeft()
        {
            game.level.mario.state = new LeftMovingBigMS(game);
        }
        public void GoRight()
        {
            game.level.mario.position.X++;
        }
        public void Idle()
        {
            game.level.mario.state = new RightIdleBigMS(game);
        }
        public void Land()
        {

        }
        public void MakeBigMario()
        {
           // no-op
        }
        public void MakeSmallMario()
        {
            game.level.mario.state = new RightMovingSmallMS(game);
        }
        public void MakeFireMario()
        {
            game.level.mario.state = new RightMovingFireMS(game);
        }
        public void MakeDeadMario()
        {
            game.level.mario.state = new DeadMS(game);
        }
        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            sprite.Draw(spriteBatch, location);
        }
    }
}