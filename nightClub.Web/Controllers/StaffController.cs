using System;
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
    public class StaffController : BaseController
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
            SessionStatus();
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

        // GET: Staff/Details/1
        public ActionResult Details(int id)
        {
            var empDetails = _staffBL.GetStaffById(id);
            if (empDetails != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<StaffModel, Staff>());
                IMapper mapper = config.CreateMapper();
                var data = mapper.Map<Staff>(empDetails);
                return View(data);
            }

            return View("NotFound");
        }   
        // GET: Staff/EmployeeDetail/1
        public ActionResult EmployeeDetail(int id)
        {
            SessionStatus();
            var empDetails = _staffBL.GetStaffById(id);
            if (empDetails != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<StaffModel, Staff>());
                IMapper mapper = config.CreateMapper();
                var data = mapper.Map<Staff>(empDetails);
                return View(data);
            }

            return View("NotFound");
        }
        
        // GET: Staff/Edit/1
        public ActionResult Edit(int id)
        {
            var empDetails = _staffBL.GetStaffById(id);
            if (empDetails != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<StaffModel, Staff>());
                IMapper mapper = config.CreateMapper();
                var data = mapper.Map<Staff>(empDetails);
                return View(data);
            }

            return View("NotFound");
        }
        [HttpPost]
        public ActionResult Edit(Staff employee)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<Staff, StaffModel>());
                IMapper mapper = config.CreateMapper();
                var data = mapper.Map<StaffModel>(employee);

                var employeeAdded = _staffBL.UpdateEmployee(data);
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

        // GET: Staff/Delete/1
        public ActionResult Delete(int id)
        {
            var empDetails = _staffBL.GetStaffById(id);
            if (empDetails != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<StaffModel, Staff>());
                IMapper mapper = config.CreateMapper();
                var data = mapper.Map<Staff>(empDetails);
                return View(data);
            }

            return View("NotFound");
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var empDetails = _staffBL.GetStaffById(id);
            if (empDetails == null) return View("NotFound");
            _staffBL.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}