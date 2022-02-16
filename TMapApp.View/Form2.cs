using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Data;
using System.Windows.Forms;
using TMapApp.BL.Controller;
using TMapApp.BL.Database;

namespace TMapApp.View
{
    public partial class DatabaseWindow : MaterialForm
    {
        #region Параметры
        private readonly MaterialSkinManager materialSkinManager;
        private readonly IDatabase database;
        private string selectedDataTable;
        private bool isRowAdded;
        private bool isValueUpdated;
        #endregion
        public DatabaseWindow()
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

            selectedDataTable = DatabaseComboBox.SelectedItem.ToString();
        }

        private void DataTableLoad()
        {
            try
            {
                var dataTable = database.GetTable(selectedDataTable);

                DatabaseView.DataSource = dataTable;
                var columnCounter = DatabaseView.Columns.Count - 1;

                for (var i = 0; i < DatabaseView.Rows.Count; i++)
                {
                    var linkCell = new DataGridViewLinkCell();
                    DatabaseView[columnCounter, i] = linkCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DatabaseWindow_Load(object sender, EventArgs e)
        {
            DataTableLoad();
        }

        private void DatabaseComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            selectedDataTable = DatabaseComboBox.SelectedItem.ToString();
            DataTableLoad();
        }

        private void DatabaseView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var columnCounter = DatabaseView.Columns.Count - 1;

                if(e.ColumnIndex == columnCounter)
                {
                    var task = DatabaseView.Rows[e.RowIndex].Cells[columnCounter].Value.ToString();
                    var dataTable = database.GetTable(selectedDataTable);
                    var rowIndex = e.RowIndex;

                    switch (task)
                    {
                        case "Delete":
                            if(MessageBox.Show("Вы действительно хотите удалить эту строку?","Удаление",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                DatabaseView.Rows.RemoveAt(rowIndex);

                                dataTable.Rows[rowIndex].Delete();
                            }
                            break;

                        case "Insert":
                            if (MessageBox.Show("Вы действительно хотите добавить новую строку?", "Добавление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                var rowCounter = DatabaseView.Rows.Count - 2;

                                var row = dataTable.NewRow();

                                for (int i = 0; i < DatabaseView.Columns.Count; i++)
                                {
                                    var columnName = DatabaseView.Columns[i].Name;

                                    row[columnName] = DatabaseView.Rows[rowCounter].Cells[columnName].Value;
                                }

                                dataTable.Rows.Add(row);
                                DatabaseView.Rows[rowIndex].Cells[columnCounter].Value = "Delete";

                                isRowAdded = false;
                            }
                            break;

                        case "Update":

                            rowIndex = e.RowIndex;

                            if (MessageBox.Show("Вы действительно хотите изменить данные?", "Изменение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                for (int i = 0; i < DatabaseView.Columns.Count; i++)
                                {
                                    var columnName = DatabaseView.Columns[i].Name;

                                    dataTable.Rows[rowIndex][columnName] = DatabaseView.Rows[rowIndex].Cells[DatabaseView.Columns[i].Name].Value;
                                }
                                isValueUpdated = false;
                            }
                            break;
                    }
                    database.UpdateTable(dataTable);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DatabaseView_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (!isRowAdded)
                {
                    isRowAdded = true;
                    var rowCounter = DatabaseView.Rows.Count - 2;
                    var row = DatabaseView.Rows[rowCounter];
                    var columnCounter = DatabaseView.Columns.Count - 1;

                    var linkCell = new DataGridViewLinkCell();
                    DatabaseView[columnCounter, rowCounter] = linkCell;
                    row.Cells["Command"].Value = "Insert";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DatabaseView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (!isValueUpdated && !isRowAdded)
                {
                    isValueUpdated = true;
                    var rowIndex = DatabaseView.SelectedCells[0].RowIndex;
                    var editedRow = DatabaseView.Rows[rowIndex];
                    var linkCell = new DataGridViewLinkCell();
                    var columnCounter = DatabaseView.Columns.Count - 1;

                    DatabaseView[columnCounter, rowIndex] = linkCell;
                    editedRow.Cells["Command"].Value = "Update";
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
