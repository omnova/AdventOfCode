using System;

namespace AdventOfCode.Year2017.Day11
{
  public class Part1 : IPuzzle
  {
    public string Run(string input)
    {
      var steps = input.Split(',');

      decimal x = 0;
      decimal y = 0;

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
      }

      x = Math.Abs(x);
      y = Math.Abs(y);

      y = Math.Max(0, y - (x * 0.5m));
      
      return ((int)(x + y)).ToString();
    }
  }
}
