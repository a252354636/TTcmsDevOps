using TTcms.Web.Shopping.HttpAggregator.Models;
using System.Threading.Tasks;

namespace TTcms.Web.Shopping.HttpAggregator.Services
{
    public interface IOrderApiClient
    {
        Task<OrderData> GetOrderDraftFromBasketAsync(BasketData basket);
    }
}
