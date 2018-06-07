using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IVolunteerMVC.Data;
using IVolunteerMVC.Models.ProjectModel;
using Microsoft.AspNetCore.Identity;
using IVolunteerMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace IVolunteerMVC.Controllers
{

    [Authorize]
    public class PostingsController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public PostingsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Postings
        public async Task<IActionResult> Index(string searchString)
        {
            var posts = from p in _context.Posting
                        select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                posts = posts.Where(p => p.JobTitle.Contains(searchString));
            }

            return View(await _context.Posting.ToListAsync());
        }

       
        public async Task<IActionResult> Mypost()
        {
            string AppUser = _userManager.GetUserId(User);

            var appId = _context.Posting.Include(s => s.ApplicationUser).Where(s => s.ApplicationUserId == AppUser);
            return View(await appId.ToListAsync());
        }

        public async Task<IActionResult> PostApplications(int id)
        {

            var appId = _context.Posting.Include(s => s.JobApplications).Where(s => s.PostingId == id);
            return View(await appId.ToListAsync());
        }

        // GET: Postings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posting = await _context.Posting
                .Include(e => e.JobApplications)
                .SingleOrDefaultAsync(m => m.PostingId == id);
            if (posting == null)
            {
                return NotFound();
            }

            return View(posting);
        }

        // GET: Postings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Postings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostingId,JobTitle,JobLocation,Category,Requirements,NumberOfVolunteersNeeded,AgeRequirementFrom,AgeRequirementTo,State,DateOfPosting")] Posting posting)
        {
            if (ModelState.IsValid)
            {

                posting.ApplicationUserId = _userManager.GetUserId(User).ToString();
                _context.Add(posting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(posting);
        }

        // GET: Postings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posting = await _context.Posting.SingleOrDefaultAsync(m => m.PostingId == id);
            if (posting == null)
            {
                return NotFound();
            }
            return View(posting);
        }

        // POST: Postings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PostingId,JobTitle,JobLocation,Category,Requirements,NumberOfVolunteersNeeded,AgeRequirementFrom,AgeRequirementTo,State,DateOfPosting,ApplicationUserId")] Posting posting)
        {
            if (id != posting.PostingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(posting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostingExists(posting.PostingId))
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
            return View(posting);
        }

        // GET: Postings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var posting = await _context.Posting
                .SingleOrDefaultAsync(m => m.PostingId == id);
            if (posting == null)
            {
                return NotFound();
            }

            return View(posting);
        }

        // POST: Postings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var posting = await _context.Posting.SingleOrDefaultAsync(m => m.PostingId == id);
            _context.Posting.Remove(posting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostingExists(int id)
        {
            return _context.Posting.Any(e => e.PostingId == id);
        }
    }
}
