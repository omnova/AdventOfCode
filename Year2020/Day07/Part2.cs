using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day07
{
  public class Part2 : IPuzzle
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

      int numGoldContainers = GetContainedBagCount(relationships, "shiny gold bags");

      return numGoldContainers;
    }

    private int GetContainedBagCount(Dictionary<string, Dictionary<string, int>> relationships, string container)
    {
      int numContainedBags = 0;

      foreach (var contained in relationships[container])
      {
        numContainedBags += GetContainedBagCount(relationships, contained.Key) * contained.Value + contained.Value;
      }

      return numContainedBags;
    }
  }
}
