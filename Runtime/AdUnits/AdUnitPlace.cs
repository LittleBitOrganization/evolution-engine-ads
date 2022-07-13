namespace LittleBitGames.Ads.AdUnits
{
    public class AdUnitPlace : IAdUnitPlace
    {
        public string StringValue { get; }

        public AdUnitPlace(string place = "MainView") => StringValue = place;

        public AdUnitPlace(IAdUnitPlace place) => StringValue = place.StringValue;

        public AdUnitPlace() => StringValue = "MainView";
    }
}