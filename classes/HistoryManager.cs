using System.IO;
using System.Text.Json;

public static class HistoryManager
{
	private static string filePath = "history.json";

	public static List<CalculationHistory> LoadRecords()
	{
		if (!File.Exists(filePath))
			return new List<CalculationHistory>();

		string json = File.ReadAllText(filePath);
		return JsonSerializer.Deserialize<List<CalculationHistory>>(json) ?? new List<CalculationHistory>();
	}

	public static void SaveHistory(List<CalculationHistory> history)
	{
		string json = JsonSerializer.Serialize(history, new JsonSerializerOptions { WriteIndented = true });
		File.WriteAllText(filePath, json);
	}
}