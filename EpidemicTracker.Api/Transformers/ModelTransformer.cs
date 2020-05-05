using EpidemicTracker.Api.Services.Dtos;
using EpidemicTracker.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpidemicTracker.Api.Transformers
{
    //These are extensions ..if you want this to be an extension ,....rename the class ending with extension
    //or you can take source as parameter like normal methods
    public static class ModelTransformer
    {
        public static Address ConvertToAddress(this AddressDto addressDto)
        {
            var address = new Address();
            address.AddressId = addressDto.AddressDtoId;
            address.AddressType = addressDto.AddressType;
            address.Hno = addressDto.Hno;
            address.Street = addressDto.Street;
            address.City = addressDto.City;
            address.State = addressDto.State;
            address.Country = addressDto.Country;
            address.Pincode = addressDto.Pincode;

            return address;
        }
    }
}
