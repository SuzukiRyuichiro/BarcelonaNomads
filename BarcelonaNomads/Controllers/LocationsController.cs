using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarcelonaNomads.Data;
using BarcelonaNomads.Models;
using Microsoft.AspNetCore.Authorization;
using BarcelonaNomad.Data.Services;

namespace BarcelonaNomads.Controllers
{
    public class LocationsController : Controller
    {
        private readonly ILocationsService _service;

        public LocationsController(ILocationsService service)
        {
            _service = service;
        }

        // GET: Locations
        public async Task<IActionResult> Index()
        {
            var locations = await _service.GetAll();
            return locations != null
                ? View(locations)
                : Problem("Entity set 'ApplicationDbContext.Location'  is null.");
        }

        // GET: Locations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // EDIT this
            var location = await _service.Get(id: 1);
            if (location == null)
            {
                return NotFound();
            }

            return View(location);
        }

        // GET: Locations/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(
            [Bind(include: "Name,Address,ImageURL,Description")] Location location
        )
        {
            if (ModelState.IsValid)
            {
                _service.Add(location);
                return RedirectToAction(nameof(Index));
            }
            return View(location);
        }

        // GET: Locations/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _service.GetAll() == null)
            {
                return NotFound();
            }

            var location = await _service.Get(1);
            if (location == null)
            {
                return NotFound();
            }
            return View(location);
        }
    }
}
