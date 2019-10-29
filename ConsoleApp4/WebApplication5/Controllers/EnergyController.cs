using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnergyConsumption.Business;
using EnergyConsumption.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using WebApplication5.Providers;

namespace WebApplication5.Controllers
{
    public class EnergyController : Controller
    {
        public IActionResult Index()
        {
            var usops = new UserSensorOperations(new Providers.DapperEnergyServicesConnectionStringProvider());
            var sdops = new SensorDataOperations(new Providers.DapperEnergyServicesConnectionStringProvider());

            var userId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);

            var dict = new Dictionary<Guid, SensorData>();
            
            var userSensors = usops.GetList(userId);
            
            foreach(var sid in userSensors.Select(i=>i.SensorId))
            {
                var data = sdops.GetList(sid).OrderByDescending(i => i.Created).Take(1).FirstOrDefault();

                if(data!=null)
                    dict.Add(sid, data);
            }


            var userEnSensors = userSensors
                .Select(i => new EnergyUserSensor()
                {
                    UserSensorId = i.UserSensorId,
                    UserId = i.UserId,
                    SensorId = i.SensorId,
                    Created = i.Created,
                    SensorText = i.SensorText,
                    LastCounterValue = dict.ContainsKey(i.SensorId) ? dict[i.SensorId].Value : 0,
                    LastCounterValueDateTime = dict.ContainsKey(i.SensorId) ? dict[i.SensorId].Created : DateTime.Now
                }); ;

            var model = new EnergyServiceProfileDetails()
            {
                sensors = userEnSensors
            };

            return View(model);
        }

        // GET: Blockchain/Create
        public ActionResult Create()
        {
            var usops = new UserSensorOperations(new DapperEnergyServicesConnectionStringProvider());

            var userId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);

            var model = new EnergyUserSensor()
            {
                UserSensorId = 0,
                SensorId = Guid.NewGuid(),
                SensorText="My new smart sensor device(rename me)",
                UserId = userId,
                Created = DateTime.Now
            };

            return View(model);
        }

        // POST: Blockchain/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var usops = new UserSensorOperations(new DapperEnergyServicesConnectionStringProvider());

                var userId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);

                var sensorText = collection["sensorText"];

                var userSensor = usops.AddOne(userId, sensorText);

                 // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var usops = new UserSensorOperations(new DapperEnergyServicesConnectionStringProvider());

                //var userId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);

                usops.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Blockchain/Create
        public ActionResult Details(Guid sensorId)
        {
            var usops = new UserSensorOperations(new DapperEnergyServicesConnectionStringProvider());
            var sdops = new SensorDataOperations(new Providers.DapperEnergyServicesConnectionStringProvider());

            var userId = Guid.Parse(HttpContext.User.Claims.FirstOrDefault(i => i.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value);

            var sensor = usops.GetOne(sensorId, userId);
            
            var data = sdops.GetList(sensorId).OrderByDescending(i=>i.Created).ToArray();

            var model = new EnergyUserSensorWithData()
            {
                UserSensorId = sensor.UserSensorId,
                SensorId = sensor.SensorId,
                SensorText = sensor.SensorText,
                UserId = sensor.UserId,
                Created = sensor.Created,
                SensorData=data
            };

            return View("UserSensorDetails",model);
        }
    }
}