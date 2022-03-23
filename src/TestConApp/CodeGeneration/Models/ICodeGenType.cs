using ConsoleApp23.CodeGeneration.Internals;

namespace ConsoleApp23.CodeGeneration.Models;

public interface ICodeGenType : ICodeGenHasName, ICodeGenHasAccessibility, IHasParent<ICodeGenNamespace>
{
}
