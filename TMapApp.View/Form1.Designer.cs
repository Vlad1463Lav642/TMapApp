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
            this.RemoveButton = new MaterialSkin.Controls.MaterialButton();
            this.AddButton = new MaterialSkin.Controls.MaterialButton();
            this.Map = new GMap.NET.WindowsForms.GMapControl();
            this.ListOfMapProviders = new MaterialSkin.Controls.MaterialComboBox();
            this.SuspendLayout();
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RemoveButton.AutoSize = false;
            this.RemoveButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.RemoveButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.RemoveButton.Depth = 0;
            this.RemoveButton.HighEmphasis = true;
            this.RemoveButton.Icon = null;
            this.RemoveButton.Location = new System.Drawing.Point(635, 118);
            this.RemoveButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.RemoveButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.RemoveButton.Size = new System.Drawing.Size(158, 36);
            this.RemoveButton.TabIndex = 1;
            this.RemoveButton.Text = "Удалить";
            this.RemoveButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.RemoveButton.UseAccentColor = false;
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.AutoSize = false;
            this.AddButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AddButton.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.AddButton.Depth = 0;
            this.AddButton.HighEmphasis = true;
            this.AddButton.Icon = null;
            this.AddButton.Location = new System.Drawing.Point(635, 70);
            this.AddButton.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.AddButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.AddButton.Name = "AddButton";
            this.AddButton.NoAccentTextColor = System.Drawing.Color.Empty;
            this.AddButton.Size = new System.Drawing.Size(158, 36);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Добавить";
            this.AddButton.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.AddButton.UseAccentColor = false;
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
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
            this.ListOfMapProviders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            "Yandex",
            "Bing",
            "OpenStreetMap"});
            this.ListOfMapProviders.Location = new System.Drawing.Point(635, 163);
            this.ListOfMapProviders.MaxDropDownItems = 4;
            this.ListOfMapProviders.MouseState = MaterialSkin.MouseState.OUT;
            this.ListOfMapProviders.Name = "ListOfMapProviders";
            this.ListOfMapProviders.Size = new System.Drawing.Size(158, 49);
            this.ListOfMapProviders.StartIndex = 0;
            this.ListOfMapProviders.TabIndex = 3;
            this.ListOfMapProviders.SelectedValueChanged += new System.EventHandler(this.ListOfMapProviders_SelectedValueChanged);
            // 
            // MapWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ListOfMapProviders);
            this.Controls.Add(this.Map);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.RemoveButton);
            this.MaximizeBox = false;
            this.Name = "MapWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Карта";
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialButton RemoveButton;
        private MaterialSkin.Controls.MaterialButton AddButton;
        private GMap.NET.WindowsForms.GMapControl Map;
        private MaterialSkin.Controls.MaterialComboBox ListOfMapProviders;
    }
}

