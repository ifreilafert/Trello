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
       
        public string ScreenTitle { get; } = "Next Page!";

    

        public NextViewModel()
        {
           

            NextCommnd = new RelayCommand(OnNextCommnd);
        }

    }
}
