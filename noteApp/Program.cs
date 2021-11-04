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
            Journal journal = new Journal();
            Console.WriteLine("\t\t\t Welcome to Your Note App!\n");
  
            while (true)
            {
                //moved menu call inside while loop to decrease redundancy of calls
                Menu();
                string answer = Console.ReadLine();
                if (answer == "1")
                {
                    journal.AddTask();

                }
                else if (answer == "2")
                {
                    journal.EditTask();
                }
                else if (answer == "3")
                {
                    journal.DeleteTask();
                   
                }
                else if (answer == "4")
                {
                    journal.DisplayAllTasks();
                }
                else if (answer == "5")
                {
                    Console.WriteLine("\nGoodbye!");
                    break;
                }
                else
                {
                    Console.Write("Please only enter 1-5: ");
                }
            }
        }

        public static void Menu()
        {
            Console.WriteLine("\n\t\t\tWhat would you like to do? ");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.WriteLine("[1] Add Task [2] Edit Task [3] Delete Task [4] View All Task [5] Close App");
            Console.WriteLine("--------------------------------------------------------------------------");
            Console.Write("Enter task you would like to do: ");
        }
    }
}