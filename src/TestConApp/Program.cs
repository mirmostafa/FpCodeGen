using ConsoleApp23.CodeGeneration.Helpers;
using ConsoleApp23.CodeGeneration.Providers;

var code = CodeGen
    .CreateNamespace("MyCodGenTests")
    .AddClass("Person")
    .Classes["Person"]
    .AddProperty("Name", CodeGen.ByType<string>())
    .AddProperty("Age", CodeGen.ByType<int>())
    .Parent
    .GenerateCode<CodeDomCodeGenerator>();
Console.WriteLine(code);