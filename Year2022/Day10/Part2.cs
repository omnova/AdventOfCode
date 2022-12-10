using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2022.Day10
{
  public class Part2 : IPuzzle
  {   
    public object Run(string input)
    {
      var instructions = input.Split(Environment.NewLine).Select(l => l.Split(' ').ToArray());

      var screen = new bool[40, 6];

      int x = 1;
      int cycle = 1;

      foreach (var instruction in instructions)
      {
        screen[(cycle - 1) % 40, (cycle - 1) / 40] = (((cycle - 1) % 40 >= x - 1) && ((cycle - 1) % 40 <= x + 1));

        if (instruction.Length > 1)
        {
          cycle++;
          screen[(cycle - 1) % 40, (cycle - 1) / 40] = (((cycle - 1) % 40 >= x - 1) && ((cycle - 1) % 40 <= x + 1));

          x += int.Parse(instruction[1]);
        }

        cycle++;
      }

      return Environment.NewLine + screen.ToString(c => c ? "#" : ".");
    }
  }
}
