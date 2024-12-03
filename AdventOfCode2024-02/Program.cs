namespace AdventOfCode2024_02;

class Program
{
	static void Main(string[] args)
	{
		string input = File.ReadAllText("../../../input.txt");
		Console.WriteLine("Part One: " + PartOne(input));
		Console.WriteLine("Part Two: " + PartTwo(input));
	}
	
	public static int PartOne(string input)
	{
		int amountSafe = 0;
		string[] lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

		foreach (string line in lines)
		{

			string[] parts = line.Split(' ', StringSplitOptions.TrimEntries);
			int[] numbers = new int[parts.Length];
			for (int i = 0; i < numbers.Length; i++)
			{
				numbers[i] = int.Parse(parts[i]);
			}

			bool isAscending = true, isDescending = true, isValid = true;
			for (int i = 0; i < numbers.Length - 1; i++)
			{
				if(numbers[i] > numbers[i + 1])
				{
					isAscending = false;
				}
				if(numbers[i] < numbers[i + 1])
				{
					isDescending = false;
				}
				int diff = Math.Abs(numbers[i] - numbers[i + 1]);
				if(diff>3 || diff < 1)
				{
					isValid = false;
				}
			}
			
			if((isAscending || isDescending) && isValid)
			{
				amountSafe++;
			}

		}
		
		return amountSafe;
	}

	public static int PartTwo(string input)
	{
		int amountSafe = 0;
		string[] lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

		foreach (string line in lines)
		{
			string[] parts = line.Split(' ', StringSplitOptions.TrimEntries);
			int[] numbers = new int[parts.Length];
			for (int i = 0; i < numbers.Length; i++)
			{
				numbers[i] = int.Parse(parts[i]);
			}

			if (IsSafe(numbers))
			{
				amountSafe++;
			}
			else
			{
				for (int i = 0; i < numbers.Length; i++)
				{
					int[] modifiedNumbers = numbers.Where((_, index) => index != i).ToArray();
					if (IsSafe(modifiedNumbers))
					{
						amountSafe++;
						break;
					}
				}
			}
		}

		return amountSafe;
	}

	private static bool IsSafe(int[] numbers)
	{
		bool isAscending = true, isDescending = true, isValid = true;
		for (int i = 0; i < numbers.Length - 1; i++)
		{
			if (numbers[i] > numbers[i + 1])
			{
				isAscending = false;
			}
			if (numbers[i] < numbers[i + 1])
			{
				isDescending = false;
			}
			int diff = Math.Abs(numbers[i] - numbers[i + 1]);
			if (diff > 3 || diff < 1)
			{
				isValid = false;
			}
		}

		return (isAscending || isDescending) && isValid;
	}
	
}