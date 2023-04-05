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
    public class QuanLyDonHangController : Controller
    {
        private readonly MvcBigContext _context;

        public QuanLyDonHangController(MvcBigContext context)
        {
            _context = context;
        }

        // GET: QuanLyDonHang
        public async Task<IActionResult> Index()
        {
            var mvcBigContext = _context.QuanLyDonHang.Include(q => q.ThongTinKhachHang);
            return View(await mvcBigContext.ToListAsync());
        }

        // GET: QuanLyDonHang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanLyDonHang = await _context.QuanLyDonHang
                .Include(q => q.ThongTinKhachHang)
                .FirstOrDefaultAsync(m => m.Madonhang == id);
            if (quanLyDonHang == null)
            {
                return NotFound();
            }

            return View(quanLyDonHang);
        }

        // GET: QuanLyDonHang/Create
        public IActionResult Create()
        {
            ViewData["Makhachhang"] = new SelectList(_context.ThongTinKhachHang, "Makhachhang", "Makhachhang");
            return View();
        }

        // POST: QuanLyDonHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Madonhang,ngaydatdon,Masanpham,ThongTinSanPham,Makhachhang")] QuanLyDonHang quanLyDonHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quanLyDonHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Makhachhang"] = new SelectList(_context.ThongTinKhachHang, "Makhachhang", "Makhachhang", quanLyDonHang.Makhachhang);
            return View(quanLyDonHang);
        }

        // GET: QuanLyDonHang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanLyDonHang = await _context.QuanLyDonHang.FindAsync(id);
            if (quanLyDonHang == null)
            {
                return NotFound();
            }
            ViewData["Makhachhang"] = new SelectList(_context.ThongTinKhachHang, "Makhachhang", "Makhachhang", quanLyDonHang.Makhachhang);
            return View(quanLyDonHang);
        }

        // POST: QuanLyDonHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Madonhang,ngaydatdon,Masanpham,ThongTinSanPham,Makhachhang")] QuanLyDonHang quanLyDonHang)
        {
            if (id != quanLyDonHang.Madonhang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quanLyDonHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuanLyDonHangExists(quanLyDonHang.Madonhang))
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
            ViewData["Makhachhang"] = new SelectList(_context.ThongTinKhachHang, "Makhachhang", "Makhachhang", quanLyDonHang.Makhachhang);
            return View(quanLyDonHang);
        }

        // GET: QuanLyDonHang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quanLyDonHang = await _context.QuanLyDonHang
                .Include(q => q.ThongTinKhachHang)
                .FirstOrDefaultAsync(m => m.Madonhang == id);
            if (quanLyDonHang == null)
            {
                return NotFound();
            }

            return View(quanLyDonHang);
        }

        // POST: QuanLyDonHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var quanLyDonHang = await _context.QuanLyDonHang.FindAsync(id);
            _context.QuanLyDonHang.Remove(quanLyDonHang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuanLyDonHangExists(string id)
        {
            return _context.QuanLyDonHang.Any(e => e.Madonhang == id);
        }
    }
}
