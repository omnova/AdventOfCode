using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2022.Day05
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var stackDefinitions = input.Split(Environment.NewLine + Environment.NewLine)[0].Split(Environment.NewLine).ToArray();
      var stacks = stackDefinitions[stackDefinitions.Length - 1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => new Stack<char>()).ToArray();

      for (int i = stackDefinitions.Length - 2; i >= 0; i--)
      {
        for (int j = 0; 1 + (j * 4) < stackDefinitions[i].Length; j++)
        {
          if (stackDefinitions[i][1 + (j * 4)] != ' ')
            stacks[j].Push(stackDefinitions[i][1 + (j * 4)]);
        }
      }

      var instructions = input
        .Split(Environment.NewLine + Environment.NewLine)[1]
        .Split(Environment.NewLine)
        .Select(l => l.Split(' '))
        .Select(l => new int[] { int.Parse(l[1]), int.Parse(l[3]), int.Parse(l[5]) })
        .ToArray();

      foreach (var instruction in instructions)
      {
        string boxes = "";

        for (int i = 0; i < instruction[0]; i++)
          boxes = stacks[instruction[1] - 1].Pop() + boxes;

        for (int i = 0; i < instruction[0]; i++)
          stacks[instruction[2] - 1].Push(boxes[i]);
      }

      string message = string.Join(null, stacks.Select(s => s.Peek()));

      return message;
    }
  }
}
