using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2018.Day02
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

      for (int i = 0; i < lines.Length - 1; i++)
      {
        for (int j = i + 1; j < lines.Length; j++)
        {
          int differenceCount = 0;
          string commonLetters = "";

          for (int index = 0; index < lines[i].Length; index++)
          {
            if (lines[i][index] != lines[j][index])
            {
              differenceCount++;
            }
            else
            {
              commonLetters += lines[i][index].ToString();
            }
          }

          if (differenceCount == 1)
          {
            return commonLetters;
          }
        }
      }

      return "";
    }
  }
}
