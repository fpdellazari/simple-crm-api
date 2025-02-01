using AutoMapper;
using SimpleCRM.Domain.Entities;
using SimpleCRM.Domain.Models;
using SimpleCRM.Domain.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCRM.Application.Mapper {
    public class MappingProfile : Profile {

        public MappingProfile() { 

            CreateMap<Customer, CustomerModel>();
            CreateMap<CustomerModel, Customer>();
            CreateMap<ContactHistory, ContactHistoryModel>();
            CreateMap<ContactHistoryModel, ContactHistory>();
            CreateMap<Sale, SaleModel>();
            CreateMap<SaleModel, Sale>();
            CreateMap<Product, ProductModel>();
            CreateMap<ProductModel, Product>();
        }

    }
}
