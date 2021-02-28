using System;
using System.Data;
using System.Data.SqlClient;

namespace Examination_System
{
    internal class sqlCommand
    {
        internal static string CommandText;
        internal readonly object parameters;
        internal CommandType CommandType;
        private string v;
        private SqlConnection sqlConnection1;

        public sqlCommand(string v, SqlConnection sqlConnection1)
        {
            this.v = v;
            this.sqlConnection1 = sqlConnection1;
        }

       
    }
}