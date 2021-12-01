using System;
using System.Collections.Generic;
using System.Linq;
namespace AdventOfCode.Year2019.Day05
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var program = new IntcodeProgram(input);

      program.Addresses[1] = 12;
      program.Addresses[2] = 2;

      var interpreter = new IntcodeIntepreter();
      var result = interpreter.Run(program);

      return result.Addresses.ElementAt(0);
    }

    private class IntcodeProgram
    {
      public List<int> Addresses { get; private set; }

      public IntcodeProgram(string input)
      {
        this.Addresses = input.Split(',').Select(int.Parse).ToList();
      }
    }

    private class IntcodeExecutionResult
    {
      public IEnumerable<int> Addresses { get; private set; }

      public IntcodeExecutionResult(List<int> addresses)
      {
        this.Addresses = addresses;
      }
    }

    private class IntcodeInstruction
    {
      public int OpCode { get; private set; }
      public int Parameter1Mode { get; private set; }
      public int Parameter2Mode { get; private set; }
      public int Parameter3Mode { get; private set; }

      public IntcodeInstruction(int instruction)
      {
        var parts = instruction.ToString().PadLeft(5, '0').Select(p => p.ToString()).ToArray();

        this.OpCode = int.Parse(parts[3] + parts[4]);
        this.Parameter1Mode = int.Parse(parts[2]);
        this.Parameter2Mode = int.Parse(parts[1]);
        this.Parameter3Mode = int.Parse(parts[0]);
      }
    }

    private class IntcodeIntepreter
    {
      public IntcodeExecutionResult Run(IntcodeProgram program)
      {
        var addresses = program.Addresses.ToList();

        for (int instructionPointer = 0; instructionPointer < addresses.Count; instructionPointer++)
        {
          var instruction = new IntcodeInstruction(addresses[instructionPointer]);

          switch (instruction.OpCode)
          {
            case 1:
              Add(addresses, 
                GetArgumentValue(addresses, instruction.Parameter1Mode, addresses[++instructionPointer]), 
                GetArgumentValue(addresses, instruction.Parameter2Mode, addresses[++instructionPointer]),
                addresses[++instructionPointer]);
              break;

            case 2:
              Multiply(addresses, 
                GetArgumentValue(addresses, instruction.Parameter1Mode, addresses[++instructionPointer]),
                GetArgumentValue(addresses, instruction.Parameter2Mode, addresses[++instructionPointer]),
                addresses[++instructionPointer]);
              break;

            case 3:
              break;

            case 4:
              break;

            case 99:
              return new IntcodeExecutionResult(addresses);

            default:
              throw new InvalidOperationException();
          }
        }

        throw new InvalidProgramException();
      }

      private int GetArgumentValue(List<int> addresses, int parameterMode, int rawArgumentValue)
      {
        return parameterMode == 1 ? rawArgumentValue : addresses[rawArgumentValue];
      }

      private void Add(List<int> addresses, int operand1, int operand2, int destinationAddress)
      {
        addresses[destinationAddress] = operand1 + operand2;
      }

      private void Multiply(List<int> addresses, int operand1, int operand2, int destinationAddress)
      {
        addresses[destinationAddress] = operand1 * operand2;
      }

      private void Put(List<int> addresses, int operand1, int destinationAddress)
      {
        //addresses[destinationAddress] = operand1 * operand2;
      }
    }
  }
}
