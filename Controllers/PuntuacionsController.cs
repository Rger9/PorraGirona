using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PorraGirona.DataLayer;

namespace PorraGirona.Controllers
{
    public class PuntuacionsController : Controller
    {
        //private readonly PostDbContext _context;

        //public PuntuacionsController(PostDbContext context)
        //{
        //    _context = context;
        //}

        PostDbContext _context;
        public PuntuacionsController()
        {
            _context = new PostDbContext();
        }

        // GET: Puntuacions
        public async Task<IActionResult> Index()
        {
            return View(await _context.puntuacions.ToListAsync());
        }

        // GET: Puntuacions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puntuacions = await _context.puntuacions
                .FirstOrDefaultAsync(m => m.idpuntuacio == id);
            if (puntuacions == null)
            {
                return NotFound();
            }

            return View(puntuacions);
        }

        // GET: Puntuacions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Puntuacions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idpuntuacio,idpenyista,alias,puntuacio,temporada")] puntuacions puntuacions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(puntuacions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(puntuacions);
        }

        // GET: Puntuacions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puntuacions = await _context.puntuacions.FindAsync(id);
            if (puntuacions == null)
            {
                return NotFound();
            }
            return View(puntuacions);
        }

        // POST: Puntuacions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idpuntuacio,idpenyista,alias,puntuacio,temporada")] puntuacions puntuacions)
        {
            if (id != puntuacions.idpuntuacio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(puntuacions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!puntuacionsExists(puntuacions.idpuntuacio))
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
            return View(puntuacions);
        }

        // GET: Puntuacions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var puntuacions = await _context.puntuacions
                .FirstOrDefaultAsync(m => m.idpuntuacio == id);
            if (puntuacions == null)
            {
                return NotFound();
            }

            return View(puntuacions);
        }

        // POST: Puntuacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var puntuacions = await _context.puntuacions.FindAsync(id);
            if (puntuacions != null)
            {
                _context.puntuacions.Remove(puntuacions);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool puntuacionsExists(int id)
        {
            return _context.puntuacions.Any(e => e.idpuntuacio == id);
        }
    }
}
