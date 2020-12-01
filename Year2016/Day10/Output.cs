using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Year2016.Day10
{
  internal class Output : IChipReceiver
  {
    public int Id { get; private set; }

    public List<int> Chips = new List<int>();
    
    public Output(int id)
    {
      this.Id = id;
    }

    public void TakeChip(int value)
    {
      this.Chips.Add(value);
    }
  }
}
