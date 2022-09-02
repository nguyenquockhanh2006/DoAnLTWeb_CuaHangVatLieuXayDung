using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CuaHangVatLieuXayDung.Controllers;
using CuaHangVatLieuXayDung.Models;

namespace CuaHangVatLieuXayDung.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: TrangChu
        VatLieuXayDungDbContext db = new VatLieuXayDungDbContext();
        public ActionResult Index()
        {
            List<SANPHAM> listsp = new List<SANPHAM>();
            SANPHAM[] listsp1 = db.SANPHAMs.ToArray();
            for (int i = 0; i < 5; i++)
            {
                SANPHAM a = listsp1[i];
                listsp.Add(a);
            }
            return View(listsp);
        }
    }
}