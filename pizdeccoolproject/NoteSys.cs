using System;
using System.Collections.Generic;
using System.IO;

public class NoteSys
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