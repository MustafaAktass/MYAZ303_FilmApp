using FilmApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FilmApp.Controllers
{
    public class NextFilmController : Controller
    {
        private readonly DatabaseContext db;
        

        public NextFilmController(DatabaseContext db)
        {
            this.db = db;
            
        }
        public IActionResult Index()
        {
            var value = db.Set<NextFilmFeatures>().ToList();
            return View(value);
        }
        public IActionResult AddNextFilm()
        {   
            return View();
        }
        [HttpPost]
        public IActionResult AddNextFilm(NextFilmFeatures model)
        {
            db.Add(model);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult DeleteNextFilm(int id)
        {
            var values = db.Set<NextFilmFeatures>().Find(id);
            db.Remove(values);
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

       
        public IActionResult AddWatchedFilm(int id)
        {
            FilmController filmController = new FilmController(db);

            var values = db.Set<NextFilmFeatures>().Find(id);
            var watchedFilm = new FilmFeatures()
            {
                
                FilmName = values.NextFilmName,
                FilmComment = ""
            };
            DeleteNextFilm(id);
            filmController.AddFilm(watchedFilm);           
            return RedirectToAction(nameof(Index));
        }

    }
}
