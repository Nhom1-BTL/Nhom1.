using System.ComponentModel.DataAnnotations;

namespace NHOM1.Models;

public class ThongTinKhachHang
{
    [Key]
     [Required(ErrorMessage = "Mã  khách  hàng không được để trống !!!")]
    public string? Makhachhang { get; set; }
    [Required(ErrorMessage = "Tên khách hàng không được để trống !!!")]
    public string? Tenkhachhang{ get; set; }
  
    public string? Diachi { get; set; }
     public int Sodienthoai { get; set; }
     
}