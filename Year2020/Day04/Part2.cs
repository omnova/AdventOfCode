using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Year2020.Day04
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var fieldValidations = new Dictionary<string, string>
      {
        { "byr", @"^19[2-9]\d$|^200[0-2]$" },
        { "iyr", @"^201\d$|^2020$" },
        { "eyr", @"^202\d$|^2030$" },
        { "hgt", @"^((1[5-8]\d|19[0-3])cm|(59|6\d|7[0-6])in)$" },
        { "hcl", @"^#[0-9a-f]{6}$" },
        { "ecl", @"^(amb|blu|brn|gry|grn|hzl|oth)$" },
        { "pid", @"^\d{9}$" }
      };

      var passports = input.Split(Environment.NewLine + Environment.NewLine);

      int numValidPassports = 0;

      foreach (var passport in passports)
      {
        var fields = passport.Split(new string[] { " ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Select(f => f.Split(':')).ToList();

        bool isValid = fieldValidations.All(v => fields.Any(f => v.Key == f[0] && Regex.IsMatch(f[1], v.Value)));

        if (isValid)
          numValidPassports++;
      }

      return numValidPassports;
    }
  }
}
