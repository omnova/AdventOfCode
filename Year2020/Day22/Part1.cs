using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode.Year2020.Day22
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var hands = input.Split(Environment.NewLine + Environment.NewLine).Select(s => new Queue<int>(s.Split(Environment.NewLine).Skip(1).Select(int.Parse).ToList())).ToList();

      while (!hands.Any(h => h.Count == 0))
      {
        var play = hands.Select(h => h.Dequeue()).ToList();

        int winner = play.IndexOf(play.Max());

        hands[winner].Enqueue(play[winner]);
        hands[winner].Enqueue(play[(winner + 1) % 2]);
      }

      int multiplier = 1;

      long result = hands.FirstOrDefault(h => h.Count > 0).Reverse().Aggregate(0, (acc, val) => acc + (val * multiplier++));

      return result;
    }
  }
}
