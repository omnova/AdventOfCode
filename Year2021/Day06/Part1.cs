using System;
using System.Collections.Generic;
using System.Linq;
namespace AdventOfCode.Year2021.Day06
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var fish = input.Split(',').Select(int.Parse).ToList();

      for (int i = 0; i < 80; i++)
      {
        int newFish = 0;

        for (int f = 0; f < fish.Count; f++)
        {
          fish[f]--;

          if (fish[f] < 0)
          {
            fish[f] = 6;
            newFish++;
          }
        }

        for (int f = 0; f < newFish; f++)
          fish.Add(8);
      }     

      return fish.Count;
    }
  }
}
