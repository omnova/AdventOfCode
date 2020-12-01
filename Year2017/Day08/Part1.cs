using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2017.Day08
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var instructions = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
      var registers = new SortedList<string, int>();

      foreach (var instruction in instructions)
      {
        PerformOperation(registers, instruction);
      }

      return registers.Values.Max().ToString();
    }

    private void PerformOperation(SortedList<string, int> registers, string instruction)
    {
      var instructionParts = instruction.Split();

      string operationRegister = instructionParts[0];
      string operation = instructionParts[1];
      int operationValue = int.Parse(instructionParts[2]);

      string conditionRegister = instructionParts[4];
      string conditionOperator = instructionParts[5];
      int conditionValue = int.Parse(instructionParts[6]);

      if (!registers.ContainsKey(operationRegister))
        registers.Add(operationRegister, 0);

      if (!registers.ContainsKey(conditionRegister))
        registers.Add(conditionRegister, 0);

      bool isConditionMet = IsValidCondition(registers[conditionRegister], conditionOperator, conditionValue);

      if (isConditionMet)
        registers[operationRegister] += (operation == "inc" ? operationValue : -operationValue);
    }

    private bool IsValidCondition(int registerValue, string conditionOperator, int conditionValue)
    {
      switch (conditionOperator)
      {
        case "==": return registerValue == conditionValue;
        case "!=": return registerValue != conditionValue;
        case ">" : return registerValue > conditionValue;
        case ">=": return registerValue >= conditionValue;
        case "<" : return registerValue < conditionValue;
        case "<=": return registerValue <= conditionValue;
        default: throw new ApplicationException("Missed one");
      }
    }
  }
}
