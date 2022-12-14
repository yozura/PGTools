using System.Drawing;

namespace PGToolsTestSpace
{
    public enum BSP_SPLIT_DIR { HORIZONTAL = 0, VERTICAL }

    public class BSPNode
    {
        BSPNode? left, right;
        Rectangle rect;

        public Rectangle Rect { get { return rect; } }
        public BSPNode? Left { get { return left; } set { left = value; } }
        public BSPNode? Right { get { return right; } set { right = value; } }

        // 벽으로 전체 초기화
        public BSPNode(Rectangle rect)
        {
            this.rect = rect;

            left = null;
            right = null;
        }
    }

    public class BSPTree
    {
        private BSPNode root;                   // 트리 부모
        private int boardWidth, boardHeight;    // 보드 사이즈
        private int roomWidth, roomHeight;      // 룸 최소 사이즈
        private int[,] room;

        public BSPTree(int boardWidth, int boardHeight, int roomWidth, int roomHeight)
        {
            Rectangle rect = new Rectangle(0, 0, boardWidth, boardHeight);
            this.root = new BSPNode(rect);
            this.boardWidth = boardWidth;
            this.boardHeight = boardHeight;
            this.roomWidth = roomWidth;
            this.roomHeight = roomHeight;
            this.room = new int[rect.Height, rect.Width];

            for (int y = 0; y < rect.Height; ++y)
            {
                for (int x = 0; x < rect.Width; ++x)
                {
                    room[y, x] = (int)BSP_TILE_TYPE.WALL;
                }
            }

            SplitRoom(root, 10);
        }

        // 방 분할
        private void SplitRoom(BSPNode? node, int count)
        {
            // root 에서 부터 최소 방 사이즈보다 작아질 때까지 재귀 or 반복
            // 나누는 기준의 랜덤 값에 offset을 추가한다.
            // offset은 해당 노드의 룸 사이즈의 절반 +- 오차.

            /* BSP 로직 설계 */
            // 1-1. 보드를 수직, 수평 중 어느 방향으로 분할할지 결정한다.
            // 1-2. 1-1에서 결정한 값에 따라 분할할 x, y축을 결정한다.
            // 1-3. 그 위치를 기준으로 나눠 left right로 나눔~

            // 1번 항목을 정해진 갯수만큼 반복한다.
            // 반복할 때마다 결과물을 BSP 노드에 저장한다.

            if (count is 0) return;
            if (node is null) return;

            // Left 탈락 조건
            int offsetX, offsetY;
            offsetX = (node.Rect.Width - node.Rect.X) / 2;
            offsetY = (node.Rect.Height - node.Rect.Y) / 2;
            if (offsetX <= roomWidth || offsetY <= roomHeight) return;

            Random rand = new Random();
            int dir = rand.Next(0, 2);
            if (dir is (int)BSP_SPLIT_DIR.HORIZONTAL)
            {
                Rectangle newLeftRect = new Rectangle(node.Rect.X, node.Rect.Y, node.Rect.Width, offsetY - 1);
                BSPNode newLeftNode = new BSPNode(newLeftRect);

                Rectangle newRightRect = new Rectangle(node.Rect.X, offsetY, node.Rect.Width, node.Rect.Height);
                BSPNode newRightNode = new BSPNode(newRightRect);

                node.Left = newLeftNode;
                node.Right = newRightNode;
            }
            else if (dir is (int)BSP_SPLIT_DIR.VERTICAL)
            {
                Rectangle newLeftRect = new Rectangle(node.Rect.X, node.Rect.Y, offsetX - 1, node.Rect.Height);
                BSPNode newLeftNode = new BSPNode(newLeftRect);

                Rectangle newRightRect = new Rectangle(offsetX, node.Rect.Y, node.Rect.Width, node.Rect.Height);
                BSPNode newRightNode = new BSPNode(newRightRect);

                node.Left = newLeftNode;
                node.Right = newRightNode;
            }

            SplitRoom(node.Left, count - 1);
            SplitRoom(node.Right, count - 1);
        }

        private void BuildRoom()
        {

        }

        public void PrintNode()
        {
            if (root == null) return;

            BSPNode? newNode = root.Left;
            Console.WriteLine("left\n");
            while (newNode != null)
            {
                Console.WriteLine(newNode.Rect.ToString());
                newNode = newNode.Left;
            }

            Console.WriteLine("right\n");
            newNode = root.Right;
            while (newNode != null)
            {
                Console.WriteLine(newNode.Rect.ToString());
                newNode = newNode.Right;
            }
        }

        public int Clamp(int min, int max, int value)
        {
            if (min > value) return min;
            else if (max < value) return max;
            else return value;
        }
    }
}
