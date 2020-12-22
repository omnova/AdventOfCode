using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode.Year2020.Day22
{
  public class Part2 : IPuzzle
  {    
    public object Run(string input)
    {
      var hands = input.Split(Environment.NewLine + Environment.NewLine).Select(s => new Queue<byte>(s.Split(Environment.NewLine).Skip(1).Select(byte.Parse).ToList())).ToList();

      byte winner = PlayGame(hands, out Queue<byte> winningHand);

      int multiplier = 1;

      return winningHand.Reverse().Aggregate(0, (acc, val) => acc + (val * multiplier++));
    }

    private byte PlayGame(List<Queue<byte>> hands, out Queue<byte> winningHand)
    {
      var handConfigurations = new List<List<string>> { new List<string>(), new List<string>() };

      while (!hands.Any(h => h.Count == 0))
      {
        for (byte h = 0; h < hands.Count; h++)
        {
          if (handConfigurations[h].Contains(string.Join(',', hands[h])))
          {
            winningHand = hands[h];
            return 0;
          }
          else
            handConfigurations[h].Add(string.Join(',', hands[h]));
        }

        var play = hands.Select(h => h.Dequeue()).ToList();

        byte? winner = null;

        if (hands[0].Count >= play[0] && hands[1].Count >= play[1])
        {
          var subGameHands = hands.Select(h => new Queue<byte>(h.Take(play[hands.IndexOf(h)]).ToList())).ToList();

          winner = PlayGame(subGameHands, out Queue<byte> dontcare);
        }
        else
          winner = (play[0] > play[1] ? 0 : 1);

        hands[winner.Value].Enqueue(play[winner.Value]);
        hands[winner.Value].Enqueue(play[(winner.Value + 1) % 2]);
      }

      winningHand = hands[0].Any() ? hands[0] : hands[1];

      return hands[0].Any() ? 0 : 1;
    }
  }
}
