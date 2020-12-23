using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode.Year2020.Day23
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var rawCups = input.ToCharArray().Select(c => int.Parse(c.ToString())).ToList();
      var cups = new LinkedList<int>();

      rawCups.ForEach(c => cups.AddLast(c));
      Enumerable.Range(cups.Max() + 1, 1000000 - cups.Count).ToList().ForEach(c => cups.AddLast(c));

      var cupLookup = new Dictionary<int, LinkedListNode<int>>();

      for (var cupNode = cups.First; cupNode != null; cupNode = cupNode.Next)
      {
        cupLookup.Add(cupNode.Value, cupNode);
      }

      int totalCups = cups.Count;
      var currentCupNode = cups.First;      

      for (int i = 1; i <= 10000000; i++)
      {
        var pickedUpCups = new List<LinkedListNode<int>>();

        for (int p = 0; p < 3; p++)
        {
          var nextNode = currentCupNode.Next;

          if (nextNode == null)
            nextNode = cups.First;

          pickedUpCups.Add(nextNode);
          cups.Remove(nextNode);
        }

        int targetCupValue = currentCupNode.Value - 1;

        while (true)
        {
          if (targetCupValue == 0)
            targetCupValue = totalCups;

          if (!pickedUpCups.Any(c => c.Value == targetCupValue))
            break;

          targetCupValue--;
        }

        var destinationNode = cupLookup[targetCupValue];

        pickedUpCups.Reverse();
        pickedUpCups.ForEach(p => cups.AddAfter(destinationNode, p));

        currentCupNode = currentCupNode.Next != null ? currentCupNode.Next : cups.First;
      }

      long result = (long)cupLookup[1].Next.Value * (long)cupLookup[1].Next.Next.Value;

      return result; 
    }
  }
}
