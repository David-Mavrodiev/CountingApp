using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinatorics.Counting.Contracts
{
    public interface ICountingContext
    {
        public ISet<string> Items { get; set; }

        public bool IsCountingSubsets { get; set; }
    }
}
