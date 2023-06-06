using AutoMapper;
using nightClub.BusinessLogic.Interfaces;
using nightClub.Domain.Entities.Bar;
using nightClub.Helpers;
using nightClub.Web.Models;
using System.Collections.Generic;
using System.Web.Mvc;

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
            IMapper mapper = MappingHelper.Configure<PhotoBar, Bar>();
            var bar = mapper.Map<List<Bar>>(_barBL.GetBars());
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
                IMapper mapper = MappingHelper.Configure<Bar, PhotoBar>();

                var data = mapper.Map<PhotoBar>(bar);

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
        public ActionResult Details(int id)
        {
            SessionStatus();
            var bar = _barBL.GetBarById(id);
            if (bar != null)
            {
                IMapper mapper = MappingHelper.Configure<PhotoBar, Bar>();
                var data = mapper.Map<Bar>(bar);
                return View(data);
            }

            return View("NotFound");
        }

        public ActionResult Edit(int id)
        {
            SessionStatus();
            var bar = _barBL.GetBarById(id);
            if (bar != null)
            {
                IMapper mapper = MappingHelper.Configure<PhotoBar, Bar>();
                var data = mapper.Map<Bar>(bar);
                return View(data);
            }

            return View("NotFound");
        }

        [HttpPost]
        public ActionResult Edit(Bar bar)
        {
            SessionStatus();
            if (ModelState.IsValid)
            {
                IMapper mapper = MappingHelper.Configure<Bar, PhotoBar>();

                var data = mapper.Map<PhotoBar>(bar);

                var uBar = _barBL.Update(data);
                if (uBar.Status)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", uBar.StatusMsg);
                    return View();
                }
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            SessionStatus();
            var bar = _barBL.GetBarById(id);
            if (bar != null)
            {
                IMapper mapper = MappingHelper.Configure<PhotoBar, Bar>();
                var data = mapper.Map<Bar>(bar);
                return View(data);
            }

            return View("NotFound");
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var empDetails = _barBL.GetBarById(id);
            if (empDetails == null) return View("NotFound");
            _barBL.DeleteBar(id);
            return RedirectToAction("Index");
        }

        public ActionResult SortByCategory()
        {
            SessionStatus();
            IMapper mapper = MappingHelper.Configure<PhotoBar, Bar>();
            var bar = mapper.Map<List<Bar>>(_barBL.GetBarsByCategory());
            return View(bar);
        }
        public ActionResult SortByAlcohol()
        {
            SessionStatus();
            IMapper mapper = MappingHelper.Configure<PhotoBar, Bar>();
            var bar = mapper.Map<List<Bar>>(_barBL.GetBarsByAlcohol());
            return View(bar);
        }
        public ActionResult SortByPrice()
        {
            SessionStatus();
            IMapper mapper = MappingHelper.Configure<PhotoBar, Bar>();
            var bar = mapper.Map<List<Bar>>(_barBL.GetBarsByPrice());
            return View(bar);
        }
        public ActionResult Search(string searchQuery)
        {
            SessionStatus();

            if (string.IsNullOrEmpty(searchQuery))
            {
                ModelState.AddModelError("", "Please, enter a valid search term!");
                return RedirectToAction("Index");
            }

            var searchResults = _barBL.SearchProducts(searchQuery);

            return View("SearchResults", searchResults);
        }
    }
}