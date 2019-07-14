using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_of_life
{

    public class cell
    {
        public Bitmap entityElement;
        public int x;
        public int y;
    }

    public partial class Form1 : Form
    {
        int x;
        int y;
        private static Random randomInterval = new Random();

        private const int СellSize = 5;

        int[] stepOfElement = { -5, 5 };
        cell Newcell = new cell();
        

        public void timer2_Tick(object sender, EventArgs e)
        { }
        private void Form1_Load(object sender, EventArgs e)
        {
            Paint += Form1_Paint;
            ResizeRedraw = true;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)

        private void timer_Tick(object sender, EventArgs e)
        {
            Refresh();
        }

        public Form1()
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            UpdateStyles();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {


        }
    }
}
