using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2017.Day06
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var banks = input.Split().Select(int.Parse).ToList();
      var configurationHistory = new List<string>
      {
        string.Join(" ", banks)
      };

      while (configurationHistory.Count < int.MaxValue)
      {
        PerformRedistribution(banks);

        string configuration = string.Join(" ", banks);

        if (configurationHistory.Contains(configuration))
          return (configurationHistory.Count - configurationHistory.IndexOf(configuration)).ToString();

        configurationHistory.Add(configuration);
      }

      throw new ApplicationException("We ran out of ints.");
    }

    private void PerformRedistribution(List<int> banks)
    {
      int most = banks.Max();
      int mostIndex = banks.IndexOf(most);

      banks[mostIndex] = 0;

      for (int i = mostIndex + 1; i < mostIndex + most + 1; i++)
      {
        banks[i % banks.Count]++;
      }
    }
  }
}