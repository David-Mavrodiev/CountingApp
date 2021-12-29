using Combinatorics.Counting.Contracts;
using Combinatorics.Counting.Contracts.Clauses;

namespace Combinatorics.Counting.Implementations.Clauses
{
    public class GetKOutOfNClause : ChainedClause<IClause, ISet<string>>, IGetKOutOfNClause
    {
        private readonly int subsetsSize;

        public GetKOutOfNClause(int k, IClause instantiator, ISet<string> items) : base(instantiator, items) 
        {
            this.subsetsSize = k;
        }

        public IList<string> DescriptionSteps
        {
            get
            {
                IList<string> steps = new List<string>(this.Instantiator.DescriptionSteps);
                steps.Add($"Calculate the count of all distinctive subsets with size {subsetsSize}.");
                steps.Add($"We should select {subsetsSize} elements out of {this.Context.Count}...");
                steps.Add("Lets define some variables:");
                steps.Add($"   n = {this.Context.Count} (all elements count).");
                steps.Add($"   k = {subsetsSize} (constructed subsets size).");
                steps.Add($"   np = {this.Context.Count}! = {this.Factoriel(this.Context.Count)} (total permutations count).");
                steps.Add($"   kp = {subsetsSize}! = {this.Factoriel(subsetsSize)} (different ways to reorder set with {this.subsetsSize} elements).");
                steps.Add($"   lp = (n - k)! = ({this.Context.Count} - {subsetsSize})! = {this.Context.Count - subsetsSize}! = {this.Factoriel(this.Context.Count - subsetsSize)} (different ways to reorder the left elements).");
                steps.Add($"So in order to get the distinctive combinations of all {subsetsSize}-sized subsets we need to:");
                steps.Add($"   Divide the np to lp. r' = np / lp. In this way we get all all {subsetsSize}-sized subsets permutations count...");
                steps.Add($"   However this is not enough. We should also divide r' to kp in order to get the unique subsets count and not theirs permutations.");
                steps.Add($"   So the correct equation is r = r' / kp.");
                return steps;
            }
        }

        public CountingResult Execute()
        {
            CountingResult result = new CountingResult();
            int allElementsCount = this.Context.Count;
            int leftOverElements = allElementsCount - subsetsSize;

            result.Count =
                this.Factoriel(allElementsCount) /  (this.Factoriel(leftOverElements) * this.Factoriel(subsetsSize));
            result.StepByStepSolution = new List<string>(this.DescriptionSteps);
            result.StepByStepSolution.Add($"The final answer is {allElementsCount}! / ({allElementsCount - subsetsSize})! * {subsetsSize}! = {result.Count}.");

            return result;
        }

        private int Factoriel(int n)
        {
            int res = 1;
            while (n >= 1)
            {
                res *= n;
                n--;
            }

            return res;
        }
    }
}
