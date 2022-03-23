using System.Collections;
using ConsoleApp23.CodeGeneration.Models;

namespace ConsoleApp23.CodeGeneration.Internals;

internal sealed class CodeGenCollection<T> : ICodeGenEnumerableIndexed<T>, ICollection<T>
    where T : ICodeGenHasName
{
    private readonly List<T> _innerList;
    public CodeGenCollection() => this._innerList = new();
    public CodeGenCollection(IEnumerable<T> items) => this._innerList = new(items);
    public static CodeGenCollection<T> Create(IEnumerable<T> items) => new(items);

    public int Count => ((ICollection<T>)this._innerList).Count;

    public bool IsReadOnly => ((ICollection<T>)this._innerList).IsReadOnly;

    public T this[string name] => this._innerList.First(x => x.Name == name);

    public void Add(T item) => ((ICollection<T>)this._innerList).Add(item);
    public void Clear() => ((ICollection<T>)this._innerList).Clear();
    public bool Contains(T item) => ((ICollection<T>)this._innerList).Contains(item);
    public void CopyTo(T[] array, int arrayIndex) => ((ICollection<T>)this._innerList).CopyTo(array, arrayIndex);
    public IEnumerator<T> GetEnumerator() => this._innerList.GetEnumerator();
    public bool Remove(T item) => ((ICollection<T>)this._innerList).Remove(item);
    IEnumerator IEnumerable.GetEnumerator() => this._innerList.GetEnumerator();
}
