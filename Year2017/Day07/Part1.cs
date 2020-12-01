using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2017.Day07
{
  public class Part1 : IPuzzle
  {
    public string Run(string input)
    {
      var lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                       .Select(l => l.Split())
                       .ToList();

      var discs = new List<Disc>();

      var temp = lines.Where(l => l.Length > 2)
                      .SelectMany(l => l)
                      .Where(p => !p.Contains('(') && !p.Contains("->"))
                      .Select(p => p.Trim(','))
                      .ToList();

      var blah = temp.FindAll(p => temp.IndexOf(p) == temp.LastIndexOf(p)).OrderBy(p => p).ToList();

      foreach (var line in lines)
      {
        //if (lines.Where(l => l.Length > 2).SelectMany(l => l)

        var disc = new Disc
        {
          Name = line[0],
          Weight = int.Parse(line[1].Substring(1, line[1].Length - 2))
        };

        discs.Add(disc);
      }

      foreach (var line in lines.Where(l => l.Length > 2).ToList())
      {
        var parent = discs.Find(d => d.Name == line[0]);

        for (int i = 3; i < line.Length; i++)
        {
          discs.Find(d => d.Name == line[i].Trim(',')).Parent = parent;
        }
      }

      var bottom = discs.Find(d => d.Parent == null);

      return bottom.Name;
    }
  }
}
