using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2017.Day01
{
  public class Part2 : IPuzzle
  {
    public string Run(string input)
    {
      int total = 0;

      for (int i = 0; i < input.Length; i++)
      {
        int j = (i + (input.Length / 2)) >= input.Length ? (i + (input.Length / 2)) - input.Length : (i + (input.Length / 2));

        if (input[i] == input[j])
          total += int.Parse(input[i].ToString());
      }

      return total.ToString();
    }
  }
}
