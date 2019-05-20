using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Trello.Model;
using System.Collections.ObjectModel;

namespace Trello.ViewModel
{
    public class NextViewModel : ViewModelBase
    {
        private MainViewModel _mainViewModel;
        public string ScreenTitle { get; } = "Trello World!";

        public ICommand BackCommnd { get; private set; }

        public ICommand AddDoCommnd { get; private set; }

        public ObservableCollection<Card> CardListDo { get; set; }

        public ObservableCollection<Card> CardListDoing { get; set; }

        public ObservableCollection<Card> CardListDone { get; set; }

        public NextViewModel(MainViewModel mainViewModel)
        {
            ObservableCollection<Card> cardListDo = new ObservableCollection<Card>
            {
                new Card("Card 1","I'm a description"),
                new Card("Card 2","I'm also a description"),
                new Card("Card 3","Don't tell me what I am")
            };
            CardListDo = cardListDo;

            ObservableCollection<Card> cardListDoing = new ObservableCollection<Card>
            {
                new Card("Card 4","I said a hip hop"),
                new Card("Card 5","Hippie to the hippie"),
                new Card("Card 6","The hip, hip a hop, and you dont stop")
            };
            CardListDoing = cardListDoing;

            ObservableCollection<Card> cardListDone = new ObservableCollection<Card>
            {
                new Card("Card 7","Bubba to the bang bang boogie"),
                new Card("Card 8","Boobie to the boogie"),
                new Card("Card 9","To the rhythm of the boogie the beat")
            };
            CardListDone = cardListDone;

            _mainViewModel = mainViewModel;

            BackCommnd = new RelayCommand(OnBackCommnd);
            AddDoCommnd = new RelayCommand(OnAddDoCommnd);

        }

        private void OnBackCommnd()
        {
            _mainViewModel.CurrentViewModel = ViewModelLocator.HomeViewModel;
        }

        private void OnAddDoCommnd()
        {
            CardListDo.Add(new Card("New Card", "This was added by the add button"));
        }
    }
}
