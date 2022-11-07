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
            var locations = await _service.GetAllAsync();
            return locations != null
                ? View(locations)
                : Problem("Entity set 'ApplicationDbContext.Location'  is null.");
        }

        // GET: Locations/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var location = await _service.GetAsync(id);

            if (location == null)
            {
                NotFound();
                return View("NotFound");
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
                await _service.AddAsync(location);
                return RedirectToAction(nameof(Index));
            }
            return View(location);
        }

        // GET: Locations/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            var location = await _service.GetAsync(id: id);
            if (location == null)
            {
                return NotFound();
            }
            return View(location);
        }

        // POST: Locations/Edit/5
        [ValidateAntiForgeryToken]
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Location location)
        {
            // Validate the new location
            if (!ModelState.IsValid)
            {
                return View(location);
            }
            // tell the service to update
            await _service.UpdateAsync(id, location);
            // redirect to index
            return RedirectToAction(nameof(Index));
        }
    }
}
