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
}