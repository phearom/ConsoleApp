using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GetStoreProcedure();
            return;
            var con = new OracleConnection("user id=phearom; password=123;data source=localhost:1521/db002");
            var cmd = new OracleCommand("select * from tblstudent", con);
            con.Open();
            var dr = cmd.ExecuteReader();
            Console.WriteLine("Get data from Oracle");
            while (dr.Read())
            {
                Console.WriteLine(dr.GetString(1));
            }
            con.Close();
            Console.ReadKey();
        }
        static void GetStoreProcedure()
        {
            try
            {

                var con = new OracleConnection("user id=phearom; password=123;data source=localhost:1521/db002");
                var cmd = new OracleCommand("SP_GETALLSTUDENT", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add(new OracleParameter("cursorParam", OracleDbType.RefCursor, ParameterDirection.Output));
                con.Open();
                var dr = cmd.ExecuteReader();
                Console.WriteLine("Get data from Oracle using Store procedure ref cursor");
                while (dr.Read())
                {
                    Console.WriteLine(dr.GetString(1));
                }
                con.Close();
                Console.ReadKey();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
