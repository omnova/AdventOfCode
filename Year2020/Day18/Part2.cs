using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Year2020.Day18
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      long result = input.Replace(" ", "").Split(Environment.NewLine).Select(DoMaths).Sum();

      return result;
    }

    private long DoMaths(string math)
    {      
      for (var match = Regex.Match(math, @"\([^\(\)]+\)"); match.Success; match = Regex.Match(math, @"\([^\(\)]+\)"))
      {
        string matchValue = match.Value;

        DoAddition(ref matchValue);
        DoMultiplication(ref matchValue);
        DoParentheses(ref matchValue);

        math = math.Replace(match.Value, matchValue);
      }

      DoAddition(ref math);
      DoMultiplication(ref math);

      return long.Parse(math);
    }

    private void DoParentheses(ref string math)
    {
      math = math.Substring(1, math.Length - 2);
    }

    private void DoAddition(ref string math)
    {
      for (var match = Regex.Match(math, @"\d+\+\d+"); match.Success; match = Regex.Match(math, @"\d+\+\d+"))
      {      
        long result = match.Value.Split("+").Select(long.Parse).Sum();

        math = new Regex(match.Value.Replace("+", @"\+")).Replace(math, result.ToString(), 1);
      }
    }

    private void DoMultiplication(ref string math)
    {
      for (var match = Regex.Match(math, @"\d+\*\d+"); match.Success; match = Regex.Match(math, @"\d+\*\d+"))
      {
        long result = match.Value.Split("*").Select(long.Parse).Aggregate(1L, (acc, val) => acc * val);

        math = new Regex(match.Value.Replace("*", @"\*")).Replace(math, result.ToString(), 1);
      }
    }
  }
}
