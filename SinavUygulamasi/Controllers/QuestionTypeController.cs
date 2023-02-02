using Microsoft.AspNetCore.Mvc;
using SinavUygulamasiData.DataContext;
using SinavUygulamasiData.Model;

namespace SinavUygulamasi.Controllers
{
    public class QuestionTypeController : Controller
    {
        private readonly SinavUygulamasiContext _context;

        public QuestionTypeController(SinavUygulamasiContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.QuestionTypes.Where(x=>x.IsDeleted != true).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(QuestionType QuestionTypeModel)
        {
            _context.QuestionTypes.Add(QuestionTypeModel);
            _context.SaveChanges();
            return RedirectToAction("Index", "QuestionType");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var questionType = _context.QuestionTypes.Find(id);
            return View(questionType);
        }
        [HttpPost]
        public IActionResult Update(QuestionType QuestionTypeModel)
        {
            _context.QuestionTypes.Update(QuestionTypeModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var questionType = _context.QuestionTypes.Find(id).IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
