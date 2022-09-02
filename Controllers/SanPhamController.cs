using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CuaHangVatLieuXayDung.Models;
namespace CuaHangVatLieuXayDung.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        VatLieuXayDungDbContext db = new VatLieuXayDungDbContext();
        // GET: SanPham
        public ActionResult Index()
        {
            return View(db.SANPHAMs.ToList());
        }
        public List<SANPHAM> GetSanPham(string Loai)
        {
            List<SANPHAM> listSP = new List<SANPHAM>();

            if (Loai == null)
                listSP = db.SANPHAMs.ToList();
            else
                listSP = (from x in db.SANPHAMs where x.LOAI == Loai.Trim() select x).ToList();

            return listSP;
        }

        public ActionResult LoadSanPham(string Loai)
        {
            var sanpham = new List<SANPHAM>();
            List<SANPHAM> sp = GetSanPham(Loai);
            foreach (var temp in sp)
            {
                sanpham.Add(temp);
            }
            //ViewBag.SanPham = sanpham;
            return View(sanpham);
        }
    }
}