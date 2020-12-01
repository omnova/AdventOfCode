using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode.Year2016.Day12
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var registers = new Dictionary<string, int>
      {
        { "a", 0 },
        { "b", 0 },
        { "c", 1 },
        { "d", 0 }
      };

      var instructions = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Select(i => i.Split().ToArray()).ToList();

      int codePointer = 0;

      while (codePointer < instructions.Count)
      {
        if (instructions[codePointer][0] == "cpy")
        {
          if (char.IsLetter(instructions[codePointer][1][0]))
            registers[instructions[codePointer][2]] = registers[instructions[codePointer][1]];
          else
            registers[instructions[codePointer][2]] = int.Parse(instructions[codePointer][1]);

          codePointer++;
        }
        else if (instructions[codePointer][0] == "inc")
        {
          registers[instructions[codePointer][1]]++;

          codePointer++;
        }
        else if (instructions[codePointer][0] == "dec")
        {
          registers[instructions[codePointer][1]]--;

          codePointer++;
        }
        else if (instructions[codePointer][0] == "jnz")
        {
          if (char.IsDigit(instructions[codePointer][1][0]) && int.Parse(instructions[codePointer][1]) != 0)
            codePointer += int.Parse(instructions[codePointer][2]);
          else if (char.IsLetter(instructions[codePointer][1][0]) && registers[instructions[codePointer][1]] != 0)
            codePointer += int.Parse(instructions[codePointer][2]);
          else
            codePointer++;
        }
      }

      return registers["a"].ToString();
    }
  }
}
