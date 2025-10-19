using System;
class Calc
{
	public double a, b;
	public double Summ() => a + b;
	public double Minus() => a - b;
	public double X() => a * b;
	public double RR() => b != 0 ? a / b : double.NaN;
}

class Program
{
	static void Main(string[] args)
	{
		while (true)
		{
			Console.Clear();
			Console.WriteLine("Hello. Welcome to PizdecCoolProject!");
			Console.WriteLine("Choose your language:\n1. Russian 2.English\nPress E for exit");
			string lang = Console.ReadLine()?.Trim().ToLower();
			if (lang == "e") break;
			if (lang == "1") {
				RusMenu();
			}
			else if (lang == "2") {
				EngMenu();
			}
			else
			{
				Console.WriteLine("Unknown command. Press any key to try again.");
				Console.ReadKey();
			}
		}
		Console.Clear();
		Console.WriteLine("Goodbye. See you again <3");
	}

	static void RusMenu()
	{
		var calc = new Calc();

		while (true)
		{
			Console.Clear();
			Console.WriteLine("Добро пожаловать в PCP, выберите режим работы:");
			Console.WriteLine("1. Калькулятор\n2. Справка\n3. Сменить язык\n Menu для выхода");
			string RuMenu = Console.ReadLine()?.Trim().ToLower();
			Console.Clear();
			if (RuMenu == "1") {
				Console.WriteLine("Выберите действие:\n1. Сложение\n2. Вычитание\n3. Умножение\n4. Деление\nMenu для выхода");
				
				string RuCalc = Console.ReadLine()?.Trim().ToLower();
				if (RuCalc == "Menu" || RuCalc == "menu") break;

				Console.Clear();

				Console.WriteLine("Введите первое число");
				calc.a = double.Parse(Console.ReadLine());

				Console.WriteLine("Введите второе число");
				calc.b = double.Parse(Console.ReadLine());

				switch (RuCalc)
				{
					case "1":
						Console.WriteLine($"{calc.a} + {calc.b} = {calc.Summ()}");
						break;
					case "2":
                                                Console.WriteLine($"{calc.a} - {calc.b} = {calc.Minus()}");
                                                break;
					case "3":
                                                Console.WriteLine($"{calc.a} x {calc.b} = {calc.X()}");
                                                break;
					case "4":
						if (calc.b != 0) 
							Console.WriteLine($"{calc.a} : {calc.b} = {calc.RR()}");
						else 
							Console.WriteLine("На 0 делить нельзя!");
                                                break;
				}
				Console.WriteLine("\n Нажмите любую клавишу для продолжения...");
				Console.ReadKey();
			}
			else if (RuMenu == "2")
			{
				Console.Clear();
				Console.WriteLine("Справка");
				Console.WriteLine("PCP - это глобальный проект,в перспективе способный перевернуть многое, но пока что, мы ограничиваемя несчастным калькулятором :(");
				Console.WriteLine("PizdecCoolProject. Version Alpha 1.0");
				Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить");
				Console.ReadKey();
			}
			else if (RuMenu == "3")
			{
				break;
			}
			else
			{
				Console.WriteLine("Неизвестная команда, нажмите любую клавишу, чтобы продолжить");
				Console.ReadKey();
			}
		}
	}
	static void EngMenu()
		{
		var calc = new Calc();

		while (true)
		{
			Console.Clear();
			Console.WriteLine("Welcome to PCP. Choose mode:");
			Console.WriteLine("1. Calculator\n2. Help\n3. Main menu");
			string EnMenu = Console.ReadLine()?.Trim().ToLower();
			Console.Clear();
			if (EnMenu == "1") {
				Console.WriteLine("Choose an operation:\n1. Addiction\n2. Subtraction\n3. Multiplication\n4. Divition\nMenu - back");
				
				string EnCalc = Console.ReadLine()?.Trim().ToLower();
				if (EnCalc == "Menu" || EnCalc == "menu") break;

				Console.Clear();

				Console.WriteLine("Enter the 1st number");
				calc.a = double.Parse(Console.ReadLine());

				Console.WriteLine("Enter the 2nd number");
				calc.b = double.Parse(Console.ReadLine());

				switch (EnCalc)
				{
					case "1":
						Console.WriteLine($"{calc.a} + {calc.b} = {calc.Summ()}");
						break;
					case "2":
                                                Console.WriteLine($"{calc.a} - {calc.b} = {calc.Minus()}");
                                                break;
					case "3":
                                                Console.WriteLine($"{calc.a} x {calc.b} = {calc.X()}");
                                                break;
					case "4":
						if (calc.b != 0) 
							Console.WriteLine($"{calc.a} : {calc.b} = {calc.RR()}");
						else 
							Console.WriteLine("Error: Division by zero");
                                                break;
				}
				Console.WriteLine("\n Press any key to coninue...");
				Console.ReadKey();
			}
			else if (EnMenu == "2")
			{
				Console.Clear();
				Console.WriteLine("Help");
				Console.WriteLine("PCP’s a global thing that’s gonna flip the world one day, but for now — yeah, it’s just a sad lil’ calculator :(");
				Console.WriteLine("PizdecCoolProject. Version Alpha 1.0");
				Console.WriteLine("\nPress any key to continue");
				Console.ReadKey();
			}
			else if (EnMenu == "3")
			{
				break;
			}
			else
			{
				Console.WriteLine("Unknown command. Press any key to continue");
				Console.ReadKey();
			}
		}
	}
}

