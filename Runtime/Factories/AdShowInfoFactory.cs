using LittleBitGames.Ads.AdUnits;

namespace LittleBitGames.Ads.Factories
{
    public class AdShowInfoFactory
    {
        private readonly IAdUnitKey _key;
        private readonly IAdUnitPlace _from;
        
        public AdShowInfoFactory(IAdUnitKey key, IAdUnitPlace from)
        {
            _from = from;
            _key = key;
        }

        public AdShowInfo Create(bool success) => new AdShowInfo(_key, success, _from);
    }
}