using Combinatorics.Counting.Contracts;
using Combinatorics.Counting.Contracts.Clauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinatorics.Counting.Implementations.Clauses
{
    public class StartQueryClause : ChainedClause<IFromSetClause, ISet<string>>, IStartQueryClause
    {
        private readonly string name;

        public StartQueryClause(string name, IFromSetClause instantiator, ISet<string> items) : base(instantiator, items)
        {
            this.name = name;        
        }

        public string Name
        {
            get { return name; }
        }

        public IList<string> DescriptionSteps => this.Instantiator.DescriptionSteps;

        public IGetKOutOfNClause GetAllUniqueSubsetsWithLength(int k)
        {
            IGetKOutOfNClause clause = new GetKOutOfNClause(k, this, this.Context);
            return clause;
        }
    }
}
