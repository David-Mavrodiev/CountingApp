using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinatorics.Counting.Contracts.Clauses
{
    public interface IStartQueryClause : IClause
    {
        IGetKOutOfNClause GetAllUniqueSubsetsWithLength(int k);
    }
}
