using System;
using System.Collections.Generic;
using System.IO;
using modules;
public class CalcModSys
{
	private static string filePath = "calchis.pcp";
	private static List<string> calchis = new List<string>();
	
	public string Result;

	public double a, b;
	public double Summ() => a + b;
	public double Minus() => a - b;
	public double X() => a * b;
	public double RR() => b != 0 ? a / b : double.NaN;
}
public class CalcMod : XModule
{
    public string Name => "Calc Module";
    public string Description => "Калькулятор";
    public void Execute() 
    {
		Console.Clear();
		var calc = new CalcModSys();
		Local.StartCode();

		while (true)
		{
			Console.WriteLine($"{Local.CalcMainTxt}");
                string Calc = Console.ReadLine()?.Trim().ToLower();
				
				if (Calc == "E" || Calc == "e") {
					Console.Clear();
					break;
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
							break;
						case "2":
							calc.Result = $"{calc.a} - {calc.b} = {calc.Minus()}";
							Console.WriteLine(calc.Result);
							break;
						case "3":
							calc.Result = $"{calc.a} x {calc.b} = {calc.X()}";
							Console.WriteLine(calc.Result);
							break;
						case "4":
							if (calc.b != 0)
							{
								calc.Result = $"{calc.a} : {calc.b} = {calc.RR()}";
								Console.WriteLine(calc.Result);
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
}