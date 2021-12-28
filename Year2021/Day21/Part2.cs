using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2021.Day21
{
  public class Part2 : IPuzzle
  {
    private class Universe
    {
      public int Turn { get; private set; }
      public int[] Scores { get; private set; }
      public int[] Positions { get; private set; }

      public long Count { get; set; }
      public string Hash { get; private set; }

      public Universe(int turn, int player1Score, int player2Score, int player1Position, int player2Position)
      {
        Turn = turn;
        Scores = new int[2] { player1Score, player2Score };
        Positions = new int[2] { player1Position, player2Position };

        Count = 0;
        Hash = turn.ToString() + "|" + player1Score + "|" + player2Score + "|" + player1Position + "|" + player2Position;
      }
    }


    public object Run(string input)
    {
      var playerPositions = input.Split(Environment.NewLine).Select(l => int.Parse(l.Split(": ").Last())).ToArray();

      // Track counts of games at each stage (should be much more finite than number of universes
      // There's probably math to figure this out

      var universes = new Dictionary<string, Universe>();

      var start = new Universe(-1, 0, 0, playerPositions[0], playerPositions[1]);
      start.Count = 1;

      universes.Add(start.Hash, start);

      for (int t = 0; t < 20; t++)
      {
        for (int s1 = 0; s1 <= 31; s1++)
        {
          for (int s2 = 0; s2 <= 31; s2++)
          {
            for (int p1 = 1; p1 <= 10; p1++)
            {
              for (int p2 = 1; p2 <= 10; p2++)
              {
                var universe = new Universe(t, s1, s2, p1, p2);

                universes.Add(universe.Hash, universe);
              }
            }
          }
        }
      }

      for (int turn = 0; turn < 20; turn++)
      {
        var previousTurns = universes.Values.Where(u => u.Turn == turn - 1 && u.Scores.Max() < 21 && u.Count > 0).ToList();

        if (previousTurns.Count == 0)
          break;

        foreach (var previousTurn in previousTurns)
        {
          universes[GetUniverseHash(previousTurn, 3)].Count += (1 * previousTurn.Count);
          universes[GetUniverseHash(previousTurn, 4)].Count += (3 * previousTurn.Count);
          universes[GetUniverseHash(previousTurn, 5)].Count += (6 * previousTurn.Count);
          universes[GetUniverseHash(previousTurn, 6)].Count += (7 * previousTurn.Count);
          universes[GetUniverseHash(previousTurn, 7)].Count += (6 * previousTurn.Count);
          universes[GetUniverseHash(previousTurn, 8)].Count += (3 * previousTurn.Count);
          universes[GetUniverseHash(previousTurn, 9)].Count += (1 * previousTurn.Count);
        }
      }

      long player1Wins = universes.Values.Where(u => u.Scores[0] >= 21).Sum(u => u.Count);
      long player2Wins = universes.Values.Where(u => u.Scores[1] >= 21).Sum(u => u.Count);

      return string.Format("{0} + {1} = {2}", player1Wins, player2Wins, player1Wins + player2Wins);
    }

    private string GetHash(int turn, int player1Score, int player2Score, int player1Position, int player2Position)
    {
      return turn.ToString() + "|" + player1Score + "|" + player2Score + "|" + player1Position + "|" + player2Position;
    }

    private int GetNextPosition(int position, int roll)
    {
      return ((position - 1 + roll) % 10) + 1;
    }

    private string GetUniverseHash(Universe previousTurn, int roll)
    {
      int currentPlayerIndex = (previousTurn.Turn + 1) % 2;
      int otherPlayerIndex = (previousTurn.Turn + 1 + 1) % 2;

      int newPosition = GetNextPosition(previousTurn.Positions[currentPlayerIndex], roll);
      int newScore = previousTurn.Scores[currentPlayerIndex] + newPosition;

      if (currentPlayerIndex == 0)
      {
        string hash = GetHash(previousTurn.Turn + 1, newScore, previousTurn.Scores[otherPlayerIndex], newPosition, previousTurn.Positions[otherPlayerIndex]);

        return hash;
      }
      else
      {
        string hash = GetHash(previousTurn.Turn + 1, previousTurn.Scores[otherPlayerIndex], newScore, previousTurn.Positions[otherPlayerIndex], newPosition);

        return hash;
      }
    }
  }
}
