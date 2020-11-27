using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var measureItems = new string[] { "м/с", "км/ч", "узел", "мах" };//типы скорости

            cmbFirstType.DataSource = new List<string>(measureItems);
            cmbSecondType.DataSource = new List<string>(measureItems);
            cmbResultType.DataSource = new List<string>(measureItems);
        }

        private MeasureType GetMeasureType(ComboBox comboBox)//выбор типов
        {
            MeasureType measureType;
            switch (comboBox.Text)
            {
                case "м/с":
                    measureType = MeasureType.m;
                    break;
                case "км/ч":
                    measureType = MeasureType.km;
                    break;
                case "узел":
                    measureType = MeasureType.u;
                    break;
                case "мах":
                    measureType = MeasureType.max;
                    break;
                default:
                    measureType = MeasureType.m;
                    break;
            }
            return measureType;
        }

        private void Calculate()//сам калькулятор
        {
            try
            {
                var firstValue = double.Parse(txtFirst.Text);
                var secondValue = double.Parse(txtSecond.Text);

                MeasureType firstType = GetMeasureType(cmbFirstType);
                MeasureType secondType = GetMeasureType(cmbSecondType);
                MeasureType resultType = GetMeasureType(cmbResultType);

                var firstLength = new Speed(firstValue, firstType);
                var secondLength = new Speed(secondValue, secondType);

                Speed sum;

                switch (cmbOperation.Text)//перебор операций
                {
                    case "+":
                        sum = firstLength + secondLength;
                        break;
                    case "-":
                        sum = firstLength - secondLength;
                        break;
                    case "*":
                        sum = firstLength * secondLength;
                        break;
                    case ">":
                        sum = firstLength > secondLength;
                        break;
                    case "<":
                        sum = firstLength < secondLength;
                        break;
                    default:
                        sum = new Speed(0, MeasureType.m);
                        break;
                }

                txtResult.Text = sum.To(resultType).Verbose();
            }
            catch (FormatException)
            {
            }
        }

        private void onValueChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void button1_Click(object sender, EventArgs e)//кнопка вызова инструкций
        {
            Form2 examp = new Form2();
            examp.Show();
        }

        private void button2_Click(object sender, EventArgs e)//кнопка вызова справки
        {
            Form3 examp = new Form3();
            examp.Show();
        }

        private void button3_Click(object sender, EventArgs e)//кнопка отчистки
        {
            txtFirst.Clear();
            txtSecond.Clear();
            txtResult.Clear();
            cmbFirstType.Text = "м/с";
            cmbSecondType.Text = "м/с";
            cmbResultType.Text = "м/с";
            cmbOperation.Text = "";
        }

        private void keyPress(KeyPressEventArgs e, ComboBox comboBox)  //Функция, обрабатывающая нажатие клавиши
        {

            switch (e.KeyChar)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case '\b':
                case '-':
                    break;
                default:
                    e.KeyChar = '\0';
                    break;
            }


        }

        private void txtFirst_KeyPress(object sender, KeyPressEventArgs e)
        {
            nextItem(sender, e);
            keyPress(e, cmbFirstType);
        }

        private void txtSecond_KeyPress(object sender, KeyPressEventArgs e)
        {
            nextItem(sender, e);
            keyPress(e, cmbSecondType);
        }

        private void nextItem(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
    }
}
