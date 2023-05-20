using System.ComponentModel.DataAnnotations;

namespace NHOM1.Models;

public class QuanLyNV
{
    [Key]
     [Required(ErrorMessage = "Mã  nhân viên không được để trống !!!")]
    public string? MaNV { get; set; }
    [Required(ErrorMessage = "Tên nhân viên không được để trống !!!")]
    public string? TenNV { get; set; }
    [Required(ErrorMessage = "Giới tính không được để trống !!!")]
    [Display( Name = "Giới tính")]
    public string? GioiTinh { get; set;}
    [Required(ErrorMessage = "Địa chỉ không được để trống !!!")] 
    [Display( Name = "Địa chỉ")]
     public string? DiaChi { get; set; }

    [Required(ErrorMessage = "Số điện thoại không được bỏ trống !!!")]
    [Display( Name = "Số điện thoại")]
     public string? SoDienThoai { get; set; }
     
}