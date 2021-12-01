using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day16
{
  public class Part1 : IPuzzle
  {
    private class Field
    {
      public string Name;
      private List<FieldRange> valueRanges;

      public Field(string fieldString)
      {
        var parts = fieldString.Split(": ");

        this.Name = parts[0];
        this.valueRanges = parts[1].Split(" or ").Select(r => new FieldRange(r)).ToList();
      }

      public bool IsValidValue(int value)
      {
        foreach (var range in this.valueRanges)
        {
          if (value >= range.Min && value <= range.Max)
            return true;
        }

        return false;
      }
    }

    private class FieldRange
    {
      public int Min;
      public int Max;

      public FieldRange(string rangeString)
      {
        var parts = rangeString.Split('-');

        this.Min = int.Parse(parts[0]);
        this.Max = int.Parse(parts[1]);
      }
    }

    public object Run(string input)
    {
      var sections = input.Split(Environment.NewLine + Environment.NewLine);

      var fields = sections[0].Split(Environment.NewLine).Select(f => new Field(f)).ToList();
      var ticketValues = sections[1].Split(Environment.NewLine)[1].Split(',').Select(int.Parse).ToList();
      var nearbyTicketValues = sections[2].Split(Environment.NewLine).Skip(1).Select(t => t.Split(',').Select(int.Parse).ToList()).ToList();

      long errorRate = nearbyTicketValues.SelectMany(v => v).Where(v => !fields.Any(f => f.IsValidValue(v))).Sum();

      return errorRate;
    }
  }
}
