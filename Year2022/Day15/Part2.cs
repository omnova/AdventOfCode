using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2022.Day15
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var beacons = input
        .Split(Environment.NewLine)
        .Select(l => new List<int>
        {
          int.Parse(l.Substring(l.IndexOf('=') + 1, l.IndexOf(',') - l.IndexOf('=') - 1)),
          int.Parse(l.Substring(l.IndexOf("y=") + 2, l.IndexOf(':') - l.IndexOf("y=") - 2)),
          int.Parse(l.Substring(l.LastIndexOf("x=") + 2, l.LastIndexOf(',') - l.LastIndexOf("x=") - 2)),
          int.Parse(l.Substring(l.LastIndexOf('=') + 1))
        })
        .Select(l => new int[] { l[0], l[1], l[2], l[3], Math.Abs(l[2] - l[0]) + Math.Abs(l[3] - l[1]) })
        .ToArray();

      int maxCoord = 4000000;

      foreach (var beacon in beacons)
      { 
        int searchRadius = beacon[4] + 1;

        for (int x = beacon[0] - searchRadius; x <= beacon[0] + searchRadius; x++)
        {
          if (x < 0 || x > maxCoord)
            continue;

          int y = beacon[1] - (searchRadius - Math.Abs(beacon[0] - x));

          if (y >= 0)
          {
            bool isBeacon = IsMissingBeacon(beacon, x, y, beacons);

            if (isBeacon)
            {
              long frequency = ((long)x * 4000000) + (long)y;

              return frequency;
            }
          }

          y = beacon[1] + (searchRadius - Math.Abs(beacon[0] - x));

          if (y <= maxCoord)
          {
            bool isBeacon = IsMissingBeacon(beacon, x, y, beacons);

            if (isBeacon)
            {
              long frequency = ((long)x * 4000000) + (long)y;

              return frequency;
            }
          }
        }
      }

      return null;
    }

    private bool IsMissingBeacon(int[] beacon, int x, int y, int[][] beacons)
    {
      foreach (var otherBeacon in beacons)
      {
        if (beacon == otherBeacon)
          continue;

        if ((otherBeacon[0] == x && otherBeacon[1] == y) || (otherBeacon[2] == x && otherBeacon[3] == y))
          return false;

        int radius = otherBeacon[4];
        int stairDistance = Math.Abs(x - otherBeacon[0]) + Math.Abs(y - otherBeacon[1]);

        if (stairDistance <= radius)
          return false;
      }

      return true;
    }
  }
}
