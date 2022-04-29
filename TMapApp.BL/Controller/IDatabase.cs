using System;
using System.Collections.Generic;
using System.Data;
using TMapApp.BL.Database;

namespace TMapApp.BL.Controller
{
    public interface IDatabase
    {
        /// <summary>
        /// Получить список с данными о точках.
        /// </summary>
        /// <returns>List<Point></returns>
        List<Point> GetPoints();

        /// <summary>
        /// Текст последней ошибки.
        /// </summary>
        Exception ExceptionText { get; }

        /// <summary>
        /// Установить новые координаты для точки.
        /// </summary>
        /// <param name="coordinate">Новые координаты.</param>
        /// <param name="id">ID точки.</param>
        void SetPoint(string coordinate, int id);

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
