using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Energy.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class EnergyController : Controller
    {
        // GET: Energy
        public ActionResult Index()
        {
            var usops = new UserSensorOperations(new Providers.DapperEnergyServicesConnectionStringProvider());

            //var userId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);

            //var userSensors = usops.GetList(userId)
            //    .Select(i => new EnergyUserSensor()
            //    {
            //        UserSensorId = i.UserSensorId,
            //        UserId = i.UserId,
            //        SensorId = i.SensorId,
            //        Created = i.Created
            //    });

            var model = new EnergyServiceProfileDetails()
            {
                sensors = null
            };

            return View(model);
        }

        // GET: Energy/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Energy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Energy/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Energy/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Energy/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Energy/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Energy/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}