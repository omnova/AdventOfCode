using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day08
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var instructions = input.Split(Environment.NewLine).Select(i => i.Split(" ")).Select(i => new { Op = i[0], Arg = int.Parse(i[1]) }).ToList();
      var runInstructions = new List<int>();

      int accumulator = 0;
      int i = 0;

      while (true)
      {
        if (runInstructions.Contains(i))
          break;
        else
          runInstructions.Add(i);

        var instruction = instructions[i];

        if (instruction.Op == "jmp")
          i += (instruction.Arg % instructions.Count);
        else
        {
          if (instruction.Op == "acc")
            accumulator += instruction.Arg;

          i = (i + 1) % instructions.Count;
        }
      }

      return accumulator;
    }
  }
}
