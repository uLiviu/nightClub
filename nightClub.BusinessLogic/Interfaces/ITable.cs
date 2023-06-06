using nightClub.Domain.Entities.Table;
using nightClub.Domain.Entities.User;
using System.Collections.Generic;

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