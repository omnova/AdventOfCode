using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day11
{
  public class Part2 : IPuzzle
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

            for (int upY = 1; seatY - upY >= 0; upY++)
            {
              if (seats[seatY - upY][seatX] == '#')
              {
                adjacentOccupiedCount++;
                break;
              }
              else if (seats[seatY - upY][seatX] == 'L')
                break;
            }

            for (int downY = 1; seatY + downY < seats.Count; downY++)
            {
              if (seats[seatY + downY][seatX] == '#')
              {
                adjacentOccupiedCount++;
                break;
              }
              else if (seats[seatY + downY][seatX] == 'L')
                break;
            }

            for (int leftX = 1; seatX - leftX >= 0; leftX++)
            {
              if (seats[seatY][seatX - leftX] == '#')
              {
                adjacentOccupiedCount++;
                break;
              }
              else if (seats[seatY][seatX - leftX] == 'L')
                break;
            }

            for (int rightX = 1; seatX + rightX < seats[seatY].Count; rightX++)
            {
              if (seats[seatY][seatX + rightX] == '#')
              {
                adjacentOccupiedCount++;
                break;
              }
              else if (seats[seatY][seatX + rightX] == 'L')
                break;
            }

            for (int upLeftXY = 1; seatX - upLeftXY >= 0 && seatY - upLeftXY >= 0; upLeftXY++)
            {
              if (seats[seatY - upLeftXY][seatX - upLeftXY] == '#')
              {
                adjacentOccupiedCount++;
                break;
              }
              else if (seats[seatY - upLeftXY][seatX - upLeftXY] == 'L')
                break;
            }

            for (int upRightXY = 1; seatX + upRightXY < seats[seatY].Count && seatY - upRightXY >= 0; upRightXY++)
            {
              if (seats[seatY - upRightXY][seatX + upRightXY] == '#')
              {
                adjacentOccupiedCount++;
                break;
              }
              else if (seats[seatY - upRightXY][seatX + upRightXY] == 'L')
                break;
            }

            for (int downRightXY = 1; seatX + downRightXY < seats[seatY].Count && seatY + downRightXY < seats.Count; downRightXY++)
            {
              if (seats[seatY + downRightXY][seatX + downRightXY] == '#')
              {
                adjacentOccupiedCount++;
                break;
              }
              else if (seats[seatY + downRightXY][seatX + downRightXY] == 'L')
                break;
            }

            for (int downLeftXY = 1; seatX - downLeftXY >= 0 && seatY + downLeftXY < seats.Count; downLeftXY++)
            {
              if (seats[seatY + downLeftXY][seatX - downLeftXY] == '#')
              {
                adjacentOccupiedCount++;
                break;
              }
              else if (seats[seatY + downLeftXY][seatX - downLeftXY] == 'L')
                break;
            }

            if (seats[seatY][seatX] == '#' && adjacentOccupiedCount >= 5)
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
          return nextState.SelectMany(s => s).Count(s => s == '#');

        seats = nextState;
      }

      return null;
    }
  }
}
