using System;
using System.Diagnostics;
using System.Text;

namespace LHH_Opgave2
{
    class Program
    {
        static StringBuilder ResolveNumberToPrimeFactors(int number)
        {
            StringBuilder result = new StringBuilder();

            string intro = string.Format("Prime factors of {0}: ", number);
            result.Append(intro);
            
            while (number % 2 == 0)
            {
                result.Append(2);
                number /= 2;

                if (number >= 2)
                {
                    result.Append(", ");
                }
            }

            int factor = 3;

            while (factor * factor <= number)
            {
                if (number % factor == 0)
                {
                    result.Append(factor);
                    number /= factor;

                    if (number >= factor)
                    {
                        result.Append(", ");
                    }
                }
                else
                {
                    factor += 2;
                }
            }

            if (number > 1)
            {
                result.Append(number);
            }

            return result;
        }

        static void Main(string[] args)
        {
            // ---------- Test ----------
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Console.WriteLine(ResolveNumberToPrimeFactors(10));         // => Prime factors of 10: 2, 5
            Console.WriteLine(ResolveNumberToPrimeFactors(16));         // => Prime factors of 16: 2, 2, 2, 2
            Console.WriteLine(ResolveNumberToPrimeFactors(21));         // => Prime factors of 21: 3, 7
            Console.WriteLine(ResolveNumberToPrimeFactors(25));         // => Prime factors of 25: 5, 5
            Console.WriteLine(ResolveNumberToPrimeFactors(20));         // => Prime factors of 20: 2, 2, 5
            Console.WriteLine(ResolveNumberToPrimeFactors(15));         // => Prime factors of 15: 3, 5
            Console.WriteLine(ResolveNumberToPrimeFactors(1564852));    // => Prime factors of 1564852: 2, 2, 67, 5839
            Console.WriteLine(ResolveNumberToPrimeFactors(68459237));   // => Prime factors of 68459237: 7, 11, 889081

            stopWatch.Stop();

            TimeSpan time = stopWatch.Elapsed;

            Console.WriteLine("\nRunTime " + time.TotalSeconds + " seconds\n");
            Console.ReadLine();
        }
    }
}
