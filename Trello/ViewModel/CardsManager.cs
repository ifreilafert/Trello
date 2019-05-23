using System;
using System.Collections.ObjectModel;
using System.IO;
using Trello.Model;
using System.Xml.Linq;
using System.Text;
using System.Xml;
using System.Linq;
using System.Collections.Generic;

namespace Trello.ViewModel
{
    public class CardsManager
    {
        public ObservableCollection<Card> Load()
        {

            ObservableCollection<Card> TodoItems = new ObservableCollection<Card>();

            //StreamReader file = new StreamReader(@"Resources\CardData.txt");

            //line = file.ReadToEnd();

            //string[] collectionStringList = line.Split(new string[] { "---" }, StringSplitOptions.RemoveEmptyEntries);
            //string[] cardsStringList = line.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            //foreach (string cardString in cardsStringList)
            //{
            //    Card cardLoaded = new Card();
            //    dataList = cardString.Split(';');
            //    cardLoaded.Title = dataList[0];
            //    cardLoaded.Description = dataList[1];
            //    if (DateTime.TryParse(dataList[2], out DateTime createdResult)) { cardLoaded.CreatedDate = createdResult; }
            //    if (DateTime.TryParse(dataList[3], out DateTime completedResult)) { cardLoaded.CompletedDate = completedResult; }
            //    if (Enum.TryParse(dataList[4], out DueState state)) { cardLoaded.DueState = state; }

            //    TodoItems.Add(cardLoaded);
            //}

            //file.Close();

            XElement TodoItemsXml = XElement.Load(@"Resources\CardData.xml");
            Card TodoItemCardLoaded = new Card();

            //TodoItemCardLoaded.Title = TodoItemsXml.Element("Collections").Element("Collection").Element("Card").Element("Title").Value;

            //var result = TodoItemsXml.Element("Collections").Element("Collection").Element("Card").Element("Title").Value;

            //IEnumerable<string> titleEnumerableList =
            //    from element in TodoItemsXml.Descendants("Title")
            //    select (string)element;


            //IEnumerable<Card> todoItemsList =
            //    from el in TodoItemsXml.Descendants("Card")
            //    select new Card(
            //        (string)el.Element("Title"),
            //        (string)el.Element("Description"),
            //        (DateTime)el.Element("CreatedDate"),
            //        (DateTime)el.Element("CompletedDate"),
            //        (DueState)Enum.Parse(typeof(DueState), (string)el.Element("DueState"))
            //    );

            IEnumerable<Card> todoItemsList =                
                from el in TodoItemsXml.Elements("Collection")
                .Where(element => element.Attribute("List").Value == "Todo Items").Descendants("Card")
                select new Card(
                    (string)el.Element("Title"),
                    (string)el.Element("Description"),
                    (DateTime)el.Element("CreatedDate"),
                    (DateTime)el.Element("CompletedDate"),
                    (DueState)Enum.Parse(typeof(DueState), (string)el.Element("DueState"))
                );

            foreach (Card card in todoItemsList)
            {
                TodoItems.Add(card);
            }


            //List<string> titleList = titleEnumerableList.ToList();

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


            XDocument collectionXDoc = new XDocument();
            XElement rootElement = new XElement("Collections");

                foreach (ObservableCollection<Card> collection in collectionList)
                {
                XElement collectionElement = new XElement("Collection", 
                    new XAttribute("List", "Todo Items"));

                    foreach (Card card in collection)
                    {
                        XElement cardElement = new XElement("Card",
                            new XElement("Title", card.Title),
                            new XElement("Description", card.Description),
                            new XElement("CreatedDate", card.CreatedDate),
                            new XElement("CompletedDate", card.CompletedDate),
                            new XElement("DueState", card.DueState)
                            );
                        collectionElement.Add(cardElement);
                    }
                    rootElement.Add(collectionElement);
                }
            collectionXDoc.Add(rootElement);
            collectionXDoc.Save(Path.Combine(docPath, "CardData.xml"));

        }
            
    }


}

