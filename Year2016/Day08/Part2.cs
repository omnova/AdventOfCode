using System;
using System.Linq;
using System.Text;

namespace AdventOfCode.Year2016.Day08
{
  public class Part2 : IPuzzle
  {
    public string Run(string input)
    {
      const int ScreenSizeX = 50;
      const int ScreenSizeY = 6;

      var screen = new bool[ScreenSizeX, ScreenSizeY];

      var instructions = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
        .Select(i => i.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries))
        .ToArray();

      foreach (var instruction in instructions)
      {
        if (instruction[0] == "rect")
        {
          for (int x = 0; x < int.Parse(instruction[1].Substring(0, instruction[1].IndexOf('x'))); x++)
          {
            for (int y = 0; y < int.Parse(instruction[1].Substring(instruction[1].IndexOf('x') + 1)); y++)
            {
              screen[x, y] = true;
            }
          }
        }
        else if (instruction[0] == "rotate")
        {
          if (instruction[1] == "row")
          {
            int y = int.Parse(instruction[2].Substring(2));

            bool[] newRow = new bool[ScreenSizeX];

            for (int x = 0; x < ScreenSizeX; x++)
            {
              newRow[(x + int.Parse(instruction[4])) % ScreenSizeX] = screen[x, y];
            }

            for (int x = 0; x < ScreenSizeX; x++)
            {
              screen[x, y] = newRow[x];
            }
          }
          else if (instruction[1] == "column")
          {
            int x = int.Parse(instruction[2].Substring(2));

            bool[] newColumn = new bool[ScreenSizeY];

            for (int y = 0; y < ScreenSizeY; y++)
            {
              newColumn[(y + int.Parse(instruction[4])) % ScreenSizeY] = screen[x, y];
            }

            for (int y = 0; y < ScreenSizeY; y++)
            {
              screen[x, y] = newColumn[y];
            }
          }
        }
      }

      return DrawScreen(screen);
    }

    private string DrawScreen(bool[,] screen)
    {
      var builder = new StringBuilder();

      builder.AppendLine();

      for (int y = 0; y < screen.GetLength(1); y++)
      {
        for (int x = 0; x < screen.GetLength(0); x++)
        {
          builder.Append(screen[x, y] ? "#" : " ");
        }

        builder.AppendLine();
      }

      return builder.ToString();
    }
  }
}
