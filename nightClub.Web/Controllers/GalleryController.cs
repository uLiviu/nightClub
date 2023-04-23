using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using nightClub.BusinessLogic.Interfaces;
using nightClub.Domain.Entities.Gallery;
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
    }
}