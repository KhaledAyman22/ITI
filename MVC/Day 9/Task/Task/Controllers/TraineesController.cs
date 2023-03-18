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
    public class TraineesController : Controller
    {
        private readonly ITraineeRepo _traineeRepo;
        private readonly ITrackRepo _trackRepo;
        private readonly ICourseRepo _courseRepo;

        public TraineesController(ITraineeRepo traineeRepo, ITrackRepo trackRepo, ICourseRepo courseRepo)
        {
            _traineeRepo = traineeRepo;
            _trackRepo = trackRepo;
            _courseRepo = courseRepo;
        }

        // GET: Trainees
        public async Task<IActionResult> Index()
        {
            var traineesDbContext = _traineeRepo.ReadAll(true,true);
            return View(traineesDbContext);
        }

        // GET: Trainees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var res = _traineeRepo.ReadAll(true, true);
            if (id == null || res == null)
            {
                return NotFound();
            }

            var trainee = res.FirstOrDefault(m => m.Id == id);
            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        // GET: Trainees/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_courseRepo.ReadAll(), "Id", "Id");
            ViewData["TrackId"] = new SelectList( _trackRepo.ReadAll(), "Id", "Id");
            return View();
        }

        // POST: Trainees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Gender,Email,MobileNumber,Birthdate,TrackId,CourseId")] Trainee trainee)
        {
            trainee.Course = _courseRepo.Read(trainee.CourseId);
            trainee.Track =  _trackRepo.Read(trainee.TrackId);
            
            if (ModelState.IsValid)
            {
                _traineeRepo.Create(trainee);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_courseRepo.ReadAll(), "Id", "Id", trainee.CourseId);
            ViewData["TrackId"] = new SelectList(_trackRepo.ReadAll(), "Id", "Id", trainee.TrackId);
            return View(trainee);
        }

        // GET: Trainees/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var res = _traineeRepo.ReadAll(false, false);
            if (id == null || res == null)
            {
                return NotFound();
            }

            var trainee =_traineeRepo.Read(id);
            if (trainee == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_courseRepo.ReadAll(), "Id", "Id", trainee.CourseId);
            ViewData["TrackId"] = new SelectList( _trackRepo.ReadAll(), "Id", "Id", trainee.TrackId);
            return View(trainee);
        }

        // POST: Trainees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Gender,Email,MobileNumber,Birthdate,TrackId,CourseId")] Trainee trainee)
        {
            if (id != trainee.Id)
            {
                return NotFound();
            }

            trainee.Track =  _trackRepo.Read(trainee.TrackId);
            trainee.Course = _courseRepo.Read(trainee.CourseId);

            if (ModelState.IsValid)
            {
                try
                {
                    _traineeRepo.Update(id, trainee);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TraineeExists(trainee.Id))
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
            ViewData["CourseId"] = new SelectList(_courseRepo.ReadAll(), "Id", "Id", trainee.CourseId);
            ViewData["TrackId"] = new SelectList( _trackRepo.ReadAll(), "Id", "Id", trainee.TrackId);
            return View(trainee);
        }

        // GET: Trainees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var res = _traineeRepo.ReadAll(true, true);
            if (id == null || res == null)
            {
                return NotFound();
            }

            var trainee = res.FirstOrDefault(m => m.Id == id);
            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        // POST: Trainees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var res = _traineeRepo.ReadAll(false, false);
            if (res == null)
            {
                return Problem("Entity set 'TraineesDbContext.Trainees'  is null.");
            }
            var trainee = _traineeRepo.Read(id);
            if (trainee != null)
            {
                _traineeRepo.Delete(trainee);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool TraineeExists(int id)
        {
          return (_traineeRepo.ReadAll(false, false)?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
