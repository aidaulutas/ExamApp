using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SinavUygulamasiData.DataContext;
using SinavUygulamasiData.Model;

namespace SinavUygulamasi.Controllers
{
    public class ExamController : Controller
    {
        private readonly SinavUygulamasiContext _context;

        public ExamController(SinavUygulamasiContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Exams.Where(x => x.IsDeleted != true).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Subject = _context.Subjects.Where(x => x.IsDeleted != true).ToList();
            var QuestionType = _context.QuestionTypes.Where(x => x.IsDeleted != true).ToList();
            var nwQuestionType = new QuestionType();
            nwQuestionType.Name = "Mixed Question Types";
            QuestionType.Add(nwQuestionType);
            ViewBag.DifficultyLevel = _context.DifficultyLevels.Where(x => x.IsDeleted != true).ToList();
            ViewBag.ExamType = QuestionType;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Exam ExamModel)
        {
            _context.Exams.Add(ExamModel);
            _context.SaveChanges();
            try
            {
                var soruBul = new List<Question>();
                if (ExamModel.Id == 3)
                {
                    soruBul = _context.Questions.Where(x => x.IsDeleted != true && x.DifficultyLevelId == ExamModel.DifficultyLevelId && x.SubjectId == ExamModel.SubjectId).ToList();

                }
                else if (ExamModel.Id == 2)
                {
                    
                }
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var exam = _context.Exams.Find(id);
            ViewBag.Subject = _context.Subjects.Where(x => x.IsDeleted != true).ToList();
            var QuestionType = _context.QuestionTypes.Where(x => x.IsDeleted != true).ToList();
            var nwQuestionType = new QuestionType();
            nwQuestionType.Name = "Mixed Question Types";
            QuestionType.Add(nwQuestionType);
            ViewBag.DifficultyLevel = _context.DifficultyLevels.Where(x => x.IsDeleted != true).ToList();
            ViewBag.ExamType = QuestionType;
            return View(exam);
        }
        [HttpPost]
        public IActionResult Update(Exam ExamModel)
        {
            _context.Exams.Update(ExamModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var exam = _context.Exams.Find(id);
            exam.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
