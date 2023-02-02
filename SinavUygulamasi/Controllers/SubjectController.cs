using Microsoft.AspNetCore.Mvc;
using SinavUygulamasiData.DataContext;
using SinavUygulamasiData.Model;

namespace SinavUygulamasi.Controllers
{
    public class SubjectController : Controller
    {

        private readonly SinavUygulamasiContext _context; 

        public SubjectController(SinavUygulamasiContext context)
        {
            
            _context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Subjects.Where(x=>x.IsDeleted != true).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Subject SubjectModel)
        {
            _context.Subjects.Add(SubjectModel);
            _context.SaveChanges();
            return RedirectToAction("Index","Subject");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var subject = _context.Subjects.Find(id);
            return View(subject);
        }
        [HttpPost]
        public IActionResult Update(Subject SubjectModel)
        {
            _context.Subjects.Update(SubjectModel);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            var subject = _context.Subjects.Find(id).IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        

    }
}
