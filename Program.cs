MessageHandler.LoadMessages("data/messages.json");
Console.WriteLine(MessageHandler.GetMessage("welcome"));

Calculator calc = new Calculator();
var operations = OperationDictionary.GetOperations(calc);
List<CalculationHistory> history = HistoryManager.LoadHistory();

while (true)
{
	Console.WriteLine();
	Console.WriteLine(MessageHandler.GetMessage("prompt"));

	string? operation = Console.ReadLine()?.ToLower();
	if (string.IsNullOrWhiteSpace(operation))
	{
		Console.WriteLine(MessageHandler.GetSubMessages("errors")["invalidInput"]);
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

	if (operation == "exit")
	{
		Console.WriteLine(MessageHandler.GetMessage("exitMessage"));
		break;
	}

	if (operation == "history")
	{
		if (history.Count == 0)
		{
			Console.WriteLine(MessageHandler.GetSubMessages("history")["empty"]);
		}
		else
		{
			foreach (var record in history)
			{
				string nums = string.Join(", ", record.Numbers);
				Console.WriteLine($"{record.Timestamp}: {record.Operation}({nums}) = {record.Result}");
			}
		}
		continue;
	}

	if (operation == "clear history")
	{
		HistoryManager.ClearHistory(history);
		Console.WriteLine(MessageHandler.GetSubMessages("clearHistory")["confirmation"]);
		continue;
	}

	if (!operations.ContainsKey(operation))
	{
		Console.WriteLine(MessageHandler.GetSubMessages("errors")["invalidOperation"]);
		continue;
	}

	Console.WriteLine(MessageHandler.GetMessage("promptNumbers"));
	string? input = Console.ReadLine();
	if (string.IsNullOrWhiteSpace(input))
	{
		Console.WriteLine(MessageHandler.GetSubMessages("errors")["noNumbers"]);
		continue;
	}

	List<double> numbers = InputHandler.ParseNumbers(input);
	if (numbers.Count == 0)
	{
		Console.WriteLine(MessageHandler.GetSubMessages("errors")["noNumbers"]);
		continue;
	}

	double result;
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
	catch (DivideByZeroException)
	{
		Console.WriteLine(MessageHandler.GetSubMessages("errors")["divideByZero"]);
	}
}