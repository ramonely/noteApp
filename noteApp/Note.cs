using System;
using System.Collections.Generic;
using System.Text;

namespace noteApp
{
    internal class Note
    {
        public string Title { get; set; }
        public string Message { get; set; }

        public DateTime Date { get; set; }

        public Note(string title, string message, DateTime date)
        {
            Title = title;
            Message = message;
            Date = date;
        }
    }
}