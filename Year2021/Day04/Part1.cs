using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2021.Day04
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var numbers = input.Split(Environment.NewLine)[0].Split(',').Select(int.Parse).ToArray();
      var boards = input.Split(Environment.NewLine + Environment.NewLine).Skip(1).Select(Board.Parse).ToArray();

      foreach (int number in numbers)
      {
        foreach (var board in boards)
        {
          board.CallNumber(number);
        }

        var winningBoards = boards.Where(b => b.HasBingo()).ToList();

        if (winningBoards.Any())
        {
          int score = winningBoards.First().CalculateScore();

          return score * number;
        }
      }

      return "No winner";
    }
  }
}
