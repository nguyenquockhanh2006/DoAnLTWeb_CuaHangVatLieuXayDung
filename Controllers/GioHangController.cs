using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CuaHangVatLieuXayDung.Models;
using CuaHangVatLieuXayDung.ModelsKH;
namespace CuaHangVatLieuXayDung.Controllers
{
    public class GioHangController : Controller
    {
        VatLieuXayDungDbContext db = new VatLieuXayDungDbContext();
        // GET: GioHang
        public ActionResult Index()
        {
            string id = (string)Session["ID"];
            var result = (from c in db.GIOHANGs where c.MAKH == id select c).ToList();
            List<GIOHANG> gh = result;
            return View(gh);
        }
        public ActionResult ThemGioHang(string id)
        {
            if (Session["ID"] == null)
            {
                return RedirectToAction("Login", "DangNhap");
            }
            SANPHAM sp = db.SANPHAMs.FirstOrDefault(x => x.MASP == id);
            GIOHANG gh = new GIOHANG
            {
                MASP = sp.MASP,
                MAKH = (string)Session["ID"],
                TENSP = sp.TENSP,
                DONVITINH = sp.DONVITINH,
                DONGIA = sp.GIA,
                ANH = sp.ANHMOTA,
            };
            return View(gh);
        }

        [HttpPost]
        public ActionResult ThemGioHang(GIOHANG gh)
        {
            decimal thanhtien = (decimal)(gh.DONGIA * (Convert.ToInt32(gh.SOLUONG)));
            gh.MAKH = (string)Session["ID"];
            gh.THANHTIEN = thanhtien;
            db.GIOHANGs.Add(gh);
            db.SaveChanges();
            return RedirectToAction("Index", "TrangChu");
        }
    }
}
