using System;
namespace PassbookManagement.Framework
{
    public static class Global
    {
        public static string EMPLOYEE = "Employee";
        public static string CUSTOMER = "Customer";
    }

    public static class IdAutoCreator
    {
        
        private static uint[] count = new uint[5];

        public static string newSpendAccount()
        {
            string result = "1";
            
            //so chu so cua cus
            byte x = (byte)(Math.Log10(count[0]) + 1);

            for (byte i = 7; i > x; i--)
            {
                result += "0";
            }
            return result + count[0].ToString();
        }

        public static string newPassbook()
        {
            string result = "6";

            //so chu so cua cus
            byte x = (byte)(Math.Log10(count[1]) + 1);

            for (byte i = 8; i > x; i--)
            {
                result += "0";
            }
            return result + count[1].ToString();
        }

        public static string newCustomer()
        {
            string result = "KH";

            //so chu so cua cus
            byte x = (byte)(Math.Log10(count[2]) + 1);

            for(byte i = 7; i > x; i--)
            {
                result += "0";
            }
            return result + count[2].ToString();
        }

        public static string newTransaction()
        {
            return "GD" + count[3].ToString();
        }

        public static string newInterest()
        {
            string result = "LS";

            //so chu so cua cus
            byte x = (byte)(Math.Log10(count[4]) + 1);

            for (byte i = 2; i > x; i--)
            {
                result += "0";
            }
            return result + count[4].ToString();
        }

        

        public static void update(IdIndex index)
        {
            count[(int)index]++;
        }
    }

    public enum IdIndex
    {
        spendAccount = 0,
        passbook = 1,
        customer = 2,
        transaction = 3,
        interest = 4
    }

    public enum InterestMethod
    {
        NonCircular = 0,
        CircularCompound = 1,
        CircularNonCoumpond = 2
    }    public enum TransactionType
    {
        Withdrawing = 0,
        Submitting = 1
    }    public enum TransactionMethod
    {
        Offline = 0,
        Online = 1
    }    public enum ProfitType
    {
        Finalization = 0,
        Renewal = 1
    }}
