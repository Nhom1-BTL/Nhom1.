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
    [Required(ErrorMessage = "Xuất xứ không được để trống !!!")]
    public string?  XuatXu{ get; set; }

    [Required(ErrorMessage = "Số lượng không được để trống")]
    [Display( Name = "Số lượng")]
     public int?  SoLuong { get; set; }
     
}