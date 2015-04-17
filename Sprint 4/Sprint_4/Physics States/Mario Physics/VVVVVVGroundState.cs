﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class VVVVVVGroundState :IMarioPhysicsState
    {
        int gravity =1;
        Mario mario;
        public Vector2 speedDecayRate = new Vector2((float)0.73, (float)0.70);
        float positionDtAdjust = 10;

        public VVVVVVGroundState(Mario mario, int gravity)
        {
            this.mario = mario;
            this.gravity *= gravity;
        }
        public void Update(Mario mario, GameTime gameTime)
        {
            mario.position += mario.velocity * ((float)gameTime.ElapsedGameTime.Milliseconds / positionDtAdjust);
            mario.velocity *= speedDecayRate;
            mario.gravity = this.gravity;
        }
        public void Run() 
        {
        }
        public void Flip() {
            SoundManager.flip.Play();
            mario.state.Flip();
            gravity = -gravity;
            mario.position.Y += 5*gravity;
            mario.physState = new VVVVVVAirState(gravity, mario);
        }
    }
}