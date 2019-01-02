using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace animations
{
    internal class SpriteAnimation : SpriteManager
    {
        private float timeElapsed;
        private float timeToUpdate = 0.05f;

        public int framePerSecond
        {
            set { timeToUpdate = (1f / value); }
        }

        public SpriteAnimation(Texture2D texture, int frames, int animations)
            : base(texture, frames, animations)
        {
        }

        public void Update(GameTime gameTime)
        {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timeElapsed > timeToUpdate)
            {
                timeElapsed -= timeToUpdate;

                if (frameIndex < Animations[Animation].frames - 1)
                    frameIndex++;
                else if (Animations[Animation].isLooping)
                    frameIndex = 0;
            }
        }
    }
}