namespace ASP.NET_Core_Project_Online_Shop.Infrastructures
{
    using ASP.NET_Core_Project_Online_Shop.Data.Models;
    using ASP.NET_Core_Project_Online_Shop.Models.Products;
    using ASP.NET_Core_Project_Online_Shop.Services.Cart.Models;
    using ASP.NET_Core_Project_Online_Shop.Services.Products.Models;
    using ASP.NET_Core_Project_Online_Shop.Services.ShippingDetails.Models;
    using AutoMapper;
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Product, NewestProductsServiceModel>();
            this.CreateMap<ProductsDetailsServiceModel, ProductFormModel>();

            this.CreateMap<Product, ProductServiceModel>();

            this.CreateMap<Product, ProductsDetailsServiceModel>();

            this.CreateMap<CartItem, CartViewServiceMode>();

            this.CreateMap<ShippingDetailsFormModel, ShippingDetails>();


        }
    }
}
