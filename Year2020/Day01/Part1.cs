using System;
using System.Linq;

namespace AdventOfCode.Year2020.Day01
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var expenses = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

      for (int i = 0; i < expenses.Count; i++)
      {
        for (int j = 0; j < expenses.Count; j++)
        {
          if (j == i)
            continue;

          if (expenses[i] + expenses[j] == 2020)
            return (expenses[i] * expenses[j]).ToString();
        }
      }

      return "no value";
    }
  }
}
