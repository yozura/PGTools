namespace PGToolsTestSpace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PN pn = new PN();
            float[][] wn = pn.GenerateWhiteNoise(50, 50);
            
            for (int i = 0; i < 10; ++i)
            {
                for (int j = 0; j < 10; ++j)
                {
                    Console.Write(wn[i][j] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}