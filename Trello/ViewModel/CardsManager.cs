using System;
using System.Collections.ObjectModel;
using System.IO;
using Trello.Model;

namespace Trello.ViewModel
{
    public class CardsManager
    {
        public ObservableCollection<Card> Load()
        {            
            string line;
            string[] dataList;          
           
            ObservableCollection<Card> TodoItems = new ObservableCollection<Card>();

            StreamReader file = new StreamReader(@"Resources\CardData.txt");

            line = file.ReadToEnd();

            string[] cardsStringList = line.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);            

            foreach(string cardString in cardsStringList)
            {
                Card cardLoaded = new Card();
                dataList = cardString.Split(';');
                cardLoaded.Title = dataList[0];
                cardLoaded.Description = dataList[1];
                TodoItems.Add(cardLoaded);
            }

            file.Close();
            return TodoItems;
            
        }

        public void Save(ObservableCollection<Card> cardList)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "CardData.txt")))
            {                
                foreach(Card card in cardList)
                {
                    outputFile.WriteLine($"{card.Title};{card.Description}");                    
                }
            }
        }
    }
}
