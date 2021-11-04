using System;
using System.Collections.Generic;

namespace noteApp
{
    class Journal
    {
        // in order to do unit testing, I needed to move everything out of main,
        //so i made a new "journal" class to house the functionality of this program
        //elsewhere outside of main. 
        public List<Note> Tasks = new List<Note>();

        public Journal()
        {
            //added some dummy notes to the constructor class only for testing purposes, will comment out later
            Tasks.Add(new Note("Clean Office", "Clean surfaces, sweep, vacuum, wash floors.", DateTime.Now));
            Tasks.Add(new Note("Finish Lab", "Lab is Due Soon! Rework main method.", DateTime.Now));
            Tasks.Add(new Note("Grocery List", "Make sure you don't forget Eggs", DateTime.Now));
        }

        //also taking functionality of each menu option out of main menu and adding here 
        //and renaming them as separate methods

        public void AddTask()
        {
            //previously housed in main method, put here instead
            Console.Write("\nWhat would you like to call your Note?: ");
            string noteName = Console.ReadLine();
            Console.Write($"What are you adding into your \"{noteName}\" note?: ");
            string noteMessage = Console.ReadLine();
            Tasks.Add(new Note(noteName, noteMessage, DateTime.Now));
            Console.WriteLine("Update Complete\n");
        }

        //took functionality out of main menu if statment and moved here
        public void EditTask()
        {
            //called to display all notes so could be reused.
            DisplayAllTasks();

            //moved input validation to its own method so
            //it could be shared with Delete and Edit Tasks methods
            Note editNote = GetValidInput("Choose note to edit: ");

            //put edit functionality at the object level in a new method
            //inside the note class
            editNote.EditNote();

        }

        //took this functionality out of main and added here
        public void DeleteTask()
        {
            //instead of printing out a display manually, just caling to display all again
            DisplayAllTasks();

            //took out validation from this method and now am calling to another
            //for input validation
            Note delNote = GetValidInput("Select which task to delete: ");

            //searches through journal to find that journal entry then deletes
            foreach(Note note in Tasks)
            {
                if(note == delNote)
                {
                    Tasks.Remove(note);
                    Console.WriteLine("Task deleted successfully");
                    break;
                }
            }
           
        }

        //took this functionality out of main and added here 
        public void DisplayAllTasks()
        {
            //method to view all tasks in Journal List
            //took code from main method and added here
            Console.WriteLine($"\nID\tTITLE\t\tDATE ADDED\tMESSAGE");
            Console.WriteLine("---------------------------------------------------------------");

            for (int i = 0; i < Tasks.Count; i++)
            {
                Console.WriteLine($"{i}: {Tasks[i]}");
            }

            if (Tasks.Count == 0)
            {
                Console.WriteLine("\nThere is nothing in your Note App.\n");
            }
        }

        //there used to be two places where input was validated
        //both served the same purpose though and code was almost identical
        //so just moved it to its own method so it could be called to
        public Note GetValidInput(string prompt)
        {
            int choice = -1;
            Note noteChoice;
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    choice = int.Parse(Console.ReadLine());
                    noteChoice = Tasks[choice];
                    break;
                }
                catch (FormatException)
                {
                    {
                        Console.Write("\nInvalid Selection, try again.");
                        continue;
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.Write($"\nPlease only enter number between 0 and {Tasks.Count-1}. Try Again. ");
                    continue;
                }
            }
            return noteChoice;
        }
    }
}
