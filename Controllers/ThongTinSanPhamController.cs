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
    public class ThongTinSanPhamController : Controller
    {
        private readonly MvcBigContext _context;

        public ThongTinSanPhamController(MvcBigContext context)
        {
            _context = context;
        }

        // GET: ThongTinSanPham
        public async Task<IActionResult> Index()
        {
            return View(await _context.ThongTinSanPham.ToListAsync());
        }

        // GET: ThongTinSanPham/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thongTinSanPham = await _context.ThongTinSanPham
                .FirstOrDefaultAsync(m => m.MaSanPham == id);
            if (thongTinSanPham == null)
            {
                return NotFound();
            }

            return View(thongTinSanPham);
        }

        // GET: ThongTinSanPham/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ThongTinSanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSanPham,TenSanPham,Color,GiaTien")] ThongTinSanPham thongTinSanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(thongTinSanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(thongTinSanPham);
        }

        // GET: ThongTinSanPham/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thongTinSanPham = await _context.ThongTinSanPham.FindAsync(id);
            if (thongTinSanPham == null)
            {
                return NotFound();
            }
            return View(thongTinSanPham);
        }

        // POST: ThongTinSanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaSanPham,TenSanPham,Color,GiaTien")] ThongTinSanPham thongTinSanPham)
        {
            if (id != thongTinSanPham.MaSanPham)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(thongTinSanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ThongTinSanPhamExists(thongTinSanPham.MaSanPham))
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
            return View(thongTinSanPham);
        }

        // GET: ThongTinSanPham/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thongTinSanPham = await _context.ThongTinSanPham
                .FirstOrDefaultAsync(m => m.MaSanPham == id);
            if (thongTinSanPham == null)
            {
                return NotFound();
            }

            return View(thongTinSanPham);
        }

        // POST: ThongTinSanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var thongTinSanPham = await _context.ThongTinSanPham.FindAsync(id);
            _context.ThongTinSanPham.Remove(thongTinSanPham);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ThongTinSanPhamExists(string id)
        {
            return _context.ThongTinSanPham.Any(e => e.MaSanPham == id);
        }
    }
}
