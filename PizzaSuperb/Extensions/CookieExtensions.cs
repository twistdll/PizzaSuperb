namespace PizzaSuperb.Extensions
{
    internal static class CookieExtensions
    {
        public static IEnumerable<KeyValuePair<string, string>> ToFilteredPairs(this IRequestCookieCollection cookies, string prefix)
            => cookies.Where(x => x.Key.StartsWith(prefix) && int.Parse(x.Value) > 0);

        public static IEnumerable<KeyValuePair<string, string>> ToFilteredPairs(this IRequestCookieCollection cookies, string prefix1, string prefix2)
           => cookies.Where(x => x.Key.StartsWith(prefix1) || x.Key.StartsWith(prefix2) && int.Parse(x.Value) > 0);
    }
}
