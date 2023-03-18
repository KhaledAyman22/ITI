using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalTask.Models;
using FinalTask.Contracts;
using Microsoft.AspNetCore.Authorization;


namespace Task.Controllers
{
    [Authorize]
    public class TracksController : Controller
    {
        private readonly ITrackRepo _trackRepo;

        public TracksController(ITrackRepo trackRepo)
        {
            _trackRepo = trackRepo;
        }

        // GET: Tracks
        public async Task<IActionResult> Index()
        {
            var res = _trackRepo.ReadAll();
              return res != null ? 
                          View(res) :
                          Problem("Entity set 'TraineesDbContext.Tracks'  is null.");
        }

        // GET: Tracks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var res = _trackRepo.ReadAll();

            if (id == null || res == null)
            {
                return NotFound();
            }

            var track = res.FirstOrDefault(m => m.Id == id);
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        // GET: Tracks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tracks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Track track)
        {
            if (ModelState.IsValid)
            {
                _trackRepo.Create(track);
                return RedirectToAction(nameof(Index));
            }
            return View(track);
        }

        // GET: Tracks/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var res = _trackRepo.ReadAll();

            if (id == null || res == null)
            {
                return NotFound();
            }

            var track = _trackRepo.Read(id);
            if (track == null)
            {
                return NotFound();
            }
            return View(track);
        }

        // POST: Tracks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Track track)
        {
            if (id != track.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _trackRepo.Update(id, track);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrackExists(track.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(track);
        }

        // GET: Tracks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var res = _trackRepo.ReadAll();

            if (id == null || res == null)
            {
                return NotFound();
            }

            var track = res.FirstOrDefault(m => m.Id == id);
            if (track == null)
            {
                return NotFound();
            }

            return View(track);
        }

        // POST: Tracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var res = _trackRepo.ReadAll();

            if (res == null)
            {
                return Problem("Entity set 'TraineesDbContext.Tracks'  is null.");
            }
            var track = _trackRepo.Read(id);
            if (track != null)
            {
                _trackRepo.Delete(track);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool TrackExists(int id)
        {
          return (_trackRepo.ReadAll()?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
