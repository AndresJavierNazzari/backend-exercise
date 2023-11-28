using System.Diagnostics.Metrics;

namespace GenericDataStorage
{
    internal class DataStorage<T> where T : new()
    {
        public static int TotalItems = 0;
        private List<T> items;

        public DataStorage()
        {
            this.items = new List<T>();
        }

        public void Add(T item)
        {
            TotalItems++;
            this.items.Add(item);
        }
        public void Remove(T item)
        {
            TotalItems--;
            this.items.Remove(item);
        }

        public T Retrieve(int index)
        {
            return this.items[index];
        }

        public void DisplayItems()
        {
            Console.WriteLine("Items in the storage:");
            foreach(var item in this.items)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
