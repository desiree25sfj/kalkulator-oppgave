// handle parsing and validation

using System.Collections.Generic;

public static class InputHandler
{
	public static List<double> ParseNumbers(string input)
	{
		List<double> numbers = new List<double>();
		string[] parts = input.Split(' ', ',', StringSplitOptions.RemoveEmptyEntries);

		foreach (string part in parts)
		{
			if (double.TryParse(part, out double num))
			{
				numbers.Add(num);
			}
			else
			{
				Console.WriteLine($"Warning: '{part}' is not a valid number and will be ignored.");
			}
		}
		return numbers;
	}
}