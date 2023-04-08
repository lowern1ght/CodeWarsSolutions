using System.Text.RegularExpressions;

namespace CodeWarsTask._6_kyu;

public class StripCommentsSolution {
    public static string StripComments(string text, string[] commentSymbols) {
        //return String.Join("", text.Split(@"\n").Select(s => Regex.Replace(s.ToString(), @"\s*["+String.Join("", commentSymbols)+"].+", m => "").Trim()));
        return Regex.Replace(text.Replace("\n", Environment.NewLine), @"\s*["+String.Join("?", commentSymbols)+"].*$",
            m => String.Empty, RegexOptions.Multiline);
    }
}
