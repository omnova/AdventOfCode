using System;
using System.Linq;

namespace AdventOfCode.Year2016.Day03
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var data = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                      .Select(t => t.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
                      .Select(t => new int[] { int.Parse(t[0]), int.Parse(t[1]), int.Parse(t[2]) });

      return data.Select(t => t[0])
                 .Concat(data.Select(t => t[1]))
                 .Concat(data.Select(t => t[2]))
                 .Select((v, i) => new { Value = v, Index = i })
                 .GroupBy(i => i.Index / 3)
                 .Select(g => g.Select(o => o.Value).OrderBy(i => i).ToArray())
                 .Count(t => t[0] + t[1] > t[2])
                 .ToString();
    }
  }
}
