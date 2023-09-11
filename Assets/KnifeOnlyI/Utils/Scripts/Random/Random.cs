using UnityEngine;

namespace KnifeOnlyI.Utils.Random
{
    public sealed class Random : System.Random
    {
        private int _seed;

        public Random(int seed)
        {
            _seed = seed;
        }

        private int NextSeed()
        {
            _seed = _seed * 0x08088405 + 1;

            return _seed;
        }

        public new int Next(int minValue, int maxValue)
        {
            return Mathf.Clamp(Mathf.Abs(minValue + NextSeed() % (maxValue - minValue)), minValue, maxValue - 1);
        }
    }
}