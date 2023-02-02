using Microsoft.AspNetCore.Mvc;
using SinavUygulamasiData.DataContext;
using System.Runtime.CompilerServices;
using SinavUygulamasiData.Model;
using Microsoft.EntityFrameworkCore;

namespace SinavUygulamasi.Controllers
{
    public class QuestionController : Controller
    {
        private readonly SinavUygulamasiContext _context;

        public QuestionController(SinavUygulamasiContext context)
        {
            _context = context;
        }

       
        public IActionResult Index(int id)
        {
            var model = _context.Questions.Include(x=>x.QuestionType).Include(x=>x.Subject).Include(x=>x.DifficultyLevel).Where(x => x.SubjectId == id && x.IsDeleted != true).ToList();
            ViewBag.SubjectId = id;
            return View(model);
        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            ViewBag.SubjectId = id;
            ViewBag.QuestionType = _context.QuestionTypes.ToList();
            ViewBag.DifficultyLevel = _context.DifficultyLevels.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Question QuestionModel)
        {
            _context.Questions.Add(QuestionModel);
            _context.SaveChanges();
            return RedirectToAction("Index", new { Id = QuestionModel.SubjectId });
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var question = _context.Questions.Include(x=>x.Answers.Where(x=>x.IsDeleted != true)).FirstOrDefault(x=>x.Id == id);
            ViewBag.QuestionType = _context.QuestionTypes.ToList();
            ViewBag.DifficultyLevel= _context.DifficultyLevels.ToList();
            return View(question);
        }
        [HttpPost]
        public IActionResult Update(Question QuestionModel)
        {
            _context.Questions.Update(QuestionModel);
            _context.SaveChanges();
            return RedirectToAction("Index", new {Id=QuestionModel.SubjectId});
        }
        public IActionResult Delete(int id)
        {
            var question = _context.Questions.Find(id);
            question.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction("Index", new { Id = question.SubjectId});
        }

        public IActionResult AnswerDelete(int id)
        {
            var answer = _context.Answers.FirstOrDefault(x=>x.Id ==id);
            answer.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction("Update", new { Id = answer.QuestionId});
        }

    }
}
