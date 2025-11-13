using System;
using System.Collections.Generic;
using System.IO;

public class Local
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