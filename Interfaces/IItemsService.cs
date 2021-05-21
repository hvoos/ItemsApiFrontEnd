using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ItemsApiConsume.Models;

namespace ItemsApiConsume.Interfaces
{
    //Essa interface define tudo que a classe filha dela precisa ter;
    public interface IItemsService
    {
        Task<List<Item>> GetItems();
        Task<Item> PostItem(Item item);
        Task<Item> UpdateItem(Item item);
        Task<Item> DeleteItem(Item item);
    }
}
