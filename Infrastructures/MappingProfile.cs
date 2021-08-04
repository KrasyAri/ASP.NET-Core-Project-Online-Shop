namespace ASP.NET_Core_Project_Online_Shop.Infrastructures
{
    using ASP.NET_Core_Project_Online_Shop.Data.Models;
    using ASP.NET_Core_Project_Online_Shop.Services.Products.Models;
    using AutoMapper;
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Product, NewestProductsServiceModel>();
            this.CreateMap<ProductsDetailsServiceModel, ProductServiceModel>();
        }
    }
}
