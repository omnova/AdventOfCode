using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day19
{
  public class Part2 : IPuzzle
  {
    private class Instruction
    {
      public int Id;
      public string RawText;
      public List<Instruction> InnerInstructionsA = new List<Instruction>();
      public List<Instruction> InnerInstructionsB = new List<Instruction>();

      //public override string ToString()
      //{
      //  if (!string.IsNullOrEmpty(this.RawText))
      //    return RawText;
      //  else
      //  {
      //    string value = "[";

      //    foreach (var innerInstruction in this.InnerInstructionsA)
      //    {
      //      value += innerInstruction.ToString();
      //    }

      //    if (InnerInstructionsB.Any())
      //    {
      //      value += "|";

      //      foreach (var innerInstruction in this.InnerInstructionsB)
      //      {
      //        value += innerInstruction.ToString();
      //      }
      //    }

      //    value += "]";

      //    return value;
      //  }
      //}

      public List<string> GetPermutations(int depth)
      {
        if (!string.IsNullOrEmpty(this.RawText))
          return new List<string> { this.RawText };

        if (depth == 10)
          return new List<string> { "" };

        var permutationsA = new List<string>(this.InnerInstructionsA[0].GetPermutations(depth + 1));        

        for (int i = 1; i < this.InnerInstructionsA.Count; i++)
        {
          var nextPermutations = this.InnerInstructionsA[i].GetPermutations(depth + 1);
          var newPermutations = new List<string>();

          for (int a = 0; a < permutationsA.Count; a++)
          {
            for (int b = 0; b < nextPermutations.Count; b++)
              newPermutations.Add(permutationsA[a] + nextPermutations[b]);
          }

          permutationsA = newPermutations;
        }

        if (this.InnerInstructionsB.Any())
        {
          var permutationsB = new List<string>(this.InnerInstructionsB[0].GetPermutations(depth + 1));

          for (int i = 1; i < this.InnerInstructionsB.Count; i++)
          {
            var nextPermutations = this.InnerInstructionsB[i].GetPermutations(depth + 1);
            var newPermutations = new List<string>();

            for (int a = 0; a < permutationsB.Count; a++)
            {
              for (int b = 0; b < nextPermutations.Count; b++)
                newPermutations.Add(permutationsB[a] + nextPermutations[b]);
            }

            permutationsB = newPermutations;
          }

          permutationsA.AddRange(permutationsB);
        }

        return permutationsA;
      }
    }

    public object Run(string input)
    {
      input = input.Replace("8: 42", "8: 42 | 42 8").Replace("11: 42 31", "11: 42 31 | 42 11 31");

      var instructionLines = input.Split(Environment.NewLine + Environment.NewLine)[0].Split(Environment.NewLine);
      var wordLines = input.Split(Environment.NewLine + Environment.NewLine)[1].Split(Environment.NewLine);

      var instructions = new Dictionary<int, Instruction>();

      foreach (var instructionLine in instructionLines)
      {
        int id = int.Parse(instructionLine.Split(": ")[0]);
        var instruction = new Instruction { Id = id };

        if (instructionLine.Contains("\""))
          instruction.RawText = instructionLine.Split(": ")[1].Replace("\"", "");

        instructions.Add(id, instruction);
      }

      foreach (var instructionLine in instructionLines.Where(l => !l.Contains("\"")).ToList())
      {
        var parts = instructionLine.Split(": ");

        int id = int.Parse(parts[0]);
        var instruction = instructions[id];

        var beforeInstructions = parts[1].Split("|")[0].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Select(i => instructions[i]).ToList();

        instruction.InnerInstructionsA.AddRange(beforeInstructions);

        if (instructionLine.Contains("|"))
        {
          var afterInstructions = parts[1].Split("|")[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Select(i => instructions[i]).ToList();

          instruction.InnerInstructionsB.AddRange(afterInstructions);
        }
      }

      //var validMatches = instructions.Values.Select(i => i.GetPermutations()).SelectMany(p => p).Distinct().ToList();
      var validOptions = new HashSet<string>(instructions[0].GetPermutations(1).Distinct().ToList());

      int numMatches = wordLines.Count(w => validOptions.Contains(w));

      return numMatches;
    }
  }
}
