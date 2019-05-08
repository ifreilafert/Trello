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

        public Card(string title, string description)
        {
            _title = title;
            _description = description;
        }

    }
}
