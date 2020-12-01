using System;
using System.Collections.Generic;

namespace AdventOfCode.Year2017.Day17
{
  public class Part1 : IPuzzle
  {
    public string Run(string input)
    {
      int steps = int.Parse(input);

      var buffer = new List<int>(2018) { 0 };
      int position = 0;

      for (int i = 1; i <= 2017; i++)
      {
        position = ((position + steps) % buffer.Count) + 1;

        buffer.Insert(position, i);
      }

      return buffer[position + 1].ToString();
    }
  }
}
