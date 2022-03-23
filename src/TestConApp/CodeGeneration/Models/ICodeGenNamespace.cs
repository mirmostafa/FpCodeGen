namespace ConsoleApp23.CodeGeneration.Models;

public interface ICodeGenNamespace : ICodeGenHasName
{
    ICodeGenEnumerableIndexed<ICodeGenType> Types { get; }
    ICodeGenEnumerableIndexed<ICodeGenClass> Classes { get; }
}
