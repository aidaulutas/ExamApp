using Microsoft.AspNetCore.Mvc;
using SinavUygulamasiData.DataContext;
using SinavUygulamasiData.Model;
using System.Security.Cryptography.X509Certificates;

namespace SinavUygulamasi.Controllers
{
    public class DifficultyLevelController : Controller
    {
        private readonly SinavUygulamasiContext _context;

        public DifficultyLevelController(SinavUygulamasiContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.DifficultyLevels.Where(x => x.IsDeleted != true).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DifficultyLevel DifficultyLevelModel)
        {
            _context.DifficultyLevels.Add(DifficultyLevelModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var difficultyLevel = _context.DifficultyLevels.Find(id);
            return View(difficultyLevel);
        }
        [HttpPost]
        public IActionResult Update(DifficultyLevel DifficultyLevelModel)
        {
            _context.DifficultyLevels.Update(DifficultyLevelModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var difficultyLevel = _context.DifficultyLevels.Find(id);
            difficultyLevel.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
