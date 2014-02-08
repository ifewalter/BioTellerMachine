using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace TellerMachineAdmin
{
    public partial class Admin : Form
    {
        private Connection.ConnectionStatement connectionStatement = new Connection.ConnectionStatement();
        SqlDataReader dataReader;

        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            loadAllAccounts();
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void accountListBox_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                getSpecificAccount(accountListBox.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
            }

        }

        //fetch accounts and list them into the listBox
        private void loadAllAccounts()
        {
            dataReader = connectionStatement.fetchAllAccount();

            //   System.Data.DataRow dataRow;
            foreach (IDataRecord dataRow in dataReader)
            {
                accountListBox.Items.Add(dataRow.GetString(1));
            }
            dataReader.Close();
        }

        private void getSpecificAccount(String accountNumber)
        {
            try
            {
                Array accountDetails = new String[6];
                accountDetails = connectionStatement.fetchSpecificAccount(accountNumber);

                accountNumberText.Text = accountDetails.GetValue(1).ToString();
                balanceText.Text = accountDetails.GetValue(5).ToString();
                firstNameText.Text = accountDetails.GetValue(2).ToString();
                lastNameText.Text = accountDetails.GetValue(3).ToString();
                addressText.Text = accountDetails.GetValue(4).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please Register Some Accounts First");
            }

        }

        private void updateAccountButton_Click(object sender, EventArgs e)
        {
            Boolean result = connectionStatement.updateAccount(accountNumberText.Text, firstNameText.Text,
                  lastNameText.Text, balanceText.Text, addressText.Text);
            if (result == true)
            {
                MessageBox.Show("Account Updated");
                refreshContents();
            }
            else
            {
                MessageBox.Show("Error Updating Account");
            }

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            getSpecificAccount(searchText.Text);
        }

        private void resetSearchLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            refreshContents();
        }

        private void refreshContents()
        {
            accountListBox.Items.Clear();
            accountNumberText.Text = "";
            balanceText.Text = "";
            firstNameText.Text = "";
            lastNameText.Text = "";
            addressText.Text = "";

            loadAllAccounts();
        }

        private void deleteAccountButton_Click(object sender, EventArgs e)
        {
            Boolean result = connectionStatement.deleteAccount(accountNumberText.Text);
            if (result == true)
            {
                MessageBox.Show("Account deleted");
                refreshContents();

            }
            else
            {
                MessageBox.Show("Error Deleting Account");
            }
        }

        private void newAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewAccount newAccount = new NewAccount();
            newAccount.ShowDialog(this);
            refreshContents();
        }

        private void detailsGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void transactionLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log log = new Log();
            log.Show();
        }

    }
}
