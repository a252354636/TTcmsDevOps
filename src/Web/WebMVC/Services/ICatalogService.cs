using Microsoft.AspNetCore.Mvc.Rendering;
using TTcms.WebMVC.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TTcms.WebMVC.Services
{
    public interface ICatalogService
    {
        Task<Catalog> GetCatalogItems(int page, int take, int? brand, int? type);
        Task<IEnumerable<SelectListItem>> GetBrands();
        Task<IEnumerable<SelectListItem>> GetTypes();
    }
}
