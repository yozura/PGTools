namespace PGToolsTestSpace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BSP2 bsp = new BSP2(50, 50);
            bsp.GenerateRoom(5, 50, 50);
            bsp.PrintRoom();

        }
    }
}