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

      var seats = new bool[128 * 8];

      seatInstructions.Select(s => GetSeatId(s)).ToList().ForEach(s => seats[s] = true);

      int seatId = seats.Skip(8).Take(126 * 8).ToList().IndexOf(false) + 8;

      return seatId;
    }

    private int GetSeatId(string seatInstruction)
    {
      int seatId = Convert.ToInt32(seatInstruction.Replace('B', '1').Replace('R', '1').Replace('F', '0').Replace('L', '0'), 2);

      return seatId;
    }
  }
}
