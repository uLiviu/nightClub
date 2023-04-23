using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using nightClub.BusinessLogic.Implimentations;
using nightClub.BusinessLogic.Interfaces;
using nightClub.Domain.Entities.Gallery;
using nightClub.Domain.Entities.Staff;
using nightClub.Web.Models;

namespace nightClub.Web.Controllers
{
    public class GalleryController : Controller
    {
        public readonly IGallery _galleryBL;

        public GalleryController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _galleryBL = bl.GetGalleryBL();
        }

        // GET: Gallery
        public ActionResult Index()
        {
            IMapper mappeer = new MapperConfiguration(cfg =>
                cfg.CreateMap<PhotoModel, Photo>()).CreateMapper();
            var photo = mappeer.Map<List<Photo>>(_galleryBL.GetAll());
            return View(photo);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Photo photo)
        {
            if (ModelState.IsValid)
            {
                IMapper mappeer = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Photo, PhotoModel>()).CreateMapper();
                var data = mappeer.Map<PhotoModel>(photo);
                
                var newPhoto = _galleryBL.Add(data);
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

        // GET: Gallery/Details/1
        public ActionResult Details(int id)
        {
            var photo = _galleryBL.GetById(id);
            if (photo != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<PhotoModel, Photo>());
                IMapper mapper = config.CreateMapper();
                var data = mapper.Map<Photo>(photo);
                return View(data);
            }

            return View("NotFound");
        }

        public ActionResult Edit(int id)
        {
            var photo = _galleryBL.GetById(id);
            if (photo != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<PhotoModel, Photo>());
                IMapper mapper = config.CreateMapper();
                var data = mapper.Map<Photo>(photo);
                return View(data);
            }

            return View("NotFound");
        }
        [HttpPost]
        public ActionResult Edit(Photo photo)
        {
            if (ModelState.IsValid)
            {
                IMapper mappeer = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Photo, PhotoModel>()).CreateMapper();
                var data = mappeer.Map<PhotoModel>(photo);

                var uPhoto = _galleryBL.Update(data);
                if (uPhoto.Status)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", uPhoto.StatusMsg);
                    return View();
                }
            }
            return View();
        }
        // GET: Gallery/Delete/1
        public ActionResult Delete(int id)
        {
            var photo = _galleryBL.GetById(id);
            if (photo != null)
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<PhotoModel, Photo>());
                IMapper mapper = config.CreateMapper();
                var data = mapper.Map<Photo>(photo);
                return View(data);
            }

            return View("NotFound");
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var empDetails = _galleryBL.GetById(id);
            if (empDetails == null) return View("NotFound");
            _galleryBL.Delete(id);
            return RedirectToAction("Index");
        }
    }
}