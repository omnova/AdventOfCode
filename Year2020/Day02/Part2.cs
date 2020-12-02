using System;
using System.Linq;

namespace AdventOfCode.Year2020.Day02
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var instructions = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries).ToList();

      int numValidPasswords = 0;

      foreach (var instruction in instructions)
      {
        var parts = instruction.Split(new string[] { "-", " ", ": " }, StringSplitOptions.None).ToList();

        int position1 = int.Parse(parts[0]) - 1;
        int position2 = int.Parse(parts[1]) - 1;
        char ruleChar = parts[2][0];
        string password = parts[3];

        if ((password[position1] == ruleChar && password[position2] != ruleChar) || (password[position1] != ruleChar && password[position2] == ruleChar))
          numValidPasswords++;
      }

      return numValidPasswords;
    }
  }
}
