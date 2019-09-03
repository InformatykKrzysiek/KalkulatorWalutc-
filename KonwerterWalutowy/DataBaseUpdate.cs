using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Serialization.Json;

namespace KonwerterWalutowy
{
    class DataBaseUpdate
    {
        ExchangeRatesToArray _exchangeRatesToArray = new ExchangeRatesToArray();

        private SqlConnection cnn;
        private SqlDataReader dataReader;
        private SqlCommand cmd;

        private string connectionString =
            "Data Source=KRZYSZTOFGR3A0A;Initial Catalog=ExchangeRatesDB;Integrated Security=True";

        string tempString, sqlString;

        public void update(string day = "latest")
        {
            string[] array = _exchangeRatesToArray.toArray(day);
            try
            {
                cnn = new SqlConnection(connectionString);
                cnn.Open();

                //Adapter.SelectCommand = new SqlCommand($"SELECT * FROM RATES WHERE Data = {array[0]}", cnn);
                sqlString = $"SELECT * FROM RATES WHERE Data = '{array[0]}'";
                dataReader = new SqlCommand(sqlString, cnn).ExecuteReader();
                while (dataReader.Read())
                {
                    tempString = $"{dataReader.GetValue(0)}";
                }

                dataReader.Close();

                if (tempString == null)
                {
                    cmd = new SqlCommand($"INSERT INTO RATES(Data) Values('{array[0]}')", cnn);
                    cmd.ExecuteNonQuery();

                    for (int i = 1; i < array.Length; i++)
                    {
                        cmd = new SqlCommand(
                            $"Update RATES set {array[i]} = '{array[i + 1]}' WHERE Data = '{array[0]}' ", cnn);
                        cmd.ExecuteNonQuery();
                        ;
                        i++;
                    }
                }
                cnn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}