// used HomePageController Demo from https://github.com/Xipooo/NET-Core-Demo/blob/Step-14/WozUCoreDemo/Controllers/HomePageController.cs
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Data;


namespace FinalProject.Controllers
{
    public class HomePageController : Controller
    {

        // where you see "FinalProjectContext" will change in the future, used as placeholder only

        private readonly ApplicationDbContext _context;
        public HomePageController( ApplicationDbContext context)
        {
            _context = context;
        }
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_context.PageContents.FirstOrDefault(Page => Page.PageName == "HomePage"));
    }
    }
}