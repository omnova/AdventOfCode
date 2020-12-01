using System;
using System.Collections.Generic;

namespace AdventOfCode.Year2017.Day17
{
  public class Part2 : IPuzzle
  {
    private const int NumInserts = 50000000;

    public object Run(string input)
    {
      int steps = int.Parse(input);

      var buffer = new LinkedList<int>();
      var current = buffer.AddFirst(0);

      for (int i = 1; i <= NumInserts; i++)
      {
        for (int j = 0; j < steps; j++)
        {
          current = current.Next ?? buffer.First;
        }

        current = buffer.AddAfter(current, i);
      }

      return buffer.Find(0).Next.Value.ToString();      
    }
  }
}
