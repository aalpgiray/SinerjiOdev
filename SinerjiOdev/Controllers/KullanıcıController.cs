using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SinerjiOdev.Models;

namespace SinerjiOdev.Controllers
{
    public class KullanıcıController : Controller
    {
        private readonly DatabaseContext _context;

        public KullanıcıController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Kullanıcı
        public async Task<IActionResult> Index()
        {
            return View(await _context.Kullanıcılar.ToListAsync());
        }

        // GET: Kullanıcı/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kullanıcı = await _context.Kullanıcılar
                .SingleOrDefaultAsync(m => m.KullanıcıId == id);
            if (kullanıcı == null)
            {
                return NotFound();
            }

            return View(kullanıcı);
        }

        // GET: Kullanıcı/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kullanıcı/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KullanıcıId,KullaniciAdi,Adi,SoyAdi,Sifre")] Kullanıcı kullanıcı)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kullanıcı);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kullanıcı);
        }

        // GET: Kullanıcı/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kullanıcı = await _context.Kullanıcılar.SingleOrDefaultAsync(m => m.KullanıcıId == id);
            if (kullanıcı == null)
            {
                return NotFound();
            }
            return View(kullanıcı);
        }

        // POST: Kullanıcı/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KullanıcıId,KullaniciAdi,Adi,SoyAdi,Sifre")] Kullanıcı kullanıcı)
        {
            if (id != kullanıcı.KullanıcıId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    _context.Update(kullanıcı);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KullanıcıExists(kullanıcı.KullanıcıId))
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
            return View(kullanıcı);
        }

        // GET: Kullanıcı/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kullanıcı = await _context.Kullanıcılar
                .SingleOrDefaultAsync(m => m.KullanıcıId == id);
            if (kullanıcı == null)
            {
                return NotFound();
            }

            return View(kullanıcı);
        }

        // POST: Kullanıcı/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kullanıcı = await _context.Kullanıcılar.SingleOrDefaultAsync(m => m.KullanıcıId == id);
            _context.Kullanıcılar.Remove(kullanıcı);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KullanıcıExists(int id)
        {
            return _context.Kullanıcılar.Any(e => e.KullanıcıId == id);
        }
    }
}
