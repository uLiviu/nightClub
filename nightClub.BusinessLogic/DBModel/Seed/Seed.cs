using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nightClub.BusinessLogic.DBModel.Seed
{
    public class Seed
    {
        public static void InitializeDataBase()
        {
            System.Data.Entity.Database.SetInitializer(new GalleryDbInitializer());
            System.Data.Entity.Database.SetInitializer(new StaffDbInitializer());
            System.Data.Entity.Database.SetInitializer(new UserDbInitializer());
            System.Data.Entity.Database.SetInitializer(new EventDbInitializer());
        }
    }
}
