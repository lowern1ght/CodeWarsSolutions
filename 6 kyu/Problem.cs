using System.Text.RegularExpressions;

namespace CodeWarsTask._6_kyu;

public static class Problem {
    public static string CamelCase(this string str) {
        return Regex.Replace(str, @"\b[a-z]", m => m.Value.ToUpper()).Replace(" ", "");
    }
}
