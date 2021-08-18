using AutoMapper;
using OrdersAPI.Business.Models;
using OrdersAPI.Data.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersAPI.Business.Profiles
{
    public class OrderDetailServiceProfile : Profile
    {
        OrderDetailServiceProfile()
        {
            CreateMap<OrderDetailsPersistence, OrderDetails>();
        }
    }
}
