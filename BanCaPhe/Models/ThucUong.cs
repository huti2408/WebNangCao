using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BanCaPhe.Models
{
    public class ThucUong
    {
        [Key]
        public string IdCF { get; set; }
        [Required(ErrorMessage = "Tên không được trống")]
        public string Ten { get; set; }
        [Required(ErrorMessage = "Vui lòng thêm hình ảnh cho sản phẩm")]
        public string HinhAnh { get; set; }
        [Required(ErrorMessage = "Vui lòng thêm đơn giá")]
        public int DonGia { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn loại nước")]
        public string IdLoaiNuoc { get; set; }
        public virtual ICollection<LoaiNuoc> LoaiNuocs { get; set; }
        public virtual ICollection<ChiTietHD> ChiTietHDs { get; set; }
    }
}