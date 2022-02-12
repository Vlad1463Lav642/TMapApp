using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using TMapApp.BL.Controller;

namespace TMapApp.BL.Database
{
    public class Database : IDatabase
    {
        #region Параметры
        private readonly SqlConnection connection;
        #endregion

        public Database()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
        }

        private List<string> SqlQuery(string column, string table, string orderBy)
        {
            var list = new List<string>();

            OpenConnection();

            var command = new SqlCommand($"SELECT {column} FROM {table} ORDER BY {orderBy} ASC",connection);
            var result = command.ExecuteReader();

            while (result.Read())
            {
                list.Add(result.GetString(0));
            }

            CloseConnection();


            return list;
        }

        private void OpenConnection()
        {
            if(connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }

        private void CloseConnection()
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        public List<KeyValuePair<string, string>> GetPointsInfo()
        {
            var points = new List<KeyValuePair<string, string>>();

            var machinesList = SqlQuery("Machine_Name", "Machines", "Machine_ID");
            var coordinatesList = SqlQuery("Coordinate", "Coordinates", "Coordinate_ID");

            OpenConnection();

            var command = new SqlCommand($"SELECT Machine_ID, Coordinate_ID FROM MapPoints ORDER BY MapPoint_ID ASC",connection);
            var result = command.ExecuteReader();

            while (result.Read())
            {
                var result2 = result.GetInt32(0);
                var result3 = result.GetInt32(1);

                points.Add(new KeyValuePair<string, string>(machinesList[--result2], coordinatesList[--result3]));
            }

            CloseConnection();

            return points;
        }
    }
}