using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2016.Day10
{
  internal class Bot : IChipReceiver
  {
    public List<int> Chips = new List<int>();

    public int Id { get; private set; }
    public IChipReceiver LowTarget { get; set; }
    public IChipReceiver HighTarget { get; set; }

    public Bot(int id)
    {
      this.Id = id;
    }

    public void DisperseChips()
    {
      GiveChip(this.LowTarget, this.Chips.Min());
      GiveChip(this.HighTarget, this.Chips.Max());
    }

    private void GiveChip(IChipReceiver receiver, int value)
    {
      receiver.TakeChip(value);

      this.Chips.Remove(value);
    }

    public void TakeChip(int value)
    {
      if (!this.Chips.Contains(value))
        this.Chips.Add(value);
    }

    public override string ToString()
    {
      return string.Format("Id: {0}, Chips = {1}, LowTarget = {2}, HighTarget = {3}", this.Id, string.Concat(this.Chips.Select(c => c.ToString() + ", ")).Trim(", ".ToCharArray()), 0, 0);
    }
  }
}
