﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NHOM1.Data;

#nullable disable

namespace Nhom1.Migrations
{
    [DbContext(typeof(MvcBigContext))]
    partial class MvcBigContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("NHOM1.Models.QuanLyDonHang", b =>
                {
                    b.Property<string>("Madonhang")
                        .HasColumnType("TEXT");

                    b.Property<string>("Makhachhang")
                        .HasColumnType("TEXT");

                    b.Property<string>("Masanpham")
                        .HasColumnType("TEXT");

                    b.Property<string>("ThongTinSanPham")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ngaydatdon")
                        .HasColumnType("TEXT");

                    b.HasKey("Madonhang");

                    b.HasIndex("Makhachhang");

                    b.ToTable("QuanLyDonHang");
                });

            modelBuilder.Entity("NHOM1.Models.QuanLyNV", b =>
                {
                    b.Property<string>("MaNV")
                        .HasColumnType("TEXT");

                    b.Property<string>("DiaChi")
                        .HasColumnType("TEXT");

                    b.Property<string>("GioiTinh")
                        .HasColumnType("TEXT");

                    b.Property<int>("SoDienThoai")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TenNV")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaNV");

                    b.ToTable("QuanLyNV");
                });

            modelBuilder.Entity("NHOM1.Models.QuanLyNguonHang", b =>
                {
                    b.Property<string>("MaSanPham")
                        .HasColumnType("TEXT");

                    b.Property<int>("SoLuong")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("XuatXu")
                        .HasColumnType("TEXT");

                    b.HasKey("MaSanPham");

                    b.ToTable("QuanLyNguonHang");
                });

            modelBuilder.Entity("NHOM1.Models.ThongTinKhachHang", b =>
                {
                    b.Property<string>("Makhachhang")
                        .HasColumnType("TEXT");

                    b.Property<string>("Diachi")
                        .HasColumnType("TEXT");

                    b.Property<int>("Sodienthoai")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Tenkhachhang")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Makhachhang");

                    b.ToTable("ThongTinKhachHang");
                });

            modelBuilder.Entity("NHOM1.Models.ThongTinSanPham", b =>
                {
                    b.Property<string>("MaSanPham")
                        .HasColumnType("TEXT");

                    b.Property<string>("Color")
                        .HasColumnType("TEXT");

                    b.Property<int>("GiaTien")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TenSanPham")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MaSanPham");

                    b.ToTable("ThongTinSanPham");
                });

            modelBuilder.Entity("NHOM1.Models.QuanLyDonHang", b =>
                {
                    b.HasOne("NHOM1.Models.ThongTinKhachHang", "ThongTinKhachHang")
                        .WithMany()
                        .HasForeignKey("Makhachhang");

                    b.Navigation("ThongTinKhachHang");
                });
#pragma warning restore 612, 618
        }
    }
}
