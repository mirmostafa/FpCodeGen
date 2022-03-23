using ConsoleApp23.CodeGeneration.Internals;
using ConsoleApp23.CodeGeneration.Models;

namespace ConsoleApp23.CodeGeneration.Helpers;

public static class CodeGen
{
    public static ICodeGenNamespace CreateNamespace(string name) =>
        new CodeGenNamespace(name);
    public static ICodeGenNamespace AddClass(this ICodeGenNamespace codeGenNamespace, string name, CodeGenAccessibility accessibilitie = CodeGenAccessibility.Internal)
    {
        var ns = codeGenNamespace.As<CodeGenNamespace>();
        var result = new CodeGenClass(name, accessibilitie, ns);
        ns.Types.Add(result);
        return ns;
    }
    public static ICodeGenClass AddProperty(this ICodeGenClass codeGenClass,
                                            string name,
                                            ICodeGenType type,
                                            CodeGenAccessibility accessibilities = CodeGenAccessibility.Public,
                                            CodeGenPropertyKind kind = CodeGenPropertyKind.Auto,
                                            ICodeGenField? backingField = null,
                                            bool hasGetter = true,
                                            bool hasSetter = true)
    {
        var c = codeGenClass.As<CodeGenClass>();
        c.Properties.Add(new CodeGenProperty(name, accessibilities, kind, backingField.As<CodeGenField>(), codeGenClass, hasGetter, hasSetter, type.As<CodeGenType>()));
        return c;
    }
    public static Code GenerateCode(this ICodeGenNamespace codeGenNamespace, ICodeGenerator codeGenerator) =>
        codeGenerator.Generate(codeGenNamespace);

    public static Code GenerateCode<TCodeDomCodeGenerator>(this ICodeGenNamespace codeGenNamespace)
        where TCodeDomCodeGenerator : ICodeGenerator, new() => GenerateCode(codeGenNamespace, new TCodeDomCodeGenerator());

    internal static CodeGenCollection<T> Convert<T>(this IEnumerable<T> items) where T : ICodeGenHasName => new(items);

    private static T? As<T>(this object? o) =>
        o is null ? default : o is T result ? result : throw new NotSupportedException();

    public static ICodeGenType ByType<TType>() =>
        new CodeGenType(typeof(TType).Name, CodeGenAccessibility.None, new(CodePathHelper.NamespaceByType<TType>()));
}
