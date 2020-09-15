using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EndedTask.Models;
using EndedTask.Mocks;
using Microsoft.AspNetCore.Identity;
using EndedTask.Repositories;

namespace EndedTask.Controllers
{
    public class ProductController : Controller
    {
        private readonly UnitOfWork _db;
        private readonly UserManager<User> _userManager;
        public ProductController(UserManager<User> userManager, ApplicationDbContext context)
        {
            _db = new UnitOfWork(context);
            _userManager = userManager;

        }
        public IActionResult ProductList()=> View(_db.Products.GetAllList().ToList());
        public IActionResult Find(string Category)
        {
            var FindList = _db.Products.GetAllList().Where(u => u.Category == Category);
            if (FindList != null)
            return View("ProductList", FindList);
            return View("ProductList", _db.Products.GetAllList().ToList());

        }
        public IActionResult DeleteOrderItems(Guid id)
        {
            var h = _db.OrderItems.Get(id);
            if (h != null)
                _db.OrderItems.Delete(h.Id);
            _db.Save();
            return View("Buy", _db);

        }
        public IActionResult Buy() => View("Buy", _db);
        public async Task<IActionResult> Select(Guid item,string button) { 
            if(button == "delete")
            {
               var h =_db.Products.Get(item);
                _db.Products.Delete(h.Id);
                _db.Save();
                return View("ProductList", _db.Products.GetAllList().ToList());
            }
            if(button == "change")
                return View("Shift", item);
            if (button == "buy") {
              //  User user = await _userManager.FindByIdAsync(Convert.ToString(item));
               // if ((await _userManager.IsInRoleAsync(user, "Client") == true) && (user!=null))
               if(User.IsInRole("Client"))
                {
                    var user = await _userManager.FindByNameAsync(User.Identity.Name);
                    var h =_db.Clients.Get(Guid.Parse(user.Id));
                    if (h == null) {
                        Client client = new Client
                        {
                            Name = User.Identity.Name,
                            Code = GenerateCodeClient.Generate(),
                            Id = Guid.Parse(user.Id)
                        };
                        _db.Clients.Create(client);
                        _db.Save();

                        BuyingProduct.AddToCan(_db,client,_db.Products.Get(item));
                        
                        return View("Buy",_db);
                    }
                    else {
                        BuyingProduct.AddToCan(_db,h,_db.Products.Get(item));
                        
                        return View("Buy",_db);
                        
                    }
                }
                return RedirectToAction("Index", "Home");
            }
            return View("ProductList", _db.Products.GetAllList().ToList());
        }
   
        public IActionResult Create()
        {

            return View("Create");
        }
        public IActionResult Add(Product product)
        {

            var h = _db.Products.Get(product.Id);
            var copy = product;
            if (h == null)
            {
                copy.Code = GenerateCodeProduct.GenerateCode();
                _db.Products.Create(copy);
                _db.Save();

            }
            return View("ProductList", _db.Products.GetAllList().ToList());
        }
        public IActionResult Changed(Guid mark, Product product)
        {
            var h = _db.Products.Get(mark);
            var g = _db.OrderItems.GetAllList().Where(u => u.ProductId == h.Id);
            bool flag = false;
            if (h != null)
            {
                if (product.image != null)
                {
                    flag = true;
                    h.image = product.image;
                }
                if (product.Name != null)
                {
                    flag = true;
                    h.Name = product.Name;
                }
                if (product.Price > 0)
                {
                    flag = true;
                    h.Price = product.Price;
                }
                if (product.Category != null)
                {
                    flag = true;
                    h.Category = product.Category;
                }
                if (g != null && flag == true)
                {
                    foreach (var item in g)
                        _db.OrderItems.Delete(item.Id);
                    _db.Save();
                }
                if (flag == true)
                {
                    _db.Products.Update(h);
                    _db.Save();
                }
                _db.Save();

            }
            return View("ProductList", _db.Products.GetAllList().ToList());
        }
    }
}
