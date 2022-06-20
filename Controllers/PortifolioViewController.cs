using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class PortifolioViewController : Controller
    {
        private readonly WebContext _context;

        public PortifolioViewController(WebContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
              return _context.Portifolio != null ? 
                          View(await _context.Portifolio.ToListAsync()) :
                          Problem("Entity set 'WebContext.Portifolio'  is null.");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}