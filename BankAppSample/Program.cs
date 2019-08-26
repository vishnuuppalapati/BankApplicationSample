using System;
using System.Collections.Generic;
using System.Linq;

namespace BankAppSample
{
    public class Program
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("@@@@@@ Bank Application @@@@@@\n");
        Main:
            Console.WriteLine("_____Home Page_____\n");
            Console.WriteLine("1.Registration Form\n");
            Console.WriteLine("2.Login Page\n");
            Console.WriteLine("3.Account Holder Details\n");
            Console.WriteLine("4.Exit\n");
            Console.WriteLine("Enter your Choice..");
            int number1 = int.Parse(Console.ReadLine());
            if (number1 > 0 && number1 <= 4)
            {
                goto Switchcase1;
            }
            else
            {
                Console.WriteLine("Enter Valid Choice..\n");
                goto Main;
            }
        Switchcase1:
            switch (number1)
            {
                case 1:
                    {
                        Program program = new Program();
                        program.RegistrationMethod();
                        goto Main;
                    }
                case 2:
                    {

                        Program program = new Program();
                        program.LoginMethod();

                        goto Main;
                    }
                case 3:
                    {
                        Program program = new Program();
                        program.LoginMethod();
                        goto Main;
                    }
                case 4:
                    {
                        break;
                    }
            }

        }
        //For Registration, Creating the object for entities of User Registration.
        public void RegistrationMethod()
        {
            Console.WriteLine("Please enter Registration details..");

            UserRegistration UserRegistrations = new UserRegistration();
            Console.WriteLine("Please enter FullName");
            string FName = Console.ReadLine();
            UserRegistrations.FullName = FName;

            Console.WriteLine("Please enter FatherName");
            string FaName = Console.ReadLine();
            UserRegistrations.FatherName = FaName;

            Console.WriteLine("Please enter MotherName");
            string MName = Console.ReadLine();
            UserRegistrations.MotherName = MName;

            Console.WriteLine("Please enter Dateofbirth(Ex:15 / 05 / 2005)");
            DateTime DOB = Convert.ToDateTime(Console.ReadLine());
            UserRegistrations.Dateofbirth = DOB;

            Console.WriteLine("Please enter Age");
            int age = int.Parse(Console.ReadLine());
            UserRegistrations.Age = age;

            Console.WriteLine("Please enter MobileNumber");
            long Phone = long.Parse(Console.ReadLine());
            UserRegistrations.MobileNumber = Phone;

            Console.WriteLine("Please enter PermanemtAddress");
            string Addr = Console.ReadLine();
            UserRegistrations.PermanentAddress = Addr;

            Console.WriteLine("Please enter ResidentialAddress");
            string Raddr = Console.ReadLine();
            UserRegistrations.ResidentialAddress = Raddr;

            Console.WriteLine("Please enter UserName");
            string UName = Console.ReadLine();
            UserRegistrations.UserName = UName;

            Console.WriteLine("Please enter Password");
            string pwd = Console.ReadLine();
            UserRegistrations.Password = pwd;

            using (var context = new BankContext())
            {
                context.UserRegistrations.Add(UserRegistrations);
                context.SaveChanges();
                Console.WriteLine("User Registration Successfully Completed!");
            }

            //Passing Values from User Registration Table by using UserRegistration Id to Account holder details table, 
            using (var context = new BankContext())
            {
                var user = context.UserRegistrations.Where(x => x.UserName == UserRegistrations.UserName).FirstOrDefault();
                if (user != null)
                {
                    AccountHolderDetails accountHolderDetails = new AccountHolderDetails();
                    accountHolderDetails.AcHolderName = user.UserName;
                    accountHolderDetails.AvailBalance = 000;
                    accountHolderDetails.RegistrationId = user.RegistrationId;
                    Random R = new Random();
                    var accnumber = ((long)R.Next(0, 100000) * (long)R.Next(0, 100000)).ToString().PadLeft(10, '0');
                    accountHolderDetails.AccountNumber = accnumber;
                    context.AccountHolderDetails.Add(accountHolderDetails);
                    context.SaveChanges();
                }

                Console.WriteLine("Account Number Successfully Generated..");
            }



        }
        //For Login by using our credentials.
        public void LoginMethod()
        {
        //For Asking the User Name.
        ReenterUname:
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            using (var context = new BankContext())
            {
                var userinfo = context.UserRegistrations.Where(s => s.UserName == username).ToList();
                if (userinfo.Count == 0)
                {
                    Console.WriteLine("Invalid user name.. Please register or Enter valid User Name");
                    goto ReenterUname;
                }
                else
                {
                //For asking the Password.
                ReenterPwd:
                    Console.WriteLine("Enter password:");
                    string pwd = Console.ReadLine();
                    if (pwd != userinfo[0].Password)
                    {
                        Console.WriteLine("Incorrect password");
                        goto ReenterPwd;
                    }
                    else
                    {
                        //For Account Holder Details.
                        Console.WriteLine("Successfully Login To Your Account.\n");
                    AHD:
                        Console.WriteLine("1.User Details\n");
                        Console.WriteLine("2.User Transactions\n");
                        Console.WriteLine("3.Logout\n");
                        Console.WriteLine("Enter Your Choice..");
                        int number2 = int.Parse(Console.ReadLine());
                        if (number2 > 0 && number2 <= 3)
                        {
                            goto Switchcase2;
                        }
                        else
                        {
                            Console.WriteLine("Enter Valid Choice..\n");
                            goto AHD;
                        }
                    Switchcase2:
                        switch (number2)
                        {
                            case 1:
                                {
                                    //Getting the Account Holder Details by using Linq Query Based on user Login Credentials..
                                    using (var ctext = new BankContext())
                                    {
                                        var acholderinfo = ctext.AccountHolderDetails.Where(a => a.AcHolderName == username).FirstOrDefault();

                                        //Printing the Account Holder Details in Table Format using Account Holder Login Credintials..
                                        IEnumerable<Tuple<string, string, decimal, int>> authors = new[] {Tuple.Create(acholderinfo.AcHolderName,acholderinfo.AccountNumber,
                                                        acholderinfo.AvailBalance,acholderinfo.RegistrationId)};

                                        //For Creating Table Format..
                                        Console.WriteLine(authors.ToStringTable(
                                          new[] { "Account Holder Name", "Account Number", "AvailableBalance", "RegistrationId" },
                                          a => a.Item1, a => a.Item2, a => a.Item3, a => a.Item4));

                                        //Console.WriteLine("Account Holder Name: {0}", acholderinfo.AcHolderName);
                                        //Console.WriteLine("Account Number:      {0}", acholderinfo.AccountNumber);
                                        //Console.WriteLine("Available Balance:   {0}", acholderinfo.AvailBalance);
                                        //Console.WriteLine("RegistrationId:      {0}", acholderinfo.RegistrationId);
                                    }
                                    goto AHD;

                                }
                            case 2:                                                                                                                            //Writing Now
                                {
                                    Console.WriteLine("Successfully Entered Into Transactions...\n");

                                    //Getting the Account Holder Details and inserting the data what we required in User Transactions..
                                    using (var cntext = new BankContext())
                                    {
                                        var transatinfo = cntext.AccountHolderDetails.Where(a => a.AcHolderName == username).FirstOrDefault();
                                        UserTransactions userTransaction = new UserTransactions();

                                        userTransaction.AccountNumber = transatinfo.AccountNumber;
                                        userTransaction.AvailBal = transatinfo.AvailBalance;
                                        userTransaction.AccountHolderName = transatinfo.AcHolderName;
                                    //userTransaction.DateofTransaction = DateTime.UtcNow;
                                    depositwithdraw:
                                        Console.WriteLine("1.Deposit");
                                        Console.WriteLine("2.Withdraw");
                                        Console.WriteLine("3.Transaction Details");
                                        Console.WriteLine("4.Back\n");
                                        Console.WriteLine("Enter User Choice.");
                                        int number3 = int.Parse(Console.ReadLine());

                                        if (number3 > 0 && number3 <= 4)
                                        {
                                            goto Switchcase3;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Enter Valid Choice..\n");
                                            goto depositwithdraw;
                                        }
                                    Switchcase3:
                                        switch (number3)
                                        {
                                            case 1:
                                                {
                                                    //Asking the Amount to Deposit in your Account..
                                                    Console.WriteLine("Enter Deposit Amount:");
                                                    decimal depositamt = decimal.Parse(Console.ReadLine());
                                                    //Adding the Entered Amount in Deposit column in Transaction Database..
                                                    userTransaction.DepositAmount = depositamt;
                                                    decimal AvailBalance = userTransaction.AvailBal + depositamt;
                                                    //Updating the Balance in User Transactions..
                                                    userTransaction.AvailBal = AvailBalance;
                                                    //Updating the Balance in Account Holder Details..
                                                    transatinfo.AvailBalance = AvailBalance;

                                                    userTransaction.DateofTransaction = DateTime.Now;
                                                    cntext.UserTransaction.Add(userTransaction);
                                                    cntext.SaveChanges();
                                                    Console.WriteLine("\nMoney Deposited Successfully..\n");
                                                    goto AHD;

                                                }
                                            case 2:
                                                {
                                                    //Asking the Amount to Withdraw from your Account..
                                                    Console.WriteLine("Enter Withdraw Amount:");
                                                    decimal withdrawamt = decimal.Parse(Console.ReadLine());
                                                    //Adding the Entered Amount in Withdraw column in Transaction Database..
                                                    userTransaction.WithdrawAmount = withdrawamt;
                                                    decimal AvailBalance = userTransaction.AvailBal - withdrawamt;
                                                    //Updating the Balance in User Transactions..
                                                    userTransaction.AvailBal = AvailBalance;
                                                    //Updating the Balance in Account Holder Details..
                                                    transatinfo.AvailBalance = AvailBalance;

                                                    userTransaction.DateofTransaction = DateTime.Now;
                                                    cntext.UserTransaction.Add(userTransaction);
                                                    cntext.SaveChanges();
                                                    Console.WriteLine("\nWithdrawl Money Successfully..\n");
                                                    goto AHD;
                                                }
                                            case 3:
                                                {

                                                    //Getting Last Transaction info from Transaction Db Related to Login Details..
                                                    var transactioninfo = cntext.UserTransaction.Where(a => a.AccountHolderName == username).LastOrDefault();
                                                    //transactioninfo=cntext.UserTransaction.Where(a=>a.AccountHolderName==username).Where(f=>f.TransactionId== )

                                                    //Printing the Last Transaction Details in Table Format using Account Holder Login Credintials..
                                                    IEnumerable<Tuple<int, string, string, decimal, decimal, DateTime, decimal>> authors = new[] {Tuple.Create(transactioninfo.TransactionId,transactioninfo.AccountHolderName,
                                                        transactioninfo.AccountNumber,transactioninfo.DepositAmount,transactioninfo.WithdrawAmount,
                                                        transactioninfo.DateofTransaction,transactioninfo.AvailBal)};

                                                    //For Creating Table Format..
                                                    Console.WriteLine(authors.ToStringTable(
                                                      new[] { "Id", "Account Holder Name", "Account Number", "DepositAmount", "WithdrawAmount", "DateofTransaction", "AvailableBalance" },
                                                      a => a.Item1, a => a.Item2, a => a.Item3, a => a.Item4, a => a.Item5, a => a.Item6, a => a.Item7));

                                                    //Console.ReadLine();

                                                    //Console.WriteLine("Account Holder Name  :   {0}", transactioninfo.AccountHolderName);
                                                    //Console.WriteLine("Account Number       :   {0}", transactioninfo.AccountNumber);
                                                    //Console.WriteLine("DepositAmount        :   {0}", transactioninfo.DepositAmount);
                                                    //Console.WriteLine("WithdrawAmount       :   {0}", transactioninfo.WithdrawAmount);
                                                    //Console.WriteLine("DateofTransaction    :   {0}", transactioninfo.DateofTransaction);
                                                    //Console.WriteLine("AvailableBalance     :   {0}\n", transactioninfo.AvailBal);
                                                    goto AHD;

                                                }
                                            case 4:
                                                {
                                                    break;
                                                }
                                        }


                                    }
                                    goto AHD;
                                }
                            case 3:
                                {
                                    Console.WriteLine("Successfully Logged Out Your Account.\n");
                                    break;
                                }
                        }
                    }

                }
            }

        }

    }

}
