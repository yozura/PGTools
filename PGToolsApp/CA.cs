using System;

namespace PGToolsApp
{
    public enum CA_TILE_TYPE { EMPTY = 0, WALL };

    public class TagCA
    {
        public int RoomWidth { get; set; }
        public int RoomHeight { get; set; }
        public int RunCount { get; set; }
        public double WallRatio { get; set; }
    }

    public class CA
    {
        int roomWidth, roomHeight;
        int runCount;
        double wallRatio;
        int[,] room;

        public int[,] Room { get { return room; } }

        public CA(int roomWidth, int roomHeight, double ratio, int count)
        {
            this.roomWidth = roomWidth;
            this.roomHeight = roomHeight;
            this.wallRatio = ratio;
            this.runCount = count;

            room = new int[roomHeight, roomWidth];
        }

        public CA(TagCA tca)
        {
            this.roomWidth = tca.RoomWidth;
            this.roomHeight = tca.RoomHeight;
            this.wallRatio = tca.WallRatio;
            this.runCount = tca.RunCount;

            room = new int[roomHeight, roomWidth];
        }

        public void Generate()
        {
            Random rand = new Random();
            for (int y = 0; y < roomHeight; ++y)
            {
                for (int x = 0; x < roomWidth; ++x)
                {
                    if (y == 0 || y >= roomHeight - 1 || x == 0 || x >= roomWidth - 1)
                    {
                        room[y, x] = (int)CA_TILE_TYPE.WALL;
                        continue;
                    }

                    if (rand.NextDouble() >= this.wallRatio) room[y, x] = (int)CA_TILE_TYPE.EMPTY;
                    else room[y, x] = (int)CA_TILE_TYPE.WALL;
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
                        randY = rand.Next(1, roomHeight - 1);
                        randX = rand.Next(1, roomWidth - 1);
                        SelectCoordinate(randX, randY, ref limitCount);
                    }
                }
            }
        }

        private void SelectCoordinate(int x, int y, ref int limitCount)
        {
            // Top Left, Top Center, Top Right
            if (room[y - 1, x - 1] == (int)CA_TILE_TYPE.WALL) ++limitCount;
            if (room[y - 1, x] == (int)CA_TILE_TYPE.WALL) ++limitCount;
            if (room[y - 1, x + 1] == (int)CA_TILE_TYPE.WALL) ++limitCount;

            // Middle Left, Middle Center, Middle Right
            if (room[y, x - 1] == (int)CA_TILE_TYPE.WALL) ++limitCount;
            if (room[y, x] == (int)CA_TILE_TYPE.WALL) ++limitCount;
            if (room[y, x + 1] == (int)CA_TILE_TYPE.WALL) ++limitCount;

            // Bottom Left, Bottom Center, Bottom Right
            if (room[y + 1, x - 1] == (int)CA_TILE_TYPE.WALL) ++limitCount;
            if (room[y + 1, x] == (int)CA_TILE_TYPE.WALL) ++limitCount;
            if (room[y + 1, x + 1] == (int)CA_TILE_TYPE.WALL) ++limitCount;

            // 만약 5칸 이상이 벽일 경우 자기 자신도 벽으로 치환, 아닐 경우 비우기
            if (limitCount >= 5) room[y, x] = (int)CA_TILE_TYPE.WALL;
            else room[y, x] = (int)CA_TILE_TYPE.EMPTY;
        }
    }
}