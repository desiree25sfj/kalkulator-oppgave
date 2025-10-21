// handle operations using a dictionary instead of a switch/case-thingy

public static class OperationDictionary
{
	public static Dictionary<string, Func<List<double>, double>> GetOperations(Calculator calc)
	{
		return new Dictionary<string, Func<List<double>, double>>()
		{
			["add"] = nums => nums.Count == 2 ? calc.Add(nums[0], nums[1]) : calc.Add(nums),
			["subtract"] = nums => nums.Count == 2 ? calc.Subtract(nums[0], nums[1]) : calc.Subtract(nums),
			["multiply"] = nums => nums.Count == 2 ? calc.Multiply(nums[0], nums[1]) : calc.Multiply(nums),
			["divide"] = nums =>
			{
				if (nums.Contains(0) && nums.Count > 1) throw new DivideByZeroException("Cannot divide by zero.");
				return nums.Count == 2 ? calc.Divide(nums[0], nums[1]) : calc.Divide(nums);
			}
		};
	}
};