using System;
using System.Collections.Generic;
using System.IO;

class Calc
{
	public double a, b;
	public double Summ() => a + b;
	public double Minus() => a - b;
	public double X() => a * b;
	public double RR() => b != 0 ? a / b : double.NaN;
}

class Settings
{
	public static string lang;
}
class Local
{
	public static string MenuTxt;
	public static string CalcMainTxt;
	public static string Calc1NumTxt;
	public static string Calc2NumTxt;
	public static string Calc0Txt;
	public static string NoteTxt;
	public static string HelpTxt;
	public static string UnkTxt;
	public static string PressKey;

	public static void StartCode()
	{
		if (Settings.lang == "ru")
		{
			MenuTxt = "Добро пожаловать в PCP!\nВыберите режим работы:\n1. Калькулятор\n2. Заметки\nH. Справка\nE. Выход в меню";
			UnkTxt = "Неизвестная команда. Нажмите любую клавишу чтобы продолжить";
			CalcMainTxt = "Выберите действие:\n1. Сложение\n2. Вычитание\n3. Умножение\n4. Деление\nE. Выход в меню";
			Calc1NumTxt = "Введите первое число";
			Calc2NumTxt = "Введите второе число";
			Calc0Txt = "Ошибка: деление на ноль!";
			PressKey = "Нажмите любую клавишу для продолжения";
			HelpTxt = "Справка\nPCP - это глобальный проект,в перспективе способный перевернуть многое, но пока что, мы ограничиваемя несчастным калькулятором :(\nPizdecCoolProject. Version Alpha 1.0.1\nНажмите любую клавишу чтобы продолжить";
		}
		else if (Settings.lang == "en")
		{
			MenuTxt = "Welcome to PCP!\nChoose mode:\n1. Calculator\n2. Notes\nH. Help\nE. Main menu";
			UnkTxt = "Unknown command. Press any key to continue";
			CalcMainTxt = "Choose an operation:\n1. Addiction\n2. Subtraction\n3. Multiplication\n4. Divition\nE. Back";
			Calc1NumTxt = "Enter the 1st number";
			Calc2NumTxt = "Enter the 2nd number";
			Calc0Txt = "Error: Divition by zero!";
			PressKey = "Press any key to continue";
			HelpTxt = "Help\nPCP’s a global thing that’s gonna flip the world one day, but for now — yeah, it’s just a sad lil’ calculator :(\nPizdecCoolProject. Version Alpha 1.0.1\nPress any key to continue";
		}
		else
		{
               		Settings.lang = "err";
		}
	}	
}

class NotesSys
{
}
class Program
{
	static void Main(string[] args)
	{
		while (true)
		{
			Console.Clear();
			Console.WriteLine("Hello. Welcome to PizdecCoolProject!");
			Console.WriteLine("Choose your language:\n1.Russian 2.English\nPress E for exit");
			string lang = Console.ReadLine()?.Trim().ToLower();
			if (lang == "e") break;
			if (lang == "1") {
				Settings.lang = "ru";
				Menu();
			}
			else if (lang == "2") {
				Settings.lang = "en";
				Menu();
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

	static void Menu()
	{
		Local.StartCode();
		while (true)
		{
			if (Settings.lang != "err")
			{
				Console.Clear();
				Console.WriteLine($"{Local.MenuTxt}");
				string Menu = Console.ReadLine()?.Trim().ToLower();
				Console.Clear();
				if (Menu == "1")
				{
					Calc();			
				}
				else if (Menu == "2")
				{
					Notes();
				}
				else if (Menu == "H" || Menu == "h")
				{
					Console.Clear();
					Console.WriteLine($"{Local.HelpTxt}");
					Console.ReadKey();
				}
				else if (Menu == "E" || Menu == "e")
				{
					break;
				}
				else
				{
					Console.WriteLine($"{Local.UnkTxt}");
					Console.ReadKey();
				}
			}
			else {
				Console.WriteLine("Произошла непредвиденная ошибка. Нажмите любую клавишу чтобы продолжить.\nAn unexpected error has occurred. Press any key to continue.");
				Console.ReadKey();
				Environment.Exit(0);
			}
		}
	}
	static void Calc()
	{
		var calc = new Calc();
		Local.StartCode();

		while (true)
		{
			Console.WriteLine($"{Local.CalcMainTxt}");
                               	string Calc = Console.ReadLine()?.Trim().ToLower();

				if (Calc == "E" || Calc == "e") break;
			{
                               	Console.Clear();

				if (Calc == "1" || Calc == "2" || Calc == "3" || Calc == "4")
                                {

					Console.WriteLine($"{Local.Calc1NumTxt}");
                     			calc.a = double.Parse(Console.ReadLine());

                               		Console.WriteLine($"{Local.Calc2NumTxt}");
					calc.b = double.Parse(Console.ReadLine());

                               		switch (Calc)
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
								Console.WriteLine($"{Local.Calc0Txt}");
							break;
					}
				}
				else
				{
					Console.WriteLine($"{Local.UnkTxt}");
				}
				Console.WriteLine($"{Local.PressKey}");
				Console.ReadKey();
				Console.Clear();
			}
		}
	}

        static string filePath = "PCPN";
        public static List<string> notes = new List<string>();
	
	public static void Notes()
	{
		Local.StartCode();
		while (true)
		{
			Console.WriteLine("В разработке/In developement");
			Console.WriteLine($"{Local.PressKey}");
			Console.ReadKey();
			break;
		}
	}
}
