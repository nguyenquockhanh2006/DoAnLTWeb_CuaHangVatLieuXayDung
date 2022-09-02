using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using CuaHangVatLieuXayDung.Models;
using CuaHangVatLieuXayDung.Controllers;
namespace CuaHangVatLieuXayDung.Controllers
{
    public class DangNhapController : Controller
    {

        VatLieuXayDungDbContext db = new VatLieuXayDungDbContext();

        //mã hóa MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
        // GET: DangNhap
        public ActionResult Index()
        {
            if (Session["ID"] != null)
                return RedirectToAction("Index", "TrangChu");
            return View("Login");
        }
        // 
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string id, string pass)
        {
            if (ModelState.IsValid)
            {
                var f_password = GetMD5(pass);
                var data = db.TAIKHOANs.Where(s => s.ID.Equals(id) && s.PASS.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    //if(data.FirstOrDefault().PQ == "KHACH")
                    //{
                        Session["FullName"] = data.FirstOrDefault().TEN;
                        Session["ID"] = data.FirstOrDefault().ID;
                        Session["PASS"] = data.FirstOrDefault().PASS;
                        Session["PHANQUYEN"] = data.FirstOrDefault().PQ;
                        return RedirectToAction("Index", "TrangChu");
                    //}
                    //else
                    //{
                    //    Session["FullName"] = data.FirstOrDefault().TEN;
                    //    Session["ID"] = data.FirstOrDefault().ID;
                    //    Session["PASS"] = data.FirstOrDefault().PASS;
                    //    Session["PHANQUYEN"] = data.FirstOrDefault().PQ;
                    //    return RedirectToAction("Index1");
                    //}
                }
                else
                {
                    ViewBag.error = "Đăng nhập thất bại - Tên tài khoản hoặc mật khẩu không đúng!";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        // Đăng xuất
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
        // Đăng kí 
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(TAIKHOAN _user)
        {
            if (ModelState.IsValid)
            {
                var check = db.TAIKHOANs.FirstOrDefault(s => s.ID == _user.ID);
                if (check == null)
                {
                    _user.PASS = GetMD5(_user.PASS);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.TAIKHOANs.Add(_user);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.error = "Tên tài khoản đã tồn tại";
                    return View();
                }
            }
            return View();
        }
    }
}