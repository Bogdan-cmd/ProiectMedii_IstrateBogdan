﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectMediiMaster_BogdanIstrate.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ProjectMediiMaster_BogdanIstrate.Models.LibraryViewModels;
using ProjectMediiMaster_BogdanIstrate.Data;
using Microsoft.EntityFrameworkCore;

namespace ProjectMediiMaster_BogdanIstrate.Controllers
{
    public class HomeController : Controller
    {
        private readonly LibraryContext _context;
        public HomeController(LibraryContext context)
        {
            _context = context;
        }
       

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<ActionResult> Statistics()
        {
            IQueryable<GuitarOrderGroup> data =
            from order in _context.GuitarOrders
            group order by order.OrderDate into dateGroup
            select new GuitarOrderGroup()
            {
                OrderDate = dateGroup.Key,
                GuitarCount = dateGroup.Count()
            };
            return View(await data.AsNoTracking().ToListAsync());
        }
        public IActionResult Chat()
        {
            return View();
        }
    }
}
