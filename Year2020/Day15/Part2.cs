using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day15
{
  public class Part2 : IPuzzle
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

      for (int i = numbers.Count; i < 30000000; i++)
      {
        int nextNumber = isLastNumberNew ? 0 : i - 1 - lastUsages[lastNumber];

        lastUsages[lastNumber] = i - 1;

        isLastNumberNew = !lastUsages.ContainsKey(nextNumber);
        lastNumber = nextNumber;
      }

      return lastNumber;
    }
  }
}
