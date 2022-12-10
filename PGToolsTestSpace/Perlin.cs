
namespace PGToolsTestSpace
{
    public class Perlin
    {
        public class TagPerlin
        {
            public int RoomWidth { get; set; }
            public int RoomHeight { get; set; }
        }

        public static float Noise1(int x)
        {
            x = (x << 13) ^ x;
            return (float)(1.0 - ((x * (x * x * 15731 + 789221) + 1376312589 & 0x7fffffff) / 1073741824.0));
        }

        public static float SmoothNoise1(float x)
        {
            return Noise1((int)x) / 2 + Noise1((int)(x - 1)) / 4 + Noise1((int)(x + 1)) / 4;
        }

        public static float InterpolatedNoise1(float x)
        {
            int x1 = (int)x;
            float xp = (x - x1);

            float v1 = SmoothNoise1(x1);
            float v2 = SmoothNoise1(x1 + 1);

            return CosInterpolate(v1, v2, xp);
        }

        public static float CosInterpolate(float a, float b, float x)
        {
            float y = x * MathF.PI;
            y = (1.0f - MathF.Cos(y)) * 0.5f;
            return a * (1.0f - y) + b * y;
        }

        public static float PerlinNoise(float x)
        {
            int floor = (int)MathF.Floor(x);
            float t = x - floor;

            return CosInterpolate(SmoothNoise1(floor), SmoothNoise1(floor + 1), t);
        }
    }
}
