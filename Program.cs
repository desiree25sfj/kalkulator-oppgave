Console.WriteLine("Welcome to the Overloaded Calculator!");

// Temporary code to test

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
Console.WriteLine($"Divide(List) = {divList}");