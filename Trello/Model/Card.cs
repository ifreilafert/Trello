using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello.Model
{
    public class Card
    {
        private string _title;
        private string _description;
        private DateTime _dateTime;
        private DateTime _dueByDate;
        private DateTime _completedDate;
        private dueState _dueState;

        public enum dueState
        {
            Ontime,
            Expiring,
            Expired 
        }
        
        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
            }
        }



        public DateTime DateTime
        {
            get { return _dateTime; }
            set
            {
                _dateTime = value;
            }
        }
        public DateTime DueByDate
        {
            get { return _dueByDate; }
            set
            {
                _dueByDate = value;
            }
        }
        public DateTime CompletedDate
        {
            get { return _completedDate; }
            set
            {
                _completedDate = value;
            }
        }
        public dueState DueState
        {
            get { return _dueState; }
            set
            {
                _dueState = value;
            }
        }

        public Card(string title, string description = null)
        {
            _title = title;
            _description = description;
            _dueState = dueState.Ontime;
        }

    }
}
