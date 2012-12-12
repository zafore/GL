using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using System.Data;
namespace BLL.Banks
{
    public class Banks
    {
        private DatabaseClass DB = new DatabaseClass();
        public DataTable View(int CompId)
        {
            string Sql = string.Format("Select * from Banks where CompId={0} ", CompId);
            return DB.ExecuteQuery(Sql);


        }
    }
}