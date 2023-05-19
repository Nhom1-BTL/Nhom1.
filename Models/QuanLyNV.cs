using System.ComponentModel.DataAnnotations;

namespace NHOM1.Models;

public class QuanLyNV
{
    [Key]
     [Required(ErrorMessage = "Mã  khách  hàng không được để trống !!!")]
    public string? MaNV { get; set; }
    [Required(ErrorMessage = "Tên khách hàng không được để trống !!!")]
    public string? TenNV { get; set; }
    public string? GioiTinh { get; set;}
  
    public string? DiaChi { get; set; }
     public string? SoDienThoai { get; set; }
     
}