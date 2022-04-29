using TMapApp.BL.Controller;

namespace TMapApp.BL.Database
{
    public class Point : IPoint
    {
        /// <summary>
        /// ID точки.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Наименование техники в точке.
        /// </summary>
        public string MachineName { get; set; }

        /// <summary>
        /// Координаты точки.
        /// </summary>
        public string Coordinate { get; set; }

        public Point(int id, string machineName, string coordinate)
        {
            ID = id;
            MachineName = machineName;
            Coordinate = coordinate;
        }
    }
}