using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Year2016.Day07
{
  public class Part2 : IPuzzle
  {
    public string Run(string input)
    {
      var ipAddresses = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
        .Where(l => Regex.IsMatch(l, @"(\w)(?!\1)(\w)\2\1") && !Regex.IsMatch(l, @"\[\w*(\w)(?!\1)(\w)\2\1\w*\]"))
        .ToList();

      var abaRegex = new Regex(@"(\w)(?!\1)(\w)\1(?=\w*\[)|(?!\]\w*)(\w)(?!\3)(\w)\3(?=\w*$)");

      int count = 0;

      foreach (string ip in ipAddresses)
      {
        var supernetSequences = Regex.Matches(ip, @"(?:\[)\w+\]").Cast<object>().Select(match => match.ToString()).ToArray();
        var netSequences = ip.Split(supernetSequences, StringSplitOptions.RemoveEmptyEntries);
        var abas = netSequences.SelectMany(n => abaRegex.Matches(n).Cast<object>().Select(match => match.ToString()).ToList()).ToList();
        var babs = abas.Select(a => a.Substring(1) + a[1]).ToList();

        if (babs.Count == babs.Count(b => string.Join(" ", supernetSequences).IndexOf(b) != -1))
          count++;
      }

      return count.ToString();
    }
  }
}
