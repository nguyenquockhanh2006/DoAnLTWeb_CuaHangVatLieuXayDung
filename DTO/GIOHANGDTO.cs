using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CuaHangVatLieuXayDung.Models;
namespace CuaHangVatLieuXayDung.DTO
{
    public class GIOHANGDTO
    {
        [Required]
        public int MAGH { get; set; }
        [Required]
        public string MAKH { get; set; }
        [Required]
        public string MASP { get; set; }
        [Required]
        public string TENSP { get; set; }
        [Required]
        public string SOLUONG { get; set; }
        [Required]
        public string DONVITINH { get; set; }
        [Required]
        public Nullable<decimal> DONGIA { get; set; }
        [Required]
        public Nullable<decimal> THANHTIEN { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
        public virtual TAIKHOAN TAIKHOAN { get; set; }
    }
}