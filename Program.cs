using System;
using System.Runtime.Intrinsics.X86;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NumbersGame
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //variablar om hur många försök och vad svar numret kommer att vara
            int tries = 0;
            int number = 0;

            //Spelets start, börjar med att fråga efter en svårighetsgrad och utgår därifrån
            while (true)
            {
                Console.WriteLine("Välkommen till gissa numret! Vilken svårighetsgrad vill du ha mellan 1, 2 och 3");

                int svårighetsgrad = int.Parse(Console.ReadLine());
                //Dessa får användaren välja mellan om de vill ha svårare eller lättare för sig
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

                //Här kollar programmet om svaret är korrekt eller inte
                CheckGuess(tries, number, svårighetsgrad);

                Console.WriteLine("Vill du spela igen? Y/N");

                //Här kollar programmet om du vill forsätta spelet eller inte
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
            //Här skapas intar för nummer omkring så att jag kan ge andra texter om andvändaren kommer närmre svaret
            int close = number + 3;
            int close2 = close - 1;
            int close3 = close - 2;
            int close4 = number - 3;
            int close5 = close4 + 1;
            int close6 = close4 + 2;

            //For Loop för att den ska fortsätta fråga efter svaret beroende på hur många försök du har kvar
            for (int i = 0; i < tries; i++)
            {

                int definedanswer = int.Parse(Console.ReadLine());

                //Här skapas lite arrayer för olika texter som sedan ska randomly skickas ut
                string[] output = { "Tyvärr, du gissade för högt!", $"Haha! du gissade {definedanswer} och det var för högt", "Bra gissat men det var för högt!" };
                string[] output2 = { "Tyvärr, du gissade för lågt!", $"Haha! du gissade {definedanswer} och det var för lägre", "Ganska bra gissat men det var för lågt!" };

                Random fel = new Random();

                int index = fel.Next(output.Length);

                //Här kollar programmet om svaret är rätt eller rätt så nära
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
            //Här avslutas spelet
            Console.WriteLine("Bra spelat!");
        }
    }
}