using Combinatorics.Counting.Contracts.Clauses;

namespace Combinatorics.Counting.Contracts
{
    public interface ICombinatoricsCountingService
    {
        IFromSetClause UseSet(ISet<string> items);
    }
}
