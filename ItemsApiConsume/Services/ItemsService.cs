using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using ItemsApiConsume.Interfaces;
using ItemsApiConsume.Models;

namespace ItemsApiConsume.Services
{
    public class ItemsService : IItemsService //Informa que a classe ItemService precisa ter tudo que a interface IItemsService tem.
    {
        private readonly HttpClient _http;

        public ItemsService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Item>> GetItems()
        {
            return await _http.GetFromJsonAsync<List<Item>>("items");
        }


        public async Task<Item> PostItem(Item item)
        {
            HttpResponseMessage response = await _http.PostAsJsonAsync("items", item);

            return await response.Content.ReadFromJsonAsync<Item>();
        }


        public async Task<Item> UpdateItem(Item item)
        {
            HttpResponseMessage response = await _http.PutAsJsonAsync("items", item);

            return await response.Content.ReadFromJsonAsync<Item>();
        }

        public async Task<Item> DeleteItem(Item item)
        {
            HttpResponseMessage response = await _http.DeleteAsync("items/" + item.Id, new CancellationToken());

            return await response.Content.ReadFromJsonAsync<Item>();
        }
    }
}
