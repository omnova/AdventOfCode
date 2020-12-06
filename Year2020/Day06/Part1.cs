using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day06
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var groups = input.Split(Environment.NewLine + Environment.NewLine);

      int totalYesCounts = 0;

      foreach (var group in groups)
      {
        var groupAnswers = new HashSet<char>();
        var people = group.Split(Environment.NewLine).ToList();

        people.ForEach(person => person.ToCharArray().ToList().ForEach(y => groupAnswers.Add(y)));

        totalYesCounts += groupAnswers.Count();
      }

      return totalYesCounts;
    }
  }
}
