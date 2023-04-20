﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using nightClub.BusinessLogic.Interfaces;
using nightClub.Domain.Entities.Staff;
using nightClub.Domain.Enums;
using nightClub.Web.Models;

namespace nightClub.Web.Controllers
{
    public class StaffController : Controller
    {
        private readonly IStaff _staffBL;

        public StaffController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _staffBL = bl.GetStaffBL();
        }
        
        //GET: Staff
        public ActionResult Index()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StaffModel, Staff>();
            });
            IMapper mapper = config.CreateMapper();
            
            var staff = mapper.Map<List<Staff>>(_staffBL.GetStaff());
            return View(staff);
        }
        // GET: Staff/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Staff employee)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Staff, StaffModel>());
                IMapper mapper = config.CreateMapper();
                var data = mapper.Map<StaffModel>(employee);

                var employeeAdded = _staffBL.AddEmployee(data);
                if (employeeAdded.Status)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", employeeAdded.StatusMsg);
                    return View();
                }
            }
            return View();
        }
    }
}