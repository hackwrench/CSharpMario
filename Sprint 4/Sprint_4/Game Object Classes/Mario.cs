﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    public class Mario
    {
        public IMarioState state;
        public bool marioIsStar, marioIsBig = false, marioIsFire = false;
        public IMarioPhysicsState physState;
        public bool isBig = false, isFire = false;
        private int starTimer;
        public Vector2 position;
        public Vector2 velocity;
        public Vector2 maxVelocity = new Vector2((float)2, (float)16);
        public Vector2 minVelocity = new Vector2((float) -2, (float)-5);
        Game1 game;
        public int marioHeight = 0;


        public Mario(Game1 game, Vector2 position)
        {
            state = new RightIdleSmallMS(game);
            physState = new GroundState(this, game);
            marioIsStar = false;
            starTimer = 1000;
            this.game = game;
            this.position.X = position.X;
            this.position.Y = position.Y;
        }

        public void TakeDamage(Enemy enemy)
        {
            if (!enemy.isDead)
            {
                state.TakeDamage();
            }
            marioIsBig = false;
        }
        public void Up()
        {
            //mario needs to have an initial velocity, which slows as he gets higher. Max height is based on the time
            //it takes for his velocity to reach 0.
            if (velocity.Y > minVelocity.Y && physState.GetType() != (new FallingState(game)).GetType())
            {
                physState = new JumpingState(game);
                velocity.Y -= (float)2;
            }
            state.Up();
        }

        public void Down()
        {
            state.Down();
            //velocity.Y++;
        }

        public void GoLeft()
        {
            state.GoLeft();
            if (velocity.X > minVelocity.X)
            {
                velocity.X -= (float).3;
            }
        }

        public void GoRight()
        {
            state.GoRight();
            if (velocity.X < maxVelocity.X)
            {
                velocity.X += (float).3;
            }
        }

        public void Idle()
        {
            state.Idle();
        }
        public void Land()
        {
            state.Land();
        }

        public void MakeBigMario()
        {
            if (!marioIsFire)
            {
                state.MakeBigMario();
            }
            marioIsBig = true;
            marioIsFire = false;
        }

        public void MakeSmallMario()
        {
            state.MakeSmallMario();
            marioIsBig = false;
            marioIsFire = false;
        }

        public void MakeFireMario()
        {
            state.MakeFireMario();
            marioIsBig = true;
            marioIsFire = true;
        }

        public void MakeDeadMario()
        {
            state.MakeDeadMario();
            marioIsBig = false;
            marioIsFire = false;
        }

        public void Update(GameTime gameTime)
        {
            if (starTimer != 0 & marioIsStar)
            {
                starTimer--;
            }
            if (starTimer == 0)
            {
                marioIsStar = false;
                starTimer = 1000;
                game.level.soundManager.PlaySong(SoundManager.songs.athletic);
            }
            state.Update(gameTime);
            physState.Update(this, gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (marioIsStar & starTimer % 5 != 0)
            {
                state.Draw(spriteBatch, position);
            }
            if (!marioIsStar)
                {
                    state.Draw(spriteBatch, position);
                }
                    state.Draw(spriteBatch, position);
            }
        }
    }
