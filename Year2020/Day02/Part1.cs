using System;
using System.Linq;

namespace AdventOfCode.Year2020.Day02
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var instructions = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();

      int numValidPasswords = 0;

      foreach (var instruction in instructions)
      {
        var parts = instruction.Split(new string[] { "-", " ", ": " }, StringSplitOptions.None).ToList();

        int minCount = int.Parse(parts[0]);
        int maxCount = int.Parse(parts[1]);
        char ruleChar = parts[2][0];
        string password = parts[3];

        int charCount = password.Count(c => c == ruleChar);

        if (charCount >= minCount && charCount <= maxCount)
          numValidPasswords++;
      }

      return numValidPasswords;
    }
  }
}
