using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day10
{
  public class Part2 : IPuzzle
  {
    private static long totalCount = 0;

    public object Run(string input)
    {
      var adapters = input.Split(Environment.NewLine).Select(int.Parse).OrderBy(a => a).ToList();
      
      adapters.Insert(0, 0);
      adapters.Add(adapters[adapters.Count - 1] + 3);

      int deviceJoltage = adapters[adapters.Count - 1] + 3;

      var nextStepCounts = Enumerable.Repeat(0, adapters.Count).ToList();
      
      for (int i = 0; i < adapters.Count - 1; i++)
      {
        for (int j = i + 1; j < adapters.Count; j++)
        {
          if (adapters[j] - adapters[i] <= 3)
            nextStepCounts[i]++;
        }
      }

      //nextStepCounts.RemoveAll(s => s == 1);

      GetPathCount(nextStepCounts, 0);

      return totalCount;
    }

    private void GetPathCount(List<int> nextStepCounts, int index)
    {
      if (index == nextStepCounts.Count - 1)
      {
        totalCount++;
        return;
      }

      for (int nextStep = 0; nextStep < nextStepCounts[index]; nextStep++)
      {
        GetPathCount(nextStepCounts, index + nextStep + 1);
      }
    }
  }
}
