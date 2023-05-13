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
    public class QuanLyNguonHangController : Controller
    {
        private readonly MvcBigContext _context;

        public QuanLyNguonHangController(MvcBigContext context)
        {
            _context = context;
        }

        // GET: QuanLyNguonHang
        public async Task<IActionResult> Index()
        {
            return View(await _context.QuanLyNguonHang.ToListAsync());
        }

        // GET: QuanLyNguonHang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanLyNguonHang = await _context.QuanLyNguonHang
                .FirstOrDefaultAsync(m => m.MaSanPham == id);
            if (quanLyNguonHang == null)
            {
                return NotFound();
            }

            return View(quanLyNguonHang);
        }

        // GET: QuanLyNguonHang/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuanLyNguonHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSanPham,TenSanPham,XuatXu,SoLuong")] QuanLyNguonHang quanLyNguonHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quanLyNguonHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quanLyNguonHang);
        }

        // GET: QuanLyNguonHang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanLyNguonHang = await _context.QuanLyNguonHang.FindAsync(id);
            if (quanLyNguonHang == null)
            {
                return NotFound();
            }
            return View(quanLyNguonHang);
        }

        // POST: QuanLyNguonHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSanPham,TenSanPham,XuatXu,SoLuong")] QuanLyNguonHang quanLyNguonHang)
        {
            if (id != quanLyNguonHang.MaSanPham)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quanLyNguonHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuanLyNguonHangExists(quanLyNguonHang.MaSanPham))
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
            return View(quanLyNguonHang);
        }

        // GET: QuanLyNguonHang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanLyNguonHang = await _context.QuanLyNguonHang
                .FirstOrDefaultAsync(m => m.MaSanPham == id);
            if (quanLyNguonHang == null)
            {
                return NotFound();
            }

            return View(quanLyNguonHang);
        }

        // POST: QuanLyNguonHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var quanLyNguonHang = await _context.QuanLyNguonHang.FindAsync(id);
            _context.QuanLyNguonHang.Remove(quanLyNguonHang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuanLyNguonHangExists(string id)
        {
            return _context.QuanLyNguonHang.Any(e => e.MaSanPham == id);
        }
    }
}
