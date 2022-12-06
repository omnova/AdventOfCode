using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2022.Day06
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      int i = 0;
      var buffer = new char[14];

      while (i < 13 || buffer.Distinct().Count() != 14)
      {
        buffer[i++ % 14] = input[i];
      }

      return i + 1;
    }
  }
}
