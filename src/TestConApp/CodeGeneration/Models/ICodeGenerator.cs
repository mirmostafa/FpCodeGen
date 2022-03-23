namespace ConsoleApp23.CodeGeneration.Models;

public interface ICodeGenerator
{
    Code Generate(ICodeGenNamespace codeGenNamespace);
}
