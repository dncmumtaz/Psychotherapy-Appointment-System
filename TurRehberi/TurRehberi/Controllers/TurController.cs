using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TurRehberi.Data;
using TurRehberi.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace TurRehberi.Controllers
{
    [Authorize]
    public class TurController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _hostingEnvironment;

        public TurController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Tur
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tur.ToListAsync());
        }

        // GET: Tur/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Tur = await _context.Tur
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Tur == null)
            {
                return NotFound();
            }

            return View(Tur);
        }

        // GET: Tur/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tur/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TurAdi,Aciklama,Sehir,Tip,Fiyat,Ulasim,Puan,Fotograf")] Tur Tur)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;


                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images/Tur/");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                Tur.Fotograf = @"/images/Tur/" + fileName + extension;

                _context.Add(Tur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Tur);
        }

        // GET: Tur/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Tur = await _context.Tur.FindAsync(id);
            if (Tur == null)
            {
                return NotFound();
            }
            return View(Tur);
        }

        // POST: Tur/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TurAdi,Aciklama,Sehir,Tip,Fiyat,Ulasim,Puan,Fotograf")] Tur Tur)
        {
            if (id != Tur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Tur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurExists(Tur.Id))
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
            return View(Tur);
        }

        // GET: Tur/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Tur = await _context.Tur
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Tur == null)
            {
                return NotFound();
            }

            return View(Tur);
        }

        // POST: Tur/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Tur = await _context.Tur.FindAsync(id);
            _context.Tur.Remove(Tur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurExists(int id)
        {
            return _context.Tur.Any(e => e.Id == id);
        }
    }
}
