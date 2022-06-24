namespace LittleBitGames.Ads.AdUnits
{
    public readonly struct AdUnitKey : IAdUnitKey
    {
        public AdUnitKey(string key) => StringValue = key;
        public string StringValue { get; }

        public bool Validate() => !string.IsNullOrEmpty(StringValue);

        public bool Equals(IAdUnitKey key) => string.Equals(key?.StringValue, StringValue);
    }
}