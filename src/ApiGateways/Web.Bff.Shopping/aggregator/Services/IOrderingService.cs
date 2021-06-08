using TTcms.Web.Shopping.HttpAggregator.Models;
using System.Threading.Tasks;

namespace TTcms.Web.Shopping.HttpAggregator.Services
{
    public interface IOrderingService
    {
        Task<OrderData> GetOrderDraftAsync(BasketData basketData);
    }
}