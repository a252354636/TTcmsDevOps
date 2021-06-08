using TTcms.Mobile.Shopping.HttpAggregator.Models;
using System.Threading.Tasks;

namespace TTcms.Mobile.Shopping.HttpAggregator.Services
{
    public interface IBasketService
    {
        Task<BasketData> GetById(string id);

        Task UpdateAsync(BasketData currentBasket);

    }
}
