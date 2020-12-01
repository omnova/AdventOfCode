using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2016.Day11
{
  public class Part1 : IPuzzle
  {
    public string Run(string input)
    {
      var floors = new List<int> { 4, 5, 1, 0 };

      int elevatorFloor = 0;
      int steps = 0;

      while (floors[3] != floors.Sum())
      {
        if (elevatorFloor == 0 || floors[elevatorFloor - 1] == 0)
        {
          floors[elevatorFloor] -= 2;
          elevatorFloor++;
          floors[elevatorFloor] += 2;

          steps++;
        }
        else
        {
          floors[elevatorFloor]++;
          floors[elevatorFloor - 1]--;

          steps += 2;
        }
      }

      return steps.ToString();
    }
  }
}
