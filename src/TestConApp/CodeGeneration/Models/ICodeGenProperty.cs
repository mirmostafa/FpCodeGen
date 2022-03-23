namespace ConsoleApp23.CodeGeneration.Models;

public interface ICodeGenProperty : ICodeGenHasName, ICodeGenHasAccessibility, IHasParent<ICodeGenDataType>
{
    public bool HasGetter { get; }
    public bool HasSetter { get; }
    CodeGenPropertyKind Kind { get; }
    ICodeGenField? BackingField { get; }
    ICodeGenType Type { get; }
}

public interface ICodeGenAttribute : ICodeGenHasName
{
    ICodeGenEnumerableIndexed<(string PropertyName, string PropertyValue)> Properties { get; }
}