using Cpts321;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spreadsheet_Sonam_Yangtso
{
    public partial class Form1 : Form
    {
        private Spreadsheet sheet;
        public Form1()
        {
            InitializeComponent();
            sheet = new Spreadsheet(50, 26);
            //sheet.CellPropertyChanged +=

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for(int column = 065; column<=090; column++)
            {
                char character = (char)column;
                this.dataGridView1.Columns.Add(character.ToString(), character.ToString());
            }

            for (int row = 1;row<= 50;row++ )
            {
                this.dataGridView1.Rows.Add(row);
                this.dataGridView1.Rows[row - 1].HeaderCell.Value = row.ToString();
            }
            sheet.CellPropertyChanged += OnCellPropertyChanged;
        }

        private void OnCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            SpreadsheetCell cellChanged = (SpreadsheetCell)sender;
            if (cellChanged != null && e.PropertyName == "Value")
            {
                this.dataGridView1.Rows[cellChanged.RowIndex].Cells[cellChanged.ColumnIndex].Value = cellChanged.Value;
                this.sheet.ArrayOfCells[cellChanged.RowIndex, cellChanged.ColumnIndex].Text = cellChanged.Text;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }

}

