using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2019.Day04
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      int rangeMin = int.Parse(input.Split('-')[0]);
      int rangeMax = int.Parse(input.Split('-')[1]);

      int validPasswords = 0;

      for (int value = rangeMin; value <= rangeMax; value++)
      {
        string password = value.ToString();
        string sortedPassword = string.Join("", password.ToCharArray().OrderBy(i => i).ToList());

        if (password == sortedPassword)
        {
          var charCounts = password.ToCharArray().Distinct().Select(p => password.ToCharArray().Count(c => c == p)).ToList();

          if (charCounts.Any(c => c > 1))
            validPasswords++;
        }     
      }
      
      return validPasswords;
    }
  }
}
