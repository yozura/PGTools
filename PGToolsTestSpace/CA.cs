using System.Diagnostics;

namespace PGToolsTestSpace
{
    public enum CA_TILE_TYPE { EMPTY = 0, WALL };

    public class CA
    {
        int roomWidth, roomHeight;
        int count;
        float ratio;
        int[,] room;

        public CA(int roomWidth, int roomHeight, float ratio, int count)
        {
            Debug.Assert(roomWidth > 0);
            Debug.Assert(roomHeight > 0);
            Debug.Assert(ratio > 0.0f);
            Debug.Assert(count > 0);

            this.roomWidth = roomWidth;
            this.roomHeight = roomHeight;
            this.ratio = ratio;
            this.count = count;

            room = new int[roomHeight, roomWidth];
            for (int y = 0; y < roomHeight; ++y)
            {
                for (int x = 0; x < roomWidth; ++x)
                {
                    //if (y == 0 || y >= roomHeight - 1 || x == 0 || x >= roomWidth - 1)
                    //{
                    //    room[y, x] = (int)CA_TILE_TYPE.WALL;
                    //    continue;
                    //}

                    Random rand = new Random();
                    if (rand.NextSingle() >= this.ratio) room[y, x] = (int)CA_TILE_TYPE.EMPTY;
                    else room[y, x] = (int)CA_TILE_TYPE.WALL;
                }
            }

            ChangeRoomTile();
        }

        private void ChangeRoomTile()
        {
            for (int i = 0; i < count; ++i)
            {
                for (int y = 0; y < roomHeight; ++y)
                {
                    for (int x = 0; x < roomWidth; ++x)
                    {
                        Random rand = new Random();
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
                Console.WriteLine($"{i + 1}번째...");
                PrintRoom();
                Console.WriteLine();
            }
        }

        public void PrintRoom()
        {
            for (int y = 0; y < roomHeight; ++y)
            {
                for (int x = 0; x < roomWidth; ++x)
                {
                    switch (room[y, x])
                    {
                        case (int)CA_TILE_TYPE.EMPTY:   Console.Write("□");     break;
                        case (int)CA_TILE_TYPE.WALL:    Console.Write("■");     break;
                    }
                }
                Console.WriteLine();
            }
        }
    }
}