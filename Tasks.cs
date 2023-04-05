﻿using System.Runtime.CompilerServices;

using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;

namespace CodeWarsTask;

using static Tasks;

public class Tasks {
    public static string Maskify(string masked) {
        return masked.Length < 4 ? masked :
            new string('#', masked[0..^4].Length) + masked.Substring(masked.Length-4);
    }

    public static Boolean IsIsogram(string str, Boolean? IgnoreCase = true) {
        return str.ToLower().Distinct().Count() == str.Length;
    }

    public static string HighAndLow(string numbers) {
        var arrNums = numbers.Split(' ').Select(n => Int32.Parse(n)).ToArray();
        return arrNums.Max() + " " + arrNums.Min();
    }

    public static string Longest(string s1, string s2) {
        return new string((s1 + s2).Distinct().OrderBy(c => c).ToArray());
    }

    public static string ToCamelCase(string str) {
        var splitStrings = str.Split(new char[] { '-', '_', ' ' });
        return splitStrings[0] + String.Join("", splitStrings.Skip(1).Select(s => Char.ToUpper(s[0]) + s[1..^0]));
    }

    public static string SpinWords(string sentence) {
        return String.Join(" ", sentence.Split(' ').Select(x => x.Length < 5 ? x : new string(x.Reverse().ToArray())));
    }

    public static Int32 BetweenExtremes(Int32[] numbers) {
        return numbers.Max() - numbers.Min();
    }

    public static int GetVowelCount(string str) {
        return Regex.Matches(str, @"[aeiou]").Count;
    }

    public static bool ValidatePin(string pin) {
        return Regex.IsMatch(pin, @"^\b(\d{4}|\d{6})\z", RegexOptions.CultureInvariant);
        //return pin.All(c => Char.IsDigit(c)) && (pin.Length == 4 || pin.Length == 6);
    }

    public static Boolean Narcissistic(int value) {
        return false;
    }
}

internal class Start {
    public static async Task Main() {
        //await Console.Out.WriteLineAsync(SpinWords("Hey fellow warriors"));
        await TestFunc();
    }

    public static async Task TestFunc() {
        string[] fruits = { "apple", "banana", "mango", "orange", "passionfruit", "grape" };
        var result = fruits.Count(s => s.Contains("banana"));
        await Console.Out.WriteLineAsync(result.ToString());
    }
}

public class CleverSolution {
    //a.kozhanov, использование регулярных выражений
    public static string SpinWords(string sentence) {
        return Regex.Replace(sentence, @"\w{5,}", m => string.Concat(m.Value.Reverse()));
    }
}