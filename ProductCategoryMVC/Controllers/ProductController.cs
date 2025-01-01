using Microsoft.AspNetCore.Mvc;
using ProductCategoryMVC.Data;
using Microsoft.EntityFrameworkCore;
using ProductCategoryMVC.Models;
using System.Linq;

namespace ProductCategoryMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            var products = _context.Products
                           .Include(p => p.Category)
                           .OrderBy(p => p.ProductId)
                           .Skip((pageNumber - 1) * pageSize)
                           .Take(pageSize)
                           .ToList();

            ViewBag.CurrentPage = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalCount = _context.Products.Count();
            return View(products);
        }

        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            ViewBag.Categories = _context.Categories.ToList();
            return RedirectToAction("Index", "Product");

        }

        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                return NotFound();

            ViewBag.Categories = _context.Categories.ToList();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
        {
            var existingProduct = _context.Products.Find(product.ProductId);
            existingProduct.ProductName = product.ProductName;
            existingProduct.CategoryId = product.CategoryId;

            _context.SaveChanges();

            return RedirectToAction("Index", "Product");
        }

        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                return NotFound();

            _context.Products.Remove(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}
