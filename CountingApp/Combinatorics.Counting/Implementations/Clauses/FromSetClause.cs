using Combinatorics.Counting.Contracts.Clauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinatorics.Counting.Implementations.Clauses
{
    public class FromSetClause : ChainedClause<IFromSetClause, ISet<string>>, IFromSetClause
    {
        private readonly ISet<string> items;
        private IDictionary<string, IStartQueryClause> queries;

        public FromSetClause(ISet<string> items) : base(null, items)
        {
            this.items = items;
            queries = new Dictionary<string, IStartQueryClause>();
        }

        public IList<string> DescriptionSteps
        { 
            get
            {
                IList<string> steps = new List<string>();
                steps.Add($"Given set A = [{string.Join(',', this.items)}].");
                return steps;
            } 
        }

        public IDictionary<string, IExecuteableClause> ExecuteAllQueries()
        {
            throw new NotImplementedException();
        }

        public IStartQueryClause StartQueryWithName(string name)
        {
            IStartQueryClause clause = new StartQueryClause(name, this, items);
            this.queries.Add(name, clause);

            return clause;
        }
    }
}
