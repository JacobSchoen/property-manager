using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PropMan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // List to hold the Property Accounts objects
        List<Account> PropAccountList = new List<Account>();

        public MainWindow()
        {
            InitializeComponent();
        }

        // accepts a Account object, assigns data entered by user to object's properties
        private void GetAccountInfo(Account PropAccount)
        {
            // Temp variables to hold values from user input fields
            decimal amountdue = 0m;
            decimal totalpaid =0m;
            decimal totalamountowed =0m;
            int accountnum =0;
            int zip =0;
            int payment =0;
            double phone =0; 
            //Get the account name
            PropAccount.AccountName = AccNametextBox.Text;

            //Get the account number 
            
            if (int.TryParse(AccNumbertextBox.Text, out accountnum))
            {
                //Checks to see if there is a account with that account number
                //store a boolean value of if the account number is in use
                bool contains = PropAccountList.Any(p => p.AccountNumber == accountnum);
                //checking messagebox 
                MessageBox.Show(contains.ToString());

                //logic for if the account number is not in use store it in the object
                // or if it is in by another object go to a loop where it increments one to the number
                // and checks if that is available 
                if (contains == false)
                {
                    PropAccount.AccountNumber = accountnum;
                }
                else if (contains == true)
                {
                    while(contains == true)
                    {
                        accountnum += 1;
                        contains = PropAccountList.Any(p => p.AccountNumber == accountnum);
                    }

                    PropAccount.AccountNumber = accountnum;
                }
            }
            else
            {
                //display a error
                MessageBox.Show("Invaild  account number");
                return;
            }

            //Get street name
            PropAccount.Street = streettextBox.Text;

            //Get city name
            PropAccount.City = citytextBox.Text;

            //Get state name
            PropAccount.State = statetextBox.Text;

            //get zipcode 
            if(int.TryParse(ziptextBox.Text, out zip))
            {
                if(zip.ToString().Length != 5)
                {
                    MessageBox.Show("Invaild, Not a 5 number zipcode");
                    return;
                }
                else
                {
                    PropAccount.Zipcode = zip;
                }
            }
            else
            {
                MessageBox.Show("Invaild zipcode");
                return;
            }

            //get phone number
            if (double.TryParse(mphonetextBox.Text, out phone))
            {

                PropAccount.Phone = phone;

            }
            else
            {
                MessageBox.Show("Invaild phone number");
                return;
            }

            //get total amount owed
            if (decimal.TryParse(TotalowedtextBox.Text, out totalamountowed))
            {
                PropAccount.TotalAmountOwed = totalamountowed;
            }
            else
            {
                MessageBox.Show("Invaild  totalamount number");
                return;
            }

            //get amount of payments 
            if(int.TryParse(paymenttextBox.Text, out payment))
            {
                if (payment > 0)
                {
                    PropAccount.Payments = payment;
                }
                else
                {
                    MessageBox.Show("cannot divied by zero payments");
                    return;
                }
            }

            //calculate total paid, when setting up a account put the down payment in this spot
            if(decimal.TryParse(totalpaidtextBox.Text, out totalpaid))
            {
                PropAccount.TotalPaid = totalpaid;
            }

            //calculate and get amount due
            if (payment > 0)
            {
                amountdue = (totalamountowed - totalpaid) / payment;
            }
            PropAccount.AmountDue = amountdue;
        }

        private void cleartextboxes()
        {
            AccNametextBox.Text = "";
            AccNumbertextBox.Text = "";
            streettextBox.Text = "";
            citytextBox.Text = "";
            statetextBox.Text = "";
            ziptextBox.Text = "";
            mphonetextBox.Text = "";
            paymenttextBox.Text = "";
            totalpaidtextBox.Text = "";
            TotalowedtextBox.Text = "";
            amountduetextBox.Text = "";
            deposittextBox.Text = "";
        }

        private void AddAccTextboxes()
        {
            AccNametextBox.Background = Brushes.White;
            AccNumbertextBox.Background = Brushes.White;
            streettextBox.Background = Brushes.White;
            citytextBox.Background = Brushes.White;
            statetextBox.Background = Brushes.White;
            ziptextBox.Background = Brushes.White;
            mphonetextBox.Background = Brushes.White;
            paymenttextBox.Background = Brushes.White;
            totalpaidtextBox.Background = Brushes.White;
            TotalowedtextBox.Background = Brushes.White;
            deposittextBox.Background = Brushes.WhiteSmoke;
            
            
        }

        private void RevertTextboxes()
        {
            AccNametextBox.Background = Brushes.WhiteSmoke;
            AccNumbertextBox.Background = Brushes.WhiteSmoke;
            streettextBox.Background = Brushes.WhiteSmoke;
            citytextBox.Background = Brushes.WhiteSmoke;
            statetextBox.Background = Brushes.WhiteSmoke;
            ziptextBox.Background = Brushes.WhiteSmoke;
            mphonetextBox.Background = Brushes.WhiteSmoke;
            paymenttextBox.Background = Brushes.WhiteSmoke;
            totalpaidtextBox.Background = Brushes.WhiteSmoke;
            TotalowedtextBox.Background = Brushes.WhiteSmoke;
            deposittextBox.Background = Brushes.WhiteSmoke;
        }

        private void addaccountbutton_Click(object sender, RoutedEventArgs e)
        {
            // clears text inside any field
            cleartextboxes();
            //enable text fields to be filled
            AccNametextBox.IsReadOnly = false;
            AccNumbertextBox.IsReadOnly = false;
            streettextBox.IsReadOnly = false;
            citytextBox.IsReadOnly = false;
            statetextBox.IsReadOnly = false;
            ziptextBox.IsReadOnly = false;
            mphonetextBox.IsReadOnly = false;
            paymenttextBox.IsReadOnly = false;
            totalpaidtextBox.IsReadOnly = false;
            TotalowedtextBox.IsReadOnly = false;

            //change background color of textboxes
            AddAccTextboxes();

            //disable text fields
            amountduetextBox.IsReadOnly = true;
            deposittextBox.IsReadOnly = true;

            //disable buttons not needed for creating a account
            editaccountbutton.IsEnabled = false;
            depositbutton.IsEnabled = false;
            addaccountbutton.IsEnabled = false;
            //enable buttons needed for creating a account
            Savebutton.IsEnabled = true;

            //rename labels text
            paymentlabel.Content = "# of Payments";
            totalpaidlabel.Content = "Down payment";

        }
        
        private void Savebutton_Click(object sender, RoutedEventArgs e)
        {
            //for creating a new account
            //create a Property account object
            Account newAccount = new Account();

            //get data for account
            GetAccountInfo(newAccount);

            // add the new account object to the list
            PropAccountList.Add(newAccount);

            // add an entry to the listbox
            AccountlistBox.Items.Add(newAccount.AccountNumber + "  " + newAccount.AccountName);
            
            //clear all fields in the form
            cleartextboxes();

            // enable buttons 
            editaccountbutton.IsEnabled = true;
            addaccountbutton.IsEnabled = true;
            // disable button
            Savebutton.IsEnabled = false;

            //disbale textboxes of the form
            AccNametextBox.IsReadOnly = true;
            AccNumbertextBox.IsReadOnly = true;
            streettextBox.IsReadOnly = true;
            citytextBox.IsReadOnly = true;
            statetextBox.IsReadOnly = true;
            ziptextBox.IsReadOnly = true;
            mphonetextBox.IsReadOnly = true;
            paymenttextBox.IsReadOnly = true;
            totalpaidtextBox.IsReadOnly = true;
            TotalowedtextBox.IsReadOnly = true;
            amountduetextBox.IsReadOnly = true;
            //enable textboxes
            deposittextBox.IsReadOnly = false;

            //rename labels text
            paymentlabel.Content = "Payments left";
            totalpaidlabel.Content = "       Total paid";

            //revert to disable color background
            RevertTextboxes();

        }

        private void AccountlistBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // get the index of the account you selected
            int index = AccountlistBox.SelectedIndex;
            
            //display account information in the fields
            AccNametextBox.Text = PropAccountList[index].AccountName.ToString();
            AccNumbertextBox.Text = PropAccountList[index].AccountNumber.ToString();
            streettextBox.Text = PropAccountList[index].Street.ToString();
            citytextBox.Text = PropAccountList[index].City.ToString();
            statetextBox.Text = PropAccountList[index].State.ToString();
            ziptextBox.Text = PropAccountList[index].Zipcode.ToString();
            mphonetextBox.Text = PropAccountList[index].Phone.ToString();
            paymenttextBox.Text = PropAccountList[index].Payments.ToString();
            totalpaidtextBox.Text = PropAccountList[index].TotalPaid.ToString("0.00");
            TotalowedtextBox.Text = PropAccountList[index].TotalAmountOwed.ToString("0.00");
            amountduetextBox.Text = PropAccountList[index].AmountDue.ToString("0.00");

            //enable the deposit button
            depositbutton.IsEnabled = true;
        }


        private void depositbutton_Click(object sender, RoutedEventArgs e)
        {
            //variable to hold amount deposited
            decimal Deposited;
            //Get amount from textbox
            decimal.TryParse(deposittextBox.Text, out Deposited);
            //MessageBox.Show(Deposited.ToString());

            // get the index of the account that is selected
            int index = AccountlistBox.SelectedIndex;
            
            // adds deposited amount to paid property
            PropAccountList[index].TotalPaid += Deposited;
            
            //if the current payment amount due has been mofidied from orginal
            // price after a deposit smaller than total amount due has been made
            //run through this logic once
            if(PropAccountList[index].TempAmount != 0)
            {
                if (Deposited >= PropAccountList[index].AmountDue)
                {
                    Deposited -= PropAccountList[index].AmountDue;
                    if (PropAccountList[index].Payments >= 1)
                    {
                        --PropAccountList[index].Payments;
                    }
                    PropAccountList[index].AmountDue = PropAccountList[index].TempAmount;
                }

                PropAccountList[index].TempAmount = 0;
            }
            
            //logic if deposit is bigger than amount due
            while (Deposited > PropAccountList[index].AmountDue)
            {
                Deposited -= PropAccountList[index].AmountDue;
                if (PropAccountList[index].Payments >= 1)
                {
                    --PropAccountList[index].Payments;
                }
            }
            //logic if deposit is the same as amount due
            if(Deposited == PropAccountList[index].AmountDue)
            {
                if (PropAccountList[index].Payments >= 1)
                {
                    --PropAccountList[index].Payments;
                }
                if (PropAccountList[index].Payments > 0)
                {
                    PropAccountList[index].AmountDue = (PropAccountList[index].TotalAmountOwed - PropAccountList[index].TotalPaid) / PropAccountList[index].Payments;
                }
            }
            else //logic for if the deposit is smaller than amount due
            {
                PropAccountList[index].TempAmount = PropAccountList[index].AmountDue;
                PropAccountList[index].AmountDue -= Deposited;
            }
            //refresh textboxes for current values
            amountduetextBox.Text = PropAccountList[index].AmountDue.ToString("0.00");
            totalpaidtextBox.Text = PropAccountList[index].TotalPaid.ToString("0.00");
            paymenttextBox.Text = PropAccountList[index].Payments.ToString();
            deposittextBox.Text = "";


            
        }

        private void editaccountbutton_Click(object sender, RoutedEventArgs e)
        {
            //enable text fields to be filled
            AccNametextBox.IsReadOnly = false;
            AccNumbertextBox.IsReadOnly = false;
            streettextBox.IsReadOnly = false;
            citytextBox.IsReadOnly = false;
            statetextBox.IsReadOnly = false;
            ziptextBox.IsReadOnly = false;
            mphonetextBox.IsReadOnly = false;
            paymenttextBox.IsReadOnly = false;
            totalpaidtextBox.IsReadOnly = false;
            TotalowedtextBox.IsReadOnly = false;
            //disable text fields
            amountduetextBox.IsReadOnly = true;
            deposittextBox.IsReadOnly = true;

            //change background color of textboxes
            AddAccTextboxes();

            //clear textboxes
            amountduetextBox.Text = "";
            deposittextBox.Text = "";

            //disable buttons not needed for editing a account
            editaccountbutton.IsEnabled = false;
            depositbutton.IsEnabled = false;
            addaccountbutton.IsEnabled = false;

            //enable buttons
            UpdateButton.IsEnabled = true;

            //rename labels text
            paymentlabel.Content = "# of Payments";
            totalpaidlabel.Content = "Down payment";
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            // Temp variables to hold values from user input fields
            decimal amountdue;
            decimal totalpaid;
            decimal totalamountowed;
            int accountnum;
            int zip;
            int payment;
            double phone;

            // get the index of the account you selected
            int index = AccountlistBox.SelectedIndex;

            //update the account name
            PropAccountList[index].AccountName = AccNametextBox.Text;

            //update the account number
            if (int.TryParse(AccNumbertextBox.Text, out accountnum))
            {
                PropAccountList[index].AccountNumber = accountnum;
            }
            else
            {
                //display a error
                MessageBox.Show("Invaild  account number");
                return;
            }

            //update the street
            PropAccountList[index].Street = streettextBox.Text;
            //update the city
            PropAccountList[index].City = citytextBox.Text;
            //update the state
            PropAccountList[index].State = statetextBox.Text;
            //update zipcode 
            if (int.TryParse(ziptextBox.Text, out zip))
            {
                if (zip.ToString().Length != 5)
                {
                    MessageBox.Show("Invaild, Not a 5 number zipcode");
                    return;
                }
                else
                {
                    PropAccountList[index].Zipcode = zip;
                }
            }
            else
            {
                MessageBox.Show("Invaild zipcode");
                return;
            }

            //update phone number
            if (double.TryParse(mphonetextBox.Text, out phone))
            {

                PropAccountList[index].Phone = phone;

            }
            else
            {
                MessageBox.Show("Invaild phone number");
                return;
            }

            //update amount of payments 
            if (int.TryParse(paymenttextBox.Text, out payment))
            {
                if (payment > 0)
                {
                    PropAccountList[index].Payments = payment;
                }
                else
                {
                    MessageBox.Show("cannot divide by zero payments");
                    return;
                }
            }

            //calculate total paid, when setting up a account put the down payment in this spot
            if (decimal.TryParse(totalpaidtextBox.Text, out totalpaid))
            {
                PropAccountList[index].TotalPaid = totalpaid;
            }

            //get total amount owed
            if (decimal.TryParse(TotalowedtextBox.Text, out totalamountowed))
            {
                PropAccountList[index].TotalAmountOwed = totalamountowed;
            }
            else
            {
                MessageBox.Show("Invaild  totalamount number");
                return;
            }

            //calculate and get amount due
            amountdue = (totalamountowed - totalpaid) / payment;

            if (PropAccountList[index].Payments > 0)
            {
                PropAccountList[index].AmountDue = amountdue;
            }
            //update all fields in the form
            AccNametextBox.Text = PropAccountList[index].AccountName.ToString();
            AccNumbertextBox.Text = PropAccountList[index].AccountNumber.ToString();
            streettextBox.Text = PropAccountList[index].Street.ToString();
            citytextBox.Text = PropAccountList[index].City.ToString();
            statetextBox.Text = PropAccountList[index].State.ToString();
            ziptextBox.Text = PropAccountList[index].Zipcode.ToString();
            mphonetextBox.Text = PropAccountList[index].Phone.ToString();
            paymenttextBox.Text = PropAccountList[index].Payments.ToString();
            totalpaidtextBox.Text = PropAccountList[index].TotalPaid.ToString("0.00");
            TotalowedtextBox.Text = PropAccountList[index].TotalAmountOwed.ToString("0.00");
            amountduetextBox.Text = PropAccountList[index].AmountDue.ToString("0.00");

            // enable buttons 
            editaccountbutton.IsEnabled = true;
            addaccountbutton.IsEnabled = true;
            // disable button
            UpdateButton.IsEnabled = false;

            //disbale textboxes of the form
            AccNametextBox.IsReadOnly = true;
            AccNumbertextBox.IsReadOnly = true;
            streettextBox.IsReadOnly = true;
            citytextBox.IsReadOnly = true;
            statetextBox.IsReadOnly = true;
            ziptextBox.IsReadOnly = true;
            mphonetextBox.IsReadOnly = true;
            paymenttextBox.IsReadOnly = true;
            totalpaidtextBox.IsReadOnly = true;
            TotalowedtextBox.IsReadOnly = true;
            amountduetextBox.IsReadOnly = true;
            //enable textboxes
            deposittextBox.IsReadOnly = false;

            //rename labels text
            paymentlabel.Content = "Payments left";
            totalpaidlabel.Content = "       Total paid";

            //revert to disable color background
            RevertTextboxes();
        }
    }
}
