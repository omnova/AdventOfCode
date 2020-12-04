using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Year2020.Day04
{
  public class Part1 : IPuzzle
  {
    public object Run(string input)
    {
      var requiredFields = new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" }; // cid

      var passports = input.Split(Environment.NewLine + Environment.NewLine);

      int numValidPassports = 0;

      foreach (var passport in passports)
      {
        var fields = passport.Split(new string[] { " ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Select(f => f.Split(':')[0]).ToList();

        bool hasAllFields = requiredFields.All(f => fields.Contains(f));

        if (hasAllFields)
          numValidPassports++;
      }

      return numValidPassports;
    }
  }
}
