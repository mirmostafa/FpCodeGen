namespace ConsoleApp23.CodeGeneration.Models;

public interface IHasParent<T>
{
    T Parent { get; }
}
