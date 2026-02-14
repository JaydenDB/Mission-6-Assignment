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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
