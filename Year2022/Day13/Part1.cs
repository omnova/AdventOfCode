using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2022.Day13
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var pairs = input.Split(Environment.NewLine + Environment.NewLine).Select(p => p.Split(Environment.NewLine)).ToArray();

      int sum = 0;

      for (int i = 0; i < pairs.Length; i++)
      {
        int result = Compare(pairs[i][0], pairs[i][1]);

        if (result == 1)
          sum += i + 1;
      }

      return sum;
    }

    private int Compare(string left, string right)
    {
      if (left.Length == 0 && right.Length == 0)
        return 0;
      else if (left.Length == 0 && right.Length > 0)
        return 1;
      else if (left.Length > 0 && right.Length == 0)
        return -1;

      bool isLeftInt = int.TryParse(left, out int leftValue);
      bool isRightInt = int.TryParse(right, out int rightValue);

      if (isLeftInt && isRightInt)
      {
        if (leftValue < rightValue)
          return 1;
        else if (leftValue > rightValue)
          return -1;
      }
      else if (isLeftInt && !isRightInt)
      {
        return Compare($"[{left}]", right);
      }
      else if (!isLeftInt && isRightInt)
      {
        return Compare(left, $"[{right}]");
      }
      else
      {
        string tempLeft = left.Substring(1, left.Length - 2);
        string tempRight = right.Substring(1, right.Length - 2);

        var tempLeftComponents = Split(tempLeft);
        var tempRightComponents = Split(tempRight);

        for (int i = 0; i < tempLeftComponents.Length && i < tempRightComponents.Length; i++)
        {
          int result = Compare(tempLeftComponents[i], tempRightComponents[i]);

          if (result != 0)
            return result;
        }

        if (tempLeftComponents.Length > tempRightComponents.Length)
          return -1;
        else if (tempLeftComponents.Length < tempRightComponents.Length)
          return 1;
      }

      return 0;
    }

    private string[] Split(string value)
    {
      var items = new List<string>();
      int depth = 0;
      int start = 0;

      for (int i = 0; i < value.Length; i++)
      {
        if (value[i] == '[')
          depth++;
        else if (value[i] == ']')
          depth--;
        else if (value[i] == ',' && depth == 0)
        {
          items.Add(value.Substring(start, i - start));
          start = i + 1;
        }
      }

      items.Add(value.Substring(start, value.Length - start));

      return items.ToArray();
    }
  }
}