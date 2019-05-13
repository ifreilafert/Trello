using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello.Model
{

    public enum DueState { New, Expiring, Expired }


    public class Card
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime DueByDate { get; set; }

        public DateTime CompletedDate { get; set; }      

        public DueState DueState { get; set; }

        public Card(string title, string description, DateTime createdDate, DateTime dueByDate, DateTime completedDate, DueState dueState)
        {
            Title = title;
            Description = description;
            CreatedDate = createdDate;
            DueByDate = dueByDate;
            CompletedDate = completedDate;
            DueState = dueState;            
        }

        public Card(string title, string description = null)
        {
            Title = title;
            Description = description;
            CreatedDate = DateTime.Now;
            DueByDate = DateTime.Now.AddDays(7);
        }
        



    }
}
