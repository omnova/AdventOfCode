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
        var groupAnswers = new HashSet<char>("abcdefghijklmnopqrstuvwxyz".ToCharArray());

        var people = group.Split(Environment.NewLine);

        foreach (var person in people)
        {
          var personAnswers = new HashSet<char>();

          person.ToCharArray().ToList().ForEach(y => personAnswers.Add(y));

          groupAnswers.IntersectWith(personAnswers);
        }

        totalYesCounts += groupAnswers.Count;
      }

      return totalYesCounts;
    }
  }
}