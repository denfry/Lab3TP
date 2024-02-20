using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2TP
{
    public partial class MainForm : Form

    {
        private isoscelesTriangle А;
        isoscelesTriangle triangle1 = new isoscelesTriangle(7, 12);
        isoscelesTriangle triangle2 = new isoscelesTriangle(8, 13);
        isoscelesTriangle triangle3 = new isoscelesTriangle(9, 14);
        isoscelesTriangle triangle4 = new isoscelesTriangle(8, 15);
        
        public MainForm()
        {
            InitializeComponent();
            radioButton1.CheckedChanged += RadioButton_CheckedChanged;
            radioButton2.CheckedChanged += RadioButton_CheckedChanged;
            radioButton3.CheckedChanged += RadioButton_CheckedChanged;
            radioButton4.CheckedChanged += RadioButton_CheckedChanged;
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            if (radioButton != null && radioButton.Checked)
            {
                if (radioButton == radioButton1)
                    А = triangle1;
                else if (radioButton == radioButton2)
                    А = triangle2;
                else if (radioButton == radioButton3)
                    А = triangle3;
                else if (radioButton == radioButton4)
                    А = triangle4;
            }
        }

        private void InputButton(object sender, EventArgs e)
        {
            if (А == null)
            {
                MessageBox.Show("Объект не выбран", "Внимание!");
                return;
            }

            
            InputForm inputForm = new InputForm();
            DialogResult result = inputForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                int baseLength = inputForm.GetBaseLength();
                int sideLength = inputForm.GetSideLength();

                А.SetBaseLength(baseLength);
                А.SetSideLength(sideLength);
            }
        }
        private void OutputButton(object sender, EventArgs e)
        {
            if (А != null)
            {
                ResultForm resultForm = new ResultForm();
                resultForm.SetResults(А.calculatePerimeter(), А.calculateSquare());
                resultForm.ShowDialog();
            } else
            {
                MessageBox.Show("Объект не выбран", "Внимание!");
                return;
            }
        }
        private void calculateAreaNPerimetr(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                
                if (int.TryParse(textBox1.Text, out int baseLength) && int.TryParse(textBox2.Text, out int sideLength))
                {
                    
                    if (baseLength > 0 && sideLength > 0)
                    {
                        if (baseLength < sideLength + sideLength && sideLength < baseLength + sideLength)
                        {
                            if (baseLength > 6 || baseLength < 10)
                            {
                                isoscelesTriangle triangle = new isoscelesTriangle(baseLength, sideLength);

                                ResultForm resultForm = new ResultForm();
                                resultForm.SetResults(triangle.calculatePerimeter(), triangle.calculateSquare());
                                resultForm.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Длина основания должна быть от 6 до 10", "Ошибка");
                            }
                                
                            
                        }
                        else
                        {
                            MessageBox.Show("Стороны должны соответсвовать правилу треугольника", "Ошибка");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Введите положительные значения для длины основания и длины стороны", "Ошибка");
                    }
                }
                else
                {
                    MessageBox.Show("Введите числовые значения для длины основания и длины стороны", "Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Введите значения для длины основания и длины стороны", "Ошибка");
            }
        }
        /// <summary>
        /// Ru: Класс для расчёта периметра и площади равнобедренного треугольника.<br/>
        /// En: A class for calculating the perimeter and area of an isosceles triangle.
        /// </summary>

        protected internal class isoscelesTriangle
        {
            private int baseLength;
            private int sideLength;

            public isoscelesTriangle()
            {
                baseLength = 0;
                sideLength = 0;
            }

            public isoscelesTriangle(int baseLength, int sideLength)
            {
                SetBaseLength(baseLength);
                SetSideLength(sideLength);
            }

            public void SetBaseLength(int length)
            {
                if (length >= 0)
                {
                    baseLength = length;
                }
                else
                {
                    MessageBox.Show("Длина основания не может быть отрицательной", "Ошибка");
                }
                
            }

            public int GetBaseLength()
            {
                return baseLength;
            }

            public void SetSideLength(int length)
            {
                if (length >= 0)
                    sideLength = length;
                else
                    MessageBox.Show("Длина стороны не может быть отрицательной", "Ошибка");
            }

            public int GetSideLength()
            {
                return sideLength;
            }

            public int calculatePerimeter()
            {
                return baseLength + 2 * sideLength;
            }

            public int calculateSquare()
            {
                return baseLength * sideLength / 2;
            }
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            triangle1 = new isoscelesTriangle(9, 12);
            triangle2 = new isoscelesTriangle(8, 13);
            triangle3 = new isoscelesTriangle(9, 14);
            triangle4 = new isoscelesTriangle(8, 15);
        }

      
        
    }
}
