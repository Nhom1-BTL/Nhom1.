using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NHOM1.Models;
using NHOM1.Data;

namespace NHOM1.Controllers
{
    public class QuanLyNVController : Controller
    {
        private readonly MvcBigContext _context;

        public QuanLyNVController(MvcBigContext context)
        {
            _context = context;
        }

        // GET: QuanLyNV
        public async Task<IActionResult> Index()
        {
            return View(await _context.QuanLyNV.ToListAsync());
        }

        // GET: QuanLyNV/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanLyNV = await _context.QuanLyNV
                .FirstOrDefaultAsync(m => m.MaNV == id);
            if (quanLyNV == null)
            {
                return NotFound();
            }

            return View(quanLyNV);
        }

        // GET: QuanLyNV/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuanLyNV/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNV,TenNV,GioiTinh,Diachi,Sodienthoai")] QuanLyNV quanLyNV)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quanLyNV);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quanLyNV);
        }

        // GET: QuanLyNV/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanLyNV = await _context.QuanLyNV.FindAsync(id);
            if (quanLyNV == null)
            {
                return NotFound();
            }
            return View(quanLyNV);
        }

        // POST: QuanLyNV/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaNV,TenNV,GioiTinh,Diachi,Sodienthoai")] QuanLyNV quanLyNV)
        {
            if (id != quanLyNV.MaNV)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quanLyNV);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuanLyNVExists(quanLyNV.MaNV))
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
            return View(quanLyNV);
        }

        // GET: QuanLyNV/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanLyNV = await _context.QuanLyNV
                .FirstOrDefaultAsync(m => m.MaNV == id);
            if (quanLyNV == null)
            {
                return NotFound();
            }

            return View(quanLyNV);
        }

        // POST: QuanLyNV/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var quanLyNV = await _context.QuanLyNV.FindAsync(id);
            _context.QuanLyNV.Remove(quanLyNV);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuanLyNVExists(string id)
        {
            return _context.QuanLyNV.Any(e => e.MaNV == id);
        }
    }
}
