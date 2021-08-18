using AutoMapper;
using OrdersAPI.Data.DTO;
using OrdersAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrdersAPI.Business.Profiles
{
    public class OrderServiceProfile : Profile
    {
        public OrderServiceProfile()
        {
            CreateMap<OrderPersistence, Order>();
        }
    }
}
