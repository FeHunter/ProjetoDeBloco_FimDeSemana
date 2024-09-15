using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoDeBloco_FimDeSemana.Data;
using ProjetoDeBloco_FimDeSemana.Models;

namespace ProjetoDeBloco_FimDeSemana.Controllers
{
    public class ItemCardapiosController : Controller
    {
        private readonly Contexto _context;

        public ItemCardapiosController(Contexto context)
        {
            _context = context;
        }

        // GET: ItemCardapios
        public async Task<IActionResult> Index()
        {
            var contexto = _context.ItensDoCardapio
                .Include(i => i.Cardapio) 
                .ThenInclude(c => c.Evento); 
            return View(await contexto.ToListAsync());
        }

        // GET: ItemCardapios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemCardapio = await _context.ItensDoCardapio
                .Include(i => i.Cardapio)
                .ThenInclude(c => c.Evento) 
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemCardapio == null)
            {
                return NotFound();
            }

            return View(itemCardapio);
        }

        // GET: ItemCardapios/Create
        public IActionResult Create()
        {
            ViewData["CardapioId"] = new SelectList(
                _context.Cardapios
                .Include(c => c.Evento)
                .Select(c => new {
                    Id = c.Id,
                    NomeEvento = c.Evento.Titulo 
                }),
                "Id",
                "NomeEvento"
            );
            return View();
        }

        // POST: ItemCardapios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CardapioId,Nome,Quantidade,Preco,ValorTotal")] ItemCardapio itemCardapio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itemCardapio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CardapioId"] = new SelectList(_context.Cardapios, "Id", "Id", itemCardapio.CardapioId);
            return View(itemCardapio);
        }

        // GET: ItemCardapios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemCardapio = await _context.ItensDoCardapio
                .Include(i => i.Cardapio) 
                .ThenInclude(c => c.Evento) 
                .FirstOrDefaultAsync(i => i.Id == id);
            if (itemCardapio == null)
            {
                return NotFound();
            }

            // Cria a lista de Cardapios com o nome do Evento
            var cardapios = await _context.Cardapios
                .Include(c => c.Evento) 
                .Select(c => new {
                    c.Id,
                    NomeEvento = c.Evento.Titulo 
                })
                .ToListAsync();

            ViewData["CardapioId"] = new SelectList(cardapios, "Id", "NomeEvento", itemCardapio.CardapioId);

            return View(itemCardapio);
        }

        // POST: ItemCardapios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CardapioId,Nome,Quantidade,Preco,ValorTotal")] ItemCardapio itemCardapio)
        {
            if (id != itemCardapio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itemCardapio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemCardapioExists(itemCardapio.Id))
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
            ViewData["CardapioId"] = new SelectList(_context.Cardapios, "Id", "Id", itemCardapio.CardapioId);
            return View(itemCardapio);
        }

        // GET: ItemCardapios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemCardapio = await _context.ItensDoCardapio
                .Include(i => i.Cardapio)
                .ThenInclude(c => c.Evento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itemCardapio == null)
            {
                return NotFound();
            }

            return View(itemCardapio);
        }

        // POST: ItemCardapios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemCardapio = await _context.ItensDoCardapio.FindAsync(id);
            if (itemCardapio != null)
            {
                _context.ItensDoCardapio.Remove(itemCardapio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemCardapioExists(int id)
        {
            return _context.ItensDoCardapio.Any(e => e.Id == id);
        }
    }
}
