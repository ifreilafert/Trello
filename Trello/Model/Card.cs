using System;
using static Trello.ViewModel.CardsManager;

namespace Trello.Model
{
    public enum DueState
    {
        OnTime,
        Expiring,
        Expired,
    }
    public enum CompletedState
    {
        NotStarted,
        Started,
        Done,
    }

    public class Card
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueByDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public DueState DueState { get; set; }
        public CompletedState CompletedState { get; set; }

        public Card(string title, string description = null)
        {
            Title = title;
            Description = description;
            CreatedDate = DateTime.Now;
            DueByDate = CreatedDate.AddDays(7);
            DueState = DueState.OnTime;
            CompletedState = CompletedState.NotStarted;
        }

        public Card(string title, string description = null, DateTime createdDate = default(DateTime), DateTime dueByDate = default(DateTime), DueState dueState = DueState.OnTime, CompletedState completedState = CompletedState.NotStarted)
        {
            Title = title;
            Description = description;
            CreatedDate = createdDate;
            DueByDate = dueByDate;
            DueState = dueState;
            CompletedState = completedState;
        }

        public Card()
        {

        }
    }
}
