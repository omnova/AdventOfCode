using System;
using System.Linq;
using System.Collections.Generic;

namespace AdventOfCode.Year2020.Day21
{
  public class Part2 : IPuzzle
  {
    public object Run(string input)
    {
      var ingredientLists = input.Replace(")", "").Split(Environment.NewLine).Select(l => l.Split(" (contains ").ToList()).ToList();

      var ingredientAllergenCounts = new Dictionary<string, Dictionary<string, int>>();
      var allergenCounts = new Dictionary<string, int>();

      foreach (var ingredientList in ingredientLists)
      {
        var ingredients = ingredientList[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var allergens = ingredientList[1].Split(", ");

        foreach (var ingredient in ingredients)
        {
          Dictionary<string, int> allergenCount;

          if (!ingredientAllergenCounts.TryGetValue(ingredient, out allergenCount))
          {
            allergenCount = new Dictionary<string, int>();
            ingredientAllergenCounts.Add(ingredient, allergenCount);
          }

          foreach (var allergen in allergens)
          {
            if (!allergenCount.ContainsKey(allergen))
              allergenCount.Add(allergen, 1);
            else
              allergenCount[allergen] += 1;
          }
        }

        foreach (var allergen in allergens)
        {
          if (!allergenCounts.ContainsKey(allergen))
            allergenCounts.Add(allergen, 1);
          else
            allergenCounts[allergen]++;
        }
      }

      foreach (var allergenCount in allergenCounts)
      {
        foreach (var ingredientAllergenCount in ingredientAllergenCounts)
        {
          if (ingredientAllergenCount.Value.ContainsKey(allergenCount.Key) && ingredientAllergenCount.Value[allergenCount.Key] != allergenCount.Value)
            ingredientAllergenCount.Value.Remove(allergenCount.Key);
        }
      }

      var allergenIngredients = ingredientAllergenCounts.Where(i => i.Value.Count > 0).ToList();

      return null;
    }
  }
}
