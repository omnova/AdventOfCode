using System;

namespace AdventOfCode.Year2017.Day11
{
  public class Part2 : IPuzzle
  {
    public string Run(string input)
    {
      var steps = input.Split(',');

      decimal x = 0;
      decimal y = 0;

      decimal maxDistance = 0;

      foreach (string step in steps)
      {
        if (step == "nw")
        {
          x--;
          y -= 0.5m;
        }
        else if (step == "n")
        {
          y--;
        }
        else if (step == "ne")
        {
          x++;
          y -= 0.5m;
        }
        else if (step == "sw")
        {
          x--;
          y += 0.5m;
        }
        else if (step == "s")
        {
          y++;
        }
        else if (step == "se")
        {
          x++;
          y += 0.5m;
        }

        maxDistance = Math.Max(maxDistance, (Math.Abs(x) + Math.Max(0, Math.Abs(y) - (Math.Abs(x) * 0.5m))));
      }

      return ((int)maxDistance).ToString();
    }
  }
}
