using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using miniproject.Data;
using miniproject.Models;

namespace miniproject.Controllers
{
    public class MyController : Controller
    {
        private readonly AppDbContext _db;

        public MyController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index() {
            IEnumerable<MyModel> objectList = _db.MyTable;
            return View(objectList);
        }

        //GET - CREATE
        public IActionResult Create() {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        public IActionResult Create(MyModel obj) {
            if(ModelState.IsValid){
                _db.MyTable.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET - EDIT
        public IActionResult Edit(int? id) {
            if(id == null)
                return NotFound();
            var obj = _db.MyTable.Find(id);
            if(obj == null)
                return NotFound();
            
            return View(obj);
        }

        //POST - EDIT
        [HttpPost]
        public IActionResult Edit(MyModel obj) {
            if(ModelState.IsValid){
                _db.MyTable.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //POST - DELETE
        [HttpPost]
        public IActionResult Delete(int? id) {
            var obj = _db.MyTable.Find(id);
            
            if(obj == null)
                return NotFound();

            _db.MyTable.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
            
        }
    }
}