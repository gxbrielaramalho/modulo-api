using ModuloApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace ModuloApi.Data
{
    public class InMemoryRepository
    {
        private static List<Item> Items = new List<Item>();
        private static int nextId = 1;

        public IEnumerable<Item> GetAll() => Items;

        public Item? Get(int id) => Items.FirstOrDefault(i => i.Id == id);

        public Item Add(Item item)
        {
            item.Id = nextId++;
            Items.Add(item);
            return item;
        }

        public void Update(Item item)
        {
            var index = Items.FindIndex(i => i.Id == item.Id);
            if (index != -1)
            {
                Items[index] = item;
            }
        }

        public void Delete(int id)
        {
            var item = Get(id);
            if (item != null)
            {
                Items.Remove(item);
            }
        }
    }
}
