using Microsoft.AspNetCore.Mvc;
using Table_Track.Models;
using Table_Track.Repository;
using Table_Track.Repository.IRepository;

namespace Table_Track.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public IActionResult Index(string search = null, int page = 1)
        {
            var pageSize = 5;    
            var cs = customerRepository.GetAll();

             if (!string.IsNullOrEmpty(search))
            {
                search = search.Trim();
                cs = cs.Where(e => e.ZipCode.Contains(search));

                if (!cs.Any())
                {
                    return RedirectToAction("NotFoundPage", "Home");
                }
            }

             var totalItems = cs.Count();

             var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

             var customersOnPage = cs.Skip((page - 1) * pageSize).Take(pageSize).ToList();

             ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(customersOnPage);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            customerRepository.Add(customer);
            customerRepository.Commit();
            TempData["success"] = "Add Customer successfully";

            return RedirectToAction("");
        }
        public IActionResult Edit(int id)
        {
            var cat = customerRepository.GetOne([]).FirstOrDefault(e => e.Id == id);
            return View(cat);
        }
        [HttpPost]

        public IActionResult Edit(Customer customer)
        {
            customerRepository.Edit(customer);
            customerRepository.Commit();
            TempData["success"] = "Edit Customer successfully";
            return RedirectToAction(""); 
        }
        public IActionResult Delete(int id )
        {
            Customer cs = new Customer() { Id =id };
             customerRepository.Delete(cs);
            customerRepository.Commit();
            TempData["success"] = "Delete Customer successfully";
            return RedirectToAction("");

        }
    }
}
