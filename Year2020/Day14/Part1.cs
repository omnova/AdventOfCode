using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day14
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var lines = input.Replace("mem[", "").Replace("] = ", ",").Split(Environment.NewLine).ToList();

      string mask = null;
      var addressValues = new Dictionary<long, long>();

      foreach (string line in lines)
      {
        if (line.Contains("mask"))
        {
          mask = line.Substring(7);
        }
        else
        {
          int address = int.Parse(line.Split(",")[0]);
          string valueString = Convert.ToString(int.Parse(line.Split(",")[1]), 2).PadLeft(mask.Length, '0');

          long value = 0;

          for (int i = 0; i < valueString.Length; i++)
          {
            value <<= 1;

            if (mask[i] != 'X')
              value += int.Parse(mask[i].ToString());
            else
              value += int.Parse(valueString[i].ToString());
          }

          if (addressValues.ContainsKey(address))
            addressValues[address] = value;
          else
            addressValues.Add(address, value);
        }
      }

      return addressValues.Values.Sum();
    }
  }
}
