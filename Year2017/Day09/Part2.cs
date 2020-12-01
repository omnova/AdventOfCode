using System;

namespace AdventOfCode.Year2017.Day09
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      bool isGarbage = false;
      int numGarbageChars = 0;

      for (int i = 0; i < input.Length; i++)
      {
        if (input[i] == '!')
          i++;
        else if (!isGarbage && input[i] == '<')
          isGarbage = true;
        else if (isGarbage && input[i] == '>')
          isGarbage = false;
        else if (isGarbage)
          numGarbageChars++;
      }

      return numGarbageChars.ToString();
    }
  }
}
