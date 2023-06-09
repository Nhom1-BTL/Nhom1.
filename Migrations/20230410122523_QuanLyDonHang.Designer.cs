﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NHOM1.Data;

#nullable disable

namespace Nhom1.Migrations
{
    [DbContext(typeof(MvcBigContext))]
    [Migration("20230410122523_QuanLyDonHang")]
    partial class QuanLyDonHang
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
