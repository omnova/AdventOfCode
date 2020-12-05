using System;
using System.Collections.Generic;
using System.Linq;
namespace AdventOfCode.Year2020.Day05
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var seatInstructions = input.Split(Environment.NewLine);

      int maxSeatId = seatInstructions.Max(GetSeatId);

      return maxSeatId;
    }

    private int GetSeatId(string seatInstruction)
    {
      int seatId = Convert.ToInt32(seatInstruction.Replace('B', '1').Replace('R', '1').Replace('F', '0').Replace('L', '0'), 2);

      return seatId;
    }
  }
}
