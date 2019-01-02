using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace animations
{
    internal abstract class SpriteManager
    {
        protected Texture2D texture;
        public Vector2 position = Vector2.Zero;
        protected int frameIndex = 0;

        protected Dictionary<string, AnimationClass> Animations =
            new Dictionary<string, AnimationClass>();

        private string animation;

        public string Animation
        {
            get { return animation; }
            set
            {
                animation = value;
                //frameIndex = 0;
            }
        }

        protected Vector2 origin;
        protected int height;
        protected int width;

        public SpriteManager(Texture2D texture, int frames, int animations)
        {
            this.texture = texture;

            width = texture.Width / frames;
            height = texture.Height / animations;
            origin = new Vector2(width / 2, height / 2);
        }

        public void AddAnimation(string name, int row, int frames, AnimationClass animation)
        {
            Rectangle[] rect = new Rectangle[frames];
            for (int i = 0; i < frames; i++)
            {
                rect[i] = new Rectangle(i * width, (row - 1) * height, width, height);
            }

            animation.frames = frames;
            animation.rectangles = rect;
            Animations.Add(name, animation);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Animations[Animation].rectangles[frameIndex], Animations[Animation].color, Animations[Animation].rotation,
                Animations[Animation].origin, Animations[Animation].scale, Animations[Animation].spriteEffect, 0f);
        }
    }
}