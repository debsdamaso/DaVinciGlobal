using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DaVinciGlobal.Models;
using DaVinciGlobal.Persistencia;

namespace DaVinciGlobal.Controllers
{
    public class ImagemCoraisController : Controller
    {
        private readonly OracleFIAPDbContext _context;

        public ImagemCoraisController(OracleFIAPDbContext context)
        {
            _context = context;
        }

        // GET: ImagemCorais
        public async Task<IActionResult> Index()
        {
            var oracleFIAPDbContext = _context.ImagensCorais.Include(i => i.Usuario);
            return View(await oracleFIAPDbContext.ToListAsync());
        }

        // GET: ImagemCorais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagemCoral = await _context.ImagensCorais
                .Include(i => i.Usuario)
                .FirstOrDefaultAsync(m => m.ImagemCoralId == id);
            if (imagemCoral == null)
            {
                return NotFound();
            }

            return View(imagemCoral);
        }

        // GET: ImagemCorais/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email");
            return View();
        }

        // POST: ImagemCorais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImagemCoralId,CaminhoImagem,Localizacao,DataEnvio,EstadoCoral,UsuarioId")] ImagemCoral imagemCoral)
        {
            if (ModelState.IsValid)
            {
                _context.Add(imagemCoral);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email", imagemCoral.UsuarioId);
            return View(imagemCoral);
        }

        // GET: ImagemCorais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagemCoral = await _context.ImagensCorais.FindAsync(id);
            if (imagemCoral == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email", imagemCoral.UsuarioId);
            return View(imagemCoral);
        }

        // POST: ImagemCorais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImagemCoralId,CaminhoImagem,Localizacao,DataEnvio,EstadoCoral,UsuarioId")] ImagemCoral imagemCoral)
        {
            if (id != imagemCoral.ImagemCoralId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(imagemCoral);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImagemCoralExists(imagemCoral.ImagemCoralId))
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
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email", imagemCoral.UsuarioId);
            return View(imagemCoral);
        }

        // GET: ImagemCorais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imagemCoral = await _context.ImagensCorais
                .Include(i => i.Usuario)
                .FirstOrDefaultAsync(m => m.ImagemCoralId == id);
            if (imagemCoral == null)
            {
                return NotFound();
            }

            return View(imagemCoral);
        }

        // POST: ImagemCorais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var imagemCoral = await _context.ImagensCorais.FindAsync(id);
            if (imagemCoral != null)
            {
                _context.ImagensCorais.Remove(imagemCoral);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImagemCoralExists(int id)
        {
            return _context.ImagensCorais.Any(e => e.ImagemCoralId == id);
        }
    }
}
