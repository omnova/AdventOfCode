using System;

namespace AdventOfCode.Year2017.Day14
{
  public class Part1 : IPuzzle
  {
    public string Run(string input)
    {
      int count = 0;

      for (int i = 0; i < 128; i++)
      {
        string knotHash = new AdventOfCode.Year2017.Day10.Part2().Run(input + "-" + i);

        foreach (char c in knotHash)
        {
          int value = Convert.ToInt32("0x0" + c, 16);

          for (int b = 3; b >= 0; b--)
          {
            count += (value & (1 << b)) == 0 ? 0 : 1;
          }
        }
      }

      return count.ToString();
    }
  }
}
