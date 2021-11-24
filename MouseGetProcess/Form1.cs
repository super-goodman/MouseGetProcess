using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseGetProcess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            pictureBox1.BackColor = Control.DefaultBackColor;
            MouseGetProcessClass.POINTAPI point = new MouseGetProcessClass.POINTAPI();
            MouseGetProcessClass.GetCursorPos(ref point);//获取当前鼠标坐标
            int hwnd = MouseGetProcessClass.WindowFromPoint(point.X, point.Y);//获取指定坐标处窗口的句柄
            StringBuilder name = new StringBuilder(256);
            MouseGetProcessClass.GetWindowText(hwnd, name, 256);
            textBox1.Text = name.ToString();

            uint processID = default;
            MouseGetProcessClass.GetWindowThreadProcessId(hwnd, out processID);
            textBox2.Text = processID.ToString();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.BackColor = Color.Black;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
