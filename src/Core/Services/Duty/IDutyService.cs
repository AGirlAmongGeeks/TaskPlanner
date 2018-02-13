using Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IDutyService
    {
        //Task AddItemToBasket(int basketId, int catalogItemId, decimal price, int quantity);
        //Task<List<Duty>> GetList(int userId);
        Task<List<Duty>> GetListAsync(string name);
    }
}
