using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinatorics.Counting.Contracts.Clauses
{
    public interface IExecuteableClause : IClause
    {
        public CountingResult Execute();
    }

    public class CountingResult
    {
        public int Count { get; set; }

        public IList<string> StepByStepSolution { get; set; }
    }
}
