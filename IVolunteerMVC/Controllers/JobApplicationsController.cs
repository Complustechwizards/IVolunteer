using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IVolunteerMVC.Data;
using IVolunteerMVC.Models.ProjectModel;
using Microsoft.AspNetCore.Authorization;
using IVolunteerMVC.Models;
using Microsoft.AspNetCore.Identity;

namespace IVolunteerMVC.Controllers
{
    
    public class JobApplicationsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public JobApplicationsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: JobApplications
        
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.JobApplication.Include(j => j.Posting);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: JobApplications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplication = await _context.JobApplication
                .Include(j => j.Posting)
                .SingleOrDefaultAsync(m => m.JobApplicationId == id);
            if (jobApplication == null)
            {
                return NotFound();
            }

            return View(jobApplication);
        }

        // GET: JobApplications/Create
        public IActionResult Create()
        {
            ViewData["PostingId"] = new SelectList(_context.Posting, "PostingId", "Description");
            return View();
        }

        // POST: JobApplications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("JobApplicationId,CoverLetter,DateOfApplication")] JobApplication jobApplication)
        {
            if (ModelState.IsValid)
            {
                jobApplication.ApplicationUserId = _userManager.GetUserId(User).ToString();
                jobApplication.PostingId = id;
                _context.Add(jobApplication);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostingId"] = new SelectList(_context.Posting, "PostingId", "Description", jobApplication.PostingId);
            return View(jobApplication);
        }

        // GET: JobApplications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplication = await _context.JobApplication.SingleOrDefaultAsync(m => m.JobApplicationId == id);
            if (jobApplication == null)
            {
                return NotFound();
            }
            ViewData["PostingId"] = new SelectList(_context.Posting, "PostingId", "Description", jobApplication.PostingId);
            return View(jobApplication);
        }

        // POST: JobApplications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JobApplicationId,CoverLetter,DateOfApplication,PostingId,ApplicationUserId")] JobApplication jobApplication)
        {
            if (id != jobApplication.JobApplicationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobApplication);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobApplicationExists(jobApplication.JobApplicationId))
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
            ViewData["PostingId"] = new SelectList(_context.Posting, "PostingId", "Description", jobApplication.PostingId);
            return View(jobApplication);
        }

        // GET: JobApplications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jobApplication = await _context.JobApplication
                .Include(j => j.Posting)
                .SingleOrDefaultAsync(m => m.JobApplicationId == id);
            if (jobApplication == null)
            {
                return NotFound();
            }

            return View(jobApplication);
        }

        // POST: JobApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jobApplication = await _context.JobApplication.SingleOrDefaultAsync(m => m.JobApplicationId == id);
            _context.JobApplication.Remove(jobApplication);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobApplicationExists(int id)
        {
            return _context.JobApplication.Any(e => e.JobApplicationId == id);
        }
    }
}
