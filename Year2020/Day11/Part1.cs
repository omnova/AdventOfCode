using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day11
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var seats = input.Split(Environment.NewLine).Select(s => s.ToList()).ToList();

      for (int round = 1; round < 1000; round++)
      {
        var nextState = seats.Select(s => new List<char>(s)).ToList();
        bool hasChange = false;

        for (int seatY = 0; seatY < seats.Count; seatY++)
        {
          for (int seatX = 0; seatX < seats[seatY].Count; seatX++)
          {
            int adjacentOccupiedCount = 0;

            for (int adjacentX = Math.Max(0, seatX - 1); adjacentX <= Math.Min(seatX + 1, seats[seatY].Count - 1); adjacentX++)
            {
              for (int adjacentY = Math.Max(0, seatY - 1); adjacentY <= Math.Min(seatY + 1, seats.Count - 1); adjacentY++)
              {
                if (seats[adjacentY][adjacentX] == '#' && !(adjacentX == seatX && adjacentY == seatY))
                  adjacentOccupiedCount++;
              }
            }

            if (seats[seatY][seatX] == '#' && adjacentOccupiedCount >= 4)
            {
              nextState[seatY][seatX] = 'L';
              hasChange = true;
            }
            else if (seats[seatY][seatX] == 'L' && adjacentOccupiedCount == 0)
            {
              nextState[seatY][seatX] = '#';
              hasChange = true;
            }
          }
        }

        if (!hasChange)
          return seats.SelectMany(s => s).Count(s => s == '#');

        seats = nextState;
      }

      return null;
    }
  }
}
