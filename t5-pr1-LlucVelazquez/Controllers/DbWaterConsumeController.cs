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
    [Route("DbWaterConsume")]
    public class DbWaterConsumeController : Controller
    {
        private readonly ApplicationDBContext _context;

        public DbWaterConsumeController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: DbWaterConsume
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.WaterConsumes.ToListAsync());
        }

        // GET: DbWaterConsume/Details/5
        [HttpGet]
        [Route("Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbWaterConsume = await _context.WaterConsumes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbWaterConsume == null)
            {
                return NotFound();
            }

            return View(dbWaterConsume);
        }

        // GET: DbWaterConsume/Create
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: DbWaterConsume/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([Bind("Region,Town,Year,Consume")] DbWaterConsume dbWaterConsume)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(dbWaterConsume);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DataException ex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(dbWaterConsume);
        }

        // GET:DbWaterConsume/Edit/5
        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbWaterConsume = await _context.WaterConsumes.FindAsync(id);
            if (dbWaterConsume == null)
            {
                return NotFound();
            }
            return View(dbWaterConsume);
        }

        // POST: DbWaterConsume/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("Region,Town,Year,Consume")] DbWaterConsume dbWaterConsume)
        {
            /*if (id != dbWaterConsume.Id)
            {
                return NotFound();
            }*/
            dbWaterConsume.Id = id;
			if (ModelState.IsValid)
            {
				try
                {
                    _context.Update(dbWaterConsume);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
					if (!DbWaterConsumeExists(dbWaterConsume.Id))
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
            return View(dbWaterConsume);
        }

        // GET: DbWaterConsume/Delete/5
        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dbWaterConsume = await _context.WaterConsumes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dbWaterConsume == null)
            {
                return NotFound();
            }

            return View(dbWaterConsume);
        }

        // POST: DbWaterConsume/Delete/5
        [HttpPost, ActionName("Delete")]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dbWaterConsume = await _context.WaterConsumes.FindAsync(id);
            if (dbWaterConsume != null)
            {
                _context.WaterConsumes.Remove(dbWaterConsume);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DbWaterConsumeExists(int id)
        {
            return _context.WaterConsumes.Any(e => e.Id == id);
        }
    }
}
