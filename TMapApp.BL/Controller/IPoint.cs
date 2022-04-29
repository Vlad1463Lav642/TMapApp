namespace TMapApp.BL.Controller
{
    public interface IPoint
    {
        /// <summary>
        /// ID точки.
        /// </summary>
        int ID { get; set; }

        /// <summary>
        /// Наименование техники в точке.
        /// </summary>
        string MachineName { get; set; }

        /// <summary>
        /// Координаты точки.
        /// </summary>
        string Coordinate { get; set; }
    }
}