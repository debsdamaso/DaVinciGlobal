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
    public class DadoTemperaturasController : Controller
    {
        private readonly OracleFIAPDbContext _context;

        public DadoTemperaturasController(OracleFIAPDbContext context)
        {
            _context = context;
        }

        // GET: DadoTemperaturas
        public async Task<IActionResult> Index()
        {
            var oracleFIAPDbContext = _context.DadosTemperatura.Include(d => d.Sensor);
            return View(await oracleFIAPDbContext.ToListAsync());
        }

        // GET: DadoTemperaturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadoTemperatura = await _context.DadosTemperatura
                .Include(d => d.Sensor)
                .FirstOrDefaultAsync(m => m.DadoTemperaturaId == id);
            if (dadoTemperatura == null)
            {
                return NotFound();
            }

            return View(dadoTemperatura);
        }

        // GET: DadoTemperaturas/Create
        public IActionResult Create()
        {
            ViewData["SensorId"] = new SelectList(_context.Sensores, "SensorId", "Localizacao");
            return View();
        }

        // POST: DadoTemperaturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DadoTemperaturaId,DataColeta,Temperatura,SensorId")] DadoTemperatura dadoTemperatura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dadoTemperatura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SensorId"] = new SelectList(_context.Sensores, "SensorId", "Localizacao", dadoTemperatura.SensorId);
            return View(dadoTemperatura);
        }

        // GET: DadoTemperaturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadoTemperatura = await _context.DadosTemperatura.FindAsync(id);
            if (dadoTemperatura == null)
            {
                return NotFound();
            }
            ViewData["SensorId"] = new SelectList(_context.Sensores, "SensorId", "Localizacao", dadoTemperatura.SensorId);
            return View(dadoTemperatura);
        }

        // POST: DadoTemperaturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DadoTemperaturaId,DataColeta,Temperatura,SensorId")] DadoTemperatura dadoTemperatura)
        {
            if (id != dadoTemperatura.DadoTemperaturaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dadoTemperatura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DadoTemperaturaExists(dadoTemperatura.DadoTemperaturaId))
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
            ViewData["SensorId"] = new SelectList(_context.Sensores, "SensorId", "Localizacao", dadoTemperatura.SensorId);
            return View(dadoTemperatura);
        }

        // GET: DadoTemperaturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dadoTemperatura = await _context.DadosTemperatura
                .Include(d => d.Sensor)
                .FirstOrDefaultAsync(m => m.DadoTemperaturaId == id);
            if (dadoTemperatura == null)
            {
                return NotFound();
            }

            return View(dadoTemperatura);
        }

        // POST: DadoTemperaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dadoTemperatura = await _context.DadosTemperatura.FindAsync(id);
            if (dadoTemperatura != null)
            {
                _context.DadosTemperatura.Remove(dadoTemperatura);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DadoTemperaturaExists(int id)
        {
            return _context.DadosTemperatura.Any(e => e.DadoTemperaturaId == id);
        }
    }
}
