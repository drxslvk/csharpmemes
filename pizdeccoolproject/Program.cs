using System;
using System.Collections.Generic;
using System.IO;

class CalcSys
{
	private static string filePath = "calchis.pcp";
	private static List<string> calchis = new List<string>();
	
	public string Result;

	public static void Init()
	{
		if (!File.Exists(filePath))
			File.WriteAllText(filePath, "");

		calchis = new List<string>(File.ReadAllLines(filePath));
	}
	
	public static List<string> GetHis()
	{
		return new List<string>(calchis);
	}

	public void Add(string text)
	{
		if (string.IsNullOrWhiteSpace(text)) return;
		calchis.Add(text);
		File.AppendAllText(filePath, text + "\n");
	}

	public double a, b;
	public double Summ() => a + b;
	public double Minus() => a - b;
	public double X() => a * b;
	public double RR() => b != 0 ? a / b : double.NaN;
}

class Settings
{
	public static string lang;
	public static int Attempts = 10;
}
class Local
{
	public static string MenuTxt = "";
	public static string CalcMainTxt = "";
	public static string Calc1NumTxt = "";
	public static string Calc2NumTxt = "";
	public static string Calc0Txt = "";
	public static string CalcHis0 = "";
	public static string NoteTxt = "";
	public static string Note0 = "";
	public static string NoteSave = "";
	public static string NoteInputTxt = "";
	public static string NoteDel = "";
	public static string NoteDelFail = "";
	public static string NoteDelSuc = "";
	public static string NoteDelErr = "";	
	public static string HelpTxt = "";
	public static string UnkTxt = "";
	public static string PressKey = "";
	public static string GameNumIntroTxt = "";
	public static string GameNumInputTxt = "";
	public static string GameNumAttLessTxt = "";
	public static string GameNumAttMoreTxt = "";
	public static string GameNumWinTxt = "";
	public static string GameNumLoseTxt = "";
	public static string GameNumAttCounterTxt = "";

	public static void StartCode()
	{
		if (Settings.lang == "ru")
		{
			MenuTxt = "Добро пожаловать в PCP!\nВыберите режим работы:\n1. Калькулятор\n2. Заметки\n3. Мини-игра \nH. Справка\nE. Выход в меню";
			UnkTxt = "Неизвестная команда. Нажмите любую клавишу чтобы продолжить";
			CalcMainTxt = "Выберите действие:\n1. Сложение\n2. Вычитание\n3. Умножение\n4. Деление\nH. История вычислений\nE. Выход в меню";
			Calc1NumTxt = "Введите первое число";
			Calc2NumTxt = "Введите второе число";
			Calc0Txt = "Ошибка: деление на ноль!";
			CalcHis0 = "История не обнаружена";
			PressKey = "Нажмите любую клавишу для продолжения";
			NoteTxt = "Заметки\n\n1. Показать все\n2. Добавить\n3. Удалить\nE. Выход в меню";
			Note0 = "Заметки не обнаружены";
			NoteSave = "Сохранено";
			NoteDel = "Введите номер удаляемой заметки";
			NoteDelFail = "Заметка не обнаружена";
			NoteDelSuc = "Заметка удалена";
			NoteDelErr = "Ошибка. Введите номер заметки";
			NoteInputTxt = "Введите текст заметки";
			HelpTxt = "Справка\nPCP - это глобальный проект,в перспективе способный перевернуть многое, но пока что, мы ограничиваемся несчастными калькулятором и заметками :(\nPizdecCoolProject. Version Alpha 1.1\nНажмите любую клавишу чтобы продолжить";
			GameNumIntroTxt = "Угадай число от 1 до 500! У тебя есть 10 попыток.";
			GameNumInputTxt = "Введи число: ";
			GameNumAttLessTxt = "Меньше!";
			GameNumAttMoreTxt = "Больше!";
			GameNumAttCounterTxt = $"Попыток осталось: {Settings.Attempts}";
			GameNumWinTxt = "Поздравляю! Ты угадал число!";
			GameNumLoseTxt = "Ты проиграл! Загаданное число было: ";
		}
		else if (Settings.lang == "en")
		{
			MenuTxt = "Welcome to PCP!\nChoose mode:\n1. Calculator\n2. Notes\n3. Mini game\nH. Help\nE. Main menu";
			UnkTxt = "Unknown command. Press any key to continue";
			CalcMainTxt = "Choose an operation:\n1. Addiction\n2. Subtraction\n3. Multiplication\n4. Divition\nH. Calculating history\nE. Back";
			Calc1NumTxt = "Enter the 1st number";
			Calc2NumTxt = "Enter the 2nd number";
			Calc0Txt = "Error: Divition by zero!";
			CalcHis0 = "No calculation history found";
			PressKey = "Press any key to continue";
			NoteTxt = "Notes\n\n1. Show all\n2. Add new\n3. Remove note\nE. Back";
			Note0 = "No notes found";
			NoteSave = "Done";
			NoteDel = "Enter the number of the note to delete";
			NoteDelFail = "Note not found";
			NoteDelSuc = "Note deleted";
			NoteDelErr = "Error. Enter a note number";
			NoteInputTxt = "Input text";
			HelpTxt = "Help\nPCP’s a global thing that’s gonna flip the world one day, but for now — yeah, it’s just a sad lil’ calculator and notes :(\nPizdecCoolProject. Version Alpha 1.1\nPress any key to continue";
			GameNumIntroTxt = "Guess a number between 1 and 500! You have 10 attempts.";
			GameNumInputTxt = "Enter number: ";
			GameNumAttLessTxt = "Less!";
			GameNumAttMoreTxt = "More!";
			GameNumAttCounterTxt = $"Attempts left: {Settings.Attempts}";
			GameNumWinTxt = "Congratulations! You guessed the number!";
			GameNumLoseTxt = "You lost! The number was: ";
		}
		else if (Settings.lang == "ge")
		{
			MenuTxt = "Willkommen bei PCP!\nWählen Sie den Modus: \n1. Rechner\n2. Anmerkungen\n3. Minispiel\nH. Hilfe\nE. Hauptmenü";
			UnkTxt = "Unbekannter Befehl. Drücken Sie eine beliebige Taste, um fortzufahren";
			CalcMainTxt = "Wählen Sie eine Operation:\n1. Sucht\n2. Subtraktion\n3. Multiplikation\n4. Abteilung \nH. Geschichte der Berechnung\nE. Zurück";
			Calc1NumTxt = "Geben Sie die 1. Zahl ein";
			Calc2NumTxt = "Geben Sie die 2. Zahl ein";
			Calc0Txt = "Fehler: Division durch Null!";
			CalcHis0 = "Der Berechnungsverlauf wurde nicht gefunden";
			PressKey = "Drücken Sie eine beliebige Taste, um fortzufahren";
			NoteTxt = "Anmerkungen\n\n1. Alle anzeigen\n2. Neues\n3. Notiz entfernen\nE. Zurück";
			Note0 = "Keine Notizen gefunden";
			NoteSave = "Erfolgen";
			NoteDel = "Geben Sie die Nummer der zu löschenden Notiz ein";
			NoteDelFail = "Notiz nicht gefunden";
			NoteDelSuc = "Notiz gelöscht";
			NoteDelErr = "Fehlermeldung. Geben Sie eine Notiznummer ein";
			NoteInputTxt = "Eingabetext";
			HelpTxt = "Hilfe\nPCP ist eine globale Sache, die eines Tages die Welt verändern wird, aber für den Moment — ja, es ist nur ein trauriger kleiner Taschenrechner und Notizen :(\nPizdecCoolProjekt. Version Alpha 1.1\nDrücken Sie eine beliebige Taste, um fortzufahren";
			GameNumIntroTxt = "Erraten Sie eine Zahl zwischen 1 und 500! Sie haben 10 Versuche.";
			GameNumInputTxt = "Nummer eingeben: ";
			GameNumAttLessTxt = "Weniger!";
			GameNumAttMoreTxt = "Mehr!";
			GameNumAttCounterTxt = $"Verbleibende Versuche: {Settings.Attempts}";
			GameNumWinTxt = "Herzlichen Glückwunsch! Sie haben die Zahl erraten!";
			GameNumLoseTxt = "Du hast verloren! Die Zahl war: ";
		}
		else
		{
			Settings.lang = "err";
		}
	}	
}

class NoteSys
{
	private static string filePath = "notes.pcp";
	private static List<string> notes = new List<string>();

	public static void Init()
	{
		if (!File.Exists(filePath))
			File.WriteAllText(filePath, "");

		notes = new List<string>(File.ReadAllLines(filePath));
	}
	
	public static List<string> GetNotes()
	{
		return new List<string>(notes);
	}

	public static void Add(string text)
	{
		if (string.IsNullOrWhiteSpace(text)) return;
		notes.Add(text);
		File.AppendAllText(filePath, text + "\n");
	}

	public static bool Delete(int index)
	{
		if (index < 0 || index >= notes.Count) return false;

		notes.RemoveAt(index);
		File.WriteAllLines(filePath, notes);
		return true;
	}
}
class Program
{
	static void Main(string[] args)
	{
		while (true)
		{
			Console.Clear();
			Console.WriteLine("Hello. Welcome to PizdecCoolProject!");
			Console.WriteLine("Choose your language:\n1.Russian 2.English 3.German\nPress E for exit");
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
			else if (lang == "3") {
				Settings.lang  = "ge";
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
				else if (Menu == "3")
				{
					MiniGame();
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
		CalcSys.Init();
		var calc = new CalcSys();
		Local.StartCode();

		while (true)
		{
			Console.WriteLine($"{Local.CalcMainTxt}");
                               	string Calc = Console.ReadLine()?.Trim().ToLower();
				var his = CalcSys.GetHis();
				
				if (Calc == "E" || Calc == "e") break;
				if (Calc == "H" || Calc == "h")
				{
					Console.Clear();
					if (his.Count == 0)
					{
					Console.WriteLine($"{Local.CalcHis0}");
					}
					else
					{
					for (int i = 0; i < his.Count; i++)
					Console.WriteLine($"{i+1}. {his[i]}");
					}
				}


				if (Calc == "1" || Calc == "2" || Calc == "3" || Calc == "4")
                                {
					Console.Clear();

					Console.WriteLine($"{Local.Calc1NumTxt}");
                     			calc.a = double.Parse(Console.ReadLine());

                               		Console.WriteLine($"{Local.Calc2NumTxt}");
					calc.b = double.Parse(Console.ReadLine());

                               		switch (Calc)
                               		{
                                       		case "1":
							calc.Result = $"{calc.a} + {calc.b} = {calc.Summ()}";
							Console.WriteLine(calc.Result);
							calc.Add($"{calc.Result}		<{DateTime.Now}>");
							break;
						case "2":
							calc.Result = $"{calc.a} - {calc.b} = {calc.Minus()}";
							Console.WriteLine(calc.Result);
							calc.Add($"{calc.Result}		<{DateTime.Now}>");
							break;
						case "3":
							calc.Result = $"{calc.a} x {calc.b} = {calc.X()}";
							Console.WriteLine(calc.Result);
							calc.Add($"{calc.Result}		<{DateTime.Now}>");
							break;
						case "4":
							if (calc.b != 0)
							{
								calc.Result = $"{calc.a} : {calc.b} = {calc.RR()}";
								Console.WriteLine(calc.Result);
								calc.Add($"{calc.Result}		<{DateTime.Now}>");
							}
							else
								Console.WriteLine($"{Local.Calc0Txt}");
							break;
					}
				}
				else if (Calc == "h" || Calc =="H")
				{
					Console.WriteLine();
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

        static string filePath = "PCPN";
        public static List<string> notes = new List<string>();
	
	public static void Notes()
	{
		Local.StartCode();
		NoteSys.Init();

		while (true)
		{
			Console.Clear();
			Console.WriteLine($"{Local.NoteTxt}");
			
			string Mode = Console.ReadLine()?.Trim().ToLower();

			if (Mode == "1") ShowNotes();
			else if (Mode == "2") AddNote();
			else if (Mode == "3") DelNote();
			else if (Mode == "E" || Mode == "e") break;
			else
			{
				Console.WriteLine($"{Local.UnkTxt}");
				Console.ReadKey();
			}
		}
	}
	static void ShowNotes()
	{
		NoteSys.Init();
		Local.StartCode();
		Console.Clear();
		var notes = NoteSys.GetNotes();
		if (notes.Count == 0)
		{
			Console.WriteLine($"{Local.Note0}");
		}
		else
		{
			for (int i = 0; i < notes.Count; i++)
				Console.WriteLine($"{i+1}. {notes[i]}");
		}
		Console.WriteLine($"\n{Local.PressKey}");
		Console.ReadKey();
	}

	static void AddNote()
	{
		NoteSys.Init();
		Console.Clear();
		Console.WriteLine($"{Local.NoteInputTxt}\n");
		string NoteText = Console.ReadLine();
		NoteSys.Add($"{NoteText}		<{DateTime.Now}>");
		Console.WriteLine($"{Local.NoteSave}. {Local.PressKey}");
		Console.ReadKey();
	}
	static void DelNote()
	{
		NoteSys.Init();
		Console.Clear();
		var notes = NoteSys.GetNotes();
		if (notes.Count == 0)
		{
			Console.WriteLine($"{Local.Note0}. {Local.PressKey}");
			Console.ReadKey();
			return;
		}

		for (int i = 0; i < notes.Count; i++)
			Console.WriteLine($"{i + 1}. {notes[i]}");

		Console.WriteLine($"\n{Local.NoteDel}");
		if (int.TryParse(Console.ReadLine(), out int num))
		{
			bool ok = NoteSys.Delete(num - 1);
			Console.WriteLine(ok ? $"{Local.NoteDelSuc}. {Local.PressKey}" : $"{Local.NoteDelFail}. {Local.PressKey}");
		}
		else
		{
			Console.WriteLine($"{Local.NoteDelErr}. {Local.PressKey}");
		}
		Console.ReadKey();
	}
	public static void MiniGame()
	{
		Settings.Attempts = 10;
		Local.StartCode();
		Console.Clear();
		Random rand = new Random();
		int GameNum = rand.Next(1, 500);
		Console.WriteLine($"{Local.GameNumIntroTxt}");
		while (true)
        {
			if (Settings.Attempts > 0)
			{
				if (int.TryParse(Console.ReadLine(), out int UserNum))
				{
					if (UserNum == GameNum)
					{
						Console.Clear();
						Console.WriteLine($"{Local.GameNumWinTxt}");
						Console.WriteLine($"{Local.PressKey}");
						Console.ReadKey();
						break;
					}
					else if (UserNum < GameNum)
					{
						Settings.Attempts--;
						Local.StartCode();
						Console.Clear();
						Console.Write($"{Local.GameNumAttMoreTxt} ");
						Console.WriteLine($"{Local.GameNumAttCounterTxt}");
						Console.WriteLine($"{Local.GameNumInputTxt}");
					}
					else if (UserNum > GameNum)
					{
						Settings.Attempts--;
						Local.StartCode();
						Console.Clear();
						Console.Write($"{Local.GameNumAttLessTxt} ");
						Console.WriteLine($"{Local.GameNumAttCounterTxt}");
						Console.WriteLine($"{Local.GameNumInputTxt}");
					}
				}
				else
				{
					Console.WriteLine($"{Local.UnkTxt}");
					Console.ReadKey();
				}
			}
			else
			{
				Console.Clear();
				Console.WriteLine($"{Local.GameNumLoseTxt} {GameNum}");
				Console.WriteLine($"{Local.PressKey}");
				Console.ReadKey();
				break;
            }
        }
    }
}
