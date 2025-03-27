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
    [Route("DbSimulations")]
    public class DbSimulationsController : Controller
    {
        private readonly ApplicationDBContext _context;

        public DbSimulationsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: DbSimulations
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Simulations.ToListAsync());
        }

        // GET: DbSimulations/Details/5
        [HttpGet]
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbSimulation = await _context.Simulations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbSimulation == null)
            {
                return NotFound();
            }

            return View(dbSimulation);
        }

        // GET: DbSimulations/Create
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: DbSimulations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([Bind("TypeSim,HoresSol,VelocitatVent,CabalAigua,Rati,EnergyGen,CostTotal,PreuTotal,DateT")] DbSimulation dbSimulation)
        {
            Debug.WriteLine("?:           ------------------------- Start Create Task");
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(dbSimulation);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DataException ex)
            {
                Debug.WriteLine("?: Data Exception: " + ex);
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(dbSimulation);
        }

        // GET: DbSimulations/Edit/5
        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbSimulation = await _context.Simulations.FindAsync(id);
            if (dbSimulation == null)
            {
                return NotFound();
            }
            return View(dbSimulation);
        }

        // POST: DbSimulations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("TypeSim,HoresSol,VelocitatVent,CabalAigua,Rati,EnergyGen,CostTotal,PreuTotal,DateT")] DbSimulation dbSimulation)
        {
            if (id != dbSimulation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dbSimulation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DbSimulationExists(dbSimulation.Id))
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
            return View(dbSimulation);
        }

        // GET: DbSimulations/Delete/5
        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbSimulation = await _context.Simulations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbSimulation == null)
            {
                return NotFound();
            }

            return View(dbSimulation);
        }

        // POST: DbSimulations/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dbSimulation = await _context.Simulations.FindAsync(id);
            if (dbSimulation != null)
            {
                _context.Simulations.Remove(dbSimulation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbSimulationExists(int id)
        {
            return _context.Simulations.Any(e => e.Id == id);
        }
    }
}
