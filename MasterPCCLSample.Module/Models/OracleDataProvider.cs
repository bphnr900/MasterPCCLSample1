using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace MasterPCCLSample.Module.Models
{
    class OracleDataProvider
    {
        private OracleConnection con;
        public string ConnectionString { get; set; }
        private void Connect()
        {
            con = new OracleConnection();
            con.ConnectionString = ConnectionString;
            con.Open();
        }
        private void Close()
        {
            con.Close();
            con.Dispose();
        }
        private void Reader()
        {
            string strSQL = "select ename from emp";
            OracleCommand myCmd = new OracleCommand(strSQL, con);
            OracleDataReader myReader = myCmd.ExecuteReader();
            myReader.Close();
            myReader.Dispose();
        }
        private void ReadDataSet()
        {
            string strSQL = "select ename,empno from emp";
            OracleCommand myCmd = new OracleCommand(strSQL, con);
            OracleDataAdapter myDa = new OracleDataAdapter(myCmd);
            DataSet myDs = new DataSet();
            myDa.Fill(myDs, "emp");
        }
        private void insData()
        {
            string strSQL = "Insert into (empno,ename,deptno) values(9999,'ODP.NET',10)";
            OracleCommand myCmd = new OracleCommand(strSQL, con);
            OracleTransaction txn = con.BeginTransaction();
            try
            {
                int res = myCmd.ExecuteNonQuery();
                if (res == 1)
                {
                    txn.Commit();
                }
            }
            catch (Exception e)
            {
                txn.Rollback();
            }
        }
    }
}
