using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using nightClub.BusinessLogic.Implimentations;
using nightClub.BusinessLogic.Interfaces;
using nightClub.Domain.Entities.Table;
using nightClub.Web.Filters;
using nightClub.Web.Models;

namespace nightClub.Web.Controllers
{
    public class TableController : BaseController
    {
        private readonly ITable _tableBL;

        public TableController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _tableBL = bl.GetTableBL();
        }
        // GET: Table
        public ActionResult Index(string searchCriteria)
        {
            SessionStatus();
            var configure = new MapperConfiguration(cfg =>
                cfg.CreateMap<TableModel, Table>());
            IMapper mapper = configure.CreateMapper();

            var table = mapper.Map<List<Table>>(_tableBL.GetList(searchCriteria));
            return View(table);
        }

        // GET: Table\Reservation
        public ActionResult Reservation()
        {
            SessionStatus();
            if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
                return RedirectToAction("Index", "Login");

            Table model = new Table();
            model.Username = ViewBag.CurrentUser.Username;
            model.Email = ViewBag.CurrentUser.Email;
            model.Phone = ViewBag.CurrentUser.PhoneNumb;
            model.GuestsNumber = 1;

            return View(model);
        }
        [HttpPost]
        public ActionResult Reservation(Table table)
        {
            SessionStatus();
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Table, TableModel>());
                IMapper mapper = config.CreateMapper();
                var tableModel = mapper.Map<TableModel>(table);

                var createReservation = _tableBL.Add(tableModel);

                if (createReservation.Status)
                {
                    return View("Confirmation", table);
                }
                else
                {
                    ModelState.AddModelError("", createReservation.StatusMsg);
                    return View();
                }
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            var ticket = _tableBL.GetById(id);
            if (ticket == null) return View("NotFound");
            _tableBL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}