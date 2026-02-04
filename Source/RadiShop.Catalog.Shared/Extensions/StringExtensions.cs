using System.Text.RegularExpressions;

namespace RadiShop.Catalog.Shared.Extensions;

public static class StringExtensions
{
    public static string ToKebabCase(this string str)
    {
        var sanitizedInput = Regex.Replace(str, @"[^a-zA-Z0-9\s-]", "");

        var kebab = Regex.Replace(sanitizedInput.Trim(), @"\s+", "-");

        return kebab.ToLower();
    }
}