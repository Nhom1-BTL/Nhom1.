using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NHOM1.Models;

namespace NHOM1.Data 
{
#pragma warning restore format
    public class MvcBigContext : DbContext
    {
        public MvcBigContext (DbContextOptions<MvcBigContext> options)
            : base(options)
        {
        }

        public DbSet<ThongTinKhachHang> ThongTinKhachHang { get; set; }

        public DbSet<QuanLyDonHang> QuanLyDonHang { get; set; }
        public DbSet<ThongTinSanPham> ThongTinSanPham { get; set; }

    }
}