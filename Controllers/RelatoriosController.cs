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
    public class RelatoriosController : Controller
    {
        private readonly OracleFIAPDbContext _context;

        public RelatoriosController(OracleFIAPDbContext context)
        {
            _context = context;
        }

        // GET: Relatorios
        public async Task<IActionResult> Index()
        {
            var oracleFIAPDbContext = _context.Relatorios.Include(r => r.Sensor);
            return View(await oracleFIAPDbContext.ToListAsync());
        }

        // GET: Relatorios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorio = await _context.Relatorios
                .Include(r => r.Sensor)
                .FirstOrDefaultAsync(m => m.RelatorioId == id);
            if (relatorio == null)
            {
                return NotFound();
            }

            return View(relatorio);
        }

        // GET: Relatorios/Create
        public IActionResult Create()
        {
            ViewData["SensorId"] = new SelectList(_context.Sensores, "SensorId", "Localizacao");
            return View();
        }

        // POST: Relatorios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RelatorioId,DataInicio,DataFim,Localizacao,TemperaturaMaxima,TemperaturaMedia,TemperaturaMinima,SensorId")] Relatorio relatorio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relatorio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SensorId"] = new SelectList(_context.Sensores, "SensorId", "Localizacao", relatorio.SensorId);
            return View(relatorio);
        }

        // GET: Relatorios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorio = await _context.Relatorios.FindAsync(id);
            if (relatorio == null)
            {
                return NotFound();
            }
            ViewData["SensorId"] = new SelectList(_context.Sensores, "SensorId", "Localizacao", relatorio.SensorId);
            return View(relatorio);
        }

        // POST: Relatorios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RelatorioId,DataInicio,DataFim,Localizacao,TemperaturaMaxima,TemperaturaMedia,TemperaturaMinima,SensorId")] Relatorio relatorio)
        {
            if (id != relatorio.RelatorioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(relatorio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RelatorioExists(relatorio.RelatorioId))
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
            ViewData["SensorId"] = new SelectList(_context.Sensores, "SensorId", "Localizacao", relatorio.SensorId);
            return View(relatorio);
        }

        // GET: Relatorios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var relatorio = await _context.Relatorios
                .Include(r => r.Sensor)
                .FirstOrDefaultAsync(m => m.RelatorioId == id);
            if (relatorio == null)
            {
                return NotFound();
            }

            return View(relatorio);
        }

        // POST: Relatorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var relatorio = await _context.Relatorios.FindAsync(id);
            if (relatorio != null)
            {
                _context.Relatorios.Remove(relatorio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RelatorioExists(int id)
        {
            return _context.Relatorios.Any(e => e.RelatorioId == id);
        }
    }
}
