using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Trello.Model;

namespace Trello.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        private CardsManager _cardsManager;

        public ObservableCollection<Card> TodoItems { get; private set; }
        public ObservableCollection<Card> DoingItems { get; private set; }
        public ObservableCollection<Card> CompletedItems { get; private set; }

        public ICommand DeleteCommand { get; private set; }

        public ICommand MoveCommand { get; private set; }

        public HomeViewModel(CardsManager cardsManager)
        {
            _cardsManager = cardsManager;           

            DeleteCommand = new RelayCommand<Card>(OnDeleteCommand);
            MoveCommand = new RelayCommand<Card>(OnMoveCommand);

            TodoItems = _cardsManager.Load()[0];
            DoingItems = _cardsManager.Load()[1];
            CompletedItems = _cardsManager.Load()[2];

            // TODO Delete CreateTodoItems when Load is implemented
            //CreateTodoItems();
        }

        private void OnDeleteCommand(Card card)
        {
            if (TodoItems != null) { TodoItems.Remove(card); }
            if (DoingItems!= null) { DoingItems.Remove(card); }
            if (CompletedItems != null) { CompletedItems.Remove(card); }
            _cardsManager.Save(TodoItems,DoingItems,CompletedItems);
        }

        private void OnMoveCommand(Card card)
        {
            _cardsManager.Save(TodoItems);
        }

        private void CreateTodoItems()
        {
            TodoItems = new ObservableCollection<Card>();

            var card = new Card("Buy tickets", "Caravan Palace in 'The Observatory'");
            card.DueState = DueState.Expired;
            TodoItems.Add(card);

            card = new Card("Rent", "$150, Due by 01/01/2020");
            TodoItems.Add(card);

            card = new Card("Groceries list", "Milk, bread, buttermilk, feta cheese, olives.");
            TodoItems.Add(card);

            DoingItems = new ObservableCollection<Card>();
            card = new Card("Read a book", "Neon Prey by John Sandford");
            DoingItems.Add(card);
        }
    }
}
