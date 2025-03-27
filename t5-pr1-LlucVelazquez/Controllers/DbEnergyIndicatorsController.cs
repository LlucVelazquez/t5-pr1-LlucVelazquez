using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using t5_pr1_LlucVelazquez.Data;
using t5_pr1_LlucVelazquez.Model;
using System.Diagnostics;
using System.Data;

namespace t5_pr1_LlucVelazquez.Controllers
{
    [Route("DbEnergyIndicators")]
    public class DbEnergyIndicatorsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public DbEnergyIndicatorsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: DbEnergyIndicators
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.EnergyIndicators.ToListAsync());
        }

        // GET: DbEnergyIndicators/Details/5
        [HttpGet]
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbEnergyIndicators = await _context.EnergyIndicators
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbEnergyIndicators == null)
            {
                return NotFound();
            }

            return View(dbEnergyIndicators);
        }

        // GET: DbEnergyIndicators/Create
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: DbEnergyIndicators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([Bind("Year,ProdNeta,ConsumGasoil,DemandaElectr,ProdDisp")] DbEnergyIndicator dbEnergyIndicator)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(dbEnergyIndicator);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DataException ex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(dbEnergyIndicator);
        }

        // GET:DbEnergyIndicator/Edit/5
        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbEnergyIndicator = await _context.EnergyIndicators.FindAsync(id);
            if (dbEnergyIndicator == null)
            {
                return NotFound();
            }
            return View(dbEnergyIndicator);
        }

        // POST: DbEnergyIndicator/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("Year,ProdNeta,ConsumGasoil,DemandaElectr,ProdDisp")] DbEnergyIndicator dbEnergyIndicator)
        {
            /*if (id != dbEnergyIndicator.Id)
            {
                return NotFound();
            }*/
            dbEnergyIndicator.Id = id;
			if (ModelState.IsValid)
            {
				try
                {
                    _context.Update(dbEnergyIndicator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
					if (!DbEnergyIndicatorExists(dbEnergyIndicator.Id))
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
            return View(dbEnergyIndicator);
        }

        // GET: DbEnergyIndicator/Delete/5
        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbEnergyIndicator = await _context.EnergyIndicators
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbEnergyIndicator == null)
            {
                return NotFound();
            }

            return View(dbEnergyIndicator);
        }

        // POST: DbEnergyIndicator/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dbEnergyIndicator = await _context.EnergyIndicators.FindAsync(id);
            if (dbEnergyIndicator != null)
            {
                _context.EnergyIndicators.Remove(dbEnergyIndicator);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbEnergyIndicatorExists(int id)
        {
            return _context.EnergyIndicators.Any(e => e.Id == id);
        }
    }
}
