public class CalculationHistory
{
	public string Operation { get; set; } = "";
	public List<double> Numbers { get; set; } = new();
	public double Result { get; set; }
	public DateTime Timestamp { get; set; } = DateTime.Now;
}