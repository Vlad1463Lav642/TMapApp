using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using TMapApp.BL.Controller;
using System;
using System.IO;
using System.Text;

namespace TMapApp.BL.Database
{
    /// <summary>
    /// Взаимодействие с базой данных.
    /// </summary>
    public class Database : IDatabase
    {
        #region Параметры
        private readonly SqlConnection connection;
        private List<string> coordinatesList;
        private readonly List<string> machinesList;
        private List<KeyValuePair<int, int>> pointsIDs;
        private SqlDataAdapter dataAdapter;
        private string logFolderPath = $"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}/Logs";
        #endregion

        public Database()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
            coordinatesList = SqlQuery("Coordinate", "Coordinates", "Coordinate_ID");
            machinesList = SqlQuery("Machine_Name", "Machines", "Machine_ID");
            pointsIDs = SqlQuery("MapPoints", "MapPoint_ID");

            Directory.CreateDirectory(logFolderPath);
        }

        /// <summary>
        /// Текст последней ошибки.
        /// </summary>
        public Exception ExceptionText
        {
            get;
            private set;
        }

        /// <summary>
        /// Осуществить запрос к таблице БД.
        /// </summary>
        /// <param name="column">Столбец таблицы у которого нужно получить данные.</param>
        /// <param name="table">Таблица БД.</param>
        /// <param name="orderBy">Столбец таблицы по которому будет осуществлятся сортировка.</param>
        /// <returns></returns>
        private List<string> SqlQuery(string column, string table, string orderBy)
        {
            var list = new List<string>();

            ExceptionText = null;

            try
            {
                OpenConnection();

                var command = new SqlCommand($"SELECT {column} FROM {table} ORDER BY {orderBy} ASC", connection);
                var result = command.ExecuteReader();

                while (result.Read())
                    list.Add(result.GetString(0));

                CloseConnection();
            }
            catch (SqlException ex)
            {
                CreateLogException(ex);
            }

            return list;
        }

        /// <summary>
        /// Осуществить запрос к таблице БД.
        /// </summary>
        /// <param name="table">Таблица БД.</param>
        /// <param name="orderBy">Столбец таблицы по которому будет осуществлятся сортировка.</param>
        /// <returns></returns>
        private List<KeyValuePair<int,int>> SqlQuery(string table, string orderBy)
        {
            var list = new List<KeyValuePair<int, int>>();

            ExceptionText = null;

            try
            {
                OpenConnection();

                var command = new SqlCommand($"SELECT * FROM {table} ORDER BY {orderBy} ASC", connection);
                var result = command.ExecuteReader();

                while (result.Read())
                    list.Add(new KeyValuePair<int, int>(result.GetInt32(1), result.GetInt32(2)));

                CloseConnection();
            }
            catch (SqlException ex)
            {
                CreateLogException(ex);
            }

            return list;
        }

        /// <summary>
        /// Открывает соединение с базой данных.
        /// </summary>
        private void OpenConnection()
        {
            ExceptionText = null;

            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();
            }
            catch(Exception ex)
            {
                CreateLogException(ex);
            }
        }

        /// <summary>
        /// Закрывает соединение с базой данных.
        /// </summary>
        private void CloseConnection()
        {
            ExceptionText = null;

            try
            {
                if (connection.State != ConnectionState.Closed)
                    connection.Close();
            }
            catch(Exception ex)
            {
                CreateLogException(ex);
            }
        }

        /// <summary>
        /// Получить список с данными о точках.
        /// </summary>
        /// <returns>Список с KeyValuePair<string,string></returns>
        public List<KeyValuePair<string, string>> GetPointsInfo()
        {
            var points = new List<KeyValuePair<string, string>>();

            ExceptionText = null;

            try
            {
                foreach (var item in pointsIDs)
                {
                    var result1 = item.Key;
                    var result2 = item.Value;

                    points.Add(new KeyValuePair<string, string>(machinesList[--result1], coordinatesList[--result2]));
                }
            }
            catch (Exception ex)
            {
                CreateLogException(ex);
            }

            return points;
        }

        /// <summary>
        /// Получить список координат.
        /// </summary>
        /// <returns>Список с строками.</returns>
        public List<string> GetCoordinatesList()
        {
            return coordinatesList;
        }

        /// <summary>
        /// Установить новые координаты для точки.
        /// </summary>
        /// <param name="coordinate">Новые координаты.</param>
        /// <param name="id">ID точки.</param>
        public void SetPointCoordinate(string coordinate, int id)
        {
            ExceptionText = null;

            try
            {
                if (coordinatesList.Contains(coordinate))
                {
                    var coordinateID = coordinatesList.IndexOf(coordinate);

                    OpenConnection();

                    var command = new SqlCommand($"UPDATE MapPoints SET Coordinate_ID = {++coordinateID} WHERE MapPoint_ID = {++id}", connection);
                    command.ExecuteNonQuery();

                    CloseConnection();
                }
                else
                {
                    Console.WriteLine(coordinate);
                    OpenConnection();

                    var command = new SqlCommand($"INSERT INTO Coordinates VALUES('{coordinate}');", connection);
                    command.ExecuteNonQuery();

                    CloseConnection();

                    coordinatesList = SqlQuery("Coordinate", "Coordinates", "Coordinate_ID");

                    OpenConnection();

                    var command2 = new SqlCommand($"UPDATE MapPoints SET Coordinate_ID = {coordinatesList.Count} WHERE MapPoint_ID = {++id}", connection);
                    command2.ExecuteNonQuery();

                    CloseConnection();
                }

                pointsIDs = SqlQuery("MapPoints", "MapPoint_ID");
            }
            catch (SqlException ex)
            {
                CreateLogException(ex);
            }
        }

        /// <summary>
        /// Получить таблицу из базы данных.
        /// </summary>
        /// <param name="table">Таблица БД.</param>
        /// <returns>DataTable</returns>
        public DataTable GetTable(string table)
        {
            var dataTable = new DataTable();

            ExceptionText = null;

            try
            {
                OpenConnection();

                dataAdapter = new SqlDataAdapter($"SELECT *, 'Delete' AS [Command] FROM {table}", connection);

                var sqlBuilder = new SqlCommandBuilder(dataAdapter);

                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();

                dataAdapter.Fill(dataTable);

                CloseConnection();
            }
            catch(SqlException ex)
            {
                CreateLogException(ex);
            }

            return dataTable;
        }

        /// <summary>
        /// Обновить таблицу в БД.
        /// </summary>
        /// <param name="dataTable">Таблица БД.</param>
        public void UpdateTable(DataTable dataTable)
        {
            ExceptionText = null;

            try
            {
                dataAdapter.Update(dataTable);
            }
            catch(SqlException ex)
            {
                CreateLogException(ex);
            }
        }

        /// <summary>
        /// Получить список техники.
        /// </summary>
        /// <returns></returns>
        public List<string> GetMachinesList()
        {
            return machinesList;
        }

        /// <summary>
        /// Получить список ID координат и ID техники.
        /// </summary>
        /// <returns>Список с KeyValuePair<int,int></returns>
        public List<KeyValuePair<int,int>> GetPointIDs()
        {
            return pointsIDs;
        }

        /// <summary>
        /// Создает log файл в папке Logs и записывает exception в параметр.
        /// </summary>
        /// <param name="ex">Текст ошибки.</param>
        private void CreateLogException(Exception ex)
        {
            ExceptionText = ex;
            
            using (var logFile = File.Create($"{logFolderPath}/{DateTime.Today.Day}.{DateTime.Today.Month}-{DateTime.Now.Hour}.{DateTime.Now.Minute}.{DateTime.Now.Second}.log"))
            {
                using (var fileWriter = new StreamWriter(logFile, Encoding.UTF8))
                    fileWriter.WriteLine(ex.Message);
            }
        }
    }
}