namespace Matrix.UI
{
    internal class MatrixUi

    {
        public void Run()
        {
            Console.WriteLine("Welcome to the Matrix App");

            int height, weight = 0;
            bool isValidInput;

            do
            {
                Console.WriteLine("Enter the number of rows: ");
                isValidInput = int.TryParse(Console.ReadLine(), out height);

                if (!isValidInput || height <= 0)
                {
                    Console.WriteLine("Invalid input! Please enter a positive amount.");
                    continue;
                }

                Console.Write("Enter the number of colums: ");
                isValidInput = int.TryParse(Console.ReadLine(), out weight);

                if (!isValidInput || weight <= 0)
                {
                    Console.WriteLine("Invalid input! Please enter the positive amount.");
                }
            } while (!isValidInput || weight <= 0);

            var matrix = new BL.Matrix(height, weight);
            matrix.FillWithRandomNumbers();
            matrix.CalculateTrace();
            
            Console.WriteLine("Filled Matrix:");
            matrix.PrintMatrix();
            
            Console.WriteLine("\nTrace of the Matrix: " + matrix.Trace);

            Console.Write("Snail Matrix:\n");
            int[] snailMatrix = matrix.GetSnail();
            foreach (var element in snailMatrix)
            {
                Console.Write(element + " ");
            }
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
     
        public static void Main(string[] args)
        {
            MatrixUi matrixUi = new MatrixUi();
            matrixUi.Run();
        }
    }
}