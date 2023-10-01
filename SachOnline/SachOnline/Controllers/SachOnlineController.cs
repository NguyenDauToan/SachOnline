using SachOnline.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SachOnline.Controllers
{
    public class SachOnlineController : Controller
    {
        private SachOnlineEntities data = new SachOnlineEntities();
        // GET: SachOnline
        public ActionResult Index()
        {
            var listSachMoi = LaySachMoi(6);
            return View(listSachMoi);
        }
        
        private List<SACH> LaySachMoi(int count)
        {
            return data.SACHes.OrderByDescending(a => a.NgayCapNhat).Take(count).ToList();
        }
        private List<NHAXUATBAN> NhaXB(int count)
        {
            return data.NHAXUATBANs.OrderByDescending(a => a.MaNXB).Take(count).ToList();
        }
        // GET: SachOnline/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SachOnline/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SachOnline/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SachOnline/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SachOnline/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SachOnline/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SachOnline/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ChuDePartialView()
        {
            var listchude = from cd in data.CHUDEs select cd;
            return PartialView(listchude);
        }
        public ActionResult NXBPartialView()
        {
            var listNXB = from nxb in data.NHAXUATBANs select nxb;
            return PartialView(listNXB);
        }
        public ActionResult SachTheoChuDe(int id)
        {
            var sach = from s in data.SACHes where s.MaCD == id select s;
            return View(sach);
        }
        public ActionResult SachTheoNhaXuatBan(int id)
        {
            var sachs = from nxb in data.SACHes where nxb.MaNXB == id select nxb;  
            return View(sachs);
        }
    }
}
