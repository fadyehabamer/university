using NAudio.Wave;
using System;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        char choice;

        while (true)
        {
            Console.Clear();
            PlayKeyPressSound();
            PrintMenu();
            choice = Console.ReadKey(true).KeyChar;
            Console.WriteLine();

            switch (char.ToUpper(choice))
            {
                case 'P':
                    PrintNumbers(numbers);
                    break;
                case 'A':
                    AddNumber(numbers);
                    break;
                case 'M':
                    CalculateMean(numbers);
                    break;
                case 'D':
                    CalculateMode(numbers);
                    break;
                case 'E':
                    CalculateMedian(numbers);
                    break;
                case 'O':
                    DisplayOccurrences(numbers);
                    break;
                case 'R':
                    DisplayPrimeNumbers(numbers);
                    break;
                case 'X':
                    MultiplyByNumber(numbers);
                    break;
                case 'C':
                    numbers.Clear();
                    Console.WriteLine("List cleared.");
                    break;
                case 'S':
                    CalculateSum(numbers);
                    break;
                case 'Q':
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unknown selection, please try again");
                    Console.ResetColor();
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey(true);

            if (char.ToUpper(choice) == 'Q')
                break;
        }
    }


    static void PrintMenu()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("╔═════════════════════════ MENU ═══════════════════════════╗");
        Console.WriteLine("║ P - Print numbers                                        ║");
        Console.WriteLine("║ A - Add a number                                         ║");
        Console.WriteLine("║ M - Calculate mean                                       ║");
        Console.WriteLine("║ D - Calculate mode                                       ║");
        Console.WriteLine("║ E - Calculate median                                     ║");
        Console.WriteLine("║ O - Display occurrences of each entry                    ║");
        Console.WriteLine("║ S - Calculate Sum of all numbers                         ║");
        Console.WriteLine("║ R - Display prime numbers                                ║");
        Console.WriteLine("║ X - Multiply all values by a certain number              ║");
        Console.WriteLine("║ C - Clear the list                                       ║");
        Console.WriteLine("║ Q - Quit                                                 ║");
        Console.WriteLine("╚══════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        Console.Write("Enter your choice: ");
    }

    static void PrintNumbers(List<int> numbers)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;

        if (numbers.Count == 0)
        {
            Console.WriteLine("╔══════════════════════════ Error ═════════════════════════════╗");
            Console.WriteLine("║ [Empty] - the list is empty                                  ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════════╝");
        }
        else
        {
            Console.WriteLine("╔══════════════════════════ Numbers ═════════════════════════════╗");
            Console.Write("║ [ ");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine("]".PadRight(53));
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝");
        }
        Console.ResetColor();
    }
    static void AddNumber(List<int> numbers)
    {
        Console.Write("Enter the number to add: ");
        try
        {
            int num = int.Parse(Console.ReadLine());
            numbers.Add(num);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════ Adding New Entry ═════════════════════════════╗");
            Console.WriteLine($"║ {num} added".PadRight(66) + "║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
        }
        catch (FormatException)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔══════════════════════════ Error ═════════════════════════════╗");
            Console.WriteLine("║ Invalid input. Please enter a valid integer.".PadRight(66) + "║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
        }
    }

    static void CalculateMean(List<int> numbers)
    {
        if (numbers.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔══════════════════════════ Error ═════════════════════════════╗");
            Console.WriteLine("║ Unable to calculate the mean - no data".PadRight(66) + "║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
        }
        else
        {
            int sum = 0;
            foreach (int num in numbers)
            {
                sum += num;
            }
            double mean = (double)sum / numbers.Count;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════ Mean ═════════════════════════════╗");
            Console.WriteLine($"║ Mean: {mean}".PadRight(66) + "║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
        }
    }

    static void CalculateMode(List<int> numbers)
    {
        if (numbers.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔══════════════════════════ Error ═════════════════════════════╗");
            Console.WriteLine("║ Unable to calculate the mode - no data".PadRight(66) + "║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝");

            Console.ResetColor();
            return;
        }

        Dictionary<int, int> occurrences = new Dictionary<int, int>();
        foreach (int num in numbers)
        {
            if (occurrences.ContainsKey(num))
                occurrences[num]++;
            else
                occurrences[num] = 1;
        }

        List<int> modes = new List<int>();
        int maxCount = 0;
        foreach (var entry in occurrences)
        {
            if (entry.Value > maxCount)
            {
                modes.Clear();
                modes.Add(entry.Key);
                maxCount = entry.Value;
            }
            else if (entry.Value == maxCount)
            {
                modes.Add(entry.Key);
            }
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("║ Mode:");
        foreach (int mode in modes)
        {
            Console.Write($" {mode}");
        }
        Console.WriteLine("".PadRight(53) + "║");
        Console.ResetColor();
    }

    static void CalculateMedian(List<int> numbers)
    {
        if (numbers.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔══════════════════════════ Error ═════════════════════════════╗");
            Console.WriteLine("║ Unable to calculate the median - no data".PadRight(66) + "║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝");

            Console.ResetColor();
            return;
        }

        List<int> sortedNumbers = new List<int>(numbers);
        CustomSort(sortedNumbers);
        double median;
        if (sortedNumbers.Count % 2 == 0)
        {
            median = (sortedNumbers[sortedNumbers.Count / 2 - 1] + sortedNumbers[sortedNumbers.Count / 2]) / 2.0;
        }
        else
        {
            median = sortedNumbers[sortedNumbers.Count / 2];
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"║ Median: {median}".PadRight(61) + "║");
        Console.ResetColor();
    }

    static void DisplayOccurrences(List<int> numbers)
    {
        if (numbers.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔══════════════════════════ Error ═════════════════════════════╗");
            Console.WriteLine("║ Unable to display occurrences - no data".PadRight(66) + "║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            return;
        }

        // New dictionary to store the occurrences of each number
        Dictionary<int, int> occurrences = new Dictionary<int, int>();
        foreach (int num in numbers)
        {
            if (occurrences.ContainsKey(num))
                occurrences[num]++;
            else
                occurrences[num] = 1;
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔══════════════════════════ Occurrence ═════════════════════════════╗");
        foreach (var entry in occurrences)
        {
            Console.WriteLine($"║ Occurrence of {entry.Key}: {entry.Value}".PadRight(66) + "║");

        }
        Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝");
        Console.ResetColor();
    }

    static void DisplayPrimeNumbers(List<int> numbers)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔══════════════════════════ Prime numbers ═════════════════════════════╗");
        Console.Write("║ Prime numbers:");
        foreach (int num in numbers)
        {
            if (IsPrime(num))
            {
                Console.Write($" {num}");
            }
        }
        Console.WriteLine("".PadRight(66) + "║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝");

        Console.ResetColor();
    }

    static bool IsPrime(int num)
    {
        if (num <= 1)
            return false;
        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0)
                return false;
        }
        return true;
    }

    static void MultiplyByNumber(List<int> numbers)
    {
        Console.Write("Enter the number to multiply by: ");
        if (int.TryParse(Console.ReadLine(), out int multiplier))
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i] *= multiplier;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════ Multiply ═════════════════════════════╗");
            Console.WriteLine($"║ All values multiplied by {multiplier}".PadRight(66) + "║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝");

            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔══════════════════════════ Error ═════════════════════════════╗");
            Console.WriteLine("║ Invalid input. Please enter a valid integer.".PadRight(66) + "║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════════╝");

            Console.ResetColor();
        }
    }

    static void CustomSort(List<int> numbers)
    {
        for (int i = 0; i < numbers.Count - 1; i++)
        {
            for (int j = i + 1; j < numbers.Count; j++)
            {
                if (numbers[i] > numbers[j])
                {
                    int temp = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = temp;
                }
            }
        }
    }

    static void CalculateSum(List<int> numbers)
    {
        if (numbers.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Unable to calculate the sum - the list is empty");
            Console.ResetColor();
            return;
        }

        int sum = 0;
        foreach (int num in numbers)
        {
            sum += num;
        }

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Sum of all numbers: {sum}");
        Console.ResetColor();
    }

    static void PlayKeyPressSound()
    {
        try
        {
            using (var audioFile = new AudioFileReader("click2.wav"))
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFile);
                outputDevice.Play();
                while (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    // Wait for the audio to finish playing
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error playing sound: {ex.Message}");
        }
    }
}




