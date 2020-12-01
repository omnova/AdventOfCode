using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AdventOfCode.Year2017.Day07
{
  [DebuggerDisplay("Name = {Name}, Weight = {Weight}, TotalWeight = {TotalWeight}, IsUnbalanced = {IsUnbalanced}")]
  internal class Disc
  {
    public string Name;
    public int Weight;

    public Disc Parent;
    public List<Disc> Children = new List<Disc>();

    public int TotalWeight
    {
      get { return this.Weight + this.Children.Sum(d => d.TotalWeight); }
    }

    public bool IsUnbalanced
    {
      get { return this.Children.Select(d => d.TotalWeight).Distinct().Count() > 1; }
    }
  }
}
