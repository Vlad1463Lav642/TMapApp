using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TMapApp.View
{
    public partial class MapWindow : MaterialForm
    {
        #region Параметры
        private bool isLeftMouseDown;
        private GMapMarker selectedPoint;
        private readonly MaterialSkinManager materialSkinManager;
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
            #endregion
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {

        }

        private void Map_Load(object sender, EventArgs e)
        {
            Map.MapProvider = listProviders[ListOfMapProviders.SelectedIndex];
            var lat = Convert.ToDouble(10);
            var lng = Convert.ToDouble(10);
            Map.Position = new PointLatLng(lat, lng);
            Map.DragButton = MouseButtons.Middle;
            Map.ShowCenter = false;

            var point = new PointLatLng(lat,lng);
            GMapMarker marker = new GMarkerGoogle(point,GMarkerGoogleType.black_small);

            var markers = new GMapOverlay("markers");
            markers.Markers.Add(marker);
            Map.Overlays.Add(markers);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {

        }

        private void ListOfMapProviders_SelectedValueChanged(object sender, EventArgs e)
        {
            Map.MapProvider = listProviders[ListOfMapProviders.SelectedIndex];
        }

        private void Map_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                selectedPoint = item;
            }
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
    }
}