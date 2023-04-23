using nightClub.Domain.Entities.Staff;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using nightClub.BusinessLogic.DBModel;
using nightClub.Domain.Entities.Gallery;
using nightClub.Domain.Entities.User;

namespace nightClub.BusinessLogic.Core
{
    public class ContentApi
    {
        //Get List
        internal List<StaffModel> GetList()
        {
            List<SDbTable> context;

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SDbTable, StaffModel>()).CreateMapper();
            using (var db = new StaffContext())
            {
                context = db.Staff.ToList();
            }
            return mapper.Map<List<StaffModel>>(context);
        }
        internal List<PhotoModel> GetAllPhoto()
        {
            List<PDbTable> context;

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<PDbTable, PhotoModel>()).CreateMapper();
            using (var db = new GalleryContext())
            {
                context = db.Photos.ToList();
            }
            return mapper.Map<List<PhotoModel>>(context);
        }
        //AddNewEntity
        internal UResponse AddNewEntity(StaffModel data)
        {
            SDbTable context;

            using (var db = new StaffContext())
                context = db.Staff.FirstOrDefault(u => u.PhoneNumb == data.PhoneNumb);
            if (context != null)
                return new UResponse { Status = false, StatusMsg = "Employee already added!" };

            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<StaffModel, SDbTable>()).CreateMapper();
            context = mapper.Map<SDbTable>(data);

            using (var db = new StaffContext())
            {
                db.Staff.Add(context);
                db.SaveChanges();
            }
            return new UResponse { Status = true };
        }

        internal UResponse AddEntity(PhotoModel photo)
        {
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<PhotoModel, PDbTable>()).CreateMapper();
            PDbTable context = mapper.Map<PDbTable>(photo);

            context.Date = DateTime.Now;
            using (var db = new GalleryContext())
            {
                db.Photos.Add(context);
                db.SaveChanges();
            }
            return new UResponse { Status = true };
        }

        //AddById
        internal StaffModel GetById(int id)
        {
            SDbTable context;
            using (var db = new StaffContext())
                context = db.Staff.FirstOrDefault(u => u.Id == id);
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<SDbTable, StaffModel>()).CreateMapper();

            return context != null ? mapper.Map<StaffModel>(context) : null;
        }
        internal PhotoModel GetPhotoById(int id)
        {
            PDbTable context;
            using (var db = new GalleryContext())
                context = db.Photos.FirstOrDefault(u => u.Id == id);
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<PDbTable, PhotoModel>()).CreateMapper();

            return context != null ? mapper.Map<PhotoModel>(context) : null;
        }

        //Update
        internal UResponse Update(StaffModel data)
        {
            if (GetById(data.Id) == null)
                return new UResponse { Status = false, StatusMsg = "An Error occur at updating" };

            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<StaffModel, SDbTable>()).CreateMapper();
            var result = mapper.Map<SDbTable>(data);

            using (var db = new StaffContext())
            {
                db.Staff.AddOrUpdate(result);
                db.SaveChanges();
            }
            return new UResponse { Status = true };
        }
        internal UResponse UpdatePhoto(PhotoModel data)
        {
            if (GetPhotoById(data.Id) == null)
                return new UResponse { Status = false, StatusMsg = "An Error occur at updating" };

            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<PhotoModel, PDbTable>()).CreateMapper();
            var result = mapper.Map<PDbTable>(data);
            result.Date = DateTime.Now;

            using (var db = new GalleryContext())
            {
                db.Photos.AddOrUpdate(result);
                db.SaveChanges();
            }
            return new UResponse { Status = true };
        }

        //Delete
        internal void Delete(int id)
        {
            using (var db = new StaffContext())
            {
                var staff = db.Staff.FirstOrDefault(u => u.Id == id);
                if (staff != null)
                {
                    db.Staff.Remove(staff);
                    db.SaveChanges();
                }
            }
        }
        internal void DeletePhoto(int id)
        {
            using (var db = new GalleryContext())
            {
                var photo = db.Photos.FirstOrDefault(p => p.Id == id);
                if (photo != null)
                {
                    db.Photos.Remove(photo);
                    db.SaveChanges();
                }
            }
        }

    }
}
