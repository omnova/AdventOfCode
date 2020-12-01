using System;
using System.Linq;

namespace AdventOfCode.Year2016.Day03
{
  public class Part1 : IPuzzle
  {
    public string Run(string input)
    {
      return input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                  .Select(t => t.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                  .Select(t => new int[] { int.Parse(t[0]), int.Parse(t[1]), int.Parse(t[2]) }.OrderBy(i => i).ToArray())
                  .Count(t => t[0] + t[1] > t[2])
                  .ToString();
    }
  }
}
