namespace LittleBitGames.Ads.AdUnits
{
    public readonly struct AdUnitPlace : IAdUnitPlace
    {
        public string StringValue { get; }

        public AdUnitPlace(string place = "MainView")
        {
            StringValue = place;
        }
        
        public AdUnitPlace(IAdUnitPlace place)
        {
            StringValue = place.StringValue;
        }
    }
}