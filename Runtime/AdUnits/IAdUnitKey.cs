using System;

namespace LittleBitGames.Ads.AdUnits
{
    public interface IAdUnitKey : IEquatable<IAdUnitKey>
    {
        public string StringValue { get; }

        public bool Validate();
    }
}