namespace ConsoleApp23.CodeGeneration.Models;

public interface ICodeGenClass : ICodeGenDataType
{
    ICodeGenEnumerableIndexed<ICodeGenProperty> Properties { get; }
}
