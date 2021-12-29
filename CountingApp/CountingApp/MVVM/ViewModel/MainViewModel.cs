using CountingApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingApp.MVVM.ViewModel
{
    public class MainViewModel : ObservableObject
    {        
        public HomeViewModel HomeView { get; set; }

        public RelayCommand HomeViewCommand { get; set; }

        public PermutationsViewModel PermutationsView { get; set; }

        public RelayCommand PermutationsViewCommand { get; set; }

        public CombinationsViewModel CombinationsView { get; set; }

        public RelayCommand CombinationsViewCommand { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get 
            {
                return _currentView;
            }
            set 
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {
            HomeView = new HomeViewModel();
            HomeViewCommand = new RelayCommand(o => CurrentView = HomeView);

            PermutationsView = new PermutationsViewModel();
            PermutationsViewCommand = new RelayCommand(o => CurrentView = PermutationsView);

            CombinationsView = new CombinationsViewModel();
            CombinationsViewCommand = new RelayCommand(o => CurrentView = CombinationsView);

            _currentView = HomeView;
        }
    }
}
