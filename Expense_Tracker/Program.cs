using Microsoft.VisualBasic;

namespace Expense_Tracker
{
    public class Transaction
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }

    public class Tracker
    {
        List<Transaction> transactions;
        public decimal Income { get; set; }
        public decimal Expenses { get; set; }

        public Tracker()
        {
            transactions = new List<Transaction>();
        }

        public void Add_Transaction()
        {

            Console.Write("Enter Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Description: ");
            string description = Console.ReadLine();
            
            decimal amount = 0;
            try
            {
                Console.Write("Enter Amount: ");
                amount = decimal.Parse(Console.ReadLine());
            }catch(FormatException)
            {
                Console.WriteLine("Wrong Input!!!  Enter only integer value");
                return;
            }

            DateTime date = new DateTime();
            try
            {
                Console.Write("Enter Date(DD/MM/YYYY): ");
                date = DateTime.Parse(Console.ReadLine());
            }catch (Exception)
            {
                Console.WriteLine("Wrong Input!!!  Enter Correct Date Format. Example : 04/05/2023");
                return;
            }
            
            if (amount >= 0)
            {
                Income += amount;
            }
            else
            {
                Expenses += Math.Abs(amount);
            }

            transactions.Add(new Transaction() {Title = title, Description = description, Amount = amount, Date = date });

            Console.WriteLine("Transaction Added Successfully");
        }

        public void View_Expenses()
        {
            Console.WriteLine("Expenses:");
            Console.WriteLine("Title\tDescription\tAmount\tDate");
            foreach (Transaction transaction in transactions)
            {
                if(transaction.Amount < 0)
                {
                    Console.WriteLine($"{transaction.Title}\t{transaction.Description}\t{transaction.Amount}\t{transaction.Date}");
                }
            }
        }

        public void View_Income()
        {
            Console.WriteLine("Income:");
            Console.WriteLine("Title\tDescription\tAmount\tDate");
            foreach (Transaction transaction in transactions)
            {
                if (transaction.Amount >= 0)
                {
                    Console.WriteLine($"{transaction.Title}\t{transaction.Description}\t{transaction.Amount}\t{transaction.Date}");
                }
            }

        }
        public void View_Balance()
        {
            decimal Balance = Income - Expenses;
            Console.WriteLine($"Available Balance: {Balance}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();

            while (true)
            {
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("1. Add Transaction");
                Console.WriteLine("2. View Expenses");
                Console.WriteLine("3. View Income");
                Console.WriteLine("4. View Balance");
                int choice = 0;
                try
                {
                    Console.WriteLine("Enter Your choice: ");
                    choice = Convert.ToInt16(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter only Numbers");
                }
                Console.WriteLine("---------------------------------------------------------");
                switch (choice)
                {
                    case 1:
                        {
                            tracker.Add_Transaction();
                            break;
                        }
                    case 2:
                        {
                            tracker.View_Expenses();
                            break;
                        }
                    case 3:
                        {
                            tracker.View_Income();
                            break;
                        }
                    case 4:
                        {
                            tracker.View_Balance();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong Choice Entered");
                            break;
                        }
                }
            }
        }
    }
}