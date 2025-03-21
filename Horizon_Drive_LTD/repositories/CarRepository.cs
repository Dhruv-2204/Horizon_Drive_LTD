using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Horizon_Drive_LTD.models;

namespace Horizon_Drive_LTD.repositories
{
    public class CarRepository
    {
        private readonly DatabaseConnection _dbConnection;

        public CarRepository(DatabaseConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        // mo supposer fer mo get all cars ici -- sql la
        
    }
}
