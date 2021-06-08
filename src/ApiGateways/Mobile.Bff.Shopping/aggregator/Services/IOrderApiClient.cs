using TTcms.Mobile.Shopping.HttpAggregator.Models;
using System.Threading.Tasks;

namespace TTcms.Mobile.Shopping.HttpAggregator.Services
{
    public interface IOrderApiClient
    {
        Task<OrderData> GetOrderDraftFromBasketAsync(BasketData basket);
    }
}
