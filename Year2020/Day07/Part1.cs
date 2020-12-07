using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day07
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var lines = input.Split("." + Environment.NewLine);

      var relationships = new Dictionary<string, Dictionary<string, int>>();

      foreach (var line in lines)
      {
        var parts = line.Split(" contain ");

        string container = parts[0];

        relationships.TryAdd(container, new Dictionary<string, int>());

        if (parts[1] == "no other bags")
          continue;

        foreach (var contains in parts[1].Split(", "))
        {
          string contained = contains.Substring(contains.IndexOf(' ') + 1);

          if (contained.Last() == 'g')
            contained += "s";

          int number = int.Parse(contains.Substring(0, contains.IndexOf(' ')));

          if (!relationships[container].TryAdd(contained, number))
            relationships[container][contained] += number;

          if (!relationships.ContainsKey(contained))
            relationships.Add(contained, new Dictionary<string, int>());
        }
      }

      int numGoldContainers = relationships.Count(r => ContainsGold(relationships, r.Key));

      return numGoldContainers;
    }

    private bool ContainsGold(Dictionary<string, Dictionary<string, int>> relationships, string container)
    {
      foreach (var contained in relationships[container])
      {
        if (contained.Key == "shiny gold bags")
          return true;
        else if (ContainsGold(relationships, contained.Key))
          return true;
      }

      return false;
    }
  }
}
