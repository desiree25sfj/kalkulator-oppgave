/* Temporary code to test

Calculator calc = new Calculator();

double addTwo = calc.Add(3, 5);
Console.WriteLine($"Add(3, 5) = {addTwo}");

double subTwo = calc.Subtract(10, 4);
Console.WriteLine($"Subtract(10, 4) = {subTwo}");

double mulTwo = calc.Multiply(2, 6);
Console.WriteLine($"Multiply(2, 6) = {mulTwo}");

double divTwo = calc.Divide(20, 2);
Console.WriteLine($"Divide(20, 2) = {divTwo}");

List<double> testNumbers = new List<double> { 2, 4, 6, 8 };

double addList = calc.Add(testNumbers);
Console.WriteLine($"Add(List) = {addList}");

double subList = calc.Subtract(testNumbers);
Console.WriteLine($"Subtract(List) = {subList}");

double mulList = calc.Multiply(testNumbers);
Console.WriteLine($"Multiply(List) = {mulList}");

double divList = calc.Divide(testNumbers);
Console.WriteLine($"Divide(List) = {divList}"); */

Console.WriteLine("Welcome to the Overloaded Calculator!");

Calculator calc = new Calculator();

while (true)
{
	Console.WriteLine("What operation would you like to perform? \n(add, subtract, multiply, divide or type 'exit' to quit)");
	string? operation = Console.ReadLine()?.ToLower();

	if (operation == "exit")
	{
		Console.WriteLine("Goodbye! Thanks for calculating responsibly.");
		break;
	}
	Console.WriteLine("Please enter numbers separated by spaces or commas:");
	string? input = Console.ReadLine();
	List<double> numbers = InputHandler.ParseNumbers(input);

	double result = 0;

	if (numbers.Count == 0)
	{
		Console.WriteLine("No valid numbers were provided. Please try again.");
		continue;
	}

	switch (operation)
	{
		case "add":
			result = (numbers.Count == 2)
				? calc.Add(numbers[0], numbers[1])
				: calc.Add(numbers);
			break;

		case "subtract":
			result = (numbers.Count == 2)
				? calc.Subtract(numbers[0], numbers[1])
				: calc.Subtract(numbers);
			break;

		case "multiply":
			result = (numbers.Count == 2)
				? calc.Multiply(numbers[0], numbers[1])
				: calc.Multiply(numbers);
			break;

		case "divide":
			try
			{
				result = (numbers.Count == 2)
					? calc.Divide(numbers[0], numbers[1])
					: calc.Divide(numbers);
			}
			catch (DivideByZeroException ex)
			{
				Console.WriteLine(ex.Message);
				continue;
			}
			break;

		default:
			Console.WriteLine("Invalid operation. Please try again.");
			continue;
	}

	Console.WriteLine($"Result: {result}");
}