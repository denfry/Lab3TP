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
            if (!string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                if (int.TryParse(textBox2.Text, out int baseLength) && int.TryParse(textBox1.Text, out int sideLength))
                {
                    if (baseLength > 0 && sideLength > 0)
                    {
                        if (baseLength > 6)
                        {
                            if (baseLength < 10)
                            {
                                if (baseLength < sideLength * 2 && sideLength < baseLength * 2)
                                {
                                    return true;
                                }
                                else
                                {
                                    MessageBox.Show("Стороны должны соответствовать правилу треугольника", "Ошибка");
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Длина основания должна быть < 10", "Ошибка");
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Длина основания должна быть > 6", "Ошибка");
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите положительные значения для длины основания и длины стороны", "Ошибка");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Введите числовые значения для длины основания и длины стороны", "Ошибка");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Введите значения для длины основания и длины стороны", "Ошибка");
                return false;
            }
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

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";

        }
    }
}
