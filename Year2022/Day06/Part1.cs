using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2022.Day06
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      int i = 0;
      var buffer = new char[4];

      while (i < 3 || buffer.Distinct().Count() != 4)
      {
        buffer[i++ % 4] = input[i];
      }

      return i + 1;
    }
  }
}
