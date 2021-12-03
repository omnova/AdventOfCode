using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2021.Day03
{
  public class Part2 : IPuzzle
  {   
    public object Run(string input)
    {
      var numbers = input.Split(Environment.NewLine);

      var oxygenGeneratorNumbers = numbers.ToArray();
      var co2ScrubberNumbers = numbers.ToArray();

      for (int i = 0; i < numbers[0].Length; i++)
      {
        var oxygenGeneratorNumbers0 = oxygenGeneratorNumbers.Where(n => n[i] == '0').ToArray();
        var oxygenGeneratorNumbers1 = oxygenGeneratorNumbers.Where(n => n[i] == '1').ToArray();

        if (oxygenGeneratorNumbers1.Length >= oxygenGeneratorNumbers0.Length)
          oxygenGeneratorNumbers = oxygenGeneratorNumbers1;
        else
          oxygenGeneratorNumbers = oxygenGeneratorNumbers0;

        if (oxygenGeneratorNumbers.Length == 1)
          break;
      }

      for (int i = 0; i < numbers[0].Length; i++)
      {
        var co2ScrubberNumbers0 = co2ScrubberNumbers.Where(n => n[i] == '0').ToArray();
        var co2ScrubberNumbers1 = co2ScrubberNumbers.Where(n => n[i] == '1').ToArray();

        if (co2ScrubberNumbers0.Length <= co2ScrubberNumbers1.Length)
          co2ScrubberNumbers = co2ScrubberNumbers0;
        else
          co2ScrubberNumbers = co2ScrubberNumbers1;

        if (co2ScrubberNumbers.Length == 1)
          break;
      }

      int oxygenGeneratorRating = Convert.ToInt32(oxygenGeneratorNumbers[0], 2);
      int co2ScrubberRating = Convert.ToInt32(co2ScrubberNumbers[0], 2);

      return oxygenGeneratorRating * co2ScrubberRating;
    }
  }
}
