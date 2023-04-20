using nightClub.Domain.Entities.Staff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using nightClub.BusinessLogic.DBModel;

namespace nightClub.BusinessLogic.Core
{
    public class ContentApi
    {
        internal List<StaffModel> GetStaffList()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StaffModel, SDbTable>();
            });
            IMapper mapper = config.CreateMapper();
            using (var db = new StaffContext())
            {
                var result = db.Staff.ToList();
                var staffData = mapper.Map<List<StaffModel>>(result);
                return staffData;
            }
        }
    }
}
