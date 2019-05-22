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
                if(DateTime.TryParse(dataList[2], out DateTime createdResult)){ cardLoaded.CreatedDate = createdResult; }
                if(DateTime.TryParse(dataList[3], out DateTime completedResult)){ cardLoaded.CompletedDate = completedResult; }
                if(Enum.TryParse(dataList[4], out DueState state)) { cardLoaded.DueState = state; }

                TodoItems.Add(cardLoaded);
            }

            file.Close();
            return TodoItems;
            
        }

        public void Save(params ObservableCollection<Card>[] collectionList)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "CardData.txt")))
            {
                foreach (ObservableCollection<Card> collection in collectionList)
                    {
                        foreach (Card card in collection)
                        {
                            outputFile.WriteLine($"{card.Title};{card.Description};{card.CreatedDate};{card.CompletedDate};{card.DueState}");
                        }
                    }
            }
        }
    }
}
