using System;

namespace Csharp_MasterMinds
{
    class Program
    {
        static void DisplayStringConcatenationInfo(MasterMinds Num)
        {
            Console.WriteLine("Number " + (Num.count + 1).ToString() + ": " + (Num.RandomNumber).ToString());
            Console.WriteLine($"Number {Num.count + 1}" + ":" + Num.RandomNumber); //string concatenation with $ sign
        }

        /* Develop a program that generates 4 unique, random numbers between 0(inclusive) to 10(exclusive)*/
        class MasterMinds
        {
            public int RandomNumber;
            public int[] NumberArr;
            public int count;
            public int min = 0;
            public int max = 9;
            public int UserGuess;
            public int[] UserGuessArr;
            public int isWinCount;
        }
        static void InitializeArray(MasterMinds Num)
        {
            for (int i = 0; i < 4; i++)
            {
                Num.NumberArr[i] = 10;
            }
        }
        enum Colors { }
        static void ChangeColor(int color)
        {
            Console.ForegroundColor = (ConsoleColor)color;
        }
        static void ChangeColor(Colors color)
        {
            ChangeColor(color);
        }
        static void GetUserInput(MasterMinds Num)
        {

            for (int i = 0; i < 4; i++)
            {
                Console.Write($"Number {i + 1}:");
                Num.UserGuess = int.Parse(Console.ReadLine());
                Num.UserGuessArr[i] = Num.UserGuess;
            }

        }
        static bool DidUserWin(MasterMinds Num)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Num.NumberArr[i] == Num.UserGuessArr[i] && i == j)
                    {
                        Num.isWinCount++;
                    }
                }
            }
            if (Num.isWinCount == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /*
         Checking User Input:
         3 scenarios:
         1. Number is not in computer array
         2. Number is correct, but not in correct location
         3. Number is wrong, but in correct location
         Win: ALL Numbers are correct, and ALL are in correct location  
         */

        static void IsUserNumberInCorrectLocation(MasterMinds Num)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Num.NumberArr[i] != Num.UserGuessArr[j] && i != j)
                    {
                        continue;
                        
                    }
                    if (Num.NumberArr[i] == Num.UserGuessArr[j] && i == j)//if i==j, then they are in correct location
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine($"Number {i + 1}: {Num.UserGuessArr[j]} is one of the computer's random numbers and is in the correct location");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (Num.NumberArr[i] == Num.UserGuessArr[j] && i != j)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;


                        Console.WriteLine($"Number {i + 1}: {Num.UserGuessArr[j]} is one of the computer's random numbers but is NOT in the correct location");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else //if(Num.NumberArr[i] != Num.UserGuess && i !=j)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine($"Number {i + 1}: {Num.UserGuessArr[j]} is NOT one of the computer's random numbers and is NOT in the correct location");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                }
            }

        }
        ////2. 
        //static void IsUserNumberInComputerArray(MasterMinds Num)
        //{
        //    for(int i=0;i<4;i++)
        //    {
        //        if(Num.NumberArr[i]==Num.UserGuessArr[i])
        //        {

        //        }
        //    }

        //}
        static void DisplayComputerNumberList(MasterMinds Num)
        {
            Console.WriteLine("The computer's final number list is: ");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Number {Num.count}" + ":" + Num.NumberArr[i]);
            }
        }
        static void Main()
        {
            MasterMinds Num = new MasterMinds();
            Num.count = 0;
            Num.NumberArr = new int[4];
            Num.UserGuessArr = new int[4];


            InitializeArray(Num);

            for (int i = 0; i < 4; i++)
            {
                GenerateRandomNumber(Num);
                Num.RandomNumber = CheckRandomNumber(Num);

                Num.NumberArr[i] = Num.RandomNumber;
                Num.count++;
                Console.WriteLine($"Number {Num.count}" + ":" + Num.NumberArr[i]);
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            DisplayComputerNumberList(Num);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

            do
            {
                Console.WriteLine("Try to guess the computer's number");
                GetUserInput(Num);
                Console.WriteLine();
                //  IsUserNumberInComputerArray(Num);
                IsUserNumberInCorrectLocation(Num);
                Console.WriteLine("Try again!");
                Console.ReadKey();
                Console.Clear();

            } while (DidUserWin(Num) == false);

            Console.WriteLine("Congrats! You won!");
        }

        static int GenerateRandomNumber(MasterMinds Num)
        {
            Random random = new Random();
            return random.Next(Num.min, Num.max);
        }
        static int CheckRandomNumber(MasterMinds Num)
        {
            if (Num.count == 0)//first number is never going to be duplicate
            {
                Num.RandomNumber = GenerateRandomNumber(Num);

                return Num.RandomNumber;
            }
            else
            {
                Num.RandomNumber = GenerateRandomNumber(Num);

                while (IsNumberDuplicate(Num) == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Generating Number {Num.count + 1}: {Num.RandomNumber}. It's a Duplicate!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Num.RandomNumber = GenerateRandomNumber(Num);

                }
            }
            return Num.RandomNumber;
        }
        static bool IsNumberDuplicate(MasterMinds Num)
        {
            for (int i = 0; i < Num.NumberArr.Length; i++)
            {
                if (Num.NumberArr[i] == Num.RandomNumber)//iterate thru each number in numberarr and check
                {
                    return true;
                }
            }
            return false;
        }
    }
}
