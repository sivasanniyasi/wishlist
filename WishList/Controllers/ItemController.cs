using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;
namespace WishList.Controllers
{
    public class ItemController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View("Index", _context.Items.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        


        [HttpPost]
        public IActionResult Create(WishList.Models.Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index","Item");
        }

        //[HttpGet]
        //public IActionResult Delete()
        //{
        //    //var delItem = _context.Items.FirstOrDefault(i => i.Id == id);
        //    //_context.Items.Remove(delItem);
        //    //_context.SaveChanges();
        //    return View();
        //}

        //[HttpPost]
        public IActionResult Delete(int id)
        {
            var delItem = _context.Items.FirstOrDefault(i => i.Id == id);
            _context.Items.Remove(delItem);
            _context.SaveChanges();
            return RedirectToAction("Index", "Item");
        }
    }
}
