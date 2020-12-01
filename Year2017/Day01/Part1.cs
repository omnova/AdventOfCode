using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2017.Day01
{
  public class Part1 : IPuzzle
  {
    public string Run(string input)
    {
      // Cheat the loop
      input += input[0];

      int total = 0;

      for (int i = 0; i < input.Length - 1; i++)
      {
        if (input[i] == input[i + 1])
          total += int.Parse(input[i].ToString());
      }

      return total.ToString();
    }
  }
}
