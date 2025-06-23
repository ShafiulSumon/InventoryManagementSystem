using AutoMapper;
using InventoryManagementSystem.Models.Entities;
using InventoryManagementSystem.Models.ViewModels;
using InventoryManagementSystem.Utils;

namespace InventoryManagementSystem.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductEntity, ProductListViewModel>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => StockHelper.CurrentStock(src.Quantity)));
    }
}