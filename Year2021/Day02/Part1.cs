using System;
using System.Linq;

namespace AdventOfCode.Year2021.Day02
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var commands = input.Split(Environment.NewLine).Select(c => c.Split(' ')).ToList();

      int x = 0;
      int z = 0;

      foreach (var command in commands)
      {
        if (command[0] == "forward")
          x += int.Parse(command[1]);
        else if (command[0] == "down")
          z += int.Parse(command[1]);
        else if (command[0] == "up")
          z -= int.Parse(command[1]);
      }

      return x * z;
    }
  }
}
