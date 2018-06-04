using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IVolunteer.Data;
using IVolunteer.Models.ProjectModel;

namespace IVolunteer.Controllers
{
    public class PostingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Postings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Posting.ToListAsync());
        }

        // GET: Postings/Details/5
        public async Task<IActionResult> Details(int? id)
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
        public async Task<IActionResult> Create([Bind("PostingId,ProfileId,JobTitle,JobLocation,Category,Requirements,NumberOfVolunteersNeeded,AgeRequirementFrom,AgeRequirementTo,State")] Posting posting)
        {
            if (ModelState.IsValid)
            {
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
        public async Task<IActionResult> Edit(int id, [Bind("PostingId,ProfileId,JobTitle,JobLocation,Category,Requirements,NumberOfVolunteersNeeded,AgeRequirementFrom,AgeRequirementTo,State")] Posting posting)
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
