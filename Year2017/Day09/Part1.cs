using System;

namespace AdventOfCode.Year2017.Day09
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      int groupsOpen = 0;
      int totalScore = 0;
      bool isGarbage = false;

      for (int i = 0; i < input.Length; i++)
      {
        if (input[i] == '{' && !isGarbage)
          totalScore += ++groupsOpen;
        else if (input[i] == '}' && !isGarbage)
          groupsOpen--;
        else if (input[i] == '<')
          isGarbage = true;
        else if (input[i] == '>')
          isGarbage = false;
        else if (input[i] == '!')
          i++;
      }

      return totalScore.ToString();
    }
  }
}
