using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Brown.Models;

namespace Mission06_Brown.Controllers;

public class HomeController : Controller
{
    private readonly MovieContext _context;

    public HomeController(MovieContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnowJoel()
    {
        return View();
    }

    [HttpGet]
    public IActionResult EnterMovie()
    {
        ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
        return View();
    }

    [HttpPost]
    public IActionResult EnterMovie(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Movie added successfully!";
            return RedirectToAction("EnterMovie");
        }

        // If validation fails, reload categories and return the form
        ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
        return View(movie);
    }

    // Display list of all movies
    public IActionResult MovieList()
    {
        var movies = _context.Movies
            .Include(m => m.Category)
            .OrderBy(m => m.Title)
            .ToList();
        return View(movies);
    }

    // GET: Edit movie
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var movie = _context.Movies
            .Include(m => m.Category)
            .FirstOrDefault(m => m.MovieId == id);

        if (movie == null)
        {
            return NotFound();
        }

        ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
        return View(movie);
    }

    // POST: Edit movie
    [HttpPost]
    public IActionResult Edit(Movie movie)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Movie updated successfully!";
            return RedirectToAction("MovieList");
        }

        // If validation fails, reload categories and return the form
        ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
        return View(movie);
    }

    // GET: Delete confirmation
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var movie = _context.Movies
            .Include(m => m.Category)
            .FirstOrDefault(m => m.MovieId == id);

        if (movie == null)
        {
            return NotFound();
        }

        return View(movie);
    }

    // POST: Delete movie
    [HttpPost]
    [ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var movie = _context.Movies.Find(id);
        if (movie == null)
        {
            return NotFound();
        }

        _context.Movies.Remove(movie);
        _context.SaveChanges();

        TempData["SuccessMessage"] = "Movie deleted successfully!";
        return RedirectToAction("MovieList");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
