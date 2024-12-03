namespace AdventOfCode2024_01;

class Program
{
	static void Main(string[] args)
	{
		string input = File.ReadAllText("../../../input.txt");

		Console.WriteLine("Part One: " + PartOne(input));
		
		Console.WriteLine("Part Two: " + PartTwo(input));

	}

	public static int PartOne (string input)
	{
		string[] lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);

		int[] column1 = new int[lines.Length];
		int[] column2 = new int[lines.Length];

		for (int i = 0; i < lines.Length; i++)
		{
			string[] parts = lines[i].Split("   ");
			column1[i] = int.Parse(parts[0].Trim());
			column2[i] = int.Parse(parts[1].Trim());
		}
		
		Array.Sort(column1);
		Array.Sort(column2);
		
		int[] resultArray = new int[lines.Length];
		
		for (int i = 0; i < lines.Length; i++)
		{
			resultArray[i] = Math.Abs(column1[i] - column2[i]);
		}
		
		int result = resultArray.Sum();
		
		return result;
	}
	
	public static int PartTwo (string input)
	{
		string[] lines = input.Split("\n", StringSplitOptions.RemoveEmptyEntries);

		int[] column1 = new int[lines.Length];
		int[] column2 = new int[lines.Length];

		for (int i = 0; i < lines.Length; i++)
		{
			string[] parts = lines[i].Split("   ");
			column1[i] = int.Parse(parts[0].Trim());
			column2[i] = int.Parse(parts[1].Trim());
		}
		
		int[] resultArray = new int[lines.Length];
		
		for (int i = 0; i < lines.Length; i++)
		{
			int count = 0;
			for (int ii = 0 ; ii < lines.Length ; ii++)
			{
				if (column1[i] == column2[ii] )
				{
					count++;
				}
			}
			resultArray[i] = column1[i] * count;
		}
		
		int result = resultArray.Sum();
		
		return result;
	}
	
}