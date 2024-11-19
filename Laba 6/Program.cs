using System;

class Program
{
    // Task 1: Geometric Mean Calculator
    static double CalculateGeometricMean(double x, double y, double z)
    {
        return Math.Pow(x * y * z, 1.0 / 3.0);
    }

    static void GeometricMeanTask()
    {
        Console.Write("Введіть перше число: ");
        double x = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть друге число: ");
        double y = Convert.ToDouble(Console.ReadLine());

        Console.Write("Введіть третє число: ");
        double z = Convert.ToDouble(Console.ReadLine());

        double geometricMean = CalculateGeometricMean(x, y, z);
        Console.WriteLine($"Середнє геометричне чисел {x}, {y} та {z} дорівнює: {geometricMean}");
    }

    // Task 2: Mathematical Formula Calculation
    static double A(double b)
    {
        return Math.Pow(b, 3) + Math.Log(Math.Abs(b));
    }

    static double C(double a, double b)
    {
        return Math.Pow(a, 2) + Math.Sqrt(b);
    }

    static void MathFormulaTask()
    {
        Console.WriteLine("Введіть значення x:");
        double x = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Введіть значення b:");
        double b = Convert.ToDouble(Console.ReadLine());

        if (b <= 0)
        {
            Console.WriteLine("Помилка: b повинно бути більше за 0.");
            return;
        }

        double a = A(b);
        double c = C(a, b);
        double y = Math.Exp(x) + 5.8 * c;

        Console.WriteLine($"Результат y: {y:F4}");
    }

    // Task 3: Matrix Processor
    static void GenerateMatrix(ref int[,] matrix)
    {
        Random random = new Random();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = random.Next(-100, 101);
            }
        }
    }

    static void WriteMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j],5} ");
            }
            Console.WriteLine();
        }
    }

    static (int column, int row, int lastNegative) ProcessMatrix(int[,] matrix)
    {
        int lastNegative = int.MinValue;
        int lastNegativeRow = -1;
        int lastNegativeCol = -1;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < 0)
                {
                    lastNegative = matrix[i, j];
                    lastNegativeRow = i;
                    lastNegativeCol = j;
                }
            }
        }

        return (lastNegativeCol, lastNegativeRow, lastNegative);
    }

    static void MatrixTask()
    {
        int[,] matrix = new int[5, 8];
        GenerateMatrix(ref matrix);
        WriteMatrix(matrix);

        (int column, int row, int lastNegative) = ProcessMatrix(matrix);

        if (lastNegative != int.MinValue)
        {
            Console.WriteLine($"Останній негативний елемент: {lastNegative} знаходиться на позиції ({row}, {column})");
        }
        else
        {
            Console.WriteLine("Негативних елементів у матриці немає.");
        }
    }

    // Task 4: Recursive Digit Counter
    static int CountDigits(int number)
    {
        if (number < 10) return 1;
        return 1 + CountDigits(number / 10);
    }

    static void RecursiveDigitCountTask()
    {
        Console.WriteLine("Enter a natural number:");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number <= 0)
        {
            Console.WriteLine("Please enter a natural number greater than 0.");
        }
        else
        {
            int digitCount = CountDigits(number);
            Console.WriteLine($"The number of digits in {number} is: {digitCount}");
        }
    }

    // Main Menu
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nSelect a task to execute:");
            Console.WriteLine("1. Calculate Geometric Mean");
            Console.WriteLine("2. Calculate Mathematical Formula");
            Console.WriteLine("3. Process Matrix");
            Console.WriteLine("4. Count Digits in a Number");
            Console.WriteLine("5. Exit");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    GeometricMeanTask();
                    break;
                case "2":
                    MathFormulaTask();
                    break;
                case "3":
                    MatrixTask();
                    break;
                case "4":
                    RecursiveDigitCountTask();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
