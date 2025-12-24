using System;
using modules;

public class HelloWorld : XModule
{
    public string Name => "Hello World";
    public string Description => "Тестовый модуль";
    public void Execute() 
    {
        Console.WriteLine("Hello World");
    }
}