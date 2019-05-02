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
        private NextViewModel _nextViewModel;
        public string ScreenTitle { get; } = "Next Page!";

        public ICommand NextCommnd { get; private set; }

        public NextViewModel(NextViewModel nextViewModel)
        {
            _nextViewModel = nextViewModel;

            NextCommnd = new RelayCommand(OnNextCommnd);
        }

        private void OnNextCommnd()
        {

        }
    }
}
