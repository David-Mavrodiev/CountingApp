namespace Combinatorics.Counting.Contracts.Clauses
{
    public interface IFromSetClause : IClause
    {
        IStartQueryClause StartQueryWithName(string name);

        IDictionary<string, IExecuteableClause> ExecuteAllQueries();
    }
}
