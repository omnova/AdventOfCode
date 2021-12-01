using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day13
{
  public class Part2 : IPuzzle
  {
    private class Bus
    {
      public int ID;
      public long RequiredOffset;

      public bool IsRequiredDeparture(long t)
      {
        return (t + RequiredOffset) % ID == 0;
      }
    }

    public object Run(string input)
    {
      var schedule = input.Split(Environment.NewLine)[1].Split(",");
      var busses = new List<Bus>();

      Console.Write("".PadLeft(5));
      for (int t = 0; t < schedule.Length; t++)
      {
        if (schedule[t] != "x")
        {
          busses.Add(new Bus { ID = int.Parse(schedule[t]), RequiredOffset = t });
          Console.Write(busses.FirstOrDefault(b => b.ID == int.Parse(schedule[t])).ID.ToString().PadLeft(3, ' '));
        }
      }
      Console.WriteLine();

      for (long t = 1068700; t < 1068800; t += 1)
      {
        Console.Write(t.ToString().PadRight(5));
        foreach (var bus in busses)
        {
          Console.Write(t % bus.ID == 0 ? bus.ID.ToString().PadLeft(3) : "   ");          
        }
        Console.WriteLine();

        bool isSuccess = IsSuccess(busses, t);

        if (isSuccess)
        {

        }
        
      }

      return null;
    }

    private bool IsSuccess(List<Bus> busses, long t)
    {
      foreach (var bus in busses)
      {
        if (!bus.IsRequiredDeparture(t))
          return false;
      }

      return true;
    }
  }
}
