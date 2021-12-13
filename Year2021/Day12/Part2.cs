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

      var fullPaths = new HashSet<string> { "start" };
      var completedPaths = new HashSet<string>();

      do
      {
        var newPaths = new HashSet<string>();

        foreach (var path in fullPaths)
        {
          var pathNodes = path.Split(',');

          string currentNode = pathNodes.Last();

          if (currentNode == "end")
          {
            completedPaths.Add(path);
            continue;
          }

          var hasRevisitedSmalLCave = pathNodes.Where(n => n.ToLower() == n).Any(n => pathNodes.Count(c => c == n) > 1);

          var validNextNodes = nextNodes[currentNode].Where(n => n.ToUpper() == n || !pathNodes.Contains(n) || (!hasRevisitedSmalLCave && pathNodes.Count(pn => pn == n) < 2)).ToList();

          foreach (var validNextNode in validNextNodes)
          {
            string newPath = path + "," + validNextNode;

            newPaths.Add(newPath);
          }
        }

        fullPaths = newPaths;
      }
      while (fullPaths.Count > 0);

      return completedPaths.Count;
    }
  }
}
