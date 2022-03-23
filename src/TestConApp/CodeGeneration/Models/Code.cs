namespace ConsoleApp23.CodeGeneration.Models;

public readonly struct Code : IEquatable<Code>, IEquatable<string>
{
    public Code(string name, string statement)
        => (this.Name, this.Statement) = (name, statement);
    public void Deconstruct(out string name, out string statement)
        => (name, statement) = (this.Name, this.Statement);

    public string Name { get; }
    public string Statement { get; }

    public override string ToString() => $"Name: '{this.Name}' Code: `{this.Statement}`";

    public override int GetHashCode() => this.Name.GetHashCode();

    public bool Equals(Code other) => other.Name.Equals(this.Name);
    public bool Equals(string? other) => other?.Equals(this.Name) ?? false;
    public override bool Equals(object? obj) => obj is Code code && this.Equals(code);

    public static bool operator ==(Code left, Code right) => left.Equals(right);
    public static bool operator !=(Code left, Code right) => !(left == right);
    public static explicit operator string(Code code) => code.Statement;
    public static explicit operator Code((string Name, string Statament) codeData) => new(codeData.Name, codeData.Statament);
}
