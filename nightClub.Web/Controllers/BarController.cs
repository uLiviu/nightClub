using AutoMapper;
using nightClub.BusinessLogic.Interfaces;
using nightClub.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using nightClub.Domain.Entities.Bar;

namespace nightClub.Web.Controllers
{
    public class BarController : BaseController
    {
        public readonly IBar _barBL;

        public BarController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _barBL = bl.GetBarBL();
        }

        //GET: Bar
        public ActionResult Index()
        {

            SessionStatus();
            IMapper mappeer = new MapperConfiguration(cfg =>
                cfg.CreateMap<PhotoBar, Bar>()).CreateMapper();
            var bar = mappeer.Map<List<Bar>>(_barBL.GetBars());
            return View(bar);
        }
        
        public ActionResult Create()
        {
            SessionStatus();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Bar bar)
        {
            SessionStatus();
            if (ModelState.IsValid)
            {
                IMapper mappeer = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Bar, PhotoBar>()).CreateMapper();
                var data = mappeer.Map<PhotoBar>(bar);

                var newPhoto = _barBL.Add(data);
                if (newPhoto.Status)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", newPhoto.StatusMsg);
                    return View();
                }
            }
            return View();
        }
    }
}