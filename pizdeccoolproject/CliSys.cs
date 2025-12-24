using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;
using modules;
public class CliSys
{
    public static void Start()
    {        
        var engine = new ModuleEngine("./modules");
        Console.WriteLine("CLI-mode");
        while (true) {
            Console.Write(">");
            string cli = Console.ReadLine();
            if (cli == "exit")
            {
                Console.Clear();
                Environment.Exit(0);
            }
            while (true)
            {
                if (cli == "help")
                {  
                    Console.WriteLine("Список комманд");
                    break;
                }
                else if (cli == "calc")
                {
                    Program.Calc();
                    break;
                }
                else if (cli == "menu")
                {
                    Console.Clear();
                    Program.Menu();
                    break;
                }
                  else if (cli == "notes")
                {
                    Console.Clear();
                    Program.Notes();
                    break;
                }
                else if (cli == "game")
                {
                    Console.Clear();
                    Program.MiniGame();
                    break;
                }
                else if (cli.StartsWith("setlang "))
                {
                    string Lang = cli.Substring(8);
                    if (Lang == "ru" || Lang == "en" || Lang == "ge")
                    {
                        Settings.lang = Lang;
                        Local.StartCode();
                        Console.WriteLine(Local.LangChCLI);
                    }
                    else 
                    {
                        Console.WriteLine(Local.UnkTxt, Local.PressKey);
                        Console.ReadKey();
                        Console.WriteLine();
                    }
                    break;
                }
                else if (cli.StartsWith("module "))
                {
                    string moduleName = cli.Substring(7);
                    if (moduleName == "list")
                    {
                        engine.QLoadModules();
                        engine.ListModules();
                    }
                    else engine.RunModule(moduleName);
                    break;
                }
                else if (cli == "clear")
                {
                    Console.Clear();
                    break;
                }
                else 
                {
                    Console.WriteLine(Local.UnkTxt, Local.PressKey);
                    Console.ReadKey();
                    Console.WriteLine();
                    break;
                }
            }
        } 
    }
}
