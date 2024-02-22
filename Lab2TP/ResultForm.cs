using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2TP
{
    public partial class ResultForm : Form
    {

        public ResultForm()
        {
            InitializeComponent();
        }

        public void SetResults(int perimeter, int area, string triangleInfo)
        {
            label1.Text = "Периметр треугольника: " + perimeter.ToString();
            label2.Text = "Площадь треугольника: " + area.ToString();
            label3.Text = triangleInfo;
        }
    }
}
