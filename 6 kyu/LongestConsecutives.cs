namespace CodeWarsTask._6_kyu {
    public class LongestConsecutives {
        public static string LongestConsec(string[] strarr, int k) {
            return (k > 0) && (k <= strarr.Length) ? String.Join("", strarr.Select((x, i) => x+strarr.ElementAtOrDefault(i)).OrderBy(s => s.Length).First()) : "";
        }
    }
}