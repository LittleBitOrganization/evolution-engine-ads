using AppodealStack.Monetization.Common;

namespace LittleBitGames.Ads.AdUnits
{
    public class AdInfo
    {
        public AdInfo()
        {
        }
        
        public AdInfo(MaxSdkBase.AdInfo adInfo)
        {
            Revenue = adInfo.Revenue;
            Placement = adInfo.Placement;
            RevenuePrecision = adInfo.RevenuePrecision;
            NetworkName = adInfo.NetworkName;
            AdFormat = adInfo.AdFormat;
            NetworkPlacement = adInfo.NetworkPlacement;
            AdUnitIdentifier = adInfo.AdUnitIdentifier;
            CreativeIdentifier = adInfo.CreativeIdentifier;
            DspName = adInfo.DspName;
        }
        
        public AdInfo(AppodealAdRevenue adInfo)
        {
            Revenue = adInfo.Revenue;
            Placement = adInfo.Placement;
            RevenuePrecision = adInfo.RevenuePrecision;
            NetworkName = adInfo.NetworkName;
            AdFormat = adInfo.AdType;
            NetworkPlacement = adInfo.DemandSource;
            AdUnitIdentifier = adInfo.AdUnitName;

        }
        
        public string AdUnitIdentifier { get; private set; }
        public string AdFormat { get; private set; }
        public string NetworkName { get; private set; }
        public string NetworkPlacement { get; private set; }
        public string Placement { get; private set; }
        public string CreativeIdentifier { get; private set; }
        public double Revenue { get; private set; }
        public string RevenuePrecision { get; private set; }
        public string DspName { get; private set; }
    }
}