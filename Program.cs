using System;
using System.Runtime.Intrinsics.X86;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int tries = 0;
            bool a = true;
            int number = 0;

            while (true)
            {
                Console.WriteLine("Välkommen till gissa numret! Vilken svårighetsgrad vill du ha mellan 1, 2 och 3");

                int svårighetsgrad = int.Parse(Console.ReadLine());

                if (svårighetsgrad == 1)
                {
                    tries = 6;
                    Random random = new Random();
                    number = random.Next(1, 10);
                }
                else if (svårighetsgrad == 2)
                {
                    tries = 5;
                    Random random = new Random();
                    number = random.Next(1, 20);
                }
                else if (svårighetsgrad == 3)
                {
                    tries = 4;
                    Random random = new Random();
                    number = random.Next(1, 30);
                }


                Console.WriteLine($"Jag tänker på ett nummer. Kan du gissa vilket? Du får {tries} försök.");

                CheckGuess(tries, number, svårighetsgrad);

                Console.WriteLine("Vill du spela igen? Y/N");

                string svar = Console.ReadLine();
                if (svar == "N")
                {
                    break;
                }
                else if (svar == "Y")
                {
                    Console.WriteLine("Lycka till!");
                }
                else
                {
                    break;
                }
            }
        }
        static void CheckGuess(int tries, int number, int svårighetsgrad)
        {

            int close = number + 3;
            int close2 = close - 1;
            int close3 = close - 2;
            int close4 = number - 3;
            int close5 = close4 + 1;
            int close6 = close4 + 2;

            for (int i = 0; i < tries; i++)
            {

                int definedanswer = int.Parse(Console.ReadLine());

                string[] output = { "Tyvärr, du gissade för högt!", $"Haha! du gissade {definedanswer} och det var för högt", "Bra gissat men det var för högt!" };
                string[] output2 = { "Tyvärr, du gissade för lågt!", $"Haha! du gissade {definedanswer} och det var för lägre", "Ganska bra gissat men det var för lågt!" };

                Random fel = new Random();

                int index = fel.Next(output.Length);

                if (definedanswer == number)
                {
                    Console.WriteLine("Wohoo! Du klarade det!");
                    return;

                }
                else if (definedanswer < number)
                {
                    Console.WriteLine(output2[index]);
                    if (definedanswer == close4)
                    {
                        Console.WriteLine("Nu bränns det, lite högre bara");
                    }
                    else if (definedanswer == close5)
                    {
                        Console.WriteLine("Oj vad nära du är!");
                    }
                    else if (definedanswer == close6)
                    {
                        Console.WriteLine("Nu har du nästan vunnit!");
                    }

                }
                else if (definedanswer > number)
                {
                    Console.WriteLine(output[index]);
                    if (definedanswer > close)
                    {
                        Console.WriteLine("Nu bränns det, lite lägre");
                    }
                    else if (definedanswer == close2)
                    {
                        Console.WriteLine("Oj vad nära du är!");
                    }
                    else if (definedanswer == close3)
                    {
                        Console.WriteLine("Nu är du nära på att vinna");
                    }
                }

            }

            Console.WriteLine("Bra spelat!");
        }
    }
}