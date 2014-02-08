using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Connection;

namespace TellerMachine
{
    public partial class TellerMachine : Form
    {
        #region "Constants Definition"
        private const int LOGIN = 0;
        private const int WITHDRAWAL = 1;
        private const int BALANCE_CHECK = 2;
        private const int TRANSFER = 3;
        private const int CHANGE_PIN = 4;
        private const int PAY_BILLS = 5;
        private const int ELECTRICITY_BILL = 6;
        private const int WATER_BILLS = 7;
        private const int PHONE_BILLS = 8;
        private const int DEPOSIT = 9;
        private const int CUSTOM_WITHDRAWAL = 10;
        private const int HOME_SCREEN = 11;
        private const int ELECTRICITY_BILLS_PAYMENT = 12;
        private const int TRANSFER_STEP_2 = 13;

        private const int CASH_VALUE_1 = 500;
        private const int CASH_VALUE_2 = 1000;
        private const int CASH_VALUE_3 = 2000;
        private const int CASH_VALUE_4 = 5000;
        private const int CASH_VALUE_5 = 10000;
        private const int CASH_VALUE_6 = 20000;

        #endregion

        #region "Varible Definition"
        private int transaction;
        private String keypadEntry;
        private ConnectionStatement connection = new ConnectionStatement();
        private Sounds sounds = new Sounds();
        private Boolean response;
        private String accountNumber;
        private String balance;
        private String transferAccountNumber;
        private Int32 transferAmount;
        private Capture cap;
        private HaarCascade haar;
        #endregion

        public TellerMachine()
        {
            InitializeComponent();
        }

        private void TellerMachine_Load(object sender, EventArgs e)
        {
            transaction = LOGIN;

            axWindowsMediaPlayer1.enableContextMenu = false;
            axWindowsMediaPlayer1.settings.autoStart = true;
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.URL = "Resources\\atm.wmv";
            axWindowsMediaPlayer1.settings.setMode("loop", true);




        }

        private void button1_Click(object sender, EventArgs e)
        {
            sounds.buttonClick();

            switch (transaction)
            {
                case LOGIN:
                    {
                        titleLabel2.Text += "#";
                        keypadEntry += "1";
                        break;
                    }
                default:
                    {
                        titleLabel2.Text += "1";
                        keypadEntry += "1";
                        break;
                    }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sounds.buttonClick();

            switch (transaction)
            {
                case LOGIN:
                    {
                        titleLabel2.Text += "#";
                        keypadEntry += "2";
                        break;
                    }
                default:
                    {
                        titleLabel2.Text += "2";
                        keypadEntry += "2";
                        break;
                    }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sounds.buttonClick();

            switch (transaction)
            {
                case LOGIN:
                    {
                        titleLabel2.Text += "#";
                        keypadEntry += "3";
                        break;
                    }
                default:
                    {
                        titleLabel2.Text += "3";
                        keypadEntry += "3";
                        break;
                    }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sounds.buttonClick();

            switch (transaction)
            {
                case LOGIN:
                    {
                        titleLabel2.Text += "#";
                        keypadEntry += "6";
                        break;
                    }
                default:
                    {
                        titleLabel2.Text += "6";
                        keypadEntry += "6";
                        break;
                    }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sounds.buttonClick();

            switch (transaction)
            {
                case LOGIN:
                    {
                        titleLabel2.Text += "#";
                        keypadEntry += "5";
                        break;
                    }
                default:
                    {
                        titleLabel2.Text += "5";
                        keypadEntry += "5";
                        break;
                    }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sounds.buttonClick();

            switch (transaction)
            {
                case LOGIN:
                    {
                        titleLabel2.Text += "#";
                        keypadEntry += "4";
                        break;
                    }
                default:
                    {
                        titleLabel2.Text += "4";
                        keypadEntry += "4";
                        break;
                    }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            sounds.buttonClick();

            switch (transaction)
            {
                case LOGIN:
                    {
                        titleLabel2.Text += "#";
                        keypadEntry += "7";
                        break;
                    }
                default:
                    {
                        titleLabel2.Text += "7";
                        keypadEntry += "7";
                        break;
                    }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            sounds.buttonClick();

            switch (transaction)
            {
                case LOGIN:
                    {
                        titleLabel2.Text += "#";
                        keypadEntry += "8";
                        break;
                    }
                default:
                    {
                        titleLabel2.Text += "8";
                        keypadEntry += "8";
                        break;
                    }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            sounds.buttonClick();

            switch (transaction)
            {
                case LOGIN:
                    {
                        titleLabel2.Text += "#";
                        keypadEntry += "9";
                        break;
                    }
                default:
                    {
                        titleLabel2.Text += "9";
                        keypadEntry += "9";
                        break;
                    }
            }
        }

        private void button0_Click(object sender, EventArgs e)
        {
            sounds.buttonClick();

            switch (transaction)
            {
                case LOGIN:
                    {
                        titleLabel2.Text += "#";
                        keypadEntry += "0";
                        break;
                    }
                default:
                    {
                        titleLabel2.Text += "0";
                        keypadEntry += "0";
                        break;
                    }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            sounds.buttonClick();

            titleLabel2.Text = "";
            keypadEntry = "";
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            sounds.buttonClick();

            switch (transaction)
            {
                case LOGIN:
                    {
                        accountNumber = keypadEntry;
                        response = authenticateAccount(keypadEntry);

                        if (response == true)
                        {
                            // transaction = HOME_SCREEN;
                            // prepareHomeScreen();

                            // passing 0 gets zeroth webcam
                            try
                            {
                                pictureBox1.Visible = true;
                                cap = new Capture(0);
                                //cap = pictureBox1.Image;

                                // adjust path to find your xml
                                haar = new HaarCascade(Application.StartupPath +
                        "\\haarcascade_frontalface_alt.xml");
                                timer1.Start();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error Initializing Camera. Make sure you have a webcam properly installed");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Authentication Error");
                        }
                        break;
                    }
                case WITHDRAWAL:
                    {
                        break;
                    }
                case BALANCE_CHECK:
                    {
                        break;
                    }
                case CHANGE_PIN:
                    {
                        break;
                    }
                case TRANSFER:
                    {
                        prepareFundTransferAmount();
                        break;
                    }
                case TRANSFER_STEP_2:
                    {
                        Int32 tempAmount = Convert.ToInt32(keypadEntry);
                        transferAmount = tempAmount;
                        transferFund();
                        break;
                    }
                case PAY_BILLS:
                    {
                        break;
                    }
                case ELECTRICITY_BILL:
                    {
                        break;
                    }
                case PHONE_BILLS:
                    {
                        break;
                    }
                case WATER_BILLS:
                    {
                        break;
                    }
                case CUSTOM_WITHDRAWAL:
                    {
                        dispenseMoney(Convert.ToInt32(keypadEntry));
                        break;
                    }
                case DEPOSIT:
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }



        }

        //disable the keypad
        private void disableKeypad()
        {
            button0.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            cancelButton.Enabled = false;
            enterButton.Enabled = false;
        }

        //re-enable the keyad
        private void enableKeypad()
        {
            button0.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            cancelButton.Enabled = true;
            enterButton.Enabled = true;
        }

        private void prepareHomeScreen()
        {
            transaction = HOME_SCREEN;
            disableKeypad();
            titleLabel1.Text = "Please Select and Option from the Menu";
            titleLabel2.Text = null;

            // leftOption1.Text = "Deposit";
            leftOption1.Text = null;
            leftOption2.Text = "Pay Bills";
            // leftOption3.Text = "Change Pin";
            leftOption3.Text = null;
            leftOption4.Text = null;

            rightOption1.Text = "Balance";
            rightOption2.Text = "Withdrawal";
            rightOption3.Text = "Fund Transfer";
            rightOption4.Text = "Exit";
            keypadEntry = null;

        }

        private void prepareBalance()
        {
            transaction = BALANCE_CHECK;
            disableKeypad();
            titleLabel1.Text = "Your Current Balance is: ";
            titleLabel2.Text = "₦ " + balance;

            leftOption1.Text = null;
            leftOption2.Text = null;
            leftOption3.Text = null;
            leftOption4.Text = null;

            rightOption1.Text = null;
            rightOption2.Text = null;
            rightOption3.Text = null;
            rightOption4.Text = "Back";
            keypadEntry = null;


        }

        private void prepareBills()
        {
            transaction = PAY_BILLS;
            disableKeypad();
            titleLabel1.Text = "Please Choose and Option from the Menu";
            titleLabel2.Text = null;

            leftOption1.Text = null;
            leftOption2.Text = null;
            leftOption3.Text = null;
            leftOption4.Text = null;

            rightOption1.Text = "Electricity Bills";
            rightOption2.Text = "Water Bills";
            // rightOption3.Text = "Phone Bills";
            rightOption3.Text = null;
            rightOption4.Text = "Exit";
            keypadEntry = null;

        }

        public void preparePinChange()
        {
            transaction = CHANGE_PIN;
            enableKeypad();
            titleLabel1.Text = "Please Enter your new PIN";
            titleLabel2.Text = null;

            leftOption1.Text = null;
            leftOption2.Text = null;
            leftOption3.Text = null;
            leftOption4.Text = null;

            rightOption1.Text = null;
            rightOption2.Text = null;
            rightOption3.Text = null;
            rightOption4.Text = null;
            keypadEntry = null;

        }

        private void prepareCustomWithdrawal()
        {
            transaction = CUSTOM_WITHDRAWAL;
            enableKeypad();
            keypadEntry = null;
            titleLabel1.Text = "Plese Enter the Amount to be Withdrawn";
            titleLabel2.Text = null;

            leftOption1.Text = null;
            leftOption2.Text = null;
            leftOption3.Text = null;
            leftOption4.Text = null;

            rightOption1.Text = null;
            rightOption2.Text = null;
            rightOption3.Text = "Accept";
            rightOption4.Text = "Cancel";
            keypadEntry = null;

        }

        private void prepareWithdrawal()
        {
            transaction = WITHDRAWAL;
            disableKeypad();
            titleLabel1.Text = "Please Select the Amount to Be withdrawn";
            titleLabel2.Text = null;

            leftOption1.Text = "₦ " + CASH_VALUE_1.ToString();
            leftOption2.Text = "₦ " + CASH_VALUE_2.ToString();
            leftOption3.Text = "₦ " + CASH_VALUE_3.ToString();
            leftOption4.Text = "₦ " + CASH_VALUE_4.ToString();

            rightOption1.Text = "₦ " + CASH_VALUE_5.ToString();
            rightOption2.Text = "₦ " + CASH_VALUE_6.ToString();
            rightOption3.Text = "Other";
            rightOption4.Text = "Cancel";
            keypadEntry = null;

        }

        private void prepareDispensing()
        {
            sounds.dispensingCash();
            disableKeypad();
            titleLabel1.Text = "Transaction Successfull...";
            titleLabel2.Text = null;

            leftOption1.Text = null;
            leftOption2.Text = null;
            leftOption3.Text = null;
            leftOption4.Text = null;

            rightOption1.Text = null;
            rightOption2.Text = null;
            rightOption3.Text = null;
            rightOption4.Text = "Exit";
            keypadEntry = null;

        }

        private void prepareTransactionSuccess()
        {
            disableKeypad();
            sounds.transactionSuccess();

            titleLabel1.Text = "Transaction Successful...";
            titleLabel2.Text = null;

            leftOption1.Text = null;
            leftOption2.Text = null;
            leftOption3.Text = null;
            leftOption4.Text = null;

            rightOption1.Text = null;
            rightOption2.Text = null;
            rightOption3.Text = null;
            rightOption4.Text = "Exit";
            keypadEntry = null;
            //  System.Threading.Thread.Sleep(1000);
            //prepareHomeScreen();

        }

        private void prepareTransactionFailed()
        {
            sounds.transactionFailed();

            disableKeypad();
            titleLabel1.Text = "Transaction Failed - Insufficient Balance...";
            titleLabel2.Text = null;

            leftOption1.Text = null;
            leftOption2.Text = null;
            leftOption3.Text = null;
            leftOption4.Text = null;

            rightOption1.Text = null;
            rightOption2.Text = null;
            rightOption3.Text = null;
            rightOption4.Text = "Exit";
            keypadEntry = null;
            //  prepareHomeScreen();


        }

        /* Deprecated
         * 
         private void prepareElectricBills()
         {
             transaction = ELECTRICITY_BILL;
             enableKeypad();
             titleLabel1.Text = "Please Enter your Power Company Subscriber Number";
             titleLabel2.Text = null;

             leftOption1.Text = null;
             leftOption2.Text = null;
             leftOption3.Text = null;
             leftOption4.Text = null;

             rightOption1.Text = null;
             rightOption2.Text = null;
             rightOption3.Text = null;
             rightOption4.Text = null;
         }
         * */

        private void prepareElectricBillsPayment()
        {
            transaction = ELECTRICITY_BILL;
            enableKeypad();
            titleLabel1.Text = "Please Enter the Amount to be paid";
            titleLabel2.Text = null;

            leftOption1.Text = null;
            leftOption2.Text = null;
            leftOption3.Text = null;
            leftOption4.Text = null;

            rightOption1.Text = null;
            rightOption2.Text = null;
            rightOption3.Text = "Accept";
            rightOption4.Text = "Cancel";
            keypadEntry = null;

        }

        private void prepareWaterBillsPayment()
        {
            transaction = WATER_BILLS;
            enableKeypad();
            titleLabel1.Text = "Please Enter the Amount to be paid";
            titleLabel2.Text = null;

            leftOption1.Text = null;
            leftOption2.Text = null;
            leftOption3.Text = null;
            leftOption4.Text = null;

            rightOption1.Text = null;
            rightOption2.Text = null;
            rightOption3.Text = "Accept";
            rightOption4.Text = "Cancel";
            keypadEntry = null;

        }

        private void preparePhoneBillsPayment()
        {
            transaction = PHONE_BILLS;
            enableKeypad();
            titleLabel1.Text = "Please Enter the Amount to be paid";
            titleLabel2.Text = null;

            leftOption1.Text = null;
            leftOption2.Text = null;
            leftOption3.Text = null;
            leftOption4.Text = null;

            rightOption1.Text = null;
            rightOption2.Text = null;
            rightOption3.Text = "Accept";
            rightOption4.Text = "Cancel";
        }

        private void prepareFundTransferAccountNumber()
        {

            transaction = TRANSFER;
            enableKeypad();
            titleLabel1.Text = "Please Enter Beneficiary Account Number";
            titleLabel2.Text = null;

            leftOption1.Text = null;
            leftOption2.Text = null;
            leftOption3.Text = null;
            leftOption4.Text = null;

            rightOption1.Text = null;
            rightOption2.Text = null;
            rightOption3.Text = "Accept";
            rightOption4.Text = "Cancel";
            keypadEntry = null;

        }

        private void prepareFundTransferAmount()
        {
            transaction = TRANSFER_STEP_2;
            enableKeypad();
            transferAccountNumber = keypadEntry;
            titleLabel1.Text = "Please Enter Amount to be Transfered";
            titleLabel2.Text = null;

            leftOption1.Text = null;
            leftOption2.Text = null;
            leftOption3.Text = null;
            leftOption4.Text = null;

            rightOption1.Text = null;
            rightOption2.Text = null;
            rightOption3.Text = "Accept";
            rightOption4.Text = "Cancel";
            keypadEntry = null;

        }

        private void prepareDeposit()
        {
        }

        private void prepareAuthentication()
        {
            transaction = LOGIN;
            enableKeypad();
            titleLabel1.Text = "Please Enter Account Number: ";
            titleLabel2.Text = null;

            leftOption1.Text = null;
            leftOption2.Text = null;
            leftOption3.Text = null;
            leftOption4.Text = null;

            rightOption1.Text = null;
            rightOption2.Text = null;
            rightOption3.Text = null;
            rightOption4.Text = null;

            //reset all variables
            keypadEntry = null;
            response = false;
            accountNumber = null;
            balance = null;
            pictureBox1.Visible = false;

        }

        private Boolean authenticateAccount(String accountNumber)
        {
            response = connection.checkAccountExists(accountNumber);

            if (response == true)
            {
                //TODO: This is where we include the facial detection procedure
                response = true;
                getAccountDetails(accountNumber);
            }
            else
            {
                response = false;
            }

            return response;
        }

        private void getAccountDetails(String accountNumber)
        {

            try
            {
                Array accountDetails = new String[6];
                accountDetails = connection.fetchSpecificAccount(accountNumber);

                balance = accountDetails.GetValue(5).ToString();
            }
            catch (Exception ex)
            {

            }
            keypadEntry = null;

        }

        private void dispenseMoney(Int32 amount)
        {
            double newBalance = Convert.ToDouble(balance);
            double newAmount = Convert.ToDouble(amount);
            if (newBalance > newAmount)
            {
                newBalance -= newAmount;
                balance = newBalance.ToString();
                response = connection.updateBalance(accountNumber, balance);

                connection.createLog(accountNumber, Connection.ConnectionStatement.WITHDRAW, DateTime.Now.ToString() + " - Withdrawal  Successful " + newAmount);
                prepareDispensing();
            }
            else
            {

                connection.createLog(accountNumber, Connection.ConnectionStatement.WITHDRAW, DateTime.Now.ToString() + " - Withdrawal Failed " + newAmount);
                prepareTransactionFailed();
            }
            keypadEntry = null;

        }

        private void payElectricityBills(Int32 amount)
        {
            double newBalance = Convert.ToDouble(balance);
            double newAmount = Convert.ToDouble(amount);
            if (newBalance > newAmount)
            {
                newBalance -= newAmount;
                balance = newBalance.ToString();
                response = connection.updateBalance(accountNumber, balance);
                connection.createLog(accountNumber, Connection.ConnectionStatement.ELECTRIC_BILLS, DateTime.Now.ToString() + " - Electric bills payment - N" + newAmount);
                prepareTransactionSuccess();
            }
            else
            {
                prepareTransactionFailed();
            }
            keypadEntry = null;
        }

        private void payWaterBills(Int32 amount)
        {
            double newBalance = Convert.ToDouble(balance);
            double newAmount = Convert.ToDouble(amount);
            if (newBalance > newAmount)
            {
                newBalance -= newAmount;
                balance = newBalance.ToString();
                response = connection.updateBalance(accountNumber, balance);
                connection.createLog(accountNumber, Connection.ConnectionStatement.WATER_BILLS, DateTime.Now.ToString() + " - Water bills payment - N" + newAmount);
                prepareTransactionSuccess();
            }
            else
            {
                prepareTransactionFailed();
            }
            keypadEntry = null;
        }


        private void transferFund()
        {
            //   payBills(transferAmount, reciepientAccountNumber);

            double newBalance = Convert.ToDouble(balance);
            double newAmount = Convert.ToDouble(transferAmount);
            //verify we still have money
            if (newBalance > newAmount)
            {
                newBalance -= newAmount;
                balance = newBalance.ToString();
                response = connection.updateBalance(accountNumber, balance);
                //verify transaction was successful then transfer funds
                if (response == true)
                {
                    String tempAmount;
                    tempAmount = Convert.ToString(transferAmount);
                    response = connection.transferfund(transferAccountNumber, tempAmount);
                    //verify transfer success
                    if (response == true)
                    {

                        connection.createLog(accountNumber, Connection.ConnectionStatement.TRANSFER, DateTime.Now.ToString() + " - Withdrawal Success - " + newAmount);
                        prepareTransactionSuccess();
                    }
                    else
                    {

                        connection.createLog(accountNumber, Connection.ConnectionStatement.TRANSFER, DateTime.Now.ToString() + " - Withdrawal Failed - " + newAmount);
                        prepareTransactionFailed();
                    }
                }
                else
                {

                    connection.createLog(accountNumber, Connection.ConnectionStatement.TRANSFER, DateTime.Now.ToString() + " - Withdrawal Success - " + newAmount);
                    prepareTransactionSuccess();
                }
            }
            else
            {

                connection.createLog(accountNumber, Connection.ConnectionStatement.TRANSFER, DateTime.Now.ToString() + " - Withdrawal Failed - " + newAmount);
                prepareTransactionFailed();
            }
        }

        private void payBills(Int32 amount)
        {
            double newBalance = Convert.ToDouble(balance);
            double newAmount = Convert.ToDouble(amount);
            if (newBalance > newAmount)
            {
                newBalance -= newAmount;
                balance = newBalance.ToString();
                response = connection.updateBalance(accountNumber, balance);
                prepareTransactionSuccess();
            }
            else
            {
                sounds.transactionFailed();
                prepareTransactionFailed();
            }
        }


        private void leftButton1_Click(object sender, EventArgs e)
        {
            sounds.buttonClick();

            switch (transaction)
            {
                case HOME_SCREEN:
                    {
                        // prepareDeposit();
                        break;
                    }
                case WITHDRAWAL:
                    {
                        dispenseMoney(CASH_VALUE_1);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void leftButton2_Click(object sender, EventArgs e)
        {
            sounds.buttonClick();

            switch (transaction)
            {
                case HOME_SCREEN:
                    {
                        prepareBills();
                        break;
                    }
                case WITHDRAWAL:
                    {
                        dispenseMoney(CASH_VALUE_2);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void leftButton3_Click(object sender, EventArgs e)
        {
            sounds.buttonClick();

            switch (transaction)
            {
                case HOME_SCREEN:
                    {
                        //  preparePinChange();
                        break;
                    }
                case WITHDRAWAL:
                    {
                        dispenseMoney(CASH_VALUE_3);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void leftButton4_Click(object sender, EventArgs e)
        {
            sounds.buttonClick();

            switch (transaction)
            {
                case WITHDRAWAL:
                    {
                        dispenseMoney(CASH_VALUE_4);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void rightButton1_Click(object sender, EventArgs e)
        {
            sounds.buttonClick();

            switch (transaction)
            {
                case HOME_SCREEN:
                    {
                        prepareBalance();
                        break;
                    }
                case PAY_BILLS:
                    {
                        prepareElectricBillsPayment();
                        break;
                    }
                case WITHDRAWAL:
                    {
                        dispenseMoney(CASH_VALUE_5);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void rightButton2_Click(object sender, EventArgs e)
        {
            sounds.buttonClick();

            switch (transaction)
            {
                case HOME_SCREEN:
                    {
                        prepareWithdrawal();
                        break;
                    }
                case PAY_BILLS:
                    {
                        prepareWaterBillsPayment();
                        break;
                    }
                case WITHDRAWAL:
                    {
                        dispenseMoney(CASH_VALUE_6);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void rightButton3_Click(object sender, EventArgs e)
        {
            sounds.buttonClick();

            switch (transaction)
            {
                case HOME_SCREEN:
                    {
                        prepareFundTransferAccountNumber();
                        break;
                    }
                case WITHDRAWAL:
                    {
                        transaction = CUSTOM_WITHDRAWAL;
                        prepareCustomWithdrawal();
                        break;
                    }
                case BALANCE_CHECK:
                    {
                        break;
                    }
                case CHANGE_PIN:
                    {
                        break;
                    }
                case TRANSFER:
                    {
                        prepareFundTransferAmount();
                        break;
                    }
                case TRANSFER_STEP_2:
                    {
                        Int32 tempAmount = Convert.ToInt32(keypadEntry);
                        transferAmount = tempAmount;
                        transferFund();
                        break;
                    }
                case PAY_BILLS:
                    {
                        break;
                    }
                case ELECTRICITY_BILL:
                    {
                        Int32 tempAmount = Convert.ToInt32(keypadEntry);
                        payElectricityBills(tempAmount);
                        break;
                    }
                case PHONE_BILLS:
                    {
                        break;
                    }
                case WATER_BILLS:
                    {
                        Int32 tempAmount = Convert.ToInt32(keypadEntry);
                        payWaterBills(tempAmount);
                        break;
                    }
                case CUSTOM_WITHDRAWAL:
                    {
                        Int32 newAmount = Convert.ToInt32(keypadEntry);
                        MessageBox.Show(newAmount.ToString());

                        dispenseMoney(newAmount);
                        break;
                    }
                case DEPOSIT:
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void rightButton4_Click(object sender, EventArgs e)
        {
            sounds.buttonClick();

            switch (transaction)
            {
                case HOME_SCREEN:
                    {
                        prepareAuthentication();
                        break;
                    }
                case LOGIN:
                    {
                        Application.Exit();
                        break;
                    }
                default:
                    {
                        prepareHomeScreen();
                        break;
                    }
            }
        }

        private void titleLabel1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            using (Image<Bgr, byte> nextFrame = cap.QueryFrame())
            {
                
                if (nextFrame != null)
                {
                    // there's only one channel (greyscale), hence the zero index
                    //var faces = nextFrame.DetectHaarCascade(haar)[0];
                    Image<Gray, byte> grayframe = nextFrame.Convert<Gray, byte>();
                    var faces =
                            grayframe.DetectHaarCascade(
                                    haar, 1.4, 4,
                                    HAAR_DETECTION_TYPE.DO_CANNY_PRUNING,
                                    new Size(nextFrame.Width / 8, nextFrame.Height / 8)
                                    )[0];

                    foreach (var face in faces)
                    {
                        nextFrame.Draw(face.rect, new Bgr(0, double.MaxValue, 0), 3);


                        transaction = HOME_SCREEN;
                        System.Threading.Thread.Sleep(1000);
                       // pictureBox1.Enabled = false;
                       // pictureBox1.Hide();
                        timer1.Stop();
                        axWindowsMediaPlayer1.Hide();
                        prepareHomeScreen();



                    }
                    pictureBox1.Image = nextFrame.ToBitmap();
                }
            }
        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }
    }
}
