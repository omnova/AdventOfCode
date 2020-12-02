using System;
using System.Linq;

namespace AdventOfCode.Year2019.Day02
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var addresses = input.Split(',').Select(int.Parse).ToList();

      addresses[1] = 12;
      addresses[2] = 2;

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
        else
          return "something went wrong";
      }

      return addresses[0];
    }
  }
}
