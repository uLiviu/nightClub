using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using nightClub.Domain.Entities.Table;
using nightClub.Domain.Entities.User;

namespace nightClub.BusinessLogic.Interfaces
{
    public interface ITable
    {
        List<TableModel> GetList(string searchCriteria);
        UResponse Add(TableModel tableModel);
        void Delete(int id);
        TableModel GetById(int id);
    }
}