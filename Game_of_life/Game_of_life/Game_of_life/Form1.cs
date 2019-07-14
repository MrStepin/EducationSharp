using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace Game_of_life
{
    public partial class Form1 : Form
    {
        int NumberOfColumns = 73;
        int NumberOfRows = 36;
        Image image = new Bitmap(Resource1.entity);
        int generation = 0;
        int[,] CheckLifeInCell = new int[73, 36];

        public void Form1_Load(object sender, EventArgs e)
        {    
            DataGridViewImageColumn[] column = new DataGridViewImageColumn[NumberOfColumns];

            for (int i = 0; i < NumberOfColumns; i++)
            {
                column[i] = new DataGridViewImageColumn();
                column[i].Name = "Number" + i;
                column[i].Width = 10;
            }
            this.dataGridView1.Columns.AddRange(column);

            for (int i = 0; i < NumberOfRows; i++)
            {
                dataGridView1.Rows.Add();
            }
            dataGridView1[40, 15].Value = image;            
            dataGridView1[39, 17].Value = image;
            dataGridView1[41, 16].Value = image;
            dataGridView1[40, 17].Value = image;
            dataGridView1[41, 17].Value = image;

            dataGridView1[3, 3].Value = image;
            dataGridView1[3, 4].Value = image;
            dataGridView1[4, 3].Value = image;

            dataGridView1[14, 8].Value = image;
            dataGridView1[14, 10].Value = image;
            dataGridView1[15, 11].Value = image; 
            dataGridView1[16, 11].Value = image;
            dataGridView1[17, 8].Value = image;
            dataGridView1[17, 11].Value = image;
            dataGridView1[18, 9].Value = image;
            dataGridView1[18, 10].Value = image;
            dataGridView1[18, 11].Value = image;

            dataGridView1[1, 21].Value = image;
            dataGridView1[1, 23].Value = image;
            dataGridView1[2, 24].Value = image;
            dataGridView1[3, 24].Value = image;
            dataGridView1[4, 21].Value = image;
            dataGridView1[4, 24].Value = image;
            dataGridView1[5, 22].Value = image;
            dataGridView1[5, 23].Value = image;
            dataGridView1[5, 24].Value = image;
            for (int i = 1; i < (NumberOfColumns - 1); i++)
            {
                for (int j = 1; j < (NumberOfRows - 1); j++)
                {
                    if (dataGridView1[i, j].Value == image) { CheckLifeInCell[i, j] = 1; }
                    if (dataGridView1[i, j].Value == null) { CheckLifeInCell[i, j] = 0; }
                }
            }
            DateTime TimeOut = DateTime.Now.AddSeconds(4);
            while (generation < 100)
            {                
                timer_Tick(sender, e);
                generation++;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
            UpdateStyles();
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += timer_Tick;
            timer.Start();

            System.Timers.Timer timerForGeneration = new System.Timers.Timer();
            timerForGeneration.Enabled = true;
            timerForGeneration.AutoReset = false;
            timerForGeneration.Start();
        }
        

        private void timer_Tick(object sender, EventArgs e)
        {
            for (int i = 1; i < (NumberOfColumns - 1); i ++)
                {
                    for (int j = 1; j < (NumberOfRows - 1); j ++)
                    {                      
                        if (dataGridView1[i, j].Value == image)
                        {
                            int CountOfNeighborsForLifeCell = 0;
                            for (int CheckNeighborsColumns = (i - 1); CheckNeighborsColumns < (i + 2); CheckNeighborsColumns ++)
                            {
                                for (int CheckNeighborsRows = (j - 1); CheckNeighborsRows < (j + 2); CheckNeighborsRows ++)
                                {
                                    if (dataGridView1[CheckNeighborsColumns, CheckNeighborsRows].Value == image) { CountOfNeighborsForLifeCell ++; }
                                }
                            }
                            if (CountOfNeighborsForLifeCell < 3) {CheckLifeInCell[i, j] = 0; }
                            if (CountOfNeighborsForLifeCell > 4) { CheckLifeInCell[i, j] = 0;  }
                        }

                        if (dataGridView1[i, j].Value == null)
                        {
                            int CountOfNeighborsForDeadCell = 0;
                            for (int CheckNeighborsColumns = (i - 1); CheckNeighborsColumns < (i + 2); CheckNeighborsColumns ++)
                            {
                                for (int CheckNeighborsRows = (j - 1); CheckNeighborsRows < (j + 2); CheckNeighborsRows ++)
                                {
                                    if (dataGridView1[CheckNeighborsColumns, CheckNeighborsRows].Value == image) { CountOfNeighborsForDeadCell++; }                                   
                                }
                            }
                         if (CountOfNeighborsForDeadCell == 3) {CheckLifeInCell[i, j] = 1;}
                        }
                    }
                }
                for (int i = 1; i < (NumberOfColumns - 1); i ++)
                {
                    for (int j = 1; j < (NumberOfRows - 1); j ++)
                    {
                        if (CheckLifeInCell[i, j] == 1) { dataGridView1[i, j].Value = image; }
                        if (CheckLifeInCell[i, j] == 0) { dataGridView1[i, j].Value = null; }
                    }
                }
        }
    }
}
