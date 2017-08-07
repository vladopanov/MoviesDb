using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using MoviesDB.Data;
using MoviesDB.Models;

namespace MoviesDB.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetMovies()
        {
            using (MoviesDbContext ctx = new MoviesDbContext())
            {
                IEnumerable<Movie> movies = ctx.Movies.OrderBy(m => m.ReleaseDate).ToList();
                return Json(new {data = movies}, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            using (MoviesDbContext ctx = new MoviesDbContext())
            {
                Movie movie = ctx.Movies.FirstOrDefault(m => m.Id == id);
                return View(movie);
            }
        }

        [HttpPost]
        public ActionResult Save(Movie movieBm)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                using (MoviesDbContext ctx = new MoviesDbContext())
                {
                    if (movieBm.Id > 0)
                    {
                        // Edit
                        Movie movie = ctx.Movies.FirstOrDefault(m => m.Id == movieBm.Id);
                        if (movie != null)
                        {
                            movie.Title = movieBm.Title;
                            movie.DirectorName = movieBm.DirectorName;
                            movie.ReleaseDate = movieBm.ReleaseDate;
                        }
                    }
                    else
                    {
                        // Save
                        ctx.Movies.Add(movieBm);
                    }
                    ctx.SaveChanges();
                    status = true;
                }
            }

            return new JsonResult { Data = new {status = status} };
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (MoviesDbContext ctx = new MoviesDbContext())
            {
                Movie movie = ctx.Movies.FirstOrDefault(m => m.Id == id);
                if (movie != null)
                {
                    return View(movie);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteMovie(int id)
        {
            bool status = false;
            using (MoviesDbContext ctx = new MoviesDbContext())
            {
                Movie movie = ctx.Movies.FirstOrDefault(m => m.Id == id);
                if (movie != null)
                {
                    ctx.Movies.Remove(movie);
                    ctx.SaveChanges();
                    status = true;
                }
            }
            return new JsonResult{ Data = new { status = status } };
        }

        public JsonResult GetJsonData()
        {
            using (MoviesDbContext ctx = new MoviesDbContext())
            {
                var movies = ctx.Movies.OrderBy(m => m.ReleaseDate).ToList()
                    .Select(m => new
                    {
                        id = m.Id,
                        title = m.Title,
                        direcorName = m.DirectorName,
                        end = m.ReleaseDate.ToString(CultureInfo.InvariantCulture)
                    });


                return Json(new { data = movies }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}