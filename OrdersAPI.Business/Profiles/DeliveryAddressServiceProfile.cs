using AutoMapper;
using OrdersAPI.Data.DTO;
using OrdersAPI.Models;

namespace OrdersAPI.Business.Profiles
{
    public class DeliveryAddressServiceProfile : Profile
    {
        public DeliveryAddressServiceProfile()
        {
            CreateMap<DeliveryAddressPersistence, DeliveryAddress>();
        }
    }
}
