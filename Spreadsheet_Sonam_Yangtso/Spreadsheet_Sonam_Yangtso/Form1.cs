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
        public Form1()
        {
            InitializeComponent();
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
        }
    }

}

