using System;

public interface IAdUnitKey : IEquatable<IAdUnitKey>
{
    public string StringValue { get; }

    public bool Validate();
}