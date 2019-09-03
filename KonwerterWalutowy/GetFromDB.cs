using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace KonwerterWalutowy
{
    class GetFromDB
    {
        private SqlConnection cnn;
        private string connectionString =
            "Data Source=KRZYSZTOFGR3A0A;Initial Catalog=ExchangeRatesDB;Integrated Security=True";

        private string sqlString, tempString;
        private SqlDataReader dataReader;

        public decimal Get(string day, string exchange )
        {
            try
            {
                cnn = new SqlConnection(connectionString);
                cnn.Open();
                if (day=="latest")
                {
                    sqlString = $"SELECT Top(1) {exchange} FROM RATES Order by Data desc";
                    dataReader = new SqlCommand(sqlString, cnn).ExecuteReader();
                    while (dataReader.Read())
                    {
                        tempString = $"{dataReader.GetValue(0)}";
                    }
                    dataReader.Close();
                }
                else
                {
                    sqlString = $"SELECT {exchange} FROM RATES WHERE Data = '{day}'";
                    dataReader = new SqlCommand(sqlString, cnn).ExecuteReader();
                    while (dataReader.Read())
                    {
                        tempString = $"{dataReader.GetValue(0)}";
                    }

                    dataReader.Close();
                }

               tempString = tempString.Replace(".", ",");
                
                return decimal.Parse(tempString); 

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
