using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using System.Data;

namespace BLL.Currencies
{ 
    public class Currencies
    {
        private DatabaseClass DB = new DatabaseClass();
         public DataTable View()
        {
            string Sql = string.Format("Select (CurrencyName +' '+ CurrencyNameAr +' '+ CurrencyShortName ) as CurrencyNameAr ,CurrencyId  from  Currencies ");
            return DB.ExecuteQuery(Sql);


        }
    }
}