using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TMapApp.BL.Controller;
using TMapApp.BL.Database;

namespace TMapApp.View
{
    public partial class MapWindow : MaterialForm
    {
        #region Параметры
        private bool isLeftMouseDown;
        private GMapMarker selectedPoint;
        private readonly MaterialSkinManager materialSkinManager;
        private readonly IDatabase database;
        private readonly List<GMapMarker> points;
        private readonly List<GMapProvider> listProviders;
        private readonly double mapLat = 55.12543197566676;
        private readonly double mapLng = 82.64313042320175;
        #endregion

        public MapWindow()
        {
            #region Инициализация
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green400, Primary.Green700, Primary.Green100, Accent.Blue200, TextShade.WHITE);

            database = new Database();

            listProviders = new List<GMapProvider>()
            {
                GMapProviders.GoogleMap,
                GMapProviders.GoogleHybridMap,
                GMapProviders.BingMap,
                GMapProviders.OpenStreetMap
            };

            points = new List<GMapMarker>();
            #endregion
        }

        /// <summary>
        /// Инициализация маркеров.
        /// </summary>
        private void MarkersInit()
        {
            try
            {
                var pointsList = database.GetPointsInfo();
                var markers = new GMapOverlay("markers");

                foreach (var item in pointsList)
                {
                    var latLng = item.Value.Split(':');
                    var point = new PointLatLng(Convert.ToDouble(latLng[0]), Convert.ToDouble(latLng[1]));
                    GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.black_small)
                    {
                        ToolTipText = item.Key
                    };

                    points.Add(marker);

                    markers.Markers.Add(marker);
                }

                Map.Overlays.Add(markers);

                if (database.ExceptionText != null)
                    throw new Exception(database.ExceptionText.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Карта.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Map_Load(object sender, EventArgs e)
        {
            try
            {
                #region Настройки карты
                Map.MapProvider = listProviders[ListOfMapProviders.SelectedIndex];
                Map.CanDragMap = true;
                Map.MarkersEnabled = true;
                Map.Bearing = 0;

                Map.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
                Map.IgnoreMarkerOnMouseWheel = true;
                GMaps.Instance.Mode = AccessMode.ServerOnly;

                Map.Position = new PointLatLng(mapLat, mapLng);
                Map.DragButton = MouseButtons.Middle;
                Map.ShowCenter = false;

                Map.MaxZoom = 20;
                Map.Zoom = 5;
                #endregion

                MarkersInit();

                if (database.ExceptionText != null)
                    throw new Exception(database.ExceptionText.Message);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Выпадающий список с поставщиками карт.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListOfMapProviders_SelectedValueChanged(object sender, EventArgs e)
        {
            Map.MapProvider = listProviders[ListOfMapProviders.SelectedIndex];
        }

        private void Map_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
                isLeftMouseDown = true;
        }

        private void Map_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    isLeftMouseDown = false;
                    if (selectedPoint != null)
                    {
                        var pointID = points.IndexOf(selectedPoint);
                        database.SetPointCoordinate($"{selectedPoint.Position.Lat}:{selectedPoint.Position.Lng}", pointID);
                        selectedPoint = null;
                    }
                }

                if (database.ExceptionText != null)
                    throw new Exception(database.ExceptionText.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Map_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isLeftMouseDown)
            {
                if(selectedPoint != null)
                    selectedPoint.Position = Map.FromLocalToLatLng(e.X, e.Y);
            }
        }

        private void Map_OnMarkerEnter(GMapMarker item)
        {
            selectedPoint = item;
        }

        private void DatabaseButton_Click(object sender, EventArgs e)
        {
            DatabaseWindow databaseWindow = new DatabaseWindow();
            databaseWindow.Show();
        }
    }
}