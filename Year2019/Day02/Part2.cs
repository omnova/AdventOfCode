using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2019.Day02
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var addresses = input.Split(',').Select(int.Parse).ToList();

      for (int noun = 0; noun < 100; noun++)
      {
        for (int verb = 0; verb < 100; verb++)
        {
          if (GetOutput(addresses, noun, verb) == 19690720)
            return 100 * noun + verb; // exact OoO
        }
      }

      return "wtfmate";
    }

    private int GetOutput(List<int> inputAddresses, int noun, int verb)
    {
      var addresses = inputAddresses.ToList(); // Shallow copy

      addresses[1] = noun;
      addresses[2] = verb;

      for (int instructionPointer = 0; instructionPointer < addresses.Count; instructionPointer += 4)
      {
        int instruction = addresses[instructionPointer];
        int operand1 = addresses[addresses[instructionPointer + 1]];
        int operand2 = addresses[addresses[instructionPointer + 2]];
        int destinationAddress = addresses[instructionPointer + 3];

        if (instruction == 1)
          addresses[destinationAddress] = operand1 + operand2;
        else if (instruction == 2)
          addresses[destinationAddress] = operand1 * operand2;
        else if (instruction == 99)
          break;
      }

      return addresses[0];
    }
  }
}
