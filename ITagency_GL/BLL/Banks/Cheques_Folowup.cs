using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DAL;
namespace BLL.Cheques_Folowup
{
    public class Cheques_Folowup
    {
        private DatabaseClass DB = new DatabaseClass();
        public DataTable Search(string ChequeDueDate1, string ChequeDueDate2, string ChequeType, string BankID, string ChequeNo, string Status)
        {
            bool isFirstArg = true;
            string sql = "SELECT * FROM vwChequeMgmtFullInfo ";


            if (ChequeDueDate1 != null)
            {
                if (isFirstArg)
                {
                    sql = string.Format("{0} WHERE ChequeDueDate>='{1}' ", sql, DatabaseClass.FormatDateArEgMDY(ChequeDueDate1));
                    isFirstArg = false;
                }
                else
                    sql = string.Format("{0} AND ChequeDueDate>='{1}' ", sql, DatabaseClass.FormatDateArEgMDY(ChequeDueDate1));
            }

            if (ChequeDueDate2 != null)
            {
                if (isFirstArg)
                {
                    sql = string.Format(" {0} WHERE ChequeDueDate<='{1}' ", sql, DatabaseClass.FormatDateArEgMDY(ChequeDueDate2));
                    isFirstArg = false;
                }
                else
                    sql = string.Format(" {0} AND ChequeDueDate<='{1}' ", sql, DatabaseClass.FormatDateArEgMDY(ChequeDueDate2));
            }

            if (ChequeType != "0")
            {
                if (isFirstArg)
                {
                    sql = string.Format("{0} WHERE {1}=1 ", sql, ChequeType == "1" ? "Incoming" : "Outgoing");
                    isFirstArg = false;
                }
                else
                    sql = string.Format("{0} AND {1}=1 ", sql, ChequeType == "1" ? "Incoming" : "Outgoing");
            }

            if (BankID != "0")
            {
                if (isFirstArg)
                {
                    sql = string.Format("{0} WHERE BankID={1} ", sql, BankID);
                    isFirstArg = false;
                }
                else
                    sql = string.Format("{0} AND BankID={1} ", sql, BankID);
            }

            if (ChequeNo != "")
            {
                if (isFirstArg)
                {
                    sql = string.Format("{0} WHERE ChequeNum LIKE '%{1}%' ", sql, ChequeNo);
                    isFirstArg = false;
                }
                else
                    sql = string.Format("{0} AND ChequeNum LIKE '%{1}%' ", sql, ChequeNo);
            }

            if (Status != "0")
            {
                if (isFirstArg)
                {
                    sql = string.Format(" {0} WHERE ChequeStatus={1} ", sql, Status);
                    isFirstArg = false;
                }
                else
                    sql = string.Format(" {0} AND ChequeStatus={1} ", sql, Status);
            }


            sql = string.Format("{0} ORDER BY ChequeDueDate DESC ", sql);
           /// DataTable dt = new DatabaseClass().ExecuteQuery(sql);
            return DB.ExecuteQuery(sql);

        }
             
    }
}