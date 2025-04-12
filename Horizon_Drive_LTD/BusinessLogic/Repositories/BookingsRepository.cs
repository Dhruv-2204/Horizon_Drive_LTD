using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Horizon_Drive_LTD.DataStructure;
using Horizon_Drive_LTD.Domain.Entities;
using Microsoft.Data.SqlClient;

namespace Horizon_Drive_LTD.BusinessLogic.Repositories
{
    public class BookingsRepository
    {
        private readonly DatabaseConnection _dbConnection;

      

        public BookingsRepository(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }


       


    }



}
