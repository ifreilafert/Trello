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
    public class HomeViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;
        public string ScreenTitle { get; } = "My Title";

        public ICommand NextCommnd { get; private set; }

        public HomeViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            NextCommnd = new RelayCommand(OnNextCommnd);
        }

        private void OnNextCommnd()
        {

        }
    }
}
