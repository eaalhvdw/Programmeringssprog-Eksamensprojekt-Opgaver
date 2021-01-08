using System;
using System.Linq;

namespace LHH_Opgave1
{
    public class MergeSortRandomStrings
    {
        // GLOBAL COUNTERS
        private int sortMethodCalls = 0;
        public static int sortEventsRaised = 0;
        public static int generatorEventsRaised = 0;

        // Delegate Eventhandler.
        public delegate void ProgressHandler(object sender, int status, int goal);

        // Events.
        public event ProgressHandler ArrayOfRandomStringsGeneratorProgress;
        public event ProgressHandler MergeSortProgress;

        /**
         * Reset global counters.
         * 
         * Always call this method after a call to either
         * one of the methods ArrayOfRandomStringsGenerator 
         * or MergeSortStrings.
         */
        public void ResetGlobalCounters()
        {
            sortMethodCalls = 0;
            sortEventsRaised = 0;
            generatorEventsRaised = 0;
        }

        // Generate an array of random strings.
        public string[] ArrayOfRandomStringsGenerator(int numStrs, int stringLength, Random random)
        {
            String[] randomStrings = new String[numStrs];

            int i = 0;

            // Frequency of progress report.
            int frequency = numStrs / 5;

            if (frequency <= 0)
            {
                frequency = 1;
            }

            while (i < numStrs)
            {
                randomStrings[i] = RandomStringGenerator(stringLength, random);

                // Send progression reports.
                if (i % frequency == 0)
                {
                    // Raise event.
                    generatorEventsRaised++;
                    ArrayOfRandomStringsGeneratorProgress?.Invoke(this, i, numStrs);
                }

                i++;
            }

            // Send final progression report.
            generatorEventsRaised++;
            ArrayOfRandomStringsGeneratorProgress?.Invoke(this, i, numStrs);

            return randomStrings;
        }

        // Generate a random string.
        private string RandomStringGenerator(int length, Random random)
        {
            char[] letters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            string randomString = "";

            for (int i = 0; i < length; i++)
            {
                randomString += letters[random.Next(0, letters.Length)].ToString();
            }

            return randomString;
        }

        // MergeSort array of strings.
        public String[] MergeSortStrings(String[] unsortedArray, int numOfAllElementsToSort)
        {
            // Send initial progress report.
            if (sortMethodCalls == 0)
            {
                sortEventsRaised++;
                MergeSortProgress?.Invoke(this, sortMethodCalls, numOfAllElementsToSort);
            }

            // Increase global method calls counter.
            sortMethodCalls++;

            // Frequency of progress reports.
            int frequency = numOfAllElementsToSort / 5;

            if (frequency <= 0)
            {
                frequency = 1;
            }

            // Send progression reports.
            if (sortMethodCalls % frequency == 0)
            {
                sortEventsRaised++;
                MergeSortProgress?.Invoke(this, sortMethodCalls, numOfAllElementsToSort);
            }
            
            if (unsortedArray.Length < 2)
            {
                // Array is sorted.
                return unsortedArray;
            }
            else
            {
                int middle = unsortedArray.Length / 2;
                
                String[] left = unsortedArray.Take(middle).ToArray();
                String[] right = unsortedArray.Skip(middle).ToArray();

                left = MergeSortStrings(left, numOfAllElementsToSort);
                right = MergeSortStrings(right, numOfAllElementsToSort);
                return MergeStringArrays(left, right, numOfAllElementsToSort);
            }
        }

        // Helper for MergeSort array of strings.
        private String[] MergeStringArrays(String[] left, String[] right, int numOfAllElementsToSort)
        {
            // Increase global method calls counter.
            sortMethodCalls++;
            
            String[] sortedArray = new String[left.Length + right.Length];

            if (left.Length == 1 && right.Length == 1)
            {
                if (CompareStrings(left[0], right[0]) <= 0)
                {
                    sortedArray[0] = left[0];
                    sortedArray[1] = right[0];
                }
                else
                {
                    sortedArray[0] = right[0];
                    sortedArray[1] = left[0];
                }
            }
            else
            {
                int left_i = 0;
                int right_i = 0;

                while (left_i < left.Length && right_i < right.Length)
                {
                    int index = Array.IndexOf(sortedArray, null);

                    if (CompareStrings(left[left_i], right[right_i]) <= 0)
                    {
                        sortedArray[index] = left[left_i];
                        left_i++;
                    }
                    else
                    {
                        sortedArray[index] = right[right_i];
                        right_i++;
                    }
                }

                if (left_i < left.Length)
                {
                    while (left_i < left.Length)
                    {
                        int index = Array.IndexOf(sortedArray, null);
                        sortedArray[index] = left[left_i];
                        left_i++;
                    }
                }

                if (right_i < right.Length)
                {
                    while (right_i < right.Length)
                    {
                        int index = Array.IndexOf(sortedArray, null);
                        sortedArray[index] = right[right_i];
                        right_i++;
                    }
                }
            }

            // Frequency of progress reports.
            int frequency = numOfAllElementsToSort / 5;

            if (frequency <= 0)
            {
                frequency = 1;
            }

            // Used to make certain of sending final progression report.
            int lastCall;

            if (numOfAllElementsToSort < 2)
            {
                lastCall = 1;
            }
            else if (numOfAllElementsToSort > 2)
            {
                lastCall = numOfAllElementsToSort * 2 + (numOfAllElementsToSort - 2);
            }
            else
            {
                lastCall = numOfAllElementsToSort * 2;
            }

            // Send progression reports.
            if(sortMethodCalls % frequency == 0 || sortMethodCalls == lastCall)
            {
                sortEventsRaised++;
                MergeSortProgress?.Invoke(this, sortMethodCalls, numOfAllElementsToSort);
            }
            
            return sortedArray;
        }

        // Compare two string objects.
        private int CompareStrings(string s1, string s2)
        {
            int result = 0;

            int i = 0;
            int j = 0;

            while (i < s1.Length && j < s2.Length)
            {
                int compareResult = s1[i].CompareTo(s2[j]);

                if (compareResult < 0)
                {
                    result = -1;
                    break;
                }
                else if (compareResult > 0)
                {
                    result = 1;
                    break;
                }
                else
                {
                    i++;
                    j++;
                }
            }
            return result;
        }
    }
}
