using System.Drawing;

public enum BSP_TILE_TYPE { EMPTY = 0, WALL, CORRIDOR }
public enum BSP_SPLIT_DIR { HORIZONTAL = 0, VERTICAL }

public class BSPNode
{
    BSPNode? left, right;
    Rectangle rect;
    int[,] room;

    public Rectangle Rect { get { return rect; } }
    public int[,] Room { get { return room; } set { room = value; } }
    public BSPNode? Left { get { return left; } set { left = value; } }
    public BSPNode? Right { get { return right; } set { right = value; } }

    // 벽으로 전체 초기화
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

    public void CreateRoom()
    {
        Random rand = new Random();

        // 1. 자신의 크기보다 작은 방을 생성

    }
}

public class BSPTree
{

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

        SplitRoom(root);
    }

    // 방 분할
    private void SplitRoom(BSPNode? node)
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

        if (node is null) return;
        if (node.Rect.Width <= roomWidth) return;
        if (node.Rect.Height <= roomHeight) return;

        int offsetX, offsetY;
        Random rand = new Random();

        // 1. 0, 1 을 랜덤으로 나눠 수직, 수평을 분할한다.
        int dir = rand.Next(0, 2);
        if (dir is (int)BSP_SPLIT_DIR.HORIZONTAL)
        {
            offsetX = (node.Rect.Width - node.Rect.X) / 2 + rand.Next(-roomWidth, roomWidth + 1);
            offsetX = Clamp(roomWidth + 1, node.Rect.Width, offsetX);

            Rectangle leftRect = new Rectangle(0, 0, offsetX - 1, node.Rect.Height - 1);
            BSPNode newLeftNode = new BSPNode(leftRect);

            Rectangle rightRect = new Rectangle(offsetX, 0, node.Rect.Width - 1, node.Rect.Height - 1);
            BSPNode newRightNode = new BSPNode(rightRect);

            node.Left = newLeftNode;
            node.Right = newRightNode;
        }
        else if (dir is (int)BSP_SPLIT_DIR.VERTICAL)
        {
            offsetY = (node.Rect.Height - node.Rect.Y) / 2 + rand.Next(-roomHeight, roomHeight + 1);
            offsetY = Clamp(roomHeight + 1, node.Rect.Height, offsetY);
            
            Rectangle leftRect = new Rectangle(0, 0, node.Rect.Width - 1, offsetY - 1);
            BSPNode newLeftNode = new BSPNode(leftRect);

            Rectangle rightRect = new Rectangle(0, offsetY, node.Rect.Width - 1, node.Rect.Height - 1);
            BSPNode newRightNode = new BSPNode(rightRect);

            node.Left = newLeftNode;
            node.Right = newRightNode;
        }

        SplitRoom(node.Left);
        SplitRoom(node.Right);
    }

    public int Clamp(int min, int max, int value)
    {
        if (min > value) return min;
        else if (max < value) return max;
        else return value;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        BSPTree bsp = new BSPTree(35, 35, 6, 6);
        
    }
}