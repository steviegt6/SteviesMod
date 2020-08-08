using Microsoft.Xna.Framework;

namespace SteviesMod.Utilities
{
    //AnimatedColor code by pbone (pbone#4569).
    public class AnimatedColor
    {
        private static float _animatedColorCounter = 0f;
        private static bool _animatedColorLoop = false;

        private Color _color1;
        private Color _color2;

        public AnimatedColor(Color c1, Color c2)
        {
            _color1 = c1;
            _color2 = c2;
        }

        public static void Update()
        {
            _animatedColorCounter += !_animatedColorLoop ? 0.05f : -0.05f;
            _animatedColorCounter = MathHelper.Clamp(_animatedColorCounter, 0, 1);
            if (_animatedColorCounter >= 1)
            {
                _animatedColorLoop = true;
            }

            if (_animatedColorCounter <= 0)
            {
                _animatedColorLoop = false;
            }
        }

        public Color GetColor() => Color.Lerp(_color1, _color2, _animatedColorCounter);
    }
}