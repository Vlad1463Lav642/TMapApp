namespace TMapApp.View
{
    partial class MapWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Map = new GMap.NET.WindowsForms.GMapControl();
            this.ListOfMapProviders = new MaterialSkin.Controls.MaterialComboBox();
            this.DatabaseButton = new MaterialSkin.Controls.MaterialButton();
            this.SuspendLayout();
            // 
            // Map
            // 
            this.Map.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Map.Bearing = 0F;
            this.Map.CanDragMap = true;
            this.Map.EmptyTileColor = System.Drawing.Color.Navy;
            this.Map.GrayScaleMode = false;
            this.Map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.Map.LevelsKeepInMemory = 5;
            this.Map.Location = new System.Drawing.Point(6, 70);
            this.Map.MarkersEnabled = true;
            this.Map.MaxZoom = 2;
            this.Map.MinZoom = 2;
            this.Map.MouseWheelZoomEnabled = true;
            this.Map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.Map.Name = "Map";
            this.Map.NegativeMode = false;
            this.Map.PolygonsEnabled = true;
            this.Map.RetryLoadTile = 0;
            this.Map.RoutesEnabled = true;
            this.Map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.Map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.Map.ShowTileGridLines = false;
            this.Map.Size = new System.Drawing.Size(622, 374);
            this.Map.TabIndex = 2;
            this.Map.Zoom = 0D;
            this.Map.OnMarkerEnter += new GMap.NET.WindowsForms.MarkerEnter(this.Map_OnMarkerEnter);
            this.Map.Load += new System.EventHandler(this.Map_Load);
            this.Map.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Map_MouseDown);
            this.Map.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Map_MouseMove);
            this.Map.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Map_MouseUp);
            // 
            // ListOfMapProviders
            // 
            this.ListOfMapProviders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListOfMapProviders.AutoResize = false;
            this.ListOfMapProviders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ListOfMapProviders.Depth = 0;
            this.ListOfMapProviders.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ListOfMapProviders.DropDownHeight = 174;
            this.ListOfMapProviders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ListOfMapProviders.DropDownWidth = 121;
            this.ListOfMapProviders.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.ListOfMapProviders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ListOfMapProviders.FormattingEnabled = true;
            this.ListOfMapProviders.IntegralHeight = false;
            this.ListOfMapProviders.ItemHeight = 43;
            this.ListOfMapProviders.Items.AddRange(new object[] {
            "Google",
            "Google Hybrid",
            "Bing",
            "OpenStreetMap"});
            this.ListOfMapProviders.Location = new System.Drawing.Point(634, 70);
            this.ListOfMapProviders.MaxDropDownItems = 4;
            this.ListOfMapProviders.MouseState = MaterialSkin.MouseState.OUT;
            this.ListOfMapProviders.Name = "ListOfMapProviders";
            this.ListOfMapProviders.Size = new System.Drawing.Size(158, 49);
            this.ListOfMapProviders.StartIndex = 0;
            this.ListOfMapProviders.TabIndex = 3;
            this.ListOfMapProviders.SelectedValueChanged += new System.EventHandler(this.ListOfMapProviders_SelectedValueChanged);
            // 
            // DatabaseButton
            // 
            this.DatabaseButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DatabaseButton.AutoSize = false;
            this.DatabaseButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DatabaseButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.DatabaseButton.Depth = 0;
            this.DatabaseButton.HighEmphasis = true;
            this.DatabaseButton.Icon = null;
            this.DatabaseButton.Location = new System.Drawing.Point(635, 128);
            this.DatabaseButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.DatabaseButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.DatabaseButton.Name = "DatabaseButton";
            this.DatabaseButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.DatabaseButton.Size = new System.Drawing.Size(158, 36);
            this.DatabaseButton.TabIndex = 4;
            this.DatabaseButton.Text = "База данных";
            this.DatabaseButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.DatabaseButton.UseAccentColor = false;
            this.DatabaseButton.UseVisualStyleBackColor = true;
            this.DatabaseButton.Click += new System.EventHandler(this.DatabaseButton_Click);
            // 
            // MapWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DatabaseButton);
            this.Controls.Add(this.ListOfMapProviders);
            this.Controls.Add(this.Map);
            this.MaximizeBox = false;
            this.Name = "MapWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Карта";
            this.ResumeLayout(false);

        }

        #endregion
        private GMap.NET.WindowsForms.GMapControl Map;
        private MaterialSkin.Controls.MaterialComboBox ListOfMapProviders;
        private MaterialSkin.Controls.MaterialButton DatabaseButton;
    }
}

