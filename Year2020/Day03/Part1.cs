using System;
using System.Linq;

namespace AdventOfCode.Year2020.Day03
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var grid = input.Split(Environment.NewLine).Select(l => l.ToCharArray()).ToArray();

      int numTrees = grid.Where((g, y) => g[(3 * y) % g.Length] == '#').Count();

      return numTrees;
    }
  }
}
