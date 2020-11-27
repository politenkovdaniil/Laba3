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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            richTextBox1.Text = "Шаг 1: Введите первое значение скорости;";
            richTextBox1.Text += "\nШаг 2: Выберите тип для первого значения;";
            richTextBox1.Text += "\nШаг 3: Введите второе значение скорости;";
            richTextBox1.Text += "\nШаг 4: Выберите тип для второго значения;";
            richTextBox1.Text += "\nШаг 5: Выберите нужную вам операцию;";
            richTextBox1.Text += "\nШаг 6: Выберите тип, в котором нужно вывести результат;";
            richTextBox1.Text += "\nШаг 7: Получите результат.";

        }
    }
}
