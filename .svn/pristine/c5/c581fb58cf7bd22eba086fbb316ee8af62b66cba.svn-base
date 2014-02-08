using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Connection;


namespace TellerMachineAdmin
{
    public partial class NewAccount : Form
    {
        private ConnectionStatement connectionStatement = new ConnectionStatement();

        public NewAccount()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            Boolean response = connectionStatement.createNewAccount(accountNumberText.Text, firstNameText.Text,
                 lastNameText.Text, balanceText.Text, addressText.Text);
            if (response == true)
            {
                MessageBox.Show("Account Creation Successfull");
                this.Close();
            }
            else
            {
                MessageBox.Show("Account Creation Failed, Please Try Again");
            }
        }

        private void NewAccount_Load(object sender, EventArgs e)
        {
            Random random = new Random();
            accountNumberText.Text = random.Next(100000000, 999999999).ToString();
        }


    }
}
