
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using CHETUPROJECT.Models;
using System.Linq;
using CHETUPROJECT.Data;
using System;
using System.IO;

namespace CHETUPROJECT.Controllers
{
    [Authorize]
    public class CHETUPROJECT : Controller
    {
        private DataDbContext _dbContext;
        public IHostingEnvironment Environment { get;}    
        public CHETUPROJECT(DataDbContext Dbcontext ,IHostingEnvironment environment)
        {
            _dbContext = Dbcontext;
            Environment = environment;
        }

        // get data
        public IActionResult Index()
        {
            var catagory = _dbContext.Categories.ToList();

            var product = _dbContext.Products.ToList();
            ViewBag.product = product;

            return View(catagory);
        }

        public IActionResult ProdectList(int id)
        {
            var product = _dbContext.Products.Where(e => e.Category.Id == id);
            return View(product);
        }

        // Create 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            var files = Request.Form.Files;
            string dbPath = string.Empty;
            if (files.Count > 0)
            {
                //Image path Create code
                string path = Environment.WebRootPath;
                string fullpath = Path.Combine(path, "image", files[0].FileName);

                dbPath = "image/" + files[0].FileName;
                FileStream stream = new FileStream(fullpath, FileMode.Create);

                files[0].CopyTo(stream);
            }

            product.ImageUrl = dbPath;
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
