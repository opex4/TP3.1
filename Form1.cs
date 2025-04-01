using System.Numerics;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TP3._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(["2", "8", "10", "16"]);
            comboBox1.SelectedIndex = 2;

            comboBox2.Items.AddRange([ "2", "8", "10", "16" ]);
            comboBox2.SelectedIndex = 2;

            comboBox3.Items.AddRange([ "2", "8", "10", "16" ]);
            comboBox3.SelectedIndex = 2;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Logic number1 = new Logic(textBox1.Text, Convert.ToInt32(comboBox1.Text), checkBox1.Checked);
                Logic number2 = new Logic(textBox2.Text, Convert.ToInt32(comboBox2.Text), checkBox2.Checked);
                Logic result = number1 + number2;
                label1.Text = result.Result(Convert.ToInt32(comboBox3.Text));
                //label1.Text = Result(result, Convert.ToInt32(comboBox3.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("¬ведите числа дл€ расчЄта");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Logic number1 = new Logic(textBox1.Text, Convert.ToInt32(comboBox1.Text), checkBox1.Checked);
                Logic number2 = new Logic(textBox2.Text, Convert.ToInt32(comboBox2.Text), checkBox2.Checked);
                Logic result = number1 - number2;
                label1.Text = result.Result(Convert.ToInt32(comboBox3.Text));
                //label1.Text = Result(result, Convert.ToInt32(comboBox3.Text));
            }
            catch (Exception)
            {
                MessageBox.Show("¬ведите числа дл€ расчЄта");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Logic number1 = new Logic(textBox1.Text, Convert.ToInt32(comboBox1.Text), checkBox1.Checked);
                Logic number2 = new Logic(textBox2.Text, Convert.ToInt32(comboBox2.Text), checkBox2.Checked);
                Logic result = number1 * number2;
                label1.Text = result.Result(Convert.ToInt32(comboBox3.Text));
                //label1.Text = Result(result, Convert.ToInt32(comboBox3.Text));

            }
            catch (Exception)
            {
                MessageBox.Show("¬ведите числа дл€ расчЄта");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                //Logic number1 = new Logic(textBox1.Text, Convert.ToInt32(comboBox1.Text), checkBox1.Checked);
                //Logic number2 = new Logic(textBox2.Text, Convert.ToInt32(comboBox2.Text), checkBox2.Checked);
                //if (number1 > number2)
                //{
                //    label1.Text = Result(number1, Convert.ToInt32(comboBox3.Text)) + " > " + Result(number2, Convert.ToInt32(comboBox3.Text));
                //}
                //else if (number1 < number2)
                //{
                //    label1.Text = Result(number1, Convert.ToInt32(comboBox3.Text)) + " < " + Result(number2, Convert.ToInt32(comboBox3.Text));
                //}
                //else
                //{
                //    label1.Text = Result(number1, Convert.ToInt32(comboBox3.Text)) + " = " + Result(number2, Convert.ToInt32(comboBox3.Text));
                //}
                Logic number1 = new Logic(textBox1.Text, Convert.ToInt32(comboBox1.Text), checkBox1.Checked);
                Logic number2 = new Logic(textBox2.Text, Convert.ToInt32(comboBox2.Text), checkBox2.Checked);
                if (number1 > number2)
                {
                    label1.Text = number1.Result(Convert.ToInt32(comboBox3.Text)) + " > " + number2.Result(Convert.ToInt32(comboBox3.Text));
                }
                else if (number1 < number2)
                {
                    label1.Text = number1.Result(Convert.ToInt32(comboBox3.Text)) + " < " + number2.Result(Convert.ToInt32(comboBox3.Text));
                }
                else
                {
                    label1.Text = number1.Result(Convert.ToInt32(comboBox3.Text)) + " = " + number2.Result(Convert.ToInt32(comboBox3.Text));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("¬ведите числа дл€ расчЄта");
            }
        }
        //private string Result(Logic result, int baseSystem)
        //{
        //    if (result.Value < 0)
        //    {
        //        Logic logic = new Logic(Convert.ToString(Math.Abs(result.Value)), 10);
        //        return ("-" + Convert.ToString(logic.Value, baseSystem));
        //    }
        //    else
        //    {
        //        return Convert.ToString(result.Value, baseSystem);
        //    }
        //}
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            label1.Text = "";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox2.Clear();
            label1.Text = "";
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;

            int baseNum = int.Parse(comboBox1.SelectedItem.ToString());
            char keyChar = e.KeyChar;

            if (char.IsControl(keyChar)) return;

            bool isValid = baseNum switch
            {
                2 => keyChar is '0' or '1',
                8 => keyChar >= '0' && keyChar <= '7',
                10 => char.IsDigit(keyChar),
                16 => char.IsDigit(keyChar) || (keyChar >= 'A' && keyChar <= 'F') || (keyChar >= 'a' && keyChar <= 'f'),
                _ => false
            };

            if (!isValid)
                e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (comboBox1.SelectedItem == null) return;

            int baseNum = int.Parse(comboBox2.SelectedItem.ToString());
            char keyChar = e.KeyChar;

            if (char.IsControl(keyChar)) return;

            bool isValid = baseNum switch
            {
                2 => keyChar is '0' or '1',
                8 => (keyChar >= '0' && keyChar <= '7'),
                10 => char.IsDigit(keyChar),
                16 => char.IsDigit(keyChar) || (keyChar >= 'A' && keyChar <= 'F') || (keyChar >= 'a' && keyChar <= 'f'),
                _ => false
            };

            if (!isValid)
                e.Handled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
