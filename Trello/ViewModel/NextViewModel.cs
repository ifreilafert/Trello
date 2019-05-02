using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Trello.ViewModel
{
    public class NextViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;
        public string ScreenTitle { get; } = "Next Page!";

        public ICommand BackCommnd { get; private set; }

        public NextViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            BackCommnd = new RelayCommand(OnBackCommnd);
        }

        private void OnBackCommnd()
        {
            _mainViewModel.CurrentViewModel = ViewModelLocator.HomeViewModel;
        }
    }
}
