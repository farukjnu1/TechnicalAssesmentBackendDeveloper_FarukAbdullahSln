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

            // Part Two: Implement the RemoveItem method
            manager.RemoveItem("Apple");

            // Part Three: Introduce a Fruit class and use the ItemManager<Fruit> to add a few fruits and print them on the console.
            // TODO: Implement this part three.
            ItemManager<Fruit> managerFruit = new ItemManager<Fruit>();
            managerFruit.AddItem(new Fruit() { Name = "Cherry" });
            managerFruit.AddItem(new Fruit() { Name = "Dragon fruit" });

            Console.WriteLine("\nFruits:");
            managerFruit.PrintAllItems();

            // Part Four (Bonus): Implement an interface IItemManager and make ItemManager implement it.
            // TODO: Implement this part four.
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

    public interface IItemManager<T>
    {
        void AddItem(T item);
        void RemoveItem(T item);
        void PrintAllItems();
        void ClearAllItems();
    }

    public class ItemManager<T>: IItemManager<T>
    {
        private List<T> items;

        public ItemManager()
        {
            items = new List<T>();
        }

        public void AddItem(T item)
        {
            items.Add(item);
        }

        public void RemoveItem(T item)
        {
            if (items.Contains(item))
            {
                items.Remove(item);
                Console.WriteLine($"{item} removed successfully.");
            }
            else
            {
                Console.WriteLine($"{item} not found.");
            }
        }

        public void PrintAllItems()
        {
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void ClearAllItems()
        {
            items.Clear();
        }
    }

    public class Fruit
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
