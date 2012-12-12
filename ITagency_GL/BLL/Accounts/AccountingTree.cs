using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using System.Data;

namespace BLL.Accounts
{
    public class AccountingTree
    {
        private DatabaseClass DB = new DatabaseClass();
        public decimal GetAccountBalance(int accountID, string beginDate, string endDate, bool isCredit, int centerID, string  FinancialPeriodId)
        {
            string sql = "";
            string openingBalanceSql = "";

            decimal balance = 0;
            decimal openingBalance = 0;

            
            string subtractPart = isCredit ? "(ISNULL(SUM(Credit), 0) - ISNULL(SUM(Debit), 0)) AS balance " : "(ISNULL(SUM(Debit), 0) - ISNULL(SUM(Credit), 0)) AS balance ";
            if (beginDate == "" || endDate == "")
            {
                sql = string.Format("SELECT {1} FROM vwGLMasterDetailed WHERE IsPosted=1 AND AccountId={0} AND CenterID={2} and FinancialPeriodId={3}",
                    accountID, subtractPart, centerID, FinancialPeriodId);
                balance = decimal.Parse(DB.ExecuteScalar(sql).ToString()) + openingBalance;
            }
            if (beginDate != "")
            {
                openingBalanceSql = string.Format("SELECT {2} FROM vwGLMasterDetailed WHERE IsPosted=1 AND AccountId={0} AND TransactionDate>='{1}' AND CenterID={3} and FinancialPeriodId={4} ",
                    accountID, DatabaseClass.FormatDateArEgMDY(beginDate), subtractPart, centerID, FinancialPeriodId);

                openingBalance = decimal.Parse(DB.ExecuteScalar(openingBalanceSql).ToString());
            }


            if (endDate != "")
            {

                balance = decimal.Parse(DB.ExecuteScalar(sql).ToString()) + openingBalance;
            }

            if (CheckAccountIsNode(accountID))
                return balance;
            else
            {
                string subAccountsSql = string.Format("SELECT AccountId, (AccountName + ' - ' +AccountCode) AS AccountFullName FROM vwAccontsProfitCenters WHERE UpperAccountId={0} AND CenterID={1}  ", accountID, centerID);
                DataTable dtAccounts = DB.ExecuteQuery(subAccountsSql);
                foreach (DataRow drSubAccount in dtAccounts.Rows)
                    balance +=this.GetAccountBalance(int.Parse(drSubAccount["AccountId"].ToString()), beginDate, endDate, isCredit, centerID,FinancialPeriodId);

                return balance;
            }
        }
        public bool CheckAccountIsNode(int accountID)
        {
            string sql = string.Format("SELECT IsNode FROM AccountTree WHERE AccountId={0} ", accountID);
            return Boolean.Parse(DB.ExecuteScalar(sql).ToString());
        }
        public DataTable Account(int CenterID,int CompId)
        {
            string sql = string.Format("SELECT RecordID, AccountID, AccountName, AccountFullName, IsExpenses, IsRevenue, IsAsset, IsLiablty FROM vwTrialBalanceReportAccounts WHERE CenterID = {0} and CompId={1}  ", CenterID, CompId);
            return DB.ExecuteQuery(sql);

        }
    }
}