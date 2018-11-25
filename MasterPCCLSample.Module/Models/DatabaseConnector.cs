using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MasterPCCLSample.Module.Models
{
    class DatabaseConnector : OracleDataProvider
    {
        private string Query;

        public DatabaseConnector(DateTime startDate,DateTime endDate, string Constr)
        {
            this.ConnectionString = Constr;
            this.Query = startDate.ToShortDateString() + endDate.ToShortDateString();
        }

        public DataSet Execute()
        {
            DataSet result = new DataSet();
            /*****必要な処理を記載*****/

            return result;
        }
    }
}
