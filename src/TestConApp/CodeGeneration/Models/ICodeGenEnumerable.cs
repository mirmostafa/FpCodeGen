namespace ConsoleApp23.CodeGeneration.Models;

public interface ICodeGenEnumerableIndexed<out T> : IEnumerable<T>
{
    T this[string name] { get; }
}
