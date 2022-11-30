using System.Drawing;

public enum BSP_TILE_TYPE { EMPTY = 0, WALL, CORRIDOR }
public enum BSP_SPLIT_DIR { HORIZONTAL = 0, VERTICAL }

public class BSPTree
{
    class BSPNode
    {
        BSPNode? left, right;
        Rectangle rect;
        int[,] room;

        public Rectangle Rect { get { return rect; } }
        public int[,] Room { get { return room; } set { room = value; } }

        public BSPNode(Rectangle rect)
        {
            this.rect = rect;
            this.room = new int[rect.Height, rect.Width];
            
            for (int y = 0; y < rect.Height; ++y)
            {
                for (int x = 0; x < rect.Width; ++x)
                {
                    room[y, x] = (int)BSP_TILE_TYPE.WALL;
                }
            }

            left = null;
            right = null;
        }
    }

    private BSPNode root;                   // 트리 부모
    private int boardWidth, boardHeight;    // 보드 사이즈
    private int roomWidth, roomHeight;      // 룸 최소 사이즈

    public BSPTree(int boardWidth, int boardHeight, int roomWidth, int roomHeight)
    {
        Rectangle rect = new Rectangle(0, 0, boardWidth, boardHeight);
        this.root = new BSPNode(rect);
        this.boardWidth = boardWidth;
        this.boardHeight = boardHeight;
        this.roomWidth = roomWidth;
        this.roomHeight = roomHeight;
    }

    // 방 분할
    public void SplitRoom(BSPNode? node, int count, int x, int y)
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

        // 1. 0, 1 을 랜덤으로 나눠 수직, 수평을 분할한다.
        if (node is null) return;
        if (count is 0) return;

        int offsetX, offsetY;
        int nextX, nextY;
        Random rand = new Random();

        int dir = rand.Next(0, 2);
        if (dir is (int)BSP_SPLIT_DIR.HORIZONTAL)
        {
            offsetX = (node.Rect.Width - node.Rect.X) / 2 + rand.Next(-roomWidth, roomWidth + 1);
            // (0 ~ offsetX - 1) 까지의 left 노드
            // (offseX~ boardWidth - 1) 까지의 노드
            Rectangle leftRect = new Rectangle(0, 0, offsetX - 1, boardHeight - 1);
            BSPNode newLeftNode = new BSPNode(leftRect);

            Rectangle rightRect = new Rectangle(offsetX, 0, boardWidth - 1, boardHeight - 1);
            BSPNode newRightNode = new BSPNode(rightRect);

                

        }
        else if (dir is (int)BSP_SPLIT_DIR.VERTICAL)
        {
            offsetY = (node.Rect.Height - node.Rect.Y) / 2 + rand.Next(-roomHeight, roomHeight + 1);
        }

        // 오프셋
    }
}

public class Program
{
    public static void Main(string[] args)
    {
      



    }
}