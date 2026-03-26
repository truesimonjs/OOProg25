using ADORosBil.DBMethods;
using ADORosBil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADORosBil.Repositories
{
    public class MedarbejderRepository : ADORepositoryBase<Medarbejder>
    {
        public MedarbejderRepository(string connectionString)
            :base(new DBMethodsMedarbejder(connectionString))
        {
        }
    }
}
