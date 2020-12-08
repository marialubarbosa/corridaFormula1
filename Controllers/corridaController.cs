using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using corridaFormula1.Data;
using corridaFormula1.Models;

namespace corridaFormula1.Controllers
{
    public class corridaController : Controller
    {
        private readonly corridaFormula1Context _context;

        public corridaController(corridaFormula1Context context)
        {
            _context = context;
        }

        // GET: corrida
        public async Task<IActionResult> Index()
        {
            return View(await _context.corrida.ToListAsync());
        }

        // GET: corrida/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corrida = await _context.corrida
                .FirstOrDefaultAsync(m => m.id == id);
            if (corrida == null)
            {
                return NotFound();
            }

            return View(corrida);
        }

        // GET: corrida/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: corrida/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,piloto,equipe,posicao")] corrida corrida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(corrida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(corrida);
        }

        // GET: corrida/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corrida = await _context.corrida.FindAsync(id);
            if (corrida == null)
            {
                return NotFound();
            }
            return View(corrida);
        }

        // POST: corrida/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,piloto,equipe,posicao")] corrida corrida)
        {
            if (id != corrida.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(corrida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!corridaExists(corrida.id))
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
            return View(corrida);
        }

        // GET: corrida/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var corrida = await _context.corrida
                .FirstOrDefaultAsync(m => m.id == id);
            if (corrida == null)
            {
                return NotFound();
            }

            return View(corrida);
        }

        // POST: corrida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var corrida = await _context.corrida.FindAsync(id);
            _context.corrida.Remove(corrida);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool corridaExists(int id)
        {
            return _context.corrida.Any(e => e.id == id);
        }
    }
}
