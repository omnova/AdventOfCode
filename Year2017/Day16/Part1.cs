using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2017.Day16
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var programs = string.Join(string.Empty, Enumerable.Range(0, 16).Select(p => ((char)(p + 97)).ToString()).ToList());

      var moves = input.Split(',');

      foreach (var move in moves)
      {
        if (move[0] == 's')
        {
          int numPrograms = int.Parse(move.Substring(1));

          programs = programs.Substring(programs.Length - numPrograms) + programs.Substring(0, programs.Length - numPrograms);
        }
        else if (move[0] == 'x')
        {
          var positions = move.Substring(1).Split('/').Select(int.Parse).ToArray();

          char temp = programs[positions[0]];
          char[] array = programs.ToCharArray();

          array[positions[0]] = array[positions[1]];
          array[positions[1]] = temp;
          programs = new string(array);
        }
        else if (move[0] == 'p')
        {
          var positions = move.Substring(1).Split('/').Select(p => programs.IndexOf(p)).ToArray();

          char temp = programs[positions[0]];
          char[] array = programs.ToCharArray();

          array[positions[0]] = array[positions[1]];
          array[positions[1]] = temp;
          programs = new string(array);
        }
      }

      return programs;
    }
  }
}
