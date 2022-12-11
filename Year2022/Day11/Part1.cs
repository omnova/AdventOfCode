using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;

namespace AdventOfCode.Year2022.Day11
{
  public class Part1 : IPuzzle
  {
    private class Monkey
    {
      public List<int> Items { get; }
      public Func<int, int> Operation { get; }
      public int TestDivisibliity { get; }
      public int TestTrueRecipient { get; }
      public int TestFalseRecipient { get; }
      public int InspectionCount { get; set; }

      public Monkey(IEnumerable<int> items, Func<int, int> operation, int testDivisibility, int testTrueRecipient, int testFalseRecipient)
      {
        this.Items = new List<int>(items);
        this.Operation = operation;
        this.TestDivisibliity = testDivisibility;
        this.TestTrueRecipient = testTrueRecipient;
        this.TestFalseRecipient = testFalseRecipient;
      }
    }

    public object Run(string input)
    {
      var monkeys = new List<Monkey>
      {
        new Monkey(new int[] { 64 }, old => old * 7, 13, 1, 3),
        new Monkey(new int[] { 60, 84, 84, 65 }, old => old + 7, 19, 2, 7),
        new Monkey(new int[] { 52, 67, 74, 88, 51, 61  }, old => old * 3, 5, 5, 7),
        new Monkey(new int[] { 67, 72 }, old => old + 3, 2, 1, 2),
        new Monkey(new int[] { 80, 79, 58, 77, 68, 74, 98, 64 }, old => old * old, 17, 6, 0),
        new Monkey(new int[] { 62, 53, 61, 89, 86 }, old => old + 8, 11, 4, 6),
        new Monkey(new int[] { 86, 89, 82 }, old => old + 2, 7, 3, 0),
        new Monkey(new int[] { 92, 81, 70, 96, 69, 84, 83 }, old => old + 4, 3, 4, 5)
      };
            
      for (int i = 0; i < 20; i++)
      {
        foreach (var monkey in monkeys)
        {
          for (int itemIndex = 0; itemIndex < monkey.Items.Count; itemIndex++)
          {
            monkey.Items[itemIndex] = monkey.Operation(monkey.Items[itemIndex]);
            monkey.Items[itemIndex] /= 3;
            monkey.InspectionCount++;

            if (monkey.Items[itemIndex] % monkey.TestDivisibliity == 0)
              monkeys[monkey.TestTrueRecipient].Items.Add(monkey.Items[itemIndex]);
            else
              monkeys[monkey.TestFalseRecipient].Items.Add(monkey.Items[itemIndex]);
          }

          monkey.Items.Clear();
        }
      }

      return monkeys.Select(m => m.InspectionCount).OrderByDescending(m => m).Take(2).Aggregate(1, (a, v) => a * v);
    }
  }
}