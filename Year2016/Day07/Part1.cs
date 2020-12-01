using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Year2016.Day07
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      return input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
        .Count(l => Regex.IsMatch(l, @"(\w)(?!\1)(\w)\2\1") && !Regex.IsMatch(l, @"\[\w*(\w)(?!\1)(\w)\2\1\w*\]"))
        .ToString();
    }
  }
}
