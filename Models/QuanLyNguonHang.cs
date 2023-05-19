using System.Drawing;
using System.ComponentModel.DataAnnotations;

namespace NHOM1.Models;

public class QuanLyNguonHang
{
    [Key]
     [Required(ErrorMessage = "Mã sản phẩm không được để trống !!!")]
    public string? MaSanPham { get; set; }
    [Required(ErrorMessage = "Tên sản phẩm không được để trống !!!")]
    public string? TenSanPham{ get; set; }
  
    public string?  XuatXu{ get; set; }
     public int SoLuong { get; set; }
     
}