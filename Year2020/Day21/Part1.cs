//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace AdventOfCode.Year2020.Day21
//{
//  public class Part1 : IPuzzle
//  {
//    private class Ingredient
//    {
//      public string Name { get; private set; }
//      public List<string> Allergens { get; private set; }
//      public int Appearances = 1;

//      public Ingredient(string name, string allergen)
//      {
//        this.Name = name;
//        this.Allergens = allergen.Split(", ").ToList();
//      }
//    }

//    public object Run(string input)
//    {
//      var ingredientLists = input.Replace(")", "").Split(Environment.NewLine).Select(l => l.Split(" (contains ").ToList()).ToList();

//      var ingredients = new List<Ingredient>();

//      foreach (var ingredientList in ingredientLists)
//      {
//        string allergen = ingredientList[1];
//        var ingredientStrings = ingredientList[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);

//        foreach (var ingredientString in ingredientStrings)
//        {
//          var ingredient = ingredients.FirstOrDefault(i => i.Name == ingredientString);

//          if (ingredient == null)
//            ingredients.Add(new Ingredient(ingredientString, allergen));
//          else if (!ingredient.Allergens.Any(a => Enumerable.SequenceEqual(a, allergen.Split(", "))))
//          {
//            ingredient.Allergens.Add(allergen.Split(", ").ToList());
//            ingredient.Appearances++;
//          }
//          else
//            ingredient.Appearances++;
//        }
//      }

//      var allergens = ingredients.SelectMany(i => i.Allergens).Select(a => string.Join(",", a)).Distinct().Select(a => a.Split(",").ToList()).ToList();

//      var safeIngredients = ingredients.Where(i => IsSafe(i, allergens)).ToList();

//      return safeIngredients.Sum(i => i.Appearances);
//    }

//    private bool IsSafe(Ingredient ingredient, List<List<string>> allergens)
//    {
//      foreach (var allergen in ingredient.Allergens)
//      {
//        if (allergen.Count > 1)
//        {
//          foreach (var allergenPart in allergen)
//          {
//            // Has both a combination of allergens and all other listings for an allergen in that list; sus
//            if (allergens.Count(a => a.Any(p => p == allergenPart)) == ingredient.Allergens.Count(a => a.Any(p => p == allergenPart)))
//              return false;
//          }
//        }
//        else
//        {
//          // There are more instances of allergens listed than this ingredient is listed with; should be safe, at least as far as that allergen goes
//          if (allergens.Count(a => a.Any(p => p == allergen[0])) == ingredient.Allergens.Count(a => a.Any(p => p == allergen[0])))
//            return false;
//        }
//      }

//      return true;
//    }
//  }
//}
