using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Connection
{
    public class ConnectionStatement
    {
        private Connection connection = new Connection();
        private SqlDataReader dataReader, dataReader2;
        private String query;
        private Boolean response;
        private String logTransactionType;

        #region "public constant declarations"
        public const Int32 WITHDRAW = 0;
        public const Int32 TRANSFER = 1;
        public const Int32 ELECTRIC_BILLS = 2;
        public const Int32 CHECK_BALANCE = 3;
        public const Int32 WATER_BILLS = 4;
        public const Int32 PHONE_BILLS = 5;
        #endregion

        #region "Login Functions"
        public Boolean adminLogin(String username, String password)
        {
            query = "select * from dbo.admin where admin_username " +
                "= '" + username + "' and admin_password = '" + password + "'";


            try
            {
                dataReader = connection.getDataReader(query);
                dataReader.Read();

                if (password == dataReader.GetString(2))
                {
                    response = true;
                }
                else
                {
                    response = false;
                }
            }
            catch (Exception ex)
            {
                response = false;
            }
            return response;
        }

        #endregion

        #region "Fetch Account Details"

        //fetch all accounts
        public SqlDataReader fetchAllAccount()
        {
            try
            {
                query = "select * from dbo.Accounts";
                dataReader = connection.getDataReader(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataReader;

        }

        public SqlDataReader fetchLogs()
        {
            try
            {
                query = "select * from dbo.atm_log";
                dataReader2 = connection.getDataReader(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataReader2;
        }

        //return details of a specific account
        public Array fetchSpecificAccount(string accountNumber)
        {
            String[] accountDetails = new String[6];
            query = "select * from dbo.Accounts where account_number = '" + accountNumber + "'";

            try
            {
                dataReader2 = connection.getDataReader(query);
                dataReader2.Read();

                for (int counter = 0; counter < 6; counter++)
                {
                    accountDetails[counter] = dataReader2.GetValue(counter).ToString();
                }
            }
            catch (Exception ex)
            {
            }
            dataReader2.Close();

            return accountDetails;

        }

        public Boolean checkAccountExists(String accountNumber)
        {
            //  dataReader2.Close();
            //  dataReader.Close();

            query = "select * from dbo.Accounts where account_number = '" + accountNumber + "'";

            try
            {
                dataReader2 = connection.getDataReader(query);
                dataReader2.Read();

                if (dataReader2.HasRows == true)
                {
                    response = true;
                    dataReader2.Close();
                }
                else
                {
                    response = false;
                }
            }
            catch (Exception ex)
            {
                response = false;
            }
            return response;
        }

        #endregion


        #region "Update account details"

        public Boolean updateAccount(String accountNumber, String firstName, String lastName,
            String balance, String address)
        {
            try
            {
                query = "update dbo.Accounts set first_name = '" + firstName + "'" +
                    ", last_name = '" + lastName + "', account_balance = '" + balance +
                    "', account_address = '" + address + "' where account_number = '" +
                    accountNumber + "'";
                connection.executeQuery(query);
                response = true;
            }
            catch (Exception ex)
            {
                response = false;
            }
            return response;
        }
        public Boolean updateBalance(String accountNumber, String balance)
        {
            try
            {
                query = "update dbo.Accounts set account_balance = '" + balance + "' where account_number = '" + accountNumber + "'";
                connection.executeQuery(query);
                response = true;
            }
            catch (Exception ex)
            {
                response = false;
            }
            return response;
        }

        public Boolean transferfund(String transferAccountNumber, String transferAmount)
        {
            try
            {
                query = "update dbo.Accounts set account_balance = account_balance + '" + transferAmount + "' where account_number" +
                        " = '" + transferAccountNumber + "'";
                connection.executeQuery(query);
                response = true;
            }
            catch (Exception ex)
            {
                response = false;
            }
            return response;
        }
        #endregion

        #region "Delete Statements"

        public Boolean deleteAccount(String accountNumber)
        {
            try
            {
                query = "delete from dbo.Accounts where account_number = '" + accountNumber + "'";
                connection.executeQuery(query);
                response = true;
            }
            catch (Exception ex)
            {
                response = false;
            }
            return response;

        }

        #endregion

        #region "Insert Statements"

        public Boolean createNewAccount(String accountNumber, String firstName, String lastName,
            String balance, String address)
        {
            try
            {
                query = "insert into dbo.Accounts (account_number, first_name, last_name" +
                ", account_address, account_balance) values ('" + accountNumber + "','"
                + firstName + "','" + lastName + "','" + address + "','" + balance + "')";

                connection.executeQuery(query);
                response = true;
            }
            catch (Exception ex)
            {
                response = false;
                Console.Out.Write(ex.ToString());
            }
            return response;
        }

        public void createLog(String accountNumber, Int32 transactionType, String description)
        {
            switch (transactionType)
            {
                case TRANSFER:
                    {
                        logTransactionType = "Transfer";
                        break;
                    }
                case WITHDRAW:
                    {
                        logTransactionType = "Withdraw";
                        break;
                    }
                case ELECTRIC_BILLS:
                    {
                        logTransactionType = "Electric-Bills";
                        break;
                    }
                case CHECK_BALANCE:
                    {
                        logTransactionType = "Balance-Check";
                        break;
                    }
                case WATER_BILLS:
                    {
                        logTransactionType = "Water-Bills";
                        break;
                    }
                case PHONE_BILLS:
                    {
                        logTransactionType = "Phone-Bills";
                        break;
                    }
                default:
                    {
                        logTransactionType = "General";
                        break;
                    }
            }
            query = "insert into dbo.atm_log (account_number, transaction_type, description) values ('" + accountNumber + "','" + logTransactionType + "','" + description + "')";
            connection.executeQuery(query);
        }

        #endregion
    }

}
