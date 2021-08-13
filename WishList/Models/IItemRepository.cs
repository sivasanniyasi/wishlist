using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WishList.Data;

namespace WishList.Models
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAllItems();
        Item GetItemById(int itemId);
    }

    public class ItemRepository : IItemRepository
    {
        private readonly ApplicationDbContext _context;

        public ItemRepository(ApplicationDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _context.Items;
        }

        public Item GetItemById(int itemId)
        {
            return _context.Items.FirstOrDefault(p => p.Id == itemId);
        }
    }

    public class MockItemRepository : IItemRepository
    {
        private List<Item> _items;
        public MockItemRepository()
        {
            if (_items == null)
                InitializeItem();
        }

        private void InitializeItem()
        {
            _items = new List<Item>()
            {
                new Item { Id = 1, Description = "Item 1"},
                new Item { Id = 2, Description = "Item 2"},
                new Item { Id = 3, Description = "Item 3"}
            };
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _items;
            //from i in _items
            //       orderby i.Description
            //       select i;
        }

        public Item GetItemById(int itemId)
        {
            return _items.SingleOrDefault(r => r.Id == itemId);
        }
    }
    
}
