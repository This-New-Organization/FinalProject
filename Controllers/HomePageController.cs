// used HomePageController Demo from https://github.com/Xipooo/NET-Core-Demo/blob/Step-14/WozUCoreDemo/Controllers/HomePageController.cs
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Models;


namespace FinalProject.Controllers
{
    public class HomePageController : Controller
    {

        // where you see "FinalProjectContext" will change in the future, used as placeholder only

        private readonly FinalProjectContext _context;
        public HomePageController(FinalProjectContext context)
        {
            _context = context;
        }

        public IActionResult Index() {
            // "Customer is just a name placeholder"
            List<Customer> customers = _context.Customer.ToList();

            return View(customers);
        }
    [HttpGet]
    public IActionResult Edit(int id){
        Customer customer = _context.Customers.FirstOrDefault( c => id == id);
        return View(customer);
    }
    [HttpPost]
    public IActionResult Edit(Customer editCustomer){
        Customer originalCustomer = _context.Customers.FirstOrDefault( c => c.Id == id);
        originalCustomer.FirstName = editedCustomer.FirstName;
        originalCustomer.LastName = editedCustomer.LastName;
        originalCustomer.Email = editedCustomer.Email;
        _context.Customer.Update(originalCustomer);
        _context.SaveChanges();
        return RedirectToAction("Index");
        }
    }
}