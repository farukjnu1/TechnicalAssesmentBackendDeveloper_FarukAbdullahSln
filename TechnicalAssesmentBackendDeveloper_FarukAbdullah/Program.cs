using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalAssesmentBackendDeveloper_FarukAbdullah
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Item Manager!");

            ItemManager manager = new ItemManager();

            // Part One: Fix the NullReferenceException
            // This will throw a NullReferenceException
            manager.AddItem("Apple");
            manager.AddItem("Banana");

            manager.PrintAllItems();
        }
    }

    public class ItemManager
    {
        private List<string> items;

        public ItemManager()
        {
            items = new List<string>();
        }

        public void AddItem(string item)
        {
            items.Add(item);
        }

        public void PrintAllItems()
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        // Part Two: Implement the RemoveItem method
        // TODO: Implement this method
        public void RemoveItem(string item)
        {
            //throw new NotImplementedException("RemoveItem method is not implemented yet. Please remove this line and implement this method.");
            if (items.Contains(item))
            {
                items.Remove(item);
                Console.WriteLine($"{item} removed successfully.");
            }
            else
            {
                Console.WriteLine($"{item} not found in the list.");
            }
        }

        public void ClearAllItems()
        {
            items.Clear();
        }
    }
}
