using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Text.Json;

namespace CodeWarsTask;

using static WithoutATopic;

public class WithoutATopic {
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
        //return (int)value.ToString().Select(c => Math.Pow(Char.GetNumericValue(c), value.ToString().Length)).Sum() == value; //Reworked
        return $"{value}".Sum(c => Math.Pow(int.Parse(c.ToString()), $"{value}".Length)) == value;
    }

    public static Boolean validBraces(String braces) { //Not successes
        var symbols = new char[] { '{', '}', '(', ')', '[', ']' };
        var booles = braces.Where(c => symbols.Contains(c));
        return braces.Length % 2 == 0 
            && booles.Select((c, i) => c == booles.ElementAtOrDefault(booles.Count() - i )).Any(b => b);
    }

    public static Dictionary<char, int> CountDisctionary(string str) {
        return str.GroupBy(c => c).ToDictionary(c => c.Key, g => g.Count());
    }

    public static string AlphabetPosition(string text) {
        return String.Join(" ", text.Where(c => Char.IsLetter(c) != false).Select(c => Char.IsUpper(c) == true ? c - 64 : c - 96));
    }
    public static string FakeBin(string x) {
        return String.Concat(x.Select(c => c >= '5' ? '1' : '0'));
    }

    public static bool BetterThanAverage(int[] ClassPoints, int YourPoints) {
        return (int)ClassPoints.Average() < YourPoints;
    }

    public static int[] ReverseSeq(int n) {
        return Enumerable.Range(1, n).Reverse().ToArray();
    }

    public static string EvenOrOdd(int number) {
        return number % 2 == 0 ? "Even" : "Odd";
    }

    public static string Smash(string[] words) {
        return String.Join(" ", words);
    }

    public static string MakeComplement(string dna) {
        return String.Concat(dna.ToUpper().Select(c => c == 'A' ? 'T' : c == 'C' ? 'G' : c == 'G' ? 'C' : 'A'));
    }

    public static string PrinterError(String s) {
        return $"{s.ToLower().Count(c => c > 'm')}/{s.Length}";
    }

    public static int GetUnique(IEnumerable<int> numbers) {
        //return numbers.GroupBy(n => n).Where(g => g.Count() == 1).First().Key;
        return numbers.GroupBy(n => n).Single(g => g.Count() == 1).Key; //Use Single, without Where, First
    }
}

public class CleverSolution {
    //a.kozhanov, использование регулярных выражений
    public static string SpinWords(string sentence) {
        return Regex.Replace(sentence, @"\w{5,}", m => string.Concat(m.Value.Reverse()));
    }

    //тот же самый мужик a.kozhanov, First принимает делегат, для отбора одного элемента
    public static int GetUnique(IEnumerable<int> numbers) {
        return numbers.First(x => numbers.Count(i => i == x) == 1);
    }
}