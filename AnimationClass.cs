using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace animations
{
    internal class AnimationClass
    {
        public Rectangle[] rectangles;
        public Color color = Color.White;
        public Vector2 origin;
        public float rotation;
        public float scale = 1f;
        public SpriteEffects spriteEffect;
        public int frames;
        public bool isLooping = true;

        public AnimationClass Copy()
        {
            AnimationClass ac = new AnimationClass();
            ac.rectangles = rectangles;
            ac.color = color;
            ac.origin = origin;
            ac.rotation = rotation;
            ac.scale = scale;
            ac.spriteEffect = spriteEffect;
            ac.isLooping = isLooping;
            ac.frames = frames;

            return ac;
        }
    }
}