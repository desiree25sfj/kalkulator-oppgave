// main class (super class?), overloaded methods

using System.Collections.Generic;

public class Calculator
{
	public double Add(double a, double b)
	{
		return a + b;
	}

	public double Add(List<double> numbers)
	{
		double sum = 0;

		foreach (double num in numbers)
		{
			sum += num;
		}
		return sum;
	}

	public double Subtract(double a, double b)
	{
		return a - b;
	}

	public double Subtract(List<double> numbers)
	{
		if (numbers.Count == 0) return 0;

		double result = numbers[0];
		for (int i = 1; i < numbers.Count; i++)
		{
			result -= numbers[i];
		}
		return result;
	}
}