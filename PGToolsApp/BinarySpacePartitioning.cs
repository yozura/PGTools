﻿using System;

namespace PGToolsApp
{
    public enum BSP_TILE_TYPE { EMPTY = 0, WALL, CORRIDOR }

    public struct BSPInformation
    {
        public int RoomWidth { get; set; }
        public int RoomHeight { get; set; }
        public int Depth { get; set; }

        public BSPInformation(int roomSize, int depth)
        {
            RoomWidth = roomSize;
            RoomHeight = roomSize;
            Depth = depth;
        }
    }

    public class BinarySpacePartitioning : IProceduralGenerator
    {
        public BSPInformation Info { get; set; }
        public int[,] Room { get; set; }
        public Random Rand { get; set; }

        class RoomLocation
        {
            public int x1, y1;
            public int x2, y2;
            public int x3, y3;
            public int x4, y4;

            public RoomLocation(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
            {
                this.x1 = x1;
                this.y1 = y1;
                this.x2 = x2;
                this.y2 = y2;
                this.x3 = x3;
                this.y3 = y3;
                this.x4 = x4;
                this.y4 = y4;
            }
        }

        public BinarySpacePartitioning(int roomSize, int depth)
        {
            Info = new BSPInformation(roomSize, depth);

            Room = new int[Info.RoomWidth, Info.RoomHeight];
            Rand = new Random();
        }

        public BinarySpacePartitioning(BSPInformation info)
        {
            Info = info;

            Room = new int[Info.RoomHeight, Info.RoomWidth];
            Rand = new Random();
        }

        public void Generate()
        {
            Array.Clear(Room, 0, Room.Length);
            DivideRoom(Info.Depth, 0, 0, Info.RoomWidth, Info.RoomHeight);
        }
        
        RoomLocation DivideRoom(int depth, int x1, int y1, int x2, int y2)
        {
            int xLen = x2 - x1; // 너비
            int yLen = y2 - y1; // 높이

            // 재귀의 깊이가 도달한 경우, 방의 크기가 10x10보다 작을 경우
            if (depth == 0 || (xLen <= 10 || yLen <= 10))
            {
                for (int y = y1 + 2; y < y2 - 2; ++y)
                {
                    for (int x = x1 + 2; x < x2 - 2; ++x)
                    {
                        Room[y, x] = (int)BSP_TILE_TYPE.WALL;
                    }
                }

                return new RoomLocation(x1 + 2, y1 + 2, x2 - 3, y2 - 3,
                                        x1 + 2, y1 + 2, x2 - 3, y2 - 3);
            }

            RoomLocation leftRoom, rightRoom;
            // 세로 분할
            if (xLen / yLen > 1 ||
               (xLen / yLen <= 1 && Rand.Next() % 2 == 0))
            {
                // 분할할 X좌표를 지정한다.
                int divideX = xLen * (Rand.Next() % 3 + 4) / 10;

                // 지정한 X좌표를 기준으로 좌우로 분할한다.
                leftRoom = DivideRoom(depth - 1, x1, y1, x1 + divideX, y2);
                rightRoom = DivideRoom(depth - 1, x1 + divideX, y1, x2, y2);

                // 분할 한 뒤 정해진 방을 합친다.
                Room[(leftRoom.y3 + leftRoom.y4) / 2, leftRoom.x4 + 1] = (int)BSP_TILE_TYPE.CORRIDOR; ;
                Room[(leftRoom.y3 + leftRoom.y4) / 2, leftRoom.x4 + 2] = (int)BSP_TILE_TYPE.CORRIDOR; ;
                Room[(rightRoom.y1 + rightRoom.y2) / 2, rightRoom.x1 - 1] = (int)BSP_TILE_TYPE.CORRIDOR; ;
                Room[(rightRoom.y1 + rightRoom.y2) / 2, rightRoom.x1 - 2] = (int)BSP_TILE_TYPE.CORRIDOR; ;
                int yMin = Math.Min((leftRoom.y3 + leftRoom.y4) / 2, (rightRoom.y1 + rightRoom.y2) / 2);
                int yMax = Math.Max((leftRoom.y3 + leftRoom.y4) / 2, (rightRoom.y1 + rightRoom.y2) / 2);
                for (int y = yMin; y <= yMax; ++y)
                    Room[y, rightRoom.x1 - 2] = (int)BSP_TILE_TYPE.CORRIDOR;
            }
            // 가로 분할
            else
            {
                // 분할할 Y좌표를 지정한다.
                int divideY = yLen * (Rand.Next() % 3 + 4) / 10;

                // 지정한 Y좌표를 기준으로 좌우로 분할한다.
                leftRoom = DivideRoom(depth - 1, x1, y1, x2, y1 + divideY);
                rightRoom = DivideRoom(depth - 1, x1, y1 + divideY, x2, y2);

                // 분할 한 뒤 정해진 방을 합친다.
                Room[leftRoom.y4 + 1, (leftRoom.x3 + leftRoom.x4) / 2] = (int)BSP_TILE_TYPE.CORRIDOR;
                Room[leftRoom.y4 + 2, (leftRoom.x3 + leftRoom.x4) / 2] = (int)BSP_TILE_TYPE.CORRIDOR;
                Room[rightRoom.y1 - 1, (rightRoom.x1 + rightRoom.x2) / 2] = (int)BSP_TILE_TYPE.CORRIDOR;
                Room[rightRoom.y1 - 2, (rightRoom.x1 + rightRoom.x2) / 2] = (int)BSP_TILE_TYPE.CORRIDOR;
                int xMin = Math.Min((leftRoom.x3 + leftRoom.x4) / 2, (rightRoom.x1 + rightRoom.x2) / 2);
                int xMax = Math.Max((leftRoom.x3 + leftRoom.x4) / 2, (rightRoom.x1 + rightRoom.x2) / 2);
                for (int x = xMin; x <= xMax; ++x)
                    Room[rightRoom.y1 - 2, x] = (int)BSP_TILE_TYPE.CORRIDOR;
            }

            return new RoomLocation(
                    leftRoom.x1, leftRoom.y1,
                    leftRoom.x2, leftRoom.x2,
                    rightRoom.x3, rightRoom.y3,
                    rightRoom.x4, rightRoom.y4
                );
        }

        public void PrintRoom()
        {
            for (int y = 0; y < Info.RoomHeight; ++y)
            {
                for (int x = 0; x < Info.RoomWidth; ++x)
                {
                    if (Room[y, x] != 0) Console.Write(Room[y, x]);
                    else Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

    }
}
