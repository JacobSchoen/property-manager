using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropMan
{
    class Account
    {
        //Fields 
        //General Account identify info
        private string _AccountName; // The name of the owner of the property 
        private int _AccountNumber; // The number to help straighten out properties
        //Account address information
        private string _Street; // Name of the street of the property
        private string _City; // Name of the city of the property
        private string _State; // Name of the state of the property
        private int _Zipcode; // Number of the zipcode of the property
        //Contact information
        private double _Phone; // Number of phone connected to owner of the property
        //Account payment information
        private int _Payments; // Number of payments till property is paid off 
        private decimal _AmountDue; // Amount to be paid this payment period
        private decimal _TotalPaid; // Amount that has already has been paid off 
        private decimal _TotalAmountOwed; //Total amount of that property
        private decimal _TempAmount; //store temp amount for < size deposits

        //Constructor
        public Account()
        {
            _AccountName = "";
            _AccountNumber = 0;
            _Street = "";
            _City = "";
            _State = "";
            _Zipcode = 0;
            _Phone = 0;
            _Payments = 0;
            _AmountDue = 0m;
            _TotalPaid = 0m;
            _TotalAmountOwed = 0m;
            _TempAmount = 0m;
        }

        // Account Name property
        public string AccountName
        {
            get
            {
                return _AccountName;
            }
            set
            {
                _AccountName = value;
            }
        }
            

        // Account Number property
        public int AccountNumber
        {
            get
            {
                return _AccountNumber;
            }
            set
            {
                _AccountNumber = value;
            }
        }
        

        // Street Property
        public string Street
        {
            get
            {
                return _Street;
            }
            set
            {
                _Street = value;
            }
        }

        // City property
        public string City
        {
            get
            {
                return _City;
            }
            set
            {
                _City = value;
            }
        }

        // State property
        public string State
        {
            get
            {
                return _State;
            }
            set
            {
                _State = value;
            }
        }

        //Zipcode property
        public int Zipcode
        {
            get
            {
                return _Zipcode;
            }
            set
            {
                _Zipcode = value;
            }
        }

        //Phone property
        public double Phone
        {
            get
            {
                return _Phone;
            }
            set
            {
                _Phone = value;
            }
        }

        //Payments property
        public int Payments
        {
            get
            {
                return _Payments;
            }
            set
            {
                _Payments = value;
            }
        }

        //Amount Due property
        public decimal AmountDue
        {
            get
            {
                return _AmountDue;
            }
            set
            {
                _AmountDue = value;
            }
        }

        //Total Paid property
        public decimal TotalPaid
        {
            get
            {
                return _TotalPaid;
            }
            set
            {
                _TotalPaid = value;
            }
        }

        //Total Amount Owed property
        public decimal TotalAmountOwed
        {
            get
            {
                return _TotalAmountOwed;
            }
            set
            {
                _TotalAmountOwed = value;
            }
        }

        //Temp amount property
        public decimal TempAmount
        {
            get
            {
                return _TempAmount;
            }
            set
            {
                _TempAmount = value;
            }
        }
    }
}
