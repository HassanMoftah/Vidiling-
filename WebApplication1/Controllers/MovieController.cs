using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidiling.Models;
using Vidiling.ViewModel;
using System.Data.Entity;

namespace Vidiling.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        private ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Movie()
        {
            ViewBag.Message = "Your movies page.";
            // var movielist = _context.Movies.Include(m=>m.Genre).ToList();
            if (User.IsInRole(RoleName.CanManageMovies))
            {
                return View("List");
            }
            else
            {
                return View("ReadOnlyList");//(movielist);
            }
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Include(m=>m.Genre).Where(x => x.Id == id).SingleOrDefault();
            if (movie == null)
                return HttpNotFound();
            else
            {
                MovieViewModel movieviewmodel = new MovieViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                }; return View("MovieForm", movieviewmodel);
            }
           
        }
        [Authorize (Roles =RoleName.CanManageMovies)]
        public ActionResult MovieForm()
        {
            MovieViewModel movieviewmodel = new MovieViewModel
            {
                Movie = new Movie(),
                Genres = _context.Genres.ToList()
               
            };
            return View(movieviewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id != 0)
            {
                var movieindb = _context.Movies.Single(m => m.Id == movie.Id);
                movieindb.Name = movie.Name;
                movieindb.NumberInStock = movie.NumberInStock;
                movieindb.ReleaseDate = movie.ReleaseDate;
                movieindb.DataAdded = movie.DataAdded;
          
                movieindb.GenreId = movie.GenreId;

            }
            else
            {
                _context.Movies.Add(movie);
            }
            
            _context.SaveChanges();
            return RedirectToAction("Movie", "Movie");
        }
    }
}