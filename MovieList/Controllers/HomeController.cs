﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieList.Models;
using Microsoft.EntityFrameworkCore;

namespace MovieList.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext context { get; set; }           //New

        public HomeController(MovieContext ctx)         //New
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            //New var to hold movies
            var movies = context.Movies
                .Include(m => m.Genre)
                .OrderBy(m => m.Name)
                .ToList(); 
            return View(movies);   //Sends movies object to view
        }
    }
}

