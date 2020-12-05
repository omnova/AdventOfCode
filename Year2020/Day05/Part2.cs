using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day05
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var seatInstructions = input.Split(Environment.NewLine);

      var seats = new int[128 * 8];

      seatInstructions.Select(s => GetSeatId(s)).ToList().ForEach(s => seats[s] = s);

      int seatId = seats.Skip(8).Take(126 * 8).ToList().IndexOf(0) + 8;

      return seatId;
    }

    private int GetSeatId(string seatInstruction)
    {
      string rowInstructions = seatInstruction.Substring(0, 7);
      string columnInstructions = seatInstruction.Substring(7);

      int row = 0;

      for (int i = 0; i < 7; i++)
      {
        if (rowInstructions[i] == 'B')
          row += (1 << (6 - i));
      }

      int column = 0;

      for (int i = 0; i < 3; i++)
      {
        if (columnInstructions[i] == 'R')
          column += (1 << (2 - i));
      }
     
      return (row * 8) + column;
    }
  }
}
