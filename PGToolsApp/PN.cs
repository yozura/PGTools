using System;

namespace PGToolsApp
{
    public class TagPN
    {
        public int RoomWidth { get; set; }
        public int RoomHeight { get; set; }
        public int OctaveCount { get; set; }
        public float[][] Room { get; set; }
    }

    public class PN
    {
        // 노이즈의 기본이 되는 랜덤 난수 배열 생성기
        public float[][] GenerateWhiteNoise(int width, int height)
        {
            Random random = new Random();
            float[][] noise = new float[width][];
            for (int i = 0; i < width; ++i)
                noise[i] = new float[height];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    noise[y][x] = (float)random.NextDouble() % 1;
                }
            }

            return noise;
        }

        public float[][] GenerateSmoothNoise(float[][] baseNoise, int octave)
        {
            int width = baseNoise.Length;
            int height = baseNoise[0].Length;

            float[][] smoothNoise = new float[width][];
            for (int i = 0; i < width; ++i)
                smoothNoise[i] = new float[height];

            int samplePeriod = 1 << octave; // calculates 2 ^ k
            float sampleFrequency = 1.0f / samplePeriod;

            for (int y = 0; y < height; y++)
            {
                //calculate the horizontal sampling indices
                int sample_i0 = (y / samplePeriod) * samplePeriod;
                int sample_i1 = (sample_i0 + samplePeriod) % height; //wrap around
                float horizontal_blend = (y - sample_i0) * sampleFrequency;

                for (int x = 0; x < width; x++)
                {
                    //calculate the vertical sampling indices
                    int sample_j0 = (x / samplePeriod) * samplePeriod;
                    int sample_j1 = (sample_j0 + samplePeriod) % width; //wrap around
                    float vertical_blend = (x - sample_j0) * sampleFrequency;

                    //blend the top two corners
                    float top = Interpolate(baseNoise[sample_i0][sample_j0],
                       baseNoise[sample_i1][sample_j0], horizontal_blend);

                    //blend the bottom two corners
                    float bottom = Interpolate(baseNoise[sample_i0][sample_j1],
                       baseNoise[sample_i1][sample_j1], horizontal_blend);

                    //final blend
                    smoothNoise[y][x] = Interpolate(top, bottom, vertical_blend);
                }
            }

            return smoothNoise;
        }

        public float[][] GeneratePerlinNoise(float[][] baseNoise, int octaveCount)
        {
            int width = baseNoise.Length;
            int height = baseNoise[0].Length;

            float[][][] smoothNoise = new float[octaveCount][][]; //an array of 2D arrays containing

            float persistance = 0.5f;

            //generate smooth noise
            for (int i = 0; i < octaveCount; i++)
            {
                smoothNoise[i] = GenerateSmoothNoise(baseNoise, i);
            }

            float[][] perlinNoise = new float[width][];
            for (int i = 0; i < width; ++i)
                perlinNoise[i] = new float[height];

            float amplitude = 1.0f;
            float totalAmplitude = 0.0f;

            //blend noise together
            for (int octave = octaveCount - 1; octave >= 0; octave--)
            {
                amplitude *= persistance;
                totalAmplitude += amplitude;

                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        perlinNoise[y][x] += smoothNoise[octave][y][x] * amplitude;
                    }
                }
            }

            //normalisation
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    perlinNoise[y][x] /= totalAmplitude;
                }
            }

            return perlinNoise;
        }

        private float Interpolate(float x0, float x1, float alpha)
        {
            return x0 * (1 - alpha) + alpha * x1;
        }
    }
}
