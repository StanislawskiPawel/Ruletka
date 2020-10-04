using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Program2
{
    class Database
    {
         OracleConnection con;
         public static Database instance = new Database();
        Database()
        {
            con = new OracleConnection();

            // create connection string using builder
            OracleConnectionStringBuilder ocsb = new OracleConnectionStringBuilder();
            ocsb.Password = "*******";
            ocsb.UserID = "msbd23";
            ocsb.DataSource = "******";


            try
            {
                // connect
                con.ConnectionString = ocsb.ConnectionString;
                con.Open();
                Console.WriteLine("Connection established (" + con.ServerVersion + ")");
            }
            catch (Exception q)
            {
                Console.WriteLine(q.Message);
            }

        }
        public void sendResult(Player p)
            {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = $"INSERT INTO RULETKA (player_name, player_money, player_id) VALUES ('{p.Name}', {p.Money}, (SELECT COALESCE(MAX(player_id),0) from RULETKA) + 1)";

            cmd.Connection = con;

            try
            {
                int aff = cmd.ExecuteNonQuery();
            }
            catch (Exception w)
            {
                MessageBox.Show("Error encountered during INSERT operation.");
            }
        }
        public void Refresh(Player p)
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = $"UPDATE  RULETKA SET player_money =  {p.Money} WHERE player_name = '{p.Name}'";
            cmd.Connection = con;

            try
            {
                int aff = cmd.ExecuteNonQuery();
            }
            catch (Exception w)
            {
                Console.WriteLine(w.Message);
            }
        }
        public List<string> ReadData()
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = "SELECT * FROM RULETKA";
            cmd.Connection = con;
            OracleDataReader reader = cmd.ExecuteReader();
            List<string> data = new List<string>();
            try
            {
                while (reader.Read())
                {
                    data.Add($"'{reader.GetString(0)}',  {reader.GetInt64(1)},  {reader.GetInt32(2)}");
                }
            }
            finally
            {
                // always call Close when done reading.
                reader.Close();
            }

            return data;
        }


    }
}
