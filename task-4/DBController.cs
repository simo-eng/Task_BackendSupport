using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class DBController : Controller
    {
        private static List<Product> products = new List<Product>();
        private static List<Blog> blogs = new List<Blog>();
        public DBController()
        {

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddProduct()
        {
            return View();
        }
        
      
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            int id =0;
            if(products.Count == 0)
            {
                id = 1;
            }
            else
            {
                id = products.Max(x => x.Id) + 1;
            }
            product.Id = id;
            products.Add(product);
            return RedirectToAction("index");
        }
        #region 
        public IActionResult GetAllData()
        {

            return View(products);

        }
        #endregion
        #region delete
        public IActionResult DeleteProduct(int id)
        {
            Product pro = products.FirstOrDefault(x => x.Id == id);
            products.Remove(pro);

            return RedirectToAction("GetAllData");

        }
        #endregion
        #region editpro
        public IActionResult EditProduct(int id)
        {
            Product pro = products.FirstOrDefault(x => x.Id == id);
           

            return View(pro);

        }
        [HttpPost]
        public IActionResult EditProduct(Product pro)
        {
            Product p= products.FirstOrDefault(x => x.Id==pro.Id);
            p.Name= pro.Name;
            p.Description= pro.Description;
            p.Price= pro.Price;
            p.Quant= pro.Quant;
            p.EnableSize=pro.EnableSize;
            p.comp.Id = pro.comp.Id;
           
                
            return RedirectToAction("index");

        }
        #endregion
        public IActionResult AddBlog()
        {
            return View();
        }
       [HttpPost]
        public IActionResult AddBlog(Blog blog)
        { 
        
           int id = 0;
            if (blogs.Count == 0)
            {
               id = 1;
            }
            else
            {
               id = blogs.Max(x => x.Id) + 1;
            }
            blog.Id = id;
            blogs.Add(blog);
            return RedirectToAction("index");
        }
        #region 
        public IActionResult ViewBlog()
        {

            return View(blogs);

        }
        #endregion
        #region delete2
        public IActionResult DeleteBlog(int id)
        {
            Blog b = blogs.FirstOrDefault(x => x.Id == id);
            blogs.Remove(b);

            return RedirectToAction("ViewBlog");

        }
        #endregion
        #region editblog
        public IActionResult EditBlog(int id)
        {
            Blog b = blogs.FirstOrDefault(x => x.Id == id);
            

            return View(b);

        }
        [HttpPost]
        public IActionResult EditBlog(Blog bl)
        {
            Blog b = blogs.FirstOrDefault(x => x.Id == bl.Id);
           b.Title = bl.Title;
            b.Description = bl.Description;
            b.type.Id=bl.type.Id;
            
            return RedirectToAction("index");

        }
        #endregion

    }
}
