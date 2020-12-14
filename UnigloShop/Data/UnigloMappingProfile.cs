using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnigloShop.Data.Entities;
using UnigloShop.ViewModel;

namespace UnigloShop.Data
{
    public class UnigloMappingProfile : Profile
    {
        public UnigloMappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
                            .ForMember(o => o.OrderId, ex => ex.MapFrom(o => o.Id))
                            .ForMember(o => o.OrderItems, ex => ex.MapFrom(o => o.Items))
                            .ReverseMap();

            CreateMap<OrderItem, OrderItemViewModel>()
                            .ReverseMap();
        }
    }
}
