using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2021.Day17
{
  public class Part2 : IPuzzle
  {  
    public object Run(string input)
    {
      var target = input.Substring(input.IndexOf('x')).Replace("x=", "").Replace("y=", "").Split(", ").Select(c => c.Split("..").Select(int.Parse).ToArray()).ToArray();

      int minTargetRange = target[0][0];
      int maxTargetRange = target[0][1];
      int maxTargetHeight = Math.Max(target[1][0], target[1][1]);
      int minTargetHeight = Math.Min(target[1][0], target[1][1]);

      int maxX = maxTargetRange;
      int minX = 1;

      for (int i = 1; i <= minTargetRange; i += minX++) { }

      minX--;

      int minY = minTargetHeight;
      int maxY = (minTargetHeight % 2 == 1) ? Math.Abs(minTargetHeight) : Math.Abs(minTargetHeight) - 1;

      int count = 0;

      for (int x = minX; x <= maxX; x++)
      {
        for (int y = minY; y <= maxY; y++)
        {
          int velocityX = x;
          int velocityY = y;
          int positionX = 0;
          int positionY = 0;

          while (positionX <= maxTargetRange && (positionY >= minTargetHeight))
          {
            positionX += Math.Max(0, velocityX--);
            positionY += velocityY--;

            if (positionX >= minTargetRange && positionX <= maxTargetRange && positionY >= minTargetHeight && positionY <= maxTargetHeight)
            {
              count++;
              break;
            }
          }
        }
      }

      return count;
    }
  }
}
