namespace LittleBitGames.Ads.AdUnits
{
    public readonly struct AdShowInfo
    {
        public readonly IAdUnitKey Key;
        public readonly IAdUnitPlace From;
        public readonly bool Success;

        public AdShowInfo(IAdUnitKey key, bool success, IAdUnitPlace from)
        {
            Key = key;
            Success = success;
            From = from;
        }
    }
}