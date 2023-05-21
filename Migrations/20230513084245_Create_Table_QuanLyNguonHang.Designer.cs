﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NHOM1.Data;

#nullable disable

namespace NHOM1.Migrations
{
    [DbContext(typeof(MvcBigContext))]
    [Migration("20230513084245_Create_Table_QuanLyNguonHang")]
    partial class Create_Table_QuanLyNguonHang
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("NHOM1.Models.QuanLyNV", b =>
                {
                    b.Property<string>("MaNV")
                        .HasColumnType("TEXT");

                    b.Property<string>("Diachi")
                        .HasColumnType("TEXT");

                    b.Property<string>("GioiTinh")
                        .HasColumnType("TEXT");

                    b.Property<int>("Sodienthoai")
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
#pragma warning restore 612, 618
        }
    }
}