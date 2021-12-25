using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using comero.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using comero.Models;
using Microsoft.EntityFrameworkCore;

namespace comero.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ComeroContext _context;
        public HomeController(ILogger<HomeController> logger, ComeroContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
        [Route("ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            var product = _context.Products
                .Include(p => p.Item)
                .SingleOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            var category = _context.Products
                .Where(p => p.Id == product.Id)
                .SelectMany(c => c.CategoryToProducts)
                .Select(ca => ca.Category).ToList();
            var productData = new DetailsViewModel()
            {
                Product = product,
                Categories = category
            };
            return View(productData);
        }

        public IActionResult AddToCart(int id)
        {
            return null;
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }


}
