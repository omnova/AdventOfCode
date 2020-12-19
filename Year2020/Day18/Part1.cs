using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day18
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      long result = input.Replace(" ", "").Split(Environment.NewLine).Select(l => DoMaths(l, 0, out int length)).Sum();

      return result;
    }

    private long DoMaths(string math, int offset, out int newOffset)
    {
      long result = 0;
      int i = offset;
      Func<long, long, long> operation = null;

      for (; i < math.Length && math[i] != ')'; i++)
      {
        long operand = 0;

        if (math[i] == '(')
        {
          operand = DoMaths(math, ++i, out i);
        }
        else if (char.IsDigit(math[i]))
          operand = int.Parse(math[i].ToString());
        
        if (math[i] == '+')
          operation = new Func<long, long, long>((o1, o2) => o1 + o2);
        else if (math[i] == '*')
          operation = new Func<long, long, long>((o1, o2) => o1 * o2);
        else if (operation == null)
          result = operand;
        else
        {
          result = operation(result, operand);
          operation = null;
        }
      }

      newOffset = i;

      return result;
    }
  }
}
