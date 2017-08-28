using AutoMapper;
using RestAPIwithDB.Dtos;
using RestAPIwithDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPIwithDB.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<RestCustomer, RestCustomerDto>();
            CreateMap<RestCustomerDto, RestCustomer>();
        }
    }
}