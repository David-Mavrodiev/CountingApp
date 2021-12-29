using Combinatorics.Counting.Contracts;
using Combinatorics.Counting.Contracts.Clauses;
using Combinatorics.Counting.Implementations.Clauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinatorics.Counting.Implementations
{
    public class CombinatoricsCountingService : ICombinatoricsCountingService
    {
        public IFromSetClause UseSet(ISet<string> items)
        {
            IFromSetClause clause = new FromSetClause(items);
            return clause;
        }
    }
}
