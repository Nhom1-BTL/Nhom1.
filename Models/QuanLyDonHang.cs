using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NHOM1.Models;

public class QuanLyDonHang

{
   [Key]
    [Required(ErrorMessage = "Mã  sản phẩm không được để trống !!!")]
    public string? Madonhang { get; set; }
    [DataType(DataType.Date)]
    public DateTime ngaydatdon { get; set; }
     public string? Masanpham { get; set; }
    [ForeignKey("Masanpham")]
    public string? ThongTinSanPham { get; set; } 
     public string? Makhachhang { get; set; }
    [ForeignKey("Makhachhang")]
    public ThongTinKhachHang ?ThongTinKhachHang{ get; set; }
}