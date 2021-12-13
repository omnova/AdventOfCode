using System;
using System.Collections.Generic;
using System.Linq;
namespace AdventOfCode.Year2021.Day12
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var connections = input.Split(Environment.NewLine).Select(l => l.Split('-')).ToList();

      var nodes = connections.SelectMany(l => l).Distinct().ToList();
      var nextNodes = nodes.Where(n => n != "end").ToDictionary(n => n, n => connections.Where(p => p[0] == n && p[1] != "start").Select(p => p[1]).Union(connections.Where(p => p[1] == n && p[0] != "start").Select(p => p[0]).ToList()).ToList());

      var fullPaths = new List<string> { "start" };
      var completedPaths = new List<string>();

      do
      {
        var newPaths = new List<string>(fullPaths.Count * 2);

        foreach (var path in fullPaths)
        {
          string currentNode = path.Split(',').Last();

          if (currentNode == "end")
          {
            completedPaths.Add(path);
            continue;
          }

          var hasRevisitedSmalLCave = path.Split(',').Where(n => n.ToLower() == n).Any(n => path.Split(',').Count(c => c == n) > 1);

          var validNextNodes = nextNodes[currentNode].Where(n => n.ToUpper() == n || !path.Split(',').Contains(n) || (!hasRevisitedSmalLCave && path.Split(',').Count(pn => pn == n) < 2)).ToList();

          foreach (var validNextNode in validNextNodes)
          {
            string newPath = path + "," + validNextNode;

            if (!newPaths.Contains(newPath))
              newPaths.Add(newPath);
          }
        }

        fullPaths = newPaths.Distinct().ToList();
      }
      while (fullPaths.Any());

      return completedPaths.Count;
    }
  }
}
