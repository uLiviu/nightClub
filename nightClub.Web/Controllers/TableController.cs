using nightClub.BusinessLogic.Interfaces;
using nightClub.Domain.Entities.Table;
using nightClub.Helpers;
using nightClub.Web.Filters;
using nightClub.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

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
        [AdminMod]
        public ActionResult Index(string searchCriteria)
        {
            SessionStatus();

            var mapper = MappingHelper.Configure<TableModel, Table>();
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
        [Authenticated]
        public ActionResult Reservation(Table table)
        {
            SessionStatus();
            if (ModelState.IsValid)
            {
                var mapper = MappingHelper.Configure<Table, TableModel>();
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

        public ActionResult Confirmation()
        {
            Table table = new Table();
            return View(table);
        }

        [AdminMod]
        public ActionResult Delete(int id)
        {
            var ticket = _tableBL.GetById(id);
            if (ticket == null) return View("NotFound");
            _tableBL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}