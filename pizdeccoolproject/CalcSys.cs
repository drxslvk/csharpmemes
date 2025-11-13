using System;
using System.Collections.Generic;
using System.IO;

public class CalcSys
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