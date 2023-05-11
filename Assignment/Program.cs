namespace Assignment
{
    public static class ArrayReplicator
    {
        /// <summary>
        /// Replicates (deep copies) the incoming array
        /// </summary>
        /// <param name="original">The array to be replicated</param>
        /// <returns>A deep copy of the original array</returns>
        public static int[] ReplicateArray(int[] original)
        {
            int[] deepCopy = new int[original.Length];
            for(int i = 0; i < original.Length; ++i)
            {
                deepCopy[i] = original[i];
            }
            return deepCopy;
        }

        /// <summary>
        /// Asks the user for a number. Will crash if the user input is not convertible to an int (throw exception?)
        /// </summary>
        /// <param name="text">Text to prompt the user</param>
        /// <returns>The user input as an integer</returns>
        public static int AskForNumber(string text)
        {
            Console.WriteLine(text);

            return readNumber();
        }

        /// <summary>
        /// Asks the user for a number within a certain range [min, max]. If the number is not in the range, re-prompt the user for a new number.
        /// Will crash if the user input is not convertible to an int (throw exception?)
        /// </summary>
        /// <param name="text">Text to prompt the user</param>
        /// <param name="min">Smallest permissible value</param>
        /// <param name="max">Largest permissible value</param>
        /// <returns>The user input as an integer</returns>
        public static int AskForNumberInRange(string text, int min, int max)
        {
            bool isInRange = true;
            int value = -1;
            while (isInRange)
            {
                value = AskForNumber(text);
                if (value >= min && value <= max)
                {
                    break;
                } else
                {
                    Console.WriteLine($"the value is not in the range[{min},{max}], please input a correct value.");
                }
            }
            return value;
        }

        private static int readNumber()
        {
            int number = 0;
            while (true)
            {
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                  
                    break;
                }
                catch
                {
                    Console.WriteLine("The enter value format is not correct, please to enter a number.");
                }
            }


            return number;
        }
    }

    static class Program
    {
        static void Main()
        {
            
            const int Min = 0;
            const int Max = 10;
            const int PrintOffset = 4;

            int size = ArrayReplicator.AskForNumberInRange("Enter the array size: ", Min, Max);
            int[] original = new int[size];

            // Fill the original array with user specified integers
            for (int item = 0; item < size; ++item)
            {
                original[item] = ArrayReplicator.AskForNumber("Enter a number: ");
            }

            int[] copy = ArrayReplicator.ReplicateArray(original);
            // Verify original and replicated array are the same
            for (int index = 0; index < size; ++index)
                Console.WriteLine($"Original {original[index],-PrintOffset}  {copy[index],4} Copy");


            Console.ReadLine();
        }
    }
}
