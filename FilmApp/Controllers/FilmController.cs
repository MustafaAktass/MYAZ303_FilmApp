using FilmApp.Entities;
using FilmApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmApp.Controllers
{
    public class FilmController : Controller
    {
        private readonly DatabaseContext db;

        public FilmController(DatabaseContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {           
            var values= db.Set<FilmFeatures>().ToList();  
            return View(values);          
        }
        public IActionResult FilmDetails(int id)
        {
            var filmDetails = db.Set<FilmFeatures>().Find(id);
            
            return View(filmDetails);
        }
        public IActionResult AddFilm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddFilm(FilmFeatures model)
        {
            db.Add(model);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        } 

        public IActionResult DeleteFilm(int id)
        {
            var value = db.Set<FilmFeatures>().Find(id);
            db.Remove(value);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        
    }
}
