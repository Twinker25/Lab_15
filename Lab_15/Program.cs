using System;
using System.Data;
using System.Linq.Expressions;
using static System.Net.Mime.MediaTypeNames;

namespace Lab_15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while(true) 
            {
                Console.Write("Enter task 1 or 2: ");
                int ch = int.Parse(Console.ReadLine());
                switch(ch)
                {
                    case 1:
                        try
                        {
                            string file = "D:\\Games\\Visual Studio\\Lab_15\\Lab_15\\Task1.txt";
                            bool fileExists = File.Exists(file);

                            if (fileExists)
                            {
                                Console.Write("Enter what to do:\n1 - Write text to and print from file\n2 - Write array to and print from file\nEnter: ");
                                int task1 = int.Parse(Console.ReadLine());
                                if (task1 == 1) 
                                {
                                    Console.Write("Enter text: ");
                                    string text = Console.ReadLine();
                                    File.WriteAllText(file, text);

                                    string rez1 = File.ReadAllText(file);
                                    Console.WriteLine("Result: " + rez1);
                                }
                                if (task1 == 2)
                                {
                                    int[] arr = new int[10];
                                    for (int i = 0; i < arr.Length; i++)
                                    {
                                        Console.Write($"Enter number {i + 1}: ");
                                        arr[i] = Convert.ToInt32(Console.ReadLine());
                                    }

                                    using (StreamWriter writer = new StreamWriter(file))
                                    {
                                        foreach (int element in arr)
                                        {
                                            writer.WriteLine(element);
                                        }
                                    }

                                    string rez2 = File.ReadAllText(file);
                                    Console.WriteLine("Result: " + rez2);
                                }
                            }
                            else
                            {
                                File.Create(file);
                                throw new Exception("File not create");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 2:
                        string evenFile = "D:\\Games\\Visual Studio\\Lab_15\\Lab_15\\EvenNumber.txt";
                        string oddFile = "D:\\Games\\Visual Studio\\Lab_15\\Lab_15\\OddNumber.txt";

                        Random random = new Random();
                        int[] array = new int[10000];
                        for (int i = 0; i < array.Length; i++)
                        {
                            array[i] = random.Next(0, 10000);
                        }

                        int even = 0;
                        int odd = 0;
                        using (StreamWriter evenWriter = new StreamWriter(evenFile))
                        using (StreamWriter oddWriter = new StreamWriter(oddFile))
                        {
                            foreach (int number in array)
                            {
                                if (number % 2 == 0)
                                {
                                    evenWriter.WriteLine(number);
                                    even++;
                                }
                                else
                                {
                                    oddWriter.WriteLine(number);
                                    odd++;
                                }
                            }
                        }

                        int total = even + odd;

                        Console.WriteLine("Statistics:");
                        Console.WriteLine($"Even numbers: {even}");
                        Console.WriteLine($"Odd numbers: {odd}");
                        Console.WriteLine($"Total: {total}");
                        break;

                    default: Console.WriteLine("Error!"); break;
                }
            }
        }
    }
}