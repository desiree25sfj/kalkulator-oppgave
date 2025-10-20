// main class (super class?), overloaded methods

using System.Collections.Generic;
using System.Runtime.InteropServices;

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

	public double Multiply(double a, double b)
	{
		return a * b;
	}

	public double Multiply(List<double> numbers)
	{
		double product = 1;
		foreach (double num in numbers)
		{
			product *= num;
		}
		return product;
	}

	public double Divide(double a, double b)
	{
		if (b == 0)
		{
			throw new DivideByZeroException("Cannot divide by zero.");
		}
		return a / b;
	}

	public double Divide(List<double> numbers)
	{
		if (numbers.Count == 0) return 0;

		double result = numbers[0];
		for (int i = 1; i < numbers.Count; i++)
		{
			if (numbers[i] == 0)
			{
				throw new DivideByZeroException("Cannot divide by zero.");
			}
			result /= numbers[i];
		}
		return result;
	}
}