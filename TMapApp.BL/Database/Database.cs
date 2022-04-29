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
        private SqlDataAdapter dataAdapter;
        private string logFolderPath = "Logs";
        private List<Point> points;
        #endregion

        public Database()
        {
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
            points = SqlQuery("MapPoints", "MapPoint_ID");

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
        /// <param name="table">Таблица БД.</param>
        /// <param name="orderBy">Столбец таблицы по которому будет осуществлятся сортировка.</param>
        /// <returns></returns>
        private List<Point> SqlQuery(string table, string orderBy)
        {
            var list = new List<Point>();

            ExceptionText = null;

            try
            {
                OpenConnection();

                var command = new SqlCommand($"SELECT * FROM {table} ORDER BY {orderBy} ASC", connection);
                var result = command.ExecuteReader();

                while (result.Read())
                    list.Add(new Point(result.GetInt32(0), result.GetString(1), result.GetString(2)));

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
        /// <returns>List<Point></returns>
        public List<Point> GetPoints()
        {
            return points;
        }

        /// <summary>
        /// Установить новые координаты для точки.
        /// </summary>
        /// <param name="coordinate">Новые координаты.</param>
        /// <param name="id">ID точки.</param>
        public void SetPoint(string coordinate, int id)
        {
            ExceptionText = null;

            try
            {
                OpenConnection();

                var command = new SqlCommand($"UPDATE MapPoints SET Coordinate = ('{coordinate}') WHERE MapPoint_ID = {++id}", connection);
                command.ExecuteNonQuery();

                CloseConnection();

                points = SqlQuery("MapPoints", "MapPoint_ID");
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