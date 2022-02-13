using System.Collections.Generic;
using System.Data;

namespace TMapApp.BL.Controller
{
    public interface IDatabase
    {
        /// <summary>
        /// Получить список с данными о точках.
        /// </summary>
        /// <returns>Список с KeyValuePair<string,string></returns>
        List<KeyValuePair<string, string>> GetPointsInfo();

        /// <summary>
        /// Получить список координат.
        /// </summary>
        /// <returns>Список с строками.</returns>
        List<string> GetCoordinatesList();

        /// <summary>
        /// Получить список техники.
        /// </summary>
        /// <returns></returns>
        List<string> GetMachinesList();

        /// <summary>
        /// Получить список ID координат и ID техники.
        /// </summary>
        /// <returns>Список с KeyValuePair<int,int></returns>
        List<KeyValuePair<int, int>> GetPointIDs();

        /// <summary>
        /// Установить новые координаты для точки.
        /// </summary>
        /// <param name="coordinate">Новые координаты.</param>
        /// <param name="id">ID точки.</param>
        void SetPointCoordinate(string coordinate, int id);

        /// <summary>
        /// Получить таблицу из базы данных.
        /// </summary>
        /// <param name="table">Таблица БД.</param>
        /// <returns>DataTable</returns>
        DataTable GetTable(string table);

        /// <summary>
        /// Обновить таблицу в БД.
        /// </summary>
        /// <param name="dataTable">Таблица БД.</param>
        void UpdateTable(DataTable dataTable);
    }
}
