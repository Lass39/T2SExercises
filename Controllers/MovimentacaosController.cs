using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcContainer.Data;
using MvcContainer.Models;

namespace T2SExercises.Controllers
{
    public class MovimentacaosController : Controller
    {
        private readonly MvcContainerContext _context;

        public MovimentacaosController(MvcContainerContext context)
        {
            _context = context;
        }

        // GET: Movimentacaos
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            var mvcContainerContext = from m in _context.Movimentacao.Include(m => m.Container).Include(m => m.Navio).Include(m => m.TipoMovimentacao) select m;

            ViewData["Container"] = String.IsNullOrEmpty(sortOrder) ? "Container" : "";
            ViewData["Navio"] = sortOrder == "Navio" ? "Navio_desc" : "Navio";
            ViewData["TipoMovimentacao"] = sortOrder == "TipoMovimentacao" ? "TipoMovimentacao_desc" : "TipoMovimentacao";
            ViewData["DataInicio"] = sortOrder == "DataInicio" ? "DataInicio_desc" : "DataInicio";
            ViewData["DataFim"] = sortOrder == "DataFim" ? "DataFim_desc" : "DataFim";

            switch (sortOrder)
            {
                case "Container":
                    mvcContainerContext = mvcContainerContext.OrderByDescending(s => s.Container);
                    break;


                case "Navio":
                    mvcContainerContext = mvcContainerContext.OrderBy(s => s.Navio);
                    break;

                case "Navio_desc":
                    mvcContainerContext = mvcContainerContext.OrderByDescending(s => s.Navio);
                    break;

                case "TipoMovimentacao":
                    mvcContainerContext = mvcContainerContext.OrderBy(s => s.TipoMovimentacao);
                    break;

                case "TipoMovimentacao_desc":
                    mvcContainerContext = mvcContainerContext.OrderByDescending(s => s.TipoMovimentacao);
                    break;

                case "DataInicio":
                    mvcContainerContext = mvcContainerContext.OrderBy(s => s.DataInicio);
                    break;

                case "DataInicio_desc":
                    mvcContainerContext = mvcContainerContext.OrderByDescending(s => s.DataInicio);
                    break;

                case "DataFim":
                    mvcContainerContext = mvcContainerContext.OrderBy(s => s.DataFim);
                    break;

                case "DataFim_desc":
                    mvcContainerContext = mvcContainerContext.OrderByDescending(s => s.DataFim);
                    break;



                default:
                    mvcContainerContext = mvcContainerContext.OrderBy(s => s.Container);
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                mvcContainerContext = mvcContainerContext.Where(s => s.Container.Nmr_control.Contains(searchString));
            }


            return View(await mvcContainerContext.ToListAsync());

        }

        // GET: Movimentacaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.Movimentacao
                .Include(m => m.Container)
                .Include(m => m.Navio)
                .Include(m => m.TipoMovimentacao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movimentacao == null)
            {
                return NotFound();
            }

            return View(movimentacao);
        }

        // GET: Movimentacaos/Create
        public IActionResult Create()
        {
            ViewData["Containerid"] = new SelectList(_context.Container, "Id", "Nmr_control");
            ViewData["Navioid"] = new SelectList(_context.Navio, "Id", "Nome_navio");
            ViewData["TipoMovimentacaoId"] = new SelectList(_context.TipoMovimentacao, "Id", "Tipo_movimentacao");
            return View();
        }

        // POST: Movimentacaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Containerid,Navioid,TipoMovimentacaoId,DataInicio,DataFim")] Movimentacao movimentacao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movimentacao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Containerid"] = new SelectList(_context.Container, "Id", "Nmr_control", movimentacao.Containerid);
            ViewData["Navioid"] = new SelectList(_context.Navio, "Id", "Nome_navio", movimentacao.Navioid);
            ViewData["TipoMovimentacaoId"] = new SelectList(_context.TipoMovimentacao, "Id", "Tipo_movimentacao", movimentacao.TipoMovimentacaoId);
            return View(movimentacao);
        }

        // GET: Movimentacaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.Movimentacao.FindAsync(id);
            if (movimentacao == null)
            {
                return NotFound();
            }
            ViewData["Containerid"] = new SelectList(_context.Container, "Id", "Nmr_control", movimentacao.Containerid);
            ViewData["Navioid"] = new SelectList(_context.Navio, "Id", "Nome_navio", movimentacao.Navioid);
            ViewData["TipoMovimentacaoId"] = new SelectList(_context.TipoMovimentacao, "Id", "Tipo_movimentacao", movimentacao.TipoMovimentacaoId);
            return View(movimentacao);
        }

        // POST: Movimentacaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Containerid,Navioid,TipoMovimentacaoId,DataInicio,DataFim")] Movimentacao movimentacao)
        {
            if (id != movimentacao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimentacao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimentacaoExists(movimentacao.Id))
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
            ViewData["Containerid"] = new SelectList(_context.Container, "Id", "Id", movimentacao.Containerid);
            ViewData["Navioid"] = new SelectList(_context.Navio, "Id", "Id", movimentacao.Navioid);
            ViewData["TipoMovimentacaoId"] = new SelectList(_context.TipoMovimentacao, "Id", "Id", movimentacao.TipoMovimentacaoId);
            return View(movimentacao);
        }

        // GET: Movimentacaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacao = await _context.Movimentacao
                .Include(m => m.Container)
                .Include(m => m.Navio)
                .Include(m => m.TipoMovimentacao)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movimentacao == null)
            {
                return NotFound();
            }

            return View(movimentacao);
        }

        // POST: Movimentacaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movimentacao = await _context.Movimentacao.FindAsync(id);
            _context.Movimentacao.Remove(movimentacao);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimentacaoExists(int id)
        {
            return _context.Movimentacao.Any(e => e.Id == id);
        }
    }
}
