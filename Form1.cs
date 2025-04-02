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
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox2.Items.AddRange(["2", "8", "10", "16"]);
            comboBox2.SelectedIndex = 2;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

            comboBox3.Items.AddRange(["2", "8", "10", "16"]);
            comboBox3.SelectedIndex = 2;
            comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        string mistakeRead = "Ошибка считывания чисел:\n1.Все поля должны быть заполнены\n2.Числа должны быть введены с учётом основания их СС\n3.Числа должны быть целыми";
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Logic number1 = new Logic(textBox1.Text, Convert.ToInt32(comboBox1.Text), checkBox1.Checked);
                Logic number2 = new Logic(textBox2.Text, Convert.ToInt32(comboBox2.Text), checkBox2.Checked);
                Logic result = number1 + number2;
                label1.Text = result.Result(Convert.ToInt32(comboBox3.Text));            }
            catch (Exception)
            {
                MessageBox.Show(mistakeRead);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Logic number1 = new Logic(textBox1.Text, Convert.ToInt32(comboBox1.Text), checkBox1.Checked);
                Logic number2 = new Logic(textBox2.Text, Convert.ToInt32(comboBox2.Text), checkBox2.Checked);
                Logic result = number1 - number2;
                label1.Text = result.Result(Convert.ToInt32(comboBox3.Text));            }
            catch (Exception)
            {
                MessageBox.Show(mistakeRead);
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
            }
            catch (Exception)
            {
                MessageBox.Show(mistakeRead);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Logic number1 = new Logic(textBox1.Text, Convert.ToInt32(comboBox1.Text), checkBox1.Checked);
                Logic number2 = new Logic(textBox2.Text, Convert.ToInt32(comboBox2.Text), checkBox2.Checked);
                label1.Text = Logic.Compare(number1, number2, Convert.ToInt32(comboBox3.Text));
            }
            catch (Exception)
            {
                MessageBox.Show(mistakeRead);
            }
        }
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
