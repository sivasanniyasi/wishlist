using System;
using System.Collections.Generic;
using System.Linq;
using WishList.Core;
namespace WishList.Data
{
    public interface IItemData
    {
        IEnumerable<Item> GetItem();
        Item GetItemById(int itemId);
        //Item GetItemByDescription(string itemDescr);

    }

    public class InMemoryItemData : IItemData
    {
        readonly public List<Item> items;

        public InMemoryItemData()
        {
            items = new List<Item> ()
            {
                new Item { Id = 1, itemName = "Item 1"},
                new Item { Id = 2, itemName = "Item 2"},
                new Item { Id = 3, itemName = "Item 3"}
            };
        }

        public IEnumerable<Item> GetItem()
        {
            return from r in items 
                          orderby  r.itemName
                          select r;
        }

        public Item GetItemById(int itemId)
        {
            return items.SingleOrDefault(i => i.Id == itemId);
        }
        
        //public IEnumerable<Item> GetItemByDescription(string itemDescr)
        //{
        //    return from i in items
        //           where string.IsNullOrEmpty(i.itemName) || i.itemName == itemDescr
        //           orderby i.itemName
        //           select i;
        //}

        //Item IItemData.GetItemByDescription(string itemDescr)
        //{
        //    throw new NotImplementedException();
        //}
    }

}
