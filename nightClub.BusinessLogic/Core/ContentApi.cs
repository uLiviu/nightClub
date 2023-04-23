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


        internal StaffModel GetById(int id)
        {
            SDbTable context;
            using (var db = new StaffContext())
                context = db.Staff.FirstOrDefault(u => u.Id == id);
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<SDbTable, StaffModel>()).CreateMapper();

            return context != null ? mapper.Map<StaffModel>(context) : null;
        }
        internal UResponse Update(StaffModel data)
        {
            if (GetById(data.Id) == null)
                return new UResponse { Status = false, StatusMsg = "An Error occur at updating" };

            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<StaffModel, SDbTable>()).CreateMapper();
            SDbTable result = mapper.Map<SDbTable>(data);

            using (var db = new StaffContext())
            {
                db.Staff.AddOrUpdate(result);
                db.SaveChanges();
            }
            return new UResponse { Status = true };
        }

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
    }
}
