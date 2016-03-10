using System.Threading.Tasks;
using DioLive.GradeBook.Models;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;

namespace DioLive.GradeBook.Controllers
{
    public class ResultController : Controller
    {
        private ApplicationDbContext _context;

        public ResultController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Result
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Results.Include(r => r.Exercise).Include(r => r.Student);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Result/Create
        public IActionResult Create()
        {
            ViewData["ExerciseId"] = new SelectList(_context.Exercises, nameof(Exercise.Id), nameof(Exercise.Title));
            ViewData["StudentId"] = new SelectList(_context.Students, nameof(Student.Id), nameof(Student.Name));
            return View();
        }

        // POST: Result/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Result result)
        {
            if (ModelState.IsValid)
            {
                _context.Results.Add(result);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewData["ExerciseId"] = new SelectList(_context.Exercises, nameof(Exercise.Id), nameof(Exercise.Title));
            ViewData["StudentId"] = new SelectList(_context.Students, nameof(Student.Id), nameof(Student.Name));
            return View(result);
        }

        // GET: Result/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Result result = await _context.Results.SingleOrDefaultAsync(m => m.Id == id);
            if (result == null)
            {
                return HttpNotFound();
            }

            ViewData["ExerciseId"] = new SelectList(_context.Exercises, nameof(Exercise.Id), nameof(Exercise.Title));
            ViewData["StudentId"] = new SelectList(_context.Students, nameof(Student.Id), nameof(Student.Name));
            return View(result);
        }

        // POST: Result/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Result result)
        {
            if (ModelState.IsValid)
            {
                _context.Update(result);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewData["ExerciseId"] = new SelectList(_context.Exercises, nameof(Exercise.Id), nameof(Exercise.Title));
            ViewData["StudentId"] = new SelectList(_context.Students, nameof(Student.Id), nameof(Student.Name));
            return View(result);
        }

        // GET: Result/Delete/5
        [ActionName("Delete")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Result result = await _context.Results.SingleOrDefaultAsync(m => m.Id == id);
            if (result == null)
            {
                return HttpNotFound();
            }

            return View(result);
        }

        // POST: Result/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Result result = await _context.Results.SingleAsync(m => m.Id == id);
            _context.Results.Remove(result);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}