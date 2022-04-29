namespace TMapApp.View
{
    partial class DatabaseWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DatabaseView = new System.Windows.Forms.DataGridView();
            this.DatabaseComboBox = new MaterialSkin.Controls.MaterialComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.DatabaseView)).BeginInit();
            this.SuspendLayout();
            // 
            // DatabaseView
            // 
            this.DatabaseView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DatabaseView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DatabaseView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.DatabaseView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DatabaseView.Location = new System.Drawing.Point(6, 125);
            this.DatabaseView.Name = "DatabaseView";
            this.DatabaseView.Size = new System.Drawing.Size(788, 319);
            this.DatabaseView.TabIndex = 0;
            this.DatabaseView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DatabaseView_CellContentClick);
            this.DatabaseView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DatabaseView_CellValueChanged);
            this.DatabaseView.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.DatabaseView_UserAddedRow);
            // 
            // DatabaseComboBox
            // 
            this.DatabaseComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DatabaseComboBox.AutoResize = false;
            this.DatabaseComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DatabaseComboBox.Depth = 0;
            this.DatabaseComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.DatabaseComboBox.DropDownHeight = 174;
            this.DatabaseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DatabaseComboBox.DropDownWidth = 121;
            this.DatabaseComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.DatabaseComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DatabaseComboBox.FormattingEnabled = true;
            this.DatabaseComboBox.IntegralHeight = false;
            this.DatabaseComboBox.ItemHeight = 43;
            this.DatabaseComboBox.Items.AddRange(new object[] {
            "MapPoints"});
            this.DatabaseComboBox.Location = new System.Drawing.Point(6, 70);
            this.DatabaseComboBox.MaxDropDownItems = 4;
            this.DatabaseComboBox.MouseState = MaterialSkin.MouseState.OUT;
            this.DatabaseComboBox.Name = "DatabaseComboBox";
            this.DatabaseComboBox.Size = new System.Drawing.Size(788, 49);
            this.DatabaseComboBox.StartIndex = 0;
            this.DatabaseComboBox.TabIndex = 1;
            this.DatabaseComboBox.SelectedValueChanged += new System.EventHandler(this.DatabaseComboBox_SelectedValueChanged);
            // 
            // DatabaseWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DatabaseComboBox);
            this.Controls.Add(this.DatabaseView);
            this.MaximizeBox = false;
            this.Name = "DatabaseWindow";
            this.ShowIcon = false;
            this.Text = "База данных";
            this.Load += new System.EventHandler(this.DatabaseWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DatabaseView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DatabaseView;
        private MaterialSkin.Controls.MaterialComboBox DatabaseComboBox;
    }
}