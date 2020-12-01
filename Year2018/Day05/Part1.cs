using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2018.Day05
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      int lastLength = 0;

      do
      {
        lastLength = input.Length;
        
        for (int i = 0; i < input.Length - 1; i++)
        {
          while (i < input.Length - 1 && input[i].ToString().ToLower() == input[i+1].ToString().ToLower() && ((char.IsUpper(input[i]) && char.IsLower(input[i+1])) || (char.IsLower(input[i]) && char.IsUpper(input[i+1]))))
          {
            input = input.Remove(i, 2);
          }
        }
      }
      while (input.Length != lastLength);

      return input.Length.ToString();
    }
  }
}