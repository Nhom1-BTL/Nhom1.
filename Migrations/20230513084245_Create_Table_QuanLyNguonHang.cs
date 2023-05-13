using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NHOM1.Migrations
{
    /// <inheritdoc />
    public partial class Create_Table_QuanLyNguonHang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuanLyNguonHang",
                columns: table => new
                {
                    MaSanPham = table.Column<string>(type: "TEXT", nullable: false),
                    TenSanPham = table.Column<string>(type: "TEXT", nullable: false),
                    XuatXu = table.Column<string>(type: "TEXT", nullable: true),
                    SoLuong = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanLyNguonHang", x => x.MaSanPham);
                });

            migrationBuilder.CreateTable(
                name: "QuanLyNV",
                columns: table => new
                {
                    MaNV = table.Column<string>(type: "TEXT", nullable: false),
                    TenNV = table.Column<string>(type: "TEXT", nullable: false),
                    GioiTinh = table.Column<string>(type: "TEXT", nullable: true),
                    Diachi = table.Column<string>(type: "TEXT", nullable: true),
                    Sodienthoai = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuanLyNV", x => x.MaNV);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuanLyNguonHang");

            migrationBuilder.DropTable(
                name: "QuanLyNV");
        }
    }
}
