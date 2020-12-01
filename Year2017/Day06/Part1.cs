using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2017.Day06
{
  public class Part1 : IPuzzle
  {
    public string Run(string input)
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
          break;

        configurationHistory.Add(configuration);
      }

      return configurationHistory.Count.ToString();
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
