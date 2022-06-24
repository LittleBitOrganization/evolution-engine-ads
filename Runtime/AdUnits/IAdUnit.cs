using System;

namespace LittleBitGames.Ads.AdUnits
{
    public interface IAdUnit
    {
        void Show(IAdUnitPlace from, Action<AdShowInfo> callback);

        void Load();

        IAdUnitKey Key { get; }

        IAdUnitPlace UnitPlace { get; set; }
        
        IAdUnitEvents Events { get; }
    }
    
}