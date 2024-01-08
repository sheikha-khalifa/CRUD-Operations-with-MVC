using CRUD_using_MVC.Data;
using CRUD_using_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_using_MVC.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ApplicationDBContext _context;
        public ToDoController(ApplicationDBContext context)
        {
            _context = context; // Injecting ToDo Context
        }
        public IActionResult Index()
        {
            var todo = _context.ToDos.ToList(); // Retrieve ToDo items from the context
            return View(todo);
        }

        //create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ToDo todo)
        {
            if (ModelState.IsValid)
            {
                _context.ToDos.Add(todo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }
        //update
        public IActionResult Update(int id)
        {

            var todo = _context.ToDos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        //Handle updating a ToDo item
        [HttpPost]
        public IActionResult Update(ToDo todo)
        {


            if (ModelState.IsValid)
            {
                _context.ToDos.Update(todo);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }

        // Display confirmation to delete a ToDo item
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = _context.ToDos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        //  Handle deletion of a ToDo item
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var todo = _context.ToDos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.ToDos.Remove(todo);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}