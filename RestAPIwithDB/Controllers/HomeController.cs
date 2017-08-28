using AutoMapper;
using RestAPIwithDB.Dtos;
using RestAPIwithDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAPIwithDB.Controllers
{  // This is a demo comment ..//
    public class HomeController : ApiController
    {
        RestCustomerContext context;

        public HomeController()
        {
            context = new RestCustomerContext();
        }

       public IEnumerable<RestCustomerDto> GetAllCustomer()
        {
            return context.RestCustomers.ToList().Select(Mapper.Map < RestCustomer, RestCustomerDto>);
        }

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = context.RestCustomers.SingleOrDefault(c => c.Id == id);
            if(customer == null)
            {
                return BadRequest();
            }
            return Ok(Mapper.Map<RestCustomer, RestCustomerDto>(customer));
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(RestCustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = Mapper.Map<RestCustomerDto, RestCustomer>(customerDto);
            context.RestCustomers.Add(customer);
            context.SaveChanges();
            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);


        }

        [HttpPut]
        public void  UpdateCustomer(int id,RestCustomerDto customerDto)
        {
            if (!ModelState.IsValid)
               throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerinDb = context.RestCustomers.SingleOrDefault(c => c.Id == id);
            if (customerinDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(customerDto, customerinDb);
            context.SaveChanges();
        }
        
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerinDb = context.RestCustomers.SingleOrDefault(c => c.Id == id);
            if(customerinDb==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            context.RestCustomers.Remove(customerinDb);
            context.SaveChanges();
            
        }

    }
}
