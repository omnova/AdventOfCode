using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2017.Day02
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var spreadsheet = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                             .Select(r => r.Split((char[])null, StringSplitOptions.RemoveEmptyEntries).Select(c => int.Parse(c)).ToList())
                             .ToList();

      return spreadsheet.Sum(r => GetRowValue(r)).ToString();
    }

    private int GetRowValue(List<int> row)
    {
      row.Sort();

      for (int i = 0; i < row.Count - 1; i++)
      {
        for (int j = i + 1; j < row.Count; j++)
        {
          if (row[j] % row[i] == 0)
            return row[j] / row[i];
        }
      }

      return 0;
    }
  }
}
