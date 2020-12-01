using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2016.Day16
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      const int diskSize = 272;

      string disk = input;

      while (disk.Length < diskSize)
      {
        disk += '0' + string.Concat(disk.ToCharArray().Reverse().Select(c => c == '0' ? '1' : '0').ToArray());
      }

      var data = new BitArray(disk.Substring(0, diskSize).Select(b => b == '1').ToArray());

      do
      {
        var checksum = new BitArray(data.Length / 2);

        for (int i = 0; i < data.Length; i += 2)
        {
          checksum[i >> 1] = (data[i] == data[i + 1]);
        }

        data = checksum;
      }
      while (data.Length % 2 == 0);

      return string.Concat(data.Cast<bool>().Select(b => b ? '1' : '0'));
    }
  }
}
