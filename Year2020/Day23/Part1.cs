using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode.Year2020.Day23
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var cups = input.ToCharArray().Select(c => int.Parse(c.ToString())).ToList();

      int currentCup = cups[0];
      int totalCups = cups.Count;

      for (int i = 1; i <= 100; i++)
      {
        int pickup1 = cups.First(c => (cups.IndexOf(c) == (cups.IndexOf(currentCup) + 1) % cups.Count));
        int pickup2 = cups.First(c => (cups.IndexOf(c) == (cups.IndexOf(currentCup) + 2) % cups.Count));
        int pickup3 = cups.First(c => (cups.IndexOf(c) == (cups.IndexOf(currentCup) + 3) % cups.Count));

        var pickedUpCups = new List<int> { pickup1, pickup2, pickup3 };

        cups.RemoveAll(c => pickedUpCups.Contains(c));

        int? destinationCup = null;
        int targetCup = currentCup - 1;

        while (true)
        {
          if (targetCup == 0)
            targetCup = totalCups;

          if (cups.Any(c => c == targetCup))
          {
            destinationCup = targetCup;
            break;
          }

          targetCup--;
        }

        cups.InsertRange(cups.IndexOf(destinationCup.Value) + 1, pickedUpCups);

        currentCup = cups[(cups.IndexOf(currentCup) + 1) % cups.Count];
      }

      var result = string.Join("", cups.Skip(cups.IndexOf(1))).Replace("1", "") + string.Join("", cups.Take(cups.IndexOf(1) + 1)).Replace("1", "");

      return result;
    }
  }
}
