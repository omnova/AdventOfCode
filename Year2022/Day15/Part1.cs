using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace AdventOfCode.Year2022.Day15
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var beacons = input
        .Split(Environment.NewLine)
        .Select(l => new int[]
        {
          int.Parse(l.Substring(l.IndexOf('=') + 1, l.IndexOf(',') - l.IndexOf('=') - 1)),
          int.Parse(l.Substring(l.IndexOf("y=") + 2, l.IndexOf(':') - l.IndexOf("y=") - 2)),
          int.Parse(l.Substring(l.LastIndexOf("x=") + 2, l.LastIndexOf(',') - l.LastIndexOf("x=") - 2)),
          int.Parse(l.Substring(l.LastIndexOf('=') + 1))
        })      
       .ToArray();

      int y = 2000000;

      int maxX = beacons.Select(b => Math.Max(b[0], b[2])).Max() * 2;

      var line = new char[maxX * 2 + 1];

      foreach (var beacon in beacons)
      {
        if (beacon[1] == y)
          line[beacon[0] + maxX] = 'S';

        if (beacon[3] == y)
          line[beacon[2] + maxX] = 'B';

        int stepsX = Math.Abs(beacon[2] - beacon[0]);
        int stepsY = Math.Abs(beacon[3] - beacon[1]);

        int radius = stepsX + stepsY;
        int effectiveRadius = Math.Max(0, radius - Math.Abs(y - beacon[1]));       

        if (effectiveRadius > 0)
        {
          for (int x = beacon[0] - effectiveRadius; x <= beacon[0] + effectiveRadius; x++)
          {
            if (line[x + maxX] == 0)
              line[x + maxX] = '#';
          }
        }
      }

      return line.Where(x => x == '#').Count();
    }
  }
}