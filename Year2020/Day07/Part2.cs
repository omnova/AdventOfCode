using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day07
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var lines = input.Replace(" bags", "").Replace(" bag", "").Split("." + Environment.NewLine);

      var bagContents = new Dictionary<string, Dictionary<string, int>>();

      foreach (var line in lines)
      {
        var parts = line.Split(" contain ");

        string container = parts[0];

        bagContents.Add(container, new Dictionary<string, int>());

        if (parts[1] == "no other")
          continue;

        foreach (var contains in parts[1].Split(", "))
        {
          string containedBags = contains.Substring(contains.IndexOf(' ') + 1);
          int number = int.Parse(contains.Substring(0, contains.IndexOf(' ')));

          bagContents[container].Add(containedBags, number);
        }
      }

      int numGoldContainers = GetContainedBagCount(bagContents, "shiny gold");
      
      return numGoldContainers;
    }

    private int GetContainedBagCount(Dictionary<string, Dictionary<string, int>> bagContents, string container)
    {
      int numContainedBags = bagContents[container].Sum(contained => GetContainedBagCount(bagContents, contained.Key) * contained.Value + contained.Value);

      return numContainedBags;
    }
  }
}
