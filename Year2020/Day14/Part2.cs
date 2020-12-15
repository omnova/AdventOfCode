using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day14
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var lines = input.Replace("mem[", "").Replace("] = ", ",").Split(Environment.NewLine).ToList();

      string baseMask = null;
      var masks = new List<string>();
      var addressValues = new Dictionary<long, long>();

      foreach (string line in lines)
      {
        if (line.Contains("mask"))
        {
          baseMask = line.Substring(7);

          int xCount = baseMask.Count(c => c == 'X');
          int numPermutations = 1 << xCount;

          for (int i = 0; i < numPermutations; i++)
          {
            var mask = baseMask.ToCharArray();
            string permutation = Convert.ToString(i, 2).PadLeft(xCount, '0');
            int xIndex = 0;

            for (int c = 0; c < mask.Length; c++)
            {
              if (mask[c] == 'X')
                mask[c] = permutation[xIndex++];
            }

            masks.Add(new string(mask));
          }
        }
        else
        {
          string addressString = Convert.ToString(int.Parse(line.Split(",")[0]), 2).PadLeft(baseMask.Length, '0');
          long value = int.Parse(line.Split(",")[1]);

          for (int maskIndex = 0; maskIndex < masks.Count; maskIndex++)
          {
            string mask = masks[maskIndex];
            long address = 0;

            for (int i = 0; i < addressString.Length; i++)
            {
              address <<= 1;

              if (baseMask[i] == '0')
                address += int.Parse(addressString[i].ToString());
              else if (baseMask[i] == '1')
                address += 1;
              else if (baseMask[i] == 'X')
                address += int.Parse(mask[i].ToString());
            }

            if (addressValues.ContainsKey(address))
              addressValues[address] = value;
            else
              addressValues.Add(address, value);
          }
        }
      }

      return addressValues.Values.Sum();
    }
  }
}
