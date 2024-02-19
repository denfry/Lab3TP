using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Lab2TP.MainForm;

namespace Lab2TP
{
    public partial class InputForm : Form
    {
        
        public InputForm()
        {
            InitializeComponent();
            
            
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Введите значения для длины основания и длины стороны", "Ошибка");
                return false;
            }

            if (!int.TryParse(textBox1.Text, out int baseLength) || !int.TryParse(textBox2.Text, out int sideLength))
            {
                MessageBox.Show("Введите числовые значения для длины основания и длины стороны", "Ошибка");
                return false;
            }

            if (baseLength <= 0 || sideLength <= 0)
            {
                MessageBox.Show("Введите положительные значения для длины основания и длины стороны", "Ошибка");
                return false;
            }

            if (baseLength >= 6 && baseLength <= 10)
            {
                if (baseLength >= sideLength + sideLength || sideLength >= baseLength + baseLength)
                {
                    MessageBox.Show("Стороны должны соответствовать правилу треугольника", "Ошибка");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Длина основания должна быть от 6 до 10", "Ошибка");
                return false;
            }

            return true;
        }
        public int GetBaseLength()
        {
            if (int.TryParse(textBox1.Text, out int baseLength))
                return baseLength;
            else
                return -1;
        }

        public int GetSideLength()
        {
            if (int.TryParse(textBox2.Text, out int sideLength))
                return sideLength;
            else
                return -1;
        }



        private void ContinueButton(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                isoscelesTriangle activeTriangle = TriangleManager.GetActiveTriangle();
                if (activeTriangle != null)
                {
                    activeTriangle.SetBaseLength(int.Parse(textBox1.Text));
                    activeTriangle.SetSideLength(int.Parse(textBox2.Text));
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


        private void CancelButton(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
