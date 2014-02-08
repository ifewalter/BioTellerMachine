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
    public partial class AdminLogin : Form
    {
        private ConnectionStatement connectionStatement = new ConnectionStatement();
        private Boolean loginResponse;
        private Admin admin = new Admin();

        public AdminLogin()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            //Use the authenticateLogin Function
            authenticateLogin();
        }

        //Authenticate Login and Generate Notifications
        private void authenticateLogin()
        {
            authenticationNotification("Authenticating");
            loginResponse = connectionStatement.adminLogin(usernameText.Text, passwordText.Text);
            if (loginResponse == true)
            {
                showAdmin();
            }
            else
            {
                authenticationNotification("Failed");
            }
        }

        private void showAdmin()
        {
            admin.Show();
            this.Hide();
        }

        private void authenticationNotification(String notificationType)
        {
            authenticateLabel.Visible = true;

            switch (notificationType)
            {
                case "Authenticating":
                    {
                        authenticateLabel.ForeColor = Color.Green;
                        authenticateLabel.Text = "Authenticating...";
                        break;
                    }
                case "Failed":
                    {
                        authenticateLabel.ForeColor = Color.Red;
                        authenticateLabel.Text = "Last Authentication Attempt Failed";
                        break;
                    }
                default:
                    {
                        authenticateLabel.ForeColor = Color.Blue;
                        authenticateLabel.Text = "Idle";
                        break;
                    }
            }


        }
    }
}
