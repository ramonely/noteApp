using System;

namespace noteApp
{
    class Note
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

        //took this out of main and added to the note object as it is editing properties at this level
        //so to keep functionality modular adding it here
        public void EditNote()
        {
            Console.Write($"You selected:\n{ToString()}\nDo you want to edit (1)Title or (2)Message: ");
            string edit = Console.ReadLine();
            while (true)
            {
                if (edit == "1")
                {
                    Console.Write($"Enter new Title: ");
                    string newN = Console.ReadLine();
                    Title = newN;
                    break;
                }
                else if (edit == "2")
                {

                    Console.Write("Enter new Message: ");
                    string newM = Console.ReadLine();
                    Message = newM;
                    break;
                }
                else
                {

                    Console.Write("Please only pick (1) or (2): ");
                    continue;
                }
            }
            Console.WriteLine("Update Complete");
        }

        //made a tostring override so it would be simpler to print out a note in uniform format
        public override string ToString()
        {
            return $"\t{Title}\t{Date.ToString("MM/dd/yyyy")}\t{Message}";
        }
    }
}