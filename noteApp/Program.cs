using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace noteApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t Welcome to Your Note App!\n");

            List<Note> Task = new List<Note>();
            Menu();

            bool app = true;
            while (app)
            {
                string answer = Console.ReadLine();
                if (answer == "1")
                {
                    Console.WriteLine("\nWhat would you like to call your Note?");
                    string noteName = Console.ReadLine();
                    Console.WriteLine($"What are you adding into your \"{noteName}\" note?");
                    string noteMessage = Console.ReadLine();
                    Note newNote = new Note(noteName, noteMessage, DateTime.Now);
                    Task.Add(newNote);
                    Console.WriteLine("Update Complete\n");
                    Menu();
                }
                else if (answer == "2")
                {
                    if (Task.Count >= 1)
                    {
                        Console.WriteLine($"\nID\tTITLE\t\tMESSAGE");
                        Console.WriteLine("---------------------------------------------");
                        for (int i = 0; i < Task.Count; i++)
                        {
                            Note item = Task[i];
                            Console.WriteLine($"<{i}>\t{item.Title}\t\t{item.Message}");
                        }
                        Console.Write("\nEnter a Note ID you want to edit: ");
                        int editNote = Convert.ToInt32(Console.ReadLine());

                        Note b = Task[editNote];
                        Console.Write($"\nDo you want to edit (1) \"{b.Title}\" or (2) \"{b.Message}\": ");
                        string edit = Console.ReadLine();
                        bool testing = true;
                        while (testing)
                        {
                            if (edit == "1")
                            {
                                Note c = Task[editNote];
                                Console.WriteLine($"\nWhat do you want to edit the new name of \"{c.Title}\" to?");
                                string newN = Console.ReadLine();
                                c.Title = newN;
                                Console.WriteLine("\nUpdate Complete\n");
                                testing = false;
                                Menu();
                            }
                            else if (edit == "2")
                            {
                                Note c = Task[editNote];
                                Console.WriteLine($"\nWhat do you want to edit the new message of \"{c.Message}\" to?");
                                string newM = Console.ReadLine();
                                c.Message = newM;
                                Console.WriteLine("\nUpdate Complete\n");
                                testing = false;
                                Menu();
                            }
                            else
                            {
                                Console.Write("Please only pick (1) or (2): ");
                                edit = Console.ReadLine();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nThere is nothing in your Note App.\n");
                        Menu();
                    }
                }
                else if (answer == "3")
                {
                    if (Task.Any() == true)
                    {
                        Console.WriteLine($"\nID\tTITLE");
                        Console.WriteLine("------------------------------------");
                        for (int i = 0; i < Task.Count; i++)
                        {
                            Note item = Task[i];
                            Console.WriteLine($"<{i}>\t{item.Title}");
                        }

                        Console.Write("\nEnter a Note ID you want to delete: ");
                        bool format = true;
                        while (format)
                            try
                            {
                                int deleteNote = Convert.ToInt32(Console.ReadLine());
                                bool checking = true;
                                while (checking)
                                    if (deleteNote <= Task.Count)
                                    {
                                        Task.RemoveAt(deleteNote);
                                        Console.WriteLine("\nUpdate Complete\n");
                                        Menu();
                                        checking = false;
                                        format = false;
                                    }
                                    else
                                    {
                                        Console.Write("\nPlease only enter a Note ID listed: ");
                                        deleteNote = Convert.ToInt32(Console.ReadLine());
                                    }
                            }
                            catch (FormatException)
                            {
                                Console.Write("\nPlease only enter a Note ID listed: ");
                                continue;
                            }
                    }
                    else
                    {
                        Console.WriteLine("\nThere is nothing in your Note App.\n");
                        Menu();
                    }
                }
                else if (answer == "4")
                {
                    if (Task.Any() == true)
                    {
                        Console.WriteLine($"\nID\tTITLE\t\tMESSAGE\t\tDATE ADDED");
                        Console.WriteLine("---------------------------------------------------------------");
                        for (int i = 0; i < Task.Count; i++)
                        {
                            Note a = Task[i];
                            Console.WriteLine($"<{i}>\t{a.Title}\t\t{a.Message}\t\t{a.Date}");
                        }
                        Console.WriteLine();
                        Menu();
                    }
                    else
                    {
                        Console.WriteLine("\nThere is nothing in your Note App.\n");
                        Menu();
                    }
                }
                else if (answer == "5")
                {
                    Console.WriteLine("\nGoodbye!");
                    app = false;
                }
                else
                {
                    Console.Write("Please only ther 1-5: ");
                }
            }
        }

        public static void Menu()
        {
            Console.WriteLine("\t\t\tWhat would you like to do? ");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("[1] Add Task [2] Edit Task [3] Delete Task [4] View All Task [5] Close App");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.Write("Enter task you would like to do: ");
        }
    }
}