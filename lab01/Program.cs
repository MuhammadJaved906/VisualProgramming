
/*using System;

class Program
{
    static void Main()
    {
        int[,] twoDArray = new int[3, 4]
        {
            { 1, 2, 3, 4 },
            { 5, 6, 7, 8 },
            { 9, 10, 11, 12 }
        };

        Print2DArray(twoDArray);
    }

    static void Print2DArray(int[,] array)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write($"{array[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}

//Q2
/*
using System;

class Program
{
    static void Main()
    {
        string[] strings = { "hello", "and", "welcome ", "to", "this "demo! };
        string mergedString = Merger(strings);
        Console.WriteLine(mergedString);
    }

    static string Merger(string[] strings)
    {
        string merged = "";
        foreach (string str in strings)
        {
            merged += str;
        }
        return merged;
    }
}
*/

//Q3
/*
using System;

class Program
{
    static void Main()
    {
        string text = "This is a sample text with various words.";
        string[] extractedWords = ExtractWords(text);
        foreach (string word in extractedWords)
        {
            Console.WriteLine(word);
        }
    }

    static string[] ExtractWords(string text)
    {
        string[] words = text.Split();
        List<string> extracted = new List<string>();
        foreach (string word in words)
        {
            if (word.Length >= 4 && word.Length <= 5 && ContainsVowel(word))
            {
                extracted.Add(word);
            }
        }
        return extracted.ToArray();
    }

    static bool ContainsVowel(string word)
    {
        foreach (char c in word)
        {
            if (char.ToUpper(c) == 'A' || char.ToUpper(c) == 'E' || char.ToUpper(c) == 'I' || char.ToUpper(c) == 'O' || char.ToUpper(c) == 'U')
            {
                return true;
            }
        }
        return false;
    }
}
*/


//Q4
/*
using System;

class Program
{
    static void Main()
    {
        int[] ratings = { 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5, 1 };
        SummarizeRatings(ratings);
    }

    static void SummarizeRatings(int[] ratings)
    {
        int[] frequency = new int[5];
        foreach (int rating in ratings)
        {
            frequency[rating - 1]++;
        }

        for (int i = 0; i < frequency.Length; i++)
        {
            Console.WriteLine($"Response {i + 1} given by: {frequency[i]} people");
        }
    }
}
*/

//Q5
/*
using System;

class Program
{
    static void Main()
    {
        int decimalNumber = 10;
        string binaryNumber = DecimalToBinary(decimalNumber);
        Console.WriteLine($"Decimal: {decimalNumber}, Binary: {binaryNumber}");

        int binaryNumber2 = 1010;
        int decimalNumber2 = BinaryToDecimal(binaryNumber2);
        Console.WriteLine($"Binary: {binaryNumber2}, Decimal: {decimalNumber2}");
    }

    static string DecimalToBinary(int decimalNumber)
    {
        string binary = "";
        while (decimalNumber > 0)
        {
            binary = (decimalNumber % 2) + binary;
            decimalNumber /= 2;
        }
        return binary;
    }

    static int BinaryToDecimal(int binaryNumber)
    {
        int decimalNumber = 0;
        int power = 0;
        while (binaryNumber > 0)
        {
            decimalNumber += (binaryNumber % 10) * (int)Math.Pow(2, power);
            binaryNumber /= 10;
            power++;
        }
        return decimalNumber;
    }
}*/



//Q6
/*
using System;

class Program
{
    static void Main()
    {
        int[,] testMarks = new int[5, 10];

        // Populate the test marks array
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Console.Write($"Enter Test {i + 1} mark for Student {j + 1}: ");
                testMarks[i, j] = int.Parse(Console.ReadLine());
            }
        }

        // Display the test marks array
        Console.WriteLine("\nTest Marks:");
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Test {i + 1}: ");
            for (int j = 0; j < 10; j++)
            {
                Console.Write($"{testMarks[i, j]} ");
            }
            Console.WriteLine();
        }

        // Calculate and display the average of each test
        Console.WriteLine("\nAverage Marks:");
        for (int i = 0; i < 5; i++)
        {
            int sum = 0;
            for (int j = 0; j < 10; j++)
            {
                sum += testMarks[i, j];
            }
            double average = (double)sum / 10;
            Console.WriteLine($"Test {i + 1}: {average}");
        }
    }
}*/




//Q7
/*using System;

class Program
{
    static void Main()
    {
        int[,] matrixA = new int[3, 3]
        {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };

        int[,] matrixB = new int[3, 3]
        {
            { 9, 8, 7 },
            { 6, 5, 4 },
            { 3, 2, 1 }
        };

        int[,] result = MultiplyMatrices(matrixA, matrixB);

        Console.WriteLine("Resultant Matrix:");
        for (int i = 0; i < result.GetLength(0); i++)
        {
            for (int j = 0; j < result.GetLength(1); j++)
            {
                Console.Write($"{result[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    static int[,] MultiplyMatrices(int[,] matrixA, int[,] matrixB)
    {
        int rowsA = matrixA.GetLength(0);
        int colsA = matrixA.GetLength(1);
        int colsB = matrixB.GetLength(1);

        if (colsA != matrixB.GetLength(0))
        {
            throw new ArgumentException("Matrix dimensions are incompatible for multiplication.");
        }

        int[,] result = new int[rowsA, colsB];

        for (int i = 0; i < rowsA; i++)
        {
            for (int j = 0; j < colsB; j++)
            {
                for (int k = 0; k < colsA; k++)
                {
                    result[i, j] += matrixA[i, k] * matrixB[k, j];
                }
            }
        }

        return result;
    }
}*/