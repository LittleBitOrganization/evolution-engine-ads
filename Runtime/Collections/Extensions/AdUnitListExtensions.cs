using System.Collections.Generic;
using System.Linq;
using LittleBitGames.Ads.AdUnits;

namespace LittleBitGames.Ads.Collections.Extensions
{
    public static class AdUnitListExtensions
    {
        public static IAdUnit FindByKey(this List<IAdUnit> list, string key) =>
            list.FirstOrDefault(unit => unit.Key.Equals(key));

        public static bool Validate(this List<IAdUnit> list) =>
            list.Any(x => x.Equals(null)) || list.Any(x => string.IsNullOrEmpty(x?.Key.StringValue));
    }
}