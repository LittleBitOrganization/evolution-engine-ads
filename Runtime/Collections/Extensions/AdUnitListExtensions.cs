using System.Collections.Generic;
using System.Linq;
using LittleBitGames.Ads.AdUnits;

namespace LittleBitGames.Ads.Collections.Extensions
{
    public static class AdUnitListExtensions
    {
        public static IAdUnit FindByKey(this IReadOnlyList<IAdUnit> list, string key) =>
            list.Where(unit => unit is not null).FirstOrDefault(unit => unit.Key.StringValue.Equals(key));

        public static bool Validate(this IReadOnlyList<IAdUnit> list) =>
            list.Where(unit => unit is not null).All(x => !string.IsNullOrEmpty(x.Key.StringValue));
    }
}