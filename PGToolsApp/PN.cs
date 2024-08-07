using System;

namespace PGToolsApp
{
    public struct PNInformation
    {
        public int RoomWidth { get; set; }
        public int RoomHeight { get; set; }
        public int OctaveCount { get; set; }
    }

    public class PerlinNoise : IProceduralGenerator
    {
        public PNInformation Info { get; set; }
        public float[][] Room { get; set; }
        public Random Rand { get; set; }

        public PerlinNoise(PNInformation info)
        {
            Info = info;

            Rand = new Random();
        } 

        public void Generate()
        {

        }

        // 노이즈의 기본이 되는 랜덤 난수 배열 생성기
        private float[][] GenerateWhiteNoise(int width, int height)
        {
            float[][] noise = new float[height][];
            for (int i = 0; i < height; ++i)
                noise[i] = new float[width];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    noise[y][x] = (float)Rand.NextDouble() % 1;
                }
            }

            return noise;
        }

        // 이전에 생성한 노이즈를 보간해서 리턴하는 함수
        public float[][] GenerateSmoothNoise(float[][] baseNoise, int octave)
        {
            int height = baseNoise.Length;
            int width = baseNoise[0].Length;

            float[][] smoothNoise = new float[height][];
            for (int i = 0; i < height; ++i)
                smoothNoise[i] = new float[width];

            // 2의 octave 곱을 저장, int형이기 때문에 32제곱을 넘을 수 없음.
            // 즉 옥타브의 값마다 다양한 주파수의 샘플이 만들어짐.
            int samplePeriod = 1 << octave;
            float sampleFrequency = 1.0f / samplePeriod;

            for (int y = 0; y < height; y++)
            {
                int sample_i0 = (y / samplePeriod) * samplePeriod;
                int sample_i1 = (sample_i0 + samplePeriod) % height;
                float horizontal_blend = (y - sample_i0) * sampleFrequency;

                for (int x = 0; x < width; x++)
                {
                    int sample_j0 = (x / samplePeriod) * samplePeriod;
                    int sample_j1 = (sample_j0 + samplePeriod) % width;
                    float vertical_blend = (x - sample_j0) * sampleFrequency;

                    float top = CosInterpolate(baseNoise[sample_i0][sample_j0],
                       baseNoise[sample_i1][sample_j0], horizontal_blend);

                    float bottom = CosInterpolate(baseNoise[sample_i0][sample_j1],
                       baseNoise[sample_i1][sample_j1], horizontal_blend);

                    smoothNoise[y][x] = CosInterpolate(top, bottom, vertical_blend);
                }
            }

            return smoothNoise;
        }

        public float[][] GeneratePerlinNoise(float[][] baseNoise, int octaveCount)
        {
            int width = baseNoise.Length;
            int height = baseNoise[0].Length;

            float[][][] smoothNoise = new float[octaveCount][][];

            // 지속성 여부를 결정
            float persistance = 0.5f;

            // 스무스 노이즈를 생성함.
            for (int i = 0; i < octaveCount; i++)
                smoothNoise[i] = GenerateSmoothNoise(baseNoise, i);

            float[][] perlinNoise = new float[width][];
            for (int i = 0; i < width; ++i)
                perlinNoise[i] = new float[height];

            // 진폭 결정
            float amplitude = 1.0f;
            // 전체 진폭 결정
            float totalAmplitude = 0.0f;

            // 옥타브 카운트 만큼 스무스 노이즈를 펄린 노이즈에 누적시킵니다.
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

            // 전체 진폭으로 펄린 노이즈를 정규화시켜 최종 결과물을 도출합니다.
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    perlinNoise[y][x] /= totalAmplitude;
                }
            }

            return perlinNoise;
        }

        // 선형 보간법입니다.
        // v0에서 v1까지 a의 비율만큼 보간합니다.
        private float LinearInterpolate(float v0, float v1, float a)
        {
            return v0 * (1.0f - a) + a * v1;
        }

        // 코사인 보간법입니다.
        // a의 비율을 파이로 곱한뒤 각도를 구하고
        // 그 각도의 코사인값을 구한 뒤 1에서 코사인값을 뺀 뒤 0.5f를 곱합니다.
        // v0에서 v1까지 t의 비율만큼 보간합니다.
        private float CosInterpolate(float v0, float v1, float a)
        {
            float angle = (float)(a * Math.PI);
            float t = (float)((1.0f - Math.Cos(angle)) * 0.5f);
            return v0 * (1.0f - t) + v1 * t;
        }
    }
}
