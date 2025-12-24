using System;
using System.Collections.Generic;
using System.IO;
using modules;

class Settings
{
	public static string lang;
	public static int Attempts = 10;
}
class Module
{
    public static void ModStart()
    {
        var engine = new ModuleEngine("./modules");
        engine.QLoadModules();
    }
}
public class Program
{
	public static void Main(string[] args)
	{
		while (true)
		{
			Console.Clear();
			Console.WriteLine("Hello. Welcome to PizdecCoolProject!");
			Console.WriteLine("Choose your language:\n1.Russian 2.English 3.German\nPress E for exit");
			string lang = Console.ReadLine()?.Trim().ToLower();
			if (lang == "e") 
			{		
				Console.Clear();
				Console.WriteLine("Goodbye. See you again <3");
				Environment.Exit(0);
			}
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

	}

	public static void Menu()
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
				else if (Menu == "I" || Menu == "i")
                {
					Console.Clear();
                    CliSys.Start();
                }
				else if (Menu == "E" || Menu == "e")
				{
					Main([]);
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
	public static void Calc()
	{
		Console.Clear();
		CalcSys.Init();
		var calc = new CalcSys();
		Local.StartCode();

		while (true)
		{
			Console.WriteLine($"{Local.CalcMainTxt}");
                string Calc = Console.ReadLine()?.Trim().ToLower();
				var his = CalcSys.GetHis();
				
				if (Calc == "E" || Calc == "e") {
					Console.Clear();
					break;
				}
				else if (Calc == "H" || Calc == "h")
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
				else if (Calc == "1" || Calc == "2" || Calc == "3" || Calc == "4")
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
		Console.Clear();
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
			else if (Mode == "E" || Mode == "e") {
				Console.Clear();
				break;
			}
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
		Console.Clear();
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
