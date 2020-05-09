﻿using Project.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Profile : Form
    {
        private Menu owner;

        public Profile(Menu owner)
        {
            InitializeComponent();
            this.owner = owner;
           
        }

        private void Profile_Load(object sender, EventArgs e)
        {

            textBox1.Text = "Ришат";
            textBox2.Text = "Ганиев";
            textBox3.Text = "Анасович";
            comboBox1.Text = "Мужской";
            maskedTextBox1.Text = "19.09.1993";
            textBox4.Text = "РФ";
            maskedTextBox2.Text = "1234-123456";
            maskedTextBox3.Text = "1234567890123456";
            textBox5.Text = "New";
          
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (Check_Correct())
            {
                try
                {
                    string fName = textBox1.Text;
                    string lName = textBox2.Text;
                    string patronymic = textBox3.Text;
                    Boolean gender = comboBox1.Text == "Мужской" ? true : false;
                    String[] b = maskedTextBox1.Text.Split('.');
                    DateTime birthday = new DateTime(Convert.ToInt32(b[2]), Convert.ToInt32(b[1]), Convert.ToInt32(b[0]));
                    string sitizenShip = textBox4.Text;
                    string passportData = maskedTextBox2.Text;
                    string insurancePolicy = maskedTextBox3.Text;
                    string attachment = textBox5.Text;
                    Information inf = new Information(fName, lName, patronymic, gender, birthday, sitizenShip, passportData, insurancePolicy, attachment);
                    owner.addPatient(new Patient(inf));
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Поле \"Дата рождения\" заполнено некорректно");
                }
            }
            
        }

        private bool Check_Correct()
        {
            bool b = true;
            foreach (Control c in this.Controls) {
                if (c is TextBox && string.IsNullOrWhiteSpace(c.Text) || c is MaskedTextBox && !(c as MaskedTextBox).MaskCompleted)
                {
                    b = false;
                    MessageBox.Show("Заполните все поля");
                    break;
                }
                string[] s = maskedTextBox1.Text.Split('.');

                if (Convert.ToInt32(s[2])<1900 || 1>Convert.ToInt32(s[1]) || Convert.ToInt32(s[1])>12 || 1>Convert.ToInt32(s[0]) || Convert.ToInt32(s[0])> 31)
                {
                    b = false;
                    MessageBox.Show("Поле \"Дата рождения\" заполнено некорректно");
                    break;
                }

            }
            return b;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
