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
    public class CardapiosController : Controller
    {
        private readonly Contexto _context;

        public CardapiosController(Contexto context)
        {
            _context = context;
        }

        // GET: Cardapios
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Cardapios.Include(c => c.Evento);
            return View(await contexto.ToListAsync());
        }

        // GET: Cardapios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardapio = await _context.Cardapios
                .Include(c => c.Evento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cardapio == null)
            {
                return NotFound();
            }

            return View(cardapio);
        }

        // GET: Cardapios/Create
        public IActionResult Create()
        {
            ViewData["EventoId"] = new SelectList(
                _context.Eventos.Select(e => new {
                    Id = e.Id,
                    Nome = e.Titulo
                }),
                "Id",
                "Nome"
            );
            return View();
        }

        // POST: Cardapios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EventoId")] Cardapio cardapio)
        {
            if (ModelState.IsValid)
            {
                // Verifica se já existe um Cardapio com o mesmo EventoId
                var existente = await _context.Cardapios
                    .AnyAsync(c => c.EventoId == cardapio.EventoId);

                if (existente)
                {
                    // Adiciona um erro ao ModelState e retorna à view
                    ModelState.AddModelError("EventoId", "Já existe um cardápio para este evento.");
                }
                else
                {
                    _context.Add(cardapio);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["EventoId"] = new SelectList(
                _context.Eventos.Select(e => new {
                    Id = e.Id,
                    Nome = e.Titulo
                }),
                "Id",
                "Nome",
                cardapio.EventoId
            );
            return View(cardapio);
        }


        // GET: Cardapios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardapio = await _context.Cardapios.FindAsync(id);
            if (cardapio == null)
            {
                return NotFound();
            }
            ViewData["EventoId"] = new SelectList(_context.Eventos, "Id", "Id", cardapio.EventoId);
            return View(cardapio);
        }

        // POST: Cardapios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EventoId")] Cardapio cardapio)
        {
            if (id != cardapio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cardapio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardapioExists(cardapio.Id))
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
            ViewData["EventoId"] = new SelectList(_context.Eventos, "Id", "Id", cardapio.EventoId);
            return View(cardapio);
        }

        // GET: Cardapios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardapio = await _context.Cardapios
                .Include(c => c.Evento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cardapio == null)
            {
                return NotFound();
            }

            return View(cardapio);
        }

        // POST: Cardapios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cardapio = await _context.Cardapios.FindAsync(id);
            if (cardapio != null)
            {
                _context.Cardapios.Remove(cardapio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardapioExists(int id)
        {
            return _context.Cardapios.Any(e => e.Id == id);
        }
    }
}
