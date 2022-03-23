using System.Text;
using ConsoleApp23.CodeGeneration.Helpers;
using ConsoleApp23.CodeGeneration.Models;

namespace ConsoleApp23.CodeGeneration.Internals;

internal sealed record CodeGenClass(string Name, CodeGenAccessibility Accessibilities, CodeGenNamespace Parent) : ICodeGenClass
{
    public CodeGenCollection<CodeGenProperty> Properties { get; } = new CodeGenCollection<CodeGenProperty>();
    ICodeGenNamespace IHasParent<ICodeGenNamespace>.Parent => this.Parent;
    ICodeGenEnumerableIndexed<ICodeGenProperty> ICodeGenClass.Properties => this.Properties;
}

internal sealed record CodeGenProperty(string Name, CodeGenAccessibility Accessibilities, CodeGenPropertyKind Kind, CodeGenField? BackingField, ICodeGenDataType Parent, bool HasGetter, bool HasSetter, CodeGenType Type)
    : ICodeGenProperty
{
    ICodeGenField? ICodeGenProperty.BackingField => this.BackingField;

    ICodeGenType ICodeGenProperty.Type => this.Type;
}

internal sealed record CodeGenAttribute(string Name) : ICodeGenAttribute
{
    public ICodeGenEnumerableIndexed<(string PropertyName, string PropertyValue)> Properties { get; } = new CodeGenCollection<(string PropertyName, string PropertyValue)>();
}

internal sealed record CodeGenType(string Name, CodeGenAccessibility Accessibilities, CodeGenNamespace Parent) : ICodeGenType
{
    ICodeGenNamespace IHasParent<ICodeGenNamespace>.Parent => this.Parent;
}

internal static class CodePathHelper
{
    public static string NamespaceByType<TType>() => NamespaceByTypeFullName(typeof(TType).FullName);
    public static string NamespaceByType(Type type) => NamespaceByTypeFullName(type.FullName);
    public static string NamespaceByTypeFullName(string typeFullName)
    {
        var slices = typeFullName.Split('.').ToList();
        return slices.Take(slices.Count - 1).Merge();
    }
    public static string Merge(this IEnumerable<string> strs, string separator = ".")
    {
        StringBuilder buffer = new();
        foreach (var str in strs)
        {
            _ = buffer.Append(str).Append(separator);
        }
        return buffer.ToString();
    }
}

internal sealed record CodeGenField(string Name, CodeGenAccessibility Accessibilities, CodeGenModifier Modifiers, ICodeGenDataType Parent) : ICodeGenField;

internal sealed record CodeGenNamespace(string Name) : ICodeGenNamespace
{
    public CodeGenCollection<ICodeGenType> Types { get; } = new CodeGenCollection<ICodeGenType>();
    public ICodeGenEnumerableIndexed<ICodeGenClass> Classes => this.Types.Where(x => x is ICodeGenClass).Cast<ICodeGenClass>().Convert<ICodeGenClass>();

    ICodeGenEnumerableIndexed<ICodeGenType> ICodeGenNamespace.Types => this.Types;
}
