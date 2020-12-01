using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2017.Day07
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var lines = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                       .Select(l => l.Split())
                       .ToList();

      var discs = new List<Disc>();

      foreach (var line in lines)
      {
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
          parent.Children.Add(discs.Find(d => d.Name == line[i].Trim(',')));

          discs.Find(d => d.Name == line[i].Trim(',')).Parent = parent;
        }
      }

      var problemParent = discs.Find(d => d.Parent == null);

      while (true)
      {
        var problemChild = problemParent.Children.FirstOrDefault(d => d.IsUnbalanced);

        if (problemChild != null)
          problemParent = problemChild;
        else
          break;
      }

      var problemDisc = problemParent.Children.Find(d => !d.Parent.Children.Any(s => s.Name != d.Name && s.TotalWeight == d.TotalWeight));
      var correctDisc = problemParent.Children.Find(d => d != problemDisc);

      return (problemDisc.Weight - (problemDisc.TotalWeight - correctDisc.TotalWeight)).ToString();
    }
  }
}
