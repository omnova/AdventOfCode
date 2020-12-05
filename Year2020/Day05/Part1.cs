using System;
using System.Collections.Generic;
using System.Linq;
namespace AdventOfCode.Year2020.Day05
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var seats = input.Split(Environment.NewLine);

      int maxSeatId = seats.Max(GetSeatId);

      return maxSeatId;
    }

    private int GetSeatId(string seat)
    {
      string rowInstructions = seat.Substring(0, 7);
      string columnInstructions = seat.Substring(7);

      int row = 0;
      int rowIncrement = 64;

      foreach (char instruction in rowInstructions.ToCharArray())
      {
        if (instruction == 'B')
          row += rowIncrement;

        rowIncrement /= 2;
      }

      int column = 0;
      int columnIncrement = 4;

      foreach (char instruction in columnInstructions.ToCharArray())
      {
        if (instruction == 'R')
          column += columnIncrement;

        columnIncrement /= 2;
      }

      return (row * 8) + column;
    }
  }
}
