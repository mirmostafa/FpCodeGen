namespace ConsoleApp23.CodeGeneration.Models;

public interface ICodeGenField : ICodeGenHasName, ICodeGenHasAccessibility, ICodeGenHasModifier, IHasParent<ICodeGenDataType>
{
}
