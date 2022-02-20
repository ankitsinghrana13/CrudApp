using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication12.Models;
namespace WebApplication12.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext dbContext;
        public CustomerController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Location> locations = dbContext.Locations.ToList();
            return View(locations);
        }
        public IActionResult CustomerList(int id)
        {
            var cust = dbContext.Customers.Where(e => e.Location.Id==id);
            return View(cust);
        }

        public IActionResult ShowCustomer()
        {
            List<Customer>Customers=dbContext.Customers.ToList();
            return View(Customers);
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer Cust)
        {
            dbContext.Customers.Add(Cust);
            dbContext.SaveChanges();
            return RedirectToAction("ShowCustomer");
        }

      


    }
}

