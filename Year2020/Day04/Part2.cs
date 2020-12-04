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
      var fieldValidations = new Dictionary<string, Func<string, bool>>
      {
        { "byr", IsValidBirthYear },
        { "iyr", IsValidIssueDate },
        { "eyr", IsValidExpirationYear },
        { "hgt", IsValidHeight },
        { "hcl", IsValidHairColor },
        { "ecl", IsValidEyeColor },
        { "pid", IsValidPassportID }
      };

      var passports = input.Split(Environment.NewLine + Environment.NewLine);

      int numValidPassports = 0;

      foreach (var passport in passports)
      {
        var fields = passport.Split(new string[] { " ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Select(f => f.Split(':')).ToList();

        bool isValid = true;

        foreach (var validation in fieldValidations)
        {
          var foundField = fields.Find(f => f[0] == validation.Key);
            
          if (foundField == null || !validation.Value(foundField[1]))
          {
            isValid = false;
            break;
          }
        }

        if (isValid)
          numValidPassports++;
      }

      return numValidPassports;
    }

    private bool IsValidBirthYear(string value)
    {
      return Regex.IsMatch(value, @"^\d{4}$") && int.Parse(value) >= 1920 && int.Parse(value) <= 2002;
    }

    private bool IsValidIssueDate(string value)
    {
      return Regex.IsMatch(value, @"^\d{4}$") && int.Parse(value) >= 2010 && int.Parse(value) <= 2020;
    }

    private bool IsValidExpirationYear(string value)
    {
      return Regex.IsMatch(value, @"^\d{4}$") && int.Parse(value) >= 2020 && int.Parse(value) <= 2030;
    }

    private bool IsValidHeight(string value)
    {
      if (Regex.IsMatch(value, @"^\d{3}cm$"))
      {
        int height = int.Parse(value.Substring(0, 3));

        return height >= 150 && height <= 193;
      }
      
      if (Regex.IsMatch(value, @"^\d{2}in$"))
      {
        int height = int.Parse(value.Substring(0, 2));

        return height >= 59 && height <= 76;
      }

      return false;
    }

    private bool IsValidHairColor(string value)
    {
      return Regex.IsMatch(value, @"^#[0-9a-f]{6}$");
    }

    private bool IsValidEyeColor(string value)
    {
      string[] validColors = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

      return validColors.Contains(value);
    }

    private bool IsValidPassportID(string value)
    {
      return Regex.IsMatch(value, @"^\d{9}$");
    }
  }
}
