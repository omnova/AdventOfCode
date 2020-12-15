using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day13
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      long departureTime = int.Parse(input.Split(Environment.NewLine)[0]);
      var busses = input.Split(Environment.NewLine)[1].Split(",").Where(b => b != "x").Select(int.Parse).ToDictionary(b => b, b => (long)0);

      for (long t = 0; t < 10000000; t++)
      {
        foreach (var bus in busses)
        {
          if (busses[bus.Key] + bus.Key == t)
          {
            busses[bus.Key] += bus.Key;

            if (t >= departureTime)
              return bus.Key * (t - departureTime);
          }
        } 
      }

      return null;
    }
  }
}
