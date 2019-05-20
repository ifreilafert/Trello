using System;

namespace Trello.Model
{
    public enum DueState
    {
        OnTime,
        Expiring,
        Expired,
    }

    public class Card
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueByDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public DueState DueState { get; set; }

        public Card(string title, string description = null)
        {
            Title = title;
            Description = description;
            CreatedDate = DateTime.Now;
            DueByDate = CreatedDate.AddDays(7);
            DueState = DueState.OnTime;
        }

        public Card()
        {

        }
    }
}
