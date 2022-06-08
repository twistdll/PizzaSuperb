namespace PizzaSuperb.Extensions
{
    internal static class CookieExtensions
    {
        public static IEnumerable<KeyValuePair<string, string>> ToFilteredPairs(this IRequestCookieCollection cookies, params string[] prefixes)
            => cookies.Where(x => prefixes.Any(p => x.Key.StartsWith(p)));

        public static string ToItemName(this string key, params string[] prefix)
            => key.Split(prefix, StringSplitOptions.None)[1].Replace("%20", " ");
    }
}
