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
    public class GerenciaReservasController : Controller
    {
        private readonly Contexto _context;

        public GerenciaReservasController(Contexto context)
        {
            _context = context;
        }

        // GET: GerenciaReservas
        public async Task<IActionResult> Index()
        {
            var contexto = _context.Reservas.Include(g => g.Usuario);
            return View(await contexto.ToListAsync());
        }

        // GET: GerenciaReservas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerenciaReserva = await _context.Reservas
                .Include(g => g.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gerenciaReserva == null)
            {
                return NotFound();
            }

            return View(gerenciaReserva);
        }

        // GET: GerenciaReservas/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id");
            return View();
        }

        // POST: GerenciaReservas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId")] GerenciaReserva gerenciaReserva)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gerenciaReserva);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", gerenciaReserva.UsuarioId);
            return View(gerenciaReserva);
        }

        // GET: GerenciaReservas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerenciaReserva = await _context.Reservas.FindAsync(id);
            if (gerenciaReserva == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", gerenciaReserva.UsuarioId);
            return View(gerenciaReserva);
        }

        // POST: GerenciaReservas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId")] GerenciaReserva gerenciaReserva)
        {
            if (id != gerenciaReserva.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gerenciaReserva);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GerenciaReservaExists(gerenciaReserva.Id))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Id", gerenciaReserva.UsuarioId);
            return View(gerenciaReserva);
        }

        // GET: GerenciaReservas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerenciaReserva = await _context.Reservas
                .Include(g => g.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gerenciaReserva == null)
            {
                return NotFound();
            }

            return View(gerenciaReserva);
        }

        // POST: GerenciaReservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gerenciaReserva = await _context.Reservas.FindAsync(id);
            if (gerenciaReserva != null)
            {
                _context.Reservas.Remove(gerenciaReserva);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GerenciaReservaExists(int id)
        {
            return _context.Reservas.Any(e => e.Id == id);
        }
    }
}
