namespace ASP.NET_Core_Project_Online_Shop.Services
{
    using ASP.NET_Core_Project_Online_Shop.Services.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IProductService
    {
        int Create(
            int productCode,
            string name,
            double tradePartnerPrice,
            double price,
            int quantity,
            int netWeight,
            string description,
            string imageUrl,
            int seriesId,
            int productTypeId,
            int categoryId);

        IEnumerable<ProductCategoryServiceModel> AllCategories();

        bool CategoryExists(int categoryId);
    }
}
