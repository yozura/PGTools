using System;

namespace PGToolsApp
{
    public enum CA_TILE_TYPE { EMPTY = 0, WALL };

    public struct CAInformation
    {
        public int RoomWidth { get; set; }
        public int RoomHeight { get; set; }
        public int RunCount { get; set; }
        public double WallRatio { get; set; }

        public CAInformation(int roomWidth, int roomHeight, int runCount, double wallRatio)
        {
            RoomWidth = roomWidth;
            RoomHeight = roomHeight;
            RunCount = runCount;
            WallRatio = wallRatio;
        }
    }

    public class CellularAutomata : IProceduralGenerator
    { 
        public CAInformation Info { get; set; }
        public int[,] Room { get; set; }
        public Random Rand { get; set; }

        public CellularAutomata(int roomWidth, int roomHeight, int runCount, double wallRatio)
        {
            Info = new CAInformation(roomWidth, roomHeight, runCount, wallRatio);

            Room = new int[Info.RoomHeight, Info.RoomWidth];
            Rand = new Random();
        }

        public CellularAutomata(CAInformation info)
        {
            Info = info;

            Room = new int[Info.RoomHeight, Info.RoomWidth];
            Rand = new Random();
        }

        public void Generate()
        {
            Array.Clear(Room, 0, Room.Length);

            int roomHeight = Info.RoomHeight;
            int roomWidth = Info.RoomWidth;
            int runCount = Info.RunCount;
            double wallRatio = Info.WallRatio;

            for (int y = 0; y < roomHeight; ++y)
            {
                for (int x = 0; x < roomWidth; ++x)
                {
                    if (y == 0 || y >= roomHeight - 1 || x == 0 || x >= roomWidth - 1)
                    {
                        Room[y, x] = (int)CA_TILE_TYPE.WALL;
                        continue;
                    }

                    if (Rand.NextDouble() >= wallRatio) Room[y, x] = (int)CA_TILE_TYPE.EMPTY;
                    else Room[y, x] = (int)CA_TILE_TYPE.WALL;
                }
            }

            // 전체 랜덤
            int limitCount;
            int randY, randX;
            for (int i = 0; i < runCount; ++i)
            {
                for (int y = 0; y < roomHeight; ++y)
                {
                    for (int x = 0; x < roomWidth; ++x)
                    {
                        limitCount = 0;
                        randY = Rand.Next(1, roomHeight - 1);
                        randX = Rand.Next(1, roomWidth - 1);
                        SelectCoordinate(randX, randY, ref limitCount);
                    }
                }
            }
        }

        private void SelectCoordinate(int x, int y, ref int limitCount)
        {
            // Top Left, Top Center, Top Right
            if (Room[y - 1, x - 1] == (int)CA_TILE_TYPE.WALL) ++limitCount;
            if (Room[y - 1, x] == (int)CA_TILE_TYPE.WALL) ++limitCount;
            if (Room[y - 1, x + 1] == (int)CA_TILE_TYPE.WALL) ++limitCount;

            // Middle Left, Middle Center, Middle Right
            if (Room[y, x - 1] == (int)CA_TILE_TYPE.WALL) ++limitCount;
            if (Room[y, x] == (int)CA_TILE_TYPE.WALL) ++limitCount;
            if (Room[y, x + 1] == (int)CA_TILE_TYPE.WALL) ++limitCount;

            // Bottom Left, Bottom Center, Bottom Right
            if (Room[y + 1, x - 1] == (int)CA_TILE_TYPE.WALL) ++limitCount;
            if (Room[y + 1, x] == (int)CA_TILE_TYPE.WALL) ++limitCount;
            if (Room[y + 1, x + 1] == (int)CA_TILE_TYPE.WALL) ++limitCount;

            // 만약 5칸 이상이 벽일 경우 자기 자신도 벽으로 치환, 아닐 경우 비우기
            if (limitCount >= 5) Room[y, x] = (int)CA_TILE_TYPE.WALL;
            else Room[y, x] = (int)CA_TILE_TYPE.EMPTY;
        }
    }
}