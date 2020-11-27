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
    using MvcContainer.Models;
    public class ContainersController : Controller
    {
        private readonly MvcContainerContext _context;

        public ContainersController(MvcContainerContext context)
        {
            _context = context;
        }

        // GET: Containers
        public async Task<IActionResult> Index(string sortOrder,string searchString)
        {
            var mvcContainerContext = from m in _context.Container.Include(c => c.CategoriaContainer).Include(c => c.Client).Include(c => c.StatusContainer).Include(c => c.TipoContainer) select m;

            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "NameSortParm" : "";
            ViewData["Nmr_control"] = sortOrder == "Nmr_control" ? "Nmr_control_desc" : "Nmr_control";
            ViewData["TipoContainer"] = sortOrder == "TipoContainer" ? "TipoContainer_desc" : "TipoContainer";
            ViewData["StatusContainer"] = sortOrder == "StatusContainer" ? "StatusContainer_desc" : "StatusContainer";
            ViewData["CategoriaContainer"] = sortOrder == "CategoriaContainer" ? "CategoriaContainer_desc" : "CategoriaContainer";


            switch (sortOrder)
            {
                case "NameSortParm":
                    mvcContainerContext = mvcContainerContext.OrderByDescending(s => s.Client);
                    break;


                case "Nmr_control":
                    mvcContainerContext = mvcContainerContext.OrderBy(s => s.Nmr_control);
                    break;

                case "Nmr_control_desc":
                    mvcContainerContext = mvcContainerContext.OrderByDescending(s => s.Nmr_control);
                    break;

                case "TipoContainer":
                    mvcContainerContext = mvcContainerContext.OrderBy(s => s.TipoContainer);
                    break;

                case "TipoContainer_desc":
                    mvcContainerContext = mvcContainerContext.OrderByDescending(s => s.TipoContainer);
                    break;

                case "StatusContainer":
                    mvcContainerContext = mvcContainerContext.OrderBy(s => s.StatusContainer);
                    break;

                case "StatusContainer_desc":
                    mvcContainerContext = mvcContainerContext.OrderByDescending(s => s.StatusContainer);
                    break;

                case "CategoriaContainer":
                    mvcContainerContext = mvcContainerContext.OrderBy(s => s.CategoriaContainer);
                    break;

                case "CategoriaContainer_desc":
                    mvcContainerContext = mvcContainerContext.OrderByDescending(s => s.CategoriaContainer);
                    break;



                default:
                    mvcContainerContext = mvcContainerContext.OrderBy(s => s.Client);
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                mvcContainerContext = mvcContainerContext.Where(s => s.Nmr_control.Contains(searchString));
            }


            return View(await mvcContainerContext.ToListAsync());
        }
        public async Task<IActionResult> Relatorio(string searchString)
        {
            var mvcContainerContext = from m in _context.Container.Include(c => c.CategoriaContainer).Include(c => c.Client).Include(c => c.StatusContainer).Include(c => c.TipoContainer) select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                mvcContainerContext = mvcContainerContext.Where(s => s.Nmr_control.Contains(searchString));
            }


            return View(await mvcContainerContext.ToListAsync());
        }
        public async Task<IActionResult> IndexT(string searchString)
        {
            var mvcContainerContext = from m in _context.Container.Include(c => c.CategoriaContainer).Include(c => c.Client).Include(c => c.StatusContainer).Include(c => c.TipoContainer) select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                mvcContainerContext = mvcContainerContext.Where(s => s.Nmr_control.Contains(searchString));
            }


            return View(await mvcContainerContext.ToListAsync());
        }

        // GET: Containers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var container = await _context.Container
                .Include(c => c.CategoriaContainer)
                .Include(c => c.Client)
                .Include(c => c.StatusContainer)
                .Include(c => c.TipoContainer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (container == null)
            {
                return NotFound();
            }

            return View(container);
        }

        // GET: Containers/Create
        public IActionResult Create()
        {
            ViewData["CategoriaContainerId"] = new SelectList(_context.CategoriaContainer, "Id", "CategoriaName");
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Nome_cliente");
            ViewData["StatusContainerId"] = new SelectList(_context.StatusContainer, "Id", "Status_name");
            ViewData["TipoContainerId"] = new SelectList(_context.TipoContainer, "Id", "Tipo_container");
            return View();
        }

        // POST: Containers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClientId,Nmr_control,TipoContainerId,StatusContainerId,CategoriaContainerId")] Container container)
        {
            if (ModelState.IsValid)
            {
                _context.Add(container);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaContainerId"] = new SelectList(_context.CategoriaContainer, "Id", "Id", container.CategoriaContainerId);
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Id", container.ClientId);
            ViewData["StatusContainerId"] = new SelectList(_context.StatusContainer, "Id", "Id", container.StatusContainerId);
            ViewData["TipoContainerId"] = new SelectList(_context.TipoContainer, "Id", "Id", container.TipoContainerId);
            return View(container);
        }

        // GET: Containers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var container = await _context.Container.FindAsync(id);
            if (container == null)
            {
                return NotFound();
            }
            ViewData["CategoriaContainerId"] = new SelectList(_context.CategoriaContainer, "Id", "CategoriaName");
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Nome_cliente");
            ViewData["StatusContainerId"] = new SelectList(_context.StatusContainer, "Id", "Status_name");
            ViewData["TipoContainerId"] = new SelectList(_context.TipoContainer, "Id", "Tipo_container");
            return View(container);
        }

        // POST: Containers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientId,Nmr_control,TipoContainerId,StatusContainerId,CategoriaContainerId")] Container container)
        {
            if (id != container.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(container);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContainerExists(container.Id))
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
            ViewData["CategoriaContainerId"] = new SelectList(_context.CategoriaContainer, "Id", "Id", container.CategoriaContainerId);
            ViewData["ClientId"] = new SelectList(_context.Client, "Id", "Id", container.ClientId);
            ViewData["StatusContainerId"] = new SelectList(_context.StatusContainer, "Id", "Id", container.StatusContainerId);
            ViewData["TipoContainerId"] = new SelectList(_context.TipoContainer, "Id", "Id", container.TipoContainerId);
            return View(container);
        }

        // GET: Containers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var container = await _context.Container
                .Include(c => c.CategoriaContainer)
                .Include(c => c.Client)
                .Include(c => c.StatusContainer)
                .Include(c => c.TipoContainer)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (container == null)
            {
                return NotFound();
            }

            return View(container);
        }

        // POST: Containers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var container = await _context.Container.FindAsync(id);
            _context.Container.Remove(container);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContainerExists(int id)
        {
            return _context.Container.Any(e => e.Id == id);
        }
    }
}
