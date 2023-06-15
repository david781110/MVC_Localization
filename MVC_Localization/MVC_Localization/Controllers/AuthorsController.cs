using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_Localization.Models;

namespace MVC_Localization.Controllers
{
    public class AuthorsController : BaseController
    {
        private readonly pubsContext _context;

        public AuthorsController(pubsContext context)
        {
            _context = context;
        }

        // GET: Authors
        public async Task<IActionResult> Index()
        {
              return _context.Authors != null ? 
                          View(await _context.Authors.ToListAsync()) :
                          Problem("Entity set 'pubsContext.Authors'  is null.");
        }

        // GET: Authors/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var authors = await _context.Authors
                .FirstOrDefaultAsync(m => m.AuId == id);
            if (authors == null)
            {
                return NotFound();
            }

            return View(authors);
        }

        // GET: Authors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuId,AuLname,AuFname,Phone,Address,City,State,Zip,Contract")] Authors authors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(authors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(authors);
        }

        // GET: Authors/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var authors = await _context.Authors.FindAsync(id);
            if (authors == null)
            {
                return NotFound();
            }
            return View(authors);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("AuId,AuLname,AuFname,Phone,Address,City,State,Zip,Contract")] Authors authors)
        {
            if (id != authors.AuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(authors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorsExists(authors.AuId))
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
            return View(authors);
        }

        // GET: Authors/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Authors == null)
            {
                return NotFound();
            }

            var authors = await _context.Authors
                .FirstOrDefaultAsync(m => m.AuId == id);
            if (authors == null)
            {
                return NotFound();
            }

            return View(authors);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Authors == null)
            {
                return Problem("Entity set 'pubsContext.Authors'  is null.");
            }
            var authors = await _context.Authors.FindAsync(id);
            if (authors != null)
            {
                _context.Authors.Remove(authors);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorsExists(string id)
        {
          return (_context.Authors?.Any(e => e.AuId == id)).GetValueOrDefault();
        }
    }
}
