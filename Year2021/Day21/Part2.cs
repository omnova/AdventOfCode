using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2021.Day21
{
  public class Part2 : IPuzzle
  {  
    public object Run(string input)
    {
      var playerPositions = input.Split(Environment.NewLine).Select(l => int.Parse(l.Split(": ").Last())).ToArray();
      var playerScores = new int[2];

      int numRolls = 0;

      // Track counts of games at each stage (should be much more finite than number of universes
      // There's probably math to figure this out

      while (true)
      {
        for (int p = 0; p < playerPositions.Length; p++)
        {
          int roll = ++numRolls + ++numRolls + ++numRolls;

          playerPositions[p] = ((playerPositions[p] - 1 + roll) % 10) + 1;
          playerScores[p] += playerPositions[p];

          if (playerScores[p] >= 1000)
            return playerScores[(p + 1) % 2] * numRolls;
        }
      }
    }
  }
}
