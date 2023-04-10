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
    public class ThongTinKhachHangController : Controller
    {
        private readonly MvcBigContext _context;

        public ThongTinKhachHangController(MvcBigContext context)
        {
            _context = context;
        }

        // GET: ThongTinKhachHang
        public async Task<IActionResult> Index()
        {
            return View(await _context.ThongTinKhachHang.ToListAsync());
        }

        // GET: ThongTinKhachHang/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thongTinKhachHang = await _context.ThongTinKhachHang
                .FirstOrDefaultAsync(m => m.Makhachhang == id);
            if (thongTinKhachHang == null)
            {
                return NotFound();
            }

            return View(thongTinKhachHang);
        }

        // GET: ThongTinKhachHang/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ThongTinKhachHang/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Makhachhang,Tenkhachhang,Diachi,Sodienthoai")] ThongTinKhachHang thongTinKhachHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thongTinKhachHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thongTinKhachHang);
        }

        // GET: ThongTinKhachHang/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thongTinKhachHang = await _context.ThongTinKhachHang.FindAsync(id);
            if (thongTinKhachHang == null)
            {
                return NotFound();
            }
            return View(thongTinKhachHang);
        }

        // POST: ThongTinKhachHang/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Makhachhang,Tenkhachhang,Diachi,Sodienthoai")] ThongTinKhachHang thongTinKhachHang)
        {
            if (id != thongTinKhachHang.Makhachhang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thongTinKhachHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThongTinKhachHangExists(thongTinKhachHang.Makhachhang))
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
            return View(thongTinKhachHang);
        }

        // GET: ThongTinKhachHang/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thongTinKhachHang = await _context.ThongTinKhachHang
                .FirstOrDefaultAsync(m => m.Makhachhang == id);
            if (thongTinKhachHang == null)
            {
                return NotFound();
            }

            return View(thongTinKhachHang);
        }

        // POST: ThongTinKhachHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var thongTinKhachHang = await _context.ThongTinKhachHang.FindAsync(id);
            _context.ThongTinKhachHang.Remove(thongTinKhachHang);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThongTinKhachHangExists(string id)
        {
            return _context.ThongTinKhachHang.Any(e => e.Makhachhang == id);
        }
    }
}
