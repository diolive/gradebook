using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using DioLive.GradeBook.Models;

namespace DioLive.GradeBook.Controllers
{
    public class ExerciseController : Controller
    {
        private ApplicationDbContext _context;

        public ExerciseController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Exercise
        public async Task<IActionResult> Index()
        {
            return View(await _context.Exercises.ToListAsync());
        }

        // GET: Exercise/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Exercise exercise = await _context.Exercises.SingleAsync(m => m.Id == id);
            if (exercise == null)
            {
                return HttpNotFound();
            }

            return View(exercise);
        }

        // GET: Exercise/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Exercise/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                _context.Exercises.Add(exercise);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(exercise);
        }

        // GET: Exercise/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Exercise exercise = await _context.Exercises.SingleAsync(m => m.Id == id);
            if (exercise == null)
            {
                return HttpNotFound();
            }
            return View(exercise);
        }

        // POST: Exercise/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                _context.Update(exercise);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(exercise);
        }

        // GET: Exercise/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Exercise exercise = await _context.Exercises.SingleAsync(m => m.Id == id);
            if (exercise == null)
            {
                return HttpNotFound();
            }

            return View(exercise);
        }

        // POST: Exercise/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Exercise exercise = await _context.Exercises.SingleAsync(m => m.Id == id);
            _context.Exercises.Remove(exercise);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
