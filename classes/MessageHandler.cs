using System.IO;
using System.Text.Json;

public static class MessageHandler
{
	private static Dictionary<string, JsonElement> messages = new();

	public static void LoadMessages(string filePath)
	{
		if (!File.Exists(filePath))
		{
			Console.WriteLine("Messages file not found.");
			return;
		}

		string json = File.ReadAllText(filePath);
		messages = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json) ?? new Dictionary<string, JsonElement>();
	}

	public static string GetMessage(string key)
	{
		if (messages.ContainsKey(key))
		{
			if (messages[key].ValueKind == JsonValueKind.String)
				return messages[key].GetString() ?? "";
		}

		return $"[{key} not found]";
	}

	public static Dictionary<string, string> GetSubMessages(string key)
	{
		if (messages.ContainsKey(key) && messages[key].ValueKind == JsonValueKind.Object)
		{
			var dict = new Dictionary<string, string>();
			foreach (var prop in messages[key].EnumerateObject())
				dict[prop.Name] = prop.Value.GetString() ?? "";
			return dict;
		}
		return new Dictionary<string, string>();
	}
}