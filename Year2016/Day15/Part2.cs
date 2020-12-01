using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2016.Day15
{
  public class Part2 : IPuzzle
  {
    public string Run(string input)
    {
      var positions = new List<Func<int, int>>
      {
        (t => (t + 1 + 0) % 7),
        (t => (t + 2 + 0) % 13),
        (t => (t + 3 + 2) % 3),
        (t => (t + 4 + 2) % 5),
        (t => (t + 5 + 0) % 17),
        (t => (t + 6 + 7) % 19),
        (t => (t + 7 + 0) % 11)
      };

      for (int time = 0; time < int.MaxValue; time++)
      {
        if (positions.All(p => p(time) == 0))
          return time.ToString();
      }

      return string.Empty;
    }
  }
}
