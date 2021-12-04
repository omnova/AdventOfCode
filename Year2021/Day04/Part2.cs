using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Year2021.Day04
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var numbers = input.Split(Environment.NewLine)[0].Split(',').Select(int.Parse).ToArray();
      var boards = input.Split(Environment.NewLine + Environment.NewLine).Skip(1).Select(Board.Parse).ToList();

      foreach (int number in numbers)
      {
        foreach (var board in boards)
        {
          board.CallNumber(number);
        }

        var winningBoards = boards.Where(b => b.HasBingo()).ToList();

        // Last board to win
        if (winningBoards.Count == 1 && boards.Count == 1)
        {
          int score = boards.First().CalculateScore();

          return score * number;
        }
        else
        {
          boards.RemoveAll(b => winningBoards.Contains(b));
        }
      }

      return "No winner";
    }
  }
}
