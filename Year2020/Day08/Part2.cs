using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day08
{
  public class Part2 : IPuzzle
  {
    private class Instruction
    {
      public string Op;
      public int Arg;
    }

    public object Run(string input)
    {
      var originalInstructions = input.Split(Environment.NewLine).Select(i => i.Split(" ")).Select(i => new Instruction { Op = i[0], Arg = int.Parse(i[1]) }).ToList();      

      for (int attempt = 0; attempt < originalInstructions.Count; attempt++)
      {
        if (!(originalInstructions[attempt].Op == "nop" || originalInstructions[attempt].Op == "jmp"))
          continue;

        var instructions = originalInstructions.Select(i => new Instruction { Op = i.Op, Arg = i.Arg }).ToList();
        var runInstructions = new List<int>();

        instructions[attempt].Op = instructions[attempt].Op == "jmp" ? "nop" : "jmp";

        int accumulator = 0;
        int i = 0;

        while (true)
        {
          if (i == instructions.Count)
            return accumulator;

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
      }

      return null;
    }
  }
}
