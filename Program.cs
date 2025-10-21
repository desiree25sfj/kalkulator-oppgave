// Console.WriteLine("Welcome to the Overloaded Calculator!");

MessageHandler.LoadMessages("data/messages.json");

Console.WriteLine(MessageHandler.GetMessage("welcome"));

Calculator calc = new Calculator();
var operations = OperationDictionary.GetOperations(calc);

List<CalculationHistory> history = HistoryManager.LoadHistory();

while (true)
{
	Console.WriteLine(MessageHandler.GetMessage("prompt"));

	string? operation = Console.ReadLine()?.ToLower();
	if (string.IsNullOrWhiteSpace(operation))
	{
		Console.WriteLine("Invalid input. Please try again.");
		continue;
	}

	if (operation == "help")
	{
		var help = MessageHandler.GetSubMessages("help");
		Console.WriteLine(help["header"]);
		Console.WriteLine(help["operations"]);
		Console.WriteLine(help["commands"]);
		Console.WriteLine(help["footer"]);
		continue;
	}
	// Console.WriteLine("What operation would you like to perform? (type 'help' for options)");

	// if (operation == "help")
	// {
	// 	Console.WriteLine();
	// 	Console.WriteLine("=== HELP MENU ===");
	// 	Console.WriteLine("Available operations:");
	// 	Console.WriteLine(" add, subtract, multiply, divide");
	// 	Console.WriteLine();
	// 	Console.WriteLine("Special commands:");
	// 	Console.WriteLine(" history - View previous results");
	// 	Console.WriteLine(" clear - Delete history");
	// 	Console.WriteLine(" exit - Quit the program");
	// 	Console.WriteLine("=================");
	// 	Console.WriteLine();
	// 	continue;
	// }

	// if (operation == "history")
	// {
	// 	if (history.Count == 0)
	// 	{
	// 		Console.WriteLine("No previous calculations found.");
	// 	}
	// 	else
	// 	{
	// 		foreach (var record in history)
	// 		{
	// 			string nums = string.Join(", ", record.Numbers);
	// 			Console.WriteLine($"{record.Timestamp:g} | {record.Operation}({nums}) = {record.Result}");
	// 		}
	// 	}
	// 	continue;
	// }

	// if (operation == "clear")
	// {
	// 	HistoryManager.ClearHistory(history);
	// 	continue;
	// }

	if (operation == "exit")
	{
		Console.WriteLine(MessageHandler.GetMessage("exitMessage"));
		break;
	}
	Console.WriteLine("Please enter numbers separated by spaces or commas:");
	string? input = Console.ReadLine();
	if (string.IsNullOrWhiteSpace(input))
	{
		Console.WriteLine("You didn't enter any numbers!");
		continue;
	}
	List<double> numbers = InputHandler.ParseNumbers(input);

	double result = 0;

	if (numbers.Count == 0)
	{
		Console.WriteLine("No valid numbers were provided. Please try again.");
		continue;
	}

	if (!operations.ContainsKey(operation))
	{
		Console.WriteLine("Invalid operation. Please try again.");
		continue;
	}

	try
	{
		result = operations[operation](numbers);
		Console.WriteLine($"Result: {result}");
		history.Add(new CalculationHistory
		{
			Operation = operation,
			Numbers = numbers,
			Result = result,
			Timestamp = DateTime.Now
		});

		HistoryManager.SaveHistory(history);
	}
	catch (DivideByZeroException ex)
	{
		Console.WriteLine(ex.Message);
		continue;
	}
}