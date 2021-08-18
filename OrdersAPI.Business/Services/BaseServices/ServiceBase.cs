using AutoMapper;
using OrdersAPI.Business.Validators;
using OrdersAPI.Models;
using Serilog;
using System;

namespace OrdersAPI.Business.Services.BaseServices
{
    public abstract class ServiceBase
    {
        protected ILogger _logger = Log.Logger;
        protected IMapper _mapper;
        protected bool IsDeliveryAddressValid(DeliveryAddress deliveryAddress)
        {
            var validator = new DeliveryAddressValidator().Validate(deliveryAddress);

            return validator.IsValid ?
                validator.IsValid :
                    throw new ArgumentException(validator.ToString(", "));
        }
    }
}