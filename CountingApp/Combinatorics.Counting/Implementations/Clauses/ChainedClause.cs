using Combinatorics.Counting.Contracts.Clauses;

namespace Combinatorics.Counting.Implementations.Clauses
{
    public class ChainedClause<T, K> where T : IClause
    {
        private readonly T? instantiator;
        private readonly K context;

        public ChainedClause(T? instantiator, K context)
        {
            this.instantiator = instantiator;
            this.context = context;
        }

        public T? Instantiator
        {
            get { return instantiator; }
        }
        public K Context
        {
            get { return context; }
        }
    }
}
