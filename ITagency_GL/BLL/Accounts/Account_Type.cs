using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DAL;

namespace BLL.Accounts
{
    public class Account_Type
    {
        private DatabaseClass DB = new DatabaseClass();
        public DataTable View(int CompId)
        {
            string Sql = string.Format("Select * from  AccountTypes where CompId={0} ", CompId);
            return DB.ExecuteQuery(Sql);


        }
    }
}