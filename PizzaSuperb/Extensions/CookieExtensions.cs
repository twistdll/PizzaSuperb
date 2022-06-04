using System.Collections.Generic;

namespace PizzaSuperb.Extensions
{
    internal static class CookieExtensions
    {
        public static IEnumerable<KeyValuePair<string, string>> ToFilteredPairs(this IRequestCookieCollection cookies, string prefix)
            => cookies.Where(x => x.Key.StartsWith(prefix) && int.Parse(x.Value) > 0);

    }
}
