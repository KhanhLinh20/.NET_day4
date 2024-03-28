using day4.Interface;
using day4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace day4.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepo repo;
        public ProductController(IProductRepo repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            return View(await repo.GetProducts());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async  Task<IActionResult> Create(Product product)
        {
            if(ModelState.IsValid) {
                await repo.CreateProduct(product);
                return RedirectToAction("Index");
            }
            return View();
           
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await repo.DeleteProduct(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await repo.GetProduct(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            await repo.UpdateProduct(product);
            return RedirectToAction("Index");
        }
    }
}
