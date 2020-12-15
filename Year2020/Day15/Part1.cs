using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day15
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var numbers = input.Split(',').Select(int.Parse).ToList();

      var lastUsages = new Dictionary<int, int>();
      int lastNumber = 0;
      bool isLastNumberNew = true;

      for (int i = 0; i < numbers.Count; i++)
      {
        lastUsages.Add(numbers[i], i);
        lastNumber = numbers[i];
      }

      for (int i = numbers.Count; i < 2020; i++)
      {
        int nextNumber = 0;

        // Last turn
        if (isLastNumberNew)
        {
          nextNumber = 0;
          lastUsages[lastNumber] = i - 1;
        }
        else
        {
          nextNumber = i - 1 - lastUsages[lastNumber];
          lastUsages[lastNumber] = i - 1;
        }

        isLastNumberNew = !lastUsages.ContainsKey(nextNumber);
        lastNumber = nextNumber;
      }

      return lastNumber;
    }
  }
}
