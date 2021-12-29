using Combinatorics.Counting.Contracts;
using Combinatorics.Counting.Contracts.Clauses;
using Combinatorics.Counting.Implementations;
using CountingApp.Core;
using System;
using System.Collections.Generic;
using System.Timers;

namespace CountingApp.MVVM.ViewModel
{
    public class CombinationsViewModel : ObservableObject
    {
        private IList<string> items = new List<string>();

        private ICombinatoricsCountingService countingService;

        private int solution;

        private int subsetSize;

        private IList<string> stepByStepSolution;

        public CombinationsViewModel()
        {
            this.countingService = new CombinatoricsCountingService();
            this.Items = "a,b,c,d,e,f,j,h,i";
            this.subsetSize = 4;
        }

        public int SubsetSize 
        {
            get
            {
                return this.subsetSize;
            }

            set 
            {
                this.subsetSize = value;
                OnPropertyChanged();
            }
        }


        public int Solution
        {
            get 
            {
                return solution;
            }

            set 
            {
                solution = value;
                OnPropertyChanged();
            }
        }

        public IList<string> StepByStepSolution
        {
            get 
            {
                return stepByStepSolution;
            }

            set 
            {
                stepByStepSolution = value;
                OnPropertyChanged();
            }
        }

        public string Items
        {
            get
            {
                return String.Join(',', this.items);
            }

            set
            {
                if (value == null)
                {
                    return;
                }

                this.items = value.Split(',');
                OnPropertyChanged();

                this.FindSubsetsCount();
            }
        }

        private void FindSubsetsCount()
        {
            CountingResult result = this.countingService.UseSet(new HashSet<string>(this.items))
                    .StartQueryWithName("GetKOutOfN")
                    .GetAllUniqueSubsetsWithLength(3)
                    .Execute();

            this.Solution = result.Count;
            this.StepByStepSolution = result.StepByStepSolution;
        }
    }
}
