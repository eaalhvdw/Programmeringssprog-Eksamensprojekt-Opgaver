using System;

namespace LHH_Opgave1
{
    public class Program
    {
        // Subscriber method for generating an array of random strings.
        static void OnArrayOfRandomStringsGeneratorProgress(object sender, int status, int goal)
        {
            // Degree of detail is element progress.
            Console.WriteLine(" Progress now at {0} of {1} strings", status, goal);

            if (status == goal)
            {
                Console.WriteLine("\n Generation of strings has finished!\n");
                Console.WriteLine(" {0} progress reports were made for the generation of {1} strings\n", 
                    MergeSortRandomStrings.generatorEventsRaised, goal);
            }
        }
        
        // Subscriber method for sorting an array with merge sort.
        static void OnMergeSortProgress(object sender, int statusCalls, int elements) 
        {
            int totalNumMethodCalls; 
            
            if(elements > 2)
            {
                totalNumMethodCalls = elements * 2 + (elements - 2);
            }
            else if(elements == 2)
            {
                totalNumMethodCalls = elements * 2;
            }
            else
            {
                totalNumMethodCalls = 1;
            }
            
            // Degree of detail is percentage progress.
            double statusPercentage = (double) statusCalls / (double) totalNumMethodCalls * 100;
            
            Console.WriteLine(" Progress now at {0} %", statusPercentage > 99.50 ? 
                Math.Round(statusPercentage - 0.5) : Math.Round(statusPercentage));

            if (statusCalls == totalNumMethodCalls)
            {
                Console.WriteLine("\n MergeSort has finished!\n");
                Console.WriteLine(" {0} progress reports were made for the sorting of {1} strings\n", 
                    MergeSortRandomStrings.sortEventsRaised, elements);
            }
        }

        // Display an array of strings.
        static void DisplayArray(String[] array)
        {
            foreach (string s in array)
            {
                Console.WriteLine(" " + s);
            }
        }

        static void Main(string[] args)
        {
            // Setup.
            MergeSortRandomStrings publisher = new MergeSortRandomStrings();
            int numStrs = 20468;
            Random random = new Random();

            // Generate and display array of random strings.
            Console.WriteLine("\n Generating an array of {0} random strings...", numStrs);
            string[] unsortedRandomStrings = publisher.ArrayOfRandomStringsGenerator(numStrs, 20, random);
            publisher.ResetGlobalCounters();
            //Console.WriteLine(" \n The array of random strings:");
            //DisplayArray(unsortedRandomStrings);

            // Sort and display the generated array of random strings.
            Console.WriteLine("\n Sorting the array of {0} random strings with merge sort...", numStrs);
            string[] sortedRandomStrings = publisher.MergeSortStrings(unsortedRandomStrings, numStrs);
            publisher.ResetGlobalCounters();
            //Console.WriteLine("\n The array of random strings sorted with merge sort:");
            //DisplayArray(sortedRandomStrings);

            Console.WriteLine("\n-----------------------------------------------------------------------------------------");
            
            // Register with the ArrayOfRandomStringsGeneratorProgress event.
            publisher.ArrayOfRandomStringsGeneratorProgress += OnArrayOfRandomStringsGeneratorProgress;
            Console.WriteLine("\n A new subscriber has been registered to the ArrayOfRandomStringsGeneratorProgress event.");
            Console.WriteLine("\n-----------------------------------------------------------------------------------------");

            // Generate and display a new array of random strings.
            Console.WriteLine("\n Generating a new array of {0} random strings...\n", numStrs);
            string[] generatedStrings = publisher.ArrayOfRandomStringsGenerator(numStrs, 20, random);
            publisher.ResetGlobalCounters();
           // Console.WriteLine(" The new array of random strings:");
            //DisplayArray(generatedStrings);

            // Sort and display the new array of random strings.
            Console.WriteLine("\n Sorting the new array of {0} random strings with merge sort...", numStrs);
            string[] sortedGeneratedStrings = publisher.MergeSortStrings(generatedStrings, numStrs);
            publisher.ResetGlobalCounters();
            //Console.WriteLine("\n The new array of random strings sorted with merge sort:");
            //DisplayArray(sortedGeneratedStrings);

            Console.WriteLine("\n-----------------------------------------------------------------------------------------");

            // Register with the MergeSortPregress event.
            publisher.MergeSortProgress += OnMergeSortProgress;
            Console.WriteLine("\n A new subscriber has been registered to the MergeSortProgress event.");
            Console.WriteLine("\n-----------------------------------------------------------------------------------------");

            // Generate and display a new array of random strings.
            Console.WriteLine("\n Generating another new array of {0} random strings...\n", numStrs);
            string[] lastGeneratedStrings = publisher.ArrayOfRandomStringsGenerator(numStrs, 20, random);
            publisher.ResetGlobalCounters();
            //Console.WriteLine(" The latest array of random strings:");
            //DisplayArray(lastGeneratedStrings);

            // Sort and display the new array of random strings.
            Console.WriteLine("\n Sorting the latest array of {0} random strings with merge sort...\n", numStrs);
            string[] sortedLastGeneratedStrings = publisher.MergeSortStrings(lastGeneratedStrings, numStrs);
            publisher.ResetGlobalCounters();
            //Console.WriteLine(" The latest array of random strings sorted with merge sort:");
            //DisplayArray(sortedLastGeneratedStrings);
            
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
