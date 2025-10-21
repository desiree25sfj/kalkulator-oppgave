using System.IO;
using System.Text.Json;

public static class HistoryManager
{
	private static string folderPath = "data";
	private static string filePath = Path.Combine(folderPath, "history.json");

	public static List<CalculationHistory> LoadHistory()
	{
		Directory.CreateDirectory(folderPath);

		if (!File.Exists(filePath))
			return new List<CalculationHistory>();

		string json = File.ReadAllText(filePath);
		return JsonSerializer.Deserialize<List<CalculationHistory>>(json) ?? new List<CalculationHistory>();
	}

	public static void SaveHistory(List<CalculationHistory> history)
	{
		Directory.CreateDirectory(folderPath);

		string json = JsonSerializer.Serialize(history, new JsonSerializerOptions { WriteIndented = true });
		File.WriteAllText(filePath, json);
	}

	public static void ClearHistory(List<CalculationHistory> history)
	{
		history.Clear();

		if (File.Exists(filePath))
		{
			File.Delete(filePath);
		}
	}
}