using System;
using System.Linq;

namespace AdventOfCode.Year2021.Day02
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var commands = input.Split(Environment.NewLine).Select(c => c.Split(' ')).ToList();

      int x = 0;
      int z = 0;
      int aim = 0;

      foreach (var command in commands)
      {
        string instruction = command[0];
        int value = int.Parse(command[1]);

        if (instruction == "forward")
        {
          x += value;

          z += (aim * value);
        }
        else if (instruction == "down")
          aim += value;
        else if (instruction == "up")
          aim -= value;
      }

      return x * z;
    }
  }
}
