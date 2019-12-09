using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using Vidiling.Models;
using Vidiling.Dtos;
using Vidiling.App_Start;
using AutoMapper;
using System.Data.Entity;
namespace Vidiling.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }



        //Get api/customers
        public IHttpActionResult GetCustomers()
        {
            var ss = _context.Customers
                .Include(c => c.MembershipType).
                ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
            return Ok(ss);
        }



        //Get api/customers/1
        public IHttpActionResult GetCustomer(int Id)
        {
            var customer = _context.Customers.Where(m => m.Id == Id).SingleOrDefault();
            if (customer == null)
                return NotFound();
            return Ok(Mapper.Map<Customer,CustomerDto>( customer));
        }


        //post api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerdto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerdto);
            _context.Customers.Add(customer);
            _context.SaveChanges();
            customerdto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri+"/"+customerdto.Id),customerdto);

        }
       




        //put api/customers/1
        [HttpPut]
        public void UpdateCustomer (int Id,CustomerDto customerdto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customerindb = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customerindb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            Mapper.Map<CustomerDto, Customer>(customerdto, customerindb);
           
            _context.SaveChanges();

        }
        //delete api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int Id)
        {
            var customerindb = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customerindb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerindb);
            _context.SaveChanges();
        }
    }
}
