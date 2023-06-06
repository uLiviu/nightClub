using nightClub.BusinessLogic.Core;
using nightClub.BusinessLogic.Interfaces;
using nightClub.Domain.Entities.Table;
using nightClub.Domain.Entities.User;
using System.Collections.Generic;

namespace nightClub.BusinessLogic.Implimentations
{
    public class TableBL : ContentApi, ITable
    {
        public List<TableModel> GetList(string searchCriteria)
        {
            return GetReservationList(searchCriteria);
        }

        public UResponse Add(TableModel tableModel)
        {
            return AddTableReservation(tableModel);
        }

        public void Delete(int id)
        {
            DeleteTableReservation(id);
        }

        public TableModel GetById(int id)
        {
            return GetTableReservationById(id);
        }

    }
}