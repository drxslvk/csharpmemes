using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System.Reflection;
using System.Runtime.Loader;

namespace modules;

public interface XModule
{
    string Name {  get; }
    string Description { get; }
    void Execute();
}
public class ModuleEngine
{
    private readonly string modulePath;
    private readonly List<XModule> loadedModules = new();

    public IReadOnlyList<XModule> LoadedModules => loadedModules.AsReadOnly();

    public ModuleEngine(string modulePath)
    {
        this.modulePath = modulePath;
        
        if (!Directory.Exists(modulePath)) Directory.CreateDirectory(modulePath);
    }
    public void QLoadModules()
    {
        loadedModules.Clear();

        var csFiles = Directory.GetFiles(modulePath, "*.cs", SearchOption.AllDirectories);
        foreach (var file in csFiles)
        {
            try
            {
                var module = CompileAndLoad(file);
                if (module != null)
                {
                    loadedModules.Add(module);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в {Path.GetFileName(file)}: {ex.Message}");
                Console.WriteLine(Local.PressKey);
            }
        }
    }
    private XModule? CompileAndLoad(string filePath)
    {
        var sourceCode = File.ReadAllText(filePath);
        var syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);
        
        // имя сборки
        var assemblyName = Path.GetFileNameWithoutExtension(filePath);
        
        // references на нужные dll
        var references = new[]
        {
            MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(Console).Assembly.Location),
            MetadataReference.CreateFromFile(typeof(XModule).Assembly.Location),
            MetadataReference.CreateFromFile(Assembly.Load("System.Runtime").Location),
            MetadataReference.CreateFromFile(Assembly.Load("System.Collections").Location),
            MetadataReference.CreateFromFile(Assembly.Load("netstandard").Location)
        };
        
        // опции компиляции
        var compilation = CSharpCompilation.Create(
            assemblyName,
            new[] { syntaxTree },
            references,
            new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary)
        );
        
        // компилим в память
        using var ms = new MemoryStream();
        EmitResult result = compilation.Emit(ms);
        
        if (!result.Success)
        {
            // выводим ошибки компиляции
            var errors = result.Diagnostics
                .Where(d => d.Severity == DiagnosticSeverity.Error)
                .Select(d => d.GetMessage());
            
            throw new Exception($"Ошибки компиляции:\n{string.Join("\n", errors)}");
        }
        
        // загружаем скомпиленную сборку
        ms.Seek(0, SeekOrigin.Begin);
        var assembly = AssemblyLoadContext.Default.LoadFromStream(ms);
        
        // ищем классы, реализующие IModule
        var moduleType = assembly.GetTypes()
            .FirstOrDefault(t => typeof(XModule).IsAssignableFrom(t) && !t.IsInterface);
        
        if (moduleType == null)
            throw new Exception("Не найден класс, реализующий XModule");
        
        // создаем экземпляр
        return Activator.CreateInstance(moduleType) as XModule;
    }
    
    public void RunModule(string name)
    {
        var module = loadedModules.FirstOrDefault(m => 
            m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        
        if (module == null)
        {
            Console.WriteLine($"Модуль '{name}' не найден");
            return;}
        
        Console.WriteLine($"Запуск модуля: {module.Name}");
        module.Execute();
    }
    
    public void RunAllModules()
    {
        foreach (var module in loadedModules)
        {
            RunModule(module.Name);
        }
    }
    
    public void ListModules()
    {
        Console.WriteLine("Доступные модули:");
        foreach (var module in loadedModules)
        {
            Console.WriteLine($"  • {module.Name} - {module.Description}");
        }
        Console.WriteLine();
    }
}
