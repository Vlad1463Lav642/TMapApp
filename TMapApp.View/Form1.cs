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
        private readonly List<GMapProvider> listProviders = new List<GMapProvider>()
        {
            GMapProviders.GoogleMap,
            GMapProviders.YandexMap,
            GMapProviders.BingMap,
            GMapProviders.OpenStreetMap
        };
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
            #endregion
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {

        }

        private void MarkersInit()
        {
            var pointsList = database.GetPointsInfo();
            var markers = new GMapOverlay("markers");

            foreach (var item in pointsList)
            {
                string[] latLng = item.Value.Split(':');
                var point = new PointLatLng(Convert.ToDouble(latLng[0]),Convert.ToDouble(latLng[1]));
                GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.black_small);

                markers.Markers.Add(marker);
            }

            Map.Overlays.Add(markers);
        }

        private void Map_Load(object sender, EventArgs e)
        {
            #region Настройки карты
            Map.MapProvider = listProviders[ListOfMapProviders.SelectedIndex];
            Map.CanDragMap = true;
            Map.MarkersEnabled = true;
            Map.Bearing = 0;
            Map.GrayScaleMode = true;
            Map.Dock = DockStyle.None;

            Map.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
            Map.IgnoreMarkerOnMouseWheel = true;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;

            Map.Position = new PointLatLng(10, 10);
            Map.DragButton = MouseButtons.Middle;
            Map.ShowCenter = false;

            Map.MinZoom = 10;
            Map.MaxZoom = 100;
            #endregion

            MarkersInit();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {

        }

        private void ListOfMapProviders_SelectedValueChanged(object sender, EventArgs e)
        {
            Map.MapProvider = listProviders[ListOfMapProviders.SelectedIndex];
        }

        private void Map_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                isLeftMouseDown = true;
            }
        }

        private void Map_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isLeftMouseDown = false;
                selectedPoint = null;
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
    }
}