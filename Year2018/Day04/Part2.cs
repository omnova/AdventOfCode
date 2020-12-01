using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2018.Day04
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var guards = new Dictionary<int, int[]>();

      var logs = input.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
       .OrderBy(l => l)
       .ToList();

      int activeGuardId = -2;
      int asleepTime = 0;
      bool isAwake = true;

      foreach (string log in logs)
      {
        var time = DateTime.Parse(log.Substring(1, 16));

        if (time.Hour != 0)
          time.AddMinutes(60 - time.Minute);

        if (log[25] == '#')
        {
          // Old guard
          if (!isAwake && activeGuardId > 0)
          {
            for (int i = asleepTime; i < 60; i++)
            {
              guards[activeGuardId][i]++;
            }
          }

          // New guard takes post
          activeGuardId = int.Parse(log.Split(new string[] { "#", " begins shift" }, StringSplitOptions.RemoveEmptyEntries)[1]);

          if (!guards.ContainsKey(activeGuardId))
            guards.Add(activeGuardId, new int[60]);

          asleepTime = 0;
          isAwake = true;
        }
        else if (log[19] == 'f')
        {
          // Falls asleep
          asleepTime = time.Minute;
          isAwake = false;
        }
        else if (log[19] == 'w')
        {
          // Wakes up
          for (int i = asleepTime; i < time.Minute; i++)
          {
            guards[activeGuardId][i]++;
          }

          isAwake = true;
        }
      }

      var max = guards.OrderByDescending(g => g.Value.Max()).First();

      int answer = max.Key * max.Value.ToList().IndexOf(max.Value.Max());

      return answer.ToString();
    }
  }
}
