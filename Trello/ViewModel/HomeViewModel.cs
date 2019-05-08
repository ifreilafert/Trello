using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using Trello.Model;

namespace Trello.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        public ObservableCollection<Card> TodoItems { get; private set; }
        
        public HomeViewModel()
        {
            CreateTodoItems();
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
        }
    }
}
