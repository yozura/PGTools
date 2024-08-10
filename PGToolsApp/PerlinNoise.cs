using System;
using System.Diagnostics;

namespace PGToolsApp
{
    public struct PNInformation
    {
        public int RoomWidth { get; set; }
        public int RoomHeight { get; set; }
        public int OctaveCount { get; set; }

        public PNInformation(int roomWidth, int roomHeight, int octaveCount)
        {
            RoomWidth = roomWidth;
            RoomHeight = roomHeight;
            OctaveCount = octaveCount;
        }
    }

    public class PerlinNoise : IProceduralGenerator
    {
        public PNInformation Info { get; set; }
        public int[,] Room { get; set; }
        public double[,] Noise { get; set; }
        public Random Rand { get; set; }

        public PerlinNoise(int roomWidth, int roomHeight, int octaveCount)
        {
            Info = new PNInformation(roomWidth, roomHeight, octaveCount);

            Room = new int[Info.RoomHeight, Info.RoomWidth];
            Noise = new double[Info.RoomHeight, Info.RoomWidth];
            Rand = new Random();
        }

        public PerlinNoise(PNInformation info)
        {
            Info = info;

            Room = new int[Info.RoomHeight, Info.RoomWidth];
            Noise = new double[Info.RoomHeight, Info.RoomWidth];
            Rand = new Random();
        } 

        public void Generate()
        {
            GeneratePerlinNoise();
            ConvertNoiseToAlpha();
        }

        // 노이즈의 기본이 되는 랜덤 난수 배열 생성기
        private void GenerateBaseNoise()
        {
            for (int y = 0; y < Info.RoomHeight; y++)
            {
                for (int x = 0; x < Info.RoomWidth; x++)
                {
                    Noise[y, x] = Rand.NextDouble();
                }
            }
        }

        // 이전에 생성한 노이즈를 보간해서 리턴하는 함수
        private void GenerateSmoothNoise(double[,,] smoothNoise, int octave)
        {
            // 2의 octave 곱을 저장, int형이기 때문에 32제곱을 넘을 수 없음.
            // 즉 옥타브의 값마다 다양한 주파수의 샘플이 만들어짐.
            int samplePeriod = 1 << octave;
            float sampleFrequency = 1.0f / samplePeriod;

            for (int y = 0; y < Info.RoomHeight; y++)
            {
                int sample_i0 = (y / samplePeriod) * samplePeriod;
                int sample_i1 = (sample_i0 + samplePeriod) % Info.RoomHeight;
                double horizontalBlend = (y - sample_i0) * sampleFrequency;

                for (int x = 0; x < Info.RoomWidth; x++)
                {
                    int sample_j0 = (x / samplePeriod) * samplePeriod;
                    int sample_j1 = (sample_j0 + samplePeriod) % Info.RoomWidth;
                    double verticalBlend = (x - sample_j0) * sampleFrequency;

                    double top = CosInterpolate(Noise[sample_i0, sample_j0],
                                                Noise[sample_i1, sample_j0],
                                                horizontalBlend);

                    double bottom = CosInterpolate(Noise[sample_i0, sample_j1],
                                                   Noise[sample_i1, sample_j1],
                                                   horizontalBlend);

                    smoothNoise[octave, y, x] = CosInterpolate(top, bottom, verticalBlend);
                }
            }
        }

        public void GeneratePerlinNoise()
        {
            // 기본 노이즈 생성
            GenerateBaseNoise();

            // 각 노이즈를 보간한 SmoothNoise 생성
            double[,,] smoothNoise = new double[Info.OctaveCount, Info.RoomHeight, Info.RoomWidth];
            for (int i = 0; i < Info.OctaveCount; i++)
                GenerateSmoothNoise(smoothNoise, i);

            // 진폭 결정
            double amplitude = 1.0f;
            // 전체 진폭 누적
            double totalAmplitude = 0.0f;
            // 지속성 여부를 결정
            double persistance = 0.5f;
            // 임시 노이즈 버퍼 생성
            double[,] perlinNoise = new double[Info.RoomHeight, Info.RoomWidth];

            // 옥타브 카운트 만큼 스무스 노이즈를 펄린 노이즈에 누적시킵니다.
            for (int octave = Info.OctaveCount - 1; octave >= 0; --octave)
            {
                amplitude *= persistance;
                totalAmplitude += amplitude;

                for (int y = 0; y < Info.RoomHeight; y++)
                {
                    for (int x = 0; x < Info.RoomWidth; x++)
                    {
                        perlinNoise[y, x] += smoothNoise[octave, y, x] * amplitude;
                    }
                }
            }

            // 전체 진폭으로 펄린 노이즈를 정규화시켜 최종 결과물을 도출합니다.
            for (int y = 0; y < Info.RoomHeight; y++)
            {
                for (int x = 0; x < Info.RoomWidth; x++)
                {
                    perlinNoise[y, x] /= totalAmplitude;
                    perlinNoise[y, x] = Math.Max(0, Math.Min(1, perlinNoise[y, x]));
                }
            }

            Noise = perlinNoise;
        }

        private void ConvertNoiseToAlpha()
        {
            for (int y = 0; y < Info.RoomHeight; ++y)
            {
                for (int x = 0; x < Info.RoomWidth; ++x)
                {
                    int alpha = (int)(Noise[y, x] * 255);
                    Room[y, x] = alpha;
                }
            }
        }

        // 선형 보간법입니다.
        // v0에서 v1까지 a의 비율만큼 보간합니다.
        private double LinearInterpolate(double v0, double v1, double a)
        {
            return v0 * (1.0f - a) + a * v1;
        }

        // 코사인 보간법입니다.
        // v0에서 v1까지 t의 비율만큼 보간합니다.
        private double CosInterpolate(double v0, double v1, double a)
        {
            double angle = a * Math.PI;
            double t = (1.0f - Math.Cos(angle)) * 0.5f;
            return v0 * (1.0f - t) + v1 * t;
        }
    }
}
