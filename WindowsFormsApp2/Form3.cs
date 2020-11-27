using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            richTextBox1.Text = "Скорость заданная в виде пары (значение, тип), допустимые типы: м/с, км/ч, узел, мах";

            richTextBox1.Text += "\n1. Сложение";
            richTextBox1.Text += "\n2. Вычитание";
            richTextBox1.Text += "\n3. Умножение на число";
            richTextBox1.Text += "\n4. Сравнение двух скоростей";
            richTextBox1.Text += "\n5. Вывод значения в любом типе";
        }
    }
}
