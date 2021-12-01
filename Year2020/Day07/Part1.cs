using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day07
{
  public class Part1 : IPuzzle
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

      int numGoldContainers = bagContents.Count(r => ContainsGold(bagContents, r.Key));

      return numGoldContainers;
    }

    private bool ContainsGold(Dictionary<string, Dictionary<string, int>> bagContents, string container)
    {
      foreach (var contained in bagContents[container])
      {
        if (contained.Key == "shiny gold" || (bagContents.ContainsKey(contained.Key) && ContainsGold(bagContents, contained.Key)))
          return true;
      }

      return false;
    }
  }
}
