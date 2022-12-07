using System;
using System.IO;

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
        int count;
        double ratio;
        int[,] room;

        public int[,] Room { get { return room; } }

        public CA(int roomWidth, int roomHeight, double ratio, int count)
        {
            this.roomWidth = roomWidth;
            this.roomHeight = roomHeight;
            this.ratio = ratio;
            this.count = count;

            room = new int[roomHeight, roomWidth];
        }

        public CA(TagCA tca)
        {
            this.roomWidth = tca.RoomWidth;
            this.roomHeight = tca.RoomHeight;
            this.ratio = tca.WallRatio;
            this.count = tca.RunCount;

            room = new int[roomHeight, roomWidth];
        }

        public void Generate()
        {
            Random rand = new Random();
            for (int y = 0; y < roomHeight; ++y)
            {
                for (int x = 0; x < roomWidth; ++x)
                {
                    if (rand.NextDouble() >= this.ratio) room[y, x] = (int)CA_TILE_TYPE.EMPTY;
                    else room[y, x] = (int)CA_TILE_TYPE.WALL;
                }
            }

            for (int i = 0; i < count; ++i)
            {
                for (int y = 0; y < roomHeight; ++y)
                {
                    for (int x = 0; x < roomWidth; ++x)
                    {
                        int limitCount = 0;
                        int randY, randX;

                        randY = rand.Next(1, roomHeight - 1);
                        randX = rand.Next(1, roomWidth - 1);

                        // Top Left, Top Center, Top Right
                        if (room[randY - 1, randX - 1] == (int)CA_TILE_TYPE.WALL) ++limitCount;
                        if (room[randY - 1, randX] == (int)CA_TILE_TYPE.WALL) ++limitCount;
                        if (room[randY - 1, randX + 1] == (int)CA_TILE_TYPE.WALL) ++limitCount;

                        // Middle Left, Middle Center, Middle Right
                        if (room[randY, randX - 1] == (int)CA_TILE_TYPE.WALL) ++limitCount;
                        if (room[randY, randX] == (int)CA_TILE_TYPE.WALL) ++limitCount;
                        if (room[randY, randX + 1] == (int)CA_TILE_TYPE.WALL) ++limitCount;

                        // Bottom Left, Bottom Center, Bottom Right
                        if (room[randY + 1, randX - 1] == (int)CA_TILE_TYPE.WALL) ++limitCount;
                        if (room[randY + 1, randX] == (int)CA_TILE_TYPE.WALL) ++limitCount;
                        if (room[randY + 1, randX + 1] == (int)CA_TILE_TYPE.WALL) ++limitCount;

                        // 만약 5칸 이상이 벽일 경우 자기 자신도 벽으로 치환, 아닐 경우 비우기
                        if (limitCount >= 5) room[randY, randX] = (int)CA_TILE_TYPE.WALL;
                        else room[randY, randX] = (int)CA_TILE_TYPE.EMPTY;
                    }
                }
                LogRoom();
            }
        }

        private void LogRoom()
        {
            using (StreamWriter sw = new StreamWriter("CALog.txt", true))
            {
                sw.WriteLine();
                for (int y = 0; y < roomHeight; ++y)
                {
                    for (int x = 0; x < roomWidth; ++x)
                    {
                        switch (room[y, x])
                        {
                            case (int)CA_TILE_TYPE.EMPTY:
                                sw.Write("□");
                                break;
                            case (int)CA_TILE_TYPE.WALL:
                                sw.Write("■");
                                break;
                        }
                    }
                    sw.WriteLine();
                }
                sw.WriteLine();
            }
        }
    }
}