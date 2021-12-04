using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2021.Day04
{
  internal class Board
  {
    public int[,] Numbers { get; set; }
    public bool[,] NumberStatus { get; set; }

    public static Board Parse(string boardRaw)
    {
      var lines = boardRaw.Split(Environment.NewLine).Select(l => l.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()).ToArray();

      var board = new Board();

      board.Numbers = lines.ToMultidimensionalArray();
      board.NumberStatus = new bool[board.Numbers.GetLength(0), board.Numbers.GetLength(1)];

      return board;
    }

    public void CallNumber(int number)
    {
      for (int i = 0; i < this.Numbers.GetLength(0); i++)
      {
        for (int j = 0; j < this.Numbers.GetLength(1); j++)
        {
          if (this.Numbers[i, j] == number)
            this.NumberStatus[i, j] = true;
        }
      }
    }

    public bool HasBingo()
    {
      for (int i = 0; i < this.Numbers.GetLength(0); i++)
      {
        // Columns
        if (this.NumberStatus.Column(i).All(n => n))
          return true;

        // Rows
        if (this.NumberStatus.Row(i).All(n => n))
          return true;
      }

      return false;
    }

    public int CalculateScore()
    {
      int score = 0;

      for (int i = 0; i < this.Numbers.GetLength(0); i++)
      {
        for (int j = 0; j < this.Numbers.GetLength(1); j++)
        {
          if (!this.NumberStatus[i, j])
            score += this.Numbers[i, j];
        }
      }

      return score;
    }
  }
}
