using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        private List<Movie> movies = new List<Movie>()
            {
                new Movie(){Id=1,Name="Shrek"},
                new Movie(){Id=2,Name="Olsen Banden"},
                new Movie(){Id=3,Name="Miver spiser ost"}
            };

        public ActionResult Index()
        {
            return createMovieViewModel(null);
        }

        // GET: movies
        public ActionResult List(int? id)
        {
            return createMovieViewModel(id.HasValue ? id : null);
        }

        private ActionResult createMovieViewModel(int? id)
        {
            var returnViewModel = new MoviesViewModel();
            if (id.HasValue)
            {
                returnViewModel.Movies = movies.Where(c => c.Id == id).ToList();
            }
            else
            {
                returnViewModel.Movies = movies;
            }

            return View("Movies", returnViewModel);
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        // GET: Moveis/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!"};

            var customers = new List<Customer>()
            {
                new Customer(){Id=1,Name="Holger"},
                new Customer(){Id=2,Name="Brian"},
                new Customer(){Id=2,Name="Miver"}
            };

            var viewModel = new RandomMovieViewModel() {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"});
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if (String.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "Name";
        //    return Content($"pageIndex = {pageIndex} and sortBy = {sortBy}");
        //}
    }

   
}