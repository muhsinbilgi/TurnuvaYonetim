using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;



namespace VeritabaniKatmani.Repository
{
    public class DapperRepository : AbstractDapperRepository
    {
        public DapperRepository(string connectionName) : base(connectionName)
        {

        }
        public DapperRepository(IDbConnection dbConnection) : base(dbConnection)
        {

        }



    }
}