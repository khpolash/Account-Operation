using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AccountOperationApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        List<BankAccount> bankAccounts = new List<BankAccount>();
       
        private void creatAccountButton_Click(object sender, EventArgs e)
        {
            int x = 0;
            foreach (BankAccount account in bankAccounts)
            {
                if (accountNumberTextBox.Text == account.accountNumber)
                {
                    x++;
                }
            }
            if (x==0)
            {
                if (accountNumberTextBox.Text != "" && accountNameTextBox.Text != "")
                {
                    BankAccount creatBankAccount = new BankAccount();

                    creatBankAccount.accountNumber = accountNumberTextBox.Text;
                    creatBankAccount.accountName = accountNameTextBox.Text;
                    creatBankAccount.balance = 0;
                    bankAccounts.Add(creatBankAccount);
                    MessageBox.Show(@"Account successfully Created.");
                    accountNameTextBox.Clear();
                    accountNumberTextBox.Clear();
                }
                else
                {
                    MessageBox.Show(@"Please enter a Account Number and Account Name");
                }
            }
            else
            {
                MessageBox.Show(@"Account number already exits");
            }
            
        }

        private void depositButton_Click(object sender, EventArgs e)
        {
            if (transactionAccountNumberTextBox.Text !="")
            {
                int y = 0;
                BankAccount account = null;
                foreach (BankAccount count in bankAccounts)
                {
                    if (transactionAccountNumberTextBox.Text == count.accountNumber)
                    {
                        account = count;
                        y++;
                    }
                }
                if (y != 0)
                {
                    if (amountTextBox.Text != "")
                    {
                        if (Convert.ToDouble(amountTextBox.Text) > 0)
                        {
                            account.balance = account.GetDeposit(Convert.ToDouble(amountTextBox.Text));
                            MessageBox.Show(@"Balance successfully deposit." + Convert.ToDouble(amountTextBox.Text) + @" Taka\nYour Current Balance : " + account.balance);

                        }
                        else
                        {
                            MessageBox.Show(@"Invalid Amount");
                        }
                    }
                    else
                    {
                        MessageBox.Show(@"Enter Amount.");
                    }
                }
                else
                {
                    MessageBox.Show(@"Account number is Invalid");
                }
               
            }
            else
            {
                MessageBox.Show(@"Enter Account Number.");
            }

            transactionAccountNumberTextBox.Clear();
            amountTextBox.Clear();
        }

        private void withdrawButton_Click(object sender, EventArgs e)
        {
            int y = 0;
            BankAccount account = null;
            foreach (BankAccount count in bankAccounts)
            {
                if (transactionAccountNumberTextBox.Text == count.accountNumber)
                {
                    account = count;
                    y++;
                }
            }
            if (y != 0)
            {
                if (amountTextBox.Text != "")
                {
                    if (Convert.ToDouble(amountTextBox.Text) > 0)
                    {
                       
                        account.balance = account.GetWithdraw(Convert.ToDouble(amountTextBox.Text));
                        MessageBox.Show(@"Balance successfully deposit." + Convert.ToDouble(amountTextBox.Text) + @" Taka\nYour Current Balance : " + account.balance);
                        
                    }
                    else
                    {
                        MessageBox.Show(@"Invalid Amount");
                    }
                }
                else
                {
                    MessageBox.Show(@"Enter amount.");
                }
            }
            else
            {
                MessageBox.Show(@"Account number is Invalid");
            }
            transactionAccountNumberTextBox.Clear();
            amountTextBox.Clear();
        }

        private void reportButton_Click(object sender, EventArgs e)
        {
            if (reportAccNumberTextBox.Text !="")
            {
                int z = 0;
                BankAccount account = null;
                foreach (BankAccount count in bankAccounts)
                {
                    if (reportAccNumberTextBox.Text == count.accountNumber)
                    {
                        account = count;
                        z++;
                    }
                }
                if (z != 0)
                {
                    MessageBox.Show(account.GetInfo());
                }
                else
                {
                    MessageBox.Show(@"Account number is Invalid");
                }
            }
            else
            {
                MessageBox.Show(@"Enter Account Number.");
            }
            reportAccNumberTextBox.Clear();
        }

        private void allAccountInfoButton_Click(object sender, EventArgs e)
        {
            reportDataGridView.Rows.Clear();
            foreach (BankAccount account in bankAccounts)
            {
                reportDataGridView.Rows.Add(account.accountName, account.accountNumber, account.balance);
            }
        }
    }
}
