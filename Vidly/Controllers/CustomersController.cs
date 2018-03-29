using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;


namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private List<Customer> customers = new List<Customer>()
            {
                new Customer(){Id=1,Name="Holger"},
                new Customer(){Id=2,Name="Brian"},
                new Customer(){Id=3,Name="Miver"}
            };

        public ActionResult Index()
        {
            return createCumstomerViewModel(null);
        }

        // GET: Customers
        public ActionResult List(int? id)
        {
            return createCumstomerViewModel(id.HasValue ? id : null);
        }

        private ActionResult createCumstomerViewModel(int? id)
        {
            var returnViewModel = new CustomersViewModel();
            if (id.HasValue)
            {
                returnViewModel.Customers = customers.Where(c => c.Id == id).ToList();
            }
            else
            {
                returnViewModel.Customers = customers;
            }

            return View("Customers", returnViewModel);
        }
    }
}