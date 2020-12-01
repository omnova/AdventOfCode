using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2017.Day16
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      const int NumDances = 1000000000;
      var programs = Enumerable.Range(0, 16).Select(p => ((char)(p + 97))).ToArray();

      var moves = input.Split(',');

      var programsIndex = new string(programs);
      var programsSwap = new string(programs);

      foreach (var move in moves)
      {
        if (move[0] == 's')
        {
          int size = int.Parse(move.Substring(1));

          programsIndex = Spin(programsIndex, size);
        }
        else if (move[0] == 'x')
        {
          var positions = move.Substring(1).Split('/').Select(int.Parse).ToArray();

          programsIndex = SwapIndex(programsIndex, positions[0], positions[1]);
        }
        else if (move[0] == 'p')
        {
          var chars = move.Substring(1).Split('/').Select(char.Parse).ToArray();

          programsSwap = SwapPartner(programsSwap, chars[0], chars[1]);
        }
      }

      var indexTransform = programsIndex.Select(p => programs.ToList().IndexOf(p)).ToList();
      var swapTransform = programs.Select(p => programs.ToList().IndexOf(p)).ToDictionary(p => programs[p], p => programsSwap[p]);
      
      for (int i = 0; i < NumDances; i++)
      {
        ApplyIndexTransform(ref programs, indexTransform);
        ApplySwapTransform(ref programs, swapTransform);
      }

      return new string(programs);
    }

    private string Spin(string programs, int size)
    {
      return programs.Substring(programs.Length - size) + programs.Substring(0, programs.Length - size);
    }

    private string SwapIndex(string programs, int positionA, int positionB)
    {
      var array = programs.ToCharArray();

      array[positionA] = programs[positionB];
      array[positionB] = programs[positionA];

      return new string(array);
    }

    private string SwapPartner(string programs, char charA, char charB)
    {
      var array = programs.ToCharArray();

      array[programs.IndexOf(charA)] = charB;
      array[programs.IndexOf(charB)] = charA;

      return new string(array);
    }

    private void ApplyIndexTransform(ref char[] programs, List<int> transform)
    {
      var newPrograms = new char[programs.Length];

      for (int p = 0; p < programs.Length; p++)
      {
        newPrograms[p] = programs[transform[p]];
      }

      programs = newPrograms;
    }

    private void ApplySwapTransform(ref char[] programs, Dictionary<char,char> transform)
    {
      var newPrograms = new char[programs.Length];

      for (int p = 0; p < programs.Length; p++)
      {
        newPrograms[p] = transform[programs[p]];
      }

      programs = newPrograms;
    }
  }
}
