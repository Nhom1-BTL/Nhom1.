using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NHOM1.Models;
using NHOM1.Data;
using HUU38.Models.Process;
namespace NHOM1.Controllers
{
    public class QuanLyNVController : Controller
    {
        private ExcelProcess _excelProcess = new ExcelProcess();
        private StringProcess strPro = new StringProcess();
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
            var newquanao = "NV001";
            var countquanao = _context.QuanLyNV.Count();
            if (countquanao > 0)
            {
                var IDSp = _context.QuanLyNV.OrderByDescending(m => m.MaNV).First().MaNV;
                newquanao = strPro.AutoGenerateCode(IDSp);
            }
            ViewBag.newID = newquanao;
            return View();
        }

        // POST: QuanLyNV/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaNV,TenNV,GioiTinh,DiaChi,SoDienThoai")] QuanLyNV quanLyNV)
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
        public async Task<IActionResult> Edit(string id, [Bind("MaNV,TenNV,GioiTinh,DiaChi,SoDienThoai")] QuanLyNV quanLyNV)
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
        public async Task<IActionResult> Upload()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null)
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (fileExtension != ".xls" && fileExtension != ".xlsx")
                {
                    ModelState.AddModelError("", "Please choose excel file to upload!");
                }
                else
                {
                    var FileName = DateTime.Now.ToShortTimeString() + fileExtension;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory() + "/Uploads/Excels", FileName);
                    var fileLocation = new FileInfo(filePath).ToString();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        //save file to sever
                        await file.CopyToAsync(stream);
                        var dt = _excelProcess.ExcelToDataTable(fileLocation);
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            var std = new QuanLyNV();

                            std.MaNV = dt.Rows[i][0].ToString();
                            std.TenNV = dt.Rows[i][1].ToString();
                            std.GioiTinh = dt.Rows[i][2].ToString();
                            std.DiaChi = dt.Rows[i][3].ToString();
                            std.SoDienThoai = dt.Rows[i][4].ToString();

                            _context.QuanLyNV.Add(std);
                        }
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View();
        }
    }
}
