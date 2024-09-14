using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoDeBloco_FimDeSemana.Data;
using ProjetoDeBloco_FimDeSemana.Models;

namespace ProjetoDeBloco_FimDeSemana.Controllers
{
    public class CardapioPersonalizadoesController : Controller
    {
        private readonly Contexto _context;

        public CardapioPersonalizadoesController(Contexto context)
        {
            _context = context;
        }

        // GET: CardapioPersonalizadoes
        public async Task<IActionResult> Index()
        {
            var contexto = _context.CardapiosPersonalizados.Include(c => c.Evento);
            return View(await contexto.ToListAsync());
        }

        // GET: CardapioPersonalizadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardapioPersonalizado = await _context.CardapiosPersonalizados
                .Include(c => c.Evento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cardapioPersonalizado == null)
            {
                return NotFound();
            }

            return View(cardapioPersonalizado);
        }

        // GET: CardapioPersonalizadoes/Create
        public IActionResult Create()
        {
            ViewData["EventoId"] = new SelectList(_context.Eventos, "Id", "Id");
            return View();
        }

        // POST: CardapioPersonalizadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId,EventoId")] CardapioPersonalizado cardapioPersonalizado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cardapioPersonalizado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventoId"] = new SelectList(_context.Eventos, "Id", "Id", cardapioPersonalizado.EventoId);
            return View(cardapioPersonalizado);
        }

        // GET: CardapioPersonalizadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardapioPersonalizado = await _context.CardapiosPersonalizados.FindAsync(id);
            if (cardapioPersonalizado == null)
            {
                return NotFound();
            }
            ViewData["EventoId"] = new SelectList(_context.Eventos, "Id", "Id", cardapioPersonalizado.EventoId);
            return View(cardapioPersonalizado);
        }

        // POST: CardapioPersonalizadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,EventoId")] CardapioPersonalizado cardapioPersonalizado)
        {
            if (id != cardapioPersonalizado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cardapioPersonalizado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardapioPersonalizadoExists(cardapioPersonalizado.Id))
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
            ViewData["EventoId"] = new SelectList(_context.Eventos, "Id", "Id", cardapioPersonalizado.EventoId);
            return View(cardapioPersonalizado);
        }

        // GET: CardapioPersonalizadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardapioPersonalizado = await _context.CardapiosPersonalizados
                .Include(c => c.Evento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cardapioPersonalizado == null)
            {
                return NotFound();
            }

            return View(cardapioPersonalizado);
        }

        // POST: CardapioPersonalizadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cardapioPersonalizado = await _context.CardapiosPersonalizados.FindAsync(id);
            if (cardapioPersonalizado != null)
            {
                _context.CardapiosPersonalizados.Remove(cardapioPersonalizado);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardapioPersonalizadoExists(int id)
        {
            return _context.CardapiosPersonalizados.Any(e => e.Id == id);
        }
    }
}
