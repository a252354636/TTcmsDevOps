using TTcms.Mobile.Shopping.HttpAggregator.Models;
using System.Threading.Tasks;

namespace TTcms.Mobile.Shopping.HttpAggregator.Services
{
    public interface IOrderingService
    {
        Task<OrderData> GetOrderDraftAsync(BasketData basketData);
    }
}