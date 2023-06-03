using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using nightClub.BusinessLogic.Implimentations;
using nightClub.BusinessLogic.Interfaces;
using nightClub.Domain.Entities.Table;
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
    }
}