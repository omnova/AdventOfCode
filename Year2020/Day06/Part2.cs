using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day06
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var groups = input.Split(Environment.NewLine + Environment.NewLine);

      int totalYesCounts = 0;

      foreach (var group in groups)
      {
        var people = group.Split(Environment.NewLine).ToList();
        var groupAnswers = new HashSet<char>(people.SelectMany(p => p));

        people.ForEach(person => groupAnswers.IntersectWith(new HashSet<char>(person.ToCharArray())));

        totalYesCounts += groupAnswers.Count;
      }

      return totalYesCounts;
    }
  }
}